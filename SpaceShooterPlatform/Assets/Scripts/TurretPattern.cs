using UnityEngine;
using System.Collections;

public class TurretPattern : MonoBehaviour {

	public int range;

	private float startTime;
	private float timeToFire;
	public float fireDelay;

	private Player player;
	public GameObject turretBullet;

	// Use this for initialization
	void Start () 
	{
		startTime = Time.time;
		timeToFire = startTime + fireDelay;

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();

		if (player == null) {
			Debug.Log("Player was not found");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		startTime += Time.deltaTime;
		if (startTime > timeToFire) 
		{
			float distanceY = Mathf.Pow((transform.position.y - player.transform.position.y), 2);
			float distanceX = Mathf.Pow((transform.position.x - player.transform.position.x), 2);
			
			if (Mathf.Sqrt(distanceX + distanceY) < range) 
			{
				startTime = Time.time;
				timeToFire = startTime + fireDelay;

				Debug.Log ("Player in range, firing");
			}
		}
	}
}
