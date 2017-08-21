using System;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
	private string MinuteNumber = string.Empty;

	private string HourNumber = string.Empty;

	public Collider[] TrespassZones;

	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public PoliceScript Police;

	public ClockScript Clock;

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

	public float Timer;

	public float Hour;

	public int Period;

	public int ID;

	public string TimeText = string.Empty;

	public bool StopTime;

	public bool TimeSkip;

	public bool FadeIn;

	public AudioSource SchoolBell;

	public Color SkyboxColor;

	private void Start()
	{
		this.PeriodLabel.text = "BEFORE CLASS";
		this.PresentTime = this.StartHour * 60f;
		if (Globals.Weekday == 0)
		{
			Globals.Weekday = 1;
		}
		if (Globals.SchoolAtmosphere < 50f)
		{
			this.BloomEffect.bloomIntensity = 0.25f;
			this.BloomEffect.bloomThreshhold = 0.5f;
			this.Police.Darkness.enabled = true;
			this.Police.Darkness.color = new Color(this.Police.Darkness.color.r, this.Police.Darkness.color.g, this.Police.Darkness.color.b, 1f);
			this.FadeIn = true;
			this.Timer = 5f;
		}
		else
		{
			this.BloomEffect.bloomIntensity = 10f;
			this.BloomEffect.bloomThreshhold = 0f;
		}
		this.BloomEffect.bloomThreshhold = 0f;
		this.UpdateWeekdayText(Globals.Weekday);
		this.MainLight.color = new Color(1f, 1f, 1f, 1f);
		RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f, 1f);
		RenderSettings.skybox.SetColor("_Tint", new Color(0.5f, 0.5f, 0.5f));
	}

	private void Update()
	{
		if (this.FadeIn && Time.deltaTime < 1f)
		{
			this.Police.Darkness.color = new Color(this.Police.Darkness.color.r, this.Police.Darkness.color.g, this.Police.Darkness.color.b, Mathf.MoveTowards(this.Police.Darkness.color.a, 0f, Time.deltaTime));
			if (this.Police.Darkness.color.a == 0f)
			{
				this.Police.Darkness.enabled = false;
				this.FadeIn = false;
			}
		}
		if (this.PresentTime < 1080f)
		{
			if (this.Timer < 5f)
			{
				this.Timer += Time.deltaTime;
				this.BloomEffect.bloomIntensity -= Time.deltaTime * 9.75f;
				this.BloomEffect.bloomThreshhold += Time.deltaTime * 0.5f;
				if (this.BloomEffect.bloomThreshhold > 0.5f)
				{
					this.BloomEffect.bloomIntensity = 0.25f;
					this.BloomEffect.bloomThreshhold = 0.5f;
				}
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
			if (this.Period == 3)
			{
				this.PresentTime += Time.deltaTime * 0.0166666675f * this.TimeSpeed * 0.5f;
			}
			else
			{
				this.PresentTime += Time.deltaTime * 0.0166666675f * this.TimeSpeed;
			}
		}
		if (this.PresentTime > 1440f)
		{
			this.PresentTime -= 1440f;
		}
		this.HourTime = this.PresentTime / 60f;
		this.Hour = Mathf.Floor(this.PresentTime / 60f);
		this.Minute = Mathf.Floor((this.PresentTime / 60f - this.Hour) * 60f);
		if (this.Hour == 0f || this.Hour == 12f)
		{
			this.HourNumber = "12";
		}
		else if (this.Hour < 12f)
		{
			this.HourNumber = this.Hour.ToString("f0");
		}
		else
		{
			this.HourNumber = (this.Hour - 12f).ToString("f0");
		}
		if (this.Minute < 10f)
		{
			this.MinuteNumber = "0" + this.Minute.ToString("f0");
		}
		else
		{
			this.MinuteNumber = this.Minute.ToString("f0");
		}
		this.TimeText = this.HourNumber + ":" + this.MinuteNumber + ((this.Hour >= 12f) ? " PM" : " AM");
		this.TimeLabel.text = this.TimeText;
		this.MinuteHand.localEulerAngles = new Vector3(this.MinuteHand.localEulerAngles.x, this.MinuteHand.localEulerAngles.y, this.Minute * 6f);
		this.HourHand.localEulerAngles = new Vector3(this.HourHand.localEulerAngles.x, this.HourHand.localEulerAngles.y, this.Hour * 30f);
		if (this.HourTime < 8.5f)
		{
			if (this.Period < 1)
			{
				this.PeriodLabel.text = "BEFORE CLASS";
				this.DeactivateTrespassZones();
				this.Period++;
			}
		}
		else if (this.HourTime < 13f)
		{
			if (this.Period < 2)
			{
				this.PeriodLabel.text = "CLASS TIME";
				this.ActivateTrespassZones();
				this.Period++;
			}
		}
		else if (this.HourTime < 13.5f)
		{
			if (this.Period < 3)
			{
				this.PeriodLabel.text = "LUNCH TIME";
				this.DeactivateTrespassZones();
				this.Period++;
			}
		}
		else if (this.HourTime < 15.5f)
		{
			if (this.Period < 4)
			{
				this.PeriodLabel.text = "CLASS TIME";
				this.ActivateTrespassZones();
				this.Period++;
			}
		}
		else if (this.Period < 5)
		{
			this.PeriodLabel.text = "AFTER SCHOOL";
			this.DeactivateTrespassZones();
			this.Period++;
		}
		this.Sun.eulerAngles = new Vector3(this.Sun.eulerAngles.x, this.Sun.eulerAngles.y, -45f + 90f * (this.PresentTime - 420f) / 660f);
		if ((this.Yandere.transform.position.y < 11f && this.Yandere.transform.position.x > -30f && this.Yandere.transform.position.z > -38f && this.Yandere.transform.position.x < -22f && this.Yandere.transform.position.z < -26f) || (this.Yandere.transform.position.y < 11f && this.Yandere.transform.position.x > 22f && this.Yandere.transform.position.z > -38f && this.Yandere.transform.position.x < 30f && this.Yandere.transform.position.z < -26f))
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
		if (this.PresentTime > 930f)
		{
			this.DayProgress = (this.PresentTime - 930f) / 150f;
			this.MainLight.color = new Color(1f - 0.149019614f * this.DayProgress, 1f - 0.403921574f * this.DayProgress, 1f - 0.709803939f * this.DayProgress);
			RenderSettings.ambientLight = new Color(1f - 0.149019614f * this.DayProgress - (1f - this.AmbientLightDim) * (1f - this.DayProgress), 1f - 0.403921574f * this.DayProgress - (1f - this.AmbientLightDim) * (1f - this.DayProgress), 1f - 0.709803939f * this.DayProgress - (1f - this.AmbientLightDim) * (1f - this.DayProgress));
			this.SkyboxColor = new Color(1f - 0.149019614f * this.DayProgress - 0.5f * (1f - this.DayProgress), 1f - 0.403921574f * this.DayProgress - 0.5f * (1f - this.DayProgress), 1f - 0.709803939f * this.DayProgress - 0.5f * (1f - this.DayProgress));
			RenderSettings.skybox.SetColor("_Tint", new Color(this.SkyboxColor.r, this.SkyboxColor.g, this.SkyboxColor.b));
		}
		else
		{
			RenderSettings.ambientLight = new Color(this.AmbientLightDim, this.AmbientLightDim, this.AmbientLightDim);
		}
		if (this.TimeSkip)
		{
			if (this.HalfwayTime == 0f)
			{
				this.HalfwayTime = this.PresentTime + (this.TargetTime - this.PresentTime) * 0.5f;
				this.Yandere.TimeSkipHeight = this.Yandere.transform.position.y;
				this.Yandere.Phone.SetActive(true);
				this.Yandere.TimeSkipping = true;
				this.Yandere.CanMove = false;
				this.Blur.enabled = true;
				if (this.Yandere.Armed)
				{
					this.Yandere.Unequip();
				}
			}
			if (Time.timeScale < 25f)
			{
				Time.timeScale += 1f;
			}
			this.Yandere.Character.GetComponent<Animation>()["f02_timeSkip_00"].speed = 1f / Time.timeScale;
			this.Blur.blurAmount = 0.92f * (Time.timeScale / 100f);
			if (this.PresentTime > this.TargetTime)
			{
				this.EndTimeSkip();
			}
			if (this.Yandere.CameraEffects.Streaks.color.a > 0f || this.Yandere.CameraEffects.MurderStreaks.color.a > 0f || this.Yandere.NearSenpai || Input.GetButtonDown("Start"))
			{
				this.EndTimeSkip();
			}
		}
	}

	public void EndTimeSkip()
	{
		this.PromptParent.localScale = new Vector3(1f, 1f, 1f);
		this.Yandere.Phone.SetActive(false);
		this.Yandere.TimeSkipping = false;
		this.Blur.enabled = false;
		Time.timeScale = 1f;
		this.TimeSkip = false;
		this.HalfwayTime = 0f;
		if (!this.Yandere.Noticed && !this.Police.FadeOut)
		{
			this.Yandere.CanMove = true;
		}
	}

	private void UpdateWeekdayText(int Weekday)
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

	private void ActivateTrespassZones()
	{
		this.SchoolBell.Play();
		foreach (Collider collider in this.TrespassZones)
		{
			collider.enabled = true;
		}
	}

	public void DeactivateTrespassZones()
	{
		this.Yandere.Trespassing = false;
		this.SchoolBell.Play();
		foreach (Collider collider in this.TrespassZones)
		{
			collider.enabled = false;
		}
	}
}
