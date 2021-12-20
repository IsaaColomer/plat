using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateOrbs : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer1 = 1.5f;
    [SerializeField]private float timer2;
    public GameObject orbPrefab;
    void Start()
    {
        timer2 = timer1;
    }

    // Update is called once per frame
    void Update()
    {        
        if(timer1<=0f)
        {
            Instantiate(orbPrefab, transform.position, Quaternion.identity);
            timer1 = timer2;
        }
        else
        {
            timer1-=Time.deltaTime;
        }
    }
}
