using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public GameObject options;
    // Start is called before the first frame update
    void Start()
    {
        options.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToSceneIsaac()
    {
        SceneManager.LoadScene("Isaac");
        GameObject.Find("SaveManager").GetComponent<SaveManager>().DeleteSaveData();
    }
    public void Load()
    {
        if(GameObject.Find("SaveManager").GetComponent<SaveManager>().activeSave.time != 0f)
        {
            SceneManager.LoadScene("Isaac");
            GameObject.Find("SaveManager").GetComponent<SaveManager>().Load();
        }
        else
        {
            gameObject.active = false;
        }
        
    }
    public void OptionsAC()
    {
        options.SetActive(true);
    }
}
