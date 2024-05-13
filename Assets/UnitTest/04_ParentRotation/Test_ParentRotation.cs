using UnityEngine;

public class Test_ParentRotation : MonoBehaviour
{
    [SerializeField]
    public float speed = 20.0f;
   public void Update ()
   {
      transform.Rotate(0, 20.0f*Time.deltaTime, 0);

      Debug.DrawLine(transform.position, transform.position + transform.forward * 4.0f, Color.red);
    }
}