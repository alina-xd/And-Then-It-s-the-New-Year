using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDongpoRou : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (FoodManager.CanClickFood == true)
        {
            StateNameController.DongpoRouDialogue = true;
        }
    }
}
