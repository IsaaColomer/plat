using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject resume;
    public GameObject back;
    [SerializeField] private bool c;
    [SerializeField] private float speedDown;
    [SerializeField] private float speedNormal;
    [SerializeField] private float speedUp;
    [SerializeField] public float timeUp=3;
    [SerializeField] public float timeDown =0.5f;
    // Start is called before the first frame update
    void Start()
    {
        optionsMenu.SetActive(false);
        speedNormal = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().speed;
        speedDown = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().speed/3;
        speedUp = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().speed*0.5f;
        c = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F4))
        {
            Application.Quit();
        }
        if(Input.GetKey(KeyCode.Backspace))
        {
            SceneManager.LoadScene("First");
        }
        if(Input.GetButton("Pause"))
        {
            optionsMenu.SetActive(true);
            resume.SetActive(true);
            back.SetActive(true);
            Time.timeScale = 0;
        }
        //TIME DOWN
        if(Input.GetButton("Forward") && (GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().isGrounded() || GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().isOnPlatform()))
        {
            Time.timeScale = timeUp;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().speed = speedDown;
            c = true;
        }
        if(Input.GetButtonUp("Forward") && (GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().isGrounded() || GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().isOnPlatform()))
        {
            Time.timeScale = 1;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().speed = speedNormal;
        }
        if(!(GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().isGrounded() || GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().isOnPlatform()))
        {
            Time.timeScale = 1;
            if(c)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().speed = speedNormal;
            }
        }
        // TIME UP
        if(!(GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().isGrounded() || GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().isOnPlatform()))
        {
            Time.timeScale = 1;
            if(c)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().speed = speedNormal;
            }
        }
    }
    public int CheckCheckPoints()
    {
        int first = 0;
        for(int i = 0; i < GameObject.FindGameObjectsWithTag("CheckPoint").Length; i++)
        {
            if(!GameObject.FindGameObjectsWithTag("CheckPoint")[i].GetComponent<BoxCollider2D>().enabled)
            {
                first = i;
            }
        }

        return first;
    }
}
