using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] public int life;
    // Start is called before the first frame update
    void Start()
    {
        start = GameObject.FindGameObjectWithTag("Start").transform;
        if(SaveManager.instance.hasLoaded)
        {
        }
        else
        {
        }
        
        life = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // if(p <= 0)
        // {
        //     TakeDamage();
        //     p = 100f;
        // }
    }
    public void TakeDamage()
    {
        Debug.Log("Lifes: " + life);
    }
    public void AddLife()
    {
        if((life >= 1))
        {
            Debug.Log("Max life already reached");
        }
        else
        {
            life++;
            Debug.Log("Life: "+ life);
        }
            
    }
    public void KnowLife()
    {
        // if(life <= 0)
        // {
        //     life = 1;
        // }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Plus")
        {
            //Destroy(other.gameObject);
        }
    }
}
