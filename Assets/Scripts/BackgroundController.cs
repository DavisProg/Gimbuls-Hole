using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float startPos, length;
    public GameObject cam;
    public GameObject frame;
    public float parallaxEffect;
    private float loopamount; // The speed at which the background should move relative to the camera

    void Start()
    {
        // Track the Y position instead of X
        startPos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void FixedUpdate()
    {
       
        float distance = cam.transform.position.y * parallaxEffect; 
        float movement = cam.transform.position.y * (1 - parallaxEffect);

        // Update the Y position instead of the X position
        transform.position = new Vector3(transform.position.x, startPos + distance, transform.position.z);

        // Adjust Y position thresholds for infinite vertical scrolling
        // Note: Using length / 2 here fixes the original logic bug so it loops seamlessly
        if (movement > startPos + (length / 2))
        {
            startPos += length;
        }
        else if (movement < startPos - (length / 2))
        {
            startPos -= length;
        }

        
       
    }
}

