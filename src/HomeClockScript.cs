using System;
using UnityEngine;

public class HomeClockScript : MonoBehaviour
{
	public UILabel HourLabel;

	public UILabel DayLabel;

	private void Start()
	{
		if (DateGlobals.Weekday == 1)
		{
			this.DayLabel.text = "MONDAY";
		}
		else if (DateGlobals.Weekday == 2)
		{
			this.DayLabel.text = "TUESDAY";
		}
		else if (DateGlobals.Weekday == 3)
		{
			this.DayLabel.text = "WEDNESDAY";
		}
		else if (DateGlobals.Weekday == 4)
		{
			this.DayLabel.text = "THURSDAY";
		}
		else if (DateGlobals.Weekday == 5)
		{
			this.DayLabel.text = "FRIDAY";
		}
		if (HomeGlobals.Night)
		{
			this.HourLabel.text = "8:00 PM";
		}
		else
		{
			this.HourLabel.text = ((!HomeGlobals.LateForSchool) ? "6:30 AM" : "7:30 AM");
		}
	}
}
