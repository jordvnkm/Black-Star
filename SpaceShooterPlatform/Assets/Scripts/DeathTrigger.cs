using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {
	

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			Player player = other.gameObject.GetComponent<Player>();
			player.health = 0f;
		}
	}
}