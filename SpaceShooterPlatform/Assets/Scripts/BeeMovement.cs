using UnityEngine;
using System.Collections;

public class BeeMovement : MonoBehaviour {
	
	public float flyingSpeed;
	public float chaseSpeed;
	private float currentSpeed;
	private bool attacking;

	private Rigidbody2D rb2d;
	private Animator anim;
	private Player hero;

	// Specific Movement Logic
	private int movementRange; // How long the bee will move from the initial position
	// How far they will move, once reached, it will random decided to switch direction or not
	private float positionRange; 

	public int damage = 25;



	// Use this for initialization
	void Start () {
		currentSpeed = flyingSpeed;
		attacking = false;

		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = new Vector2 (currentSpeed, 0);
		anim = GetComponent<Animator> ();
		hero = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();

		movementRange = 10;
		positionRange = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		checkLocalScale ();
		checkRange ();
		checkForPlayer ();
	}
	

	public void flipDirection()
	{
		if (this.transform.localScale.x > 0) {
			this.transform.localScale = new Vector3 (-1, 1, 1);
			reverseSpeed ();
		} else {
			this.transform.localScale = new Vector3 (1, 1, 1);
			reverseSpeed ();
		}
	}


	private void reverseSpeed(){
		rb2d.velocity = Vector2.zero;

		flyingSpeed = -flyingSpeed;
		chaseSpeed = -chaseSpeed;
		currentSpeed = -currentSpeed;

		rb2d.velocity = new Vector2 (currentSpeed, 0);
	}


	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag ("Ground") || other.gameObject.CompareTag("Enemy")) {
			this.flipDirection ();
		}
		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.GetComponent<PlayerHealth> ().takeDamage (damage);
		} else if (other.gameObject.CompareTag ("Enemy")) {
			flipDirection ();
		} else if (other.gameObject.CompareTag ("EnemyBullet")) {
			Destroy (other.gameObject);
		}
	}

	// Will determine the patrol logic for the bee
	private void checkRange(){
		if (Mathf.Abs (this.transform.position.x - positionRange) > movementRange) {
			if(Random.value >= 0.5) {
				flipDirection ();
			}
			positionRange = this.transform.position.x;
		}
	}

	public void checkForPlayer() {
		if (Mathf.Abs (this.transform.position.x - hero.transform.position.x) < movementRange) {
			positionRange = this.transform.position.x;
			currentSpeed = chaseSpeed;
			attacking = true;
			anim.SetTrigger("Chasing");
			checkDirection();
		} else {
			currentSpeed = flyingSpeed;
			attacking = false;
			anim.SetTrigger("Flying");
		}
	}

	private void checkDirection() {
		if (this.transform.localScale.x > 0 && (hero.transform.position.x > this.transform.position.x)) {
			flipDirection ();
		} else if (this.transform.localScale.x < 0 && (hero.transform.position.x < this.transform.position.x)) {
			flipDirection ();
		}
	}


	public float getCurrentSpeed(){
		return currentSpeed;
	}

	public void setCurrentSpeed(float speed){
		currentSpeed = speed;
		rb2d.velocity = Vector2.right * currentSpeed;
	}


	public void checkLocalScale(){
		if (this.transform.localScale.x > 0 && this.currentSpeed > 0) {
			this.transform.localScale = new Vector3 (-1, 1, 1);
		} else if (this.transform.localScale.x < 0 && this.currentSpeed < 0) {
			this.transform.localScale = new Vector3 (1, 1, 1);
		}
	}

}
