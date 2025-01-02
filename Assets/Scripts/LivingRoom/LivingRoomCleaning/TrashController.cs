using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    public GameObject gameobject;

    void Update()
    {
        if (StateNameController.CleaningBegin == true)
        {
            gameobject.SetActive(true);
            StateNameController.CleaningBegin = false;
        }
        if (StateNameController.CleanCount >= 8)
        {
            StateNameController.CleaningEnd = true;
            StateNameController.CleanCount = 0;
            StateNameController.LivingRoomDialogue3 = true;
        }
    }
}
