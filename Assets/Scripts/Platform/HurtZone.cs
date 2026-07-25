using UnityEngine;

public class HurtZone : MonoBehaviour
{    
    private GameObject player;
    //[SerializeField] private bool firstHit = true;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ouch, I touchy you!! (Evil spike) >:)");
            //player.GetComponent<BounceScript>().bounce(true, firstHit);
            //firstHit = false;
            player.GetComponent<PlayerHealth>().takeDamage();

        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
