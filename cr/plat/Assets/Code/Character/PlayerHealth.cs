using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] public int life;
    // Start is called before the first frame update
    void Start()
    {
        start = GameObject.FindGameObjectWithTag("Start").transform;
        life = 1;
    }

    // Update is called once per frame
    void Update()
    {
        KnowLife();
    }
    public void TakeDamage()
    {
        life--;
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
        if(life <= 0)
        {
            transform.position = GetComponent<CharacterMovement>().startPos;
            life = 1;
            Debug.Log("Restarted");
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Plus")
        {
            AddLife();
            Destroy(other.gameObject);
        }
    }
}
