using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Open_Bedroom : MonoBehaviour
{
    public string NameInput;
    public GameObject inputField;
    public Text alert;
    public void playGame()
    {
        NameInput = inputField.GetComponent<Text>().text;
        StateNameController.PlayerName = NameInput;
        if (NameInput != "")
        {
            FindObjectOfType<AudioManager>().Play("Button");
            FindObjectOfType<FadeInOut>().Load("Bedroom");
        }
        
    }
    
}
