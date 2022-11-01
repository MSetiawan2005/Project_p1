using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
  

    public GameObject effect;
    public GameObject blood;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            die();
            
            
        }
    }

    private void die()
    {
        Instantiate(blood, transform.position, Quaternion.identity);
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
