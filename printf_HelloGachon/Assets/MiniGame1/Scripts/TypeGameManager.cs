using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeGameManager : MonoBehaviour
{
    public GameObject Register;
    public GameObject registerResult;
    private Timer timer;
    public Text classNumTxt;
    public Text resultTxt;
    public InputField inputClassNum;
    public Button applyBtn;
    public Button okBtn;

    //test용 더미데이터
    private string classNum1 = "06823001";
    //private string classNum2 = "14329002";

    void Update()
    {
        classNumTxt.text = classNum1;
    }
    
    public void ApplyBtnClick()
    {
        //timer.setTime = 0.0f;
        if(inputClassNum.text == classNum1)
        {
            //timer.setTime = 0.0f;
            //timer.DisplayTime(timer.setTime);
            resultTxt.text = "성공!";
        }
        else if (inputClassNum.text != classNum1)
        {
            //timer.setTime = 0.0f;
            //timer.DisplayTime(timer.setTime);
            resultTxt.text = "실패!";            
        }
        registerResult.SetActive(true);
    }
    public void checkResult()
    {
        registerResult.SetActive(false);
        Debug.Log("확인완료");
    }
}
