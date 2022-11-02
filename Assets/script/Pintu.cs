using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pintu : MonoBehaviour
{
    private PlayerMove thePlayer;

    public SpriteRenderer sr;
    public Sprite doorOpenSprt;

    public bool doorOpen, waiting;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waiting)
        {
            if(Vector3.Distance(thePlayer.followKey.transform.position, transform.position) < 0.1f)
            {
                waiting = false;
                doorOpen = true;
                sr.sprite = doorOpenSprt;
                thePlayer.followKey.gameObject.SetActive(false);
                thePlayer.followKey = null;
                
            }
        }


        if(doorOpen && Vector3.Distance(thePlayer.transform.position, transform.position) < 1f && Input.GetKey(KeyCode.W)) 
        {
            SceneChanger scene = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SceneChanger>();
            scene.NextLevel(SceneManager.GetActiveScene().buildIndex);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(thePlayer.followKey != null)
            {
                thePlayer.followKey.followTrg = transform;
                waiting = true;
            }
        }
    }
}
