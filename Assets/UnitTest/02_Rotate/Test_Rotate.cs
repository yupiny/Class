using UnityEngine;

public class Test_Rotate : MonoBehaviour
{
   private void Start ()
   {
        //Vector3 angle = transform.rotation.eulerAngles;
        //angle.y = 45.0f;
        //transform.rotation = Quaternion.Euler(angle);

        transform.Rotate(45, 0, 0);
        //transform.Rotate(0, 45, 0);
   }

    [SerializeField]
    private float speed = 20.0f;

    private void Update()
    {
        transform.Rotate((speed * Time.deltaTime), 0, 0);
        //transform.Rotate(0, (speed*Time.deltaTime), 0);
    }

    private void OnGUI()
    {
        GUILayout.Label($"Euler Angle : {transform.eulerAngles}");
    }


}