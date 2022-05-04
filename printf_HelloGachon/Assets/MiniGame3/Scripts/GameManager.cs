using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public DialManager dialManager;
    public Button dialBtn;
    public Text dialText;
    int count = 0;

    public void BtnOnClick()
    {
        dialText.text = dialManager.GetDial(count);
        count++;
    }
}
