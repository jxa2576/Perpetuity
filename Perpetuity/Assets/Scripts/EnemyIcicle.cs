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
                direction = playerPos - pos;
                direction.Normalize();

                float angle = Mathf.Atan2(direction.x, direction.y);

                angle = Mathf.Rad2Deg * angle + 90;
                currentIcicle.transform.rotation = Quaternion.Euler(0, 0, -angle);
            }

            if (Mathf.Abs(Vector2.Distance(playerPos, pos)) > 10)
            {
                rigidB.AddForce(playerPos - pos);
            }

            icicleTravel();
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
            if(currentIcicle != null)
            {
                Destroy(currentIcicle);
            }
            Destroy(gameObject);
        }
    }

    public void icicleTravel()
    {
        if(currentIcicle != null)
        {
            Vector2 pos = currentIcicle.transform.position;

            pos += direction * speed;
            currentIcicle.transform.position = pos;

            if (Mathf.Abs(Vector2.Distance(gameObject.transform.position, pos)) > 10)
            {
                Destroy(currentIcicle);
            }
        }
    }
}
