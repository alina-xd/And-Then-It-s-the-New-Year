using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingManager : MonoBehaviour
{
    public static bool CanDragWater;
    public static bool DoughMade;

    public static bool CanClickDough;
    public static int doughIndex = 0;

    public static bool CanDragRollingPin;
    public static bool DoughRolled;

    public static bool CanDragFillings;
    public static bool FillingsAdded;

    public static bool CanClickFillings;
    public static bool DumplingsMade;

    public GameObject water;
    public GameObject flour;
    public GameObject dough;
    public GameObject flatDough;
    public GameObject fillings;
    public GameObject dumplings;
    public GameObject rollingPin;
    public GameObject fillingsBowl;

    public Sprite[] doughSprites;

    void Start()
    {
        dough.SetActive(false);
        flatDough.SetActive(false);
        fillings.SetActive(false);
        dumplings.SetActive(false);
    }

    void Update()
    {
        if (DoughMade == true)
        {
            water.SetActive(false);
            flour.SetActive(false);
            dough.SetActive(true);
            StateNameController.CounterTopDialogue2 = true;
        }

        if (doughIndex < doughSprites.Length)
        {
            dough.GetComponent<SpriteRenderer>().sprite = doughSprites[doughIndex];
        }
        else
        {
            StateNameController.CounterTopDialogue3 = true;
        }

        if (DoughRolled == true)
        {
            dough.SetActive(false);
            rollingPin.SetActive(false);
            flatDough.SetActive(true);
            StateNameController.CounterTopDialogue4 = true;
        }

        if (FillingsAdded == true)
        {
            fillingsBowl.SetActive(false);
            fillings.SetActive(true);
            StateNameController.CounterTopDialogue5 = true;
        }

        if (DumplingsMade == true)
        {
            flatDough.SetActive(false);
            fillings.SetActive(false);
            dumplings.SetActive(true);
            StateNameController.CounterTopDialogue6 = true;
        }
    }
}
