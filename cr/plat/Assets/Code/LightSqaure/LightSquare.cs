using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSquare : MonoBehaviour
{
    public float speed=2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            transform.position += new Vector3(Time.deltaTime*speed,0f,0f);
        }
    }
}
