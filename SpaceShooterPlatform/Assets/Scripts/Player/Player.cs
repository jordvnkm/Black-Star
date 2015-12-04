using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    
    //floats
    public float maxSpeed;
    public float speed;
    public float jumpPower;

    //bools
    public bool canDoubleJump;
    public bool grounded;
	public bool canMove;
	public bool canTakeDamage;

    //references
    private Rigidbody2D rb2d;
    private Animator anim;
	private GameMasterScript gameMaster;

	// knockback
	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public float invulnerableCount;
	public bool knockbackFromRight;



	//speed powerup
	public float speedupCount;

	//jumpboost
	public float jumpboostCount;

	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
		maxSpeed = 10;
		speed = 200;
		jumpPower = 1300;
		canTakeDamage = true;
	
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
		if (speedupCount <= 0) {
			maxSpeed = 10;
			speed = 200;
		}
		if (jumpboostCount <= 0) {
			jumpPower = 1300;
		}
		if (invulnerableCount <= 0) {
			canTakeDamage = true;
			gameObject.layer = 8;
		}

		Vector3 easeVelocity = rb2d.velocity;
		easeVelocity.y = rb2d.velocity.y;
		easeVelocity.z = 0.0f;
		easeVelocity.x *= 0.75f;

		//fake friction/ easing the x speed of player
		if (grounded) {
			rb2d.velocity = easeVelocity;
		}

		float h = Input.GetAxis("Horizontal");

        //moving player
		if (canMove && (knockbackCount <= 0)) {

			rb2d.AddForce ((Vector2.right * speed) * h);
		} else if (canMove && canTakeDamage) {
			if (knockbackFromRight) {
				rb2d.velocity = new Vector2 (-knockback, knockback);
			}
			if (!knockbackFromRight) {
				rb2d.velocity = new Vector2 (knockback, knockback);
			}
			//invulnerableCount = 100;
			canTakeDamage = false;

		}

        // limiting speed of player
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

		// countdowns
		if (speedupCount > 0) {
			speedupCount -= Time.deltaTime;
		}
		if (jumpboostCount > 0) {
			jumpboostCount -= Time.deltaTime;
		}
		if (invulnerableCount > 0) {
			invulnerableCount -= Time.deltaTime;
		}
		if (knockbackCount > 0) {
			knockbackCount -= Time.deltaTime;
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
			maxSpeed += 15;
			speed += 100f;
			gameMaster.setNotificationText("Speed Increased!", 3f);
			speedupCount = 5;
		}
		if (other.CompareTag("JumpBoost"))
		{
			Destroy (other.gameObject);
			jumpPower += 100f;
			gameMaster.setNotificationText("Jump Increased!", 3f);
			jumpboostCount = 5;
		}
	}
}
