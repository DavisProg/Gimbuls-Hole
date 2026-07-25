using Unity.VisualScripting;
using UnityEngine;

public class BounceScript : MonoBehaviour
{
    private JumpScript jump;
    [SerializeField] private float upForce;
    [SerializeField] private float hurtAwayForce;
    void Start()
    {
       jump = GameObject.Find("Player").GetComponent<JumpScript>(); 
    }
    public void bounce(bool bounceUp)
    {
        if (bounceUp)
        {
            jump.rb.linearVelocity = new Vector2(0, 0);
        }
        jump.launchPlayer(hurtAwayForce);
        if (bounceUp)
        {
            jump.rb.AddForce(new Vector2(0, 1) * upForce, ForceMode2D.Impulse);
        }
    }
}
