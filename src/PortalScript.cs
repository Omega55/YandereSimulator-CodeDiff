using System;
using UnityEngine;

[Serializable]
public class PortalScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public PromptBarScript PromptBar;

	public ParticleSystem Particles;

	public YandereScript Yandere;

	public PoliceScript Police;

	public PromptScript Prompt;

	public ClassScript Class;

	public ClockScript Clock;

	public UISprite ClassDarkness;

	public bool Transition;

	public bool FadeOut;

	public bool Proceed;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			this.Yandere.CanMove = false;
			if (this.Clock.HourTime < 15.5f)
			{
				this.Clock.StopTime = true;
				this.Transition = true;
				this.FadeOut = true;
			}
			else
			{
				this.Police.FadeOut = true;
			}
		}
		if (this.Transition)
		{
			if (this.FadeOut)
			{
				float a = this.ClassDarkness.color.a + Time.deltaTime;
				Color color = this.ClassDarkness.color;
				float num = color.a = a;
				Color color2 = this.ClassDarkness.color = color;
				if (this.ClassDarkness.color.a >= (float)1)
				{
					int num2 = 1;
					Color color3 = this.ClassDarkness.color;
					float num3 = color3.a = (float)num2;
					Color color4 = this.ClassDarkness.color = color3;
					if (this.Clock.HourTime < (float)13)
					{
						this.Yandere.Incinerator.Timer = this.Yandere.Incinerator.Timer - ((float)780 - this.Clock.PresentTime);
						this.Clock.PresentTime = (float)780;
					}
					else
					{
						this.Yandere.Incinerator.Timer = this.Yandere.Incinerator.Timer - (930f - this.Clock.PresentTime);
						this.Clock.PresentTime = 930f;
					}
					this.FadeOut = false;
					this.Proceed = false;
					this.Yandere.RPGCamera.enabled = false;
					this.PromptBar.Show = true;
					this.Class.StudyPoints = 5;
					this.Class.UpdateLabel();
					this.Class.active = true;
					this.Class.Show = true;
					if (this.Police.Show)
					{
						this.Police.Timer = 1E-06f;
					}
				}
			}
			else if (this.Proceed)
			{
				if (this.ClassDarkness.color.a >= (float)1)
				{
					this.StudentManager.AttendClass();
				}
				float a2 = this.ClassDarkness.color.a - Time.deltaTime;
				Color color5 = this.ClassDarkness.color;
				float num4 = color5.a = a2;
				Color color6 = this.ClassDarkness.color = color5;
				if (this.ClassDarkness.color.a <= (float)0)
				{
					int num5 = 0;
					Color color7 = this.ClassDarkness.color;
					float num6 = color7.a = (float)num5;
					Color color8 = this.ClassDarkness.color = color7;
					this.Yandere.RPGCamera.enabled = true;
					this.Clock.StopTime = false;
					this.Yandere.CanMove = true;
					this.Transition = false;
					this.StudentManager.ResumeMovement();
				}
			}
		}
		if (this.Clock.HourTime > 15.5f && this.transform.position.z > (float)0)
		{
			this.transform.position = new Vector3((float)0, (float)0, -49.5f);
			this.Prompt.Label[0].text = "     " + "Go Home";
		}
	}

	public virtual void Main()
	{
	}
}
