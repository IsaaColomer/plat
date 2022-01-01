using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCode : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] public bool idle;
    [SerializeField] public bool follow;
    [SerializeField] private Transform player;
    [SerializeField] private SpriteRenderer r;
    [SerializeField] public float initY;
    [SerializeField] private float yl;
    [SerializeField] private BoxCollider2D bc;
    [SerializeField] private CapsuleCollider2D cc;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        r = GetComponent<SpriteRenderer>();
        idle = true;
        follow = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        yl = transform.position.y;
        yl += 2.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(idle)
        {
            anim.Play("catidle");
        }
        if(follow)
        {
            //transform.position = new Vector3(transform.position.x, yl, 0f);
            transform.position = Vector2.MoveTowards(transform.position, player.position,
                                         speed * Time.deltaTime);
        }
        if((player.position.x - transform.position.x) < 0f)
        {
            r.flipX = true;
        }
        else
        {
            r.flipX = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered");
        if (other.GetComponent<Collider2D>() == cc)
        {
            follow = false;
            idle = true;
        }
        if(other.GetComponent<Collider2D>() == bc)
        {
            follow = true;
            idle = false;
            anim.Play("catwalk");
        }
    }
}
