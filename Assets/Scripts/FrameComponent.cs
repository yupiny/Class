using System.Collections;
using UnityEngine;

public class FrameComponent : MonoBehaviour
{
    //[SerializeField]
    //private int updateCount;

    //[SerializeField]
    //private int fixedUpdateCount;

    private static FrameComponent instance;
   private void Awake ()
   {
        if (instance == null)
         instance = this;
       
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject); //���ε�ÿ��� ��ü����, �ı�x
   }
    public static FrameComponent Instance => instance;

    private Animator[] animators;

    private void Start()
    {
        animators = FindObjectsOfType<Animator>();
    }

    public void Delay(int frame)
    {
        StartCoroutine(Start_Delay(frame));
    }

    private IEnumerator Start_Delay(int frame)
    {
        foreach(Animator animator in animators)
        {
            if (animator != null)
                animator.speed = 0.0f;
        }

        for (int i = 0; i < frame; i++)
            yield return new WaitForFixedUpdate();

        foreach (Animator animator in animators)
        {
            if (animator != null)
                animator.speed = 0.0f;
        }
    }

    private void Update ()
    {
        //updateCount++;
    }

    private void FixedUpdate()
    {
        //fixedUpdateCount++;
    }
}
