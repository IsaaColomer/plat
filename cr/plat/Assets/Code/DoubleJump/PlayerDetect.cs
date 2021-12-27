using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    [SerializeField] private float f1;
    [SerializeField] private float f2;
    [SerializeField] private bool startE;
    // Start is called before the first frame update
    void Start()
    {
        f1 = 1f;
        f2 = f1;
        startE = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(startE)
        {
            if(f1<=0)
            {
                f1 = f2;
                startE = false;
            }
            else
            {
                f1-=Time.deltaTime;
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<CircleCollider2D>().enabled = false;
            }
        }
        if(!startE)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            startE = true;
        }
    }
}
