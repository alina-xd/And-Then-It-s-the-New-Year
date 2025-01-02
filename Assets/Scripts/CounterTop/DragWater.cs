using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragWater : MonoBehaviour
{
    bool isDragging;

    public float offsetX;
    public float offsetY;

    public float goalX;
    public float goalY;

    public float minDistance;

    Vector2 startPos;

    private void Start()
    {
        startPos = new Vector2(transform.position.x, transform.position.y);
    }

    public void OnMouseDown()
    {
        if (CookingManager.CanDragWater)
        {
            isDragging = true;
        }
    }

    public void OnMouseUp()
    {
        isDragging = false;
        float diffX = Mathf.Abs(transform.position.x - goalX);
        float diffY = Mathf.Abs(transform.position.y - goalY);
        if (diffX < minDistance && diffY < minDistance)
        {
            CookingManager.DoughMade = true;
        }
        else
        {
            transform.position = startPos;
        }
    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 offsetVector = new Vector2(offsetX, offsetY);
            Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position - (Vector3)offsetVector;
            transform.Translate(MousePos);
        }
    }
}
