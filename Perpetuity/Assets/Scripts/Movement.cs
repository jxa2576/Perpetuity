using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public int speed;
    public int jumpSpeed;

    Rigidbody2D rigidB;

    SpriteRenderer spriteRend;

    public Sprite[] spriteList;

    int count = 0;

    int animationCount = 0;

    GameObject shoulder;

    bool idle = true;

    int idleAnimationCount = 0;

    // Use this for initialization
    void Start () {
        rigidB = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        shoulder = transform.GetChild(0).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        HorizontalMovement();
        Jump();
	}

    private void FixedUpdate()
    {
        if (animationCount == 6)
        {
            if (idle == true)
            {
                if(idleAnimationCount == 6)
                {
                    count++;
                    if (count > 1)
                    {
                        count = 0;
                    }
                    spriteRend.sprite = spriteList[count];
                    idleAnimationCount = 0;
                }
                idleAnimationCount++;
            }
            else
            {
                count++;
                if (count > 9)
                {
                    count = 4;
                }
                Debug.Log(count);
                spriteRend.sprite = spriteList[count];
            }

            animationCount = 0;
        }
        animationCount++;
    }

    void UpdateShoulder(int currentSpriteCount)
    {
        
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
        
        if (movement == 0)
        {
            idle = true;
        }
        else
        {
            idle = false;
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
