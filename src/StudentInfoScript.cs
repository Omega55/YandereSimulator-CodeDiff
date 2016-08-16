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

	public Texture BlankPortrait;

	public Texture InfoChan;

	public Transform ReputationBar;

	public GameObject Static;

	public UILabel OccupationLabel;

	public UILabel ReputationLabel;

	public UILabel StrengthLabel;

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
		if (this.JSON.StudentPersonas[ID] == 1)
		{
			this.PersonaLabel.text = "Loner";
		}
		else if (this.JSON.StudentPersonas[ID] == 2)
		{
			this.PersonaLabel.text = "Teacher's Pet";
		}
		else if (this.JSON.StudentPersonas[ID] == 3)
		{
			this.PersonaLabel.text = "Heroic";
		}
		else if (this.JSON.StudentPersonas[ID] == 4)
		{
			this.PersonaLabel.text = "Coward";
		}
		else if (this.JSON.StudentPersonas[ID] == 5)
		{
			this.PersonaLabel.text = "Evil";
		}
		else if (this.JSON.StudentPersonas[ID] == 6)
		{
			this.PersonaLabel.text = "Social Butterfly";
		}
		else if (this.JSON.StudentPersonas[ID] == 9)
		{
			this.PersonaLabel.text = "Strict";
		}
		else if (this.JSON.StudentPersonas[ID] == 99)
		{
			this.PersonaLabel.text = "?????";
		}
		if (this.JSON.StudentClubs[ID] == 101)
		{
			this.PersonaLabel.text = "Friendly but Strict";
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
		if (PlayerPrefs.GetInt("Club_" + this.JSON.StudentClubs[ID] + "_Closed") == 1)
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
		if (ID > 0)
		{
			string url = "file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + ID + ".png";
			WWW www = new WWW(url);
			if (PlayerPrefs.GetInt("Student_" + ID + "_Replaced") == 0)
			{
				this.Portrait.mainTexture = www.texture;
			}
			else
			{
				this.Portrait.mainTexture = this.BlankPortrait;
			}
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
				this.Strings[2] = "May be engaging in compensated dating in Shisuta Town.";
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
		else if (ID == 17)
		{
			this.Strings[1] = "Wears contact lenses.";
			this.Strings[2] = "Enjoys spending time with her younger sister.";
			this.Strings[3] = "Rumored to be a succubus disguised as a high school student...but only a fool would believe something like that.";
			this.InfoLabel.text = this.Strings[1] + "\n" + "\n" + this.Strings[2] + "\n" + "\n" + this.Strings[3];
		}
		else if (ID == 18)
		{
			this.Strings[1] = "Wears contact lenses.";
			this.Strings[2] = "Enjoys spending time with her older sister.";
			this.Strings[3] = "Rumored to be a vampire disguised as a high school student...but only a fool would believe something like that.";
			this.InfoLabel.text = this.Strings[1] + "\n" + "\n" + this.Strings[2] + "\n" + "\n" + this.Strings[3];
		}
		else if (ID == 19)
		{
			this.InfoLabel.text = "Has never been witnessed exhibiting emotions.";
		}
		else if (ID == 20)
		{
			this.Strings[1] = "Described as 'kawaii' 'moe' and 'deredere' by her admirers.";
			this.Strings[2] = "Has sworn her heart to an independent game developer living overseas.";
			this.Strings[3] = "Prefers to spend her time alone, fantasizing about her loved one.";
			this.InfoLabel.text = this.Strings[1] + "\n" + "\n" + this.Strings[2] + "\n" + "\n" + this.Strings[3];
		}
		else if (ID == 21)
		{
			this.Strings[1] = "Founder and President of the Martial Arts Club.";
			this.Strings[2] = "Seems to be incapable of turning down a challenge.";
			this.Strings[3] = "Always gung ho and enthusiastic. Sometimes a bit overzealous, especially about martial arts.";
			this.InfoLabel.text = this.Strings[1] + "\n" + "\n" + this.Strings[2] + "\n" + "\n" + this.Strings[3];
		}
		else if (ID == 22)
		{
			this.InfoLabel.text = "Journeyman-level disciple of Budo Masuta.";
		}
		else if (ID == 23)
		{
			this.InfoLabel.text = "Apprentice-level disciple of Budo Masuta.";
		}
		else if (ID == 24)
		{
			this.InfoLabel.text = "Journeyman-level disciple of Budo Masuta.";
		}
		else if (ID == 25)
		{
			this.InfoLabel.text = "Apprentice-level disciple of Budo Masuta.";
		}
		else if (ID == 26)
		{
			this.Strings[1] = "Founder and President of the Occult Club.";
			this.Strings[2] = "Seems to have absolutely no interest in anything that is not paranormal.";
			this.Strings[3] = "Stalks the Basu sisters daily in a futile search for evidence that they are supernatural beings.";
			this.InfoLabel.text = this.Strings[1] + "\n" + "\n" + this.Strings[2] + "\n" + "\n" + this.Strings[3];
		}
		else if (ID == 27)
		{
			this.InfoLabel.text = "Trusted by Oka Ruto to operate the Occult Club when she is not present.";
		}
		else if (ID == 28)
		{
			this.Strings[1] = "Claims to be wearing a medical eyepatch to correct a problem with her vision.";
			this.Strings[2] = "Refuses to provide details regarding her eye condition, leading to rumors that she is lying about the reason she wears an eyepatch.";
			this.InfoLabel.text = this.Strings[1] + "\n" + "\n" + this.Strings[2];
		}
		else if (ID == 29)
		{
			this.Strings[1] = "No student has ever seen the right side of his face.";
			this.Strings[2] = "Some students suspect that he is using his hair to hide an unsightly scar or missing eye.";
			this.InfoLabel.text = this.Strings[1] + "\n" + "\n" + this.Strings[2];
		}
		else if (ID == 30)
		{
			this.Strings[1] = "Claims that the bandages on her face are the result of being attacked by a wild animal shortly before the school year began.";
			this.Strings[2] = "There are rumors that the true reason she wears bandages is because she is regularly beaten by a family member, and was blinded in one eye during a domestic dispute.";
			this.InfoLabel.text = this.Strings[1] + "\n" + "\n" + this.Strings[2];
		}
		else if (ID == 31)
		{
			this.Strings[1] = "One of the lenses of his glasses is completely opaque. No student has ever seen his right eye.";
			this.Strings[2] = "Some students suspect that he only has one eye, and prefers to wear an opaque lense over that eye rather than an eyepatch.";
			this.InfoLabel.text = this.Strings[1] + "\n" + "\n" + this.Strings[2];
		}
		else if (ID == 32)
		{
			this.Strings[1] = "The most flashy girl in school.";
			this.Strings[2] = "She is spoiled rotten by her doting father, who buys his daughter anything she wants.";
			this.Strings[3] = "Her father runs a loan agency.";
			this.InfoLabel.text = this.Strings[1] + "\n" + "\n" + this.Strings[2] + "\n" + "\n" + this.Strings[3];
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
