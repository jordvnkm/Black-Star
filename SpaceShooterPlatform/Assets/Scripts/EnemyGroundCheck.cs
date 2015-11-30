using UnityEngine;
using System.Collections;

public class EnemyGroundCheck : MonoBehaviour {

	private CrawlerMovement cm;

	// Use this for initialization
	void Start () {
		cm = GetComponentInParent<CrawlerMovement> ();
	}


	void Update()
	{
		if (!Physics2D.Linecast (cm.transform.position, this.transform.position, 1 << LayerMask.NameToLayer ("Ground"))) {
			cm.flipDirection();
		}
	}

}