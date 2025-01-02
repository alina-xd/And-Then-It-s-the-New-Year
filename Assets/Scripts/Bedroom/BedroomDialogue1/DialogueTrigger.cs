using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public Animator animator;

    public void TriggerDialogue()
    {
        if (StateNameController.BedroomDialogue1Started == false)
        {
            StateNameController.BedroomDialogue1 = true;
            StateNameController.CanMove = false;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            animator.SetBool("IsOpen", true);
        }
    }
}
