using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelCompletion : MonoBehaviour {

	// Reference for UI objects
	private Transform levelTransition;
	public Text completionText;
	

	// Use this for initialization
	void Start () {
		levelTransition = transform.FindChild ("LevelTransitionUI");
		completionText.text = "\tLevel Complete\nFinal Score: ";
		levelTransition.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void restartButtonPressed()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	public void nextLevelButtonPressed()
	{
		Application.LoadLevel (GameObject.FindGameObjectWithTag ("Exit").GetComponent<LevelTransition> ().levelToLoad);
	}

	public void setUIActive()
	{
		GameMasterScript gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMasterScript> ();
		completionText.text = "Level Complete!\nFinal Score: " + gm.getPoints ().ToString ();
		foreach(Transform child in transform)
		{
			child.gameObject.SetActive(true);
		}
	}
}
