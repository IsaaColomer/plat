using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulsePlatforms : MonoBehaviour
{
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }    
    private void OnCollisionStay2D(Collision2D other) 
    {
        if(other.transform.tag == "Player")
        {
            other.collider.transform.SetParent(transform);
            anim.enabled = true;
            anim.Play("movementp");
        }
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.transform.tag == "Player")
        {
            other.collider.transform.SetParent(null);
            anim.enabled = false;
            anim.StopPlayback();
        }
    }


}
