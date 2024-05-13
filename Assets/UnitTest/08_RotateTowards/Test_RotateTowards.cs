using UnityEngine;

public class Test_RotateTowards : MonoBehaviour
{
    [SerializeField]
    private Vector3 angle;


    [SerializeField]
    private float speed = 1.0f;

    private Vector3 forward;
    private Quaternion rotation;

    [SerializeField]
    private float delta = 0.0f;

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

        Debug.DrawLine(position, position + forward * 5, Color.red);
        Debug.DrawLine(position, position + direction * 5, Color.blue);

       //delta += speed * Time.deltaTime;

        Quaternion q2 = Quaternion.RotateTowards(rotation, q, delta);
        Vector3 direction2 = q2 * forward;
        Debug.DrawLine(position, position + direction2 * 5, Color.green);
    }

    private void OnGUI()
    {
        GUILayout.Label(delta.ToString("0.000000"));
    }
}