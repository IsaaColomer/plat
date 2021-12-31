using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform start;
    public Transform finish;
    [SerializeField] Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private bool dirRight = true;
    private bool dirUp = true;
    public float speed = 2.0f;

    void Update()
    {
        if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);


        if (dirUp)
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.up * speed * Time.deltaTime);

        if ((transform.position.x >= finish.position.x))
        {
            dirRight = false;
        }

        if ((transform.position.x <= start.position.x))
        {
            dirRight = true;
        }
        if (transform.position.y >= finish.position.y)
        {
            dirUp = false;
        }

        if (transform.position.y <= start.position.y)
        {
            dirUp = true;
        }
        anim.Play("platform");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.collider.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
