using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSquare : MonoBehaviour
{
    public float speed=2;
    public Transform maxim;
    [SerializeField] public Vector3 sP;
    // Start is called before the first frame update
    void Start()
    {
        sP = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            transform.position += new Vector3(Time.deltaTime*speed,0f,0f);
        }
        if(other.tag == "Stop")
        {
            this.gameObject.SetActive(false);
        }
    }
}
