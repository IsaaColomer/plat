using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCode : MonoBehaviour
{
    // Start is called before the first frame update   [SerializeField] private SpriteRenderer r;
    
    [SerializeField] private SpriteRenderer r;
    [SerializeField] private Color color;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        r = GetComponent<SpriteRenderer>();
        color = r.color;
    }

    // Update is called once per frame
    void Update()
    {
       if(GetComponent<CircleCollider2D>().enabled)
       {
           r.color = color;
       }
       else
       {
           r.color = color/10f;
       }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Light" ||other.tag == "Orb")
        {
            GetComponent<CircleCollider2D>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Light" || other.tag == "Orb")
        {
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag == "Player")
        {
            Debug.Log("Damage!");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().life--;
            GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().startPos;
        }
    }
}
