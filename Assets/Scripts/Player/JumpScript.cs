using UnityEngine;

public class JumpScript : MonoBehaviour
{
    private JumpArrow jumpArrow;
    public Rigidbody2D rb;
    private bool canJump = true;
    [SerializeField] float jumpForce;
    [SerializeField] float forwardJumpForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpArrow = GameObject.Find("JumpArrow").GetComponent<JumpArrow>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    public void Jump()
    { 
        if (canJump)
        {
            canJump = false;
            jumpArrow.disableRotation();
            rb.gravityScale = 1;
            //Debug.Log(gameObject.transform.position);
            //Debug.Log(jumpArrow.getArrowDirection());
            //Debug.Log((jumpArrow.getArrowDirection() - gameObject.transform.position).normalized);
            launchPlayer(jumpForce);
        }  
    }
    public void Land()
    {
        jumpArrow.enableRotation();
        rb.linearVelocity = new Vector2(0, 0);
        rb.gravityScale = 0;
        flipPlayer();
        Debug.Log(jumpArrow.movingUp);
        canJump = true;
        
    }
    public void launchPlayer(float force)
    {
        rb.AddForce((jumpArrow.getArrowDirection() - gameObject.transform.position).normalized * force, ForceMode2D.Impulse);
    }
    public void flipPlayer()
    {
        Vector3 orientation = transform.localScale;
        orientation.x = -transform.localScale.x;
        transform.localScale = orientation;
        jumpArrow.movingUp = !jumpArrow.movingUp;
        jumpArrow.facingRight = !jumpArrow.facingRight;
    }
}
