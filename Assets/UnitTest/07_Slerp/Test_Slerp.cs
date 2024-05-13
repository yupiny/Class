using UnityEngine;

public class Test_Slerp : MonoBehaviour
{
    [SerializeField]
    private Vector3 angle;

    [SerializeField, Range(0, 1)]
    private float range;

    private Vector3 forward;
    private Quaternion rotation;

    private void Start()
    {
        forward = transform.forward;
        rotation = transform.rotation;

    }

    private void Update()
    {
        Quaternion q = Quaternion.Euler(angle);
        Vector3 direction = q * forward;

        Vector3 position = transform.position;
        position.y += 1.5f;

        Debug.DrawLine(position, position+forward * 5, Color.red);
        Debug.DrawLine(position, position + direction * 5, Color.blue);

        Quaternion q2 = Quaternion.Slerp(rotation, q, range);
        Vector3 direction2 = q2 * forward;
        Debug.DrawLine(position, position + direction2 * 5, Color.green);
    }
}