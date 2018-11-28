using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBeam : MonoBehaviour {

    Vector2 pos;

    Vector2 playerPos;

    // Use this for initialization
    void Start () {
        pos = gameObject.transform.position;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        pos = gameObject.transform.position;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        if (pos.x > playerPos.x)
        {
            //left
            pos += Vector2.left;
            gameObject.transform.position = pos;
        }
        else
        {
            //right
            pos -= Vector2.left;
            gameObject.transform.position = pos;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
