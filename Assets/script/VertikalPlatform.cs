using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertikalPlatform : MonoBehaviour
{

    private PlatformEffector2D effector;
    public float waitTime;

    private void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Jump"))
        {
            waitTime = 0.1f;
        }

        if ( Input.GetKey(KeyCode.DownArrow))
        {
            if(waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 0.1f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        } 
        
        else if (Input.GetKey(KeyCode.S))

        {
            if (waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 0.1f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (Input.GetButton("Jump"))
        {
            effector.rotationalOffset = 0;
        }
    }
}
