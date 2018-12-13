using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAntlers : MonoBehaviour {

    Rigidbody2D rigidB;

    Vector2 pos;

    Vector2 playerPos;

    public float speed;

    public float jump;

    public GameObject beam;

    GameObject beamAttack;

    bool awake;

    SpriteRenderer spriteRend;
    public Sprite[] spriteList;

    int animationCount = 0;
    int frame = 0;

    // Use this for initialization
    void Start () {
        rigidB = GetComponent<Rigidbody2D>();
        pos = gameObject.transform.position;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        spriteRend = GetComponent<SpriteRenderer>();
        awake = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (awake)
        {
            pos = gameObject.transform.position;
            playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

            Vector2 direction = playerPos - pos;
            direction.y = 0;
            direction.Normalize();

            rigidB.AddForce(direction * speed);

            attack();
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

        if(animationCount == 12)
        {
            if(frame == 0)
            {
                frame = 1;
                spriteRend.sprite = spriteList[frame];
            }
            else
            {
                frame = 0;
                spriteRend.sprite = spriteList[frame];
            }
            animationCount = 0;
        }
        animationCount++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if(beamAttack != null)
            {
                Destroy(beamAttack);
            }
            Destroy(gameObject);
        }
    }

    void attack()
    {
        float rand = Random.Range(0.0f, 100.0f);

        if(rand > 98)
        {
            if(beamAttack == null)
            {
                beamAttack = Instantiate(beam, this.gameObject.transform.GetChild(0).transform.position, Quaternion.identity);
            }
        }
    }
}
