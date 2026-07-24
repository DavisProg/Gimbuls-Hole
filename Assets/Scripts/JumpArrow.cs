using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class JumpArrow : MonoBehaviour
{
    [SerializeField] private Transform pivotPoint;
    [SerializeField] private float arrowRotateSpeed;
    private bool rotating = true;
    private bool movingUp = false;
    public void disableRotation()
    {
        rotating = false;
    }
        public void enableRotation()
    {
        rotating = true;
    }
    void Update()
    {
        float arrowRotationZ = gameObject.transform.rotation.eulerAngles.z;
        Debug.Log(arrowRotationZ);
        if (rotating && !movingUp)
        {
            gameObject.transform.RotateAround(pivotPoint.position, new Vector3(0, 0, 1), Time.deltaTime * -arrowRotateSpeed);
            if (arrowRotationZ <= 200)
            { 
                movingUp = true;
                Debug.Log("Disabled moving down");
            }
        }
        else if(rotating && movingUp)
        {
            gameObject.transform.RotateAround(pivotPoint.position, new Vector3(0, 0, 1), Time.deltaTime * arrowRotateSpeed);
            if (arrowRotationZ >= 340)
            { 
                movingUp = false;
                Debug.Log("Disabled moving up");
            }
        }

    }
}
