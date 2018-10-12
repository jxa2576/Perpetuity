using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public int speed;
    public int jumpSpeed;

    Rigidbody2D rigidB;

	// Use this for initialization
	void Start () {
        rigidB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        HorizontalMovement();
        Jump();
	}

    void HorizontalMovement()
    {
        float movement = 0;
        if (Input.GetKey(KeyCode.D))
        {
            movement = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement = -1;
        }

        Vector2 move = new Vector2(movement, 0);

        rigidB.AddForce(move * speed);
    }
    void Jump()
    {
        float jump = 0;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = 1;
        }

        Vector2 move = new Vector2(0, jump);

        rigidB.AddForce(move * jumpSpeed);
    }
}
