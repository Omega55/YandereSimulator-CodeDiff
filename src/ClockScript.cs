using System;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
	private string MinuteNumber = string.Empty;

	private string HourNumber = string.Empty;

	public Collider[] TrespassZones;

	public StudentManagerScript StudentManager;

	public LoveManagerScript LoveManager;

	public YandereScript Yandere;

	public PoliceScript Police;

	public ClockScript Clock;

	public Bloom BloomEffect;

	public MotionBlur Blur;

	public Transform PromptParent;

	public Transform MinuteHand;

	public Transform HourHand;

	public Transform Sun;

	public GameObject SunFlare;

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

	public float CameraTimer;

	public float DayProgress;

	public float StartHour;

	public float TimeSpeed;

	public float Minute;

	public float Timer;

	public float Hour;

	public PhaseOfDay Phase;

	public int Period;

	public int Weekday;

	public int ID;

	public string TimeText = string.Empty;

	public bool IgnorePhotographyClub;

	public bool LateStudent;

	public bool UpdateBloom;

	public bool MissionMode;

	public bool StopTime;

	public bool TimeSkip;

	public bool FadeIn;

	public bool Horror;

	public AudioSource SchoolBell;

	public Color SkyboxColor;

	private void Start()
	{
		RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f);
		this.PeriodLabel.text = "BEFORE CLASS";
		this.PresentTime = this.StartHour * 60f;
		if (PlayerPrefs.GetInt("LoadingSave") == 1)
		{
			int profile = GameGlobals.Profile;
			int @int = PlayerPrefs.GetInt("SaveSlot");
			Debug.Log(string.Concat(new object[]
			{
				"Loading time! Profile_",
				profile,
				"_Slot_",
				@int,
				"_Time is ",
				PlayerPrefs.GetFloat(string.Concat(new object[]
				{
					"Profile_",
					profile,
					"_Slot_",
					@int,
					"_Time"
				}))
			}));
			this.PresentTime = PlayerPrefs.GetFloat(string.Concat(new object[]
			{
				"Profile_",
				profile,
				"_Slot_",
				@int,
				"_Time"
			}));
			this.Weekday = PlayerPrefs.GetInt(string.Concat(new object[]
			{
				"Profile_",
				profile,
				"_Slot_",
				@int,
				"_Weekday"
			}));
			if (this.Weekday == 1)
			{
				DateGlobals.Weekday = DayOfWeek.Monday;
			}
			else if (this.Weekday == 2)
			{
				DateGlobals.Weekday = DayOfWeek.Tuesday;
			}
			else if (this.Weekday == 3)
			{
				DateGlobals.Weekday = DayOfWeek.Wednesday;
			}
			else if (this.Weekday == 4)
			{
				DateGlobals.Weekday = DayOfWeek.Thursday;
			}
			else if (this.Weekday == 5)
			{
				DateGlobals.Weekday = DayOfWeek.Friday;
			}
		}
		if (DateGlobals.Weekday == DayOfWeek.Sunday)
		{
			DateGlobals.Weekday = DayOfWeek.Monday;
		}
		if (!SchoolGlobals.SchoolAtmosphereSet)
		{
			SchoolGlobals.SchoolAtmosphereSet = true;
			SchoolGlobals.SchoolAtmosphere = 1f;
		}
		if (SchoolGlobals.SchoolAtmosphere < 0.5f)
		{
			this.BloomEffect.bloomIntensity = 0.2f;
			this.BloomEffect.bloomThreshhold = 0f;
			this.Police.Darkness.enabled = true;
			this.Police.Darkness.color = new Color(this.Police.Darkness.color.r, this.Police.Darkness.color.g, this.Police.Darkness.color.b, 1f);
			this.FadeIn = true;
		}
		else
		{
			this.BloomEffect.bloomIntensity = 10f;
			this.BloomEffect.bloomThreshhold = 0f;
			this.UpdateBloom = true;
		}
		this.BloomEffect.bloomThreshhold = 0f;
		this.DayLabel.text = this.GetWeekdayText(DateGlobals.Weekday);
		this.MainLight.color = new Color(1f, 1f, 1f, 1f);
		RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f, 1f);
		RenderSettings.skybox.SetColor("_Tint", new Color(0.5f, 0.5f, 0.5f));
		if (ClubGlobals.GetClubClosed(ClubType.Photography) || StudentGlobals.GetStudentGrudge(56) || StudentGlobals.GetStudentGrudge(57) || StudentGlobals.GetStudentGrudge(58) || StudentGlobals.GetStudentGrudge(59) || StudentGlobals.GetStudentGrudge(60))
		{
			this.IgnorePhotographyClub = true;
		}
		this.MissionMode = MissionModeGlobals.MissionMode;
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
		if (!this.MissionMode && this.CameraTimer < 1f)
		{
			this.CameraTimer += Time.deltaTime;
			if (this.CameraTimer > 1f && !this.StudentManager.MemorialScene.enabled)
			{
				this.Yandere.RPGCamera.enabled = true;
				this.Yandere.CanMove = true;
			}
		}
		if (this.PresentTime < 1080f)
		{
			if (this.UpdateBloom)
			{
				this.BloomEffect.bloomIntensity = Mathf.MoveTowards(this.BloomEffect.bloomIntensity, 0.2f, Time.deltaTime * 5f);
				if (this.BloomEffect.bloomIntensity == 0.2f)
				{
					this.UpdateBloom = false;
				}
			}
		}
		else if (this.LoveManager.WaitingToConfess)
		{
			if (!this.StopTime)
			{
				this.LoveManager.BeginConfession();
			}
		}
		else if (!this.Police.FadeOut && !this.Yandere.Attacking && !this.Yandere.Struggling && !this.Yandere.DelinquentFighting && !this.Yandere.Pickpocketing && !this.Yandere.Noticed)
		{
			this.Police.DayOver = true;
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
		if (this.LateStudent && this.HourTime > 7.9f)
		{
			this.ActivateLateStudent();
		}
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
				this.StudentManager.DramaPhase = 0;
				this.StudentManager.UpdateDrama();
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
		else if (this.HourTime < 16f)
		{
			if (this.Period < 5)
			{
				foreach (GameObject gameObject in this.StudentManager.Graffiti)
				{
					if (gameObject != null)
					{
						gameObject.SetActive(false);
					}
				}
				this.PeriodLabel.text = "CLEANING TIME";
				this.DeactivateTrespassZones();
				this.Period++;
			}
		}
		else if (this.Period < 6)
		{
			this.PeriodLabel.text = "AFTER SCHOOL";
			this.StudentManager.DramaPhase = 0;
			this.StudentManager.UpdateDrama();
			this.Period++;
		}
		if (!this.IgnorePhotographyClub && this.HourTime > 16.75f && this.StudentManager.SleuthPhase < 4)
		{
			this.StudentManager.SleuthPhase = 3;
			this.StudentManager.UpdateSleuths();
		}
		this.Sun.eulerAngles = new Vector3(this.Sun.eulerAngles.x, this.Sun.eulerAngles.y, -45f + 90f * (this.PresentTime - 420f) / 660f);
		if (!this.Horror)
		{
			if (this.StudentManager.WestBathroomArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.EastBathroomArea.bounds.Contains(this.Yandere.transform.position))
			{
				this.AmbientLightDim = Mathf.MoveTowards(this.AmbientLightDim, 0.1f, Time.deltaTime);
			}
			else
			{
				this.AmbientLightDim = Mathf.MoveTowards(this.AmbientLightDim, 0.75f, Time.deltaTime);
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
			this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
			this.Yandere.CanMoveTimer = 0.5f;
		}
	}

	public string GetWeekdayText(DayOfWeek weekday)
	{
		if (weekday == DayOfWeek.Sunday)
		{
			this.Weekday = 0;
			return "SUNDAY";
		}
		if (weekday == DayOfWeek.Monday)
		{
			this.Weekday = 1;
			return "MONDAY";
		}
		if (weekday == DayOfWeek.Tuesday)
		{
			this.Weekday = 2;
			return "TUESDAY";
		}
		if (weekday == DayOfWeek.Wednesday)
		{
			this.Weekday = 3;
			return "WEDNESDAY";
		}
		if (weekday == DayOfWeek.Thursday)
		{
			this.Weekday = 4;
			return "THURSDAY";
		}
		if (weekday == DayOfWeek.Friday)
		{
			this.Weekday = 5;
			return "FRIDAY";
		}
		this.Weekday = 6;
		return "SATURDAY";
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
			if (!collider.GetComponent<TrespassScript>().OffLimits)
			{
				collider.enabled = false;
			}
		}
	}

	public void ActivateLateStudent()
	{
		if (this.StudentManager.Students[7] != null)
		{
			this.StudentManager.Students[7].gameObject.SetActive(true);
			this.StudentManager.Students[7].Pathfinding.speed = 4f;
			this.StudentManager.Students[7].Spawned = true;
			this.StudentManager.Students[7].Hurry = true;
		}
		this.LateStudent = false;
	}

	public void NightLighting()
	{
		this.MainLight.color = new Color(0.25f, 0.25f, 0.5f);
		RenderSettings.ambientLight = new Color(0.25f, 0.25f, 0.5f);
		this.SkyboxColor = new Color(0.1f, 0.1f, 0.2f);
		RenderSettings.skybox.SetColor("_Tint", new Color(0.1f, 0.1f, 0.2f));
	}
}
