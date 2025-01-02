using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickLionsHead : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (FoodManager.CanClickFood == true)
        {
            StateNameController.LionsHeadDialogue = true;
        }
    }
}
