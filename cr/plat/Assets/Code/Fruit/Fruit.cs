using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public SpriteRenderer[] rend;
    [SerializeField] private SpriteRenderer r;
    Sprite Result()
    {
        Sprite selected;
        float rnadomStart = rend.Length;
        int random = (int)Random.Range(0f,rnadomStart);
        selected = rend[random].sprite;

        return selected;
    }
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<SpriteRenderer>();
        r.sprite = Result();
    }

    
}
