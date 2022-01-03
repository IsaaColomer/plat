using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public SpriteRenderer[] rend;
    [SerializeField] private SpriteRenderer r;
    [SerializeField] private ParticleSystem p;
    Sprite Result()
    {
        Sprite selected;
        float rnadomStart = rend.Length;
        int random = (int)Random.Range(0f,rnadomStart);
        selected = rend[random].sprite;

        p.Pause();
        return selected;
    }
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<SpriteRenderer>();
        p = GetComponent<ParticleSystem>();
        r.sprite = Result();
    }
    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !p.isPlaying)
        {
            p.Play();
            r.enabled = false;
            yield return new WaitForSeconds(.5f);
            Destroy(this.gameObject);
        }
    }
}
