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
        Debug.Log((gameObject.transform.forward - jumpArrow.getArrowDirection()).normalized);
        rb.AddForce((gameObject.transform.forward - jumpArrow.getArrowDirection()).normalized * jumpForce);
    }
}
