using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBokChoi : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (FoodManager.CanClickFood == true)
        {
            StateNameController.BokChoiDialogue = true;
        }
    }
}
