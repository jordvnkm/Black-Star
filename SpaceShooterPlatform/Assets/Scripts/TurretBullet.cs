using UnityEngine;
using System.Collections;

public class TurretBullet : MonoBehaviour {

	private Rigidbody2D rb2d;
	
	public float velocity; 
	public int damage;
	public int range;
	private float position;
	

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		position = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		checkRange ();
	}

	void FixedUpdate() {
		rb2d.AddForce (Vector2.right * velocity);
	}


	private void checkRange() {
		if (Mathf.Abs (position - transform.position.x) > range) {
			Destroy(this.gameObject);
		}
	}


	public void OnCollisionEnter2D(Collision2D other) {
		string tag = other.gameObject.tag;
		if (tag == "Player") {
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			player.GetComponent<PlayerHealth>().takeDamage(damage);
			GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMasterScript>().resetMutliplier();
			Destroy (this.gameObject);
		}
	}
}
