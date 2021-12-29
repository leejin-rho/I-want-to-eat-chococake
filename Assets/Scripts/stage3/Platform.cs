using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//발판으로서 필요한 동작을 담은 스크립트
public class Platform : MonoBehaviour
{
    public GameObject[] obstacles;
   
    
    //컴포넌트가 활성화될 때마다 매번 실행되는 메서드
    private void OnEnable()
    {
        //현재 순번의 장애물을 1/4의 확률로 활성화
        int rand = Random.Range(0, 4);
        
        
        for(int i = 0; i < obstacles.Length; i++)
        {
            if (i == rand) continue;
            obstacles[i].SetActive(false);
        }
        
        obstacles[rand].SetActive(false);
        obstacles[rand].SetActive(true);

        Transform[] trCoins = obstacles[rand].GetComponentsInChildren<Transform>(true);
        for(int i=0;i< trCoins.Length; i++)
        {
            trCoins[i].gameObject.SetActive(true);
        }
    }
    

}
