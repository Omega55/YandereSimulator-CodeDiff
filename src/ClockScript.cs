using System;
using UnityEngine;

[Serializable]
public class ClockScript : MonoBehaviour
{
	public Transform MinuteHand;

	public Transform HourHand;

	public UILabel TimeLabel;

	public UILabel TimeOfDayLabel;

	public bool StopTime;

	private string MinuteNumber;

	private string HourNumber;

	public float Minute;

	public float Hour;

	public float StartHour;

	public float StartMinute;

	public string TimeOfDay;

	public string AMPM;

	public float TimeSpeed;

	public int Phase;

	public ClockScript()
	{
		this.MinuteNumber = string.Empty;
		this.HourNumber = string.Empty;
		this.TimeOfDay = string.Empty;
		this.AMPM = string.Empty;
	}

	public virtual void Start()
	{
		this.Hour = this.StartHour * (float)5;
		this.Minute = this.StartMinute * (float)5;
		float z = (float)360 - this.Hour * (float)6;
		Vector3 localEulerAngles = this.HourHand.localEulerAngles;
		float num = localEulerAngles.z = z;
		Vector3 vector = this.HourHand.localEulerAngles = localEulerAngles;
		float z2 = (float)360 - this.Minute * (float)6;
		Vector3 localEulerAngles2 = this.MinuteHand.localEulerAngles;
		float num2 = localEulerAngles2.z = z2;
		Vector3 vector2 = this.MinuteHand.localEulerAngles = localEulerAngles2;
		this.TimeOfDayLabel.text = this.TimeOfDay;
	}

	public virtual void Update()
	{
		if (!this.StopTime)
		{
			this.Hour += Time.deltaTime / (float)12 * 0.01666667f * this.TimeSpeed;
			this.Minute += Time.deltaTime * 0.01666667f * this.TimeSpeed;
			if (this.Minute > (float)60)
			{
				this.Minute -= (float)60;
			}
			if (this.Hour > (float)60)
			{
				this.Hour -= (float)60;
			}
			float z = (float)360 - this.Minute * (float)6;
			Vector3 localEulerAngles = this.MinuteHand.localEulerAngles;
			float num = localEulerAngles.z = z;
			Vector3 vector = this.MinuteHand.localEulerAngles = localEulerAngles;
			float z2 = (float)360 - this.Hour * (float)6;
			Vector3 localEulerAngles2 = this.HourHand.localEulerAngles;
			float num2 = localEulerAngles2.z = z2;
			Vector3 vector2 = this.HourHand.localEulerAngles = localEulerAngles2;
			if (Mathf.Floor(this.Hour / (float)5) < (float)1)
			{
				this.HourNumber = "12";
			}
			else
			{
				this.HourNumber = string.Empty + Mathf.Floor(this.Hour / (float)5);
			}
			if (this.Minute < (float)10)
			{
				this.MinuteNumber = "0" + Mathf.Floor(this.Minute);
			}
			else
			{
				this.MinuteNumber = string.Empty + Mathf.Floor(this.Minute);
			}
			this.TimeLabel.text = this.HourNumber + ":" + this.MinuteNumber + " " + this.AMPM;
		}
	}

	public virtual void Main()
	{
	}
}
