using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ClockScript : MonoBehaviour
{
	private string MinuteNumber;

	private string HourNumber;

	public Collider[] TrespassZones;

	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public PoliceScript Police;

	public Bloom BloomEffect;

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

	public float AmbientLightDim;

	public float DayProgress;

	public float StartHour;

	public float TimeSpeed;

	public float Minute;

	public float Hour;

	public int Period;

	public int ID;

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
		if (PlayerPrefs.GetInt("Weekday") == 0)
		{
			PlayerPrefs.SetInt("Weekday", 1);
		}
		this.UpdateWeekdayText(PlayerPrefs.GetInt("Weekday"));
		this.BloomEffect.bloomIntensity = (float)10;
		this.BloomEffect.bloomThreshhold = (float)0;
		this.MainLight.color = new Color((float)1, (float)1, (float)1, (float)1);
		RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f, (float)1);
		RenderSettings.skybox.SetColor("_Tint", new Color(0.5f, 0.5f, 0.5f));
	}

	public virtual void Update()
	{
		if (this.PresentTime < (float)1080)
		{
			this.BloomEffect.bloomIntensity = this.BloomEffect.bloomIntensity - Time.deltaTime * 9.75f;
			this.BloomEffect.bloomThreshhold = this.BloomEffect.bloomThreshhold + Time.deltaTime * 0.5f;
			if (this.BloomEffect.bloomThreshhold > 0.5f)
			{
				this.BloomEffect.bloomIntensity = 0.25f;
				this.BloomEffect.bloomThreshhold = 0.5f;
			}
		}
		else if (!this.Police.FadeOut && !this.Yandere.Attacking && !this.Yandere.Struggling)
		{
			this.Yandere.StudentManager.StopMoving();
			this.Police.Darkness.enabled = true;
			this.Police.FadeOut = true;
			this.StopTime = true;
		}
		if (!this.StopTime)
		{
			this.PresentTime += Time.deltaTime * 0.01666667f * this.TimeSpeed;
		}
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
			this.PeriodLabel.text = "BEFORE SCHOOL";
			if (this.Period < 1)
			{
				this.DeactivateTrespassZones();
				this.Period++;
			}
		}
		else if (this.HourTime < (float)13)
		{
			this.PeriodLabel.text = "CLASSTIME";
			if (this.Period < 2)
			{
				this.ActivateTrespassZones();
				this.Period++;
			}
		}
		else if (this.HourTime < 13.5f)
		{
			this.PeriodLabel.text = "LUNCHTIME";
			if (this.Period < 3)
			{
				this.DeactivateTrespassZones();
				this.Period++;
			}
		}
		else if (this.HourTime < 15.5f)
		{
			this.PeriodLabel.text = "CLASSTIME";
			if (this.Period < 4)
			{
				this.ActivateTrespassZones();
				this.Period++;
			}
		}
		else
		{
			this.PeriodLabel.text = "AFTER SCHOOL";
			if (this.Period < 5)
			{
				this.DeactivateTrespassZones();
				this.Period++;
			}
		}
		float z3 = (float)-45 + (float)90 * (this.PresentTime - (float)420) / (float)660;
		Vector3 eulerAngles = this.Sun.eulerAngles;
		float num3 = eulerAngles.z = z3;
		Vector3 vector3 = this.Sun.eulerAngles = eulerAngles;
		if ((this.Yandere.transform.position.y < (float)11 && this.Yandere.transform.position.x > (float)-30 && this.Yandere.transform.position.z > (float)-38 && this.Yandere.transform.position.x < (float)-22 && this.Yandere.transform.position.z < (float)-26) || (this.Yandere.transform.position.y < (float)11 && this.Yandere.transform.position.x > (float)22 && this.Yandere.transform.position.z > (float)-38 && this.Yandere.transform.position.x < (float)30 && this.Yandere.transform.position.z < (float)-26))
		{
			this.AmbientLightDim -= Time.deltaTime;
			if (this.AmbientLightDim < 0.1f)
			{
				this.AmbientLightDim = 0.1f;
			}
		}
		else
		{
			this.AmbientLightDim += Time.deltaTime;
			if (this.AmbientLightDim > 0.75f)
			{
				this.AmbientLightDim = 0.75f;
			}
		}
		if (this.PresentTime > (float)930)
		{
			this.DayProgress = (this.PresentTime - (float)930) / (float)150;
			float r = (float)1 - 0.149019614f * this.DayProgress;
			Color color = this.MainLight.color;
			float num4 = color.r = r;
			Color color2 = this.MainLight.color = color;
			float g = (float)1 - 0.403921574f * this.DayProgress;
			Color color3 = this.MainLight.color;
			float num5 = color3.g = g;
			Color color4 = this.MainLight.color = color3;
			float b = (float)1 - 0.709803939f * this.DayProgress;
			Color color5 = this.MainLight.color;
			float num6 = color5.b = b;
			Color color6 = this.MainLight.color = color5;
			float r2 = (float)1 - 0.149019614f * this.DayProgress - ((float)1 - this.AmbientLightDim) * ((float)1 - this.DayProgress);
			Color ambientLight = RenderSettings.ambientLight;
			float num7 = ambientLight.r = r2;
			Color color7 = RenderSettings.ambientLight = ambientLight;
			float g2 = (float)1 - 0.403921574f * this.DayProgress - ((float)1 - this.AmbientLightDim) * ((float)1 - this.DayProgress);
			Color ambientLight2 = RenderSettings.ambientLight;
			float num8 = ambientLight2.g = g2;
			Color color8 = RenderSettings.ambientLight = ambientLight2;
			float b2 = (float)1 - 0.709803939f * this.DayProgress - ((float)1 - this.AmbientLightDim) * ((float)1 - this.DayProgress);
			Color ambientLight3 = RenderSettings.ambientLight;
			float num9 = ambientLight3.b = b2;
			Color color9 = RenderSettings.ambientLight = ambientLight3;
			this.SkyboxColor.r = (float)1 - 0.149019614f * this.DayProgress - 0.5f * ((float)1 - this.DayProgress);
			this.SkyboxColor.g = (float)1 - 0.403921574f * this.DayProgress - 0.5f * ((float)1 - this.DayProgress);
			this.SkyboxColor.b = (float)1 - 0.709803939f * this.DayProgress - 0.5f * ((float)1 - this.DayProgress);
			RenderSettings.skybox.SetColor("_Tint", new Color(this.SkyboxColor.r, this.SkyboxColor.g, this.SkyboxColor.b));
		}
		else
		{
			float ambientLightDim = this.AmbientLightDim;
			Color ambientLight4 = RenderSettings.ambientLight;
			float num10 = ambientLight4.r = ambientLightDim;
			Color color10 = RenderSettings.ambientLight = ambientLight4;
			float ambientLightDim2 = this.AmbientLightDim;
			Color ambientLight5 = RenderSettings.ambientLight;
			float num11 = ambientLight5.g = ambientLightDim2;
			Color color11 = RenderSettings.ambientLight = ambientLight5;
			float ambientLightDim3 = this.AmbientLightDim;
			Color ambientLight6 = RenderSettings.ambientLight;
			float num12 = ambientLight6.b = ambientLightDim3;
			Color color12 = RenderSettings.ambientLight = ambientLight6;
		}
		if (this.TimeSkip)
		{
			if (this.HalfwayTime == (float)0)
			{
				this.HalfwayTime = this.PresentTime + (this.TargetTime - this.PresentTime) * 0.5f;
				this.Yandere.TimeSkipHeight = this.Yandere.transform.position.y;
				this.Yandere.Phone.active = true;
				this.Yandere.TimeSkipping = true;
				this.Yandere.CanMove = false;
				this.Blur.enabled = true;
				if (this.Yandere.Armed)
				{
					this.Yandere.Unequip();
				}
			}
			if (Time.timeScale < (float)25)
			{
				Time.timeScale += (float)1;
			}
			this.Yandere.Character.animation["f02_timeSkip_00"].speed = (float)1 / Time.timeScale;
			this.Blur.blurAmount = 0.92f * (Time.timeScale / (float)100);
			if (this.PresentTime > this.TargetTime)
			{
				this.EndTimeSkip();
			}
			if (this.Yandere.CameraEffects.Streaks.color.a > (float)0 || this.Yandere.CameraEffects.MurderStreaks.color.a > (float)0 || this.Yandere.NearSenpai || Input.GetButtonDown("Start"))
			{
				this.EndTimeSkip();
			}
		}
	}

	public virtual void EndTimeSkip()
	{
		this.PromptParent.localScale = new Vector3((float)1, (float)1, (float)1);
		this.Yandere.Phone.active = false;
		this.Yandere.TimeSkipping = false;
		this.Blur.enabled = false;
		Time.timeScale = (float)1;
		this.TimeSkip = false;
		this.HalfwayTime = (float)0;
		if (!this.Yandere.Noticed && !this.Police.FadeOut)
		{
			this.Yandere.CanMove = true;
		}
	}

	public virtual void UpdateWeekdayText(int Weekday)
	{
		if (Weekday == 1)
		{
			this.DayLabel.text = "MONDAY";
		}
		if (Weekday == 2)
		{
			this.DayLabel.text = "TUESDAY";
		}
		if (Weekday == 3)
		{
			this.DayLabel.text = "WEDNESDAY";
		}
		if (Weekday == 4)
		{
			this.DayLabel.text = "THURSDAY";
		}
		if (Weekday == 5)
		{
			this.DayLabel.text = "FRIDAY";
		}
	}

	public virtual void ActivateTrespassZones()
	{
		this.SchoolBell.Play();
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.TrespassZones))
		{
			this.TrespassZones[this.ID].enabled = true;
			this.ID++;
		}
	}

	public virtual void DeactivateTrespassZones()
	{
		this.Yandere.Trespassing = false;
		this.SchoolBell.Play();
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.TrespassZones))
		{
			this.TrespassZones[this.ID].enabled = false;
			this.ID++;
		}
	}

	public virtual void Main()
	{
	}
}
