using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnDetector : MonoBehaviour
{
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag.ToString() == "Respawn")
        {
            rb.velocity = Vector3.zero;
            transform.position = GetComponent<CharacterMovement>().startPos;
        }    
    }
}
