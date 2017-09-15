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

	public float Atmosphere;

	public int Phase = 1;

	private void Start()
	{
		this.LoveSickCheck();
		if (!SchoolGlobals.SchoolAtmosphereSet)
		{
			SchoolGlobals.SchoolAtmosphereSet = true;
			SchoolGlobals.SchoolAtmosphere = 100f;
		}
		if (DateGlobals.Weekday > 4)
		{
			DateGlobals.Weekday = 0;
			Globals.DeleteAll();
		}
		this.Sun.color = new Color(this.Sun.color.r, this.Sun.color.g, this.Sun.color.b, SchoolGlobals.SchoolAtmosphere * 0.01f);
		this.Cloud.color = new Color(this.Cloud.color.r, this.Cloud.color.g, this.Cloud.color.b, 1f - SchoolGlobals.SchoolAtmosphere * 0.01f);
		this.Atmosphere = SchoolGlobals.SchoolAtmosphere;
		this.AtmosphereLabel.text = this.Atmosphere.ToString("f0") + "%";
		float num = 1f - SchoolGlobals.SchoolAtmosphere * 0.01f;
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
						if (Input.GetKeyDown("z"))
						{
							float schoolAtmosphere = SchoolGlobals.SchoolAtmosphere;
							if (schoolAtmosphere > 80f)
							{
								SchoolGlobals.SchoolAtmosphere = 80f;
							}
							else if (schoolAtmosphere > 60f)
							{
								SchoolGlobals.SchoolAtmosphere = 60f;
							}
							else if (schoolAtmosphere > 50f)
							{
								SchoolGlobals.SchoolAtmosphere = 50f;
							}
							else if (schoolAtmosphere > 40f)
							{
								SchoolGlobals.SchoolAtmosphere = 40f;
							}
							else if (schoolAtmosphere > 20f)
							{
								SchoolGlobals.SchoolAtmosphere = 20f;
							}
							else if (schoolAtmosphere > 0f)
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
		if (Input.GetKeyDown("1"))
		{
			DateGlobals.Weekday = 1;
		}
		if (Input.GetKeyDown("2"))
		{
			DateGlobals.Weekday = 2;
		}
		if (Input.GetKeyDown("3"))
		{
			DateGlobals.Weekday = 3;
		}
		if (Input.GetKeyDown("4"))
		{
			DateGlobals.Weekday = 4;
		}
		if (Input.GetKeyDown("5"))
		{
			DateGlobals.Weekday = 5;
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
