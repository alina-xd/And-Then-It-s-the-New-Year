using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFirework : MonoBehaviour
{
    public GameObject background;
    public Sprite fireworks;

    private void OnMouseDown()
    {
        background.GetComponent<SpriteRenderer>().sprite = fireworks;
        FindObjectOfType<AudioManager>().Play("Firework");
        StateNameController.FireworkDialogue2 = true;
    }
}
