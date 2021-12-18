using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLight : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LineRenderer lr;
    [SerializeField] private Color c;
    public float maxDistance = 10;
    void Start()
    {
        lr = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAroundLocal(transform.forward, Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up*maxDistance,10f);
        if(hit)
        {
            if(hit.collider.tag.ToString() == "Platforms")
            {
                //GameObject.FindGameObjectWithTag("PlatManager").GetComponent<PlatformManager>().tilesColliding.
            }
            else
            {
               
            }
        }
        lr.SetPosition(0,transform.position);
        lr.SetPosition(1,transform.up*maxDistance);
    }
}
