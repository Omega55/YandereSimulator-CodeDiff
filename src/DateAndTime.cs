using System;
using UnityEngine;

[Serializable]
public class DateAndTime
{
	[SerializeField]
	private int week;

	[SerializeField]
	private DayOfWeek weekday;

	[SerializeField]
	private Clock clock;

	public DateAndTime(int week, DayOfWeek weekday, Clock clock)
	{
		this.week = week;
		this.weekday = weekday;
		this.clock = clock;
	}

	public int Week
	{
		get
		{
			return this.week;
		}
	}

	public DayOfWeek Weekday
	{
		get
		{
			return this.weekday;
		}
	}

	public Clock Clock
	{
		get
		{
			return this.clock;
		}
	}

	public int TotalSeconds
	{
		get
		{
			int num = this.week * 604800;
			int num2 = (int)(this.weekday * (DayOfWeek)86400);
			int totalSeconds = this.clock.TotalSeconds;
			return num + num2 + totalSeconds;
		}
	}

	public void IncrementWeek()
	{
		this.week++;
	}

	public void IncrementWeekday()
	{
		int num = (int)this.weekday;
		num++;
		if (num == 7)
		{
			this.IncrementWeek();
			num = 0;
		}
		this.weekday = (DayOfWeek)num;
	}

	public void Tick(float dt)
	{
		int hours = this.clock.Hours24;
		this.clock.Tick(dt);
		if (this.clock.Hours24 < hours)
		{
			this.IncrementWeekday();
		}
	}
}
