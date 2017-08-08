using System;
using UnityEngine;

[Serializable]
public class WeekEventTime : IScheduledEventTime
{
	[SerializeField]
	private int week;

	public WeekEventTime(int week)
	{
		this.week = week;
	}

	public ScheduledEventTimeType ScheduleType
	{
		get
		{
			return ScheduledEventTimeType.Week;
		}
	}

	public bool OccurringNow(DateAndTime currentTime)
	{
		return currentTime.Week == this.week;
	}

	public bool OccursInTheFuture(DateAndTime currentTime)
	{
		return currentTime.Week < this.week;
	}

	public bool OccurredInThePast(DateAndTime currentTime)
	{
		return currentTime.Week > this.week;
	}
}
