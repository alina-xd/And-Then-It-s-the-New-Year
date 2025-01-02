using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager2 : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        //nameText.text = dialogue.name;
        nameText.text = StateNameController.PlayerName;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (StateNameController.BedroomDialogue2 == true)
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        FindObjectOfType<AudioManager>().Play("Dialogue");
        bool CanEnd = false;
        dialogueText.text = "";
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
                    dialogueText.text = sentence;
                    break;
                }
            }
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        StateNameController.BedroomDialogue2 = false;
        StateNameController.CanMove = true;
        StateNameController.DoorAppear = true;
    }
}
