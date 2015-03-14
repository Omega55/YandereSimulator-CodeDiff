using System;
using UnityEngine;

[Serializable]
public class ClockScript : MonoBehaviour
{
	private string MinuteNumber;

	private string HourNumber;

	public YandereScript Yandere;

	public PoliceScript Police;

	public Bloom BloomEffect;

	public ClockScript Clock;

	public MotionBlur Blur;

	public Transform PromptParent;

	public Transform MinuteHand;

	public Transform HourHand;

	public Transform Sun;

	public UILabel PeriodLabel;

	public UILabel TimeLabel;

	public UILabel DayLabel;

	public Light MainLight;

	public float HalfwayTime;

	public float PresentTime;

	public float TargetTime;

	public float StartTime;

	public float HourTime;

	public float StartHour;

	public float TimeSpeed;

	public float Minute;

	public float Hour;

	public int Period;

	public string TimeText;

	public bool StopTime;

	public bool TimeSkip;

	public AudioSource SchoolBell;

	public Color SkyboxColor;

	public ClockScript()
	{
		this.MinuteNumber = string.Empty;
		this.HourNumber = string.Empty;
		this.TimeText = string.Empty;
	}

	public virtual void Start()
	{
		this.PresentTime = this.StartHour * (float)60;
		this.UpdateWeekdayText(PlayerPrefs.GetInt("Weekday"));
		this.BloomEffect.bloomIntensity = (float)5;
		this.BloomEffect.bloomThreshhold = (float)0;
		this.MainLight.color = new Color((float)1, (float)1, (float)1, (float)1);
		RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f, (float)1);
		RenderSettings.skybox.SetColor("_Tint", new Color(0.5f, 0.5f, 0.5f));
	}

	public virtual void Update()
	{
		if (this.PresentTime < (float)1080)
		{
			this.BloomEffect.bloomIntensity = this.BloomEffect.bloomIntensity - Time.deltaTime * 4.75f;
			this.BloomEffect.bloomThreshhold = this.BloomEffect.bloomThreshhold + Time.deltaTime * 0.5f;
			if (this.BloomEffect.bloomThreshhold > 0.5f)
			{
				this.BloomEffect.bloomIntensity = 0.25f;
				this.BloomEffect.bloomThreshhold = 0.5f;
			}
		}
		else
		{
			this.StopTime = true;
			this.Police.FadeOut = true;
		}
		if (!this.StopTime)
		{
			this.PresentTime += Time.deltaTime * 0.01666667f * this.TimeSpeed;
			if (this.PresentTime > (float)1440)
			{
				this.PresentTime -= (float)1440;
			}
			this.HourTime = this.PresentTime / (float)60;
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
			float z = this.Minute * (float)6;
			Vector3 localEulerAngles = this.MinuteHand.localEulerAngles;
			float num = localEulerAngles.z = z;
			Vector3 vector = this.MinuteHand.localEulerAngles = localEulerAngles;
			float z2 = this.Hour * (float)30;
			Vector3 localEulerAngles2 = this.HourHand.localEulerAngles;
			float num2 = localEulerAngles2.z = z2;
			Vector3 vector2 = this.HourHand.localEulerAngles = localEulerAngles2;
			if (this.HourTime < 8.5f)
			{
				this.PeriodLabel.text = "Before School";
				if (this.Period < 1)
				{
					this.SchoolBell.Play();
					this.Period++;
				}
			}
			else if (this.HourTime < (float)13)
			{
				this.PeriodLabel.text = "Classtime";
				if (this.Period < 2)
				{
					this.SchoolBell.Play();
					this.Period++;
				}
			}
			else if (this.HourTime < 13.5f)
			{
				this.PeriodLabel.text = "Lunchtime";
				if (this.Period < 3)
				{
					this.SchoolBell.Play();
					this.Period++;
				}
			}
			else if (this.HourTime < 15.5f)
			{
				this.PeriodLabel.text = "Classtime";
				if (this.Period < 4)
				{
					this.SchoolBell.Play();
					this.Period++;
				}
			}
			else
			{
				this.PeriodLabel.text = "After School";
				if (this.Period < 5)
				{
					this.SchoolBell.Play();
					this.Period++;
				}
			}
		}
		float z3 = (float)-45 + (float)90 * (this.PresentTime - (float)420) / (float)660;
		Vector3 eulerAngles = this.Sun.eulerAngles;
		float num3 = eulerAngles.z = z3;
		Vector3 vector3 = this.Sun.eulerAngles = eulerAngles;
		if (this.PresentTime > (float)930)
		{
			float num4 = (this.PresentTime - (float)930) / (float)150;
			float r = (float)1 - 0.149019614f * num4;
			Color color = this.MainLight.color;
			float num5 = color.r = r;
			Color color2 = this.MainLight.color = color;
			float g = (float)1 - 0.403921574f * num4;
			Color color3 = this.MainLight.color;
			float num6 = color3.g = g;
			Color color4 = this.MainLight.color = color3;
			float b = (float)1 - 0.709803939f * num4;
			Color color5 = this.MainLight.color;
			float num7 = color5.b = b;
			Color color6 = this.MainLight.color = color5;
			float r2 = (float)1 - 0.149019614f * num4 - 0.25f * ((float)1 - num4);
			Color ambientLight = RenderSettings.ambientLight;
			float num8 = ambientLight.r = r2;
			Color color7 = RenderSettings.ambientLight = ambientLight;
			float g2 = (float)1 - 0.403921574f * num4 - 0.25f * ((float)1 - num4);
			Color ambientLight2 = RenderSettings.ambientLight;
			float num9 = ambientLight2.g = g2;
			Color color8 = RenderSettings.ambientLight = ambientLight2;
			float b2 = (float)1 - 0.709803939f * num4 - 0.25f * ((float)1 - num4);
			Color ambientLight3 = RenderSettings.ambientLight;
			float num10 = ambientLight3.b = b2;
			Color color9 = RenderSettings.ambientLight = ambientLight3;
			this.SkyboxColor.r = (float)1 - 0.149019614f * num4 - 0.5f * ((float)1 - num4);
			this.SkyboxColor.g = (float)1 - 0.403921574f * num4 - 0.5f * ((float)1 - num4);
			this.SkyboxColor.b = (float)1 - 0.709803939f * num4 - 0.5f * ((float)1 - num4);
			RenderSettings.skybox.SetColor("_Tint", new Color(this.SkyboxColor.r, this.SkyboxColor.g, this.SkyboxColor.b));
		}
		if (this.TimeSkip)
		{
			if (this.HalfwayTime == (float)0)
			{
				this.HalfwayTime = this.PresentTime + (this.TargetTime - this.PresentTime) * 0.5f;
				this.Yandere.Hearts.active = true;
				this.Yandere.Phone.active = true;
				this.Yandere.TimeSkipping = true;
				this.Yandere.CanMove = false;
				this.Blur.enabled = true;
				if (this.Yandere.Armed)
				{
					this.Yandere.Unequip();
				}
			}
			if (this.PresentTime < this.TargetTime - (float)10)
			{
				if (Time.timeScale < (float)100)
				{
					Time.timeScale += (float)1;
				}
			}
			else if (this.PresentTime < this.HalfwayTime)
			{
				Time.timeScale += (float)1;
			}
			else
			{
				Time.timeScale = Mathf.Lerp(Time.timeScale, (float)1, 0.01666667f);
			}
			this.Yandere.Character.animation["f02_timeSkip_00"].speed = (float)1 / Time.timeScale;
			this.Blur.blurAmount = 0.92f * (Time.timeScale / (float)100);
			if (this.PresentTime > this.TargetTime)
			{
				this.EndTimeSkip();
			}
			if (Input.GetButtonDown("Start"))
			{
				this.EndTimeSkip();
			}
		}
		if (Input.GetKeyDown("backspace"))
		{
			Time.timeScale = (float)1;
			this.PresentTime = (float)1080;
			this.HourTime = this.PresentTime / (float)60;
		}
	}

	public virtual void EndTimeSkip()
	{
		Debug.Log("I was told to stop.");
		this.PromptParent.localScale = new Vector3((float)1, (float)1, (float)1);
		this.Yandere.Hearts.active = false;
		this.Yandere.Phone.active = false;
		this.Yandere.TimeSkipping = false;
		this.Yandere.CanMove = true;
		this.Blur.enabled = false;
		Time.timeScale = (float)1;
		this.TimeSkip = false;
		this.HalfwayTime = (float)0;
	}

	public virtual void UpdateWeekdayText(int Weekday)
	{
		if (Weekday == 1)
		{
			this.DayLabel.text = "Monday";
		}
		if (Weekday == 2)
		{
			this.DayLabel.text = "Tuesday";
		}
		if (Weekday == 3)
		{
			this.DayLabel.text = "Wednesday";
		}
		if (Weekday == 4)
		{
			this.DayLabel.text = "Thursday";
		}
		if (Weekday == 5)
		{
			this.DayLabel.text = "Friday";
		}
	}

	public virtual void Main()
	{
	}
}
