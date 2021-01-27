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

    //переключение скорости
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
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }
        
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
