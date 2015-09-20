using System;
using UnityEngine;

[Serializable]
public class StudentInfoScript : MonoBehaviour
{
	public PromptBarScript PromptBar;

	public ShutterScript Shutter;

	public JsonScript JSON;

	public GameObject StudentInfoMenu;

	public GameObject Static;

	public Texture DefaultPortrait;

	public Texture InfoChan;

	public Transform ReputationBar;

	public UILabel ReputationLabel;

	public UILabel PersonaLabel;

	public UILabel CrushLabel;

	public UILabel ClubLabel;

	public UILabel InfoLabel;

	public UILabel NameLabel;

	public UITexture Portrait;

	public string[] Strings;

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
			this.ReputationLabel.text = "-" + PlayerPrefs.GetInt("Student_" + ID + "_Reputation");
		}
		else if (PlayerPrefs.GetInt("Student_" + ID + "_Reputation") > 0)
		{
			this.ReputationLabel.text = "+" + PlayerPrefs.GetInt("Student_" + ID + "_Reputation");
		}
		else
		{
			this.ReputationLabel.text = "0";
		}
		int num = PlayerPrefs.GetInt("Student_" + ID + "_Reputation") * 96;
		Vector3 localPosition = this.ReputationBar.localPosition;
		float num2 = localPosition.x = (float)num;
		Vector3 vector = this.ReputationBar.localPosition = localPosition;
		if (ID > 0)
		{
			string url = "file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + ID + ".png";
			WWW www = new WWW(url);
			this.Portrait.mainTexture = www.texture;
			this.Static.active = false;
		}
		else
		{
			this.Portrait.mainTexture = this.InfoChan;
			this.Static.active = true;
		}
		this.UpdateAdditionalInfo(ID);
	}

	public virtual void Update()
	{
		if (Input.GetButtonDown("B") && !this.Shutter.PhotoIcons.active)
		{
			this.StudentInfoMenu.active = true;
			this.gameObject.active = false;
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "View Info";
			this.PromptBar.Label[1].text = "Back";
			this.PromptBar.UpdateButtons();
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
