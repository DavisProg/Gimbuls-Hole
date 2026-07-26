using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterController : MonoBehaviour
{
    private float startPos, length;
    public GameObject cam;
    public GameObject frame;
    public float parallaxEffect;

    void Start()
    {
        startPos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
    }

   void Update()
{
    float distance = cam.transform.position.y * parallaxEffect;
    transform.position = new Vector3(transform.position.x, startPos + distance, transform.position.z);

    // Destroy this object once the camera passes Y = 5
    if (cam.transform.position.y > 10f)
    {
        Destroy(gameObject);
    }
}

    
}

