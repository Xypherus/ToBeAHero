using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : Character {

    public float groundAdditional = .1f;

    bool canMove;

    Rigidbody2D rb;
    float distanceToGround;

	// Use this for initialization
	void Start () {
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        distanceToGround = GetComponent<Collider2D>().bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(canMove)
        {
            //Jump Code
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Boing");
                if (IsGrounded())
                {
                    Debug.Log("Boing2");
                    rb.AddForce(new Vector2(0, jumpHeight));
                }
            }
        }
	}

    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector3.up, distanceToGround + .1f);
    }

    private void FixedUpdate()
    {
        if(canMove)
        {
            //Translation based Movement
            Vector3 movementVector = new Vector3(moveSpeed * Input.GetAxisRaw("Horizontal"), 0f, 0f);
            transform.Translate(movementVector, Space.World);

            //Force Based Movement
            //rb.AddForce(movementVector);

            
        }
    }
}
