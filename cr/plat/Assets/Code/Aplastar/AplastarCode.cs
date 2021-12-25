using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AplastarCode : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float f1;
    [SerializeField] private float f2;
    // Start is called before the first frame update
    void Start()
    {
        f1 = 1.5f;
        anim = GetComponent<Animator>();
        f2 = f1;
    }

    // Update is called once per frame
    void Update()
    {
      anim.Play("downidle");
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Orb")
        {
            anim.Play("down");
        }
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
    if(f1>= 0)
        {
            anim.Play("up");
        }
        else
        {
            f1-=Time.deltaTime;
        }    
    }
}
