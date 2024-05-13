using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[SerializeField]
public class DoActionDate
{
    public float Power;
    public int StopFrame;
    public float Distance;

    public GameObject Hitparticle;
    public Vector3 HitParticlePositionOffset;
    public Vector3 HitParticleScaleOffset = Vector3.one;
}

public class Sword : MonoBehaviour
{
    [SerializeField]
    DoActionDate[] doActionDates;

    private new Collider collider;
    private GameObject rootObject;

    private List<GameObject> hittedList;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        rootObject = transform.root.gameObject;
        hittedList = new List<GameObject>();
    }

    private void Start()
	{
        End_Collision();
	}

    // 검 트리거
    private void OnTriggerEnter(Collider other)
    {
        if (rootObject == other.gameObject)
            return;

        if (hittedList.Contains(other.gameObject) == true)
            return;


        hittedList.Add(other.gameObject);
        IDamagable damge = other.gameObject.GetComponent<IDamagable>();
        {
            Player player = rootObject.GetComponent<Player>();

            if(player != null && damge != null)
               damge.Damage(rootObject, this, doActionDates[player.ComboIndex]);
        }
        
    }



    public void Begin_Collision()
    {
        collider.enabled = true;
    }
    public void End_Collision()
    {
        collider.enabled = false;
        hittedList.Clear();
    }
}
