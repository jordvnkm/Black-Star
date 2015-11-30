using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

	// References to components and other game objects
	private Player player;
	private Rigidbody2D rb2d;

	// Internal game logic
	public float velocity = 15;
	public int damage = 25;
	public int range = 20;
	private float position;



	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		rb2d = GetComponent<Rigidbody2D> ();

		Debug.Log ("Damage: " + damage);

		position = transform.position.x;
		// Check to see the direction of the player
		// Flip the direction and move according to the direction	
		if (player.transform.localScale.x < 0) {
			velocity = -velocity;
			transform.localScale = new Vector3(-1, 1, 1);
		}
	}


	void Update()
	{
		checkRange ();
	}



	void FixedUpdate()
	{
		// Move the bullet
		rb2d.AddForce (Vector2.right * velocity);
	}


	private void checkRange()
	{
		if (Mathf.Abs (position - transform.position.x) > range) {
			Destroy(this.gameObject);
		}
	}


	public void OnCollisionEnter2D(Collision2D other)
	{
		string tag = other.gameObject.tag;

		if (tag == "Ground") 
		{
			Destroy(this.gameObject);
		}
		else if (tag == "Enemy") 
		{
			EnemyHealth enemy = other.gameObject.GetComponent<EnemyHealth>();
			enemy.takeDamage(damage);
			Destroy (this.gameObject);
		}
	}
}
