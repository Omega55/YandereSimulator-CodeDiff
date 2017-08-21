using System;
using UnityEngine;

public class HomeClockScript : MonoBehaviour
{
	public UILabel HourLabel;

	public UILabel DayLabel;

	private void Start()
	{
		if (Globals.Weekday == 1)
		{
			this.DayLabel.text = "MONDAY";
		}
		else if (Globals.Weekday == 2)
		{
			this.DayLabel.text = "TUESDAY";
		}
		else if (Globals.Weekday == 3)
		{
			this.DayLabel.text = "WEDNESDAY";
		}
		else if (Globals.Weekday == 4)
		{
			this.DayLabel.text = "THURSDAY";
		}
		else if (Globals.Weekday == 5)
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
