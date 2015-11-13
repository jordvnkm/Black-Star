using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
	
	public GameObject bullet;

	private float delta;

	// Use this for initialization
	void Start () {
		delta = 2.5f;
	}
	
	// Update is called once per frame
	void Update () {
		delta = calculateDelta();

		if (Input.GetButtonDown ("Fire1")) {
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
