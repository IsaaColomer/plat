using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.transform.tag == "Trap")
        {
            GetComponent<PlayerHealth>().TakeDamage();
            transform.position = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().startPos;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "CheckPoint")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().startPos = other.transform.position;
        }        
    }
}
