using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPekingDuck : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (FoodManager.CanClickFood == true)
        {
            StateNameController.PekingDuckDialogue = true;
        }
    }
}
