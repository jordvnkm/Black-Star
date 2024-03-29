﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    
    //floats
    public float maxSpeed = 10;
    public float speed = 100f;
    public float jumpPower = 300f;

    //bools
    public bool canDoubleJump;
    public bool grounded;
	public bool canMove;

    //references
    private Rigidbody2D rb2d;
    private Animator anim;
	private GameMasterScript gameMaster;

	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
	
		gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMasterScript>();
		canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

		if (Input.GetAxis("Horizontal") < -0.1f && canMove)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

		if (Input.GetAxis("Horizontal") > 0.1f && canMove)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded && canMove)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                canDoubleJump = false;
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                rb2d.AddForce(Vector2.up * jumpPower);
            }
        }


    }

    void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f ;
        easeVelocity.x *= 0.75f;

        float h = Input.GetAxis("Horizontal");

        //fake friction/ easing the x speed of player
        if (grounded)
        {
            rb2d.velocity = easeVelocity;
        }


        //moving player
		if(canMove)
        	rb2d.AddForce((Vector2.right * speed) * h);

        // limiting speed of player
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

    }



	public GameMasterScript getGameMaster()
	{
		return gameMaster;
	}



	// Create triggers with collectibles
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Coin")) 
		{
			Destroy (other.gameObject);
			gameMaster.increment(100);
		}

		if (other.CompareTag ("SpeedUp")) 
		{
			Destroy(other.gameObject);
			maxSpeed += 10;
			speed += 25f;
			gameMaster.setNotificationText("Speed Increased!", 3f);
		}
		if (other.CompareTag("JumpBoost"))
		{
			Destroy (other.gameObject);
			jumpPower += 100f;
			gameMaster.setNotificationText("Jump Increased!", 3f);
		}
	}
}
