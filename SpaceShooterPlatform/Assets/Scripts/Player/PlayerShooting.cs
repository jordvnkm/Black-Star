using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		playerHealth = GetComponent<PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			playerHealth.takeDamage(25);
		
		}
	}
}
