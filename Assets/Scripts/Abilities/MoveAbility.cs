using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Drawing;
using UnityEngine;

public class MoveAbility : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;

    [Header("Settings")]
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float groundDrag;
    private float movementSpeed;

    // JUMP STUFF 
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float playerHieght;
    private bool grounded;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float airMultiplier;
    private bool readyToJump = true;
    // SLOPE STUFF
    [SerializeField] private float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    // SLIDING STUFF
    [SerializeField] private float maxSlideTime;
    [SerializeField] private float slideForce;
    [SerializeField] private float slideYscale;
    private float startYscale;
    private float slideTimer;
    private bool isSliding;


    public MovementState movementState;
    public enum MovementState
    {
        walking,
        sprinting,
        air
    }

    private void Start()
    {
        startYscale = gameObject.transform.localScale.y;

    }

    private void FixedUpdate()
    {
        if (isSliding)
        {
            SlidingMovement();
        }
    }

    private void Update()
    {
        MovementStateHandler();
    }
    private void MovementStateHandler()
    {
        if (grounded && Input.GetKey(KeyCode.LeftShift))
        {
            movementState = MovementState.sprinting;
            movementSpeed = sprintSpeed;
        } else if (grounded)
        {
            movementState = MovementState.walking;
            movementSpeed = walkSpeed;
        } else if (!grounded)
        {
            movementState = MovementState.air;  
        }
    }


    // call in fixed update
    public void Move(Vector3 moveDirection)
    {
        Vector3 forwardMovement = moveDirection.z * transform.forward;
        Vector3 sidewaysMovement = moveDirection.x * transform.right;

        Vector3 movementVector = (forwardMovement + sidewaysMovement);

        //controller.Move(movementVector * Time.deltaTime * movementSpeed);

        // on slope
        if (OnSlope())
        {
            rb.AddForce(GetSlopeMoveDirection(movementVector) * movementSpeed * 20f, ForceMode.Force);
            if (rb.velocity.y > 0)
            {
                rb.AddForce(Vector3.down * 120f, ForceMode.Force);
            }
        }

        if (grounded)
        {
            rb.AddForce(movementVector * movementSpeed * 10f, ForceMode.Force);
        } else if (!grounded)
        {
            rb.AddForce(movementVector * movementSpeed * airMultiplier * 10f, ForceMode.Force);
        }

        // turn off gravity while on slope
        rb.useGravity = !OnSlope();
    }

    private void SpeedControl()
    {
        if (OnSlope() && !exitingSlope)
        {
            if (rb.velocity.magnitude > movementSpeed)
            {
                rb.velocity = rb.velocity.normalized * movementSpeed;
            }
        } 
        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            if (flatVel.magnitude > movementSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * movementSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }
    }

    public void GroundDrag()
    {
        grounded = Physics.Raycast(transform.position + new Vector3(0, 1, 0), Vector3.down, playerHieght * 0.5f + 0.2f, groundLayer);

        if (grounded)
        {
            rb.drag = groundDrag;
        } else
        {
            rb.drag = 0;
        }
    }

    public void Jump()
    {
        if (readyToJump && grounded)
        {
            readyToJump = false;
            exitingSlope = true;

            // reset y vel so we always jump the same hieght
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

            Invoke(nameof(JumpReset), jumpCooldown);
        }
    }

    private void JumpReset()
    {
        readyToJump = true;
        exitingSlope = false;
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), Vector3.down, out slopeHit, playerHieght * 0.5f + 0.3f))
        {
            // find the angle of the slope
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }
        return false;
    }

    private Vector3 GetSlopeMoveDirection(Vector3 moveDir)
    {
        return Vector3.ProjectOnPlane(moveDir, slopeHit.normal).normalized;
    }

    public void StartSlide()
    {
        isSliding = true;

        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, slideYscale, gameObject.transform.localScale.z);
        rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);

        slideTimer = maxSlideTime;
    }

    private void SlidingMovement()
    {
        rb.AddForce(transform.forward * slideForce, ForceMode.Force);

        slideTimer -= Time.deltaTime;
        
        if (slideTimer <= 0 || Input.GetKey(KeyCode.Space))
        {
            StopSliding();
        }
    }

    public void StopSliding()
    {
        if (isSliding)
        {
            isSliding = false;

            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, startYscale, gameObject.transform.localScale.z);
        }
    }
}
