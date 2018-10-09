using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //Pos
    public Vector2 pos;
    public Vector2 velocity;
    public Vector2 acceleration;
    public float maxSpeed;
    public float aRate;
    public float deacceleration;

    public bool gravity = true;

    public Vector2 gravVelocity;
    public Vector2 gravAccel;

    public Vector2 jumpVelocity;
    public Vector2 jumpAccel;

    public GameObject ground;

    public Collider2D playerCol;
    public Collider2D groundCol;

    public GameObject shoulder;

    // Use this for initialization
    void Start () {
        pos = this.transform.position;
        playerCol = GetComponent<Collider2D>();
        ground = GameObject.Find("Ground");
        groundCol = ground.GetComponent<Collider2D>();
        shoulder = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        UpdatePosition();
        RotateShoulder();
    }

    void UpdatePosition()
    {
        //movement keys
        if (Input.GetKey(KeyCode.D))
        {
            Vector2 dir = new Vector2(1, 0);
            acceleration = aRate * dir;
            velocity += acceleration;
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
            pos += velocity;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Vector2 dir = new Vector2(-1, 0);
            acceleration = aRate * dir;
            velocity += acceleration;
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
            pos += velocity;
        }
        else
        {
            if (acceleration.x > 0.0001 || acceleration.x < -0.0001 || acceleration.y > 0.0001 || acceleration.y < -0.0001)
            {
                DeAccel();
            }
            else
            {
                acceleration = new Vector3(0, 0, 0);
                velocity = new Vector3(0, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Vector2 dir = new Vector2(0, 1);
            jumpAccel = 0.1f * dir;
            jumpVelocity += jumpAccel;
            jumpVelocity = Vector3.ClampMagnitude(jumpVelocity, maxSpeed);
            pos += jumpVelocity;
            gravity = true;
        }
        else
        {
            if (jumpAccel.y > 0.01)
            {
                JumpDeAccel();
            }
            else
            {
                //gravity = true;
                jumpAccel = new Vector3(0, 0, 0);
                jumpVelocity = new Vector3(0, 0, 0);
            }
        }

        if (playerCol.bounds.Intersects(groundCol.bounds))
        {
            acceleration = new Vector3(0, 0, 0);
            velocity = new Vector3(0, 0, 0);
            Vector2 tempPos = new Vector2(pos.x, ((0.0f + ground.transform.position.y) + (groundCol.bounds.size.y/2 + playerCol.bounds.size.y/2)));
            pos = tempPos;
            gravAccel = new Vector2(0,0);
            gravVelocity = new Vector2(0, 0);
            gravity = false;
        }

        if (gravity)
        {
            Gravity();
        }

        transform.position = new Vector2(pos.x, pos.y);
    }

    private void DeAccel()
    {
        acceleration = acceleration * deacceleration;
        velocity = velocity * deacceleration;
        pos += velocity;
    }

    private void JumpDeAccel()
    {
        jumpAccel = jumpAccel * .8f;
        jumpVelocity = jumpVelocity * .8f;
        pos += velocity;
    }

    private void Gravity()
    {
        Vector2 dir = new Vector2(0, -1);
        gravAccel = 0.01f * dir;
        gravVelocity += gravAccel;
        pos += gravVelocity;
    }

    void RotateShoulder()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shoulderPos = new Vector2(shoulder.transform.position.x, shoulder.transform.position.y);

        Vector2 mouseShoulderVec = shoulderPos - mousePos;
        Debug.Log(mouseShoulderVec);

        float angle = Mathf.Atan2(mouseShoulderVec.x, mouseShoulderVec.y);

        angle = Mathf.Rad2Deg * angle + 90;
        shoulder.transform.rotation = Quaternion.Euler(0, 0, -angle);

        Debug.Log(angle);
    }
}
