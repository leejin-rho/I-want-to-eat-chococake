using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.UI;



public enum MoleState
{
    None,
    Open,
    Idle,
    Close,
    Catch
}

public class Hole : MonoBehaviour
{
    public MoleState Ms;

    public Texture[] Open_Images;
    public Texture[] Idle_Images;
    public Texture[] Close_Images;
    public Texture[] Catch_Images;

    int Ani_Count; //몇 장의 애니메이션을 쓰는지

    public Game_manager GM;
    public AudioClip bubble;
    private AudioSource audioSource;

    void Start()
    {
        GM.G0();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bubble;

        if (GM.Gs == GameState.Play)
        {
            Open_On();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (GM.Gs == GameState.Play)
        {
            switch (Ms)
            {
                case MoleState.Open:
                    Open_ing();
                    break;
                case MoleState.Idle:
                    Idle_ing();
                    break;
                case MoleState.Close:
                    Close_ing();
                    break;
                case MoleState.Catch:
                    audioSource.Play();
                    Catch_ing();
                    break;
            }
        }

        /*if(Input.GetMouseButtonUp(0))
        {
            if (Ms == MoleState.Idle || Ms == MoleState.Open)
            {
                Catch_On();
            }
        }*/ 
    }

    public void OnMouseDown()
    {
        //if(EventSystem.current.IsPointerOverGameObject() == false)
        if ((Ms == MoleState.Idle) || (Ms == MoleState.Open))
            Catch_On();
    }

    public void Open_On()
    {
        Ms = MoleState.Open;
        Ani_Count = 0;
    }

    public void Open_ing()
    {
        GetComponent<Renderer>().material.mainTexture = Open_Images[Ani_Count];

        Ani_Count += 1;

        if(Ani_Count >= Open_Images.Length)
        {
            Idle_On();
        }
    }

    public void Idle_On()
    {
        Ms = MoleState.Idle;
        Ani_Count = 0;
    }

    public void Idle_ing()
    {
        GetComponent<Renderer>().material.mainTexture = Idle_Images[Ani_Count];

        Ani_Count += 1;

        if (Ani_Count >= Idle_Images.Length)
        {
            Close_On();
        }
    }

    public void Close_On()
    {
        Ms = MoleState.Close;
        Ani_Count = 0;
    }

    public void Close_ing()
    {
        GetComponent<Renderer>().material.mainTexture = Close_Images[Ani_Count];

        Ani_Count += 1;

        if (Ani_Count >= Close_Images.Length)
        {
            StartCoroutine("Wait");
        }
    }

    public void Catch_On()
    {
        Ms = MoleState.Catch;
        Ani_Count = 0;
    }

    public void Catch_ing()
    {
        GetComponent<Renderer>().material.mainTexture = Catch_Images[Ani_Count];

        Ani_Count += 1;

        if (Ani_Count >= Catch_Images.Length)
        {
            StartCoroutine("Wait");
        }
    }

    public IEnumerator Wait()
    {
        Ms = MoleState.None;
        Ani_Count = 0;
        float wait_time = Random.Range(0.5f, 4.5f);
        yield return new WaitForSeconds(wait_time);
        Open_On();
    }

    void start()
    {
        Open_On();
    }
}
