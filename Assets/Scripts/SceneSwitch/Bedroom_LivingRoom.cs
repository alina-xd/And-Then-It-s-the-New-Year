using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bedroom_LivingRoom : MonoBehaviour
{
    public Animator animator;

    public void SwitchScene()
    {
        FindObjectOfType<FadeInOut>().Load("LivingRoom");
        StateNameController.LivingRoomDialogue1 = true;
    }

    void Update()
    {
        if (StateNameController.DoorAppear == true)
        {
            animator.SetBool("Appear", true);
        }
    }
}
