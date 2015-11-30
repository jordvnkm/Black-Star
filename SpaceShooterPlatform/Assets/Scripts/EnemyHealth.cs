using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	
	public int maxHealth;
	public int currentHealth;
	private GameMasterScript gameMaster;

	// Use this for initialization
	void Start () 
	{
		currentHealth = maxHealth;
		gameMaster = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMasterScript> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentHealth <= 0) {
			Destroy(this.gameObject);
			gameMaster.increment (200);
		}
	}

	public void takeDamage(int amount)
	{
		currentHealth -= amount;
	}
}
