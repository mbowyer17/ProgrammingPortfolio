using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SecondPlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    [SerializeField] float fallSpeed = -8f;
    [SerializeField]private float jumpinPower = 10f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    Animator anim;
    bool flipped;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal2");
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded())
        {
            Jump(jumpinPower);
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            anim.SetBool("Jump", true);
        }
        
        if (!isGrounded())
        {
            rb.velocity -= new Vector2(rb.velocity.x, fallSpeed * Time.deltaTime);
            anim.SetBool("Jump", false);
        }
    }

    public void Jump(float power)
    {
        rb.velocity = new Vector2(rb.velocity.x, power);
        anim.SetBool("Jump", true);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if(rb.velocity.x > 0) //goes right
        {
            anim.SetBool("Run", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            FindObjectOfType<AudioManager>().PlayAudio("Run");
        }
        else if(rb.velocity.x < 0) //goes left
        {
            anim.SetBool("Run", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            FindObjectOfType<AudioManager>().PlayAudio("Run");
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        if(flipped == false)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            flipped = true;
        }
    }
}
