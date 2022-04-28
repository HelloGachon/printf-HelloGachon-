using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputFieldBehavior : MonoBehaviour
{
    public InputField myInputField;
    // Start is called before the first frame update
    void Start()
    {
        myInputField.onValueChanged.AddListener(ValueChanged);
        // myInputField.ContentSizeFitter.SetLayoutHorizontal();
    }

    // Update is called once per frame
    void ValueChanged(string text)
    {
        Debug.Log(myInputField.text);
    }
}
