using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanTrash : MonoBehaviour
{
    public GameObject gameobject;
    Vector2 touchPosition;
    public Vector2 d;
    private bool destroy;

    void Update()
    {
        //gameobject.SetActive(StateNameController.CleaningBegin);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (touchPosition.x < transform.position.x + d.x && touchPosition.x > transform.position.x - d.x
                && touchPosition.y < transform.position.y + d.y && touchPosition.y > transform.position.y - d.y)
            {
                destroy = true;
            }
        }
        else
        {
            if (destroy == true)
            {
                Destroy(gameobject);
                StateNameController.CleanCount++;
            }
        }
    }
}
