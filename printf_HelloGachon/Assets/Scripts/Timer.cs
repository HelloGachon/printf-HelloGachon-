//분, 초, 밀리초를 표시하는 타이머

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerTxt;
    public float setTime; //inspecter 창에서 초를 입력받음
    public TypeGameManager tgManager;

    void Start()
    {
        tgManager.registerResult.SetActive(false);
    }
    void Update() {
        if (setTime > 0)
        {
            setTime -= Time.deltaTime;
        }
        else {
            setTime = 0.0f;
            Debug.Log("타임오버");
            tgManager.resultTxt.text = "타임오버!";
            tgManager.registerResult.SetActive(true);
        }

        DisplayTime(setTime);
    }

    public void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0.0f;
        }
        float min = Mathf.FloorToInt(timeToDisplay / 60);
        float sec = Mathf.FloorToInt(timeToDisplay % 60);
        float msec = (timeToDisplay % 1 * 1000) / 10;
        
        timerTxt.text = string.Format("{0:00}:{1:00}:{2:00}", min, sec, msec);
    }
}
