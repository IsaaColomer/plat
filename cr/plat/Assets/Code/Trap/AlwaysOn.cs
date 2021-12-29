using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysOn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag == "Player")
        {
            Debug.Log("Damage!");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().life--;
            GameObject.FindGameObjectWithTag("Lq").transform.position = GameObject.FindGameObjectWithTag("Lq").GetComponent<LightSquare>().sP;

            GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().startPos;
        }
    }
}
