using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	
	public int maxHealth;
	private int currentHealth;
	public GameObject recovery;
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
			createRecovery();
			Destroy(this.gameObject);
			gameMaster.increment (200);
		}
	}

	public void takeDamage(int amount)
	{
		currentHealth -= amount;
	}

	private void createRecovery()
	{
		if (Random.value >= 0.5) {
			Instantiate(recovery, this.transform.position, Quaternion.identity);
		}
	}
}
