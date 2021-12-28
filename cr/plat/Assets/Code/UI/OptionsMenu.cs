using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{    
    public GameObject optionsS;
    public GameObject backS;
    public GameObject audioS;
    public GameObject videosS;
    public GameObject creditsS;
    public GameObject resumeS;
    // Start is called before the first frame update
    void Start()
    {
        optionsS.SetActive(true);
        audioS.SetActive(false);
        backS.SetActive(true);
        videosS.SetActive(false);
        creditsS.SetActive(false);
        resumeS.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioClick()
    {
        optionsS.SetActive(true);
        audioS.SetActive(true);
        backS.SetActive(true);
        videosS.SetActive(false);
        creditsS.SetActive(false);
        if(SceneManager.GetActiveScene().ToString() == "Isaac")
        {
            resumeS.SetActive(true);
        }
        else
        {
            resumeS.SetActive(true);
        }
    }
    public void BackClick()
    {
        optionsS.SetActive(false);
        audioS.SetActive(false);
        backS.SetActive(false);
        videosS.SetActive(false);
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
        Time.timeScale = 1;
    }
    public void VideoClick()
    {
        optionsS.SetActive(true);
        audioS.SetActive(false);
        backS.SetActive(true);
        videosS.SetActive(true);
        creditsS.SetActive(false);
        if(SceneManager.GetActiveScene().ToString() == "Isaac")
        {
            resumeS.SetActive(true);
        }
        else
        {
            resumeS.SetActive(true);
        }
        
    }
    public void CreditsClick()
    {
        optionsS.SetActive(true);
        audioS.SetActive(false);
        backS.SetActive(true);
        videosS.SetActive(false);
        creditsS.SetActive(true);
        if(SceneManager.GetActiveScene().ToString() == "Isaac")
        {
            resumeS.SetActive(true);
        }
        else
        {
            resumeS.SetActive(true);
        }
    }
    public void ResumeClick()
    {
        optionsS.SetActive(false);
        audioS.SetActive(false);
        backS.SetActive(false);
        videosS.SetActive(false);
        creditsS.SetActive(false);
        resumeS.SetActive(false);
        Time.timeScale = 1;
    }
}
