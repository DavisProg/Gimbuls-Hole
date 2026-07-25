using UnityEngine;

public class PlatformScript : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player touched me :(");
            collision.gameObject.GetComponent<JumpScript>().Land();
        }
    }
}
