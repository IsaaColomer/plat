using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{    
    public GameObject optionsS;
    public GameObject backS;
    public GameObject audioS;
    public GameObject videosS;
    public GameObject creditsS;
    // Start is called before the first frame update
    void Start()
    {
        optionsS.SetActive(true);
        audioS.SetActive(false);
        backS.SetActive(true);
        videosS.SetActive(false);
        creditsS.SetActive(false);
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
    }
    public void BackClick()
    {
        optionsS.SetActive(false);
        audioS.SetActive(false);
        backS.SetActive(false);
        videosS.SetActive(false);
        creditsS.SetActive(false);
    }

    public void VideoClick()
    {
        optionsS.SetActive(true);
        audioS.SetActive(false);
        backS.SetActive(true);
        videosS.SetActive(true);
        creditsS.SetActive(false);
    }
    public void CreditsClick()
    {
        optionsS.SetActive(true);
        audioS.SetActive(false);
        backS.SetActive(true);
        videosS.SetActive(false);
        creditsS.SetActive(true);
    }
}
