﻿using System;
using UnityEngine;

public class PoliceScript : MonoBehaviour
{
	public LowRepGameOverScript LowRepGameOver;

	public StudentManagerScript StudentManager;

	public ClubManagerScript ClubManager;

	public HeartbrokenScript Heartbroken;

	public LoveManagerScript LoveManager;

	public PauseScreenScript PauseScreen;

	public ReputationScript Reputation;

	public TranqCaseScript TranqCase;

	public EndOfDayScript EndOfDay;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public ClockScript Clock;

	public JsonScript JSON;

	public UIPanel Panel;

	public GameObject HeartbeatCamera;

	public GameObject DetectionCamera;

	public GameObject SuicideStudent;

	public GameObject UICamera;

	public GameObject Icons;

	public GameObject FPS;

	public Transform BloodParent;

	public Transform LimbParent;

	public RagdollScript[] CorpseList;

	public UILabel[] ResultsLabels;

	public UILabel ContinueLabel;

	public UILabel TimeLabel;

	public UISprite ContinueButton;

	public UISprite Darkness;

	public UISprite BloodIcon;

	public UISprite UniformIcon;

	public UISprite WeaponIcon;

	public UISprite CorpseIcon;

	public UISprite PartsIcon;

	public UISprite SanityIcon;

	public string ElectrocutedStudentName = string.Empty;

	public string DrownedStudentName = string.Empty;

	public bool BloodDisposed;

	public bool UniformDisposed;

	public bool WeaponDisposed;

	public bool CorpseDisposed;

	public bool PartsDisposed;

	public bool SanityRestored;

	public bool MurderSuicideScene;

	public bool ElectroScene;

	public bool SuicideScene;

	public bool PoisonScene;

	public bool MurderScene;

	public bool BeginConfession;

	public bool TeacherReport;

	public bool ClubActivity;

	public bool CouncilDeath;

	public bool MaskReported;

	public bool FadeResults;

	public bool ShowResults;

	public bool GameOver;

	public bool DayOver;

	public bool Delayed;

	public bool FadeOut;

	public bool Suicide;

	public bool Called;

	public bool LowRep;

	public bool Show;

	public int IncineratedWeapons;

	public int BloodyClothing;

	public int BloodyWeapons;

	public int HiddenCorpses;

	public int MurderWeapons;

	public int PhotoEvidence;

	public int DrownVictims;

	public int BodyParts;

	public int Witnesses;

	public int Corpses;

	public int Deaths;

	public float ResultsTimer;

	public float Timer;

	public int Minutes;

	public int Seconds;

	public int SuspensionLength;

	public int RemainingDays;

	public bool Suspended;

