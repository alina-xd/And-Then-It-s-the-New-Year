using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionMovement : MonoBehaviour
{
    public Animator animator;

    public float speed;

    public float maxY;
    public float minY;
    public float minSwipeDistY;

    Vector2 touchPosition;
    Vector2 targetPosition;
    Vector2 startPos;

    //public SpriteRenderer sprite;

    Touch touch;

    // Update is called once per frame
    void Update()
    {
        //get touch position
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended && StateNameController.LionCanMove == true)
            {
                float yDif = touch.position.y - startPos.y;
                if (yDif > minSwipeDistY)
                {
                    //Debug.Log("swipe up");
                    animator.SetTrigger("IsStandingUp");
                    animator.ResetTrigger("IsDiving");
                    if (StateNameController.LionDanceDialogue1Started == true)
                    {
                        StateNameController.StandUpComplete = true;
                    }
                }
                else if (yDif < -minSwipeDistY)
                {
                    //Debug.Log("swipe down");
                    animator.SetTrigger("IsDiving");
                    animator.ResetTrigger("IsStandingUp");
                    if(StateNameController.LionDanceDialogue2Started == true)
                    {
                        StateNameController.DiveComplete = true;
                    }
                }
                else
                {
                    touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                }
            }
        }
        //if not outside the ground, then move
        if (touchPosition.y < maxY && touchPosition.y > minY && StateNameController.LionCanMove == true)
        {
            targetPosition = new Vector2(touchPosition.x, touchPosition.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            animator.SetBool("IsMoving", true);
        }
        else animator.SetBool("IsMoving", false);
        //if not moving set animation to idle
        if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y)
        {
            animator.SetBool("IsMoving", false);
        }
        if (StateNameController.LionCanMove == false)
        {
            animator.SetBool("IsMoving", false);
        }
        //flip sprite if direction is opposite
        //if (transform.position.x <= targetPosition.x)
        //{
        //    sprite.flipX = true;
        //}
        //else if (transform.position.x >= targetPosition.x)
        //{
        //    sprite.flipX = false;
        //}
    }
}
