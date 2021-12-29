using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : FallingObject
{
    public override void getObject(nogomControllerStage2 nogomController)
    {
        nogomController.life--;

        if (nogomController.life == 2)
            GameObject.Find("HeartON").SetActive(false);
        else if (nogomController.life == 1)
            GameObject.Find("HeartON (1)").SetActive(false);
        else if (nogomController.life == 0)
        {
            GameObject.Find("HeartON (2)").SetActive(false);
            nogomController.Die();
        }
    }
}
