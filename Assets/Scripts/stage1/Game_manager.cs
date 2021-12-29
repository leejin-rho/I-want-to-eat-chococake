using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public enum GameState
{
    Ready,
    Play,
    End
}

public class Game_manager : MonoBehaviour
{
    public GameState Gs;
    public static Game_manager instance;

    //public bool isGameover = false; 
    //public bool isSuccess = false;
    public GameObject gameoverUI;
    public GameObject successImage;
    public GameObject toTheLobbyButton;
    public GameObject failLobbyButton;
    public GameObject canvas;

    public dda_gauge dg;


    public AudioClip deathClip;
    public AudioClip successClip;
    
    private AudioSource nogomAudio;
    private AudioSource bgm;

    void Start()
    {
        nogomAudio = GetComponent<AudioSource>();
        bgm = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    void Awake()
    {
        if (instance == null)
        {
            //싱글턴 변수 instance가 비어있다면 자기자신 할당
            instance = this;
        }
        else
        {
            //instance에 이미 다른 GameManager오브젝트가 할당되어 있는 경우
            //씬에 두개 이상의 GameManager 오브젝트가 존재한다는 의미
            // 싱글턴 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(Gs == GameState.Play)
        {
            if (dg.isSuccess == true)
            {
                Success();
            }
            else if (dg.isGameover == true)
            {
                End();   
            }
                
        }

        else if(Gs == GameState.End){
                if (Input.GetMouseButtonDown(0))
                {
                if (EventSystem.current && EventSystem.current.IsPointerOverGameObject() == false)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
        }
    }

    public void G0()
    {
        Gs = GameState.Play;
    }

    public void End()
    {
        //오디오 클립을 실패한 걸로 변경
        nogomAudio.clip = deathClip;

        // 실패 효과음
        nogomAudio.Play();
        bgm.Stop();

        Gs = GameState.End;
        gameoverUI.SetActive(true);
    }


    public void Success()
    {
        //오디오 클립을 성공 걸로 변경
        nogomAudio.clip = successClip;

        // 성공 효과음
        nogomAudio.Play();
        bgm.Stop();

        Gs = GameState.Ready;
        successImage.SetActive(true);
        toTheLobbyButton.SetActive(true);
        PlayerPrefs.SetInt("stage1Clear", 1);
    }

    public void toTheLobbyScene()
    {
        SceneManager.LoadScene("LOBBY");
    }
}
