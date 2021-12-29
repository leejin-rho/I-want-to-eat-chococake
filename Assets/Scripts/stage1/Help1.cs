using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help1 : MonoBehaviour
{
    public GameObject helpUI1;
    private bool isHelpUIOn = false;


    void Update()
    {
        if (isHelpUIOn && Input.GetMouseButtonDown(0))
        {
            helpUI1.SetActive(false);
            Time.timeScale = 1;
            isHelpUIOn = false;
        }
    }

    public void help()
    {
        if (helpUI1.activeSelf)
        {
            helpUI1.SetActive(false);
            Time.timeScale = 1;
            isHelpUIOn = false;
        }
        else
        {
            helpUI1.SetActive(true);
            Time.timeScale = 0;
            isHelpUIOn = true;
        }

    }
}
