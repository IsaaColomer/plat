using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Life : MonoBehaviour
{
    [SerializeField] private Image h1;
    [SerializeField] private Image h2;
    [SerializeField] private Image h3;
    public void PrintLife()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().life == 3)
        {
            h1.enabled = true;
            h2.enabled = true;
            h3.enabled = true;
        }
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().life == 2)
        {
            h1.enabled = true;
            h2.enabled = true;
            h3.enabled = false;
        }
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().life == 1)
        {
            h1.enabled = true;
            h2.enabled = false;
            h3.enabled = false;
        }
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().life == 0)
        {
            h1.enabled = false;
            h2.enabled = false;
            h3.enabled = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PrintLife();
    }

    // Update is called once per frame
    void Update()
    {
        PrintLife();
    }
    
}
