using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeToLobby : MonoBehaviour
{
    public AudioClip start;
    private AudioSource startaudio;

    public void ToLobby()
    {
        //테스트
        // PlayerPrefs.DeleteAll();
        startaudio = GetComponent<AudioSource>();
        startaudio.clip = start;
        startaudio.Play();

        SceneManager.LoadScene("LOBBY");
    }
}
