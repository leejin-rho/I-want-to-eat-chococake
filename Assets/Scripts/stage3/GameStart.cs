using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public bool gameStarted = false;
    public GameObject explanationUI;
    public GameObject gameStartButtonUI;

    int helpForTheFirstTime = 0;

    public AudioClip start;
    private AudioSource startaudio;

    // Start is called before the first frame update
    void Start()
    {
        startaudio = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("stage3Open"))
        {
            helpForTheFirstTime = PlayerPrefs.GetInt("stage3Open");
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
            PlayerPrefs.SetInt("stage3Open", 1);
        }

        startaudio.clip = start;
    }

   

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted && Input.GetMouseButtonDown(0))
        {
            startaudio.Play();

            explanationUI.SetActive(false);
            gameStartButtonUI.SetActive(true);

            
        }
    }

    
    public void startGame()
    {
        if (!gameStarted && Input.GetMouseButtonDown(0))
            {
                startGame();
                gameStarted=true;
            }
        SceneManager.LoadScene("STAGE3");
    }
}
