using System;
using UnityEngine;

public class HomeClockScript : MonoBehaviour
{
	public UILabel HourLabel;

	public UILabel DayLabel;

	private void Start()
	{
		if (PlayerPrefs.GetInt("Weekday") == 1)
		{
			this.DayLabel.text = "MONDAY";
		}
		else if (PlayerPrefs.GetInt("Weekday") == 2)
		{
			this.DayLabel.text = "TUESDAY";
		}
		else if (PlayerPrefs.GetInt("Weekday") == 3)
		{
			this.DayLabel.text = "WEDNESDAY";
		}
		else if (PlayerPrefs.GetInt("Weekday") == 4)
		{
			this.DayLabel.text = "THURSDAY";
		}
		else if (PlayerPrefs.GetInt("Weekday") == 5)
		{
			this.DayLabel.text = "FRIDAY";
		}
		if (Globals.Night)
		{
			this.HourLabel.text = "8:00 PM";
		}
		else
		{
			this.HourLabel.text = ((!Globals.LateForSchool) ? "6:30 AM" : "7:30 AM");
		}
	}
}
