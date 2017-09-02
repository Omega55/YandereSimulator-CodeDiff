﻿using System;
using System.IO;
using UnityEngine;

public class StudentInfoScript : MonoBehaviour
{
	public StudentInfoMenuScript StudentInfoMenu;

	public StudentManagerScript StudentManager;

	public DialogueWheelScript DialogueWheel;

	public HomeInternetScript HomeInternet;

	public TopicManagerScript TopicManager;

	public PromptBarScript PromptBar;

	public ShutterScript Shutter;

	public JsonScript JSON;

	public Texture DefaultPortrait;

	public Texture BlankPortrait;

	public Texture InfoChan;

	public Transform ReputationBar;

	public GameObject Static;

	public GameObject Topics;

	public UILabel OccupationLabel;

	public UILabel ReputationLabel;

	public UILabel StrengthLabel;

	public UILabel PersonaLabel;

	public UILabel CrushLabel;

	public UILabel ClubLabel;

	public UILabel InfoLabel;

	public UILabel NameLabel;

	public UITexture Portrait;

	public string[] OpinionSpriteNames;

	public string[] Strings;

	public int CurrentStudent;

	public bool CustomPortraits;

	public bool Back;

	public UISprite[] TopicIcons;

	public UISprite[] TopicOpinionIcons;

	private void Start()
	{
		this.Topics.SetActive(false);
		if (File.Exists(Application.streamingAssetsPath + "/CustomPortraits.txt"))
		{
			string a = File.ReadAllText(Application.streamingAssetsPath + "/CustomPortraits.txt");
			if (a == "1")
			{
				this.CustomPortraits = true;
			}
		}
	}

