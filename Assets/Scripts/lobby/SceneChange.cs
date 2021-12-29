using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public AudioClip start;
    private AudioSource startaudio;

    public void ChangeFirstScene()
    {
        startaudio = GetComponent<AudioSource>();
        startaudio.clip = start;
        startaudio.Play();

        SceneManager.LoadScene("Stage1 explanation");
    }
    public void ChangeSecondScene()
    {
        startaudio = GetComponent<AudioSource>();
        startaudio.clip = start;
        startaudio.Play();

        SceneManager.LoadScene("STAGE2 explanation");
    }
    public void ChangeThirdScene()
    {
        startaudio = GetComponent<AudioSource>();
        startaudio.clip = start;
        startaudio.Play();

        SceneManager.LoadScene("STAGE3 explanation");
    }
}
