using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    private bool isFollow;
    public float followsped;
    public Transform followTrg;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollow)
        {
            transform.position = Vector3.Lerp(transform.position, followTrg.position, followsped * Time.deltaTime);
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!isFollow)
            {
                PlayerMove Theplayer = FindObjectOfType<PlayerMove>();

                followTrg = Theplayer.keyFollowPoint;

                isFollow = true;
                Theplayer.followKey = this;
            }
        }
    }
}
