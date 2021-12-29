using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thread : FallingObject
{
    public override void getObject(nogomControllerStage2 nogomController)
    {
        GameManager2 gameManager2 = GameObject.Find("GameManager2").GetComponent<GameManager2>();
        if (gameManager2.n_thread < gameManager2.goal_t)
        {
            gameManager2.n_thread++;
            GameObject.Find("ThreadMarkerText").GetComponent<Text>().text = gameManager2.n_thread + "/" + gameManager2.goal_t;
        }
    }
}