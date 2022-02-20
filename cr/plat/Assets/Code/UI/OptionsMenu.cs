using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class OptionsMenu : MonoBehaviour
{    
    public GameObject optionsS;
    public GameObject backS;
    public GameObject audioS;
    public GameObject videosS;
    public GameObject creditsS;
    public GameObject resumeS;
    public GameObject drop;
    public GameObject fs;
    // Start is called before the first frame update
    void Start()
    {
        optionsS.SetActive(true);
        audioS.SetActive(false);
        backS.SetActive(true);
        videosS.SetActive(false);
        drop.SetActive(false);
        fs.SetActive(false);
        creditsS.SetActive(false);
        resumeS.SetActive(true);
        if(SceneManager.GetActiveScene().ToString() == "Isaac")
        {
            
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(resumeS);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(optionsS);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.T))
        {
            Application.Quit();
        }
    }

    public void AudioClick()
    {
        optionsS.SetActive(true);
        audioS.SetActive(true);
        backS.SetActive(true);
        videosS.SetActive(false);
        drop.SetActive(false);
        fs.SetActive(false);
        creditsS.SetActive(false);
        if(SceneManager.GetActiveScene().ToString() == "Isaac")
        {
            resumeS.SetActive(true);
        }
        else
        {
            resumeS.SetActive(true);
        }
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(audioS);
    }
    public void BackClick()
    {
        optionsS.SetActive(false);
        audioS.SetActive(false);
        backS.SetActive(true);
        videosS.SetActive(false);
        drop.SetActive(false);
        fs.SetActive(false);
        creditsS.SetActive(false);
        resumeS.SetActive(false);
        if(SceneManager.GetActiveScene().ToString() == "Isaac")
        {
            resumeS.SetActive(true);
        }
        else
        {
            resumeS.SetActive(true);
        }
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(backS);
        Time.timeScale = 1;
    }
    public void VideoClick()
    {
        optionsS.SetActive(true);
        audioS.SetActive(false);
        backS.SetActive(true);
        videosS.SetActive(true);
        drop.SetActive(true);
        fs.SetActive(true);
        creditsS.SetActive(false);
        if(SceneManager.GetActiveScene().ToString() == "Isaac")
        {
            resumeS.SetActive(true);
        }
        else
        {
            resumeS.SetActive(true);
        }
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(videosS);
    }
    public void CreditsClick()
    {
        optionsS.SetActive(true);
        audioS.SetActive(false);
        backS.SetActive(true);
        videosS.SetActive(false);
        drop.SetActive(false);
        fs.SetActive(false);
        creditsS.SetActive(true);
        if(SceneManager.GetActiveScene().ToString() == "Isaac")
        {
            resumeS.SetActive(true);
        }
        else
        {
            resumeS.SetActive(true);
        }
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsS);
    }
    public void ResumeClick()
    {
        optionsS.SetActive(false);
        audioS.SetActive(false);
        backS.SetActive(false);
        videosS.SetActive(false);
        drop.SetActive(false);
        fs.SetActive(false);
        creditsS.SetActive(false);
        resumeS.SetActive(true);
        Time.timeScale = 1;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(resumeS);
    }
}
