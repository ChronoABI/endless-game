using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    PlayerController player;
    jumpControl playerJump;
    //touch/swipecontrol
    //these two will help us know what exactly is a swipe
    public float maxSwipeTime;//0.5
    public float minSwipeDistance;//100


    //these three will help us know how long did our swipe took
    private float startTime;
    private float endTime;
    private float swipeTime;//this will be compared with maxTime;


    //these three will help us know how long the swipe is
    private Vector2 swipeStartPos;
    private Vector2 swipeEndPos;
    private float swipeDistance;//this will be compared with minSwipeDistance;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerJump = GameObject.FindGameObjectWithTag("Player").GetComponent<jumpControl>();
    }
    void Update()
    {
        SwipeTest();
    }
    void SwipeTest()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTime = Time.time;//this will see when we started touching the screen
                swipeStartPos = touch.position;//where we have started touching the screen
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTime = Time.time;//the time when we left th screen
                swipeEndPos = touch.position;//the position when we left the screen

                swipeTime = endTime - startTime;//this will calculate how long our swip took
                swipeDistance = (swipeEndPos - swipeStartPos).magnitude; //this will calculate how long our swipe is

                if (swipeTime < maxSwipeTime && swipeDistance > minSwipeDistance)
                {//here if we swipe fast and long enough then it will be a swipe
                    SwipeControl();
                }
            }
        }
    }

    void SwipeControl()
    {
        Vector2 distance = swipeEndPos - swipeStartPos;
        float xDistance = Mathf.Abs(distance.x);
        float yDistance = Mathf.Abs(distance.y);
        if (xDistance > yDistance)
        {

            Debug.Log("horizontal swipe");
            if (distance.x >0 && player.canDash)
            {
                //RigntSwipe
               player. isMoving = false;
               player. isDashing = true;
               player. canDash = false;
               
               player.rb.gravityScale = 0;
            }
            else if (distance.x <0 )
            {
             //LeftSwipe
            }
        }
        if (xDistance < yDistance)//if you are swiping up or down
        {
            Debug.Log("vertical swipe");
            if (distance.y > 0)
            {
                //your swiping up
                playerJump.jumpTimer = Time.time + playerJump.jumpDelay;

            }
            else if (distance.y < 0)
            {
                // your swiping down
            }
        }
    }
}
