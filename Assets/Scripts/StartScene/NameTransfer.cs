using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameTransfer : MonoBehaviour
{
    public string PlayerName;
    public GameObject inputField;
    //public GameObject textDisplay;

    public void StoreName()
    {
        PlayerName = inputField.GetComponent<Text>().text;
        //textDisplay.GetComponent<Text>().text = PlayerName;
    }
}
