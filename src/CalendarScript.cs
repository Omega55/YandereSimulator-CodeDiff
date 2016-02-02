using System;
using UnityEngine;

[Serializable]
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

	public int Atmosphere;

	public int Phase;

	public CalendarScript()
	{
		this.Phase = 1;
	}

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("SchoolAtmosphereSet") == 0)
		{
			PlayerPrefs.SetInt("SchoolAtmosphereSet", 1);
			PlayerPrefs.SetFloat("SchoolAtmosphere", (float)100);
		}
		if (PlayerPrefs.GetInt("Weekday") > 4)
		{
			PlayerPrefs.SetInt("Weekday", 0);
			PlayerPrefs.DeleteAll();
		}
		float a = PlayerPrefs.GetFloat("SchoolAtmosphere") * 0.01f;
		Color color = this.Sun.color;
		float num = color.a = a;
		Color color2 = this.Sun.color = color;
		float a2 = (float)1 - PlayerPrefs.GetFloat("SchoolAtmosphere") * 0.01f;
		Color color3 = this.Cloud.color;
		float num2 = color3.a = a2;
		Color color4 = this.Cloud.color = color3;
		this.Atmosphere = (int)PlayerPrefs.GetFloat("SchoolAtmosphere");
		this.AtmosphereLabel.text = this.Atmosphere + "%";
		float num3 = (float)1 - PlayerPrefs.GetFloat("SchoolAtmosphere") * 0.01f;
		this.GrayscaleEffect.desaturation = num3;
		this.Vignette.intensity = num3 * (float)5;
		this.Vignette.blur = num3;
		this.Vignette.chromaticAberration = num3;
		int num4 = -610;
		Vector3 localPosition = this.Continue.transform.localPosition;
		float num5 = localPosition.y = (float)num4;
		Vector3 vector = this.Continue.transform.localPosition = localPosition;
		this.Challenge.ViewButton.active = false;
		int num6 = 0;
		Color color5 = this.Challenge.LargeIcon.color;
		float num7 = color5.a = (float)num6;
		Color color6 = this.Challenge.LargeIcon.color = color5;
		this.Challenge.Panels[1].alpha = 0.5f;
		int num8 = 0;
		Color color7 = this.Challenge.Shadow.color;
		float num9 = color7.a = (float)num8;
		Color color8 = this.Challenge.Shadow.color = color7;
		this.ChallengePanel.alpha = (float)0;
		this.CalendarPanel.alpha = (float)1;
		int num10 = 1;
		Color color9 = this.Darkness.color;
		float num11 = color9.a = (float)num10;
		Color color10 = this.Darkness.color = color9;
		Time.timeScale = (float)1;
		int num12 = -600 + 200 * PlayerPrefs.GetInt("Weekday");
		Vector3 localPosition2 = this.Highlight.localPosition;
		float num13 = localPosition2.x = (float)num12;
		Vector3 vector2 = this.Highlight.localPosition = localPosition2;
	}

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (!this.FadeOut)
		{
			float a = this.Darkness.color.a - Time.deltaTime;
			Color color = this.Darkness.color;
			float num = color.a = a;
			Color color2 = this.Darkness.color = color;
			if (this.Darkness.color.a < (float)0)
			{
				int num2 = 0;
				Color color3 = this.Darkness.color;
				float num3 = color3.a = (float)num2;
				Color color4 = this.Darkness.color = color3;
			}
			if (this.Timer > (float)1)
			{
				if (!this.Incremented)
				{
					PlayerPrefs.SetInt("Weekday", PlayerPrefs.GetInt("Weekday") + 1);
					this.Incremented = true;
					this.audio.Play();
				}
				else
				{
					float x = Mathf.Lerp(this.Highlight.localPosition.x, (float)(-600 + 200 * PlayerPrefs.GetInt("Weekday")), Time.deltaTime * (float)10);
					Vector3 localPosition = this.Highlight.localPosition;
					float num4 = localPosition.x = x;
					Vector3 vector = this.Highlight.localPosition = localPosition;
				}
				if (this.Timer > (float)2)
				{
					float y = Mathf.Lerp(this.Continue.localPosition.y, (float)-540, Time.deltaTime * (float)10);
					Vector3 localPosition2 = this.Continue.localPosition;
					float num5 = localPosition2.y = y;
					Vector3 vector2 = this.Continue.localPosition = localPosition2;
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
							if (PlayerPrefs.GetFloat("SchoolAtmosphere") > (float)80)
							{
								PlayerPrefs.SetFloat("SchoolAtmosphere", (float)80);
							}
							else if (PlayerPrefs.GetFloat("SchoolAtmosphere") > (float)60)
							{
								PlayerPrefs.SetFloat("SchoolAtmosphere", (float)60);
							}
							else if (PlayerPrefs.GetFloat("SchoolAtmosphere") > (float)50)
							{
								PlayerPrefs.SetFloat("SchoolAtmosphere", (float)50);
							}
							else if (PlayerPrefs.GetFloat("SchoolAtmosphere") > (float)40)
							{
								PlayerPrefs.SetFloat("SchoolAtmosphere", (float)40);
							}
							else if (PlayerPrefs.GetFloat("SchoolAtmosphere") > (float)20)
							{
								PlayerPrefs.SetFloat("SchoolAtmosphere", (float)20);
							}
							else if (PlayerPrefs.GetFloat("SchoolAtmosphere") > (float)0)
							{
								PlayerPrefs.SetFloat("SchoolAtmosphere", (float)0);
							}
							Application.LoadLevel(Application.loadedLevel);
						}
					}
				}
			}
		}
		else
		{
			float y2 = Mathf.Lerp(this.Continue.localPosition.y, (float)-610, Time.deltaTime * (float)10);
			Vector3 localPosition3 = this.Continue.localPosition;
			float num6 = localPosition3.y = y2;
			Vector3 vector3 = this.Continue.localPosition = localPosition3;
			float a2 = this.Darkness.color.a + Time.deltaTime;
			Color color5 = this.Darkness.color;
			float num7 = color5.a = a2;
			Color color6 = this.Darkness.color = color5;
			if (this.Darkness.color.a >= (float)1)
			{
				if (this.Reset)
				{
					PlayerPrefs.DeleteAll();
					Application.LoadLevel(Application.loadedLevel);
				}
				else
				{
					if (PlayerPrefs.GetInt("Night") == 1)
					{
						PlayerPrefs.SetInt("Night", 0);
					}
					Application.LoadLevel("HomeScene");
				}
			}
		}
		if (this.Switch)
		{
			if (this.Phase == 1)
			{
				this.CalendarPanel.alpha = this.CalendarPanel.alpha - Time.deltaTime;
				if (this.CalendarPanel.alpha <= (float)0)
				{
					this.Phase++;
				}
			}
			else
			{
				this.ChallengePanel.alpha = this.ChallengePanel.alpha + Time.deltaTime;
				if (this.ChallengePanel.alpha >= (float)1)
				{
					this.Challenge.enabled = true;
					this.enabled = false;
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

	public virtual void Main()
	{
	}
}
