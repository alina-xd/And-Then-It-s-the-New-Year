using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFish : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (FoodManager.CanClickFood == true)
        {
            StateNameController.FishDialogue = true;
        }
    }
}
