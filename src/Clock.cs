using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Clock
{
	[SerializeField]
	private int hours;

	[SerializeField]
	private int minutes;

	[SerializeField]
	private int seconds;

	[SerializeField]
	private float currentSecond;

	private static readonly Dictionary<TimeOfDay, string> TimeOfDayStrings = new Dictionary<TimeOfDay, string>
	{
		{
			TimeOfDay.Midnight,
			"Midnight"
		},
		{
			TimeOfDay.EarlyMorning,
			"Early Morning"
		},
		{
			TimeOfDay.Morning,
			"Morning"
		},
		{
			TimeOfDay.LateMorning,
			"Late Morning"
		},
		{
			TimeOfDay.Noon,
			"Noon"
		},
		{
			TimeOfDay.Afternoon,
			"Afternoon"
		},
		{
			TimeOfDay.Evening,
			"Evening"
		},
		{
			TimeOfDay.Night,
			"Night"
		}
	};

	public Clock(int hours, int minutes, int seconds)
	{
		this.hours = hours;
		this.minutes = minutes;
		this.seconds = seconds;
		this.currentSecond = 0f;
	}

	public Clock() : this(0, 0, 0)
	{
	}

	public int Hours24
	{
		get
		{
			return this.hours;
		}
	}

	public int Hours12
	{
		get
		{
			int num = this.hours % 12;
			return (num != 0) ? num : 12;
		}
	}

	public int Minutes
	{
		get
		{
			return this.minutes;
		}
	}

	public int Seconds
	{
		get
		{
			return this.seconds;
		}
	}

	public float CurrentSecond
	{
		get
		{
			return this.currentSecond;
		}
	}

	public int TotalSeconds
	{
		get
		{
			return this.hours * 3600 + this.minutes * 60 + this.seconds;
		}
	}

	public float PreciseTotalSeconds
	{
		get
		{
			return (float)this.TotalSeconds + this.currentSecond;
		}
	}

	public bool IsAM
	{
		get
		{
			return this.hours < 12;
		}
	}

	public TimeOfDay TimeOfDay
	{
		get
		{
			if (this.hours < 3)
			{
				return TimeOfDay.Midnight;
			}
			if (this.hours < 6)
			{
				return TimeOfDay.EarlyMorning;
			}
			if (this.hours < 9)
			{
				return TimeOfDay.Morning;
			}
			if (this.hours < 12)
			{
				return TimeOfDay.LateMorning;
			}
			if (this.hours < 15)
			{
				return TimeOfDay.Noon;
			}
			if (this.hours < 18)
			{
				return TimeOfDay.Afternoon;
			}
			if (this.hours < 21)
			{
				return TimeOfDay.Evening;
			}
			return TimeOfDay.Night;
		}
	}

	public string TimeOfDayString
	{
		get
		{
			return Clock.TimeOfDayStrings[this.TimeOfDay];
		}
	}

	public bool IsBefore(Clock clock)
	{
		return this.TotalSeconds < clock.TotalSeconds;
	}

	public bool IsAfter(Clock clock)
	{
		return this.TotalSeconds > clock.TotalSeconds;
	}

	public void IncrementHour()
	{
		this.hours++;
		if (this.hours == 24)
		{
			this.hours = 0;
		}
	}

	public void IncrementMinute()
	{
		this.minutes++;
		if (this.minutes == 60)
		{
			this.IncrementHour();
			this.minutes = 0;
		}
	}

	public void IncrementSecond()
	{
		this.seconds++;
		if (this.seconds == 60)
		{
			this.IncrementMinute();
			this.seconds = 0;
		}
	}

	public void Tick(float dt)
	{
		this.currentSecond += dt;
		while (this.currentSecond >= 1f)
		{
			this.IncrementSecond();
			this.currentSecond -= 1f;
		}
	}
}
