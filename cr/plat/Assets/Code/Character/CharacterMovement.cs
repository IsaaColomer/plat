using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    [SerializeField] private float spee;
    public LayerMask ground;
    public LayerMask platform;
    [SerializeField] private SpriteRenderer r;
    [SerializeField] private float startSpeed;     
    [SerializeField] private float jumpF2;
    [SerializeField] private float jumpFstart;
    public Transform startPosition;
    public float jumpF;     
    public float reduce;
    [SerializeField] private Animator anim;
    [SerializeField] BoxCollider2D bc2d;
    [SerializeField] private float xDir;
    [SerializeField] private float yVel;
    [SerializeField] public bool canJump = false;
    [SerializeField] public Vector3 startPos;
    [SerializeField] public bool onAir;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        r = GetComponent<SpriteRenderer>();
        canJump = false;
        onAir = false;
        startSpeed = speed;
        spee = speed/reduce;
        jumpF2 = jumpF*1.5f;
        jumpFstart = jumpF;
        transform.position = startPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            transform.position = startPos;
            rb.velocity = Vector2.zero;
        }
        xDir = Input.GetAxis("Horizontal")*speed;
        if(Input.GetButtonDown("Jump") && (isGrounded() || isOnPlatform()))
        {
            rb.AddForce(new Vector2(0f, jumpF));
            if(!isGrounded())
            {
                anim.Play("jump");
            }
            if(!isOnPlatform())
            {
                anim.Play("jump");
            }
        }
        if(Input.GetButtonDown("Jump") && canJump)
        {
            rb.AddForce(new Vector2(0f, jumpF));
            if (!isGrounded())
            {
                anim.Play("jump");
            }
            if (!isOnPlatform())
            {
                anim.Play("jump");
            }
        }
        if(!isGrounded())
        {
            if (!isOnPlatform())
                speed = spee;
        }
        else
        {
            if (isOnPlatform())
            {
                speed = startSpeed;
            }
            speed =  startSpeed;
        }
        if(xDir == 0 && (!isGrounded() || !isOnPlatform()))
        {
            anim.Play("idle");
        }
        if(Input.GetKey(KeyCode.D))
        {
            r.flipX = false;
            if (isGrounded())
            {
                anim.Play("running");
            }
            if(isOnPlatform())
            {               
                anim.Play("running");
            }
            if(!isGrounded() && !isOnPlatform())
            {
                if (rb.velocity.y > 0f)
                {
                    anim.Play("jump");
                }
                if (rb.velocity.y < 0f)
                {
                    anim.Play("fall");
                }
            }
        }
        if(Input.GetKey(KeyCode.A))
        {
            r.flipX = true;
            if (isGrounded() || isOnPlatform())
            {
                anim.Play("running");
            }
            if (!isGrounded() && !isOnPlatform())
            {
                if (rb.velocity.y > 0f)
                {
                    anim.Play("jump");
                }
                if (rb.velocity.y < 0f)
                {
                    anim.Play("fall");
                }
            }
        }     
        if(rb.velocity.y == 0)
        {
            jumpF = jumpFstart;
        }
        yVel = rb.velocity.y;
    }
    public bool isGrounded()
    {
        float extraHText = 0.1f;
        RaycastHit2D raycasthit = Physics2D.Raycast(bc2d.bounds.center, Vector2.down, bc2d.bounds.extents.y+extraHText, ground);
        Color rayColor = Color.white;
        if(raycasthit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(bc2d.bounds.center, Vector2.down * (bc2d.bounds.extents.y + extraHText), rayColor);
        return raycasthit.collider != null;
    }
    public bool isOnPlatform()
    {
        float extraHText = 0.1f;
        RaycastHit2D raycasthitp = Physics2D.Raycast(bc2d.bounds.center, Vector2.down, bc2d.bounds.extents.y + extraHText, platform);
        Color rayColor = Color.white;
        if (raycasthitp.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(bc2d.bounds.center, Vector2.down * (bc2d.bounds.extents.y + extraHText), rayColor);
        return raycasthitp.collider != null;
    }
    void FixedUpdate() 
    {
        rb.velocity = new Vector2(xDir*Time.deltaTime, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "CheckPoint")
        {
            startPos = other.transform.position;
        }
        if(other.tag == "Double")
        {
            canJump = true;
            jumpF = jumpF2;
        }        
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Double")
        {
            canJump = false;
            jumpF = jumpFstart;
        }    
    }
    private void OnCollisionStay2D(Collision2D other) 
    {
        //if(other.transform.tag == "Moving")
        //{
        //    //onAir = false;
        //    canJump = true;
        //}
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.transform.tag == "Trap")
        {
            GetComponent<PlayerHealth>().TakeDamage();
            transform.position = startPos;
        }
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        //if(other.transform.tag == "Moving")
        //{
        //    rb.AddForce(new Vector2(0f, 2000));
        //    onAir = true;
        //    canJump = false;
        //}
    }
}
