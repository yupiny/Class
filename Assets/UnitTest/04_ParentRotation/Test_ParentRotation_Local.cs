using UnityEngine;

public class Test_ParentRotation_Local : MonoBehaviour
{
    [SerializeField]
    public float speed = 40.0f;
   public void Update ()
   {
      transform.Rotate(0, speed *Time.deltaTime, 0);
    }
}