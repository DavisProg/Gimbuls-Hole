using UnityEngine;

public class JumpScript : MonoBehaviour
{
    private JumpArrow jumpArrow;
    private Rigidbody2D rb;
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
    private void Jump()
    {
        jumpArrow.disableRotation();
        rb.gravityScale = 1;
        //Debug.Log(gameObject.transform.position);
        //Debug.Log(jumpArrow.getArrowDirection());
        //Debug.Log((jumpArrow.getArrowDirection() - gameObject.transform.position).normalized);
        rb.AddForce((jumpArrow.getArrowDirection() - gameObject.transform.position).normalized * jumpForce, ForceMode2D.Impulse);
    }
    public void Land()
    {
        jumpArrow.enableRotation();
        rb.linearVelocity = new Vector2(0, 0);
        rb.gravityScale = 0;
    }
}
