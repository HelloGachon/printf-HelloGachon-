using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class gameManager : MonoBehaviour
{
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    
    // 조사대상이 있을 때만 대화창 띄우기
    public void Action(GameObject scanObj)
    {
        if(isAction){ //Exit Action
            isAction = false;
        }
        else{ //Enter Action
            isAction = true;
            scanObject = scanObj;
            talkText.text = "이것의 이름은 "+ scanObject.name+ "이라고 한다.";
        }
        
        talkPanel.SetActive(isAction);
    }
}
