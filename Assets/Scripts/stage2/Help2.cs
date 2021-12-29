using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help2 : MonoBehaviour
{
    public GameObject helpUI2;
    private bool isHelpUIOn = false;


    void Update()
    {
        if (isHelpUIOn && Input.GetMouseButtonDown(0))
        {
            helpUI2.SetActive(false);
            Time.timeScale = 1;
            isHelpUIOn = false;
        }
    }

    public void help()
    {
        if (helpUI2.activeSelf)
        {
            helpUI2.SetActive(false);
            Time.timeScale = 1;
            isHelpUIOn = false;
        }
        else
        {
            helpUI2.SetActive(true);
            Time.timeScale = 0;
            isHelpUIOn = true;
        }

    }
}
