using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CalendarScript : MonoBehaviour
{
	public SelectiveGrayscale GrayscaleEffect;

	public ChallengeScript Challenge;

	public Vignetting Vignette;

	public GameObject ConfirmationWindow;

	public UILabel AtmosphereLabel;

	public UIPanel ChallengePanel;

	public UIPanel CalendarPanel;

	public UISprite Darkness;

	public UITexture Cloud;

	public UITexture Sun;

	public Transform Highlight;

	public Transform Continue;

	public UILabel[] DayNumber;

	public UILabel[] DayLabel;

	public UILabel WeekNumber;

	public bool Incremented;

	public bool LoveSick;

	public bool FadeOut;

	public bool Switch;

	public bool Reset;

	public float Timer;

	public float Target;

	public int Phase = 1;

	private void Start()
	{
		Debug.Log("Upon entering the Calendar screen, DateGlobals.Weekday is: " + DateGlobals.Weekday);
		this.LoveSickCheck();
		if (!SchoolGlobals.SchoolAtmosphereSet)
		{
			OptionGlobals.EnableShadows = false;
			SchoolGlobals.SchoolAtmosphereSet = true;
			SchoolGlobals.SchoolAtmosphere = 1f;
			PlayerGlobals.Money = 10f;
		}
		if (SchoolGlobals.SchoolAtmosphere > 1f)
		{
			SchoolGlobals.SchoolAtmosphere = 1f;
		}
		if (DateGlobals.Weekday > DayOfWeek.Thursday)
		{
			DateGlobals.Weekday = DayOfWeek.Sunday;
			Globals.DeleteAll();
		}
		if (DateGlobals.PassDays < 1)
		{
			DateGlobals.PassDays = 1;
		}
		DateGlobals.DayPassed = true;
		this.Sun.color = new Color(this.Sun.color.r, this.Sun.color.g, this.Sun.color.b, SchoolGlobals.SchoolAtmosphere);
		this.Cloud.color = new Color(this.Cloud.color.r, this.Cloud.color.g, this.Cloud.color.b, 1f - SchoolGlobals.SchoolAtmosphere);
		this.AtmosphereLabel.text = (SchoolGlobals.SchoolAtmosphere * 100f).ToString("f0") + "%";
		float num = 1f - SchoolGlobals.SchoolAtmosphere;
		this.GrayscaleEffect.desaturation = num;
		this.Vignette.intensity = num * 5f;
		this.Vignette.blur = num;
		this.Vignette.chromaticAberration = num;
		this.Continue.transform.localPosition = new Vector3(this.Continue.transform.localPosition.x, -610f, this.Continue.transform.localPosition.z);
		this.Challenge.ViewButton.SetActive(false);
		this.Challenge.LargeIcon.color = new Color(this.Challenge.LargeIcon.color.r, this.Challenge.LargeIcon.color.g, this.Challenge.LargeIcon.color.b, 0f);
		this.Challenge.Panels[1].alpha = 0.5f;
		this.Challenge.Shadow.color = new Color(this.Challenge.Shadow.color.r, this.Challenge.Shadow.color.g, this.Challenge.Shadow.color.b, 0f);
		this.ChallengePanel.alpha = 0f;
		this.CalendarPanel.alpha = 1f;
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
		Time.timeScale = 1f;
		this.Highlight.localPosition = new Vector3(-683.334f + (float)((DayOfWeek)250 * DateGlobals.Weekday), this.Highlight.localPosition.y, this.Highlight.localPosition.z);
		if (DateGlobals.Weekday == DayOfWeek.Saturday)
		{
			this.Highlight.localPosition = new Vector3(-1150f, this.Highlight.localPosition.y, this.Highlight.localPosition.z);
		}
		if (DateGlobals.Week == 2)
		{
			this.DayNumber[1].text = "11";
			this.DayNumber[2].text = "12";
			this.DayNumber[3].text = "13";
			this.DayNumber[4].text = "14";
			this.DayNumber[5].text = "15";
			this.DayNumber[6].text = "16";
			this.DayNumber[7].text = "17";
		}
		this.WeekNumber.text = "Week " + DateGlobals.Week;
		this.LoveSickCheck();
		this.ChangeDayColor();
	}

	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (!this.FadeOut)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a - Time.deltaTime);
			if (this.Darkness.color.a < 0f)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 0f);
			}
			if (this.Timer > 1f)
			{
				if (!this.Incremented)
				{
					while (DateGlobals.PassDays > 0)
					{
						DateGlobals.Weekday++;
						DateGlobals.PassDays--;
						this.ChangeDayColor();
					}
					this.Target = 250f * (float)DateGlobals.Weekday;
					if (DateGlobals.Weekday > DayOfWeek.Saturday)
					{
						this.Darkness.color = new Color(0f, 0f, 0f, 0f);
						DateGlobals.Weekday = DayOfWeek.Sunday;
						this.Target = 0f;
					}
					Debug.Log("And, as of now, DateGlobals.Weekday is: " + DateGlobals.Weekday);
					this.Incremented = true;
					base.GetComponent<AudioSource>().pitch = 1f - (0.8f - SchoolGlobals.SchoolAtmosphere * 0.8f);
					base.GetComponent<AudioSource>().Play();
				}
				else
				{
					this.Highlight.localPosition = new Vector3(Mathf.Lerp(this.Highlight.localPosition.x, -683.334f + this.Target, Time.deltaTime * 10f), this.Highlight.localPosition.y, this.Highlight.localPosition.z);
				}
				if (this.Timer > 2f)
				{
					this.Continue.localPosition = new Vector3(this.Continue.localPosition.x, Mathf.Lerp(this.Continue.localPosition.y, -500f, Time.deltaTime * 10f), this.Continue.localPosition.z);
					if (!this.Switch)
					{
						if (!this.ConfirmationWindow.activeInHierarchy)
						{
							if (Input.GetButtonDown("A"))
							{
								this.FadeOut = true;
							}
							if (Input.GetButtonDown("Y"))
							{
								this.Switch = true;
							}
							if (Input.GetButtonDown("B"))
							{
								this.ConfirmationWindow.SetActive(true);
							}
							if (Input.GetKeyDown(KeyCode.Z))
							{
								if (SchoolGlobals.SchoolAtmosphere > 0f)
								{
									SchoolGlobals.SchoolAtmosphere -= 0.1f;
								}
								else
								{
									SchoolGlobals.SchoolAtmosphere = 100f;
								}
								SceneManager.LoadScene(SceneManager.GetActiveScene().name);
							}
						}
						else
						{
							if (Input.GetButtonDown("A"))
							{
								this.FadeOut = true;
								this.Reset = true;
							}
							if (Input.GetButtonDown("B"))
							{
								this.ConfirmationWindow.SetActive(false);
							}
						}
					}
				}
			}
		}
		else
		{
			this.Continue.localPosition = new Vector3(this.Continue.localPosition.x, Mathf.Lerp(this.Continue.localPosition.y, -610f, Time.deltaTime * 10f), this.Continue.localPosition.z);
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
			if (this.Darkness.color.a >= 1f)
			{
				if (this.Reset)
				{
					int profile = GameGlobals.Profile;
					Globals.DeleteAll();
					PlayerPrefs.SetInt("ProfileCreated_" + profile, 1);
					GameGlobals.Profile = profile;
					GameGlobals.LoveSick = this.LoveSick;
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				}
				else
				{
					if (HomeGlobals.Night)
					{
						HomeGlobals.Night = false;
					}
					if (DateGlobals.Weekday == DayOfWeek.Saturday)
					{
						SceneManager.LoadScene("BusStopScene");
					}
					else
					{
						if (DateGlobals.Weekday == DayOfWeek.Sunday)
						{
							HomeGlobals.Night = true;
						}
						SceneManager.LoadScene("HomeScene");
					}
				}
			}
		}
		if (this.Switch)
		{
			if (this.Phase == 1)
			{
				this.CalendarPanel.alpha -= Time.deltaTime;
				if (this.CalendarPanel.alpha <= 0f)
				{
					this.Phase++;
				}
			}
			else
			{
				this.ChallengePanel.alpha += Time.deltaTime;
				if (this.ChallengePanel.alpha >= 1f)
				{
					this.Challenge.enabled = true;
					base.enabled = false;
					this.Switch = false;
					this.Phase = 1;
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			DateGlobals.Weekday = DayOfWeek.Monday;
			this.Target = 250f * (float)DateGlobals.Weekday;
			this.ChangeDayColor();
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			DateGlobals.Weekday = DayOfWeek.Tuesday;
			this.Target = 250f * (float)DateGlobals.Weekday;
			this.ChangeDayColor();
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			DateGlobals.Weekday = DayOfWeek.Wednesday;
			this.Target = 250f * (float)DateGlobals.Weekday;
			this.ChangeDayColor();
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			DateGlobals.Weekday = DayOfWeek.Thursday;
			this.Target = 250f * (float)DateGlobals.Weekday;
			this.ChangeDayColor();
		}
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			DateGlobals.Weekday = DayOfWeek.Friday;
			this.Target = 250f * (float)DateGlobals.Weekday;
			this.ChangeDayColor();
		}
	}

	public void ChangeDayColor()
	{
		UILabel[] array = this.DayLabel;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].color = new Color(1f, 1f, 1f, 1f);
		}
		foreach (UILabel uilabel in this.DayNumber)
		{
			if (uilabel != null)
			{
				uilabel.color = new Color(1f, 1f, 1f, 0.25f);
			}
		}
		if (DateGlobals.Weekday == DayOfWeek.Sunday)
		{
			this.DayLabel[0].color = new Color(1f, 0.5f, 0.75f, 1f);
			this.DayNumber[1].color = new Color(1f, 0.5f, 0.75f, 0.25f);
			return;
		}
		if (DateGlobals.Weekday == DayOfWeek.Monday)
		{
			this.DayLabel[1].color = new Color(1f, 0.5f, 0.75f, 1f);
			this.DayNumber[2].color = new Color(1f, 0.5f, 0.75f, 0.25f);
			return;
		}
		if (DateGlobals.Weekday == DayOfWeek.Tuesday)
		{
			this.DayLabel[2].color = new Color(1f, 0.5f, 0.75f, 1f);
			this.DayNumber[3].color = new Color(1f, 0.5f, 0.75f, 0.25f);
			return;
		}
		if (DateGlobals.Weekday == DayOfWeek.Wednesday)
		{
			this.DayLabel[3].color = new Color(1f, 0.5f, 0.75f, 1f);
			this.DayNumber[4].color = new Color(1f, 0.5f, 0.75f, 0.25f);
			return;
		}
		if (DateGlobals.Weekday == DayOfWeek.Thursday)
		{
			this.DayLabel[4].color = new Color(1f, 0.5f, 0.75f, 1f);
			this.DayNumber[5].color = new Color(1f, 0.5f, 0.75f, 0.25f);
			return;
		}
		if (DateGlobals.Weekday == DayOfWeek.Friday)
		{
			this.DayLabel[5].color = new Color(1f, 0.5f, 0.75f, 1f);
			this.DayNumber[6].color = new Color(1f, 0.5f, 0.75f, 0.25f);
			return;
		}
		if (DateGlobals.Weekday == DayOfWeek.Saturday)
		{
			this.DayLabel[6].color = new Color(1f, 0.5f, 0.75f, 1f);
			this.DayNumber[7].color = new Color(1f, 0.5f, 0.75f, 0.25f);
		}
	}

	public void LoveSickCheck()
	{
		if (GameGlobals.LoveSick)
		{
			SchoolGlobals.SchoolAtmosphereSet = true;
			SchoolGlobals.SchoolAtmosphere = 0f;
			this.LoveSick = true;
			Camera.main.backgroundColor = new Color(0f, 0f, 0f, 1f);
			foreach (GameObject gameObject in UnityEngine.Object.FindObjectsOfType<GameObject>())
			{
				UISprite component = gameObject.GetComponent<UISprite>();
				if (component != null)
				{
					component.color = new Color(1f, 0f, 0f, component.color.a);
				}
				UITexture component2 = gameObject.GetComponent<UITexture>();
				if (component2 != null)
				{
					component2.color = new Color(1f, 0f, 0f, component2.color.a);
				}
				UILabel component3 = gameObject.GetComponent<UILabel>();
				if (component3 != null)
				{
					if (component3.color != Color.black)
					{
						component3.color = new Color(1f, 0f, 0f, component3.color.a);
					}
					if (component3.text == "?")
					{
						component3.color = new Color(1f, 0f, 0f, component3.color.a);
					}
				}
			}
			this.Darkness.color = Color.black;
			this.AtmosphereLabel.enabled = false;
			this.Cloud.enabled = false;
			this.Sun.enabled = false;
		}
	}
}
