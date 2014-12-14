using System;
using UnityEngine;

[Serializable]
public class ClockScript : MonoBehaviour
{
	private string MinuteNumber;

	private string HourNumber;

	public Bloom BloomEffect;

	public Transform MinuteHand;

	public Transform HourHand;

	public UILabel PeriodLabel;

	public UILabel TimeLabel;

	public UILabel DayLabel;

	public float PresentTime;

	public float StartHour;

	public float TimeSpeed;

	public float Minute;

	public float Hour;

	public string TimeText;

	public bool StopTime;

	public ClockScript()
	{
		this.MinuteNumber = string.Empty;
		this.HourNumber = string.Empty;
		this.TimeText = string.Empty;
	}

	public virtual void Start()
	{
		this.PresentTime = this.StartHour * (float)60;
		if (PlayerPrefs.GetString("Day") == string.Empty)
		{
			PlayerPrefs.SetString("Day", "Monday");
		}
		this.DayLabel.text = PlayerPrefs.GetString("Day");
		this.BloomEffect.bloomIntensity = (float)5;
		this.BloomEffect.bloomThreshhold = (float)0;
	}

	public virtual void Update()
	{
		if (this.PresentTime < (float)1080)
		{
			this.BloomEffect.bloomIntensity = this.BloomEffect.bloomIntensity - Time.deltaTime * 4.5f;
			this.BloomEffect.bloomThreshhold = this.BloomEffect.bloomThreshhold + Time.deltaTime / (float)2;
			if (this.BloomEffect.bloomThreshhold > 0.5f)
			{
				this.BloomEffect.bloomIntensity = 0.5f;
				this.BloomEffect.bloomThreshhold = 0.5f;
			}
		}
		else
		{
			this.StopTime = true;
			this.BloomEffect.bloomIntensity = this.BloomEffect.bloomIntensity + Time.deltaTime * 4.5f;
			this.BloomEffect.bloomThreshhold = this.BloomEffect.bloomThreshhold - Time.deltaTime / (float)2;
			if (this.BloomEffect.bloomThreshhold < (float)0)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		if (!this.StopTime)
		{
			this.PresentTime += Time.deltaTime * 0.01666667f * this.TimeSpeed;
			if (this.PresentTime > (float)1440)
			{
				this.PresentTime -= (float)1440;
			}
			this.Hour = Mathf.Floor(this.PresentTime / (float)60);
			this.Minute = Mathf.Floor((this.PresentTime / (float)60 - this.Hour) * (float)60);
			if (this.Hour == (float)0 || this.Hour == (float)12)
			{
				this.HourNumber = "12";
			}
			else if (this.Hour < (float)12)
			{
				this.HourNumber = string.Empty + this.Hour;
			}
			else
			{
				this.HourNumber = string.Empty + (this.Hour - (float)12);
			}
			if (this.Minute < (float)10)
			{
				this.MinuteNumber = "0" + this.Minute;
			}
			else
			{
				this.MinuteNumber = string.Empty + this.Minute;
			}
			if (this.Hour < (float)12)
			{
				this.TimeText = this.HourNumber + ":" + this.MinuteNumber + " AM";
			}
			else
			{
				this.TimeText = this.HourNumber + ":" + this.MinuteNumber + " PM";
			}
			this.TimeLabel.text = this.TimeText;
			if (this.PresentTime / (float)60 < 8.5f)
			{
				this.PeriodLabel.text = "Before School";
			}
			else if (this.PresentTime / (float)60 < (float)13)
			{
				this.PeriodLabel.text = "Classtime";
			}
			else if (this.PresentTime / (float)60 < 13.5f)
			{
				this.PeriodLabel.text = "Lunchtime";
			}
			else if (this.PresentTime / (float)60 < 15.5f)
			{
				this.PeriodLabel.text = "Classtime";
			}
			else
			{
				this.PeriodLabel.text = "After School";
			}
			float z = this.Minute * (float)6;
			Vector3 localEulerAngles = this.MinuteHand.localEulerAngles;
			float num = localEulerAngles.z = z;
			Vector3 vector = this.MinuteHand.localEulerAngles = localEulerAngles;
			float z2 = this.Hour * (float)30;
			Vector3 localEulerAngles2 = this.HourHand.localEulerAngles;
			float num2 = localEulerAngles2.z = z2;
			Vector3 vector2 = this.HourHand.localEulerAngles = localEulerAngles2;
		}
	}

	public virtual void Main()
	{
	}
}
