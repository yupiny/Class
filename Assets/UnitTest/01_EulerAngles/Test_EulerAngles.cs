using UnityEngine;

public class Test_EulerAngles : MonoBehaviour
{
    [SerializeField]
    private float speed = 20.0f;

    private float degree;

   private void Start ()
   {
        degree += speed * Time.deltaTime;
        transform.eulerAngles = new Vector3(degree, 0, 0);
   }

    private void OnGUI()
    {
        GUILayout.Label($"Euler Angle : {transform.eulerAngles}");
    }
}