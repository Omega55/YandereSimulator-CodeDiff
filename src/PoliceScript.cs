using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class PoliceScript : MonoBehaviour
{
	public HeartbrokenScript Heartbroken;

	public GameObject HeartbeatCamera;

	public GameObject DetectionCamera;

	public Transform BloodParent;

	public ReputationScript Reputation;

	public TranqCaseScript TranqCase;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public ClockScript Clock;

	public UILabel[] ResultsLabels;

	public UILabel ContinueLabel;

	public UILabel TimeLabel;

	public UISprite ContinueButton;

	public UISprite Darkness;

	public UISprite BloodIcon;

	public UISprite UniformIcon;

	public UISprite WeaponIcon;

	public UISprite CorpseIcon;

	public string Minutes;

	public string Seconds;

	public bool BloodDisposed;

	public bool UniformDisposed;

	public bool WeaponDisposed;

	public bool CorpseDisposed;

	public bool TeacherReport;

	public bool FadeResults;

	public bool ShowResults;

	public bool GameOver;

	public bool FadeOut;

	public int IncineratedWeapons;

	public int BloodyUniforms;

	public int BloodyWeapons;

	public int MurderWeapons;

	public int Witnesses;

	public int Corpses;

	public bool Show;

	public float ResultsTimer;

	public float Timer;

	public virtual void Start()
	{
		int num = 0;
		Color color = this.Darkness.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Darkness.color = color;
		int num3 = -255;
		Vector3 localPosition = this.transform.localPosition;
		float num4 = localPosition.x = (float)num3;
		Vector3 vector = this.transform.localPosition = localPosition;
		for (int i = 0; i < Extensions.get_length(this.ResultsLabels); i++)
		{
			int num5 = 0;
			Color color3 = this.ResultsLabels[i].color;
			float num6 = color3.a = (float)num5;
			Color color4 = this.ResultsLabels[i].color = color3;
		}
		int num7 = 0;
		Color color5 = this.ContinueLabel.color;
		float num8 = color5.a = (float)num7;
		Color color6 = this.ContinueLabel.color = color5;
		int num9 = 0;
		Color color7 = this.ContinueButton.color;
		float num10 = color7.a = (float)num9;
		Color color8 = this.ContinueButton.color = color7;
	}

	public virtual void Update()
	{
		if (this.Show)
		{
			float x = Mathf.Lerp(this.transform.localPosition.x, (float)0, Time.deltaTime * (float)10);
			Vector3 localPosition = this.transform.localPosition;
			float num = localPosition.x = x;
			Vector3 vector = this.transform.localPosition = localPosition;
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
			if (this.BloodyUniforms == 0)
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
			if (this.Timer > (float)0)
			{
				this.Timer -= Time.deltaTime;
				if (this.Timer <= (float)0)
				{
					Time.timeScale = (float)1;
					this.FadeOut = true;
					this.Timer = (float)0;
				}
			}
			this.Minutes = Mathf.Floor(this.Timer / (float)60).ToString("00");
			this.Seconds = (this.Timer % (float)60).ToString("00");
			this.TimeLabel.text = this.Minutes + ":" + this.Seconds;
		}
		if (this.FadeOut)
		{
			if (this.Clock.TimeSkip || this.Yandere.CanMove)
			{
				this.Clock.EndTimeSkip();
				this.Yandere.StopAiming();
				this.Yandere.CanMove = false;
				this.Yandere.YandereVision = false;
				this.Yandere.PauseScreen.enabled = false;
				this.Yandere.Character.animation.CrossFade("f02_idleShort_00");
				for (int i = 1; i < 4; i++)
				{
					if (this.Yandere.Weapon[i] != null)
					{
						this.Yandere.Weapon[i].Drop();
					}
				}
			}
			float a = this.Darkness.color.a + Time.deltaTime;
			Color color = this.Darkness.color;
			float num2 = color.a = a;
			Color color2 = this.Darkness.color = color;
			if (this.Darkness.color.a >= (float)1 && this.HeartbeatCamera.active)
			{
				this.HeartbeatCamera.active = false;
				this.DetectionCamera.active = false;
				this.DetermineResults();
				this.ShowResults = true;
				Time.timeScale = (float)2;
				this.Jukebox.Volume = (float)0;
			}
		}
		if (this.ShowResults)
		{
			this.ResultsTimer += Time.deltaTime;
			if (this.ResultsTimer > (float)1)
			{
				float a2 = this.ResultsLabels[0].color.a + Time.deltaTime;
				Color color3 = this.ResultsLabels[0].color;
				float num3 = color3.a = a2;
				Color color4 = this.ResultsLabels[0].color = color3;
			}
			if (this.ResultsTimer > (float)2)
			{
				float a3 = this.ResultsLabels[1].color.a + Time.deltaTime;
				Color color5 = this.ResultsLabels[1].color;
				float num4 = color5.a = a3;
				Color color6 = this.ResultsLabels[1].color = color5;
			}
			if (this.ResultsTimer > (float)3)
			{
				float a4 = this.ResultsLabels[2].color.a + Time.deltaTime;
				Color color7 = this.ResultsLabels[2].color;
				float num5 = color7.a = a4;
				Color color8 = this.ResultsLabels[2].color = color7;
			}
			if (this.ResultsTimer > (float)4)
			{
				float a5 = this.ResultsLabels[3].color.a + Time.deltaTime;
				Color color9 = this.ResultsLabels[3].color;
				float num6 = color9.a = a5;
				Color color10 = this.ResultsLabels[3].color = color9;
			}
			if (this.ResultsTimer > (float)5)
			{
				float a6 = this.ResultsLabels[4].color.a + Time.deltaTime;
				Color color11 = this.ResultsLabels[4].color;
				float num7 = color11.a = a6;
				Color color12 = this.ResultsLabels[4].color = color11;
			}
			if (this.ResultsTimer > (float)6)
			{
				float a7 = this.ContinueButton.color.a + Time.deltaTime;
				Color color13 = this.ContinueButton.color;
				float num8 = color13.a = a7;
				Color color14 = this.ContinueButton.color = color13;
				float a8 = this.ContinueLabel.color.a + Time.deltaTime;
				Color color15 = this.ContinueLabel.color;
				float num9 = color15.a = a8;
				Color color16 = this.ContinueLabel.color = color15;
				if (this.ContinueButton.color.a > (float)1)
				{
					int num10 = 1;
					Color color17 = this.ContinueButton.color;
					float num11 = color17.a = (float)num10;
					Color color18 = this.ContinueButton.color = color17;
				}
				if (this.ContinueLabel.color.a > (float)1)
				{
					int num12 = 1;
					Color color19 = this.ContinueLabel.color;
					float num13 = color19.a = (float)num12;
					Color color20 = this.ContinueLabel.color = color19;
				}
			}
			if (this.ResultsTimer > (float)7 && Input.GetButtonDown("A"))
			{
				this.ShowResults = false;
				this.FadeResults = true;
				this.FadeOut = false;
				this.ResultsTimer = (float)0;
			}
		}
		for (int i = 0; i < Extensions.get_length(this.ResultsLabels); i++)
		{
			if (this.ResultsLabels[i].color.a > (float)1)
			{
				int num14 = 1;
				Color color21 = this.ResultsLabels[i].color;
				float num15 = color21.a = (float)num14;
				Color color22 = this.ResultsLabels[i].color = color21;
			}
		}
		if (this.FadeResults)
		{
			for (int i = 0; i < Extensions.get_length(this.ResultsLabels); i++)
			{
				float a9 = this.ResultsLabels[i].color.a - Time.deltaTime;
				Color color23 = this.ResultsLabels[i].color;
				float num16 = color23.a = a9;
				Color color24 = this.ResultsLabels[i].color = color23;
			}
			float a10 = this.ContinueButton.color.a - Time.deltaTime;
			Color color25 = this.ContinueButton.color;
			float num17 = color25.a = a10;
			Color color26 = this.ContinueButton.color = color25;
			float a11 = this.ContinueLabel.color.a - Time.deltaTime;
			Color color27 = this.ContinueLabel.color;
			float num18 = color27.a = a11;
			Color color28 = this.ContinueLabel.color = color27;
			if (this.ResultsLabels[0].color.a <= (float)0)
			{
				if (this.GameOver)
				{
					this.Heartbroken.transform.parent.transform.parent = null;
					this.Heartbroken.transform.parent.active = true;
					this.Heartbroken.Noticed = false;
					this.transform.parent.transform.parent.gameObject.active = false;
					Time.timeScale = (float)1;
				}
				else if (!this.TeacherReport)
				{
					PlayerPrefs.SetFloat("Reputation", this.Reputation.Reputation);
					this.KillStudents();
					Application.LoadLevel("CalendarScene");
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

	public virtual void DetermineResults()
	{
		if (this.Show)
		{
			if (this.Yandere.Attacking)
			{
				this.ResultsLabels[0].text = "Soon after the police arrived, they witnessed Yandere-chan commiting murder.";
				this.ResultsLabels[1].text = "She was arrested on the spot.";
				this.ResultsLabels[2].text = "Shortly afterwards, Yandere-chan stood trial for murder.";
				this.ResultsLabels[3].text = "She was found guilty.";
				this.ResultsLabels[4].text = "Yandere-chan will never be able to confess her love to Senpai.";
				this.GameOver = true;
			}
			else
			{
				if (!this.TeacherReport)
				{
					this.ResultsLabels[0].text = "The police arrived at school, and informed the faculty that a crime may have taken place on school grounds. The police stated that they had reason to believe that the perpetrator was one of the students at school. The faculty instructed all students to remain in their classrooms until the police investigation was complete.";
				}
				else
				{
					this.ResultsLabels[0].text = "The school's faculty members inform the students that a murder has taken place on school grounds. The faculty instruct all students to remain at school and cooperate with the police to catch the killer. The police arrived at school, and begin their investigation.";
				}
				if (this.Corpses == 0 && this.BloodParent.childCount == 0 && this.BloodyWeapons == 0 && this.BloodyUniforms == 0)
				{
					this.ResultsLabels[1].text = "The police were unable to uncover any evidence of murder on school grounds.";
					if (this.Yandere.Sanity > 66.66666f && this.Yandere.Bloodiness == (float)0)
					{
						this.ResultsLabels[2].text = "The police questioned Yandere-chan, but were not able to link her to any crimes.";
						this.ResultsLabels[3].text = "Without any evidence that a murder had taken place, the police could take no action.";
						this.ResultsLabels[4].text = "After the police investigation ended, all of the students were sent home for the day.";
					}
					else if (this.Yandere.Bloodiness > (float)0)
					{
						this.ResultsLabels[2].text = "The police questioned Yandere-chan, and immediately noticed the blood staining her clothing. She was arrested on the spot.";
						this.ResultsLabels[3].text = "Word quickly circulated around school of Yandere-chan's misdeeds.";
						this.ResultsLabels[4].text = "Yandere-chan will never be able to confess her love to Senpai.";
						this.GameOver = true;
					}
					else
					{
						this.ResultsLabels[2].text = "The police questioned Yandere-chan, who exhibited extremely erratic behavior.";
						this.ResultsLabels[3].text = "However, without any evidence that a murder had taken place, the police could take no action against her.";
						this.ResultsLabels[4].text = "After the police investigation ended, all of the students were sent home for the day.";
					}
				}
				else if (this.Corpses == 0)
				{
					if (this.BloodParent.childCount > 0 || this.BloodyUniforms > 0)
					{
						if (this.BloodyWeapons == 0)
						{
							this.ResultsLabels[1].text = "The police were unable to discover any corpses or bloody weapons on school grounds, but did discover blood stains.";
							if (this.Yandere.Sanity > 66.66666f && this.Yandere.Bloodiness == (float)0)
							{
								this.ResultsLabels[2].text = "The police questioned Yandere-chan, but were not able to link her to the blood stains.";
								this.ResultsLabels[3].text = "Without any evidence that Yandere-chan had committed a criminal act, the police could not take action.";
								this.ResultsLabels[4].text = "After the police investigation ended, all of the students were sent home for the day.";
							}
							else if (this.Yandere.Bloodiness > (float)0)
							{
								this.ResultsLabels[2].text = "The police questioned Yandere-chan, and immediately noticed the blood staining her clothing.";
								this.ResultsLabels[3].text = "Yandere-chan was arrested on the spot.";
								this.ResultsLabels[4].text = "Yandere-chan will never be able to confess her love to Senpai.";
								this.GameOver = true;
							}
							else
							{
								this.ResultsLabels[2].text = "The police questioned Yandere-chan, who exhibited extremely erratic behavior.";
								this.ResultsLabels[3].text = "Under the circumstances, the police decided to take Yandere-chan into custody.";
								this.ResultsLabels[4].text = "Yandere-chan's crimes will eventually be uncovered, and she will never be able to confess her love to Senpai.";
								this.GameOver = true;
							}
						}
						else
						{
							this.ResultsLabels[1].text = "The police were unable to discover any corpses on school grounds, but were  able to locate a weapon that had been used for murder.";
							this.ResultsLabels[2].text = "As the suspect of a crime, Yandere-chan was required to give her biometric information to the police.";
							this.ResultsLabels[3].text = "The police quickly linked the murder weapon to Yandere-chan and arrested her.";
							this.ResultsLabels[4].text = "Yandere-chan will never be able to confess her love to Senpai.";
							this.GameOver = true;
						}
					}
					else if (this.BloodyWeapons == 0)
					{
						this.ResultsLabels[1].text = "The police were unable to discover any blood stains, corpses, or bloody weapons on school grounds.";
						if (this.Yandere.Sanity > 66.66666f && this.Yandere.Bloodiness == (float)0)
						{
							this.ResultsLabels[2].text = "The police questioned Yandere-chan, but did not consider her to be suspicious.";
							this.ResultsLabels[3].text = "Without any evidence that Yandere-chan had committed a criminal act, the police could not take action.";
							this.ResultsLabels[4].text = "After the police investigation ended, all of the students were sent home for the day.";
						}
						else if (this.Yandere.Bloodiness > (float)0)
						{
							this.ResultsLabels[2].text = "The police questioned Yandere-chan, and immediately noticed the blood staining her clothing.";
							this.ResultsLabels[3].text = "Yandere-chan was arrested on the spot.";
							this.ResultsLabels[4].text = "Yandere-chan will never be able to confess her love to Senpai.";
							this.GameOver = true;
						}
						else
						{
							this.ResultsLabels[2].text = "The police questioned Yandere-chan, who exhibited extremely erratic behavior.";
							this.ResultsLabels[3].text = "Under the circumstances, the police decided to take Yandere-chan into custody.";
							this.ResultsLabels[4].text = "Yandere-chan's crimes will eventually be uncovered, and she will never be able to confess her love to Senpai.";
							this.GameOver = true;
						}
					}
					else
					{
						this.ResultsLabels[1].text = "The police were unable to discover any blood stains or corpses on school grounds, but were  able to locate a weapon that had been used for murder.";
						this.ResultsLabels[2].text = "As the suspect of a crime, Yandere-chan was required to give her biometric information to the police.";
						this.ResultsLabels[3].text = "The police quickly linked the murder weapon to Yandere-chan and arrested her.";
						this.ResultsLabels[4].text = "Yandere-chan will never be able to confess her love to Senpai.";
						this.GameOver = true;
					}
				}
				else if (this.Corpses == 1)
				{
					if (this.BloodyWeapons == 0)
					{
						this.ResultsLabels[1].text = "The police quickly discovered a corpse on school grounds, but were unable to locate the murder weapon.";
						if (this.Yandere.Sanity > 66.66666f && this.Yandere.Bloodiness == (float)0)
						{
							this.ResultsLabels[2].text = "The police questioned Yandere-chan, but were not able to link her to the murder.";
							this.ResultsLabels[3].text = "Without any evidence that Yandere-chan had committed the murder, the police could not take action.";
							this.ResultsLabels[4].text = "After the police investigation ended, all of the students were sent home for the day.";
						}
						else if (this.Yandere.Bloodiness > (float)0)
						{
							this.ResultsLabels[2].text = "The police questioned Yandere-chan, and immediately noticed the blood staining her clothing.";
							this.ResultsLabels[3].text = "Yandere-chan was arrested on the spot.";
							this.ResultsLabels[4].text = "Yandere-chan will never be able to confess her love to Senpai.";
							this.GameOver = true;
						}
						else
						{
							this.ResultsLabels[2].text = "The police questioned Yandere-chan, who exhibited extremely erratic behavior.";
							this.ResultsLabels[3].text = "Under the circumstances, the police decided to take Yandere-chan into custody.";
							this.ResultsLabels[4].text = "Yandere-chan's crimes will eventually be uncovered, and she will never be able to confess her love to Senpai.";
							this.GameOver = true;
						}
					}
					else
					{
						this.ResultsLabels[1].text = "The police quickly discovered a corpse on school grounds, and were also able to locate a weapon that had been used for murder.";
						this.ResultsLabels[2].text = "As the suspect of a crime, Yandere-chan was required to give her biometric information to the police.";
						this.ResultsLabels[3].text = "The police quickly linked the murder weapon to Yandere-chan and arrested her.";
						this.ResultsLabels[4].text = "Yandere-chan will never be able to confess her love to Senpai.";
						this.GameOver = true;
					}
				}
				else if (this.BloodyWeapons == 0)
				{
					this.ResultsLabels[1].text = "The police quickly discovered multiple corpses on school grounds, but were unable to locate the murder weapon.";
					if (this.Yandere.Sanity > 66.66666f && this.Yandere.Bloodiness == (float)0)
					{
						this.ResultsLabels[2].text = "The police questioned Yandere-chan, but were not able to link her to the murders.";
						this.ResultsLabels[3].text = "Without any evidence that Yandere-chan had committed the murders, the police could not take action.";
						this.ResultsLabels[4].text = "After the police investigation ended, all of the students were sent home for the day.";
					}
					else if (this.Yandere.Bloodiness > (float)0)
					{
						this.ResultsLabels[2].text = "The police questioned Yandere-chan, and immediately noticed the blood staining her clothing.";
						this.ResultsLabels[3].text = "Yandere-chan was arrested on the spot.";
						this.ResultsLabels[4].text = "Yandere-chan will never be able to confess her love to Senpai.";
						this.GameOver = true;
					}
					else
					{
						this.ResultsLabels[2].text = "The police questioned Yandere-chan, who exhibited extremely erratic behavior.";
						this.ResultsLabels[3].text = "Under the circumstances, the police decided to take Yandere-chan into custody.";
						this.ResultsLabels[4].text = "Yandere-chan's crimes will eventually be uncovered, and she will never be able to confess her love to Senpai.";
						this.GameOver = true;
					}
				}
				else
				{
					this.ResultsLabels[1].text = "The police quickly discovered multiple corpses on school grounds, and were also able to locate a weapon that had been used for murder.";
					this.ResultsLabels[2].text = "As the suspect of a crime, Yandere-chan was required to give her biometric information to the police.";
					this.ResultsLabels[3].text = "The police quickly linked the murder weapon to Yandere-chan and arrested her.";
					this.ResultsLabels[4].text = "Yandere-chan will never be able to confess her love to Senpai.";
					this.GameOver = true;
				}
			}
		}
		else if (PlayerPrefs.GetInt("Weekday") == 5)
		{
			this.ResultsLabels[0].text = "Yandere-chan has failed to eliminate her rival before Friday evening.";
			this.ResultsLabels[1].text = "The girl asks Senpai to meet her under the cherry tree behind the school.";
			this.ResultsLabels[2].text = "As cherry blossoms fall around them, the girl confesses her feelings for Senpai.";
			this.ResultsLabels[3].text = "Senpai is deeply moved by the girl's heartfelt confession, and happily accepts her feelings.";
			this.ResultsLabels[4].text = "Yandere-chan watches tearfully as Senpai is stolen from her.";
			this.GameOver = true;
		}
		else if (!this.TranqCase.Occupied)
		{
			if (this.Clock.HourTime < (float)18)
			{
				this.ResultsLabels[0].text = "Yandere-chan stands near the school gate and waits for Senpai to leave school.";
			}
			else
			{
				this.ResultsLabels[0].text = "The school day has ended. Teachers must walk through the school and tell any lingering students to leave.";
			}
			if (this.Yandere.Attacking)
			{
				this.ResultsLabels[1].text = "Yandere-chan was spotted committing murder by a teacher.";
				this.ResultsLabels[2].text = "The teacher was able to flee the school and call the police.";
				this.ResultsLabels[3].text = "The police arrived at school, found evidence of Yandere-chan's murder, and arrested her.";
				this.ResultsLabels[4].text = "Yandere-chan will never be able to confess her love to Senpai.";
				this.GameOver = true;
			}
			else if (this.Corpses == 0 && this.BloodParent.childCount == 0 && this.BloodyWeapons == 0 && this.BloodyUniforms == 0)
			{
				if (this.Yandere.Sanity > 66.66666f && this.Yandere.Bloodiness == (float)0)
				{
					if (this.Clock.HourTime < (float)18)
					{
						this.ResultsLabels[1].text = "Finally, Senpai exits the school. Yandere-chan's heart skips a beat when she sees him.";
						this.ResultsLabels[2].text = "Yandere-chan leaves school and watches Senpai walk home.";
						this.ResultsLabels[3].text = "Once he is safely home, Yandere-chan returns to her own home.";
						this.ResultsLabels[4].text = "Yandere-chan goes to sleep, and dreams of Senpai...";
					}
					else
					{
						this.ResultsLabels[1].text = "Like all other students, Yandere-chan is instructed to leave school.";
						this.ResultsLabels[2].text = "Yandere-chan leaves school and watches Senpai walk home.";
						this.ResultsLabels[3].text = "Once he is safely home, Yandere-chan returns to her own home.";
						this.ResultsLabels[4].text = "Yandere-chan goes to sleep, and dreams of Senpai...";
					}
				}
				else
				{
					this.ResultsLabels[1].text = "Yandere-chan is approached by a teacher.";
					if (this.Yandere.Bloodiness > (float)0)
					{
						this.ResultsLabels[2].text = "The teacher immediately notices the blood staining her clothing.";
						this.ResultsLabels[3].text = "Yandere-chan is able to convince the teacher that nothing is wrong, and leaves returns home.";
						this.ResultsLabels[4].text = "Yandere-chan goes to sleep, and has a nightmare about losing Senpai...";
					}
					else
					{
						this.ResultsLabels[2].text = "Yandere-chan exhibited extremely erratic behavior, frightening the teacher.";
						this.ResultsLabels[3].text = "The teacher becomes angry with Yandere-chan, but she is able to return home without further incident.";
						this.ResultsLabels[4].text = "Yandere-chan goes to sleep, and has a nightmare about losing Senpai...";
					}
				}
			}
			else if (this.Corpses == 0)
			{
				if (this.BloodParent.childCount > 0 || this.BloodyUniforms > 0)
				{
					if (this.BloodyWeapons == 0)
					{
						this.ResultsLabels[1].text = "While walking around the school, a teacher discovers a mysterious blood stain.";
						this.ResultsLabels[2].text = "The teacher can't decide what to do about it, and does not take any action.";
						this.ResultsLabels[3].text = "Yandere-chan leaves school and returns to her home without incident.";
						this.ResultsLabels[4].text = "Yandere-chan goes to sleep, and has a nightmare about losing Senpai...";
					}
					else
					{
						this.ResultsLabels[1].text = "While walking around the school, a teacher discovers a mysterious bloody weapon.";
						this.ResultsLabels[2].text = "The teacher can't decide what to do about it, and does not take any action.";
						this.ResultsLabels[3].text = "Yandere-chan leaves school and returns to her home without incident.";
						this.ResultsLabels[4].text = "Yandere-chan goes to sleep, and has a nightmare about losing Senpai...";
					}
				}
				else
				{
					this.ResultsLabels[1].text = "While walking around the school, a teacher discovers a mysterious bloody weapon.";
					this.ResultsLabels[2].text = "The teacher can't decide what to do about it, and does not take any action.";
					this.ResultsLabels[3].text = "Yandere-chan leaves school and returns to her home without incident.";
					this.ResultsLabels[4].text = "Yandere-chan goes to sleep, and has a nightmare about losing Senpai...";
				}
			}
			else
			{
				this.ResultsLabels[1].text = "Yandere-chan did not clean up after herself after committing murder.";
				this.ResultsLabels[2].text = "While walking around the school, a teacher discovers a corpse.";
				this.ResultsLabels[3].text = "The teacher informs the rest of the faculty about his discovery.";
				this.ResultsLabels[4].text = "The faculty members agree to call the police and report the corpse.";
				this.TeacherReport = true;
				this.Show = true;
			}
		}
		else
		{
			this.ResultsLabels[0].text = "Yandere-chan leaves school, returns home, and waits until the clock strikes midnight.";
			this.ResultsLabels[1].text = "Under the cover of darkness, Yandere-chan travels back to school and sneaks inside of the gym.";
			this.ResultsLabels[2].text = "Yandere-chan returns to the instrument case that carries her unconscious victim.";
			this.ResultsLabels[3].text = "She pushes the case back to her house, pretending to be a young musician returning home from a show.";
			this.ResultsLabels[4].text = "Yandere-chan drags the case down to her basement and ties up her victim.";
			PlayerPrefs.SetInt("Kidnapped", 1);
		}
	}

	public virtual void KillStudents()
	{
		for (int i = 1; i < 20; i++)
		{
			PlayerPrefs.SetInt("Student_" + i + "_Dead", PlayerPrefs.GetInt("Student_" + i + "_Dying"));
		}
	}

	public virtual void Main()
	{
	}
}
