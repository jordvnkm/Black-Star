using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public int startingHealth = 100;
	public int currentHealth;
	public Text healthText;
	public Text deathText;

	private Animator anim;
	private bool isDead;
	private bool damaged;
	private Player player;

	private float timeStart;
	private float timeThresh;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		player = GetComponent<Player> ();

		currentHealth = startingHealth;

		healthText.text = "" + currentHealth;
		damaged = false;
		isDead = false;

		timeThresh = 2f;
	}
	
	// Update is called once per frame
	void Update () {
		// invulnerability timer
		if (damaged && (Time.time - timeStart) > timeThresh) {
			damaged = false;
		}
	}

	public void takeDamage(int amount)
	{
		if (!damaged) {
			damaged = true;

			currentHealth -= amount;

			healthText.text = "" + Mathf.Max (currentHealth, 0);

			if (currentHealth <= 0 && !isDead) {
				death ();
			}

			timeStart = Time.time;
		}
	}


	public void death()
	{
		isDead = true;
		player.canMove = false;
		deathText.text = "\tYou Died!\nFinal Score: " + player.getGameMaster ().getPoints ();
		anim.SetTrigger ("Die");
		Time.timeScale = 0;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		string tag = other.gameObject.tag;
		if (tag == "HealthRecovery") {
			currentHealth = Mathf.Min (startingHealth, currentHealth + 10);
			healthText.text = currentHealth.ToString ();
			Destroy (other.gameObject);
		} else if (tag == "HealthBoost") {
			startingHealth += 25;
			currentHealth = startingHealth;
			healthText.text = currentHealth.ToString();
			Destroy (other.gameObject);

			GameMasterScript gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMasterScript>();
			gm.setNotificationText("Health Increased!", 3f);

		}
	}
}
