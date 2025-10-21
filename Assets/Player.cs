using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 3000;
    public float jumpForce = 300;
    public Rigidbody2D rigidbody2;
    public SpriteRenderer spriteRenderer;
    public GroundChecker GroundChecker; 
    public bool isJump = false;
    public float moveInput;






    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
                {
            isJump = true;
        }
    }

        private void FixedUpdate()
    {
        rigidbody2.velocity = new Vector2(moveInput *
            moveSpeed *
            Time.fixedDeltaTime,
           rigidbody2.velocity.y);
        if (isJump && GroundChecker.isGrounded)
        {
            rigidbody2.AddForce(Vector2.up * jumpForce);
            isJump = false; 

        }


    }


}

