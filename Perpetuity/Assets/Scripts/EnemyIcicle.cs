using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIcicle : MonoBehaviour {

    Rigidbody2D rigidB;

    Vector2 playerPos;

    Vector2 pos;

    public GameObject icicle;

    public float speed;

    GameObject currentIcicle;

    Vector2 direction;

    bool awake;

    // Use this for initialization
    void Start () {
        rigidB = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        awake = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (awake)
        {
            playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            pos = gameObject.transform.position;

            if (currentIcicle == null)
            {
                currentIcicle = Instantiate(icicle, this.gameObject.transform.GetChild(0).transform.position, this.transform.rotation);
            }

            if (Mathf.Abs(Vector2.Distance(playerPos, pos)) > 10)
            {
                rigidB.AddForce(playerPos - pos);
            }

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
