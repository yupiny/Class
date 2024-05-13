using UnityEngine;

public class Test_LookRotation : MonoBehaviour
{
    [SerializeField]
    private GameObject[] target = new GameObject[2];
    
    GameObject lookTarget = null;

   private void Update ()
   {
        

      if(Input.GetKeyDown(KeyCode.Alpha1))
            lookTarget = target[0];
      else if(Input.GetKeyDown(KeyCode.Alpha2))
            lookTarget = target[1];
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            lookTarget = null;

        if (lookTarget == null)
        {
            transform.rotation = Quaternion.identity;

            return;
        }

        Vector3 tagetPosition = lookTarget.transform.position;
        Vector3 position = transform.position;

        Vector3 direction = tagetPosition - position;
        transform.rotation = Quaternion.LookRotation(direction.normalized, Vector3.up);

        Debug.DrawLine(position, position + transform.forward * direction.magnitude, Color.red);
   }
}