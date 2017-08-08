using System;
using UnityEngine;

[Serializable]
public class DayEventTime : IScheduledEventTime
{
	[SerializeField]
	private int week;

	[SerializeField]
	private DayOfWeek weekday;

	public DayEventTime(int week, DayOfWeek weekday)
	{
		this.week = week;
		this.weekday = weekday;
	}

	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Day;
		}
	}

	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week && currentTime.Weekday == this.weekday;
	}

	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday < this.weekday;
		}
		return currentTime.Week < this.week;
	}

	public bool OccurredInThePast(DateAndTime currentTime)
	{
		if (currentTime.Week == this.week)
		{
			return currentTime.Weekday > this.weekday;
		}
		return currentTime.Week > this.week;
	}
}
