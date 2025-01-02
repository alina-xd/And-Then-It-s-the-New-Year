using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager3 : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue dialogue2;
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    private int state;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
        state = 1;
    }

    void Update()
    {
        if (StateNameController.LivingRoomDialogue1 == true && StateNameController.LivingRoomDialogue1Started == false)
        {
            StartDialogue(dialogue);
            StateNameController.CanMove = false;
            StateNameController.LivingRoomDialogue1 = false;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        sentences.Clear();

        if (state == 1)
        {
            nameText.text = StateNameController.PlayerName;
        }
        else if (state == 2)
        {
            nameText.text = "Mom";
        }
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
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
        if (state == 1)
        {
            state = 2;
            StartDialogue(dialogue2);
        }
        else if (state == 2)
        {
            animator.SetBool("IsOpen", false);
            StateNameController.CanMove = true;
            StateNameController.LivingRoomDialogue1Started = true;
        }
    }
}
