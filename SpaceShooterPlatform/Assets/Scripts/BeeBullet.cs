using UnityEngine;
using System.Collections;

public class BeeBullet : MonoBehaviour {

	public int damage = 10;
	public int velocity = -9;
	private Rigidbody2D rb2d;

	private void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = new Vector2 (0, velocity);
	}

	
	private void OnCollisionEnter2D(Collision2D other) {
		Destroy (this.gameObject);
		if (other.gameObject.CompareTag ("Player")) {
			PlayerHealth heroHealth = other.gameObject.GetComponent<PlayerHealth>();
			heroHealth.takeDamage(damage);
		}
	}
}
