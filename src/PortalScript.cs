using System;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
	public RivalMorningEventManagerScript[] MorningEvents;

	public DelinquentManagerScript DelinquentManager;

	public StudentManagerScript StudentManager;

	public ReputationScript Reputation;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public PoliceScript Police;

	public PromptScript Prompt;

	public ClassScript Class;

	public ClockScript Clock;

	public GameObject HeartbeatCamera;

	public GameObject Headmaster;

	public UISprite ClassDarkness;

	public Transform Teacher;

	public bool LateReport1;

	public bool LateReport2;

	public bool Transition;

	public bool FadeOut;

	public bool Proceed;

	public int Late;

	private void Start()
	{
		this.ClassDarkness.enabled = false;
	}

	private void Update()
	{
		if (this.Clock.HourTime > 8.52f && this.Clock.HourTime < 8.53f && !this.Yandere.InClass && !this.LateReport1)
		{
			this.LateReport1 = true;
			this.Yandere.NotificationManager.DisplayNotification(NotificationType.Late);
		}
		if (this.Clock.HourTime > 13.52f && this.Clock.HourTime < 13.53f && !this.Yandere.InClass && !this.LateReport2)
		{
			this.LateReport2 = true;
			this.Yandere.NotificationManager.DisplayNotification(NotificationType.Late);
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.CheckForLateness();
			this.Reputation.UpdateRep();
			if (this.Police.PoisonScene || (this.Police.SuicideScene && this.Police.Corpses - this.Police.HiddenCorpses > 0) || this.Police.Corpses - this.Police.HiddenCorpses > 0 || this.Reputation.Reputation <= -100f)
			{
				this.EndDay();
			}
			else if (this.Clock.HourTime < 15.5f)
			{
				if (!this.Police.Show)
				{
					if (this.Late == 0)
					{
						this.ClassDarkness.enabled = true;
						this.Transition = true;
						this.FadeOut = true;
					}
					else
					{
						this.Yandere.Subtitle.UpdateLabel(SubtitleType.TeacherLateReaction, this.Late, 5.5f);
						this.Yandere.RPGCamera.enabled = false;
						this.Yandere.ShoulderCamera.Scolding = true;
						this.Yandere.ShoulderCamera.Teacher = this.Teacher;
					}
					this.Clock.StopTime = true;
				}
				else
				{
					this.EndDay();
				}
			}
			else
			{
				this.EndDay();
			}
			this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_idleShort_00");
			this.Yandere.YandereVision = false;
			this.Yandere.CanMove = false;
			if (this.Clock.HourTime < 15.5f)
			{
				this.Yandere.InClass = true;
				for (int i = 0; i < this.MorningEvents.Length; i++)
				{
					if (this.MorningEvents[i].enabled)
					{
						this.MorningEvents[i].EndEvent();
					}
				}
			}
		}
		if (this.Transition)
		{
			if (this.FadeOut)
			{
				this.ClassDarkness.color = new Color(this.ClassDarkness.color.r, this.ClassDarkness.color.g, this.ClassDarkness.color.b, this.ClassDarkness.color.a + Time.deltaTime);
				if (this.ClassDarkness.color.a >= 1f)
				{
					if (this.Yandere.Armed)
					{
						this.Yandere.Unequip();
					}
					this.HeartbeatCamera.SetActive(false);
					this.ClassDarkness.color = new Color(this.ClassDarkness.color.r, this.ClassDarkness.color.g, this.ClassDarkness.color.b, 1f);
					this.FadeOut = false;
					this.Proceed = false;
					this.Yandere.RPGCamera.enabled = false;
					this.PromptBar.Label[4].text = "Choose";
					this.PromptBar.Label[5].text = "Allocate";
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
					this.Class.StudyPoints = ((PlayerGlobals.PantiesEquipped != 11) ? 5 : 10);
					this.Class.StudyPoints -= this.Late;
					this.Class.UpdateLabel();
					this.Class.gameObject.SetActive(true);
					this.Class.Show = true;
					if (this.Police.Show)
					{
						this.Police.Timer = 1E-06f;
					}
				}
			}
			else if (this.Proceed)
			{
				if (this.ClassDarkness.color.a >= 1f)
				{
					this.HeartbeatCamera.SetActive(true);
					this.Yandere.FixCamera();
					this.Yandere.RPGCamera.enabled = false;
					if (this.Clock.HourTime < 13f)
					{
						this.Yandere.Incinerator.Timer -= 780f - this.Clock.PresentTime;
						this.DelinquentManager.CheckTime();
						this.Clock.DeactivateTrespassZones();
						this.Clock.PresentTime = 780f;
						this.Clock.Period++;
					}
					else
					{
						this.Yandere.Incinerator.Timer -= 930f - this.Clock.PresentTime;
						this.DelinquentManager.CheckTime();
						this.Clock.DeactivateTrespassZones();
						this.Clock.PresentTime = 930f;
						this.Clock.Period++;
					}
					this.Clock.HourTime = this.Clock.PresentTime / 60f;
					this.StudentManager.AttendClass();
				}
				this.ClassDarkness.color = new Color(this.ClassDarkness.color.r, this.ClassDarkness.color.g, this.ClassDarkness.color.b, this.ClassDarkness.color.a - Time.deltaTime);
				if (this.ClassDarkness.color.a <= 0f)
				{
					this.ClassDarkness.enabled = false;
					this.ClassDarkness.color = new Color(this.ClassDarkness.color.r, this.ClassDarkness.color.g, this.ClassDarkness.color.b, 0f);
					this.Yandere.RPGCamera.enabled = true;
					this.Clock.StopTime = false;
					this.Yandere.CanMove = true;
					this.Transition = false;
					this.Yandere.InClass = false;
					this.StudentManager.ResumeMovement();
					if (!MissionModeGlobals.MissionMode)
					{
						if (this.Headmaster.activeInHierarchy)
						{
							this.Headmaster.SetActive(false);
						}
						else
						{
							this.Headmaster.SetActive(true);
						}
					}
				}
			}
		}
		if (this.Clock.HourTime > 15.5f)
		{
			if (base.transform.position.z < 0f)
			{
				this.StudentManager.RemovePapersFromDesks();
				if (!MissionModeGlobals.MissionMode)
				{
					base.transform.position = new Vector3(0f, 1f, -75f);
					this.Prompt.Label[0].text = "     Go Home";
					this.Prompt.enabled = true;
				}
				else
				{
					base.transform.position = new Vector3(0f, -10f, 0f);
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
			}
		}
		else if (this.Yandere.Armed || this.Yandere.Bloodiness > 0f || this.Yandere.Sanity < 33.333f || this.Yandere.Attacking || this.Yandere.Dragging || this.Yandere.Chased || this.StudentManager.Reporter != null || this.StudentManager.MurderTakingPlace)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		else
		{
			this.Prompt.enabled = true;
		}
	}

	public void EndDay()
	{
		this.StudentManager.StopMoving();
		this.Yandere.StopLaughing();
		this.Clock.StopTime = true;
		this.Police.Darkness.enabled = true;
		this.Police.FadeOut = true;
	}

	private void CheckForLateness()
	{
		if (this.StudentManager.Teachers[21] != null && this.StudentManager.Teachers[21].DistanceToDestination < 1f)
		{
			if (this.Clock.HourTime < 13f)
			{
				if (this.Clock.HourTime < 8.52f)
				{
					this.Late = 0;
				}
				else if (this.Clock.HourTime < 10f)
				{
					this.Late = 1;
				}
				else if (this.Clock.HourTime < 11f)
				{
					this.Late = 2;
				}
				else if (this.Clock.HourTime < 12f)
				{
					this.Late = 3;
				}
				else if (this.Clock.HourTime < 13f)
				{
					this.Late = 4;
				}
			}
			else if (this.Clock.HourTime < 13.52f)
			{
				this.Late = 0;
			}
			else if (this.Clock.HourTime < 14f)
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
			this.Reputation.PendingRep -= (float)(5 * this.Late);
		}
	}
}
