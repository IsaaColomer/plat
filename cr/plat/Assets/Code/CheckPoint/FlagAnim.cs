using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagAnim : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float t = 0f;
    [SerializeField] private bool touched = false;
    [SerializeField] public float done = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(touched)
        {
            t += Time.deltaTime;
        }
        if(t>=done)
        {
            anim.Play("ok");
            t = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            anim.Play("touchd");
            touched = true;
            SaveManager.instance.activeSave.respawnPosition = transform.position;
            SaveManager.instance.activeSave.time = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().p;
            SaveManager.instance.activeSave.deaths = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().d;
            SaveManager.instance.Save();
            //GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
