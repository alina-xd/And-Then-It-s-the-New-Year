using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    public Animator animator;

    public float speed = 1.0f;
    //public float minX;
    //public float maxX;
    public float y;
    Vector2 touchPosition;
    Vector2 targetPosition;

    public SpriteRenderer sprite;

    Touch touch;

    //private float horizontalInput;
    //private float speed2 = 15.0f;

    void Update()
    {
        //horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(Time.deltaTime * speed2 * horizontalInput, 0, 0);

        //get touch position
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        }
        //move to target position and set animation to moving
        if (StateNameController.CanMove == true)
        {
            targetPosition = new Vector2(touchPosition.x, y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            animator.SetBool("IsMoving", true);
        }
        if(StateNameController.CanMove == false)
        {
            animator.SetBool("IsMoving", false);
        }
        //if not moving set animation to idle
        if (transform.position.x == targetPosition.x)
        {
            animator.SetBool("IsMoving", false);
        }
        //flip sprite if direction is opposite
        else if (transform.position.x <= targetPosition.x)
        {
            sprite.flipX = true;
        }
        else if (transform.position.x >= targetPosition.x)
        {
            sprite.flipX = false;
        }
    }
}