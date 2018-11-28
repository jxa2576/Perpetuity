using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Vector2 pos;
    Vector2 startPos;
    Vector2 dir;

    public float speed;

	// Use this for initialization
	void Start () {
        pos = transform.position;
        startPos = transform.position;
        dir = transform.right;
        //Debug.Log(dir);

        dir.Normalize();
        
	}
	
	// Update is called once per frame
	void Update () {
        pos += dir * speed;
        transform.position = pos;
        if(Mathf.Abs(Vector2.Distance(startPos,pos)) > 10)
        {
            Destroy(this.gameObject);
        }
	}
}
