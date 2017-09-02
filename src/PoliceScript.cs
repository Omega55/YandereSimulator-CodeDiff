﻿using System;
using UnityEngine;

public class PoliceScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public ClubManagerScript ClubManager;

	public HeartbrokenScript Heartbroken;

	public PauseScreenScript PauseScreen;

	public ReputationScript Reputation;

	public TranqCaseScript TranqCase;

	public EndOfDayScript EndOfDay;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public ClockScript Clock;

	public UIPanel Panel;

	public GameObject HeartbeatCamera;

	public GameObject DetectionCamera;

	public GameObject Icons;

	public Transform BloodParent;

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

	public bool DrownScene;

	public bool TeacherReport;

	public bool ClubActivity;

	public bool MaskReported;

	public bool FadeResults;

	public bool ShowResults;

	public bool GameOver;

	public bool FadeOut;

	public bool Suicide;

	public bool Called;

	public bool Show;

	public int IncineratedWeapons;

	public int BloodyClothing;

	public int BloodyWeapons;

	public int MurderWeapons;

	public int HiddenCorpses;

	public int BodyParts;

	public int Witnesses;

	public int Corpses;

	public int Deaths;

	public float ResultsTimer;

	public float Timer;

	public int Minutes;

	public int Seconds;

	private void Start()
	{
		if (Globals.SchoolAtmosphere > 50f)
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
			if (this.PoisonScene)
			{
				this.Panel.alpha = 0f;
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
			this.Timer -= Time.deltaTime;
			if (this.Timer <= 0f)
			{
				this.Timer = 0f;
				if (!this.Yandere.Attacking && !this.Yandere.Struggling && !this.FadeOut)
				{
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
			}
			int num = Mathf.CeilToInt(this.Timer);
			this.Minutes = num / 60;
			this.Seconds = num % 60;
			this.TimeLabel.text = string.Format("{0:00}:{1:00}", this.Minutes, this.Seconds);
		}
		if (this.FadeOut)
		{
			if (this.Clock.TimeSkip || this.Yandere.CanMove)
			{
				if (this.Clock.TimeSkip)
				{
					this.Clock.EndTimeSkip();
				}
				this.Yandere.StopAiming();
				this.Yandere.StopLaughing();
				this.Yandere.CanMove = false;
				this.Yandere.YandereVision = false;
				this.Yandere.PauseScreen.enabled = false;
				this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_idleShort_00");
				for (int i = 1; i < 4; i++)
				{
					if (this.Yandere.Weapon[i] != null)
					{
					}
				}
			}
			this.PauseScreen.Panel.alpha = Mathf.MoveTowards(this.PauseScreen.Panel.alpha, 0f, Time.deltaTime);
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
			if (this.Darkness.color.a >= 1f && !this.ShowResults)
			{
				this.HeartbeatCamera.SetActive(false);
				this.DetectionCamera.SetActive(false);
				if (this.ClubActivity)
				{
					this.ClubManager.Club = Globals.Club;
					this.ClubManager.ClubActivity();
					this.FadeOut = false;
				}
				else
				{
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
				if (this.GameOver)
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
				else if (!this.TeacherReport)
				{
					if (this.EndOfDay.Phase == 1)
					{
						this.EndOfDay.gameObject.SetActive(true);
						this.EndOfDay.enabled = true;
						this.EndOfDay.Phase = 10;
						if (this.EndOfDay.PreviouslyActivated)
						{
							this.EndOfDay.Start();
						}
						for (int l = 0; l < 5; l++)
						{
							this.ResultsLabels[l].text = string.Empty;
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
		else if (Globals.Weekday == 5)
		{
			this.ResultsLabels[0].text = "This is the part where the game will determine whether or not the player has eliminated their rival.";
			this.ResultsLabels[1].text = "This game is still in development.";
			this.ResultsLabels[2].text = "The ''player eliminated rival'' state has not yet been implemented.";
			this.ResultsLabels[3].text = "Thank you for playtesting Yandere Simulator!";
			this.ResultsLabels[4].text = "Please check back soon for more updates!";
			this.GameOver = true;
		}
		else if (!this.Suicide && !this.PoisonScene)
		{
			if (this.Clock.HourTime < 18f)
			{
				if (!this.Yandere.InClass)
				{
					this.ResultsLabels[0].text = "Yandere-chan stands near the school gate and waits for Senpai to leave school.";
				}
				else
				{
					this.ResultsLabels[0].text = "Yandere-chan attempts to attend class without disposing of a corpse.";
				}
			}
			else
			{
				this.ResultsLabels[0].text = "The school day has ended. Teachers must walk through the school and tell any lingering students to leave.";
			}
			if (this.Corpses == 0 && this.BloodParent.childCount == 0 && this.BloodyWeapons == 0 && this.BloodyClothing == 0 && !this.SuicideScene)
			{
				if (this.Yandere.Sanity > 66.66666f && this.Yandere.Bloodiness == 0f)
				{
					if (this.Clock.HourTime < 18f)
					{
						this.ResultsLabels[1].text = "Finally, Senpai exits the school.";
						this.ResultsLabels[2].text = "Yandere-chan's heart skips a beat when she sees him.";
						this.ResultsLabels[3].text = "Yandere-chan leaves school and watches Senpai walk home.";
						this.ResultsLabels[4].text = "Once he is safely home, Yandere-chan returns to her own home.";
					}
					else
					{
						this.ResultsLabels[1].text = "Like all other students, Yandere-chan is instructed to leave school.";
						this.ResultsLabels[2].text = "Senpai leaves school, too.";
						this.ResultsLabels[3].text = "Yandere-chan leaves school and watches Senpai walk home.";
						this.ResultsLabels[4].text = "Once he is safely home, Yandere-chan returns to her own home.";
					}
				}
				else
				{
					this.ResultsLabels[1].text = "Yandere-chan is approached by a teacher.";
					if (this.Yandere.Bloodiness > 0f)
					{
						this.ResultsLabels[2].text = "The teacher immediately notices the blood staining her clothing.";
						this.ResultsLabels[3].text = "Yandere-chan is not able to convince the teacher that nothing is wrong.";
						this.ResultsLabels[4].text = "The teacher calls the police.";
						this.TeacherReport = true;
						this.Show = true;
					}
					else
					{
						this.ResultsLabels[2].text = "Yandere-chan exhibited extremely erratic behavior, frightening the teacher.";
						this.ResultsLabels[3].text = "The teacher becomes angry with Yandere-chan, but Yandere-chan leaves before the situation gets worse.";
						this.ResultsLabels[4].text = "Yandere-chan returns home.";
					}
				}
			}
			else if (this.Corpses == 0)
			{
				if (this.SuicideScene)
				{
					this.ResultsLabels[1].text = "While walking around the school, a teacher discovers a pair of shoes on the rooftop.";
					this.ResultsLabels[2].text = "The teachers fears that there has been a suicide, but cannot find a corpse anywhere. The teacher does not take any action.";
					this.ResultsLabels[3].text = "Yandere-chan leaves school and watches Senpai walk home.";
					this.ResultsLabels[4].text = "Once he is safely home, Yandere-chan returns to her own home.";
				}
				else if (this.BloodParent.childCount > 0 || this.BloodyClothing > 0)
				{
					if (this.BloodyWeapons == 0)
					{
						this.ResultsLabels[1].text = "While walking around the school, a teacher discovers a mysterious blood stain.";
						this.ResultsLabels[2].text = "The teacher decides to call the police.";
						this.ResultsLabels[3].text = "The teacher informs the rest of the faculty about her discovery.";
						this.ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
						this.TeacherReport = true;
						this.Show = true;
					}
					else
					{
						this.ResultsLabels[1].text = "While walking around the school, a teacher discovers a mysterious bloody weapon.";
						this.ResultsLabels[2].text = "The teacher decides to call the police.";
						this.ResultsLabels[3].text = "The teacher informs the rest of the faculty about her discovery.";
						this.ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
						this.TeacherReport = true;
						this.Show = true;
					}
				}
				else
				{
					this.ResultsLabels[1].text = "While walking around the school, a teacher discovers a mysterious bloody weapon.";
					this.ResultsLabels[2].text = "The teacher decides to call the police.";
					this.ResultsLabels[3].text = "The teacher informs the rest of the faculty about her discovery.";
					this.ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
					this.TeacherReport = true;
					this.Show = true;
				}
			}
			else
			{
				this.ResultsLabels[1].text = "While walking around the school, a teacher discovers a corpse.";
				this.ResultsLabels[2].text = "The teacher immediately calls the police.";
				this.ResultsLabels[3].text = "The teacher informs the rest of the faculty about her discovery.";
				this.ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
				this.TeacherReport = true;
				this.Show = true;
			}
		}
		else if (this.Suicide)
		{
			if (!this.Yandere.InClass)
			{
				this.ResultsLabels[0].text = "The school day has ended. Teachers must walk through the school and tell any lingering students to leave.";
			}
			else
			{
				this.ResultsLabels[0].text = "Yandere-chan attempts to attend class without disposing of a corpse.";
			}
			this.ResultsLabels[1].text = "While walking around the school, a teacher discovers a corpse.";
			this.ResultsLabels[2].text = "It appears as though a student has committed suicide.";
			this.ResultsLabels[3].text = "The teacher informs the rest of the faculty about her discovery.";
			this.ResultsLabels[4].text = "The faculty members agree to call the police and report the student's death.";
			this.TeacherReport = true;
			this.Show = true;
		}
		else if (this.PoisonScene)
		{
			this.ResultsLabels[0].text = "A teacher discovers the student who Yandere-chan poisoned.";
			this.ResultsLabels[1].text = "The teacher calls for an ambulance immediately.";
			this.ResultsLabels[2].text = "The teacher suspects that the student's death was a murder.";
			this.ResultsLabels[3].text = "The teacher also calls for the police.";
			this.ResultsLabels[4].text = "The school's students are not allowed to leave until a police investigation has taken place.";
			this.TeacherReport = true;
			this.Show = true;
		}
	}

	public void KillStudents()
	{
		float num = Globals.SchoolAtmosphere;
		if (this.Deaths > 0)
		{
			for (int i = 2; i < this.StudentManager.NPCsTotal + 1; i++)
			{
				if (Globals.GetStudentDying(i))
				{
					Globals.SetStudentDead(i, true);
					Globals.Kills++;
				}
			}
			num -= (float)this.Deaths * 5f;
			num -= (float)this.Corpses * 5f;
			Globals.SchoolAtmosphere = num;
		}
		else
		{
			num += 20f;
			Globals.SchoolAtmosphere = num;
		}
		Globals.SchoolAtmosphere = Mathf.Clamp(Globals.SchoolAtmosphere, 0f, 100f);
		for (int j = 1; j < this.StudentManager.StudentsTotal; j++)
		{
			StudentScript studentScript = this.StudentManager.Students[j];
			if (studentScript != null && studentScript.Grudge)
			{
				Globals.SetStudentGrudge(j, true);
			}
		}
	}
}
