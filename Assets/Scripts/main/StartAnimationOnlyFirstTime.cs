using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartAnimationOnlyFirstTime : MonoBehaviour
{
    public GameObject checkImage2; // 체크 없는거에 쓸거
    public GameObject checkImage3;
    public GameObject startAnimation;
    public GameObject canvas2; // 체크 없는거
    public GameObject canvas3;

    private int check = 0;
    //private float animationEndTime=20f;
    //private float sceneStartTime = 0f;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("noMovieCheck"))
        {
            check = PlayerPrefs.GetInt("noMovieCheck");
        }
        else
        {
            check = 0;
        }

        if (check == 1)
        {
            //동영상 안보기 체크 돼있으면
            startAnimation.SetActive(false);
            canvas3.SetActive(true);
            //checkImage3.SetActive(true);

        }
        else
        {
            startAnimation.SetActive(true);
            canvas2.SetActive(false);
            canvas3.SetActive(false);
        }
    }

    void Update()
    {
        if(Time.time >= 20f)
        {

            startAnimation.SetActive(false);
            canvas2.SetActive(true); //체크 없는거
        }
    }

    public void noMovieCheckButtonOnCanvas2() // 체크 있는거
    {
        if (PlayerPrefs.HasKey("noMovieCheck"))
        {
            check = PlayerPrefs.GetInt("noMovieCheck");
        }
        else
        {
            check = 0;
        }

        if (check == 0)
        {
            check = 1;
            checkImage2.SetActive(true);
            PlayerPrefs.SetInt("noMovieCheck", 1);
        }
        else if(check == 1)
        {
            check = 0;
            checkImage2.SetActive(false);
            PlayerPrefs.SetInt("noMovieCheck", 0);
        }
    }

    public void noMovieCheckButtonOnCanvas3()
    {
        if (PlayerPrefs.HasKey("noMovieCheck"))
        {
            check = PlayerPrefs.GetInt("noMovieCheck");
        }
        else
        {
            check = 0;
        }

        if (check == 0)
        {
            check = 1;
            checkImage3.SetActive(true);
            PlayerPrefs.SetInt("noMovieCheck", 1);
        }
        else if (check == 1)
        {
            check = 0;
            checkImage3.SetActive(false);
            PlayerPrefs.SetInt("noMovieCheck", 0);
        }
    }
}
