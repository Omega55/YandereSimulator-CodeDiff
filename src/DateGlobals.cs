using System;
using UnityEngine;

public static class DateGlobals
{
	private const string Str_Week = "Week";

	private const string Str_Weekday = "Weekday";

	public static int Week
	{
		get
		{
			return PlayerPrefs.GetInt("Week");
		}
		set
		{
			PlayerPrefs.SetInt("Week", value);
		}
	}

	public static DayOfWeek Weekday
	{
		get
		{
			return GlobalsHelper.GetEnum<DayOfWeek>("Weekday");
		}
		set
		{
			GlobalsHelper.SetEnum<DayOfWeek>("Weekday", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("Week");
		Globals.Delete("Weekday");
	}
}
