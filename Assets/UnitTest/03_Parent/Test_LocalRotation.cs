using UnityEngine;

public class Test_LocalRotation : MonoBehaviour
{
    [SerializeField]
    private Vector3 euler= Vector3.zero;

    //private void Reset()
    //{

    //    print($"Reset : {euler}");   
    //}

    private void OnValidate()
    {
        //print($"validate : {euler}");

        transform.localRotation = Quaternion.Euler(euler);
    }

    private void Start ()
   {
      print($"World : {transform.eulerAngles}");
        print($"Local : {transform.localRotation.eulerAngles}");
        print($"Parent : {transform.parent.eulerAngles}");
    }
}