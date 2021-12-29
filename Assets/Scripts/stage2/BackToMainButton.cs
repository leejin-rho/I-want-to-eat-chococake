using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainButton : MonoBehaviour
{
    public void OnClick_GoToMain()
    {
        SceneManager.LoadScene("LOBBY");
    }

    void Update()
    {
       
    }
}
