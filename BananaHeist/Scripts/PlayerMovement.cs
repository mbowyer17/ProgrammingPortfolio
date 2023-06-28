using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] Camera cameraPlayer;
    [SerializeField] float grappfleFOV = 95f;
    [SerializeField] float normalFOV = 95f;
    [SerializeField] Transform orientation;

    [Header("Movement")]
    public float speed;
    
    [SerializeField] float moveSpeed;
    [SerializeField] float grappleSpeed;
    [SerializeField] float swingSpeed;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    [SerializeField] float groundDrag;

    public bool enableMovementAfterLanding; //Make it private after debugging

    [Header("Jump")]
    [SerializeField] float jumpForce;
    [SerializeField] float jumpCooldown;
    [SerializeField] float airMultiplier;
    bool readyToJump;

    //[HideInInspector] public float walkSpeed;
    //[HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    [SerializeField] float playerHeight;
    [SerializeField] LayerMask Ground;
    bool grounded;

    public Animator pA;
    //States
    public MovementState state;
    public enum MovementState //Here we can also add sprinting 
    {
        moving,
        freeze,
        grappling,
        swinging,
        air
    }
    public bool freeze;
    public bool activeGrap;
    public bool activeSwing;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;

        //Fov start
        normalFOV = cameraPlayer.fieldOfView;

        //Speed
        speed = moveSpeed;
    }

    private void Update()
    {
        //Ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, Ground);

        GetMovementInput();
        SpeedControl();
        StateHandler();

        // handle drag
        if (grounded && !activeGrap)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        //GetComponent<Camera>().DoFiel
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void StateHandler()
    {
        //State: Freeze
        if (freeze)
        {
            state = MovementState.freeze;
            speed = 0f;
            rb.velocity = Vector3.zero;
            pA.SetBool("Run", false);
        }

        //State: Grappling
        else if (activeGrap)
        {
            state = MovementState.grappling;
            speed = grappleSpeed;
            pA.SetBool("Run", false);
        }

        //State: Swinging
        else if (activeSwing)
        {
            state = MovementState.swinging;
            speed = swingSpeed;
            pA.SetBool("Run", false);
        }

        //State: Moving
        else if(grounded)
        {
            state = MovementState.moving;
            speed = moveSpeed;
            pA.SetBool("Run", true);
        }

        //State: Air
        else
        {
            state = MovementState.air;
            pA.SetBool("Run", false);
        }
    }

    //INPUT
    private void GetMovementInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    //MOVEMENT
    private void MovePlayer()
    {
        if (activeGrap) return;
        if (activeSwing) return;

        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * speed * 10f * airMultiplier, ForceMode.Force);
    }

    //SPEED
    private void SpeedControl()
    {
        if (activeGrap) return;

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    //JUMP
    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }

    //CHANGE VELOCITY
    //private bool enableMovementAfterLanding;
    private Vector3 velocityToChange;
    private void ChangeVelocity()
    {
        print("ChangeVelocity - true");
        enableMovementAfterLanding = true;
        rb.velocity = velocityToChange;

        //camera.DoFov(grappleFov);
        cameraPlayer.fieldOfView = grappfleFOV;
    }

    //JUMP GRAPPLE
    public void JumpGrapple(Vector3 targetPosition, float trajectoryHeight)
    {
        print("Reset called - jump");
        activeGrap = true;

        velocityToChange = CalculateJumpVelocity(transform.position, targetPosition, trajectoryHeight);
        Invoke(nameof(ChangeVelocity), 0.1f);

        Invoke(nameof(ResetRestrictions), 3f);
    }

    //JUMP VELOCITY 
    public Vector3 CalculateJumpVelocity(Vector3 startPoint, Vector3 endPoint, float trajectoryHeight)
    {
        float gravity = Physics.gravity.y;
        float displacementY = endPoint.y - startPoint.y;
        Vector3 displacementXZ = new Vector3(endPoint.x - startPoint.x, 0f, endPoint.z - startPoint.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * trajectoryHeight);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * trajectoryHeight / gravity)
            + Mathf.Sqrt(2 * (displacementY - trajectoryHeight) / gravity));

        return velocityXZ + velocityY;
    }

    //RESET RESTRICTIONS - resets after 3 seconds just in case something bugs during grappling 
    public void ResetRestrictions()
    {
        activeGrap = false;
        //cam.DoFov(85f);
        cameraPlayer.fieldOfView = normalFOV;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print("Collided");
        if (enableMovementAfterLanding)
        {
            print("redo");
            enableMovementAfterLanding = false;
            ResetRestrictions();

            GetComponent<Grappling>().StopGrapple();
        }
    }

}