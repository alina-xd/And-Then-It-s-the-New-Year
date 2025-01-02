using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        button.onClick.AddListener(NextScene);
    }

    // Update is called once per frame
    void Update()
    {
        //first mission: stand up
        if (StateNameController.StandUpComplete == true)
        {
            StateNameController.LionDanceDialogue2 = true;
        }
        //second mission: dive
        if (StateNameController.DiveComplete == true)
        {
            StateNameController.LionDanceDialogue3 = true;
        }
        //missions complete and free time
        if (StateNameController.LionDanceDialogue3Started == true)
        {
            button.gameObject.SetActive(true);
        }
    }
    public void NextScene()
    {
        FindObjectOfType<AudioManager>().Play("Theme");
        FindObjectOfType<AudioManager>().Stop("Luogu");
        FindObjectOfType<FadeInOut>().Load("LivingRoom3");
    }
}
