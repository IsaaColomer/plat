using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgainCode : MonoBehaviour
{
    [SerializeField] private SpriteRenderer r;
    [SerializeField] private BoxCollider2D b;
    [SerializeField] private Color color;
    [SerializeField] private float t1;// tiempo que puedes estar encima la plataforma
    [SerializeField] private float t2;
    [SerializeField] private float t3;// tiempo para reiniciar
    [SerializeField] private float t4;
    [SerializeField] private bool startCount = false;
    [SerializeField] private bool startSecondCount = false;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<SpriteRenderer>();
        b = GetComponent<BoxCollider2D>();
        t1 = 0f;
        t3 = 0f;
        t2 = 0f;
        t4 = 0f;
        color = r.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(startCount)
        {
            //Count();
            if (t1 >= 1f)
            {
                startSecondCount = true;
                b.enabled = false;
            }
            else
            {
                startSecondCount = false;
                t1 += Time.deltaTime;
            }

            if (startSecondCount)
            {
                b.enabled = false;
            }
        }
        if(!b.enabled)
        {
            r.color = color/10;
            t3+=Time.deltaTime;
            if(t3>= 1f)
            {
                b.enabled = true;
                t1 = t2;
                t3 = t4;
            }
        }
        else
        {
            r.color = color;
        }
    }
    private void OnCollisionStay2D(Collision2D other) 
    {
        if(other.collider == GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>())
        {
            startCount = true;
        }
        Debug.Log($"{Time.deltaTime} vs. {Time.fixedDeltaTime}");
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.collider == GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>())
        {
            startCount = false;
            b.enabled = true;
        }
    }
    void Count()
    {
        if(t1 >= 1f)
        {
            startSecondCount = true;
            b.enabled =  false;
        }
        else
        {            
            t1+=Time.deltaTime;
        }

        if(startSecondCount)
        {
            b.enabled = false;            
        }
    }
}
