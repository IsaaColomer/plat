using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] public int life;
    [SerializeField] private int d;
    [SerializeField] private int p = 0;
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
        GameObject.FindGameObjectWithTag("Deaths").GetComponent<Text>().text = d.ToString();
    }
    public void TakeDamage()
    {
        life--;
        d++;
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
            p += 25;
            GameObject.FindGameObjectWithTag("Punt").GetComponent<Text>().text = p.ToString();
            Destroy(other.gameObject);
        }
    }
}
