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

	public bool FadeOut;

	public bool Switch;

	public bool Reset;

	public float Timer;

	public float Atmosphere;

	public int Phase = 1;

	private void Start()
	{
		if (PlayerPrefs.GetInt("SchoolAtmosphereSet") == 0)
		{
			PlayerPrefs.SetInt("SchoolAtmosphereSet", 1);
			PlayerPrefs.SetFloat("SchoolAtmosphere", 100f);
		}
		if (PlayerPrefs.GetInt("Weekday") > 4)
		{
			PlayerPrefs.SetInt("Weekday", 0);
			PlayerPrefs.DeleteAll();
		}
		this.Sun.color = new Color(this.Sun.color.r, this.Sun.color.g, this.Sun.color.b, PlayerPrefs.GetFloat("SchoolAtmosphere") * 0.01f);
		this.Cloud.color = new Color(this.Cloud.color.r, this.Cloud.color.g, this.Cloud.color.b, 1f - PlayerPrefs.GetFloat("SchoolAtmosphere") * 0.01f);
		this.Atmosphere = PlayerPrefs.GetFloat("SchoolAtmosphere");
		this.AtmosphereLabel.text = this.Atmosphere.ToString("f0") + "%";
		float num = 1f - PlayerPrefs.GetFloat("SchoolAtmosphere") * 0.01f;
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
		this.Highlight.localPosition = new Vector3(-600f + 200f * (float)PlayerPrefs.GetInt("Weekday"), this.Highlight.localPosition.y, this.Highlight.localPosition.z);
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
					PlayerPrefs.SetInt("Weekday", PlayerPrefs.GetInt("Weekday") + 1);
					this.Incremented = true;
					base.GetComponent<AudioSource>().Play();
				}
				else
				{
					this.Highlight.localPosition = new Vector3(Mathf.Lerp(this.Highlight.localPosition.x, -600f + 200f * (float)PlayerPrefs.GetInt("Weekday"), Time.deltaTime * 10f), this.Highlight.localPosition.y, this.Highlight.localPosition.z);
				}
				if (this.Timer > 2f)
				{
					this.Continue.localPosition = new Vector3(this.Continue.localPosition.x, Mathf.Lerp(this.Continue.localPosition.y, -540f, Time.deltaTime * 10f), this.Continue.localPosition.z);
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
							float @float = PlayerPrefs.GetFloat("SchoolAtmosphere");
							if (@float > 80f)
							{
								PlayerPrefs.SetFloat("SchoolAtmosphere", 80f);
							}
							else if (@float > 60f)
							{
								PlayerPrefs.SetFloat("SchoolAtmosphere", 60f);
							}
							else if (@float > 50f)
							{
								PlayerPrefs.SetFloat("SchoolAtmosphere", 50f);
							}
							else if (@float > 40f)
							{
								PlayerPrefs.SetFloat("SchoolAtmosphere", 40f);
							}
							else if (@float > 20f)
							{
								PlayerPrefs.SetFloat("SchoolAtmosphere", 20f);
							}
							else if (@float > 0f)
							{
								PlayerPrefs.SetFloat("SchoolAtmosphere", 0f);
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
					PlayerPrefs.DeleteAll();
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				}
				else
				{
					if (PlayerPrefs.GetInt("Night") == 1)
					{
						PlayerPrefs.SetInt("Night", 0);
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
			PlayerPrefs.SetInt("Weekday", 1);
		}
		if (Input.GetKeyDown("2"))
		{
			PlayerPrefs.SetInt("Weekday", 2);
		}
		if (Input.GetKeyDown("3"))
		{
			PlayerPrefs.SetInt("Weekday", 3);
		}
		if (Input.GetKeyDown("4"))
		{
			PlayerPrefs.SetInt("Weekday", 4);
		}
		if (Input.GetKeyDown("5"))
		{
			PlayerPrefs.SetInt("Weekday", 5);
		}
	}
}
