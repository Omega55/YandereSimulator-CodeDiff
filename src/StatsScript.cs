using System;
using System.IO;
using UnityEngine;

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

	private void Start()
	{
		if (File.Exists(Application.streamingAssetsPath + "/CustomPortraits.txt"))
		{
			string text = File.ReadAllText(Application.streamingAssetsPath + "/CustomPortraits.txt");
			if (text.Equals("1"))
			{
				string url = "file:///" + Application.streamingAssetsPath + "/CustomPortrait.png";
				WWW www = new WWW(url);
				this.Portrait.mainTexture = www.texture;
			}
		}
	}

	private void Update()
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
			this.PauseScreen.MainMenu.SetActive(true);
			this.PauseScreen.Sideways = false;
			this.PauseScreen.PressedB = true;
			base.gameObject.SetActive(false);
		}
	}

	public void UpdateStats()
	{
		this.Grade = PlayerPrefs.GetInt("BiologyGrade");
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite = this.Subject1Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite.color = new Color(1f, 1f, 1f, 1f);
				this.Grade--;
			}
			else
			{
				uisprite.color = new Color(1f, 1f, 1f, 0.5f);
			}
			this.BarID++;
		}
		if (PlayerPrefs.GetInt("BiologyGrade") < 5)
		{
			this.Subject1Bars[PlayerPrefs.GetInt("BiologyGrade") + 1].color = ((PlayerPrefs.GetInt("BiologyBonus") <= 0) ? new Color(1f, 1f, 1f, 0.5f) : new Color(1f, 0f, 0f, 1f));
		}
		this.Grade = PlayerPrefs.GetInt("ChemistryGrade");
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite2 = this.Subject2Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 1f);
				this.Grade--;
			}
			else
			{
				uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 0.5f);
			}
			this.BarID++;
		}
		if (PlayerPrefs.GetInt("ChemistryGrade") < 5)
		{
			this.Subject2Bars[PlayerPrefs.GetInt("ChemistryGrade") + 1].color = ((PlayerPrefs.GetInt("ChemistryBonus") <= 0) ? new Color(1f, 1f, 1f, 0.5f) : new Color(1f, 0f, 0f, 1f));
		}
		this.Grade = PlayerPrefs.GetInt("LanguageGrade");
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite3 = this.Subject3Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite3.color = new Color(uisprite3.color.r, uisprite3.color.g, uisprite3.color.b, 1f);
				this.Grade--;
			}
			else
			{
				uisprite3.color = new Color(uisprite3.color.r, uisprite3.color.g, uisprite3.color.b, 0.5f);
			}
			this.BarID++;
		}
		if (PlayerPrefs.GetInt("LanguageGrade") < 5)
		{
			this.Subject3Bars[PlayerPrefs.GetInt("LanguageGrade") + 1].color = ((PlayerPrefs.GetInt("LanguageBonus") <= 0) ? new Color(1f, 1f, 1f, 0.5f) : new Color(1f, 0f, 0f, 1f));
		}
		this.Grade = PlayerPrefs.GetInt("PhysicalGrade");
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite4 = this.Subject4Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite4.color = new Color(uisprite4.color.r, uisprite4.color.g, uisprite4.color.b, 1f);
				this.Grade--;
			}
			else
			{
				uisprite4.color = new Color(uisprite4.color.r, uisprite4.color.g, uisprite4.color.b, 0.5f);
			}
			this.BarID++;
		}
		if (PlayerPrefs.GetInt("PhysicalGrade") < 5)
		{
			this.Subject4Bars[PlayerPrefs.GetInt("PhysicalGrade") + 1].color = ((PlayerPrefs.GetInt("PhysicalBonus") <= 0) ? new Color(1f, 1f, 1f, 0.5f) : new Color(1f, 0f, 0f, 1f));
		}
		this.Grade = PlayerPrefs.GetInt("PsychologyGrade");
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite5 = this.Subject5Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite5.color = new Color(uisprite5.color.r, uisprite5.color.g, uisprite5.color.b, 1f);
				this.Grade--;
			}
			else
			{
				uisprite5.color = new Color(uisprite5.color.r, uisprite5.color.g, uisprite5.color.b, 0.5f);
			}
			this.BarID++;
		}
		if (PlayerPrefs.GetInt("PsychologyGrade") < 5)
		{
			this.Subject5Bars[PlayerPrefs.GetInt("PsychologyGrade") + 1].color = ((PlayerPrefs.GetInt("PsychologyBonus") <= 0) ? new Color(1f, 1f, 1f, 0.5f) : new Color(1f, 0f, 0f, 1f));
		}
		this.Grade = PlayerPrefs.GetInt("Seduction");
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite6 = this.Subject6Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite6.color = new Color(uisprite6.color.r, uisprite6.color.g, uisprite6.color.b, 1f);
				this.Grade--;
			}
			else
			{
				uisprite6.color = new Color(uisprite6.color.r, uisprite6.color.g, uisprite6.color.b, 0.5f);
			}
			this.BarID++;
		}
		if (PlayerPrefs.GetInt("Seduction") < 5)
		{
			this.Subject6Bars[PlayerPrefs.GetInt("Seduction") + 1].color = ((PlayerPrefs.GetInt("SeductionBonus") <= 0) ? new Color(1f, 1f, 1f, 0.5f) : new Color(1f, 0f, 0f, 1f));
		}
		this.Grade = PlayerPrefs.GetInt("Numbness");
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite7 = this.Subject7Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite7.color = new Color(uisprite7.color.r, uisprite7.color.g, uisprite7.color.b, 1f);
				this.Grade--;
			}
			else
			{
				uisprite7.color = new Color(uisprite7.color.r, uisprite7.color.g, uisprite7.color.b, 0.5f);
			}
			this.BarID++;
		}
		if (PlayerPrefs.GetInt("Numbness") < 5)
		{
			this.Subject7Bars[PlayerPrefs.GetInt("Numbness") + 1].color = ((PlayerPrefs.GetInt("NumbnessBonus") <= 0) ? new Color(1f, 1f, 1f, 0.5f) : new Color(1f, 0f, 0f, 1f));
		}
		this.Grade = PlayerPrefs.GetInt("Enlightenment");
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite8 = this.Subject8Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite8.color = new Color(uisprite8.color.r, uisprite8.color.g, uisprite8.color.b, 1f);
				this.Grade--;
			}
			else
			{
				uisprite8.color = new Color(uisprite8.color.r, uisprite8.color.g, uisprite8.color.b, 0.5f);
			}
			this.BarID++;
		}
		if (PlayerPrefs.GetInt("Enlightenment") < 5)
		{
			this.Subject8Bars[PlayerPrefs.GetInt("Enlightenment") + 1].color = ((PlayerPrefs.GetInt("EnlightenmentBonus") <= 0) ? new Color(1f, 1f, 1f, 0.5f) : new Color(1f, 0f, 0f, 1f));
		}
		this.Ranks[1].text = "Rank: " + PlayerPrefs.GetInt("BiologyGrade").ToString();
		this.Ranks[2].text = "Rank: " + PlayerPrefs.GetInt("ChemistryGrade").ToString();
		this.Ranks[3].text = "Rank: " + PlayerPrefs.GetInt("LanguageGrade").ToString();
		this.Ranks[4].text = "Rank: " + PlayerPrefs.GetInt("PhysicalGrade").ToString();
		this.Ranks[5].text = "Rank: " + PlayerPrefs.GetInt("PsychologyGrade").ToString();
		this.Ranks[6].text = "Rank: " + PlayerPrefs.GetInt("Seduction").ToString();
		this.Ranks[7].text = "Rank: " + PlayerPrefs.GetInt("Numbness").ToString();
		this.Ranks[8].text = "Rank: " + PlayerPrefs.GetInt("Enlightenment").ToString();
		int @int = PlayerPrefs.GetInt("Club");
		if (@int == 0)
		{
			this.ClubLabel.text = "Club: None";
		}
		else if (@int == 1)
		{
			this.ClubLabel.text = "Club: Cooking";
		}
		else if (@int == 2)
		{
			this.ClubLabel.text = "Club: Drama";
		}
		else if (@int == 3)
		{
			this.ClubLabel.text = "Club: Occult";
		}
		else if (@int == 4)
		{
			this.ClubLabel.text = "Club: Art";
		}
		else if (@int == 5)
		{
			this.ClubLabel.text = "Club: Light Music";
		}
		else if (@int == 6)
		{
			this.ClubLabel.text = "Club: Martial Arts";
		}
		else if (@int == 7)
		{
			this.ClubLabel.text = "Club: Photography";
		}
		else if (@int == 8)
		{
			this.ClubLabel.text = "Club: Science";
		}
		else if (@int == 9)
		{
			this.ClubLabel.text = "Club: Sports";
		}
		else if (@int == 10)
		{
			this.ClubLabel.text = "Club: Gardening";
		}
		else if (@int == 11)
		{
			this.ClubLabel.text = "Club: Gaming";
		}
	}
}
