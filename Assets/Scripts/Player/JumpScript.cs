using UnityEngine;

public class JumpScript : MonoBehaviour
{
    private JumpArrow jumpArrow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpArrow = GameObject.Find("/JumpArrow").GetComponent<JumpArrow>();
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
        jumpArrow.getZDirection();
        Debug.Log(jumpArrow.getZDirection());
    }
}
