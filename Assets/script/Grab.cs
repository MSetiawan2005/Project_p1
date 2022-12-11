using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grab : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float raydist;
    public GameObject ktk;

    [SerializeField] private AudioSource boxMoving;

    private void Start()
    {
        boxMoving = GameObject.Find(SFX.Player_PushBox.ToString()).GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabcheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, raydist);

        if(grabcheck.collider != null && grabcheck.collider.tag == "box")
        {
            if (Input.GetKey(KeyCode.W))
            {
                grabcheck.collider.gameObject.transform.parent = boxHolder;
                grabcheck.collider.gameObject.transform.position = boxHolder.position;
                grabcheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                ktk.GetComponent<ScreenWrap1>().enabled = false;

                if (!boxMoving.isPlaying)
                {
                    boxMoving.Play();
                }

            }
            else
            {
                ktk.GetComponent<ScreenWrap1>().enabled = true;
                grabcheck.collider.gameObject.transform.parent = null;
                grabcheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                if (boxMoving.isPlaying)
                {
                    boxMoving.Stop();
                }
            }
        }
    }


}
