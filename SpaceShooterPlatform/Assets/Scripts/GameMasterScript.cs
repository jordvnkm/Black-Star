using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMasterScript : MonoBehaviour {

	// Different UI Text
	public Text pointsText;
	public Text notificationText;
	public Text multiplierText;


	// Used to increase the score
	private int points;
	private float multiplier;

	// Used to reset the multiplier and notification text
	private float multResetTimer;
	private float multResetThresh;
	
	private float notficationResetTimer;
	private float notificationResetThresh;



	void Start()
	{
		points = 0;
		multiplier = 1.00f;

		multResetTimer = Time.time;
		multResetThresh = 7f;

		notificationResetThresh = 0f;
		//notificationResetThresh = 6f;
	}


	void Update() 
	{
		// Update the score and multiplier
		pointsText.text = ("Score:  " + points);
		multiplierText.text = ("Multiplier: x" + multiplier);

		// Check to see if the multiplier should reset
		if (Time.time - multResetTimer >= multResetThresh) 
		{
			multResetTimer = Time.time;
			multiplier = 1.00f;
		}

		// Check if there is a notification display and reset when time has passed
		if (notificationText.text != "" &&  notificationResetThresh > 0f && 
		    (Time.time - notficationResetTimer) >= notificationResetThresh) 
		{
			notificationText.text = "";
			notificationResetThresh = 0f;
		}
	}


	public void increment(int inc)
	{
		points += (int)(multiplier * inc);
		multiplier += 0.05f;
		multResetTimer = Time.time;
	}


	public void setNotificationText(string message)
	{
		notificationText.text = message;
	}

	public void setNotificationText(string message, float time)
	{
		notficationResetTimer = Time.time;
		notificationResetThresh = time;
		notificationText.text = message;
	}


	public void resetMutliplier()
	{
		multiplier = 1f;
	}


	public int getPoints()
	{
		return points;
	}

}
