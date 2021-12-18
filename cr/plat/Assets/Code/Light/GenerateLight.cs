using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLight : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LineRenderer lr;
    [SerializeField] private Color c;

    public float rotSpeed;
    public float maxDistance = 10;

    public bool enableBoxCollider = false;
    void Start()
    {
        lr = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAroundLocal(transform.forward, Time.deltaTime*rotSpeed);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up,10f);
        if(hit)
        {
            if(hit.transform.tag == "Platforms")
            {
                Debug.Log("Collision");
                enableBoxCollider = true;
            }
            else
            {
                Debug.Log("No Collision");
                enableBoxCollider = false;
            }
            Debug.DrawLine(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position, hit.transform.position, Color.yellow);
        }
        lr.SetPosition(0,transform.position);
        lr.SetPosition(1,transform.up);
    }
}
