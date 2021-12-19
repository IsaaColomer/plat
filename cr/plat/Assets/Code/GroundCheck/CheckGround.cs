using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public GameObject playerBoxCollider2D;
    public GameObject playerCanJump;
    // Start is called before the first frame update
    void Start()
    {
        playerBoxCollider2D = GameObject.FindGameObjectWithTag("Player");
        playerCanJump = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if(other.collider == playerBoxCollider2D.GetComponent<BoxCollider2D>())
        {
            playerCanJump.GetComponent<CharacterMovement>().canJump = true;
            playerCanJump.GetComponent<CharacterMovement>().onAir = false;
        }
        else
        {
            playerCanJump.GetComponent<CharacterMovement>().canJump = false;
            playerCanJump.GetComponent<CharacterMovement>().onAir = true;
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {    
        if(other.collider == playerBoxCollider2D.GetComponent<BoxCollider2D>())
        {
            playerCanJump.GetComponent<CharacterMovement>().canJump = true;
            playerCanJump.GetComponent<CharacterMovement>().onAir = false;
        }
        else
        {
            playerCanJump.GetComponent<CharacterMovement>().canJump = false;
            playerCanJump.GetComponent<CharacterMovement>().onAir = true;
        }
    }    
    void OnCollisionExit2D(Collision2D other) 
    {
        if(other.collider == playerBoxCollider2D.GetComponent<BoxCollider2D>())
        {
            playerCanJump.GetComponent<CharacterMovement>().canJump = false;
            playerCanJump.GetComponent<CharacterMovement>().onAir = true;  
        }
    }
}
