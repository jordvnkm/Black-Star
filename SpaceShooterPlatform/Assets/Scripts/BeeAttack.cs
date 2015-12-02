using UnityEngine;
using System.Collections;

public class BeeAttack : MonoBehaviour {

	private Transform shootPoint;
	private GameObject hero;
	private BeeMovement bm;
	private Animator anim;
	public GameObject bullet;

	private float speed;

	private float timeStart;
	private float timeThresh;

	// Use this for initialization
	void Start () {
		shootPoint = transform.GetChild (0);
		hero = GameObject.FindGameObjectWithTag ("Player");
		bm = GetComponent<BeeMovement> ();
		anim = GetComponent<Animator> ();

		speed = bm.getCurrentSpeed ();

		timeStart = Time.time;
		timeThresh = 3f;
	}
	
	// Update is called once per frame
	void Update () {
		int thisX = (int)this.transform.position.x;
		int heroX = (int)hero.transform.position.x;

		Debug.Log ("Time Start: " + timeStart.ToString () + " Current Time: " + Time.time.ToString ());
		if (thisX == heroX) {
			Debug.Log ("Player and Bee in the same position");
		}

		if(thisX == heroX && (Time.time - timeStart > timeThresh)){
			anim.SetBool ("firing", true);
			timeStart = Time.time;
		}
	}


	public void stop(){
		speed = bm.getCurrentSpeed ();
		bm.setCurrentSpeed (0);
	}

	public void move(){
		bm.setCurrentSpeed (speed);
		bm.checkForPlayer ();
	}


	public void attack(){
		Instantiate (bullet, shootPoint.position, Quaternion.identity);
		anim.SetBool ("firing", false);
	}
}
