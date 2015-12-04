using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {
	

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();
			player.takeDamage(player.currentHealth);
		}
	}
}