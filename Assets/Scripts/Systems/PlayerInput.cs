using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance;

    //Directional Inputs
    private Vector2 lookDirection;
    [SerializeField] private Vector3 moveDirection;

    [SerializeField] private MoveAbility moveAbility;
    [SerializeField] private LookAbility lookAbility;
    [SerializeField] private ShootingAbility shootAbility;
    [SerializeField] private InteractAbility interactAbility;
    [SerializeField] private CommanderAbility commanderAbility;
    [SerializeField] private GrabbingAbility grabbingAbility;

    [SerializeField] private float mouseSensitivity;

    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // when we die disable player input
        GetComponent<HealthSystem>().OnDead += () =>
        {
            this.enabled = false;
        };

        //Control of Mouse Cursor
        Cursor.visible = false; //Visibility to hidden
        Cursor.lockState = CursorLockMode.Locked; //Locked to the center of the screen
    }


    private void FixedUpdate()
    {
        if (moveAbility)
        {
            Vector3 moveDir = new Vector3();
            moveDir.x = moveDirection.x = Input.GetAxisRaw("Horizontal");
            moveDir.z = moveDirection.z = Input.GetAxisRaw("Vertical");
            moveAbility.Move(moveDir);
        }
    }

    void Update()
    {
        if (moveAbility)
        {
            moveAbility.GroundDrag();

            if (Input.GetKey(KeyCode.Space))
            {
                moveAbility.Jump();
            }

            if (Input.GetKeyDown(KeyCode.LeftControl) && (moveDirection.x != 0 || moveDirection.z != 0))
            {
                moveAbility.StartSlide();
            }

            if (Input.GetKeyUp(KeyCode.LeftControl)) {
                moveAbility.StopSliding();
            }
        }

        if (lookAbility)
        {
            lookDirection.x += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
            lookDirection.y += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

            float angleOnY = lookDirection.y;
            lookDirection.y = Mathf.Clamp(angleOnY, -80, 80);

            lookAbility.Look(lookDirection);
        }

        if (shootAbility && Input.GetMouseButtonDown(0))
        {
            shootAbility.Shoot();
        }



        if(interactAbility && Input.GetKeyDown(KeyCode.F))
        {
            interactAbility.Interact();
        }

        if (commanderAbility && Input.GetMouseButtonDown(1))
        {
            commanderAbility.Command();
        }

        if (grabbingAbility && Input.GetMouseButtonDown(1))
        {
            grabbingAbility.ThrowObject();
        }
       
        
    }

    //Testing the sphere location
    private void OnDrawGizmos()
    {
        //Drawing a sphere right at the feet of the player
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}
