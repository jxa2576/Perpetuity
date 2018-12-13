using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour {

    Vector2 pos;

    Vector2 startPos;

    Vector2 direction;

    Vector2 playerPos;

    public float speed;

    // Use this for initialization
    void Start () {
        startPos = this.transform.position;
        pos = this.transform.position;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        pos = this.transform.position;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        direction = playerPos - pos;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.x, direction.y);

        angle = Mathf.Rad2Deg * angle + 90;
        this.transform.rotation = Quaternion.Euler(0, 0, -angle);

        if (Mathf.Abs(Vector2.Distance(startPos, pos)) > 15)
        {
            Destroy(this.gameObject);
        }

        icicleTravel();
    }

    public void icicleTravel()
    {
        Vector2 pos = this.transform.position;

        pos += direction * speed;
        this.transform.position = pos;

        if (Mathf.Abs(Vector2.Distance(gameObject.transform.position, pos)) > 10)
        {
            Destroy(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
