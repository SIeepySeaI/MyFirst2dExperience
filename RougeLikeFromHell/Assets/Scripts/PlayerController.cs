using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //перемещение
    public float speed;
    public float jumpForce;
    private float moveInput;

    //прыжки
    private bool isGrounded;
    public Transform grounCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private Rigidbody2D rb;

    //разворот
    private bool facingRight = true;

    //переключение анимации
    public Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(grounCheck.position,checkRadius,whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }
    void Update()
    {
        if (isGrounded==true)
        {
            animator.SetBool("IsJumping", false);
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
