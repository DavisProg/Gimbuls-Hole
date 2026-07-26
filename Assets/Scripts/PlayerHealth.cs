using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float damageCooldown = 2;
    [SerializeField] private Image heart1;
    [SerializeField] private Image heart2;
    [SerializeField] private Image heart3;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite brokenHeart;
    private bool canDamage = true;
    private int currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        updateHearts(); 
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
            updateHearts();
            if (currentHealth <= 0)
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
    private void updateHearts()
    {
        switch (currentHealth)
        {
            case 3:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = fullHeart;
                break;
            case 2:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = brokenHeart;
                break;
            case 1:
                heart1.sprite = fullHeart;
                heart2.sprite = brokenHeart;
                heart3.sprite = brokenHeart;
                break;
            case 0:
                heart1.sprite = brokenHeart;
                heart2.sprite = brokenHeart;
                heart3.sprite = brokenHeart;
                break;

        }
    }
}