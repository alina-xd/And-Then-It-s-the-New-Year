using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger2 : MonoBehaviour
{
    public Dialogue dialogue;

    void Update()
    {
        if (StateNameController.BedroomDialogue2 == true && StateNameController.BedroomDialogue2Started == false)
        {
            FindObjectOfType<DialogueManager2>().StartDialogue(dialogue);
            StateNameController.BedroomDialogue2Started = true;
            StateNameController.CanMove = false;
        }
    }
}
