using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public GameObject[] waypoints;
    [SerializeField] private int patrolWP = 0;
    [SerializeField] private int pmt = 0;
    [SerializeField] public float f1;
    [SerializeField] private float f2;
    [SerializeField] private float speedDown;
    [SerializeField] private float speedOriginal;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        f2 = f1;
        speedDown = speed/2f;
        speedOriginal = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }
    int Calculate()
    {
        patrolWP = (patrolWP + 1) % waypoints.Length;
        return patrolWP;
    }
    void Patrol()
    {
        if(f1<= 0)
        {
            pmt = Calculate();
            f1 = f2;
        }
        else
        {
            f1-= Time.deltaTime;
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[pmt].transform.position, Time.deltaTime*speed);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Platforms")
        {
            speed = speedDown;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Platforms")
        {
            speed = speedOriginal;
        }
    }
    
}
