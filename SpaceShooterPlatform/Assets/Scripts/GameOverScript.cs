using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	private Animator anim;
	private Player hero;

	public float restartDelay = 5f;
	private float restartTimer;


	void Awake()
	{
		anim = GetComponent<Animator> ();
		hero = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
	}


	void Update()
	{
		if (hero.health <= 0f) {
			anim.SetTrigger ("GameOver");
			Time.timeScale = 0;

			restartTimer += Time.deltaTime;

			if(restartTimer >= restartDelay)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
