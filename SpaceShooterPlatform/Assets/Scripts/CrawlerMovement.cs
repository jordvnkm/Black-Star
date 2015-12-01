using UnityEngine;
using System.Collections;

public class CrawlerMovement : MonoBehaviour {
	
	public float walkingSpeed = -300f;
	public float attackSpeed = -600f;
	public int damage = 25;
	public int range = 20;

	private float currentSpeed;
	private float maxSpeed;

	private bool attacking;

	private Rigidbody2D rb2d;
	private Animator anim;
	private GameObject hero;

	// Use this for initialization
	void Start () 
	{
		currentSpeed = walkingSpeed;
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		attacking = false;
		hero = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () 
	{
		checkRange ();

		if(attacking)
			attackPlayer ();
	}
	
	void FixedUpdate()
	{
		rb2d.velocity = Vector2.right * currentSpeed;
		//rb2d.AddForce (Vector2.right * currentSpeed);
	}


	public void flipDirection()
	{
		if (this.transform.localScale.x < 0) {
			this.transform.localScale = new Vector3 (1, 1, 1);
			reverseSpeed();
		} else {
			this.transform.localScale = new Vector3 (-1, 1, 1);
			reverseSpeed();
		}
	}

	public void reverseSpeed()
	{
		rb2d.velocity = Vector2.zero;

		walkingSpeed = -walkingSpeed;
		attackSpeed = -attackSpeed;
		currentSpeed = -currentSpeed;
	}

	public float getCurrentSpeed()
	{
		return currentSpeed;
	}


	public void checkRange()
	{
		if (isInRange (this.range))
			attacking = true;
		else {
			attacking = false;
			currentSpeed = walkingSpeed;
			anim.SetTrigger ("Walking");
		}
	}


	public bool isInRange(int range)
	{
		return (this.transform.position - hero.transform.position).magnitude < range;
	}


	public void attackPlayer ()
	{
		currentSpeed = attackSpeed;
		anim.SetTrigger ("Running");
		if (this.transform.localScale.x > 0 && (hero.transform.position.x > this.transform.position.x)) {
			flipDirection ();
		} else if (this.transform.localScale.x < 0 && (hero.transform.position.x < this.transform.position.x)) {
			flipDirection ();
		}
	}


	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			hero.GetComponent<PlayerHealth> ().takeDamage (damage);
		} else if (other.gameObject.CompareTag ("Enemy")) {
			flipDirection ();
		} else if (other.gameObject.CompareTag ("EnemyBullet")) {
			Destroy (other.gameObject);
		}
	}

}
