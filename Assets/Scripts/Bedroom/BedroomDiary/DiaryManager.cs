using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaryManager : MonoBehaviour
{
    public Text diaryText;

    public Animator animator;

    private string[] sentences= 
        { "So tomorrow is the New Year. It's always been exciting to me, and I haven't figured out why yet?",
        "Most of my friends are only interested in the three-day off. And that is appealing to me indeed. But that explains nothing.",
        "Anyway, there are a lot of people coming tomorrow. Grandpa, grandma, uncle, auntie, and my cousin who's a total idiot.",
        "It's probably be like usual. We gossip a little bit, eat dinner, watch TV, and wait til the New Year comes.",
        "Wow. It always looks like a busy day when the schedule and everything is written down. And that's not even everything.",
        "Okay. Sleepiness is destroying my brain. I guess now I have to go to bed and hope tomorrow to be an interesting day."
    };
    private int length = 4;
    private int index;
    public void StartDiary()
    {
        StateNameController.CanMove = false;
        animator.SetBool("IsOpen", true);
        StateNameController.Dindex = -1;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        index = StateNameController.Dindex;
        //Debug.Log("index="+index);
        //Debug.Log("length="+length);
        if (index < length - 1)
        {
            index++;
            string sentence = sentences[index];
            StateNameController.Dindex = index;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
        else
        {
            EndDialogue();
        }
    }

    public void DisplayPreviousSentence()
    {
        index = StateNameController.Dindex;
        //Debug.Log("index=" + index);
        //Debug.Log("length=" + length);
        if (index > 0)
        {
            index--;
            string sentence = sentences[index];
            StateNameController.Dindex = index;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        FindObjectOfType<AudioManager>().Play("Flip");
        bool CanEnd = false;
        diaryText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    CanEnd = true;
                }
                if (touch.phase == TouchPhase.Ended && CanEnd == true)
                {
                    diaryText.text = sentence;
                    break;
                }
            }
            diaryText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        StateNameController.BedroomDialogue2 = true;
        StateNameController.CanMove = true;
        if (StateNameController.NoteLength < 2)
        {
            StateNameController.NoteLength = 2;
            FindObjectOfType<AudioManager>().Play("NewNote");
        }
    }
}
