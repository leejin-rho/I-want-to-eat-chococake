// 노곰런
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public int count = 4;

    public float timeBetSpawnMin = 0.5f; // 다음 배치까지 시간 간격 최솟값
    public float timeBetSpawnMax = 1.5f; // 다음 배치까지 시간 간격 최댓값
    public static float timeBetSpawn; // 다음 배치까지 시간 간격

    public float yMin = -3.5f; // 배치할 위치의 최소 y값
    public float yMax = 1.5f; // 배치할 위치의 최대 y값
    public float xPos = 10f; // 배치할 위치의 x값
    public float xMax = 10f; // 배치할 위치의 x값
    public float xMin = 8f; // 배치할 위치의 x값

    public static bool isfirst = true;

    private GameObject[] platforms; // 미리 생성한 발판들
    private int currentIndex = 0; // 사용할 현재 순번의 발판

    //초반에 생성한 발판을 화면 밖에 숨겨둘 위치
    private Vector2 poolPosition = new Vector2(0, -25);
    public static float lastSpawnTime; // 마지막 배치 시점

    
    // Start is called before the first frame update
    void Start()
    {
        // 변수 초기화, 사용할 발판 미리 생성

        platforms = new GameObject[count];

        for(int i = 0; i < count; i++)
        {
            //platformPrefab을 원본으로 새 발판을 poolposition위체에 복제
            //count만큼 루프하며 발판 생성
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
        }

        // 마지막 배치 시점 초기화
        lastSpawnTime = 0f;

        // 다음번 배치까지의 시간 간격을 0으로 초기화
        timeBetSpawn = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        // 순서를 돌아가며 주기적으로 발판 배치

        if (GameManager3.instance.isGameover)
        {
            return;
        }

        //마지막 배치 시점에서 timeBetSpawn 이상의 시간이 흘렀다면
        if(Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;

            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
           // float xPos = Random.Range(xMin, xMax);

            float yPos = Random.Range(yMin, yMax);

            //초기화위해 껐다 켜줌
            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            //현재 순번의 발판을 화면 오른쪽에 재배치
            if (isfirst)
            {
               platforms[currentIndex].transform.position = new Vector2(10, yPos);
               isfirst = false;
               lastSpawnTime = Time.time+1.2f; timeBetSpawn = 0f;
            }
            else {
                platforms[currentIndex].transform.position = new Vector2(xPos, yPos);
            }

            //순번 넘기기
            currentIndex++;

            if (currentIndex >= count)
            {
                currentIndex = 0;
            }

        }

    }
}
