using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pintu : MonoBehaviour
{
    private PlayerMove thePlayer;

    public SpriteRenderer sr;
    public Sprite doorOpenSprt;

    public bool doorOpen, waiting, openingDoor;

    [SerializeField] private AudioSource doorUnlocked;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
        doorUnlocked = GameObject.Find(SFX.Door_OpenTwo.ToString()).GetComponent<AudioSource>();
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
                doorUnlocked.Play();
            }
        }


        if(doorOpen && Vector3.Distance(thePlayer.transform.position, transform.position) < 1f && Input.GetKey(KeyCode.W) && !openingDoor) 
        {
            openingDoor = true;
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
