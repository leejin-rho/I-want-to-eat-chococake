using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 instance;    // 싱글턴을 할당할 전역변수

    public bool isGameover = false;         // 게임 오버 상태
    public GameObject gameoverUI;           // 게임 오버시 활성화할 UI

    public bool isSuccess = false;          // 게임 성공 상태
    public GameObject succssImage;             // 게임 성공 시 활성화할 UI
    public GameObject canvas;
    public GameObject toTheLobbySceneButton;

    public AudioClip deathClip, successClip;

    private AudioSource nogomAudio;
    private AudioSource bgm;



    public int n_needle = 0, n_thread = 0, n_fabric = 0;    // 바늘, 실, 천 개수 
    public int goal_n = 30, goal_t = 20, goal_f = 10;    // 바늘, 실, 천 개수 

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재");
            Destroy(gameObject);
        }

        Time.timeScale = 1;
    }
    
    public void OnPlayerDead()
    {
        //오디오 클립을 죽는 걸로 변경
        nogomAudio.clip = deathClip;

        // 사망 효과음
        nogomAudio.Play();
        bgm.Stop();

        isGameover = true;
        gameoverUI.SetActive(true);
    }

    public void OnGameSuccess()
    {
        //오디오 클립을 성공 걸로 변경
        nogomAudio.clip = successClip;

        // 성공 효과음
        nogomAudio.Play();
        bgm.Stop();

        isSuccess = true;

        succssImage.SetActive(true);
        toTheLobbySceneButton.SetActive(true);
        PlayerPrefs.SetInt("stage2Clear", 1);
        
    }
    public void toTheLobbyScene()
    {
        SceneManager.LoadScene("LOBBY");
    }

    void Start()
    {
        if(!PlayerPrefs.HasKey("FistTimeStage2"))
        {
            PlayerPrefs.SetInt("FistTimeStage2", 1);
        }

        nogomAudio = GetComponent<AudioSource>();
        bgm = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    void Update()
    {
        if(isGameover && Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current && EventSystem.current.IsPointerOverGameObject() == false)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (n_needle >= goal_n && n_thread >= goal_t && n_fabric >= goal_f)
            OnGameSuccess();
    }
}
