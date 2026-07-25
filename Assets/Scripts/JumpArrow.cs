using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class JumpArrow : MonoBehaviour
{
    [SerializeField] private Transform pivotPoint;
    [SerializeField] private float arrowRotateSpeed;
    private bool rotating = true;
    public bool movingUp = false;
    public bool facingRight = true;
    private float clampDown = 200;
    private float clampUp = 340;

    public void disableRotation()
    {
        rotating = false;
        Debug.Log("Disabled rotation");
    }
    public void enableRotation()
    {
        rotating = true;
    }
    public Vector3 getArrowDirection()
    {
        return GameObject.Find("ArrowTip").transform.position;
    }
    void Update()
    {
        
        if (facingRight)
        {
            clampDown = 200;
            clampUp = 340;
            Debug.Log("clampUp: " + clampUp + " clampDown: " + clampDown);
        }
        if (!facingRight)
        {
            clampDown = 20;
            clampUp = 160;
            Debug.Log("clampUp: " + clampUp + " clampDown: " + clampDown);
        }
        
        
        float arrowRotationZ = gameObject.transform.rotation.eulerAngles.z;
        if (rotating && !movingUp)
        {
            gameObject.transform.RotateAround(pivotPoint.position, new Vector3(0, 0, 1), Time.deltaTime * -arrowRotateSpeed);
            if (arrowRotationZ <= clampDown )
            { 
                movingUp = true;
                Debug.Log("Disabled moving down");
            }
        }
        else if(rotating && movingUp)
        {
            gameObject.transform.RotateAround(pivotPoint.position, new Vector3(0, 0, 1), Time.deltaTime * arrowRotateSpeed);
            if (arrowRotationZ >= clampUp )
            { 
                movingUp = false;
                Debug.Log("Disabled moving up");
            }
        }

    }
}
