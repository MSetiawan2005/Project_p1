using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private float speed;


    private Transform target;
    private Transform player;


    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("key").transform;
        player = GameObject.FindGameObjectWithTag("player").transform;
    }

    private void FixedUpdate()
    {
        moveCam();
    }

    public void moveCam()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -100);
        transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
    }
}
