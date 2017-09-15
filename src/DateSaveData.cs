using System;

[Serializable]
public class DateSaveData
{
	public int week;

	public int weekday;

	public DateSaveData()
	{
		this.week = 0;
		this.weekday = 0;
	}

	public static DateSaveData ReadFromGlobals()
	{
		return new DateSaveData
		{
			week = DateGlobals.Week,
			weekday = DateGlobals.Weekday
		};
	}

	public static void WriteToGlobals(DateSaveData data)
	{
		DateGlobals.Week = data.week;
		DateGlobals.Weekday = data.weekday;
	}
}
