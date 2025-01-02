using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivingRoom_Kitchen : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //switch from living room to kitchen and to bedroom
        //cleaning time cannot move
        if (StateNameController.LivingRoomDialogue2Started == true && StateNameController.CleaningEnd == true
            || StateNameController.LivingRoomDialogue2Started == false)
        {
            if (transform.position.x <= -45)
            {
                StateNameController.LivingRoomToKitchen = true;
            }
            if (StateNameController.LivingRoomToKitchen == true)
            {
                FindObjectOfType<FadeInOut>().Load("Kitchen");
                StateNameController.LivingRoomToKitchen = false;
                StateNameController.KitchenDialogue1 = true;
                //StateNameController.KitchenDialogue1Started = true;
            }
            if (transform.position.x >= 45)
            {
                FindObjectOfType<FadeInOut>().Load("Bedroom");
            }
        }

        //trigger living room dialogue 4 with daddy when moving near
        if (StateNameController.LivingRoomDialogue3Started == true && StateNameController.LivingRoomDialogue4Started == false)
        {
            if (transform.position.x < -15 && transform.position.x > -40)
            {
                StateNameController.LivingRoomDialogue4 = true;
            }
        }
    }
}
