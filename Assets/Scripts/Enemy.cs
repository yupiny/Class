using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamagable
{
    private Animator animator;
    private Rigidbody rigidbody;
    private StatusComponent status;

    private List<Material> materialsList;
    private List<Color> origincolorList;

    private void Awake()
    {
        materialsList= new List<Material>();
        rigidbody = GetComponent<Rigidbody>();
        origincolorList= new List<Color>();

        animator = GetComponent<Animator>();
        status = GetComponent<StatusComponent>();

        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach(Renderer render in renderers)
        {
            materialsList.Add(render.material);
            origincolorList.Add(render.material.color);
        }
    }

    private void Start()
	{

	}
    public void Damage(GameObject attacker, Sword causer, DoActionDate data)
    {
        status.Damage(data.Power);

        foreach (Material material in materialsList)
            material.color = Color.red;

        Invoke("RestoreColor", 0.15f);

        FrameComponent.Instance.Delay(data.StopFrame);

        if(status.Dead == false)
          transform.LookAt(attacker.transform, Vector3.up);

        //Todo : particle
        {
            if(data.Hitparticle != null)
            {
                GameObject obj = Instantiate(data.Hitparticle, transform, false);
                obj.transform.localPosition = data.HitParticlePositionOffset;
                obj.transform.localScale = data.HitParticleScaleOffset;
            }
        }

        if (status.Dead == false)
        {
            animator.SetTrigger("Damaged");

            rigidbody.isKinematic = false;

            float launch = rigidbody.drag * data.Distance *10.0f;
            rigidbody.AddForce(-transform.forward * launch);

            StartCoroutine(Change_IsKinemetics(5));

            return;
        }
        // »ç¸Á Ã³¸®
        animator.SetTrigger("Dead");
        Collider collider = GetComponent<Collider>();
        collider.enabled = false;

        Destroy(gameObject,5.0f);
    }

    private void RestoreColor()
    {
        for(int i=0; i<materialsList.Count; i++)
        {
            materialsList[i].color = origincolorList[i];
        }
    }

    private IEnumerator Change_IsKinemetics(int frame)
    {
        for(int i=0; i<frame; i++)
            yield return new WaitForFixedUpdate();

        rigidbody.isKinematic = true;
    }
}
