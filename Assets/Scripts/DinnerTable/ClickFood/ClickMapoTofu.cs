using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMapoTofu : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (FoodManager.CanClickFood == true)
        {
            StateNameController.MapoTofuDialogue = true;
        }
    }
}
