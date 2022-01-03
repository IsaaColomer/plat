using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanCode : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public Transform start;
    public Transform finish;
    public float force;
    private bool dirRight = true;
    private bool dirUp = true;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(start.GetComponent<Transform>() != null && finish.GetComponent<Transform>()! != null)
        {
            if (dirRight)
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            else
                transform.Translate(-Vector2.right * speed * Time.deltaTime);

            if ((transform.position.x >= finish.position.x))
            {
                dirRight = false;
            }

            if ((transform.position.x <= start.position.x))
            {
                dirRight = true;
            }
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("A");
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, force * Time.deltaTime), ForceMode2D.Impulse);
        }
    }
}