	public void UpdateInfo(int ID)
	{
		StudentJson studentJson = this.JSON.Students[ID];
		this.NameLabel.text = studentJson.Name;
		if (Globals.GetStudentReputation(ID) < 0)
		{
			this.ReputationLabel.text = Globals.GetStudentReputation(ID).ToString();
		}
		else if (Globals.GetStudentReputation(ID) > 0)
		{
			this.ReputationLabel.text = "+" + Globals.GetStudentReputation(ID).ToString();
		}
		else
		{
			this.ReputationLabel.text = "0";
		}
		this.ReputationBar.localPosition = new Vector3((float)Globals.GetStudentReputation(ID) * 0.96f, this.ReputationBar.localPosition.y, this.ReputationBar.localPosition.z);
		if (this.ReputationBar.localPosition.x > 96f)
		{
			this.ReputationBar.localPosition = new Vector3(96f, this.ReputationBar.localPosition.y, this.ReputationBar.localPosition.z);
		}
		if (this.ReputationBar.localPosition.x < -96f)
		{
			this.ReputationBar.localPosition = new Vector3(-96f, this.ReputationBar.localPosition.y, this.ReputationBar.localPosition.z);
		}
		if (studentJson.Persona == PersonaType.Loner)
		{
			this.PersonaLabel.text = "Loner";
		}
		else if (studentJson.Persona == PersonaType.TeachersPet)
		{
			this.PersonaLabel.text = "Teacher's Pet";
		}
		else if (studentJson.Persona == PersonaType.Heroic)
		{
			this.PersonaLabel.text = "Heroic";
		}
		else if (studentJson.Persona == PersonaType.Coward)
		{
			this.PersonaLabel.text = "Coward";
		}
		else if (studentJson.Persona == PersonaType.Evil)
		{
			this.PersonaLabel.text = "Evil";
		}
		else if (studentJson.Persona == PersonaType.SocialButterfly)
		{
			this.PersonaLabel.text = "Social Butterfly";
		}
		else if (studentJson.Persona == PersonaType.Tsundere)
		{
			this.PersonaLabel.text = "Tsundere";
		}
		else if (studentJson.Persona == PersonaType.Strict)
		{
			this.PersonaLabel.text = "Strict";
			if (studentJson.Club == ClubType.GymTeacher && !Globals.GetStudentReplaced(ID))
			{
				this.PersonaLabel.text = "Friendly but Strict";
			}
		}
		else if (studentJson.Persona == PersonaType.Nemesis)
		{
			this.PersonaLabel.text = "?????";
		}
		if (studentJson.Crush == 0)
		{
			this.CrushLabel.text = "None";
		}
		else if (studentJson.Crush == 99)
		{
			this.CrushLabel.text = "?????";
		}
		else
		{
			this.CrushLabel.text = this.JSON.Students[studentJson.Crush].Name;
		}
		if (studentJson.Club < ClubType.Teacher)
		{
			this.OccupationLabel.text = "Club";
		}
		else
		{
			this.OccupationLabel.text = "Occupation";
		}
		if (studentJson.Club < ClubType.Teacher)
		{
			if (studentJson.Club == ClubType.None)
			{
				this.ClubLabel.text = "No Club";
			}
			else if (studentJson.Club == ClubType.Cooking)
			{
				this.ClubLabel.text = "Cooking";
			}
			else if (studentJson.Club == ClubType.Drama)
			{
				this.ClubLabel.text = "Drama";
			}
			else if (studentJson.Club == ClubType.Occult)
			{
				this.ClubLabel.text = "Occult";
			}
			else if (studentJson.Club == ClubType.Art)
			{
				this.ClubLabel.text = "Art";
			}
			else if (studentJson.Club == ClubType.LightMusic)
			{
				this.ClubLabel.text = "Light Music";
			}
			else if (studentJson.Club == ClubType.MartialArts)
			{
				this.ClubLabel.text = "Martial Arts";
			}
			else if (studentJson.Club == ClubType.Photography)
			{
				this.ClubLabel.text = "Photography";
			}
			else if (studentJson.Club == ClubType.Science)
			{
				this.ClubLabel.text = "Science";
			}
			else if (studentJson.Club == ClubType.Sports)
			{
				this.ClubLabel.text = "Sports";
			}
			else if (studentJson.Club == ClubType.Gardening)
			{
				this.ClubLabel.text = "Gardening";
			}
			else if (studentJson.Club == ClubType.Gaming)
			{
				this.ClubLabel.text = "Gaming";
			}
			else if (studentJson.Club == ClubType.Nemesis)
			{
				this.ClubLabel.text = "?????";
			}
		}
		else if (studentJson.Class == 11)
		{
			this.ClubLabel.text = "Teacher of Class 1-1";
		}
		else if (studentJson.Class == 12)
		{
			this.ClubLabel.text = "Teacher of Class 1-2";
		}
		else if (studentJson.Class == 21)
		{
			this.ClubLabel.text = "Teacher of Class 2-1";
		}
		else if (studentJson.Class == 22)
		{
			this.ClubLabel.text = "Teacher of Class 2-2";
		}
		else if (studentJson.Class == 31)
		{
			this.ClubLabel.text = "Teacher of Class 3-1";
		}
		else if (studentJson.Class == 32)
		{
			this.ClubLabel.text = "Teacher of Class 3-2";
		}
		else if (studentJson.Class == 0)
		{
			this.ClubLabel.text = "Gym Teacher";
		}
		if (Globals.GetClubClosed(studentJson.Club))
		{
			this.ClubLabel.text = "No Club";
		}
		if (studentJson.Strength == 0)
		{
			this.StrengthLabel.text = "Incapable";
		}
		else if (studentJson.Strength == 1)
		{
			this.StrengthLabel.text = "Very Weak";
		}
		else if (studentJson.Strength == 2)
		{
			this.StrengthLabel.text = "Weak";
		}
		else if (studentJson.Strength == 3)
		{
			this.StrengthLabel.text = "Strong";
		}
		else if (studentJson.Strength == 4)
		{
			this.StrengthLabel.text = "Very Strong";
		}
		else if (studentJson.Strength == 5)
		{
			this.StrengthLabel.text = "Martial Arts Master";
		}
		else if (studentJson.Strength == 6)
		{
			this.StrengthLabel.text = "Extensive Training";
		}
		else if (studentJson.Strength == 99)
		{
			this.StrengthLabel.text = "?????";
		}
		AudioSource component = base.GetComponent<AudioSource>();
		if (ID > 0)
		{
			string url = string.Concat(new string[]
			{
				"file:///",
				Application.streamingAssetsPath,
				"/Portraits/Student_",
				ID.ToString(),
				".png"
			});
			WWW www = new WWW(url);
			if (!Globals.GetStudentReplaced(ID))
			{
				if (!this.CustomPortraits)
				{
					this.Portrait.mainTexture = ((ID >= 33 && ID <= 93) ? this.BlankPortrait : www.texture);
				}
				else
				{
					this.Portrait.mainTexture = www.texture;
				}
			}
			else
			{
				this.Portrait.mainTexture = this.BlankPortrait;
			}
			this.Static.SetActive(false);
			component.volume = 0f;
		}
		else
		{
			this.Portrait.mainTexture = this.InfoChan;
			this.Static.SetActive(true);
			if (!this.StudentInfoMenu.Gossiping && !this.StudentInfoMenu.Distracting && !this.StudentInfoMenu.CyberBullying)
			{
				component.enabled = true;
				component.volume = 1f;
				component.Play();
			}
		}
		this.UpdateAdditionalInfo(ID);
		this.CurrentStudent = ID;
	}

	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			if (this.StudentInfoMenu.Gossiping)
			{
				this.StudentInfoMenu.PauseScreen.MainMenu.SetActive(true);
				this.StudentInfoMenu.PauseScreen.Show = false;
				this.DialogueWheel.Victim = this.CurrentStudent;
				this.StudentInfoMenu.Gossiping = false;
				base.gameObject.SetActive(false);
				Time.timeScale = 1f;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
			}
			else if (this.StudentInfoMenu.Distracting)
			{
				this.StudentInfoMenu.PauseScreen.MainMenu.SetActive(true);
				this.StudentInfoMenu.PauseScreen.Show = false;
				this.DialogueWheel.Victim = this.CurrentStudent;
				this.StudentInfoMenu.Gossiping = false;
				base.gameObject.SetActive(false);
				Time.timeScale = 1f;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
			}
			else if (this.StudentInfoMenu.CyberBullying)
			{
				this.HomeInternet.PostLabels[1].text = this.JSON.Students[this.CurrentStudent].Name;
				this.HomeInternet.Student = this.CurrentStudent;
				this.StudentInfoMenu.PauseScreen.MainMenu.SetActive(true);
				this.StudentInfoMenu.PauseScreen.Show = false;
				this.StudentInfoMenu.CyberBullying = false;
				base.gameObject.SetActive(false);
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
			}
			else if (this.StudentInfoMenu.MatchMaking)
			{
				this.StudentInfoMenu.PauseScreen.MainMenu.SetActive(true);
				this.StudentInfoMenu.PauseScreen.Show = false;
				this.DialogueWheel.Victim = this.CurrentStudent;
				this.StudentInfoMenu.MatchMaking = false;
				base.gameObject.SetActive(false);
				Time.timeScale = 1f;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
			}
		}
		if (Input.GetButtonDown("B"))
		{
			this.Topics.SetActive(false);
			base.GetComponent<AudioSource>().Stop();
			if (this.Shutter != null)
			{
				if (!this.Shutter.PhotoIcons.activeInHierarchy)
				{
					this.Back = true;
				}
			}
			else
			{
				this.Back = true;
			}
			if (this.Back)
			{
				this.StudentInfoMenu.gameObject.SetActive(true);
				base.gameObject.SetActive(false);
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "View Info";
				if (!this.StudentInfoMenu.Gossiping)
				{
					this.PromptBar.Label[1].text = "Back";
				}
				this.PromptBar.UpdateButtons();
				this.Back = false;
			}
		}
		if (Input.GetButtonDown("Y") && this.PromptBar.Button[3].enabled)
		{
			if (!this.Topics.activeInHierarchy)
			{
				this.PromptBar.Label[3].text = "Basic Info";
				this.PromptBar.UpdateButtons();
				this.Topics.SetActive(true);
				this.UpdateTopics();
			}
			else
			{
				this.PromptBar.Label[3].text = "Interests";
				this.PromptBar.UpdateButtons();
				this.Topics.SetActive(false);
			}
		}
		if (Input.GetKeyDown("="))
		{
			Globals.SetStudentReputation(this.CurrentStudent, Globals.GetStudentReputation(this.CurrentStudent) + 10);
			this.UpdateInfo(this.CurrentStudent);
		}
		if (Input.GetKeyDown("-"))
		{
			Globals.SetStudentReputation(this.CurrentStudent, Globals.GetStudentReputation(this.CurrentStudent) - 10);
			this.UpdateInfo(this.CurrentStudent);
		}
	}

	private void UpdateAdditionalInfo(int ID)
	{
		if (ID == 7)
		{
			this.Strings[1] = ((!Globals.Event1) ? "?????" : "May be a victim of domestic abuse.");
			this.Strings[2] = ((!Globals.Event2) ? "?????" : "May be engaging in compensated dating in Shisuta Town.");
			this.InfoLabel.text = this.Strings[1] + "\n\n" + this.Strings[2];
		}
		else if (!Globals.GetStudentReplaced(ID))
		{
			if (this.JSON.Students[ID].Info == string.Empty)
			{
				this.InfoLabel.text = "No additional information is available at this time.";
			}
			else
			{
				this.InfoLabel.text = this.JSON.Students[ID].Info;
			}
		}
		else
		{
			this.InfoLabel.text = "No additional information is available at this time.";
		}
	}

	private void UpdateTopics()
	{
		for (int i = 1; i < this.TopicIcons.Length; i++)
		{
			this.TopicIcons[i].spriteName = (Globals.GetTopicDiscovered(i) ? i : 0).ToString();
		}
		for (int j = 1; j <= 25; j++)
		{
			UISprite uisprite = this.TopicOpinionIcons[j];
			if (!Globals.GetTopicLearnedByStudent(j, this.CurrentStudent))
			{
				uisprite.spriteName = "Unknown";
			}
			else
			{
				int[] topics = this.JSON.Topics[this.CurrentStudent].Topics;
				uisprite.spriteName = this.OpinionSpriteNames[topics[j]];
			}
		}
	}
}
