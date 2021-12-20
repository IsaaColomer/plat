using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;     
    [SerializeField] private float spee;
    [SerializeField] private float startSpeed;     
    public float jumpF;     
    public float reduce;
    [SerializeField] private Vector3 movement;
    [SerializeField] private Animator anim;
    [SerializeField] BoxCollider2D capsule;
    [SerializeField] CapsuleCollider2D capsuleCol;
    [SerializeField] private float xDir;
    [SerializeField] private float yVel;
    [SerializeField] public bool canJump = true;
    [SerializeField] private Vector3 startPos;
    [SerializeField] public bool onAir;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        capsule = GetComponent<BoxCollider2D>();
        capsuleCol = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        canJump = true;
        onAir = false;
        startSpeed = speed;
        spee = speed/reduce;
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
        }
        if(onAir)
        {
            speed = spee;
        }
        else
        {
            speed =  startSpeed;
        }
        if(xDir == 0)
        {
            anim.Play("idle");
        }
        if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))
        {
            anim.Play("running");
        }
        yVel = rb.velocity.y;
    }
    void FixedUpdate() 
    {
        rb.velocity = new Vector2(xDir*Time.deltaTime, rb.velocity.y);        
    }
}
