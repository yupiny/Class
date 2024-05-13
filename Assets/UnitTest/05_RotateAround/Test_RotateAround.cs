
using UnityEngine;

public class Test_RotateAround : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float speed = 5.0f;
   private void Update ()
   {
        if (target == null)
            return;

        transform.RotateAround(target.transform.position, Vector3.up, speed * Time.deltaTime);

        Quaternion q = transform.rotation;
        Vector3 e = q.eulerAngles;
        e.y = 0.0f;
        transform.eulerAngles= e;
   }
}