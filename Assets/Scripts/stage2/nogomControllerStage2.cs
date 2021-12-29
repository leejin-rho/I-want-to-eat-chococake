using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class nogomControllerStage2 : MonoBehaviour
{
    public int life = 3;                    // 목숨 개수

    private Rigidbody2D nogomRigidbody;     // 이동에 사용할 노곰 리지드 바디
    public float speed = 8f;                // 이동 속력

    Vector2 inputPosition;                  // 터치 부분의 위치를 받을 변수
    Camera MainCamera;                      // Main Camera를 할당받을 변수

    private bool isDead = false;            // 사망 상태



    public AudioClip ObjectClip, BombClip, b_ObjectClip;
    [SerializeField] AudioSource playerAudio;

    void Start()
    {
        nogomRigidbody = GetComponent<Rigidbody2D>();                           // Rigidbody 할당
        MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();     // Main Camera 할당
        gameObject.SetActive(true);
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 사망 시 처리를 더 이상 진행하지 않고 종료
        if (isDead)
            return;
        if (GameManager2.instance.isSuccess)
        {
            gameObject.SetActive(false);
            return;
        }

        //// 노곰의 움직임 구현
        // 화면의 왼쪽을 터치하면 xIput = -1.0, 오른쪽을 터치하면 xIput = 1.0, 그렇지 않으면 0
        float xInput = 0f;
        if (Input.GetMouseButton(0))
        {
            if (EventSystem.current && EventSystem.current.IsPointerOverGameObject() == false)
            {
                inputPosition = MainCamera.ScreenToWorldPoint(Input.mousePosition);     // 월드 좌표 중심으로 바꿔주기

                if (inputPosition.x > 0 && gameObject.transform.position.x < MainCamera.orthographicSize * MainCamera.aspect - 0.9f)
                    xInput = 1.0f;
                else if (inputPosition.x < 0 && gameObject.transform.position.x > - (MainCamera.orthographicSize * MainCamera.aspect -0.9f))
                    xInput = -1.0f;
            }
        }

        float xSpeed = xInput * speed;

        Vector2 newVelocity = new Vector2(xSpeed, 0f);
        nogomRigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        gameObject.SetActive(false);
        isDead = true;

        

        GameManager2.instance.OnPlayerDead();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead")
        {
            if (playerAudio != BombClip)
                playerAudio.clip = BombClip;
            playerAudio.Play();
        }
        else if (other.tag == "fallingObject")
        {
            if (playerAudio != ObjectClip)
                playerAudio.clip = ObjectClip;
            playerAudio.Play();
        }
        else if (other.tag == "b_fallingObject")
        {
            if (playerAudio != b_ObjectClip)
                playerAudio.clip = b_ObjectClip;
            playerAudio.Play();
        }
    }
}