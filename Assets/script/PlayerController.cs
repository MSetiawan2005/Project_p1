using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed, jumpPower;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            if(Mathf.Abs(theRB.velocity.y) > 0.1f)
            {
                anim.SetTrigger("DoubleJump");
            }

            theRB.velocity = new Vector2(theRB.velocity.x, jumpPower);
        }

        //flip character when moving sideways
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            transform.localScale = Vector3.one;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        anim.SetFloat("xSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetFloat("ySpeed", theRB.velocity.y);
    }
}
