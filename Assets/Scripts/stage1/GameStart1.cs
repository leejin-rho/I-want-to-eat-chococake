using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart1 : MonoBehaviour
{
    public bool gameStarted1 = false;
    public GameObject explanationUI;
    public GameObject gameStartButtonUI;

    public AudioClip start;
    private AudioSource startaudio;

    int helpForTheFirstTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        startaudio = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("stage1Open"))
        {
            helpForTheFirstTime = PlayerPrefs.GetInt("stage1Open");
        }
        if (helpForTheFirstTime == 1)
        {
            // 이미 게임을 시작한 적이 있다면
            explanationUI.SetActive(false);
            gameStartButtonUI.SetActive(true);
        }
        else
        {
            helpForTheFirstTime = 1;
            PlayerPrefs.SetInt("stage1Open",1);
        }
        startaudio.clip = start;
    }



    // Update is called once per frame
    void Update()
    {
        if (!gameStarted1 && Input.GetMouseButtonDown(0))
        {
            startaudio.Play(); 

            explanationUI.SetActive(false);
            gameStartButtonUI.SetActive(true);
        }
    }


    public void startGame1()
    {
        if (!gameStarted1 && Input.GetMouseButtonDown(0))
        {
                  
            startGame1();
            gameStarted1 = true;
        }
        SceneManager.LoadScene("Stage1");
    }
}
