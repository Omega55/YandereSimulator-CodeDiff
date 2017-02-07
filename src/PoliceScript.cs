using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
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

	public string ElectrocutedStudentName;

	public string DrownedStudentName;

	public bool BloodDisposed;

	public bool UniformDisposed;

	public bool WeaponDisposed;

	public bool CorpseDisposed;

	public bool PartsDisposed;

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

	public PoliceScript()
	{
		this.ElectrocutedStudentName = string.Empty;
		this.DrownedStudentName = string.Empty;
	}

	public virtual void Start()
	{
		if (PlayerPrefs.GetFloat("SchoolAtmosphere") > (float)50)
		{
			int num = 0;
			Color color = this.Darkness.color;
			float num2 = color.a = (float)num;
			Color color2 = this.Darkness.color = color;
			this.Darkness.enabled = false;
		}
		int num3 = -260;
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
		this.Icons.active = false;
	}

	public virtual void Update()
	{
		if (this.Show)
		{
			if (this.PoisonScene)
			{
				this.Panel.alpha = (float)0;
			}
			if (!this.Icons.active)
			{
				this.Icons.active = true;
			}
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
			this.Timer -= Time.deltaTime;
			if (this.Timer <= (float)0)
			{
				this.Timer = (float)0;
				if (!this.Yandere.Attacking && !this.Yandere.Struggling && !this.FadeOut)
				{
					this.StudentManager.StopMoving();
					this.Darkness.enabled = true;
					this.Yandere.StopLaughing();
					this.Clock.StopTime = true;
					this.FadeOut = true;
					if (!this.EndOfDay.gameObject.active)
					{
						Time.timeScale = (float)1;
					}
				}
			}
			int num2 = Mathf.CeilToInt(this.Timer);
			this.Minutes = num2 / 60;
			this.Seconds = num2 % 60;
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
				this.Yandere.Character.animation.CrossFade("f02_idleShort_00");
				for (int i = 1; i < 4; i++)
				{
					if (this.Yandere.Weapon[i] != null)
					{
					}
				}
			}
			this.PauseScreen.Panel.alpha = Mathf.MoveTowards(this.PauseScreen.Panel.alpha, (float)0, Time.deltaTime);
			float a = this.Darkness.color.a + Time.deltaTime;
			Color color = this.Darkness.color;
			float num3 = color.a = a;
			Color color2 = this.Darkness.color = color;
			if (this.Darkness.color.a >= (float)1 && !this.ShowResults)
			{
				this.HeartbeatCamera.active = false;
				this.DetectionCamera.active = false;
				if (this.ClubActivity)
				{
					this.ClubManager.Club = PlayerPrefs.GetInt("Club");
					this.ClubManager.ClubActivity();
					this.FadeOut = false;
				}
				else
				{
					this.Yandere.enabled = false;
					this.DetermineResults();
					this.ShowResults = true;
					Time.timeScale = (float)2;
					this.Jukebox.Volume = (float)0;
				}
			}
		}
		if (this.ShowResults)
		{
			this.ResultsTimer += Time.deltaTime;
			if (this.ResultsTimer > (float)1)
			{
				float a2 = this.ResultsLabels[0].color.a + Time.deltaTime;
				Color color3 = this.ResultsLabels[0].color;
				float num4 = color3.a = a2;
				Color color4 = this.ResultsLabels[0].color = color3;
			}
			if (this.ResultsTimer > (float)2)
			{
				float a3 = this.ResultsLabels[1].color.a + Time.deltaTime;
				Color color5 = this.ResultsLabels[1].color;
				float num5 = color5.a = a3;
				Color color6 = this.ResultsLabels[1].color = color5;
			}
			if (this.ResultsTimer > (float)3)
			{
				float a4 = this.ResultsLabels[2].color.a + Time.deltaTime;
				Color color7 = this.ResultsLabels[2].color;
				float num6 = color7.a = a4;
				Color color8 = this.ResultsLabels[2].color = color7;
			}
			if (this.ResultsTimer > (float)4)
			{
				float a5 = this.ResultsLabels[3].color.a + Time.deltaTime;
				Color color9 = this.ResultsLabels[3].color;
				float num7 = color9.a = a5;
				Color color10 = this.ResultsLabels[3].color = color9;
			}
			if (this.ResultsTimer > (float)5)
			{
				float a6 = this.ResultsLabels[4].color.a + Time.deltaTime;
				Color color11 = this.ResultsLabels[4].color;
				float num8 = color11.a = a6;
				Color color12 = this.ResultsLabels[4].color = color11;
			}
			if (this.ResultsTimer > (float)6)
			{
				float a7 = this.ContinueButton.color.a + Time.deltaTime;
				Color color13 = this.ContinueButton.color;
				float num9 = color13.a = a7;
				Color color14 = this.ContinueButton.color = color13;
				float a8 = this.ContinueLabel.color.a + Time.deltaTime;
				Color color15 = this.ContinueLabel.color;
				float num10 = color15.a = a8;
				Color color16 = this.ContinueLabel.color = color15;
				if (this.ContinueButton.color.a > (float)1)
				{
					int num11 = 1;
					Color color17 = this.ContinueButton.color;
					float num12 = color17.a = (float)num11;
					Color color18 = this.ContinueButton.color = color17;
				}
				if (this.ContinueLabel.color.a > (float)1)
				{
					int num13 = 1;
					Color color19 = this.ContinueLabel.color;
					float num14 = color19.a = (float)num13;
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
				int num15 = 1;
				Color color21 = this.ResultsLabels[i].color;
				float num16 = color21.a = (float)num15;
				Color color22 = this.ResultsLabels[i].color = color21;
			}
		}
		if (this.FadeResults)
		{
			for (int i = 0; i < Extensions.get_length(this.ResultsLabels); i++)
			{
				float a9 = this.ResultsLabels[i].color.a - Time.deltaTime;
				Color color23 = this.ResultsLabels[i].color;
				float num17 = color23.a = a9;
				Color color24 = this.ResultsLabels[i].color = color23;
			}
			float a10 = this.ContinueButton.color.a - Time.deltaTime;
			Color color25 = this.ContinueButton.color;
			float num18 = color25.a = a10;
			Color color26 = this.ContinueButton.color = color25;
			float a11 = this.ContinueLabel.color.a - Time.deltaTime;
			Color color27 = this.ContinueLabel.color;
			float num19 = color27.a = a11;
			Color color28 = this.ContinueLabel.color = color27;
			if (this.ResultsLabels[0].color.a <= (float)0)
			{
				if (this.GameOver)
				{
					this.Heartbroken.transform.parent.transform.parent = null;
					this.Heartbroken.transform.parent.active = true;
					this.Heartbroken.Noticed = false;
					this.transform.parent.transform.parent.gameObject.active = false;
					if (!this.EndOfDay.gameObject.active)
					{
						Time.timeScale = (float)1;
					}
				}
				else if (!this.TeacherReport)
				{
					if (this.EndOfDay.Phase == 1)
					{
						this.EndOfDay.gameObject.active = true;
						this.EndOfDay.enabled = true;
						this.EndOfDay.Phase = 10;
						if (this.EndOfDay.PreviouslyActivated)
						{
							this.EndOfDay.Start();
						}
						this.ResultsLabels[0].text = string.Empty;
						this.ResultsLabels[1].text = string.Empty;
						this.ResultsLabels[2].text = string.Empty;
						this.ResultsLabels[3].text = string.Empty;
						this.ResultsLabels[4].text = string.Empty;
						this.enabled = false;
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

	public virtual void DetermineResults()
	{
		this.ResultsLabels[0].transform.parent.gameObject.active = true;
		if (this.Show)
		{
			this.EndOfDay.gameObject.active = true;
			this.enabled = false;
			this.ResultsLabels[0].text = string.Empty;
			this.ResultsLabels[1].text = string.Empty;
			this.ResultsLabels[2].text = string.Empty;
			this.ResultsLabels[3].text = string.Empty;
			this.ResultsLabels[4].text = string.Empty;
		}
		else if (PlayerPrefs.GetInt("Weekday") == 5)
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
			if (this.Clock.HourTime < (float)18)
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
				if (this.Yandere.Sanity > 66.66666f && this.Yandere.Bloodiness == (float)0)
				{
					if (this.Clock.HourTime < (float)18)
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
					if (this.Yandere.Bloodiness > (float)0)
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

	public virtual void KillStudents()
	{
		float num = PlayerPrefs.GetFloat("SchoolAtmosphere");
		if (this.Deaths > 0)
		{
			for (int i = 2; i < this.StudentManager.NPCsTotal + 1; i++)
			{
				if (PlayerPrefs.GetInt("Student_" + i + "_Dying") == 1)
				{
					PlayerPrefs.SetInt("Student_" + i + "_Dead", 1);
				}
			}
			num -= (float)(this.Deaths * 5);
			num -= (float)(this.Corpses * 5);
			PlayerPrefs.SetFloat("SchoolAtmosphere", num);
		}
		else
		{
			num += (float)20;
			PlayerPrefs.SetFloat("SchoolAtmosphere", num);
		}
		if (PlayerPrefs.GetFloat("SchoolAtmosphere") < (float)0)
		{
			PlayerPrefs.SetFloat("SchoolAtmosphere", (float)0);
		}
		if (PlayerPrefs.GetFloat("SchoolAtmosphere") > (float)100)
		{
			PlayerPrefs.SetFloat("SchoolAtmosphere", (float)100);
		}
		for (int i = 1; i < this.StudentManager.StudentsTotal; i++)
		{
			if (this.StudentManager.Students[i] != null && this.StudentManager.Students[i].Grudge)
			{
				PlayerPrefs.SetInt("Student_" + i + "_Grudge", 1);
			}
		}
	}

	public virtual void Main()
	{
	}
}
