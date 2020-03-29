using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;

  [HideInInspector] public Rigidbody2D rb;
    GameManager gameManager;
  
    
    //Dash Mechinice
    [SerializeField] float dashSpeed;

    float dashTime;
    [SerializeField] float startDashTime,timeBetweenDash;
    [HideInInspector]public bool canDash, isDashing, isMoving;


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            // transform.Translate(Vector2.right * speed * Time.fixedDeltaTime, Space.Self);
            Movement();
            
        }
        if (isMoving)
        {
            
            rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.D) && canDash)
        {
            isMoving = false;
            isDashing = true;
            canDash = false;
            Debug.Log(canDash);
            rb.gravityScale = 0;
        }
        DashMechanice();

        

    }

    void Movement() 
    {
        isMoving = true;
        gameManager.playerIsMoving = true;
        StartCoroutine(AllowDashInSec());
    }
    private void FixedUpdate()
    {

        /*if (isMoving)
        {
            rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
        }
        DashMechanice();*/

    }
    void DashMechanice()
    {
        

        if (dashTime <= 0)
        {
            dashTime = startDashTime;
            isMoving = true;
            isDashing = false;
            StartCoroutine(AllowDashInSec());
            rb.gravityScale = 3;

        }
        else if(isDashing)
        {
            rb.AddForce(Vector2.right * dashSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            dashTime -= Time.deltaTime;

        }

    }

    IEnumerator AllowDashInSec()
    {
        yield return new WaitForSeconds(timeBetweenDash);//1
        canDash = true;
        Debug.Log(canDash);

    }
}
