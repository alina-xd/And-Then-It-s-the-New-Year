using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanDirt : MonoBehaviour
{
    public GameObject WindowDirt;
    public GameObject WallDirt;

    void Update()
    {
        if(StateNameController.CleanWall == true)
        {
            Wall();
        }
        else if (StateNameController.CleanWindow == true)
        {
            Window();
        }
    }

    void Wall()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Destroy(WallDirt);
                StateNameController.CleanCount++;
                StateNameController.CleanWall = false;
            }
        }
    }

    void Window()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Destroy(WindowDirt);
                StateNameController.CleanCount++;
                StateNameController.CleanWindow = false;
            }
        }
    }
}
