﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickAgain : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("LOBBY");
    }

}
