using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	private Animator anim;
	public PlayerHealth playerHealth;

	public float restartDelay = 5f;
	private float restartTimer;


	void Awake()
	{
		anim = GetComponent<Animator> ();
		playerHealth = playerHealth.GetComponent<PlayerHealth>();
	}


	void Update()
	{

		if (playerHealth.currentHealth <= 0f) {
			anim.SetTrigger ("GameOver");

			restartTimer += Time.deltaTime;

			if(restartTimer >= restartDelay)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
