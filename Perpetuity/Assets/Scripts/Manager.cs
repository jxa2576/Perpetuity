using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public GameObject icicleEnemy;

    List<GameObject> icicles;

    public GameObject snowballEnemy;

    List<GameObject> snowballs;

    public GameObject boss;

    Collider2D valveCollider;

    Collider2D playerCollider;

    bool spawn;

	// Use this for initialization
	void Start () {
        valveCollider = gameObject.transform.GetChild(0).gameObject.GetComponent<Collider2D>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();

        spawn = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (valveCollider.IsTouching(playerCollider))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (spawn)
                {
                    EnemySpawn();
                    spawn = false;
                }
            }
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void EnemySpawn()
    {

    }
}
