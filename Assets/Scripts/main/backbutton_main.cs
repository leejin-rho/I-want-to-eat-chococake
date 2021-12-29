using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class backbutton_main : MonoBehaviour
{
    //private AndroidJavaObject curActivity = null;

    int ClickCount = 0;

    public GameObject toastmessage;
    /*private void Awake()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            curActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        }
    }
    */
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickCount++;

            if (ClickCount == 1)
            {
                if (!IsInvoking("DoubleClick"))
                {//invoke 함수가 실행되고 있는지 파악해주는 함수
                    toastmessage.SetActive(true);
                    Invoke("DoubleClick", 1.0f);
                    toastmessage.SetActive(false);
                    //ShowToast("뒤로가기 버튼을 한번 더 누르면 종료됩니다.");
                }
            }

        }
        else if (ClickCount == 2)
        {
            CancelInvoke("DoubleClick"); //종료
            Application.Quit();
        }

    }

    void DoubleClick()
    {
        ClickCount = 0;
    }

    /*private void OnGUI()
    {
        if()
    }

    void ShowToast(string message)
    {
        currentActivity.Call
        (
            "runOnUiThread",
            new AndroidJavaRunnable(() =>
            {
                AndroidJavaClass Toast
                = new AndroidJavaClass("android.widget.Toast");

                AndroidJavaObject javaString
                = new AndroidJavaObject("java.lang.String", message);

                toast = Toast.CallStatic<AndroidJavaObject>
                (
                    "makeText",
                    context,
                    javaString,
                    Toast.GetStatic<int>("LENGTH_SHORT")
                );

                toast.Call("show");
            })
         );
    }*/


}
