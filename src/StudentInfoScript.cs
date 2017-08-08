using System;
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
		this.NameLabel.text = this.JSON.StudentNames[ID];
		if (PlayerPrefs.GetInt("Student_" + ID.ToString() + "_Reputation") < 0)
		{
			this.ReputationLabel.text = PlayerPrefs.GetInt("Student_" + ID.ToString() + "_Reputation").ToString();
		}
		else if (PlayerPrefs.GetInt("Student_" + ID.ToString() + "_Reputation") > 0)
		{
			this.ReputationLabel.text = "+" + PlayerPrefs.GetInt("Student_" + ID.ToString() + "_Reputation").ToString();
		}
		else
		{
			this.ReputationLabel.text = "0";
		}
		this.ReputationBar.localPosition = new Vector3((float)PlayerPrefs.GetInt("Student_" + ID.ToString() + "_Reputation") * 0.96f, this.ReputationBar.localPosition.y, this.ReputationBar.localPosition.z);
		if (this.ReputationBar.localPosition.x > 96f)
		{
			this.ReputationBar.localPosition = new Vector3(96f, this.ReputationBar.localPosition.y, this.ReputationBar.localPosition.z);
		}
		if (this.ReputationBar.localPosition.x < -96f)
		{
			this.ReputationBar.localPosition = new Vector3(-96f, this.ReputationBar.localPosition.y, this.ReputationBar.localPosition.z);
		}
		if (this.JSON.StudentPersonas[ID] == PersonaType.Loner)
		{
			this.PersonaLabel.text = "Loner";
		}
		else if (this.JSON.StudentPersonas[ID] == PersonaType.TeachersPet)
		{
			this.PersonaLabel.text = "Teacher's Pet";
		}
		else if (this.JSON.StudentPersonas[ID] == PersonaType.Heroic)
		{
			this.PersonaLabel.text = "Heroic";
		}
		else if (this.JSON.StudentPersonas[ID] == PersonaType.Coward)
		{
			this.PersonaLabel.text = "Coward";
		}
		else if (this.JSON.StudentPersonas[ID] == PersonaType.Evil)
		{
			this.PersonaLabel.text = "Evil";
		}
		else if (this.JSON.StudentPersonas[ID] == PersonaType.SocialButterfly)
		{
			this.PersonaLabel.text = "Social Butterfly";
		}
		else if (this.JSON.StudentPersonas[ID] == PersonaType.Tsundere)
		{
			this.PersonaLabel.text = "Tsundere";
		}
		else if (this.JSON.StudentPersonas[ID] == PersonaType.Strict)
		{
			this.PersonaLabel.text = "Strict";
			if (this.JSON.StudentClubs[ID] == 101 && PlayerPrefs.GetInt("Student_" + ID.ToString() + "_Replaced") == 0)
			{
				this.PersonaLabel.text = "Friendly but Strict";
			}
		}
		else if (this.JSON.StudentPersonas[ID] == PersonaType.Nemesis)
		{
			this.PersonaLabel.text = "?????";
		}
		if (this.JSON.StudentCrushes[ID] == 0)
		{
			this.CrushLabel.text = "None";
		}
		else if (this.JSON.StudentCrushes[ID] == 99)
		{
			this.CrushLabel.text = "?????";
		}
		else
		{
			this.CrushLabel.text = this.JSON.StudentNames[this.JSON.StudentCrushes[ID]];
		}
		if (this.JSON.StudentClubs[ID] < 100)
		{
			this.OccupationLabel.text = "Club";
		}
		else
		{
			this.OccupationLabel.text = "Occupation";
		}
		if (this.JSON.StudentClubs[ID] < 100)
		{
			if (this.JSON.StudentClubs[ID] == 0)
			{
				this.ClubLabel.text = "No Club";
			}
			else if (this.JSON.StudentClubs[ID] == 1)
			{
				this.ClubLabel.text = "Cooking";
			}
			else if (this.JSON.StudentClubs[ID] == 2)
			{
				this.ClubLabel.text = "Drama";
			}
			else if (this.JSON.StudentClubs[ID] == 3)
			{
				this.ClubLabel.text = "Occult";
			}
			else if (this.JSON.StudentClubs[ID] == 4)
			{
				this.ClubLabel.text = "Art";
			}
			else if (this.JSON.StudentClubs[ID] == 5)
			{
				this.ClubLabel.text = "Light Music";
			}
			else if (this.JSON.StudentClubs[ID] == 6)
			{
				this.ClubLabel.text = "Martial Arts";
			}
			else if (this.JSON.StudentClubs[ID] == 7)
			{
				this.ClubLabel.text = "Photography";
			}
			else if (this.JSON.StudentClubs[ID] == 8)
			{
				this.ClubLabel.text = "Science";
			}
			else if (this.JSON.StudentClubs[ID] == 9)
			{
				this.ClubLabel.text = "Sports";
			}
			else if (this.JSON.StudentClubs[ID] == 10)
			{
				this.ClubLabel.text = "Gardening";
			}
			else if (this.JSON.StudentClubs[ID] == 11)
			{
				this.ClubLabel.text = "Gaming";
			}
			else if (this.JSON.StudentClubs[ID] == 99)
			{
				this.ClubLabel.text = "?????";
			}
			else if (this.JSON.StudentClubs[ID] == 100)
			{
				this.ClubLabel.text = "Teacher";
			}
			else if (this.JSON.StudentClubs[ID] == 101)
			{
				this.ClubLabel.text = "Gym Teacher";
			}
		}
		else if (this.JSON.StudentClasses[ID] == 11)
		{
			this.ClubLabel.text = "Teacher of Class 1-1";
		}
		else if (this.JSON.StudentClasses[ID] == 12)
		{
			this.ClubLabel.text = "Teacher of Class 1-2";
		}
		else if (this.JSON.StudentClasses[ID] == 21)
		{
			this.ClubLabel.text = "Teacher of Class 2-1";
		}
		else if (this.JSON.StudentClasses[ID] == 22)
		{
			this.ClubLabel.text = "Teacher of Class 2-2";
		}
		else if (this.JSON.StudentClasses[ID] == 31)
		{
			this.ClubLabel.text = "Teacher of Class 3-1";
		}
		else if (this.JSON.StudentClasses[ID] == 32)
		{
			this.ClubLabel.text = "Teacher of Class 3-2";
		}
		else if (this.JSON.StudentClasses[ID] == 0)
		{
			this.ClubLabel.text = "Gym Teacher";
		}
		if (PlayerPrefs.GetInt("Club_" + this.JSON.StudentClubs[ID].ToString() + "_Closed") == 1)
		{
			this.ClubLabel.text = "No Club";
		}
		if (this.JSON.StudentStrengths[ID] == 0)
		{
			this.StrengthLabel.text = "Incapable";
		}
		else if (this.JSON.StudentStrengths[ID] == 1)
		{
			this.StrengthLabel.text = "Very Weak";
		}
		else if (this.JSON.StudentStrengths[ID] == 2)
		{
			this.StrengthLabel.text = "Weak";
		}
		else if (this.JSON.StudentStrengths[ID] == 3)
		{
			this.StrengthLabel.text = "Strong";
		}
		else if (this.JSON.StudentStrengths[ID] == 4)
		{
			this.StrengthLabel.text = "Very Strong";
		}
		else if (this.JSON.StudentStrengths[ID] == 5)
		{
			this.StrengthLabel.text = "Martial Arts Master";
		}
		else if (this.JSON.StudentStrengths[ID] == 6)
		{
			this.StrengthLabel.text = "Extensive Training";
		}
		else if (this.JSON.StudentStrengths[ID] == 99)
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
			if (PlayerPrefs.GetInt("Student_" + ID.ToString() + "_Replaced") == 0)
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
				this.HomeInternet.PostLabels[1].text = this.JSON.StudentNames[this.CurrentStudent];
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
			PlayerPrefs.SetInt("Student_" + this.CurrentStudent.ToString() + "_Reputation", PlayerPrefs.GetInt("Student_" + this.CurrentStudent.ToString() + "_Reputation") + 10);
			this.UpdateInfo(this.CurrentStudent);
		}
		if (Input.GetKeyDown("-"))
		{
			PlayerPrefs.SetInt("Student_" + this.CurrentStudent.ToString() + "_Reputation", PlayerPrefs.GetInt("Student_" + this.CurrentStudent.ToString() + "_Reputation") - 10);
			this.UpdateInfo(this.CurrentStudent);
		}
	}

	private void UpdateAdditionalInfo(int ID)
	{
		if (ID == 7)
		{
			this.Strings[1] = ((PlayerPrefs.GetInt("Event1") != 1) ? "?????" : "May be a victim of domestic abuse.");
			this.Strings[2] = ((PlayerPrefs.GetInt("Event2") != 1) ? "?????" : "May be engaging in compensated dating in Shisuta Town.");
			this.InfoLabel.text = this.Strings[1] + "\n\n" + this.Strings[2];
		}
		else if (PlayerPrefs.GetInt("Student_" + ID.ToString() + "_Replaced") == 0)
		{
			if (this.JSON.StudentInfos[ID] == string.Empty)
			{
				this.InfoLabel.text = "No additional information is available at this time.";
			}
			else
			{
				this.InfoLabel.text = this.JSON.StudentInfos[ID];
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
			this.TopicIcons[i].spriteName = ((PlayerPrefs.GetInt("Topic_" + i.ToString() + "_Discovered") != 0) ? i : 0).ToString();
		}
		if (PlayerPrefs.GetInt("Topic_1_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[1].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[1].spriteName = this.OpinionSpriteNames[this.JSON.Topic1[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_2_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[2].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[2].spriteName = this.OpinionSpriteNames[this.JSON.Topic2[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_3_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[3].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[3].spriteName = this.OpinionSpriteNames[this.JSON.Topic3[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_4_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[4].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[4].spriteName = this.OpinionSpriteNames[this.JSON.Topic4[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_5_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[5].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[5].spriteName = this.OpinionSpriteNames[this.JSON.Topic5[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_6_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[6].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[6].spriteName = this.OpinionSpriteNames[this.JSON.Topic6[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_7_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[7].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[7].spriteName = this.OpinionSpriteNames[this.JSON.Topic7[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_8_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[8].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[8].spriteName = this.OpinionSpriteNames[this.JSON.Topic8[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_9_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[9].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[9].spriteName = this.OpinionSpriteNames[this.JSON.Topic9[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_10_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[10].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[10].spriteName = this.OpinionSpriteNames[this.JSON.Topic10[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_11_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[11].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[11].spriteName = this.OpinionSpriteNames[this.JSON.Topic11[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_12_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[12].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[12].spriteName = this.OpinionSpriteNames[this.JSON.Topic12[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_13_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[13].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[13].spriteName = this.OpinionSpriteNames[this.JSON.Topic13[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_14_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[14].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[14].spriteName = this.OpinionSpriteNames[this.JSON.Topic14[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_15_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[15].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[15].spriteName = this.OpinionSpriteNames[this.JSON.Topic15[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_16_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[16].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[16].spriteName = this.OpinionSpriteNames[this.JSON.Topic16[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_17_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[17].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[17].spriteName = this.OpinionSpriteNames[this.JSON.Topic17[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_18_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[18].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[18].spriteName = this.OpinionSpriteNames[this.JSON.Topic18[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_19_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[19].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[19].spriteName = this.OpinionSpriteNames[this.JSON.Topic19[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_20_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[20].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[20].spriteName = this.OpinionSpriteNames[this.JSON.Topic20[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_21_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[21].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[21].spriteName = this.OpinionSpriteNames[this.JSON.Topic21[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_22_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[22].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[22].spriteName = this.OpinionSpriteNames[this.JSON.Topic22[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_23_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[23].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[23].spriteName = this.OpinionSpriteNames[this.JSON.Topic23[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_24_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[24].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[24].spriteName = this.OpinionSpriteNames[this.JSON.Topic24[this.CurrentStudent]];
		}
		if (PlayerPrefs.GetInt("Topic_25_Student_" + this.CurrentStudent + "_Learned") == 0)
		{
			this.TopicOpinionIcons[25].spriteName = "Unknown";
		}
		else
		{
			this.TopicOpinionIcons[25].spriteName = this.OpinionSpriteNames[this.JSON.Topic25[this.CurrentStudent]];
		}
	}
}
