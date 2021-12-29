using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickHelpButton : MonoBehaviour
{
    
    public bool onHelp = true;
    public GameObject helpUI;

    public int stage;

    void Start()
    {
        /*if (stage == 1)
        {
            if (!PlayerPrefs.HasKey("FistTimeStage1"))
            {
                PlayerPrefs.SetInt("FistTimeStage1", 1);
                convertHelp(true);
            }
            else
            {
                convertHelp(false);
            }
        }
        else if(stage == 2)
        {
            if (!PlayerPrefs.HasKey("FistTimeStage2"))
            {
                PlayerPrefs.SetInt("FistTimeStage2", 1);
                convertHelp(true);
            }
            else
            {
                convertHelp(false);
            }
        }
        */

    }
    /*
    public void OnClickHelp()
    {
        onHelp = !onHelp;
        convertHelp(onHelp);
    }

    void convertHelp(bool Help)
    {
        onHelp = Help;
        helpUI.SetActive(onHelp);
        if (onHelp)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    */
}