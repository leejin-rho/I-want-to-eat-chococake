using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public GameObject[] hearts;

    // Update is called once per frame
    public void HeartOff()
    {
        int index = NogomController.heartCount;
        hearts[index].SetActive(false);

        
    }
}
