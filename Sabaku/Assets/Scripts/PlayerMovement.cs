using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public Transform[] spikesCkeck;
    public LayerMask groundLayer;
    public LayerMask spikeLayer;

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (IsTouchingSpikes())
        {
            Destroy(this.gameObject);
        }

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }

        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool IsTouchingSpikes()
    {
        if (Physics2D.OverlapCircle(spikesCkeck[0].position, 0.2f, spikeLayer) || Physics2D.OverlapCircle(spikesCkeck[1].position, 0.2f, spikeLayer) ||
                Physics2D.OverlapCircle(spikesCkeck[2].position, 0.2f, spikeLayer) || Physics2D.OverlapCircle(spikesCkeck[3].position, 0.2f, spikeLayer))
        {
            return true;
        } 
        else 
        {
            return false;
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    private void UpdateAnimation()
    {
        if(IsGrounded())
        {
            animator.SetBool("isInverting", false);
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
            if (rb.velocity.x > 0)
            {
                animator.SetBool("isRunning", true);
            }
            else 
            {
                animator.SetBool("isRunning", false);
            }
        }
        else
        { 
            animator.SetBool("isRunning", false);
            if (rb.velocity.y > 10)
            {
                animator.SetBool("isJumping", true);
                animator.SetBool("isFalling", false);
            }
            else if (rb.velocity.y < 10 && rb.velocity.y > -8)
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isFalling", false);
                animator.SetBool("isInverting", true);
            }
            else
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isFalling", true);
            }
        }
    }
}
