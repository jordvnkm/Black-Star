using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuScript : MonoBehaviour {
		
	public Canvas mainMenuCanvas;
	public Button playButton;
	public Button exitButton;

	// Use this for initialization
	void Start () 
	{
		mainMenuCanvas = GetComponent<Canvas> ();
		playButton = GetComponent<Button> ();
		exitButton = GetComponent<Button> ();
	}


	public void playButtonPressed()
	{
		Application.LoadLevel (0);
	}

	public void exitButtonPressed()
	{
		Application.Quit ();
	}

}
