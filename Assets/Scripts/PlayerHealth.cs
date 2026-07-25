using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private int maxHealth = 3;
    int currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void takeDamage()
    {
        currentHealth--;
        if(currentHealth <= 0)
        {
            die();
        }
    }
    private void die()
    {
        Debug.Log("Player has died");
    }
}
