using System;
using UnityEngine;

public class DateChaser : MonoBehaviour
{
	public int CurrentDate;

	public string CurrentTimeString;

	[Header("Epoch timestamps")]
	[SerializeField]
	private int startDate = 1581724799;

	[SerializeField]
	private int endDate = 1421366399;

	[Space(5f)]
	[Header("Settings")]
	[SerializeField]
	private float generalDuration = 10f;

	[SerializeField]
	private AnimationCurve curve;

	public bool Animate;

	private float startTime;

	private string[] monthNames = new string[]
	{
		"January",
		"February",
		"March",
		"April",
		"May",
		"June",
		"July",
		"August",
		"September",
		"October",
		"November",
		"December"
	};

	private int lastFrameDay;

	private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	public UILabel Label;

	public float Timer;

	public int Stage;

	private static DateTime fromUnix(long unix)
	{
		return DateChaser.epoch.AddSeconds((double)unix);
	}

	private void Start()
	{
		Application.targetFrameRate = 60;
		Time.timeScale = 1f;
	}

	private void Update()
	{
		if (this.Animate)
		{
			float num = Time.time - this.startTime;
			this.CurrentDate = (int)Mathf.Lerp((float)this.startDate, (float)this.endDate, this.curve.Evaluate(num / this.generalDuration));
			DateTime dateTime = DateChaser.fromUnix((long)this.CurrentDate);
			string text = (dateTime.Day != 22 && dateTime.Day != 2) ? ((dateTime.Day != 3) ? ((dateTime.Day != 1) ? "th" : "st") : "rd") : "nd";
			this.CurrentTimeString = string.Format("{0} {1}{2}, {3}", new object[]
			{
				this.monthNames[dateTime.Month - 1],
				dateTime.Day,
				text,
				dateTime.Year
			});
			if (this.lastFrameDay != dateTime.Day)
			{
				this.onDayTick(dateTime.Day);
			}
			this.lastFrameDay = dateTime.Day;
			this.Timer += Time.deltaTime;
		}
		else
		{
			this.startTime = Time.time;
			this.CurrentDate = this.startDate;
		}
	}

	private void onDayTick(int day)
	{
		this.Label.text = this.CurrentTimeString;
	}
}
