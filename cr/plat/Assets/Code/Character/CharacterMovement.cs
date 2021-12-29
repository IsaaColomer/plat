using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;     
    [SerializeField] private float spee;
    [SerializeField] private SpriteRenderer r;
    [SerializeField] private float startSpeed;     
    [SerializeField] private float jumpF2;
    [SerializeField] private float jumpFstart;
    public float jumpF;     
    public float reduce;
    [SerializeField] private Vector3 movement;
    [SerializeField] private Animator anim;
    [SerializeField] CircleCollider2D capsule;
    [SerializeField] CapsuleCollider2D capsuleCol;
    [SerializeField] private float xDir;
    [SerializeField] private float yVel;
    [SerializeField] public bool canJump = true;
    [SerializeField] public Vector3 startPos;
    [SerializeField] public bool onAir;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        capsule = GetComponent<CircleCollider2D>();
        capsuleCol = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        r = GetComponent<SpriteRenderer>();
        canJump = true;
        onAir = false;
        startSpeed = speed;
        spee = speed/reduce;
        jumpF2 = jumpF*1.5f;
        jumpFstart = jumpF;
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
        if(Input.GetButtonDown("Jump") && canJump)
        {
            rb.AddForce(new Vector2(0f, jumpF));
            if(!onAir)
                anim.Play("jump");
        }
        if(onAir)
        {
            speed = spee;
        }
        else
        {
            speed =  startSpeed;
        }
        if(xDir == 0 && !onAir)
        {
            anim.Play("idle");
        }
        if(Input.GetKey(KeyCode.D) && !onAir)
        {
            r.flipX = false;           
            anim.Play("running");
        }
        if(Input.GetKey(KeyCode.D) && onAir)
        {
            r.flipX = false;
            if(rb.velocity.y >0f)
            {
                anim.Play("jump");
            }
            if(rb.velocity.y < 0f)
            {
                anim.Play("fall");
            }
        }
        if(Input.GetKey(KeyCode.A) && !onAir)
        {
            r.flipX = true;
            anim.Play("running");
        }
        if(Input.GetKey(KeyCode.A) && onAir)
        {
            r.flipX = true;
            if(rb.velocity.y >0f)
            {
                anim.Play("jump");
            }
            if(rb.velocity.y < 0f)
            {
                anim.Play("fall");
            }
        }
        if(rb.velocity.y == 0)
        {
            jumpF = jumpFstart;
        }
        if(onAir && rb.velocity.y > 0)
        {
            anim.Play("jump");
        }
        if(onAir && rb.velocity.y < 0)
        {
            anim.Play("fall");
        }
        yVel = rb.velocity.y;
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
        if(other.transform.tag == "Moving")
        {
            onAir = false;
            canJump = true;
        }
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
        if(other.transform.tag == "Moving")
        {
            rb.AddForce(new Vector2(0f, 2000));
            onAir = true;
            canJump = false;
        }
    }
}
