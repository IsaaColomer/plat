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
}
