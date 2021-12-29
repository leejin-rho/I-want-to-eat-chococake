using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // 생성할 오브젝트들의 원본 프리팹
    public GameObject needlePrefab, b_needlePrefab, threadPrefab, b_threadPrefab, fabricPrefab, b_fabricPrefab, bombPrefab;
    public int count = 10;

    public float timeBetSpawnMin = 0f, timeBetSpawnMax = 0.5f;  // 다음 배치까지 시간 간격 최소, 최대값
    private float timeBetSpawn;                                     // 다음 배치까지의 시간 간격

    public float xMin = -8.5f, xMax = 8.5f;     // 배치할 위치의 최소, 최대 x값
    private float yPos = 7f;                    // 배치할 위치의 y값

    private GameObject[] fallingobjects;        // 프리팹으로부터 생성한 fallingobject를 저장할 배열 변수
    private int currIndex;                      // 현재 사용하고 있는 fallingobject의 index

    private Vector2 poolPosition = new Vector2(0, -30);     // 초반에 fallingobject를 모아둘 위치
    private float lastSpawnTime;                            // 마지막으로 배치했던 시간

    void Start()
    {
        fallingobjects = new GameObject[count];
        fallingobjects[0] = Instantiate(needlePrefab, poolPosition, Quaternion.identity);
        fallingobjects[1] = Instantiate(needlePrefab, poolPosition, Quaternion.identity);
        fallingobjects[2] = Instantiate(needlePrefab, poolPosition, Quaternion.identity);
        fallingobjects[3] = Instantiate(b_needlePrefab, poolPosition, Quaternion.identity);
        fallingobjects[4] = Instantiate(threadPrefab, poolPosition, Quaternion.identity);
        fallingobjects[5] = Instantiate(threadPrefab, poolPosition, Quaternion.identity);
        fallingobjects[6] = Instantiate(b_threadPrefab, poolPosition, Quaternion.identity);
        fallingobjects[7] = Instantiate(fabricPrefab, poolPosition, Quaternion.identity);
        fallingobjects[8] = Instantiate(b_fabricPrefab, poolPosition, Quaternion.identity);
        fallingobjects[9] = Instantiate(bombPrefab, poolPosition, Quaternion.identity);

        lastSpawnTime = 0f;
        timeBetSpawn = 0f;
    }

    void Update()
    {
        // 게임 오버 상태에는 작동x
        if (GameManager2.instance.isGameover || GameManager2.instance.isSuccess)
            return;

        // 마지막 배치 시각에서 timeBetSpawn 이상 시간이 흘렀다면
        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;      // 기록된 마지막 배치 시각을 현재 시각으로 갱신

            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
            float xPos = Random.Range(xMin, xMax);

            currIndex = Random.Range(0, 10);
            if ((fallingobjects[currIndex].transform.position.y < -7f) || (fallingobjects[currIndex].active == false))    // 가져오려는 인덱스의 오브젝트가 이미 화면밖으로 떨어진 오브젝트거나 노곰이 획득한 오브젝트일 때
            {
                fallingobjects[currIndex].SetActive(false);
                fallingobjects[currIndex].SetActive(true);

                fallingobjects[currIndex].transform.position = new Vector2(xPos, yPos);
            }
        }
    }
}