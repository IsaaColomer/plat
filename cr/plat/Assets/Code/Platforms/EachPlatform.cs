using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EachPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Light")
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Light")
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
