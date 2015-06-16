using System;
using UnityEngine;

[Serializable]
public class CalendarScript : MonoBehaviour
{
	public ChallengeScript Challenge;

	public UIPanel ChallengePanel;

	public UIPanel CalendarPanel;

	public UISprite Darkness;

	public Transform Highlight;

	public Transform Continue;

	public bool Incremented;

	public bool FadeOut;

	public bool Switch;

	public bool Reset;

	public float Timer;

	public int Phase;

	public CalendarScript()
	{
		this.Phase = 1;
	}

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("Weekday") > 4)
		{
			PlayerPrefs.SetInt("Weekday", 0);
			PlayerPrefs.DeleteAll();
		}
		int num = -610;
		Vector3 localPosition = this.Continue.transform.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.Continue.transform.localPosition = localPosition;
		this.Challenge.ViewButton.active = false;
		int num3 = 0;
		Color color = this.Challenge.LargeIcon.color;
		float num4 = color.a = (float)num3;
		Color color2 = this.Challenge.LargeIcon.color = color;
		this.Challenge.Panels[1].alpha = 0.5f;
		int num5 = 0;
		Color color3 = this.Challenge.Shadow.color;
		float num6 = color3.a = (float)num5;
		Color color4 = this.Challenge.Shadow.color = color3;
		this.ChallengePanel.alpha = (float)0;
		this.CalendarPanel.alpha = (float)1;
		int num7 = 1;
		Color color5 = this.Darkness.color;
		float num8 = color5.a = (float)num7;
		Color color6 = this.Darkness.color = color5;
		Time.timeScale = (float)1;
	}

	public virtual void Update()
	{
		float x = Mathf.Lerp(this.Highlight.localPosition.x, (float)(-600 + 200 * PlayerPrefs.GetInt("Weekday")), Time.deltaTime * (float)10);
		Vector3 localPosition = this.Highlight.localPosition;
		float num = localPosition.x = x;
		Vector3 vector = this.Highlight.localPosition = localPosition;
		this.Timer += Time.deltaTime;
		if (this.Timer > (float)1)
		{
			if (!this.FadeOut)
			{
				float a = this.Darkness.color.a - Time.deltaTime;
				Color color = this.Darkness.color;
				float num2 = color.a = a;
				Color color2 = this.Darkness.color = color;
				if (this.Darkness.color.a < (float)0)
				{
					int num3 = 0;
					Color color3 = this.Darkness.color;
					float num4 = color3.a = (float)num3;
					Color color4 = this.Darkness.color = color3;
				}
				if (this.Timer > (float)2)
				{
					if (!this.Incremented)
					{
						PlayerPrefs.SetInt("Weekday", PlayerPrefs.GetInt("Weekday") + 1);
						this.Incremented = true;
					}
					if (this.Timer > (float)3)
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
						}
					}
				}
			}
			else
			{
				float a2 = this.Darkness.color.a + Time.deltaTime;
				Color color5 = this.Darkness.color;
				float num6 = color5.a = a2;
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
						Application.LoadLevel("HomeScene");
					}
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
