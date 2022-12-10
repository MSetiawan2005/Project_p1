using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSR : MonoBehaviour
{

    public float distance;

    public LineRenderer LineLeser;



    public PlayerDie dead;


    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);

        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            LineLeser.SetPosition(1, hitInfo.point);

            if (hitInfo.collider.CompareTag("Player"))
            {

                dead.die();

                //Destroy(hitInfo.collider.gameObject);
            }

        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
            LineLeser.SetPosition(1, transform.position + transform.right * distance);
        }


        LineLeser.SetPosition(0, transform.position);
    }
}
