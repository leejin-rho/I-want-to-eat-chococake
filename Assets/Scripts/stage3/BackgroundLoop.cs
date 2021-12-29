using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundLoop : MonoBehaviour
{
    private float width;
    
    

    private void Awake()
    {
        //하늘 가로길이 측정
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }

    // Update is called once per frame
    private void Update()
    {
        // 현재 위치가 원점에서 왼쪽으로 width이상 이동하면 위치 재배치
        if(transform.position.x<= 2-width*1.2f)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        //현재 위치에서 오른쪽으로 가로길이*2 이동
        Vector2 offset = new Vector2(width*1.2f * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
    
}
