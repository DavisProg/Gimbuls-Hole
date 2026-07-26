using UnityEngine;

public class JumpAnimator : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    float horizontalInput;
    [Header("Animation")]
    [SerializeField] float fallDelay = 2f;

    bool isFacingRight = false;
    bool isGrounded = true;
    bool hasJumped = false;
    bool isGrabbing = false;
    bool isHurting = false;
    bool isDead = false;

    float fallTimer = 0f;

    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Play the starting idle animation when the game begins.
        animator.Play("StartIdle");
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        FlipSprite();

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            isGrounded = false;
            hasJumped = true;
            fallTimer = 0f;

            animator.Play("Jump");
        }

        // Animation priorities
        if (isDead)
        {
            animator.Play("Death");
            return;
        }

        if (isHurting)
        {
            animator.Play("Hurt");
            return;
        }

        if (isGrabbing)
        {
            animator.Play("WallIdle");
            return;
        }

        // Initial idle before the first jump
        if (!hasJumped)
        {
            animator.Play("StartIdle");
            return;
        }

        // Falling
        if (!isGrounded && rb.linearVelocity.y < -0.1f)
        {
            fallTimer += Time.deltaTime;

            if (fallTimer >= fallDelay)
            {
                animator.Play("Fall");
            }
        }
        else
        {
            fallTimer = 0f;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    void FlipSprite()
    {
        if ((isFacingRight && horizontalInput < 0f) ||
            (!isFacingRight && horizontalInput > 0f))
        {
            isFacingRight = !isFacingRight;

            Vector3 scale = transform.localScale;
            scale.x *= -1f;
            transform.localScale = scale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        fallTimer = 0f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }

    // Call these methods from your health/wall scripts.
    public void SetWallGrab(bool grabbing)
    {
        isGrabbing = grabbing;
    }

    public void TakeDamage()
    {
        isHurting = true;
        animator.Play("Hurt");
    }

    public void StopHurting()
    {
        isHurting = false;
    }

    public void Die()
    {
        isDead = true;
        animator.Play("Death");
    }
}