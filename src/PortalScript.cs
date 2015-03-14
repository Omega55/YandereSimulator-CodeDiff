using System;
using UnityEngine;

[Serializable]
public class PortalScript : MonoBehaviour
{
	public ParticleSystem Particles;

	public YandereScript Yandere;

	public PoliceScript Police;

	public PromptScript Prompt;

	public ClockScript Clock;

	public UISprite ClassDarkness;

	public bool Transition;

	public bool FadeOut;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			this.Yandere.CanMove = false;
			if (this.Clock.HourTime < 15.5f)
			{
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
				if (this.ClassDarkness.color.a > (float)1)
				{
					int num2 = 1;
					Color color3 = this.ClassDarkness.color;
					float num3 = color3.a = (float)num2;
					Color color4 = this.ClassDarkness.color = color3;
					if (this.Clock.HourTime < (float)13)
					{
						this.Clock.PresentTime = (float)780;
					}
					else
					{
						this.Clock.PresentTime = 930f;
					}
					this.FadeOut = false;
				}
			}
			else
			{
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
					this.Yandere.CanMove = true;
					this.Transition = false;
					if (this.Clock.HourTime > 15.5f)
					{
						if (PlayerPrefs.GetInt("Weekday") < 5)
						{
							this.transform.position = new Vector3((float)0, (float)0, -49.5f);
							this.Prompt.Label[0].text = "     " + "Go Home";
						}
						else
						{
							this.active = false;
						}
					}
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
