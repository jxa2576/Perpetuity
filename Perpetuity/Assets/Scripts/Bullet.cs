using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Vector2 pos;

    Vector2 dir;

	// Use this for initialization
	void Start () {
        pos = transform.position;

        dir = transform.right * 5;
        Debug.Log(dir);

        dir.Normalize();
        
	}
	
	// Update is called once per frame
	void Update () {
        pos += dir * 0.1f;
        transform.position = pos;
	}
}
