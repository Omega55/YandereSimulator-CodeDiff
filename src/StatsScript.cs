using System;
using System.Collections.Generic;
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

	private Dictionary<int, string> ClubLabels;

	private void Awake()
	{
		this.ClubLabels = new Dictionary<int, string>
		{
			{
				0,
				"None"
			},
			{
				1,
				"Cooking"
			},
			{
				2,
				"Drama"
			},
			{
				3,
				"Occult"
			},
			{
				4,
				"Art"
			},
			{
				5,
				"Light Music"
			},
			{
				6,
				"Martial Arts"
			},
			{
				7,
				"Photography"
			},
			{
				8,
				"Science"
			},
			{
				9,
				"Sports"
			},
			{
				10,
				"Gardening"
			},
			{
				11,
				"Gaming"
			}
		};
	}

	private void Start()
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

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Backslash))
		{
			Globals.BiologyGrade = 1;
			Globals.ChemistryGrade = 5;
			Globals.LanguageGrade = 2;
			Globals.PhysicalGrade = 4;
			Globals.PsychologyGrade = 3;
			Globals.Seduction = 4;
			Globals.Numbness = 2;
			Globals.Enlightenment = 5;
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
		this.Grade = Globals.BiologyGrade;
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
		if (Globals.BiologyGrade < 5)
		{
			this.Subject1Bars[Globals.BiologyGrade + 1].color = ((Globals.BiologyBonus <= 0) ? new Color(1f, 1f, 1f, 0.5f) : new Color(1f, 0f, 0f, 1f));
		}
		this.Grade = Globals.ChemistryGrade;
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
		if (Globals.ChemistryGrade < 5)
		{
			this.Subject2Bars[Globals.ChemistryGrade + 1].color = ((Globals.ChemistryBonus <= 0) ? new Color(1f, 1f, 1f, 0.5f) : new Color(1f, 0f, 0f, 1f));
		}
		this.Grade = Globals.LanguageGrade;
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
		if (Globals.LanguageGrade < 5)
		{
			this.Subject3Bars[Globals.LanguageGrade + 1].color = ((Globals.LanguageBonus <= 0) ? new Color(1f, 1f, 1f, 0.5f) : new Color(1f, 0f, 0f, 1f));
		}
		this.Grade = Globals.PhysicalGrade;
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
		if (Globals.PhysicalGrade < 5)
		{
			this.Subject4Bars[Globals.PhysicalGrade + 1].color = ((Globals.PhysicalBonus <= 0) ? new Color(1f, 1f, 1f, 0.5f) : new Color(1f, 0f, 0f, 1f));
		}
		this.Grade = Globals.PsychologyGrade;
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
		if (Globals.PsychologyGrade < 5)
		{
			this.Subject5Bars[Globals.PsychologyGrade + 1].color = ((Globals.PsychologyBonus <= 0) ? new Color(1f, 1f, 1f, 0.5f) : new Color(1f, 0f, 0f, 1f));
		}
		this.Grade = Globals.Seduction;
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
		if (Globals.Seduction < 5)
		{
			this.Subject6Bars[Globals.Seduction + 1].color = ((Globals.SeductionBonus <= 0) ? new Color(1f, 1f, 1f, 0.5f) : new Color(1f, 0f, 0f, 1f));
		}
		this.Grade = Globals.Numbness;
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
		if (Globals.Numbness < 5)
		{
			this.Subject7Bars[Globals.Numbness + 1].color = ((Globals.NumbnessBonus <= 0) ? new Color(1f, 1f, 1f, 0.5f) : new Color(1f, 0f, 0f, 1f));
		}
		this.Grade = Globals.Enlightenment;
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
		if (Globals.Enlightenment < 5)
		{
			this.Subject8Bars[Globals.Enlightenment + 1].color = ((Globals.EnlightenmentBonus <= 0) ? new Color(1f, 1f, 1f, 0.5f) : new Color(1f, 0f, 0f, 1f));
		}
		this.Ranks[1].text = "Rank: " + Globals.BiologyGrade.ToString();
		this.Ranks[2].text = "Rank: " + Globals.ChemistryGrade.ToString();
		this.Ranks[3].text = "Rank: " + Globals.LanguageGrade.ToString();
		this.Ranks[4].text = "Rank: " + Globals.PhysicalGrade.ToString();
		this.Ranks[5].text = "Rank: " + Globals.PsychologyGrade.ToString();
		this.Ranks[6].text = "Rank: " + Globals.Seduction.ToString();
		this.Ranks[7].text = "Rank: " + Globals.Numbness.ToString();
		this.Ranks[8].text = "Rank: " + Globals.Enlightenment.ToString();
		int club = Globals.Club;
		string str;
		bool flag = this.ClubLabels.TryGetValue(club, out str);
		this.ClubLabel.text = "Club: " + str;
	}
}
