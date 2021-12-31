using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosaLou : MonoBehaviour
{
    //public Transform center;
    public float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.forward, Time.deltaTime * rotSpeed);
    }
}
