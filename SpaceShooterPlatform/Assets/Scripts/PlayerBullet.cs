﻿using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

	// References to components and other game objects
	private Player player;
	private Rigidbody2D rb2d;

	// Internal game logic
	public float velocity;
	public int damage;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		rb2d = GetComponent<Rigidbody2D> ();

		// Check to see the direction of the player
		// Flip the direction and move according to the direction
		if (player.transform.localScale.x < 0) {
			velocity = -velocity;
			transform.localScale = new Vector3(-1, 1, 1);
		}
	}


	void FixedUpdate()
	{
		// Move the bullet
		rb2d.AddForce (Vector2.right * velocity);
	}
}
