using UnityEngine;
using System.Collections;

public class EnemyWallCheck : MonoBehaviour {

	private CrawlerMovement cm;

	// Use this for initialization
	void Start () 
	{
		cm = GetComponentInParent<CrawlerMovement> ();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Ground")) {
			cm.flipDirection();
		}
	}
}
