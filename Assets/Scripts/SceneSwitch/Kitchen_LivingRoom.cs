using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kitchen_LivingRoom : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x >= 45)
        {
            StateNameController.KitchenToLivingRoom = true;
        }
        if (StateNameController.KitchenToLivingRoom == true)
        {
            StateNameController.KitchenToLivingRoom = false;
            StateNameController.LivingRoomDialogue2 = true;
            //StateNameController.KitchenDialogue1Started = true;
            if (StateNameController.LivingRoomDialogue2Started == false)
            {
                StateNameController.CleaningBegin = true;
            }
            FindObjectOfType<FadeInOut>().Load("LivingRoom");

        }
    }
}
