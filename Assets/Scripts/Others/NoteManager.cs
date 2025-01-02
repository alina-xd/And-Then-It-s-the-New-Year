using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteManager : MonoBehaviour
{
    public DialoguesEtName[] dialogue;
    public Text titleText;
    public Text noteText;
    public Text number;
    public Animator animator;
    private int length;
    private int i;
    private int j;

    public Button start;
    public Button next;
    public Button previous;
    public Button end;

    void Start()
    {
        start.onClick.AddListener(StartNote);
        next.onClick.AddListener(DisplayNextSentence);
        previous.onClick.AddListener(DisplayPreviousSentence);
        end.onClick.AddListener(EndDialogue);
    }

    void Update()
    {
        if (StateNameController.NoteLength > 0)
        {
            start.gameObject.SetActive(true);
        }
        else
        {
            start.gameObject.SetActive(false);
        }
        number.text = (StateNameController.NoteLength - 1).ToString();
    }

    void StartNote()
    {
        length = StateNameController.NoteLength;
        animator.SetBool("IsOpen", true);
        if (length == 2)
        {
            i = 0;
        }
        else
        {
            i = length - 1;
        }
        j = 0;
        ShowSentence();
    }

    void DisplayNextSentence()
    {
        if (j < dialogue[i].sentences.Length-1)
        {
            j++;
        }
        else
        {
            if (i < length - 1)
            {
                i++;
                j = 0;
            }
        }
        ShowSentence();
    }

    void DisplayPreviousSentence()
    {
        if (j > 0)
        {
            j--;
        }
        else
        {
            if (i > 0)
            {
                i--;
                j = dialogue[i].sentences.Length - 1;
            }
        }
        ShowSentence();
    }

    void ShowSentence()
    {
        titleText.text = dialogue[i].name;
        noteText.text = dialogue[i].sentences[j];
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
