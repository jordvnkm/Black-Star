using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;

    private bool paused = false;

	public Button resumeButton;
	public Button restartButton;
	public Button mainMenuButton;
	public Button quitButton;

    void Start()
    {
        PauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;

        }

        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
		
    }

	public void resumeButtonPressed()
	{
		paused = !paused;
	}



	public void restartButtonPressed()
	{
		Application.LoadLevel (Application.loadedLevel);
	}


	public void mainMenuButtonPressed()
	{
		Application.LoadLevel (1);
	}


	public void quitButtonPressed()
	{
		Application.Quit();
	}
}
