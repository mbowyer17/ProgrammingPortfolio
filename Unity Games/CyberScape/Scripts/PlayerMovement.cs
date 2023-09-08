using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float moveMultiplier = 6f;
    [SerializeField] float WallRunMultiplier= 3f;
    [SerializeField] Transform playerOrientation;
    float horz, verz;
    RaycastHit leftWall, rightWall, vaultableWall;
    
    Vector3 moveDir;
    Rigidbody rb;

    // Jump
    bool isGrounded;
    bool isWallLeft;
    bool isWallRight;
    bool isWall;
    bool isVaultable;
  
    [SerializeField]float wallRunJumpForce = 300f;
    [SerializeField]float playerHeight = 2f;
    [SerializeField] float jumpForce;
    [SerializeField] float vaultForce;
    [SerializeField] float airMultiplier = 1.2f;

    // Drag
    [SerializeField]float groundDrag = 3f;
    [SerializeField]float airDrag = 2f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.mass = 30;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2 + 0.1f);
        isWallLeft = Physics.Raycast(transform.position, -playerOrientation.right, out leftWall, 1f);
        isWallRight = Physics.Raycast(transform.position, playerOrientation.right, out rightWall, 1f);
        isVaultable = Physics.Raycast(transform.position, playerOrientation.forward, out vaultableWall, 3f);
        GetInput();
        GetDrag();
        Wallrun();

        Debug.DrawRay(transform.position, new Vector3(transform.position.x, playerHeight / 2 + 0.1f, 5f));
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
       
    }

    void GetInput()
    {
        horz = Input.GetAxisRaw("Horizontal");
        verz = Input.GetAxisRaw("Vertical");

        moveDir = transform.forward * verz + transform.right * horz;
    }


    void FixedUpdate()
    {
        Move();
        //Vault();
    }

    void GetDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }
    }

    void Move()
    {
        
        if (isGrounded)
        {
            rb.AddForce(moveDir.normalized * moveSpeed * moveMultiplier, ForceMode.Acceleration);
            
        }
        else if(!isGrounded)
        {
            rb.AddForce(moveDir.normalized * moveSpeed * moveMultiplier * airMultiplier, ForceMode.Acceleration);
            rb.useGravity = true;
        }
        
    }
    void Wallrun()
    {
        rb.useGravity = false;
        
        if (isWallRight)
        {
            
            rb.AddForce(moveDir.normalized * moveSpeed * WallRunMultiplier, ForceMode.Force);
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.drag = airDrag;

        }
        if (isWallRight && Input.GetKeyDown(KeyCode.Space))
        {
            print("Hello");
            rb.AddForce(rightWall.normal * wallRunJumpForce, ForceMode.Impulse);
            rb.AddForce(transform.up * wallRunJumpForce * 3f, ForceMode.Impulse);
            isWallRight = false;
        }

        if (isWallLeft)
        {
            rb.AddForce(moveDir.normalized * moveSpeed * WallRunMultiplier, ForceMode.Force);
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.drag = airDrag;
        }
        if (isWallLeft && Input.GetKeyDown(KeyCode.Space))
        {
            print("Hello");
            rb.AddForce(leftWall.normal * wallRunJumpForce, ForceMode.Impulse);
            rb.AddForce(transform.up * wallRunJumpForce * 3f, ForceMode.Impulse);
            isWallLeft = false;
        }

    }
    
   void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }
    /*void Vault()
    {
        if (isVaultable) 
        {
            if (vaultableWall.collider.gameObject.tag == "Vaultable")
            {
                rb.AddForce(transform.up * vaultForce, ForceMode.Impulse);
            }
           
        }
        
    }*/
  
}
