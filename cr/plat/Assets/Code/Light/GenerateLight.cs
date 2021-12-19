using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLight : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotSpeed;
    public float maxDistance = 10;
    [SerializeField] private PolygonCollider2D col;
    public bool enableBoxCollider = false;
    void Start()
    {
        col = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAroundLocal(transform.forward, Time.deltaTime*rotSpeed);
        
    }
}
