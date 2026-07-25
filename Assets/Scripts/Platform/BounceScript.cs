using System.Collections;
using UnityEngine;

public class BounceScript : MonoBehaviour
{
    private JumpScript jump;
    [SerializeField] private float upForce;
    [SerializeField] private float hurtAwayForce;
    [SerializeField] private bool canBounceUp = false;
    [SerializeField] private bool canFlip = true;
    [SerializeField] private float flipCooldown = 5;
    void Start()
    {
       jump = GameObject.Find("Player").GetComponent<JumpScript>(); 
    }
    public void bounce(bool bounceUp, bool flip)
    {
        if (bounceUp)
        {
            jump.rb.linearVelocity = new Vector2(0, 0);
        }
        jump.launchPlayer(hurtAwayForce);
        if (flip)
        {
            canFlip = false;
            jump.flipPlayer();
            StartCoroutine(flipCooldownStart(flipCooldown));
        }
        if (bounceUp)
        {
            jump.rb.AddForce(new Vector2(0, 1) * upForce, ForceMode2D.Impulse);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bounce(canBounceUp, canFlip);
        }
    }
    public IEnumerator flipCooldownStart(float time)
    {
        Debug.Log("Cant flip");
        yield return new WaitForSeconds(time);
        Debug.Log("Can flip now");
        canFlip = true;
    }
}
