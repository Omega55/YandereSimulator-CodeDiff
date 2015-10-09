using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class StudentInfoScript : MonoBehaviour
{
	public StudentInfoMenuScript StudentInfoMenu;

	public DialogueWheelScript DialogueWheel;

	public HomeInternetScript HomeInternet;

	public PromptBarScript PromptBar;

	public ShutterScript Shutter;

	public JsonScript JSON;

	public Texture DefaultPortrait;

	public Texture InfoChan;

	public Transform ReputationBar;

	public GameObject Static;

	public UILabel ReputationLabel;

	public UILabel PersonaLabel;

	public UILabel CrushLabel;

	public UILabel ClubLabel;

	public UILabel InfoLabel;

	public UILabel NameLabel;

	public UITexture Portrait;

	public string[] Strings;

	public int CurrentStudent;

	public bool Back;

	public virtual void UpdateInfo(int ID)
	{
		this.NameLabel.text = this.JSON.StudentNames[ID];
		if (this.JSON.StudentClubs[ID] == 0)
		{
			this.ClubLabel.text = "No Club";
		}
		else if (this.JSON.StudentClubs[ID] == 1)
		{
			this.ClubLabel.text = "Martial Arts";
		}
		else if (this.JSON.StudentClubs[ID] == 2)
		{
			this.ClubLabel.text = "Light Music";
		}
		else if (this.JSON.StudentClubs[ID] == 3)
		{
			this.ClubLabel.text = "Photography";
		}
		else if (this.JSON.StudentClubs[ID] == 4)
		{
			this.ClubLabel.text = "Gardening";
		}
		else if (this.JSON.StudentClubs[ID] == 5)
		{
			this.ClubLabel.text = "Computer";
		}
		else if (this.JSON.StudentClubs[ID] == 6)
		{
			this.ClubLabel.text = "Sports";
		}
		else if (this.JSON.StudentClubs[ID] == 7)
		{
			this.ClubLabel.text = "Gaming";
		}
		else if (this.JSON.StudentClubs[ID] == 9)
		{
			this.ClubLabel.text = "Faculty";
		}
		else if (this.JSON.StudentClubs[ID] == 99)
		{
			this.ClubLabel.text = "?????";
		}
		if (this.JSON.StudentPersonas[ID] == 1)
		{
			this.PersonaLabel.text = "Coward";
		}
		else if (this.JSON.StudentPersonas[ID] == 2)
		{
			this.PersonaLabel.text = "Teacher's Pet";
		}
		else if (this.JSON.StudentPersonas[ID] == 9)
		{
			this.PersonaLabel.text = "Strict";
		}
		else if (this.JSON.StudentPersonas[ID] == 99)
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
			this.CrushLabel.text = string.Empty + this.JSON.StudentNames[this.JSON.StudentCrushes[ID]];
		}
		if (PlayerPrefs.GetInt("Student_" + ID + "_Reputation") < 0)
		{
			this.ReputationLabel.text = string.Empty + PlayerPrefs.GetInt("Student_" + ID + "_Reputation");
		}
		else if (PlayerPrefs.GetInt("Student_" + ID + "_Reputation") > 0)
		{
			this.ReputationLabel.text = "+" + PlayerPrefs.GetInt("Student_" + ID + "_Reputation");
		}
		else
		{
			this.ReputationLabel.text = "0";
		}
		float x = (float)PlayerPrefs.GetInt("Student_" + ID + "_Reputation") * 0.96f;
		Vector3 localPosition = this.ReputationBar.localPosition;
		float num = localPosition.x = x;
		Vector3 vector = this.ReputationBar.localPosition = localPosition;
		if (this.ReputationBar.localPosition.x > (float)96)
		{
			int num2 = 96;
			Vector3 localPosition2 = this.ReputationBar.localPosition;
			float num3 = localPosition2.x = (float)num2;
			Vector3 vector2 = this.ReputationBar.localPosition = localPosition2;
		}
		if (this.ReputationBar.localPosition.x < (float)-96)
		{
			int num4 = -96;
			Vector3 localPosition3 = this.ReputationBar.localPosition;
			float num5 = localPosition3.x = (float)num4;
			Vector3 vector3 = this.ReputationBar.localPosition = localPosition3;
		}
		if (ID > 0)
		{
			string url = "file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + ID + ".png";
			WWW www = new WWW(url);
			this.Portrait.mainTexture = www.texture;
			this.Static.active = false;
			this.audio.volume = (float)0;
		}
		else
		{
			this.Portrait.mainTexture = this.InfoChan;
			this.Static.active = true;
			if (!this.StudentInfoMenu.Gossiping && !this.StudentInfoMenu.Distracting && !this.StudentInfoMenu.CyberBullying)
			{
				this.audio.volume = (float)1;
			}
		}
		this.UpdateAdditionalInfo(ID);
		this.CurrentStudent = ID;
	}

	public virtual void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			if (this.StudentInfoMenu.Gossiping)
			{
				this.StudentInfoMenu.PauseScreen.MainMenu.active = true;
				this.StudentInfoMenu.PauseScreen.Show = false;
				this.DialogueWheel.Victim = this.CurrentStudent;
				this.StudentInfoMenu.Gossiping = false;
				this.Shutter.Yandere.Interaction = 3;
				this.gameObject.active = false;
				Time.timeScale = (float)1;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
			}
			else if (this.StudentInfoMenu.Distracting)
			{
				this.StudentInfoMenu.PauseScreen.MainMenu.active = true;
				this.StudentInfoMenu.PauseScreen.Show = false;
				this.DialogueWheel.Victim = this.CurrentStudent;
				this.StudentInfoMenu.Gossiping = false;
				this.Shutter.Yandere.Interaction = 8;
				this.gameObject.active = false;
				Time.timeScale = (float)1;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
			}
			else if (this.StudentInfoMenu.CyberBullying)
			{
				this.HomeInternet.PostLabels[1].text = this.JSON.StudentNames[this.CurrentStudent];
				this.HomeInternet.Student = this.CurrentStudent;
				this.StudentInfoMenu.PauseScreen.MainMenu.active = true;
				this.StudentInfoMenu.PauseScreen.Show = false;
				this.StudentInfoMenu.CyberBullying = false;
				this.gameObject.active = false;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
			}
		}
		if (Input.GetButtonDown("B"))
		{
			this.audio.Stop();
			if (this.Shutter != null)
			{
				if (!this.Shutter.PhotoIcons.active)
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
				this.StudentInfoMenu.gameObject.active = true;
				this.gameObject.active = false;
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "View Info";
				if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(this.StudentInfoMenu, "Gossipping"), false))
				{
					this.PromptBar.Label[1].text = "Back";
				}
				this.PromptBar.UpdateButtons();
				this.Back = false;
			}
		}
		if (Input.GetKeyDown("="))
		{
			PlayerPrefs.SetInt("Student_" + this.CurrentStudent + "_Reputation", PlayerPrefs.GetInt("Student_" + this.CurrentStudent + "_Reputation") + 10);
			this.UpdateInfo(this.CurrentStudent);
		}
		if (Input.GetKeyDown("-"))
		{
			PlayerPrefs.SetInt("Student_" + this.CurrentStudent + "_Reputation", PlayerPrefs.GetInt("Student_" + this.CurrentStudent + "_Reputation") - 10);
			this.UpdateInfo(this.CurrentStudent);
		}
	}

	public virtual void UpdateAdditionalInfo(int ID)
	{
		if (ID == 0)
		{
			this.InfoLabel.text = "Trying to look up my information? Don't bother. There is nothing that you need to know about me. You're a client, and I'm a provider. That's all we need to know about each other.";
		}
		else if (ID == 6)
		{
			this.InfoLabel.text = "Kokona Haruka's best friend and closest confidant. Kokona is likely to discuss personal matters with this girl.";
		}
		else if (ID == 7)
		{
			if (PlayerPrefs.GetInt("Event1") == 1)
			{
				this.Strings[1] = "May be a victim of domestic abuse.";
			}
			else
			{
				this.Strings[1] = "?????";
			}
			if (PlayerPrefs.GetInt("Event2") == 1)
			{
				this.Strings[2] = "May be engaging in compensated dating in Sisuta Town.";
			}
			else
			{
				this.Strings[2] = "?????";
			}
			this.InfoLabel.text = this.Strings[1] + "\n" + "\n" + this.Strings[2];
		}
		else if (ID == 14)
		{
			this.InfoLabel.text = "Extremely unlikely to witness murder unless it takes place in the computer lab.";
		}
		else if (ID == 15)
		{
			this.InfoLabel.text = "Secretly has a crush on Pippi Osu. Neither of them realize that they both share feelings for each other.";
		}
		else if (ID == 16)
		{
			this.InfoLabel.text = "Known for irritating her classmates and teachers by constantly asking foolish questions.";
		}
		else
		{
			this.InfoLabel.text = "No additional information is available at this time.";
		}
	}

	public virtual void Main()
	{
	}
}
