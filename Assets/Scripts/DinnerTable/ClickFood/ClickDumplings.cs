using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDumplings : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (FoodManager.CanClickFood == true)
        {
            StateNameController.DumplingsDialogue = true;
        }
    }
}
