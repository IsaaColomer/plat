using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointCode : MonoBehaviour
{
    public bool touched;
    // Start is called before the first frame update
    void Start()
    {
        touched = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            touched = true;
        }
    }
}
