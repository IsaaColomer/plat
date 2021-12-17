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

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.up*maxDistance, out hit, maxDistance))
        {
            if(hit.collider.tag == "Platforms")
            {
                Debug.Log("Platforms");
            }
            else
            {
                Debug.Log("Not platform, name: " + hit.collider.tag.ToString());
            }
        }
        lr.SetPosition(0,transform.position);
        lr.SetPosition(1,transform.up*maxDistance);
    }
}