	private void Start()
	{
		if (SchoolGlobals.SchoolAtmosphere > 0.5f)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 0f);
			this.Darkness.enabled = false;
		}
		base.transform.localPosition = new Vector3(-260f, base.transform.localPosition.y, base.transform.localPosition.z);
		foreach (UILabel uilabel in this.ResultsLabels)
		{
			uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0f);
		}
		this.ContinueLabel.color = new Color(this.ContinueLabel.color.r, this.ContinueLabel.color.g, this.ContinueLabel.color.b, 0f);
		this.ContinueButton.color = new Color(this.ContinueButton.color.r, this.ContinueButton.color.g, this.ContinueButton.color.b, 0f);
		this.Icons.SetActive(false);
	}

	private void Update()
	{
		if (this.Show)
		{
			this.StudentManager.TutorialWindow.ShowPoliceMessage = true;
			if (this.PoisonScene)
			{
			}
			if (!this.Icons.activeInHierarchy)
			{
				this.Icons.SetActive(true);
			}
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			if (this.BloodParent.childCount == 0)
			{
				if (!this.BloodDisposed)
				{
					this.BloodIcon.spriteName = "Yes";
					this.BloodDisposed = true;
				}
			}
			else if (this.BloodDisposed)
			{
				this.BloodIcon.spriteName = "No";
				this.BloodDisposed = false;
			}
			if (this.BloodyClothing == 0)
			{
				if (!this.UniformDisposed)
				{
					this.UniformIcon.spriteName = "Yes";
					this.UniformDisposed = true;
				}
			}
			else if (this.UniformDisposed)
			{
				this.UniformIcon.spriteName = "No";
				this.UniformDisposed = false;
			}
			if (this.IncineratedWeapons == this.MurderWeapons)
			{
				if (!this.WeaponDisposed)
				{
					this.WeaponIcon.spriteName = "Yes";
					this.WeaponDisposed = true;
				}
			}
			else if (this.WeaponDisposed)
			{
				this.WeaponIcon.spriteName = "No";
				this.WeaponDisposed = false;
			}
			if (this.Corpses == 0)
			{
				if (!this.CorpseDisposed)
				{
					this.CorpseIcon.spriteName = "Yes";
					this.CorpseDisposed = true;
				}
			}
			else if (this.CorpseDisposed)
			{
				this.CorpseIcon.spriteName = "No";
				this.CorpseDisposed = false;
			}
			if (this.BodyParts == 0)
			{
				if (!this.PartsDisposed)
				{
					this.PartsIcon.spriteName = "Yes";
					this.PartsDisposed = true;
				}
			}
			else if (this.PartsDisposed)
			{
				this.PartsIcon.spriteName = "No";
				this.PartsDisposed = false;
			}
			if (this.Yandere.Sanity == 100f)
			{
				if (!this.SanityRestored)
				{
					this.SanityIcon.spriteName = "Yes";
					this.SanityRestored = true;
				}
			}
			else if (this.SanityRestored)
			{
				this.SanityIcon.spriteName = "No";
				this.SanityRestored = false;
			}
			if (!this.Clock.StopTime)
			{
				this.Timer = Mathf.MoveTowards(this.Timer, 0f, Time.deltaTime);
			}
			if (this.Timer <= 0f)
			{
				this.Timer = 0f;
				if (!this.Yandere.Attacking && !this.Yandere.Struggling && !this.Yandere.Egg && !this.FadeOut)
				{
					this.BeginFadingOut();
				}
			}
			int num = Mathf.CeilToInt(this.Timer);
			this.Minutes = num / 60;
			this.Seconds = num % 60;
			this.TimeLabel.text = string.Format("{0:00}:{1:00}", this.Minutes, this.Seconds);
		}
		if (this.FadeOut)
		{
			if (this.Yandere.Laughing)
			{
				this.Yandere.StopLaughing();
			}
			if (this.Clock.TimeSkip || this.Yandere.CanMove)
			{
				if (this.Clock.TimeSkip)
				{
					this.Clock.EndTimeSkip();
				}
				this.Yandere.StopAiming();
				this.Yandere.CanMove = false;
				this.Yandere.YandereVision = false;
				this.Yandere.PauseScreen.enabled = false;
				this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_idleShort_00");
				if (this.Yandere.Mask != null)
				{
					this.Yandere.Mask.Drop();
				}
				if (this.Yandere.PickUp != null)
				{
					this.Yandere.EmptyHands();
				}
				if (this.Yandere.Dragging || this.Yandere.Carrying)
				{
					this.Yandere.EmptyHands();
				}
			}
			this.PauseScreen.Panel.alpha = Mathf.MoveTowards(this.PauseScreen.Panel.alpha, 0f, Time.deltaTime);
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
			if (this.Darkness.color.a >= 1f && !this.ShowResults)
			{
				this.HeartbeatCamera.SetActive(false);
				this.DetectionCamera.SetActive(false);
				if (this.ClubActivity)
				{
					this.ClubManager.Club = ClubGlobals.Club;
					this.ClubManager.ClubActivity();
					this.FadeOut = false;
				}
				else
				{
					this.Yandere.MyController.enabled = false;
					this.Yandere.enabled = false;
					this.DetermineResults();
					this.ShowResults = true;
					Time.timeScale = 2f;
					this.Jukebox.Volume = 0f;
				}
			}
		}
		if (this.ShowResults)
		{
			this.ResultsTimer += Time.deltaTime;
			if (this.ResultsTimer > 1f)
			{
				UILabel uilabel = this.ResultsLabels[0];
				uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, uilabel.color.a + Time.deltaTime);
			}
			if (this.ResultsTimer > 2f)
			{
				UILabel uilabel2 = this.ResultsLabels[1];
				uilabel2.color = new Color(uilabel2.color.r, uilabel2.color.g, uilabel2.color.b, uilabel2.color.a + Time.deltaTime);
			}
			if (this.ResultsTimer > 3f)
			{
				UILabel uilabel3 = this.ResultsLabels[2];
				uilabel3.color = new Color(uilabel3.color.r, uilabel3.color.g, uilabel3.color.b, uilabel3.color.a + Time.deltaTime);
			}
			if (this.ResultsTimer > 4f)
			{
				UILabel uilabel4 = this.ResultsLabels[3];
				uilabel4.color = new Color(uilabel4.color.r, uilabel4.color.g, uilabel4.color.b, uilabel4.color.a + Time.deltaTime);
			}
			if (this.ResultsTimer > 5f)
			{
				UILabel uilabel5 = this.ResultsLabels[4];
				uilabel5.color = new Color(uilabel5.color.r, uilabel5.color.g, uilabel5.color.b, uilabel5.color.a + Time.deltaTime);
			}
			if (this.ResultsTimer > 6f)
			{
				this.ContinueButton.color = new Color(this.ContinueButton.color.r, this.ContinueButton.color.g, this.ContinueButton.color.b, this.ContinueButton.color.a + Time.deltaTime);
				this.ContinueLabel.color = new Color(this.ContinueLabel.color.r, this.ContinueLabel.color.g, this.ContinueLabel.color.b, this.ContinueLabel.color.a + Time.deltaTime);
				if (this.ContinueButton.color.a > 1f)
				{
					this.ContinueButton.color = new Color(this.ContinueButton.color.r, this.ContinueButton.color.g, this.ContinueButton.color.b, 1f);
				}
				if (this.ContinueLabel.color.a > 1f)
				{
					this.ContinueLabel.color = new Color(this.ContinueLabel.color.r, this.ContinueLabel.color.g, this.ContinueLabel.color.b, 1f);
				}
			}
			if (Input.GetKeyDown("space"))
			{
				this.ShowResults = false;
				this.FadeResults = true;
				this.FadeOut = false;
				this.ResultsTimer = 0f;
			}
			if (this.ResultsTimer > 7f && Input.GetButtonDown("A"))
			{
				this.ShowResults = false;
				this.FadeResults = true;
				this.FadeOut = false;
				this.ResultsTimer = 0f;
			}
		}
		foreach (UILabel uilabel6 in this.ResultsLabels)
		{
			if (uilabel6.color.a > 1f)
			{
				uilabel6.color = new Color(uilabel6.color.r, uilabel6.color.g, uilabel6.color.b, 1f);
			}
		}
		if (this.FadeResults)
		{
			foreach (UILabel uilabel7 in this.ResultsLabels)
			{
				uilabel7.color = new Color(uilabel7.color.r, uilabel7.color.g, uilabel7.color.b, uilabel7.color.a - Time.deltaTime);
			}
			this.ContinueButton.color = new Color(this.ContinueButton.color.r, this.ContinueButton.color.g, this.ContinueButton.color.b, this.ContinueButton.color.a - Time.deltaTime);
			this.ContinueLabel.color = new Color(this.ContinueLabel.color.r, this.ContinueLabel.color.g, this.ContinueLabel.color.b, this.ContinueLabel.color.a - Time.deltaTime);
			if (this.ResultsLabels[0].color.a <= 0f)
			{
				if (this.BeginConfession)
				{
					this.LoveManager.Suitor = this.StudentManager.Students[1];
					this.LoveManager.Rival = this.StudentManager.Students[this.StudentManager.RivalID];
					this.LoveManager.Suitor.CharacterAnimation.enabled = true;
					this.LoveManager.Rival.CharacterAnimation.enabled = true;
					this.LoveManager.BeginConfession();
					Time.timeScale = 1f;
					base.enabled = false;
				}
				else if (this.GameOver)
				{
					this.Heartbroken.transform.parent.transform.parent = null;
					this.Heartbroken.transform.parent.gameObject.SetActive(true);
					this.Heartbroken.Noticed = false;
					base.transform.parent.transform.parent.gameObject.SetActive(false);
					if (!this.EndOfDay.gameObject.activeInHierarchy)
					{
						Time.timeScale = 1f;
					}
				}
				else if (this.LowRep)
				{
					this.Yandere.RPGCamera.enabled = false;
					this.Yandere.RPGCamera.transform.parent = this.LowRepGameOver.MyCamera;
					this.Yandere.RPGCamera.transform.localPosition = new Vector3(0f, 0f, 0f);
					this.Yandere.RPGCamera.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					this.LowRepGameOver.gameObject.SetActive(true);
					this.UICamera.SetActive(false);
					this.FPS.SetActive(false);
					Time.timeScale = 1f;
					base.enabled = false;
				}
				else if (!this.TeacherReport)
				{
					if (this.EndOfDay.Phase == 1)
					{
						this.EndOfDay.gameObject.SetActive(true);
						this.EndOfDay.enabled = true;
						this.EndOfDay.Phase = 14;
						if (this.EndOfDay.PreviouslyActivated)
						{
							this.EndOfDay.Start();
						}
						for (int k = 0; k < 5; k++)
						{
							this.ResultsLabels[k].text = string.Empty;
						}
						base.enabled = false;
					}
				}
				else
				{
					this.DetermineResults();
					this.TeacherReport = false;
					this.FadeResults = false;
					this.ShowResults = true;
				}
			}
		}
	}

	private void DetermineResults()
	{
		this.ResultsLabels[0].transform.parent.gameObject.SetActive(true);
		if (this.Show)
		{
			this.EndOfDay.gameObject.SetActive(true);
			base.enabled = false;
			for (int i = 0; i < 5; i++)
			{
				this.ResultsLabels[i].text = string.Empty;
			}
		}
		else if (this.Yandere.ShoulderCamera.GoingToCounselor)
		{
			this.ResultsLabels[0].text = "While Ayano was in the counselor's office,";
			this.ResultsLabels[1].text = "a corpse was discovered on school grounds.";
			this.ResultsLabels[2].text = "The school faculty was informed of the corpse,";
			this.ResultsLabels[3].text = "and the police were called to the school.";
			this.ResultsLabels[4].text = "No one is allowed to leave school until a police investigation has taken place.";
			this.TeacherReport = true;
			this.Show = true;
		}
		else if (this.Reputation.Reputation <= -100f)
		{
			this.ResultsLabels[0].text = "Ayano's bizarre conduct has been observed and discussed by many people.";
			this.ResultsLabels[1].text = "Word of Ayano's strange behavior has reached Senpai.";
			this.ResultsLabels[2].text = "Senpai is now aware that Ayano is a deranged person.";
			this.ResultsLabels[3].text = "From this day forward, Senpai will fear and avoid Ayano.";
			this.ResultsLabels[4].text = "Ayano will never have her Senpai's love.";
			this.LowRep = true;
		}
		else if (DateGlobals.Weekday == DayOfWeek.Friday)
		{
			bool flag = true;
			if (flag)
			{
				this.ResultsLabels[0].text = "This is the part where the game will determine whether or not the player has eliminated their rival.";
				this.ResultsLabels[1].text = "This game is still in development.";
				this.ResultsLabels[2].text = "The ''player eliminated rival'' state has not yet been implemented.";
				this.ResultsLabels[3].text = "Thank you for playtesting Yandere Simulator!";
				this.ResultsLabels[4].text = "Please check back soon for more updates!";
				this.GameOver = true;
			}
			else if (!this.StudentManager.RivalEliminated)
			{
				this.ResultsLabels[0].text = "Ayano has failed to eliminate Osana before Friday evening.";
				this.ResultsLabels[1].text = "Osana asks Senpai to meet her under the cherry tree behind the school.";
				this.ResultsLabels[2].text = "As cherry blossoms fall around them...";
				this.ResultsLabels[3].text = "...Osana confesses her feelings for Senpai.";
				this.ResultsLabels[4].text = "Ayano watches from a short distance away...";
				this.BeginConfession = true;
			}
			else
			{
				this.ResultsLabels[0].text = "Ayano no longer has to worry about competing with Osana for Senpai's love.";
				this.ResultsLabels[1].text = "Ayano considers confessing her love to Senpai...";
				this.ResultsLabels[2].text = "...but she cannot build up the courage to speak to him.";
				this.ResultsLabels[3].text = "Ayano waits until Senpai leaves school, and follows him until he is safe in his home.";
				this.ResultsLabels[4].text = "Then, Ayano returns to her own home, and considers what she should do next...";
			}
		}
		else if (!this.Suicide && !this.PoisonScene)
		{
			if (this.Clock.HourTime < 18f)
			{
				if (this.Yandere.InClass)
				{
					this.ResultsLabels[0].text = "Ayano attempts to attend class without disposing of a corpse.";
				}
				else if (this.Yandere.Resting && this.Corpses > 0)
				{
					this.ResultsLabels[0].text = "Ayano rests without disposing of a corpse.";
				}
				else if (this.Yandere.Resting)
				{
					if (GameGlobals.SenpaiMourning)
					{
						this.ResultsLabels[0].text = "Ayano recovers from her injuries.";
					}
					else
					{
						this.ResultsLabels[0].text = "Ayano recovers from her injuries, then stands near the school gate and waits for Senpai to leave school.";
					}
				}
				else if (GameGlobals.SenpaiMourning)
				{
					this.ResultsLabels[0].text = "Ayano decides to leave school.";
				}
				else
				{
					this.ResultsLabels[0].text = "Ayano stands near the school gate and waits for Senpai to leave school.";
				}
			}
			else
			{
				this.ResultsLabels[0].text = "The school day has ended. Faculty members must walk through the school and tell any lingering students to leave.";
			}
			if (this.Suspended)
			{
				if (this.Clock.Weekday == 1)
				{
					this.RemainingDays = 5;
				}
				else if (this.Clock.Weekday == 2)
				{
					this.RemainingDays = 4;
				}
				else if (this.Clock.Weekday == 3)
				{
					this.RemainingDays = 3;
				}
				else if (this.Clock.Weekday == 4)
				{
					this.RemainingDays = 2;
				}
				else if (this.Clock.Weekday == 5)
				{
					this.RemainingDays = 1;
				}
				if (this.RemainingDays - this.SuspensionLength <= 0)
				{
					this.ResultsLabels[0].text = "Due to her suspension,";
					this.ResultsLabels[1].text = "Ayano will be unable";
					this.ResultsLabels[2].text = "to prevent her rival";
					this.ResultsLabels[3].text = "from confessing to Senpai.";
					this.ResultsLabels[4].text = "Ayano will never have Senpai.";
					this.GameOver = true;
				}
				else if (this.SuspensionLength == 1)
				{
					this.ResultsLabels[0].text = "Ayano has been sent home early.";
					this.ResultsLabels[1].text = string.Empty;
					this.ResultsLabels[2].text = "She won't be able to see Senpai again until tomorrow.";
					this.ResultsLabels[3].text = string.Empty;
					this.ResultsLabels[4].text = "Ayano's heart aches as she thinks of Senpai.";
				}
				else if (this.SuspensionLength == 2)
				{
					this.ResultsLabels[0].text = "Ayano has been sent home early.";
					this.ResultsLabels[1].text = string.Empty;
					this.ResultsLabels[2].text = "She will have to wait one day before returning to school.";
					this.ResultsLabels[3].text = string.Empty;
					this.ResultsLabels[4].text = "Ayano's heart aches as she thinks of Senpai.";
				}
				else
				{
					this.ResultsLabels[0].text = "Ayano has been sent home early.";
					this.ResultsLabels[1].text = string.Empty;
					this.ResultsLabels[2].text = "She will have to wait " + (this.SuspensionLength - 1) + " days before returning to school.";
					this.ResultsLabels[3].text = string.Empty;
					this.ResultsLabels[4].text = "Ayano's heart aches as she thinks of Senpai.";
				}
			}
			else
			{
				if (this.Yandere.RedPaint)
				{
					this.BloodyClothing--;
				}
				if (this.Corpses == 0 && this.LimbParent.childCount == 0 && this.BloodParent.childCount == 0 && this.BloodyWeapons == 0 && this.BloodyClothing == 0 && !this.SuicideScene)
				{
					if (this.Yandere.Sanity < 66.66666f || (this.Yandere.Bloodiness > 0f && !this.Yandere.RedPaint))
					{
						this.ResultsLabels[1].text = "Ayano is approached by a faculty member.";
						if (this.Yandere.Bloodiness > 0f)
						{
							this.ResultsLabels[2].text = "The faculty member immediately notices the blood staining her clothing.";
							this.ResultsLabels[3].text = "Ayano is not able to convince the faculty member that nothing is wrong.";
							this.ResultsLabels[4].text = "The faculty member calls the police.";
							this.TeacherReport = true;
							this.Show = true;
						}
						else
						{
							this.ResultsLabels[2].text = "Ayano exhibited extremely erratic behavior, frightening the faculty member.";
							this.ResultsLabels[3].text = "The faculty member becomes angry with Ayano, but Ayano leaves before the situation gets worse.";
							this.ResultsLabels[4].text = "Ayano returns home.";
						}
					}
					else
					{
						if (this.Clock.HourTime < 18f)
						{
							this.ResultsLabels[1].text = "Finally, Senpai exits the school.";
							this.ResultsLabels[2].text = "Ayano's heart skips a beat when she sees him.";
							this.ResultsLabels[3].text = "Ayano leaves school and watches Senpai walk home.";
							this.ResultsLabels[4].text = "Once he is safely home, Ayano returns to her own home.";
						}
						else
						{
							this.ResultsLabels[1].text = "Like all other students, Ayano is instructed to leave school.";
							this.ResultsLabels[2].text = "Senpai leaves school, too.";
							this.ResultsLabels[3].text = "Ayano leaves school and watches Senpai walk home.";
							this.ResultsLabels[4].text = "Once he is safely home, Ayano returns to her own home.";
						}
						if (GameGlobals.SenpaiMourning)
						{
							this.ResultsLabels[1].text = "Like all other students, Ayano is instructed to leave school.";
							this.ResultsLabels[2].text = "Her heart aches as she thinks of senpai.";
							this.ResultsLabels[3].text = "Ayano leaves school.";
							this.ResultsLabels[4].text = "Ayano returns to her home.";
						}
					}
				}
				else if (this.Corpses > 0)
				{
					this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a corpse.";
					this.ResultsLabels[2].text = "The faculty member immediately calls the police.";
					this.ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
					this.ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
					this.TeacherReport = true;
					this.Show = true;
				}
				else if (this.LimbParent.childCount > 0)
				{
					this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a dismembered body part.";
					this.ResultsLabels[2].text = "The faculty member decides to call the police.";
					this.ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
					this.ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
					this.TeacherReport = true;
					this.Show = true;
				}
				else if (this.BloodParent.childCount > 0 || this.BloodyClothing > 0)
				{
					this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a mysterious blood stain.";
					this.ResultsLabels[2].text = "The faculty member decides to call the police.";
					this.ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
					this.ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
					this.TeacherReport = true;
					this.Show = true;
				}
				else if (this.BloodyWeapons > 0)
				{
					this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a mysterious bloody weapon.";
					this.ResultsLabels[2].text = "The faculty member decides to call the police.";
					this.ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
					this.ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
					this.TeacherReport = true;
					this.Show = true;
				}
				else if (this.SuicideScene)
				{
					this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a pair of shoes on the rooftop.";
					this.ResultsLabels[2].text = "The faculty member fears that there has been a suicide, but cannot find a corpse anywhere. The faculty member does not take any action.";
					this.ResultsLabels[3].text = "Ayano leaves school and watches Senpai walk home.";
					this.ResultsLabels[4].text = "Once he is safely home, Ayano returns to her own home.";
					if (GameGlobals.SenpaiMourning)
					{
						this.ResultsLabels[3].text = "Ayano leaves school.";
						this.ResultsLabels[4].text = "Ayano returns home.";
					}
				}
			}
		}
		else if (this.Suicide)
		{
			if (!this.Yandere.InClass)
			{
				this.ResultsLabels[0].text = "The school day has ended. Faculty members must walk through the school and tell any lingering students to leave.";
			}
			else
			{
				this.ResultsLabels[0].text = "Ayano attempts to attend class without disposing of a corpse.";
			}
			this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a corpse.";
			this.ResultsLabels[2].text = "It appears as though a student has committed suicide.";
			this.ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
			this.ResultsLabels[4].text = "The faculty members agree to call the police and report the student's death.";
			this.TeacherReport = true;
			this.Show = true;
		}
		else if (this.PoisonScene)
		{
			this.ResultsLabels[0].text = "A faculty member discovers the student who Ayano poisoned.";
			this.ResultsLabels[1].text = "The faculty member calls for an ambulance immediately.";
			this.ResultsLabels[2].text = "The faculty member suspects that the student's death was a murder.";
			this.ResultsLabels[3].text = "The faculty member also calls for the police.";
			this.ResultsLabels[4].text = "The school's students are not allowed to leave until a police investigation has taken place.";
			this.TeacherReport = true;
			this.Show = true;
		}
	}

	public void KillStudents()
	{
		if (this.Deaths > 0)
		{
			for (int i = 2; i < this.StudentManager.NPCsTotal + 1; i++)
			{
				if (StudentGlobals.GetStudentDying(i))
				{
					if (i < 90)
					{
						SchoolGlobals.SchoolAtmosphere -= 0.05f;
					}
					else
					{
						SchoolGlobals.SchoolAtmosphere -= 0.15f;
					}
					if (this.JSON.Students[i].Club == ClubType.Council)
					{
						SchoolGlobals.SchoolAtmosphere -= 1f;
						SchoolGlobals.HighSecurity = true;
					}
					StudentGlobals.SetStudentDead(i, true);
					PlayerGlobals.Kills++;
				}
			}
			SchoolGlobals.SchoolAtmosphere -= (float)this.Corpses * 0.05f;
			if (this.DrownVictims + this.Corpses > 0)
			{
				foreach (RagdollScript ragdollScript in this.CorpseList)
				{
					if (ragdollScript != null && StudentGlobals.MemorialStudents < 9)
					{
						StudentGlobals.MemorialStudents++;
						if (StudentGlobals.MemorialStudents == 1)
						{
							StudentGlobals.MemorialStudent1 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 2)
						{
							StudentGlobals.MemorialStudent2 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 3)
						{
							StudentGlobals.MemorialStudent3 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 4)
						{
							StudentGlobals.MemorialStudent4 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 5)
						{
							StudentGlobals.MemorialStudent5 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 6)
						{
							StudentGlobals.MemorialStudent6 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 7)
						{
							StudentGlobals.MemorialStudent7 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 8)
						{
							StudentGlobals.MemorialStudent8 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 9)
						{
							StudentGlobals.MemorialStudent9 = ragdollScript.Student.StudentID;
						}
					}
				}
			}
		}
		else if (!SchoolGlobals.HighSecurity)
		{
			SchoolGlobals.SchoolAtmosphere += 0.2f;
		}
		SchoolGlobals.SchoolAtmosphere = Mathf.Clamp01(SchoolGlobals.SchoolAtmosphere);
		for (int k = 1; k < this.StudentManager.StudentsTotal; k++)
		{
			StudentScript studentScript = this.StudentManager.Students[k];
			if (studentScript != null && studentScript.Grudge && studentScript.Persona != PersonaType.Evil)
			{
				StudentGlobals.SetStudentGrudge(k, true);
				if (studentScript.OriginalPersona == PersonaType.Sleuth && !StudentGlobals.GetStudentDying(k))
				{
					StudentGlobals.SetStudentGrudge(56, true);
					StudentGlobals.SetStudentGrudge(57, true);
					StudentGlobals.SetStudentGrudge(58, true);
					StudentGlobals.SetStudentGrudge(59, true);
					StudentGlobals.SetStudentGrudge(60, true);
				}
			}
		}
	}

	public void BeginFadingOut()
	{
		this.DayOver = true;
		this.StudentManager.StopMoving();
		this.Darkness.enabled = true;
		this.Yandere.StopLaughing();
		this.Clock.StopTime = true;
		this.FadeOut = true;
		if (!this.EndOfDay.gameObject.activeInHierarchy)
		{
			Time.timeScale = 1f;
		}
	}

	public void UpdateCorpses()
	{
		foreach (RagdollScript ragdollScript in this.CorpseList)
		{
			if (ragdollScript != null)
			{
				ragdollScript.Prompt.HideButton[3] = true;
				if (ClassGlobals.PhysicalGrade + ClassGlobals.PhysicalBonus > 0 && !ragdollScript.Tranquil)
				{
					ragdollScript.Prompt.HideButton[3] = false;
				}
			}
		}
	}
}
