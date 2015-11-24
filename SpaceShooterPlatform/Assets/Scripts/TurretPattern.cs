using UnityEngine;
using System.Collections;

public class TurretPattern : MonoBehaviour {

	public int range;
	private float startTime;
	private float timeToFire;
	public float fireDelay;

	private Player player;
	private Transform currentShoot;
	public GameObject bullet;

	// Use this for initialization
	void Start () 
	{
		startTime = Time.time;
		timeToFire = startTime + fireDelay;

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();

		currentShoot = transform.GetChild (0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		checkDirection ();

		startTime += Time.deltaTime;
		if (startTime > timeToFire) {
			float distanceY = Mathf.Pow((transform.position.y - player.transform.position.y), 2);
			float distanceX = Mathf.Pow((transform.position.x - player.transform.position.x), 2);
			
			if (Mathf.Sqrt(distanceX + distanceY) < range) {
				fireBullet();
			}
		}
	}

	// Flip the sprite when the player is on either side 
	// Flip the velocity of the bullet as well
	private void checkDirection()
	{
		if (player.transform.position.x > this.transform.position.x) {
			this.transform.localScale = new Vector3 (-1, 1, 1);
			bullet.GetComponent<TurretBullet> ().velocity = Mathf.Abs (bullet.GetComponent<TurretBullet> ().velocity);
		} else {
			this.transform.localScale = new Vector3 (1, 1, 1);
			bullet.GetComponent<TurretBullet> ().velocity = -1 * Mathf.Abs(bullet.GetComponent<TurretBullet> ().velocity);
		}
	}


	private void fireBullet() {
		startTime = Time.time;
		timeToFire = startTime + fireDelay;

		Instantiate (bullet, currentShoot.transform.position, Quaternion.identity);
	}

}
