using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpControl : MonoBehaviour
{
    [SerializeField] float jumpHeight;
    private Rigidbody2D rb;
    public LayerMask groundLayer;
    public GameObject[] groundCheckGameObject;
    public float radius;
    [SerializeField] private bool Grounded;
     public float jumpTimer;
     public float jumpDelay = .25f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Grounded = Physics2D.OverlapCircle(groundCheckGameObject[0].transform.position, radius, groundLayer);
        Grounded = Physics2D.OverlapCircle(groundCheckGameObject[1].transform.position, radius, groundLayer);
        Grounded = Physics2D.OverlapCircle(groundCheckGameObject[2].transform.position, radius, groundLayer);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpTimer = Time.time + jumpDelay;
        }
    }
    private void FixedUpdate()
    {
        if (jumpTimer > Time.time && Grounded)
        {
            Jump();
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpHeight*Time.fixedDeltaTime, ForceMode2D.Impulse);
        jumpTimer = 0;
    }
}
