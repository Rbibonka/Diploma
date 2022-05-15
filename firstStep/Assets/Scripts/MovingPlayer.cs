using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    private float speed;

    private Rigidbody2D rigidbody2d;

    private Vector2 moveVelocity;

    Vector2 moveInput;

    private Animator animator;

    private bool facingRight = true;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        animator.SetBool("IsRunning", false);
    }

    private void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        moveVelocity = moveInput.normalized * speed;

        if (!facingRight && moveInput.x > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput.x < 0)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rigidbody2d.MovePosition(rigidbody2d.position + moveVelocity * Time.fixedDeltaTime);

        //Debug.Log("õ: " + moveInput.x + "y: " + moveInput.y);

        if (moveInput.x == 0 && moveInput.y == 0)
        {
            animator.SetBool("IsRunning", false);
        }
        else
        {
            animator.SetBool("IsRunning", true);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(new Vector3(0f, 180f, 0f));
    }
}
