using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private float jumpf = 14;

    private Rigidbody2D rb;

    public Transform keyFollowPoint;
    public Keys followKey;
    private Animator anim;
    private float dirX = 0f;
    private enum moveState { idel, run, jump, fall}


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


        if (Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Abs(rb.velocity.y) < 0.001f)
            
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpf);
        }

        updateAnimation();

        Vector3 characterScale = transform.localScale;
        if(Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1f;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1f;
        }

        transform.localScale = characterScale;
        

    }

    void updateAnimation()
    {
        moveState state;

        if (dirX < 0f)
        {
            state = moveState.run;
        }
        else if (dirX > 0f)
        {
            state = moveState.run;
        }
        else
        {
            state = moveState.idel;
        }

        if(rb.velocity.y > .1f)
        {
            state = moveState.jump;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = moveState.fall;
        }

        anim.SetInteger("state", (int)state);

    }

}
