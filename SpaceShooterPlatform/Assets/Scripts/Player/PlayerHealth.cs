using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public int startingHealth = 100;
	public int currentHealth;
	public Text healthText;


	private Animator anim;
	private bool isDead;
	private bool damaged;
	private Player player;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		player = GetComponent<Player> ();

		currentHealth = startingHealth;

		healthText.text = "" + currentHealth;
		damaged = false;
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		damaged = false;
	}

	public void takeDamage(int amount)
	{
		damaged = true;

		currentHealth -= amount;

		healthText.text = "" + Mathf.Max(currentHealth, 0 );

		if (currentHealth <= 0 && !isDead) {
			death();
		}
	}


	public void death()
	{
		isDead = true;
		player.canMove = false;
		anim.SetTrigger ("Die");
		Time.timeScale = 0;
	}
}
