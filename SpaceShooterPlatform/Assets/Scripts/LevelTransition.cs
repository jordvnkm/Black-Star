using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelTransition : MonoBehaviour {
	public int levelToLoad;
	public GameObject transitionUI;
	public GameObject gameUI;
	public GameObject pauseUI;

	// References
	private GameMasterScript gameMaster;


	void Start()
	{
		gameMaster = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMasterScript> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			gameMaster.setNotificationText("Press [E] to move to the next level");
			if(Input.GetKeyDown("e"))
			{
				transitionUI.SetActive (true);
				transitionUI.GetComponent<LevelCompletion>().setUIActive();
				gameUI.SetActive(false);
				pauseUI.SetActive(false);
				Time.timeScale = 0;
				//Application.LoadLevel(levelToLoad);
			}
		}
	}


	void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) 
		{
			if(Input.GetKeyDown("e"))
			{
				transitionUI.SetActive (true);
				transitionUI.GetComponent<LevelCompletion>().setUIActive();
				gameUI.SetActive(false);
				pauseUI.SetActive(false);
				Time.timeScale = 0;
				//Application.LoadLevel(levelToLoad);
			}
		}	
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			gameMaster.setNotificationText("");
		}
	}
}