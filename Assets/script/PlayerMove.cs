using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private float jumpf = 14;
    [SerializeField] private LayerMask jumpGround;

    private CircleCollider2D colld;
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
        colld = GetComponent<CircleCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.Find("Canvas").GetComponent<OnMouseEventMenu>().Pause();
            Time.timeScale = (Time.timeScale + 1) % 2;
        }

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


        if (Input.GetButton("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f && IsGrounded())
            
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpf);
        }

        updateAnimation();

        Vector3 characterScale = transform.localScale;
        if(Input.GetAxis("Horizontal") < 0 )
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

        if (dirX < 0f && !(rb.velocity.y > 1f) && !(rb.velocity.y < -1f))
        {
            state = moveState.run;
        }
        else if (dirX > 0f && !(rb.velocity.y > 1f) && !(rb.velocity.y < -1f))
        {
            state = moveState.run;
        }

        else if (rb.velocity.y > 0.1f && !IsGrounded())
        {
            state = moveState.jump;
        }

        else if (rb.velocity.y < - 0.1f && !IsGrounded())
        {
            state = moveState.fall;
        }

        else
        {
            state = moveState.idel;
        }




        anim.SetInteger("state", (int)state);

    }


    private bool IsGrounded()
    {
        return Physics2D.BoxCast(colld.bounds.center, colld.bounds.size, 0f, Vector2.down, .1f, jumpGround);
    }

}
