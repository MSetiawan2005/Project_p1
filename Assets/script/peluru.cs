using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peluru : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);

    }
}
