using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
	
	public GameObject bullet;
	public float fireRate = 0f;

	private float timeToFire = 0;
	private float delta;

	// Use this for initialization
	void Start () {
		delta = 2.5f;
	}
	
	// Update is called once per frame
	void Update () {
		delta = calculateDelta();

		if (fireRate == 0 && Input.GetButtonDown ("Fire1")) {
			Instantiate (bullet, new Vector3(transform.position.x + delta, transform.position.y, 0)
			             , Quaternion.identity);
		} else if (Input.GetButtonDown ("Fire1") && Time.time > timeToFire) {
			timeToFire = Time.time + 1 / fireRate;
			Instantiate (bullet, new Vector3(transform.position.x + delta, transform.position.y, 0)
			             , Quaternion.identity);
		}
	}


	public float calculateDelta()
	{
		if(transform.localScale.x < 0)
			return -2.5f;
		return 2.5f;
	}
}
