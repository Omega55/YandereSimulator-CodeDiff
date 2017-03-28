using System;
using System.IO;
using UnityEngine;

[Serializable]
public class StatsScript : MonoBehaviour
{
	public PauseScreenScript PauseScreen;

	public PromptBarScript PromptBar;

	public UISprite[] Subject1Bars;

	public UISprite[] Subject2Bars;

	public UISprite[] Subject3Bars;

	public UISprite[] Subject4Bars;

	public UISprite[] Subject5Bars;

	public UISprite[] Subject6Bars;

	public UISprite[] Subject7Bars;

	public UISprite[] Subject8Bars;

	public UILabel[] Ranks;

	public UILabel ClubLabel;

	public int Grade;

	public int BarID;

	public UITexture Portrait;

	public virtual void Start()
	{
		if (File.Exists(Application.streamingAssetsPath + "/CustomPortraits.txt"))
		{
			string a = File.ReadAllText(Application.streamingAssetsPath + "/CustomPortraits.txt");
			if (a == "1")
			{
				string url = "file:///" + Application.streamingAssetsPath + "/CustomPortrait.png";
				WWW www = new WWW(url);
				this.Portrait.mainTexture = www.texture;
			}
		}
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown(KeyCode.Backslash))
		{
			PlayerPrefs.SetInt("BiologyGrade", 1);
			PlayerPrefs.SetInt("ChemistryGrade", 5);
			PlayerPrefs.SetInt("LanguageGrade", 2);
			PlayerPrefs.SetInt("PhysicalGrade", 4);
			PlayerPrefs.SetInt("PsychologyGrade", 3);
			PlayerPrefs.SetInt("Seduction", 4);
			PlayerPrefs.SetInt("Numbness", 2);
			PlayerPrefs.SetInt("Enlightenment", 5);
			this.UpdateStats();
		}
		if (Input.GetButtonDown("B"))
		{
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[4].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.PauseScreen.MainMenu.active = true;
			this.PauseScreen.Sideways = false;
			this.PauseScreen.PressedB = true;
			this.active = false;
		}
	}

	public virtual void UpdateStats()
	{
		this.Grade = PlayerPrefs.GetInt("BiologyGrade");
		this.BarID = 1;
		while (this.BarID < 6)
		{
			if (this.Grade > 0)
			{
				this.Subject1Bars[this.BarID].color = new Color((float)1, (float)1, (float)1, (float)1);
				this.Grade--;
			}
			else
			{
				this.Subject1Bars[this.BarID].color = new Color((float)1, (float)1, (float)1, 0.5f);
			}
			this.BarID++;
		}
		if (PlayerPrefs.GetInt("BiologyGrade") < 5)
		{
			if (PlayerPrefs.GetInt("BiologyBonus") > 0)
			{
				this.Subject1Bars[PlayerPrefs.GetInt("BiologyGrade") + 1].color = new Color((float)1, (float)0, (float)0, (float)1);
			}
			else
			{
				this.Subject1Bars[PlayerPrefs.GetInt("BiologyGrade") + 1].color = new Color((float)1, (float)1, (float)1, 0.5f);
			}
		}
		this.Grade = PlayerPrefs.GetInt("ChemistryGrade");
		this.BarID = 1;
		while (this.BarID < 6)
		{
			if (this.Grade > 0)
			{
				int num = 1;
				Color color = this.Subject2Bars[this.BarID].color;
				float num2 = color.a = (float)num;
				Color color2 = this.Subject2Bars[this.BarID].color = color;
				this.Grade--;
			}
			else
			{
				float a = 0.5f;
				Color color3 = this.Subject2Bars[this.BarID].color;
				float num3 = color3.a = a;
				Color color4 = this.Subject2Bars[this.BarID].color = color3;
			}
			this.BarID++;
		}
		if (PlayerPrefs.GetInt("ChemistryGrade") < 5)
		{
			if (PlayerPrefs.GetInt("ChemistryBonus") > 0)
			{
				this.Subject2Bars[PlayerPrefs.GetInt("ChemistryGrade") + 1].color = new Color((float)1, (float)0, (float)0, (float)1);
			}
			else
			{
				this.Subject2Bars[PlayerPrefs.GetInt("ChemistryGrade") + 1].color = new Color((float)1, (float)1, (float)1, 0.5f);
			}
		}
		this.Grade = PlayerPrefs.GetInt("LanguageGrade");
		this.BarID = 1;
		while (this.BarID < 6)
		{
			if (this.Grade > 0)
			{
				int num4 = 1;
				Color color5 = this.Subject3Bars[this.BarID].color;
				float num5 = color5.a = (float)num4;
				Color color6 = this.Subject3Bars[this.BarID].color = color5;
				this.Grade--;
			}
			else
			{
				float a2 = 0.5f;
				Color color7 = this.Subject3Bars[this.BarID].color;
				float num6 = color7.a = a2;
				Color color8 = this.Subject3Bars[this.BarID].color = color7;
			}
			this.BarID++;
		}
		if (PlayerPrefs.GetInt("LanguageGrade") < 5)
		{
			if (PlayerPrefs.GetInt("LanguageBonus") > 0)
			{
				this.Subject3Bars[PlayerPrefs.GetInt("LanguageGrade") + 1].color = new Color((float)1, (float)0, (float)0, (float)1);
			}
			else
			{
				this.Subject3Bars[PlayerPrefs.GetInt("LanguageGrade") + 1].color = new Color((float)1, (float)1, (float)1, 0.5f);
			}
		}
		this.Grade = PlayerPrefs.GetInt("PhysicalGrade");
		this.BarID = 1;
		while (this.BarID < 6)
		{
			if (this.Grade > 0)
			{
				int num7 = 1;
				Color color9 = this.Subject4Bars[this.BarID].color;
				float num8 = color9.a = (float)num7;
				Color color10 = this.Subject4Bars[this.BarID].color = color9;
				this.Grade--;
			}
			else
			{
				float a3 = 0.5f;
				Color color11 = this.Subject4Bars[this.BarID].color;
				float num9 = color11.a = a3;
				Color color12 = this.Subject4Bars[this.BarID].color = color11;
			}
			this.BarID++;
		}
		if (PlayerPrefs.GetInt("PhysicalGrade") < 5)
		{
			if (PlayerPrefs.GetInt("PhysicalBonus") > 0)
			{
				this.Subject4Bars[PlayerPrefs.GetInt("PhysicalGrade") + 1].color = new Color((float)1, (float)0, (float)0, (float)1);
			}
			else
			{
				this.Subject4Bars[PlayerPrefs.GetInt("PhysicalGrade") + 1].color = new Color((float)1, (float)1, (float)1, 0.5f);
			}
		}
		this.Grade = PlayerPrefs.GetInt("PsychologyGrade");
		this.BarID = 1;
		while (this.BarID < 6)
		{
			if (this.Grade > 0)
			{
				int num10 = 1;
				Color color13 = this.Subject5Bars[this.BarID].color;
				float num11 = color13.a = (float)num10;
				Color color14 = this.Subject5Bars[this.BarID].color = color13;
				this.Grade--;
			}
			else
			{
				float a4 = 0.5f;
				Color color15 = this.Subject5Bars[this.BarID].color;
				float num12 = color15.a = a4;
				Color color16 = this.Subject5Bars[this.BarID].color = color15;
			}
			this.BarID++;
		}
		if (PlayerPrefs.GetInt("PsychologyGrade") < 5)
		{
			if (PlayerPrefs.GetInt("PsychologyBonus") > 0)
			{
				this.Subject5Bars[PlayerPrefs.GetInt("PsychologyGrade") + 1].color = new Color((float)1, (float)0, (float)0, (float)1);
			}
			else
			{
				this.Subject5Bars[PlayerPrefs.GetInt("PsychologyGrade") + 1].color = new Color((float)1, (float)1, (float)1, 0.5f);
			}
		}
		this.Grade = PlayerPrefs.GetInt("Seduction");
		this.BarID = 1;
		while (this.BarID < 6)
		{
			if (this.Grade > 0)
			{
				int num13 = 1;
				Color color17 = this.Subject6Bars[this.BarID].color;
				float num14 = color17.a = (float)num13;
				Color color18 = this.Subject6Bars[this.BarID].color = color17;
				this.Grade--;
			}
			else
			{
				float a5 = 0.5f;
				Color color19 = this.Subject6Bars[this.BarID].color;
				float num15 = color19.a = a5;
				Color color20 = this.Subject6Bars[this.BarID].color = color19;
			}
			this.BarID++;
		}
		if (PlayerPrefs.GetInt("Seduction") < 5)
		{
			if (PlayerPrefs.GetInt("SeductionBonus") > 0)
			{
				this.Subject6Bars[PlayerPrefs.GetInt("Seduction") + 1].color = new Color((float)1, (float)0, (float)0, (float)1);
			}
			else
			{
				this.Subject6Bars[PlayerPrefs.GetInt("Seduction") + 1].color = new Color((float)1, (float)1, (float)1, 0.5f);
			}
		}
		this.Grade = PlayerPrefs.GetInt("Numbness");
		this.BarID = 1;
		while (this.BarID < 6)
		{
			if (this.Grade > 0)
			{
				int num16 = 1;
				Color color21 = this.Subject7Bars[this.BarID].color;
				float num17 = color21.a = (float)num16;
				Color color22 = this.Subject7Bars[this.BarID].color = color21;
				this.Grade--;
			}
			else
			{
				float a6 = 0.5f;
				Color color23 = this.Subject7Bars[this.BarID].color;
				float num18 = color23.a = a6;
				Color color24 = this.Subject7Bars[this.BarID].color = color23;
			}
			this.BarID++;
		}
		if (PlayerPrefs.GetInt("Numbness") < 5)
		{
			if (PlayerPrefs.GetInt("NumbnessBonus") > 0)
			{
				this.Subject7Bars[PlayerPrefs.GetInt("Numbness") + 1].color = new Color((float)1, (float)0, (float)0, (float)1);
			}
			else
			{
				this.Subject7Bars[PlayerPrefs.GetInt("Numbness") + 1].color = new Color((float)1, (float)1, (float)1, 0.5f);
			}
		}
		this.Grade = PlayerPrefs.GetInt("Enlightenment");
		this.BarID = 1;
		while (this.BarID < 6)
		{
			if (this.Grade > 0)
			{
				int num19 = 1;
				Color color25 = this.Subject8Bars[this.BarID].color;
				float num20 = color25.a = (float)num19;
				Color color26 = this.Subject8Bars[this.BarID].color = color25;
				this.Grade--;
			}
			else
			{
				float a7 = 0.5f;
				Color color27 = this.Subject8Bars[this.BarID].color;
				float num21 = color27.a = a7;
				Color color28 = this.Subject8Bars[this.BarID].color = color27;
			}
			this.BarID++;
		}
		if (PlayerPrefs.GetInt("Enlightenment") < 5)
		{
			if (PlayerPrefs.GetInt("EnlightenmentBonus") > 0)
			{
				this.Subject8Bars[PlayerPrefs.GetInt("Enlightenment") + 1].color = new Color((float)1, (float)0, (float)0, (float)1);
			}
			else
			{
				this.Subject8Bars[PlayerPrefs.GetInt("Enlightenment") + 1].color = new Color((float)1, (float)1, (float)1, 0.5f);
			}
		}
		this.Ranks[1].text = "Rank: " + PlayerPrefs.GetInt("BiologyGrade");
		this.Ranks[2].text = "Rank: " + PlayerPrefs.GetInt("ChemistryGrade");
		this.Ranks[3].text = "Rank: " + PlayerPrefs.GetInt("LanguageGrade");
		this.Ranks[4].text = "Rank: " + PlayerPrefs.GetInt("PhysicalGrade");
		this.Ranks[5].text = "Rank: " + PlayerPrefs.GetInt("PsychologyGrade");
		this.Ranks[6].text = "Rank: " + PlayerPrefs.GetInt("Seduction");
		this.Ranks[7].text = "Rank: " + PlayerPrefs.GetInt("Numbness");
		this.Ranks[8].text = "Rank: " + PlayerPrefs.GetInt("Enlightenment");
		int @int = PlayerPrefs.GetInt("Club");
		if (@int == 0)
		{
			this.ClubLabel.text = "Club: " + "None";
		}
		else if (@int == 1)
		{
			this.ClubLabel.text = "Club: " + "Cooking";
		}
		else if (@int == 2)
		{
			this.ClubLabel.text = "Club: " + "Drama";
		}
		else if (@int == 3)
		{
			this.ClubLabel.text = "Club: " + "Occult";
		}
		else if (@int == 4)
		{
			this.ClubLabel.text = "Club: " + "Art";
		}
		else if (@int == 5)
		{
			this.ClubLabel.text = "Club: " + "Light Music";
		}
		else if (@int == 6)
		{
			this.ClubLabel.text = "Club: " + "Martial Arts";
		}
		else if (@int == 7)
		{
			this.ClubLabel.text = "Club: " + "Photography";
		}
		else if (@int == 8)
		{
			this.ClubLabel.text = "Club: " + "Science";
		}
		else if (@int == 9)
		{
			this.ClubLabel.text = "Club: " + "Sports";
		}
		else if (@int == 10)
		{
			this.ClubLabel.text = "Club: " + "Gardening";
		}
		else if (@int == 11)
		{
			this.ClubLabel.text = "Club: " + "Gaming";
		}
	}

	public virtual void Main()
	{
	}
}
