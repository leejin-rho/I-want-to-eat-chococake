using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager3 : MonoBehaviour
{
    public static GameManager3 instance; //싱글턴을 할당할 전역변수
    public bool isGameover = false; // 게임오버상태
    public bool isSuccess = false;
    public bool next = false;
    public Text scoreText; // 점수 출력할 UI텍스트
    public GameObject gameoverUI;//게임오버시 활성화할 UI 게임 프로젝트
    public GameObject toTheEndSceneButton;
    public GameObject canvas;
    public GameObject richNogomImage;
    

    private int score = 0;

    void Awake()
    {
        if(instance == null)
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
        Time.timeScale = 1;

        NogomController.heartCount = 3;
        NogomController.currentScore = 0;
        PlatformSpawner.isfirst = true;
        PlatformSpawner.lastSpawnTime = 0f;
        PlatformSpawner.timeBetSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //게임 오버 상태에서 게임을 재시작할 수 있게 하는 처리  
        if(isGameover && Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current && EventSystem.current.IsPointerOverGameObject() == false)
            {
                //게임오버 상태이고 마우스 왼쪽버튼 누르면 현재 액티브한 씬 이름 가져와서 다시 로드(시작)
                NogomController.heartCount = 3;
                NogomController.currentScore = 0;
                PlatformSpawner.isfirst = true;
                PlatformSpawner.lastSpawnTime = 0f;
                PlatformSpawner.timeBetSpawn = 0f;
                Time.timeScale=1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        
        
        //목표 코인 달성했을때 다음으로 넘어감
    }

    //점수 증가시키는 메서드
    public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            //점수 증가
            score += newScore;
            scoreText.text =" "+ score;
        }
    }

    //노곰 사망시 게임오버 실행
    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }

    public void OnPlayerSuccess()
    {
        isSuccess = true;
        richNogomImage.SetActive(true);
        toTheEndSceneButton.SetActive(true);
    }

    public void toTheEndScene()
    {
        SceneManager.LoadScene("END");
        Time.timeScale = 1;
    }
}
