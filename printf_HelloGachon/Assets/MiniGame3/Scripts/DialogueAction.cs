using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueAction : MonoBehaviour
{
    public Text dialText;
    public Button dialBtn;

    int count = 0;

    void Start()
    {
        dialBtn.onClick.AddListener(() => {});
    }

    public void TaskOnClick()
    {
        Debug.Log(count);
        dialText.text = "dialogue changed..";
        count += 1;
    }
}
