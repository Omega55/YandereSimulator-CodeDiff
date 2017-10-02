using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CalendarScript : MonoBehaviour
{
	public SelectiveGrayscale GrayscaleEffect;

	public ChallengeScript Challenge;

	public Vignetting Vignette;

	public UILabel AtmosphereLabel;

	public UIPanel ChallengePanel;

	public UIPanel CalendarPanel;

	public UISprite Darkness;

	public UITexture Cloud;

	public UITexture Sun;

	public Transform Highlight;

	public Transform Continue;

	public bool Incremented;

	public bool LoveSick;

	public bool FadeOut;

	public bool Switch;

	public bool Reset;

	public float Timer;

	public int Phase = 1;

	private void Start()
	{
		this.LoveSickCheck();
		if (!SchoolGlobals.SchoolAtmosphereSet)
		{
			SchoolGlobals.SchoolAtmosphereSet = true;
			SchoolGlobals.SchoolAtmosphere = 1f;
		}
		if (DateGlobals.Weekday > DayOfWeek.Thursday)
		{
			DateGlobals.Weekday = DayOfWeek.Sunday;
			Globals.DeleteAll();
		}
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
		this.Highlight.localPosition = new Vector3(-600f + 200f * (float)DateGlobals.Weekday, this.Highlight.localPosition.y, this.Highlight.localPosition.z);
		this.LoveSickCheck();
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
					DateGlobals.Weekday++;
					this.Incremented = true;
					base.GetComponent<AudioSource>().Play();
				}
				else
				{
					this.Highlight.localPosition = new Vector3(Mathf.Lerp(this.Highlight.localPosition.x, -600f + 200f * (float)DateGlobals.Weekday, Time.deltaTime * 10f), this.Highlight.localPosition.y, this.Highlight.localPosition.z);
				}
				if (this.Timer > 2f)
				{
					this.Continue.localPosition = new Vector3(this.Continue.localPosition.x, Mathf.Lerp(this.Continue.localPosition.y, -500f, Time.deltaTime * 10f), this.Continue.localPosition.z);
					if (!this.Switch)
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
							this.FadeOut = true;
							this.Reset = true;
						}
						if (Input.GetKeyDown(KeyCode.Z))
						{
							if (SchoolGlobals.SchoolAtmosphere > 0.8f)
							{
								SchoolGlobals.SchoolAtmosphere = 0.8f;
							}
							else if (SchoolGlobals.SchoolAtmosphere > 0.6f)
							{
								SchoolGlobals.SchoolAtmosphere = 0.6f;
							}
							else if (SchoolGlobals.SchoolAtmosphere > 0.5f)
							{
								SchoolGlobals.SchoolAtmosphere = 0.5f;
							}
							else if (SchoolGlobals.SchoolAtmosphere > 0.4f)
							{
								SchoolGlobals.SchoolAtmosphere = 0.4f;
							}
							else if (SchoolGlobals.SchoolAtmosphere > 0.2f)
							{
								SchoolGlobals.SchoolAtmosphere = 0.2f;
							}
							else
							{
								SchoolGlobals.SchoolAtmosphere = 0f;
							}
							SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
					Globals.DeleteAll();
					GameGlobals.LoveSick = this.LoveSick;
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				}
				else
				{
					if (HomeGlobals.Night)
					{
						HomeGlobals.Night = false;
					}
					SceneManager.LoadScene("HomeScene");
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
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			DateGlobals.Weekday = DayOfWeek.Tuesday;
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			DateGlobals.Weekday = DayOfWeek.Wednesday;
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			DateGlobals.Weekday = DayOfWeek.Thursday;
		}
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			DateGlobals.Weekday = DayOfWeek.Friday;
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
			GameObject[] array = UnityEngine.Object.FindObjectsOfType<GameObject>();
			foreach (GameObject gameObject in array)
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
