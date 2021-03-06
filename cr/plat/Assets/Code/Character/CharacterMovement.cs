using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float distance;
    private AnimatorClipInfo[]  freezeAnimationArray;
    private string  freezeAnimation;
    float time1 = 1f;
    float time2 = 1f;
    private Rigidbody2D rb;
    public BoxCollider2D left;
    public BoxCollider2D right;
    public float speed;
    [SerializeField] private float spee;
    public LayerMask ground;
    public LayerMask platform;
    [SerializeField] private SpriteRenderer r;
    public Vector3 deadPos;
    [SerializeField] private float startSpeed;     
    [SerializeField] private float jumpF2;
    [SerializeField] private float jumpFstart;
    public Transform startPosition;
    public float d;
    public float jumpF;     
    public float reduce;
    private float gr;
    [SerializeField] private Animator anim;
    [SerializeField] BoxCollider2D bc2d;
    [SerializeField] private float xDir;
    [SerializeField] private float yVel;
    [SerializeField] public bool canJump = false;
    [SerializeField] public bool canDoubleJump = false;
    [SerializeField] public Vector3 startPos;
    [SerializeField] public bool onAir;
    [SerializeField] public bool dead;
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        gr = rb.gravityScale;
        bc2d = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        r = GetComponent<SpriteRenderer>();
        canJump = false;
        onAir = false;
        startSpeed = speed;
        spee = speed/reduce;
        jumpFstart = jumpF;
        if (SaveManager.instance.hasLoaded)
        {
            transform.position = SaveManager.instance.activeSave.respawnPosition;

        }
        else
        {
            SaveManager.instance.activeSave.respawnPosition = startPosition.position;
            transform.position = SaveManager.instance.activeSave.respawnPosition;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if(dead)
        {
            transform.position = deadPos;
            anim.Play(freezeAnimation);
        }
        if(!dead)
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
        if (!(isGrounded() || isOnPlatform()) && canDoubleJump)
        {
            if(Input.GetButtonDown("Jump"))
            {
                rb.AddForce(new Vector2(0f, jumpF2));
                if (!isGrounded())
                {
                    anim.Play("jump");
                }
                if (!isOnPlatform())
                {
                    anim.Play("jump");
                }
                canDoubleJump = false;
            }
        }
        if (Input.GetButtonDown("Jump") && canJump)
        {
            rb.AddForce(new Vector2(0f, jumpF*2));
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
        if(xDir == 0)
        {
            if((isGrounded() || isOnPlatform()))
            {
                anim.Play("idle");
            }
            
        }
        if(isGrounded() ||isOnPlatform())
        {
            canDoubleJump = false;
        }
        if(Input.GetAxis("Horizontal") > 0 && Time.timeScale != 0)
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
        if(Input.GetAxis("Horizontal") < 0 && Time.timeScale != 0)
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
        if((Input.GetAxis("Horizontal") == 0) && Time.timeScale != 0)
        {
            if ((!isOnPlatform() && !isGrounded()))
            {
                if(rb.velocity.y < 0)
                    anim.Play("fall");
            
                if (rb.velocity.y > 0)
                {
                    anim.Play("jump");
                }
            }
        }       
        if(Input.GetKey(KeyCode.H))
        {
            if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().CheckCheckPoints() != 0)
            {
                transform.position = GameObject.FindGameObjectsWithTag("CheckPoint")[GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().CheckCheckPoints()].transform.position;
            }
            else
            {
                transform.position = startPosition.position;
            }
        }
        yVel = rb.velocity.y;
        }
       
    }
    public bool isGrounded()
    {
        float extraHText = 0.1f;
        RaycastHit2D raycasthit = Physics2D.Raycast(bc2d.bounds.center, Vector2.down, bc2d.bounds.extents.y+extraHText, ground);
        RaycastHit2D raycasthit2 = Physics2D.Raycast(left.bounds.center, Vector2.down, left.bounds.extents.y+extraHText, ground);
        RaycastHit2D raycasthit3 = Physics2D.Raycast(right.bounds.center, Vector2.down, right.bounds.extents.y+extraHText, ground);
        return raycasthit.collider != null || raycasthit2.collider != null || raycasthit3.collider != null;
    }
    public bool isOnPlatform()
    {
        float extraHText = d;
        RaycastHit2D raycasthitp = Physics2D.Raycast(bc2d.bounds.center, Vector2.down, bc2d.bounds.extents.y + extraHText, platform);
        RaycastHit2D raycasthit2 = Physics2D.Raycast(left.bounds.center, Vector2.down, left.bounds.extents.y+extraHText, platform);
        RaycastHit2D raycasthit3 = Physics2D.Raycast(right.bounds.center, Vector2.down, right.bounds.extents.y+extraHText, platform);
        Color rayColor = Color.white;
        if( raycasthitp.collider != null || raycasthit2.collider != null || raycasthit3.collider != null)
        {
            if(!raycasthitp.collider.isTrigger || !raycasthit2.collider.isTrigger || !raycasthit3.collider.isTrigger)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
        Debug.Log(raycasthitp.collider.ToString());
        Debug.Log(raycasthitp.collider.isTrigger.ToString());
        Debug.DrawRay(bc2d.bounds.center, Vector2.down * (bc2d.bounds.extents.y + extraHText), rayColor);
        Debug.DrawRay(left.bounds.center, Vector2.down * (extraHText), rayColor);
        Debug.DrawRay(right.bounds.center, Vector2.down * (extraHText), rayColor);
        return true;
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
            canDoubleJump = true;
        }        
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Double")
        {
            jumpF = jumpFstart;
        }    
    }
    private void OnCollisionStay2D(Collision2D other) 
    {

    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.transform.tag == "Trap")
        {
            dead = true;
            freezeAnimationArray = anim.GetCurrentAnimatorClipInfo(0);
            freezeAnimation = freezeAnimationArray[0].clip.name;
            deadPos = transform.position;
            StartCoroutine(Wait());
        }
    }
    private void OnCollisionExit2D(Collision2D other) 
    {

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.9f);
        transform.position = startPos;
        dead = false;
    }
}
