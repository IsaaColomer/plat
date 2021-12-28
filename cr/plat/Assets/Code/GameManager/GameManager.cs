using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject resume;
    public GameObject back;
    // Start is called before the first frame update
    void Start()
    {
        optionsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if(Input.GetKey(KeyCode.Backspace))
        {
            SceneManager.LoadScene("First");
        }
        if(Input.GetKey(KeyCode.L))
        {
            optionsMenu.SetActive(true);
            resume.SetActive(true);
            back.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
