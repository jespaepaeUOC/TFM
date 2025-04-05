using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public Transform[] spikesCkeck;
    public LayerMask groundLayer;
    public LayerMask spikeLayer;

    private float horizontal;
    private int jumpsLeft = 1;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool canDash = true;
    private bool isDashing = false;
    private float dashingPower = 16f;
    private float dashingTime = 0.2f;
    private bool hasJustDied = false;

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
        ResetJumps();
    }

    void Update()
    {
        if(isDashing)
        {
            return;
        }

        if (IsTouchingSpikes())
        {
            RespawnPlayer();
            //Destroy(this.gameObject);
            //SceneManager.LoadScene("GameScene");
        }

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }

        if (IsGrounded())
        {
            ResetDash();
            ResetJumps();
        }

        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && jumpsLeft > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumpsLeft--;
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

    private void ResetJumps()
    {
        jumpsLeft = 1;
    }

    private void ResetDash()
    {
        canDash = true;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if(canDash)
        {
            StartCoroutine(DashCoroutine());
        }
    }

    private IEnumerator DashCoroutine()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
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

    private void RespawnPlayer()
    {
        RoomsManager roomsManager = GameObject.Find("Rooms").GetComponent<RoomsManager>();
        GameObject activeRoom = roomsManager.getActiveRoom();
        if (activeRoom != null)
        {
            SetHasJustDied(true);
            roomsManager.spawnDice();
            this.transform.position = activeRoom.transform.Find("RespawnPoint").position;
            activeRoom.transform.Find("SpikeSpawner").GetComponent<SpikeSpawner>().DeleteAllSpikes();
        }
    }

    public bool GetHasJustDied()
    {
        return hasJustDied;
    }

    public void SetHasJustDied(bool NewhasJustDied)
    {
        hasJustDied = NewhasJustDied;
    }
}
