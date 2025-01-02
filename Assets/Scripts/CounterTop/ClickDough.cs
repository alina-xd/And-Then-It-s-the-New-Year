using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDough : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (CookingManager.CanClickDough)
        {
            CookingManager.doughIndex++;
        }
    }
}
