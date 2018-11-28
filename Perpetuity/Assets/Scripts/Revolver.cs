using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : MonoBehaviour {

    public GameObject bullet;

    //GameObject crosshair;

	// Use this for initialization
	void Start () {
        //crosshair = gameObject.transform.GetChild(1).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        Shoot();
	}

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Shoot");
            Instantiate(bullet, this.transform.GetChild(0).gameObject.transform.position, this.transform.rotation);
        }
    }
}
