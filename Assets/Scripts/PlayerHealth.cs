using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float damageCooldown = 2;
    private bool canDamage = true;
    private int currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody2D>(); 
       currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void takeDamage()
    {
        if (canDamage)
        {
            canDamage = false;
            currentHealth--;
            if(currentHealth <= 0)
            {
                die();
            }
            Debug.Log(currentHealth);
            StartCoroutine(IFrames(damageCooldown));

        }
        
    }
    public IEnumerator IFrames(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Can damage now");
        canDamage = true;
    }
    private void die()
    {
        Debug.Log("Player has died");
    }
}
