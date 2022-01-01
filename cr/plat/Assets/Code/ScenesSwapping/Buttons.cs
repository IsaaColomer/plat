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
    }
    public void Load()
    {
        SceneManager.LoadScene("Isaac");
        GameObject.Find("SaveManager").GetComponent<SaveManager>().Load();
    }
    public void OptionsAC()
    {
        options.SetActive(true);
    }
}
