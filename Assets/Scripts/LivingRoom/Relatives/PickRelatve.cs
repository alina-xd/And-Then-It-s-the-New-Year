using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickRelatve : MonoBehaviour
{
    public Button grandma;
    public Button grandpa;
    public Button aunt;
    public Button uncle;

    Touch touch;

    void Start()
    {
        grandma.onClick.AddListener(Grandma);
        grandpa.onClick.AddListener(Grandpa);
        aunt.onClick.AddListener(Aunt);
        uncle.onClick.AddListener(Uncle);
    }

    void Update()
    {
        if (StateNameController.PickRelative == true)
        {
            Pick();
        }
        if(StateNameController.GrandmaDialogueStarted && StateNameController.GrandpaDialogueStarted
            && StateNameController.AuntDialogueStarted && StateNameController.UncleDialogueStarted)
        {
            StateNameController.LivingRoomDialogue6 = true;
        }
    }

    void Pick()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject person = hit.collider.gameObject;
                string name = person.transform.name;
                if (name == "Grandma" && StateNameController.GrandmaDialogueStarted == false)
                {
                    grandma.gameObject.SetActive(true);
                    grandpa.gameObject.SetActive(false);
                    aunt.gameObject.SetActive(false);
                    uncle.gameObject.SetActive(false);
                }
                else if (name == "Grandpa" && StateNameController.GrandpaDialogueStarted == false)
                {
                    grandpa.gameObject.SetActive(true);
                    grandma.gameObject.SetActive(false);
                    aunt.gameObject.SetActive(false);
                    uncle.gameObject.SetActive(false);
                }
                else if (name == "Aunt" && StateNameController.AuntDialogueStarted == false)
                {
                    aunt.gameObject.SetActive(true);
                    grandpa.gameObject.SetActive(false);
                    grandma.gameObject.SetActive(false);
                    uncle.gameObject.SetActive(false);
                }
                else if (name == "Uncle" && StateNameController.UncleDialogueStarted == false)
                {
                    uncle.gameObject.SetActive(true);
                    grandpa.gameObject.SetActive(false);
                    grandma.gameObject.SetActive(false);
                    aunt.gameObject.SetActive(false);
                }
            }
        }
    }

    void Grandma()
    {
        StateNameController.GrandmaDialogue = true;
        grandma.gameObject.SetActive(false);
    }
    void Grandpa()
    {
        StateNameController.GrandpaDialogue = true;
        grandpa.gameObject.SetActive(false);
    }
    void Aunt()
    {
        StateNameController.AuntDialogue = true;
        aunt.gameObject.SetActive(false);
    }
    void Uncle()
    {
        StateNameController.UncleDialogue = true;
        uncle.gameObject.SetActive(false);
    }
}
