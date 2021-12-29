using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dda_gauge : MonoBehaviour
{
    [SerializeField]
    public Slider dda_bar;

    public float maxHp = 100;
    public float curHp = 70;
    public float plusHp = 0.0f;
    public bool isGameover = false;
    public bool isSuccess = false;

    public Hole ms;
    public Hole ms1;
    public Hole ms2;
    public Hole ms3;
    public Hole ms4;
    public Hole ms5;
    public Hole ms6;
    public Hole ms7;
    public Hole ms8;

    public Game_manager GM;

    // Start is called before the first frame update
    void Start()
    {
        dda_bar.value = (float)curHp / (float)maxHp;
        plusHp = 1 / maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (dda_bar.value != maxHp)
        {
            if (curHp > 0)
            {
                dda_bar.value += plusHp * Time.deltaTime * 3;
                if (dda_bar.value == 1)
                {
                    isGameover = true;
                    //GM.onPlayerClean()
                }
            }
        }
        if ((int)ms.Ms == 4 || (int)ms1.Ms == 4 || (int)ms2.Ms == 4 || (int)ms3.Ms == 4 || (int)ms4.Ms == 4 || (int)ms5.Ms == 4 || (int)ms6.Ms == 4 || (int)ms7.Ms == 4 || (int)ms8.Ms == 4)
        {
            if(curHp > 0 && dda_bar.value < 1)
            {
                curHp = dda_bar.value * maxHp - 0.2f;
                HandleHp();
            }
            else
            {
                curHp = 0;
                if(curHp == 0)
                {
                    isSuccess = true;
                }
            }
            
        }
    }

    public void HandleHp()
    {
        //dda_bar.value = Mathf.Lerp(dda_bar.value, (float)curHp / (float)maxHp, Time.deltaTime * 10);
        dda_bar.value = (float)curHp /(float)maxHp;
    }
}
