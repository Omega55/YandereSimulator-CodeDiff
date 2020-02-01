using System;
using UnityEngine;

public class DateReverseScript : MonoBehaviour
{
	public AudioSource MyAudio;

	public string[] MonthName;

	public string Prefix;

	public UILabel Label;

	public AudioClip Finish;

	public float TimeLimit;

	public float LifeTime;

	public float Timer;

	public int Month;

	public int Year;

	public int Day;

	private void Start()
	{
		Time.timeScale = 1f;
	}

	private void Update()
	{
		this.LifeTime += Time.deltaTime;
		this.Timer += Time.deltaTime * 2f;
		if (this.Timer > this.TimeLimit)
		{
			if (this.LifeTime < 10f)
			{
				if (this.TimeLimit > Time.deltaTime)
				{
					this.TimeLimit *= 0.9f;
				}
			}
			else
			{
				this.TimeLimit *= 1.1f;
				if (this.TimeLimit >= 1f)
				{
					this.MyAudio.clip = this.Finish;
					this.Label.color = new Color(1f, 0f, 0f, 1f);
					base.enabled = false;
				}
			}
			this.Timer = 0f;
			this.Day--;
			if (this.Day == 0)
			{
				this.Day = 28;
				this.Month--;
				if (this.Month == 0)
				{
					this.Month = 12;
					this.Year--;
				}
			}
			if (this.Day == 1 || this.Day == 21)
			{
				this.Prefix = "st";
			}
			else if (this.Day == 2 || this.Day == 22)
			{
				this.Prefix = "nd";
			}
			else if (this.Day == 3 || this.Day == 23)
			{
				this.Prefix = "rd";
			}
			else
			{
				this.Prefix = "th";
			}
			this.Label.text = string.Concat(new object[]
			{
				this.MonthName[this.Month],
				" ",
				this.Day,
				this.Prefix,
				", ",
				this.Year
			});
			this.MyAudio.Play();
		}
	}
}
