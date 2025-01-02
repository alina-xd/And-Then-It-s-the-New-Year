using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager28 : MonoBehaviour
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
        if (StateNameController.FireworkDialogue2 == true && StateNameController.FireworkDialogue2Started == false)
        {
            StartDialogue(dialogue[i]);
            StateNameController.FireworkDialogue2 = false;
            StateNameController.FireworkDialogue2Started = true;
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
            if (letter.Equals('_'))
            {
                dialogueText.text += StateNameController.PlayerName;
            }
            else
            {
                dialogueText.text += letter;
            }
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
            FindObjectOfType<FadeInOut>().Load("EndScene");
        }
    }
}
