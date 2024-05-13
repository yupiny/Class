using UnityEngine;

public partial class Player : MonoBehaviour
{
	[SerializeField]
	private float walkSpeed = 2.0f;
    [SerializeField]
    private float runSpeed = 4.0f;
    private Animator animator;
    [SerializeField]
    private GameObject particlePrefab;

    [SerializeField]
    private GameObject swordPrefab;
    private GameObject swordDestination;

    private Sword sword;

    private Transform holsterTransform;
    private Transform handTransform;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
	{
        //SearchTransform(transform);
        holsterTransform = transform.FindChildByName("Holster_Sword");
        handTransform = transform.FindChildByName("Hand_Sword");
        if (swordPrefab != null)
        {
            swordDestination = Instantiate<GameObject>(swordPrefab,holsterTransform);
            sword = swordDestination.GetComponent<Sword>();
        }

	}

    private void SearchTransform(Transform parent)
    {
        print(parent.name);

        for(int i=0; i<parent.childCount; i++)
        {
            SearchTransform(parent.GetChild(i));
        }
    }


    Vector3 direction;
    private void Update()
    {
        UpdateMoving();
        UpdateRaycast();
        UpdateDrawing();
        UpdateAttacking();
    }

    // 움직일 수 있는지
    private bool bCanMove = true;

    private void UpdateMoving()
    {
        if (bCanMove == false)
            return;


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool bRun = Input.GetButton("Run");

        float speed = bRun ? runSpeed : walkSpeed;

        direction = Vector3.forward * vertical + Vector3.right * horizontal;
        direction = direction.normalized * speed;
        //Debug.Log(direction);
        transform.Translate(direction * Time.deltaTime);

        animator.SetFloat("SpeedZ", direction.magnitude);
        //Debug.Log(direction.magnitude); 
    }

    private void UpdateRaycast()
    {
        if (Input.GetMouseButtonDown(1) == false)
            return;

        Ray ray = new Ray();
        ray.origin = transform.position + new Vector3(0,1.5f,0);
        ray.direction = transform.forward;

        int layerMask = LayerMask.GetMask("Raycast", "Water");


        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5f, layerMask))
        {
            print(hit.collider.gameObject.name);
            if(particlePrefab != null)
                Instantiate<GameObject>(particlePrefab,hit.transform.position,Quaternion.identity);
        }
        Debug.DrawRay(ray.origin,ray.direction*5f,Color.red,3f);
    }

    private void OnGUI()
    {
        //GUI.color = Color.red;
        //GUILayout.Label(direction.ToString());
    }
}
