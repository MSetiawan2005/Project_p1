using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
  

    public GameObject effect;
    public GameObject blood;
   
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            die();
        }
    }

    public void die()
    {
        Instantiate(blood, transform.position, Quaternion.identity);
        Instantiate(effect, transform.position, Quaternion.identity);
        GameObject.Find(SFX.Player_Death.ToString()).GetComponent<AudioSource>().Play();
        GameObject.Find("Canvas").GetComponent<OnMouseEventMenu>().RestartInTime(1.5f);
        Destroy(gameObject);
    }






}
