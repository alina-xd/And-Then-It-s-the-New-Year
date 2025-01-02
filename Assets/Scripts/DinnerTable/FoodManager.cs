using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public static int FoodEaten = 0;

    public static bool CanClickFood;

    // Update is called once per frame
    void Update()
    {
        if (FoodEaten >= 7)
        {
            StateNameController.DinnerDialogue2 = true;
        }
    }
}
