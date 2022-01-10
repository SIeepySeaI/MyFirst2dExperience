using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    public float speed = 20f;
    [HideInInspector]
    public bool mustPatrol;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public bool mustFlip = false;
    public LayerMask groundLayer;
    public Animator animator;

    private void Start()
    {
        mustPatrol = true;
    }
    private void Update()
    {
        if (mustPatrol)
        {
            if (mustFlip)
            {
                Flip();
            }
            //���� � �������
            rb.velocity = new Vector2(speed*Time.fixedDeltaTime, rb.velocity.y);
            animator.SetFloat("Speed",Mathf.Abs(rb.velocity.x));

        }
    }
    private void FixedUpdate()
    {
        //������ ��� ��������� ���������
        if (mustPatrol)
        {
            mustFlip = !Physics2D.OverlapCircle(groundCheck.position,0.1f,groundLayer);
        }
    }
    //��������������� � ������ �������
    void Flip()
    {
            mustPatrol = false;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            speed *= -1;
            mustPatrol = true;
    }
}
