using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    public GameObject helpUI;
    private bool isHelpUIOn = false;
    

    void Update()
    {
        if(isHelpUIOn && Input.GetMouseButtonDown(0))
        {
            helpUI.SetActive(false);
            Time.timeScale = 1;
            isHelpUIOn = false;
        }
    }
   
    public void help()
    {
        if (helpUI.activeSelf)
        {
            helpUI.SetActive(false);
            Time.timeScale = 1;
            isHelpUIOn = false;
        }
        else
        {
            helpUI.SetActive(true);
            Time.timeScale = 0;
            isHelpUIOn = true;
        }
        
    }
}
