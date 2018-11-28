using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {



    GameObject shoulder;

    GameObject arm;

    GameObject revolver;

    //GameObject crosshair;

    // Use this for initialization
    void Start () {
        shoulder = transform.GetChild(0).gameObject;
        arm = shoulder.transform.GetChild(0).gameObject;
        revolver = arm.transform.GetChild(0).gameObject;
        //crosshair = revolver.transform.GetChild(1).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        RotateShoulder();
    }

    void RotateShoulder()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shoulderPos = new Vector2(shoulder.transform.position.x, shoulder.transform.position.y);

        Vector2 mouseShoulderVec = shoulderPos - mousePos;

        float angle = Mathf.Atan2(mouseShoulderVec.x, mouseShoulderVec.y);

        angle = Mathf.Rad2Deg * angle + 90;
        shoulder.transform.rotation = Quaternion.Euler(0, 0, -angle);
    }
}
