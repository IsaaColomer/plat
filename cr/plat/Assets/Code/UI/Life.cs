using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Life : MonoBehaviour
{
    [SerializeField] private Image h1;
    [SerializeField] private Animator anim;
    public void PrintLife()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().life == 3)
        {
            h1.enabled = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PrintLife();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PrintLife();
        anim.Play("Health");
    }
    
}
