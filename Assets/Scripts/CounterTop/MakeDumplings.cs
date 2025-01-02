using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDumplings : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (CookingManager.CanClickFillings)
        {
            CookingManager.DumplingsMade = true;
        }
    }
}
