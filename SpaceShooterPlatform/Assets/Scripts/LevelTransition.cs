using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelTransition : MonoBehaviour {
	public int levelToLoad;

	// References
	private GameMasterScript gameMaster;


	void Start()
	{
		gameMaster = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMasterScript> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			gameMaster.levelText.text = "Press [E] to move to the next level";
			if(Input.GetKeyDown("e"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}


	void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) 
		{
			if(Input.GetKeyDown("e"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}	
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			gameMaster.levelText.text = "";
		}
	}
}