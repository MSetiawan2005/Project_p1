using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap1 : MonoBehaviour
{
    float leftConstraint = Screen.width;
    float rightContraint = Screen.width;
    float buttomContraint = Screen.height;
    float topContraint = Screen.height;
    float buffer = 1.5f;
    Camera cam;
    float distanceZ;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        distanceZ = Mathf.Abs(cam.transform.position.z + transform.position.z);
        leftConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightContraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
        buttomContraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
        topContraint = cam.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distanceZ)).y;
    }

    private void FixedUpdate()
    {
        if(transform.position.x < leftConstraint - buffer)
        {
            transform.position = new Vector3(rightContraint - 2f, transform.position.y, transform.position.z);
        }

        if(transform.position.x > rightContraint)
        {
            transform.position = new Vector3(leftConstraint + 2f, transform.position.y, transform.position.z);
        }

        if(transform.position.y < buttomContraint - buffer)
        {
            transform.position = new Vector3(transform.position.x, topContraint + buffer, transform.position.z);
        }
        if(transform.position.y > topContraint + buffer)
        {
            transform.position = new Vector3(transform.position.x, buttomContraint - buffer, transform.position.z);
        }
    }
}
