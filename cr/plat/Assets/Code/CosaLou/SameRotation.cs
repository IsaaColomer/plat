using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameRotation : MonoBehaviour
{
    // Start is called before the first frame update
    Quaternion startRot;
    public float i;
    private float startSpeed;
    void Start()
    {
        startRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = startRot;
        i = GameObject.FindGameObjectWithTag("CosaLou").GetComponent<CosaLou>().rotSpeed;
        startSpeed = GameObject.FindGameObjectWithTag("CosaLou").GetComponent<CosaLou>().rotSpeed;

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            while(i<5.0f)
            {
                i += 0.00001f*Time.deltaTime;
            }
            GameObject.FindGameObjectWithTag("CosaLou").GetComponent<CosaLou>().rotSpeed = i;
            collision.collider.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
           
            GameObject.FindGameObjectWithTag("CosaLou").GetComponent<CosaLou>().rotSpeed = startSpeed;
            collision.collider.transform.SetParent(null);
        }
    }
}
