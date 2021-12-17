using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;     
    public float jumpF;     
    [SerializeField] private Vector3 movement;
    [SerializeField] private float xDir;
    [SerializeField] private bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        xDir = Input.GetAxis("Horizontal")*speed;

    }
    void FixedUpdate() 
    {
        rb.velocity = new Vector2(xDir*Time.deltaTime, rb.velocity.y); 
        if(Input.GetButtonDown("Jump") && canJump)
        {
            rb.AddForce(new Vector2(0f, jumpF));
            Debug.Log("Jump");
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        canJump = true;
    }
    void OnCollisionExit2D(Collision2D other) 
    {
        canJump = false;
    }
}
