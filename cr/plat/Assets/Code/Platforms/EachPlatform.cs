using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EachPlatform : MonoBehaviour
{
    [SerializeField] private SpriteRenderer r;
    [SerializeField] private Color color;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        r = GetComponent<SpriteRenderer>();
        color = r.color;
    }

    // Update is called once per frame
    void Update()
    {
       if(GetComponent<BoxCollider2D>().enabled)
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
