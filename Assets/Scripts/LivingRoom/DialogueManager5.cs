using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager5 : MonoBehaviour
{
    public DialoguesEtName[] dialogue;
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    private int total;
    private int i;
    private Queue<string> sentences;

    void Start()
    {
        total = dialogue.Length;
        sentences = new Queue<string>();
        i = 0;
    }

    void Update()
    {
        if (StateNameController.LivingRoomDialogue2 == true && StateNameController.LivingRoomDialogue2Started == false)
        {
            StartDialogue(dialogue[i]);
            StateNameController.CanMove = false;
            StateNameController.LivingRoomDialogue2 = false;
        }
    }

    public void StartDialogue(DialoguesEtName dialogue)
    {
        animator.SetBool("IsOpen", true);
        sentences.Clear();

        if (dialogue.name == "player")
        {
            nameText.text = StateNameController.PlayerName;
        }
        else
        {
            nameText.text = dialogue.name;
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
        if (i < total - 1)
        {
            StartDialogue(dialogue[++i]);
        }
        else if (i == total - 1)
        {
            animator.SetBool("IsOpen", false);
            StateNameController.LivingRoomDialogue2Started = true;
            StateNameController.NoteLength = 3;
            FindObjectOfType<AudioManager>().Play("NewNote");
        }
    }
}
