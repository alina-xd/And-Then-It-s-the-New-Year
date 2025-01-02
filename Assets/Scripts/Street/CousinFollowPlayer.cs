using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CousinFollowPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject cousin;
    public float speed;
    public float closeLimit;
    public float y;

    private float distance;
    private Vector2 targetPosition;

    public SpriteRenderer sprite;
    public Animator animator;

    void Update()
    {
        targetPosition = new Vector2(player.transform.position.x, y);
        distance = Vector2.Distance(targetPosition, cousin.transform.position);

        if (distance > closeLimit)
        {
            cousin.transform.position = Vector2.MoveTowards(cousin.transform.position, targetPosition, speed * Time.deltaTime);
            animator.SetBool("CousinMoving", true);
        }
        else animator.SetBool("CousinMoving", false);
        if (cousin.transform.position.x <= targetPosition.x)
        {
            sprite.flipX = true;
        }
        else if (cousin.transform.position.x >= targetPosition.x)
        {
            sprite.flipX = false;
        }

        //trigger dialogue 14
        if (player.transform.position.x <= -175)
        {
            StateNameController.StreetDialogue2 = true;
        }
    }
}
