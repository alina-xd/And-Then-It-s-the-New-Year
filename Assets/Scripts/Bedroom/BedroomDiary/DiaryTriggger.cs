using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryTriggger : MonoBehaviour
{
    public Animator animator;
    public void TriggerDiary()
    {
        FindObjectOfType<DiaryManager>().StartDiary();
        StateNameController.CanMove = false;
        FindObjectOfType<AudioManager>().Play("OpenBook");
    }
    // Update is called once per frame
    void Update()
    {
        if(StateNameController.BedroomDiary == true)
        {
            animator.SetBool("Appear", true);
        }
    }
}
