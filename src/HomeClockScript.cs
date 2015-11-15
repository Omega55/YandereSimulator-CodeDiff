using System;
using UnityEngine;

[Serializable]
public class HomeClockScript : MonoBehaviour
{
	public UILabel HourLabel;

	public UILabel DayLabel;

	public virtual void Start()
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
		if (PlayerPrefs.GetInt("Night") == 1)
		{
			this.HourLabel.text = "8:00 PM";
		}
		else if (PlayerPrefs.GetInt("Late") == 1)
		{
			this.HourLabel.text = "7:30 AM";
		}
		else
		{
			this.HourLabel.text = "6:30 AM";
		}
	}

	public virtual void Main()
	{
	}
}
