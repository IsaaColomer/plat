using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;     
    public float jumpF;     
    [SerializeField] private Vector3 movement;
    [SerializeField] GameObject capsule;
    [SerializeField] private float xDir;
    [SerializeField] private float yVel;
    [SerializeField] private bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsule = GameObject.FindGameObjectWithTag("FloorCol");
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        xDir = Input.GetAxis("Horizontal")*speed;
        if(rb.velocity.y <= 0f && rb.velocity.y >= -0.1f)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
        if(Input.GetButtonDown("Jump") && canJump)
        {
            rb.AddForce(new Vector2(0f, jumpF));
        }
        yVel = rb.velocity.y;
    }
    void FixedUpdate() 
    {
        rb.velocity = new Vector2(xDir*Time.deltaTime, rb.velocity.y);        
    }
    // void OnCollisionStay2D(Collision2D other)
    // {
    //     if(other.collider == capsule.GetComponent<CapsuleCollider2D>())
    //     {
    //         canJump = true;
    //     }
    // }
    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     if(other.collider == capsule.GetComponent<CapsuleCollider2D>())
    //     {
    //         canJump = true;
    //     }
    // }
    
    // void OnCollisionExit2D(Collision2D other) 
    // {
    //     canJump = false;
    // }
}
