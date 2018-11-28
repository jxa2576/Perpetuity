using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAntlers : MonoBehaviour {

    Rigidbody2D rigidB;

    Vector2 pos;

    Vector2 playerPos;

    public float speed;

    public float jump;

    bool awake;

    // Use this for initialization
    void Start () {
        rigidB = GetComponent<Rigidbody2D>();
        pos = gameObject.transform.position;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        awake = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (awake)
        {
            pos = gameObject.transform.position;
            playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

            Vector2 direction = playerPos - pos;
            direction.Normalize();

            rigidB.AddForce(direction * speed);
        }
        else
        {
            playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            pos = gameObject.transform.position;

            if (Mathf.Abs(Vector2.Distance(playerPos, gameObject.transform.position)) < 15)
            {
                awake = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
