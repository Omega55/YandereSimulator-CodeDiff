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

	public GameObject HeartbeatCamera;

	public UISprite ClassDarkness;

	public Transform Teacher;

	public bool LateReport1;

	public bool LateReport2;

	public bool Transition;

	public bool FadeOut;

	public bool Proceed;

	public bool InEvent;

	public int Late;

	public virtual void Update()
	{
		if (this.Clock.HourTime > 8.52f && this.Clock.HourTime < 8.53f && !this.Yandere.InClass && !this.LateReport1)
		{
			this.LateReport1 = true;
			this.Yandere.NotificationManager.DisplayNotification("Late");
		}
		if (this.Clock.HourTime > 13.52f && this.Clock.HourTime < 13.53f && !this.Yandere.InClass && !this.LateReport2)
		{
			this.LateReport2 = true;
			this.Yandere.NotificationManager.DisplayNotification("Late");
		}
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			if (this.Police.NaturalScene)
			{
				this.Police.Show = true;
			}
			if (this.Clock.HourTime < 15.5f)
			{
				if (!this.Police.Show)
				{
					if (this.Clock.HourTime < (float)13)
					{
						if (this.Clock.HourTime < 8.52f)
						{
							this.Late = 0;
						}
						else if (this.Clock.HourTime < (float)10)
						{
							this.Late = 1;
						}
						else if (this.Clock.HourTime < (float)11)
						{
							this.Late = 2;
						}
						else if (this.Clock.HourTime < (float)12)
						{
							this.Late = 3;
						}
						else if (this.Clock.HourTime < (float)13)
						{
							this.Late = 4;
						}
					}
					else if (this.Clock.HourTime < 13.52f)
					{
						this.Late = 0;
					}
					else if (this.Clock.HourTime < (float)14)
					{
						this.Late = 1;
					}
					else if (this.Clock.HourTime < 14.5f)
					{
						this.Late = 2;
					}
					else if (this.Clock.HourTime < 15f)
					{
						this.Late = 3;
					}
					else if (this.Clock.HourTime < 15.5f)
					{
						this.Late = 4;
					}
					if (this.Late == 0)
					{
						this.Transition = true;
						this.FadeOut = true;
					}
					else
					{
						this.Yandere.Subtitle.UpdateLabel("Teacher Late Reaction", this.Late, 5.5f);
						this.Yandere.RPGCamera.enabled = false;
						this.Yandere.ShoulderCamera.Scolding = true;
						this.Yandere.ShoulderCamera.Teacher = this.Teacher;
					}
					this.Clock.StopTime = true;
				}
				else
				{
					this.Police.FadeOut = true;
				}
			}
			else
			{
				this.Police.FadeOut = true;
			}
			this.Yandere.Character.animation.CrossFade("f02_idleShort_00");
			this.Yandere.YandereVision = false;
			this.Yandere.CanMove = false;
			this.Yandere.InClass = true;
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
					this.HeartbeatCamera.active = false;
					int num2 = 1;
					Color color3 = this.ClassDarkness.color;
					float num3 = color3.a = (float)num2;
					Color color4 = this.ClassDarkness.color = color3;
					this.FadeOut = false;
					this.Proceed = false;
					this.Yandere.RPGCamera.enabled = false;
					this.PromptBar.Label[4].text = "Choose";
					this.PromptBar.Label[5].text = "Allocate";
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
					this.Class.StudyPoints = 5 - this.Late;
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
					this.HeartbeatCamera.active = true;
					this.Yandere.FixCamera();
					this.Yandere.RPGCamera.enabled = false;
					if (this.Clock.HourTime < (float)13)
					{
						this.Yandere.Incinerator.Timer = this.Yandere.Incinerator.Timer - ((float)780 - this.Clock.PresentTime);
						this.Clock.PresentTime = (float)780;
						this.Clock.Period = this.Clock.Period + 1;
					}
					else
					{
						this.Yandere.Incinerator.Timer = this.Yandere.Incinerator.Timer - (930f - this.Clock.PresentTime);
						this.Clock.PresentTime = 930f;
						this.Clock.Period = this.Clock.Period + 1;
					}
					this.Clock.HourTime = this.Clock.PresentTime / (float)60;
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
					this.Yandere.InClass = false;
					this.StudentManager.ResumeMovement();
				}
			}
		}
		if (this.Clock.HourTime > 15.5f)
		{
			if (this.transform.position.z > (float)0)
			{
				this.transform.position = new Vector3((float)0, (float)0, -49.5f);
				this.Prompt.Label[0].text = "     " + "Go Home";
			}
		}
		else if (this.InEvent || this.Yandere.Armed || this.Yandere.Bloodiness > (float)0 || this.Yandere.Sanity < 33.333f || this.Yandere.Attacking || this.Yandere.Dragging || this.Yandere.Chased || this.StudentManager.Reporter != null || this.Police.MurderScene || (this.Police.Corpses > 0 && !this.Police.SuicideScene && !this.Police.NaturalScene))
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		else
		{
			this.Prompt.enabled = true;
		}
		if (Input.GetKeyDown("7"))
		{
			this.Yandere.transform.position = this.transform.position;
		}
	}

	public virtual void Main()
	{
	}
}
