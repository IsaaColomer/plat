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
        transform.RotateAroundLocal(new Vector3(0,0,1), Time.deltaTime);
        lr.SetPosition(0,transform.position);
        lr.SetPosition(1,transform.right*5);
    }
}
