using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickStore : MonoBehaviour
{
    public GameObject quanjia;
    public GameObject unnamed;
    public GameObject shaxian;
    public GameObject baiguoyuan;
    public GameObject mixue;
    public GameObject laiyifen;
    public GameObject lanzhoulamian;
    public GameObject icbc;

    public GameObject quanjiaCollider;
    public GameObject unnamedCollider;
    public GameObject shaxianCollider;
    public GameObject baiguoyuanCollider;
    public GameObject mixueCollider;
    public GameObject laiyifenCollider;
    public GameObject lanzhoulamianCollider;
    public GameObject icbcCollider;

    Touch touch;

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        Pick();
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
                //colliders
                if (name == "quanjiaCollider")
                    if(touch.phase == TouchPhase.Ended)
                    {
                        Initialize();
                        quanjia.SetActive(true);
                        quanjiaCollider.SetActive(false);
                    }
                if (name == "unnamedCollider")
                    if (touch.phase == TouchPhase.Ended)
                    {
                        Initialize();
                        unnamed.SetActive(true);
                        unnamedCollider.SetActive(false);
                    }
                if (name == "shaxianCollider")
                    if (touch.phase == TouchPhase.Ended)
                    {
                        Initialize();
                        shaxian.SetActive(true);
                        shaxianCollider.SetActive(false);
                    }
                if (name == "baiguoyuanCollider")
                    if (touch.phase == TouchPhase.Ended)
                    {
                        Initialize();
                        baiguoyuan.SetActive(true);
                        baiguoyuanCollider.SetActive(false);
                    }
                if (name == "mixueCollider")
                    if (touch.phase == TouchPhase.Ended)
                    {
                        Initialize();
                        mixue.SetActive(true);
                        mixueCollider.SetActive(false);
                    }
                if (name == "laiyifenCollider")
                    if (touch.phase == TouchPhase.Ended)
                    {
                        Initialize();
                        laiyifen.SetActive(true);
                        laiyifenCollider.SetActive(false);
                    }
                if (name == "lanzhoulamianCollider")
                    if (touch.phase == TouchPhase.Ended)
                    {
                        Initialize();
                        lanzhoulamian.SetActive(true);
                        lanzhoulamianCollider.SetActive(false);
                    }
                if (name == "icbcCollider")
                    if (touch.phase == TouchPhase.Ended)
                    {
                        Initialize();
                        icbc.SetActive(true);
                        icbcCollider.SetActive(false);
                    }

                //buttons
                if (name == "quanjiaButton")
                    if (touch.phase == TouchPhase.Ended
                        && StateNameController.DialogueRunning == false)
                        StateNameController.QuanjiaDialogue = true;
                if (name == "unnamedButton")
                    if (touch.phase == TouchPhase.Ended
                        && StateNameController.DialogueRunning == false)
                        StateNameController.UnnamedDialogue = true;
                if (name == "shaxianButton")
                    if (touch.phase == TouchPhase.Ended
                        && StateNameController.DialogueRunning == false)
                        StateNameController.ShaxianDialogue = true;
                if (name == "baiguoyuanButton")
                    if (touch.phase == TouchPhase.Ended
                        && StateNameController.DialogueRunning == false)
                        StateNameController.BaiguoyuanDialogue = true;
                if (name == "mixueButton")
                    if (touch.phase == TouchPhase.Ended
                        && StateNameController.DialogueRunning == false)
                        StateNameController.MixueDialogue = true;
                if (name == "laiyifenButton")
                    if (touch.phase == TouchPhase.Ended
                        && StateNameController.DialogueRunning == false)
                        StateNameController.LaiyifenDialogue = true;
                if (name == "lanzhoulamianButton")
                    if (touch.phase == TouchPhase.Ended
                        && StateNameController.DialogueRunning == false)
                        StateNameController.LanzhoulamianDialogue = true;
                if (name == "icbcButton")
                    if (touch.phase == TouchPhase.Ended
                        && StateNameController.DialogueRunning == false)
                        StateNameController.IcbcDialogue = true;
            }
        }
    }
    void Initialize()
    {
        quanjia.SetActive(false);
        unnamed.SetActive(false);
        shaxian.SetActive(false);
        baiguoyuan.SetActive(false);
        mixue.SetActive(false);
        laiyifen.SetActive(false);
        lanzhoulamian.SetActive(false);
        icbc.SetActive(false);

        quanjiaCollider.SetActive(true);
        unnamedCollider.SetActive(true);
        shaxianCollider.SetActive(true);
        baiguoyuanCollider.SetActive(true);
        mixueCollider.SetActive(true);
        laiyifenCollider.SetActive(true);
        lanzhoulamianCollider.SetActive(true);
        icbcCollider.SetActive(true);
    }
}
