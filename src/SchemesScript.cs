using System;
using UnityEngine;

public class SchemesScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public SchemeManagerScript SchemeManager;

	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public GameObject FavorMenu;

	public Transform Highlight;

	public Transform Arrow;

	public UILabel SchemeInstructions;

	public UITexture SchemeIcon;

	public UILabel PantyCount;

	public UILabel SchemeDesc;

	public UILabel[] SchemeDeadlineLabels;

	public UILabel[] SchemeCostLabels;

	public UILabel[] SchemeNameLabels;

	public UISprite[] Exclamations;

	public Texture[] SchemeIcons;

	public int[] SchemeCosts;

	public Transform[] SchemeDestinations;

	public string[] SchemeDeadlines;

	public string[] SchemeSkills;

	public string[] SchemeDescs;

	public string[] SchemeNames;

	[Multiline]
	[SerializeField]
	public string[] SchemeSteps;

	public int ID = 1;

	public string[] Steps;

	public AudioClip InfoPurchase;

	public AudioClip InfoAfford;

	public Transform[] Scheme1Destinations;

	public Transform[] Scheme2Destinations;

	public Transform[] Scheme3Destinations;

	public Transform[] Scheme4Destinations;

	public Transform[] Scheme5Destinations;

	public GameObject HUDIcon;

	public UILabel HUDInstructions;

	private void Start()
	{
		for (int i = 1; i < this.SchemeNames.Length; i++)
		{
			if (!SchemeGlobals.GetSchemeStatus(i))
			{
				this.SchemeDeadlineLabels[i].text = this.SchemeDeadlines[i];
				this.SchemeNameLabels[i].text = this.SchemeNames[i];
			}
		}
		this.SchemeNameLabels[1].color = new Color(0f, 0f, 0f, 0.5f);
		this.SchemeNameLabels[2].color = new Color(0f, 0f, 0f, 0.5f);
		this.SchemeNameLabels[3].color = new Color(0f, 0f, 0f, 0.5f);
		this.SchemeNameLabels[4].color = new Color(0f, 0f, 0f, 0.5f);
		this.SchemeNameLabels[5].color = new Color(0f, 0f, 0f, 0.5f);
		if (DateGlobals.Weekday == DayOfWeek.Monday)
		{
			this.SchemeNameLabels[1].color = new Color(0f, 0f, 0f, 1f);
		}
		if (DateGlobals.Weekday == DayOfWeek.Tuesday)
		{
			this.SchemeNameLabels[2].color = new Color(0f, 0f, 0f, 1f);
		}
		if (DateGlobals.Weekday == DayOfWeek.Wednesday)
		{
			this.SchemeNameLabels[3].color = new Color(0f, 0f, 0f, 1f);
		}
		if (DateGlobals.Weekday == DayOfWeek.Thursday)
		{
			this.SchemeNameLabels[4].color = new Color(0f, 0f, 0f, 1f);
		}
		if (DateGlobals.Weekday == DayOfWeek.Friday)
		{
			this.SchemeNameLabels[5].color = new Color(0f, 0f, 0f, 1f);
		}
	}

	private void Update()
	{
		if (this.InputManager.TappedUp)
		{
			this.ID--;
			if (this.ID < 1)
			{
				this.ID = this.SchemeNames.Length - 1;
			}
			this.UpdateSchemeInfo();
		}
		if (this.InputManager.TappedDown)
		{
			this.ID++;
			if (this.ID > this.SchemeNames.Length - 1)
			{
				this.ID = 1;
			}
			this.UpdateSchemeInfo();
		}
		if (Input.GetButtonDown("A"))
		{
			AudioSource component = base.GetComponent<AudioSource>();
			if (this.PromptBar.Label[0].text != string.Empty)
			{
				if (this.SchemeNameLabels[this.ID].color.a == 1f)
				{
					this.SchemeManager.enabled = true;
					if (this.ID == 5)
					{
						this.SchemeManager.ClockCheck = true;
					}
					if (!SchemeGlobals.GetSchemeUnlocked(this.ID))
					{
						if (PlayerGlobals.PantyShots >= this.SchemeCosts[this.ID])
						{
							PlayerGlobals.PantyShots -= this.SchemeCosts[this.ID];
							SchemeGlobals.SetSchemeUnlocked(this.ID, true);
							SchemeGlobals.CurrentScheme = this.ID;
							if (SchemeGlobals.GetSchemeStage(this.ID) == 0)
							{
								SchemeGlobals.SetSchemeStage(this.ID, 1);
							}
							this.UpdateSchemeDestinations();
							this.UpdateInstructions();
							this.UpdateSchemeList();
							this.UpdateSchemeInfo();
							component.clip = this.InfoPurchase;
							component.Play();
						}
					}
					else
					{
						if (SchemeGlobals.CurrentScheme == this.ID)
						{
							SchemeGlobals.CurrentScheme = 0;
							this.SchemeManager.enabled = false;
						}
						else
						{
							SchemeGlobals.CurrentScheme = this.ID;
						}
						this.UpdateSchemeDestinations();
						this.UpdateInstructions();
						this.UpdateSchemeInfo();
					}
				}
			}
			else if (SchemeGlobals.GetSchemeStage(this.ID) != 100 && PlayerGlobals.PantyShots < this.SchemeCosts[this.ID])
			{
				component.clip = this.InfoAfford;
				component.Play();
			}
		}
		if (Input.GetButtonDown("B"))
		{
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[5].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.FavorMenu.SetActive(true);
			base.gameObject.SetActive(false);
		}
	}

	public void UpdateSchemeList()
	{
		for (int i = 1; i < this.SchemeNames.Length; i++)
		{
			if (SchemeGlobals.GetSchemeStage(i) == 100)
			{
				UILabel uilabel = this.SchemeNameLabels[i];
				uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
				this.Exclamations[i].enabled = false;
				this.SchemeCostLabels[i].text = string.Empty;
			}
			else
			{
				this.SchemeCostLabels[i].text = (SchemeGlobals.GetSchemeUnlocked(i) ? string.Empty : this.SchemeCosts[i].ToString());
				if (SchemeGlobals.GetSchemeStage(i) > SchemeGlobals.GetSchemePreviousStage(i))
				{
					SchemeGlobals.SetSchemePreviousStage(i, SchemeGlobals.GetSchemeStage(i));
					this.Exclamations[i].enabled = true;
				}
				else
				{
					this.Exclamations[i].enabled = false;
				}
			}
		}
	}

	public void UpdateSchemeInfo()
	{
		if (SchemeGlobals.GetSchemeStage(this.ID) != 100)
		{
			if (!SchemeGlobals.GetSchemeUnlocked(this.ID))
			{
				this.Arrow.gameObject.SetActive(false);
				this.PromptBar.Label[0].text = ((PlayerGlobals.PantyShots < this.SchemeCosts[this.ID]) ? string.Empty : "Purchase");
				this.PromptBar.UpdateButtons();
			}
			else if (SchemeGlobals.CurrentScheme == this.ID)
			{
				this.Arrow.gameObject.SetActive(true);
				this.Arrow.localPosition = new Vector3(this.Arrow.localPosition.x, -10f - 20f * (float)SchemeGlobals.GetSchemeStage(this.ID), this.Arrow.localPosition.z);
				this.PromptBar.Label[0].text = "Stop Tracking";
				this.PromptBar.UpdateButtons();
			}
			else
			{
				this.Arrow.gameObject.SetActive(false);
				this.PromptBar.Label[0].text = "Start Tracking";
				this.PromptBar.UpdateButtons();
			}
		}
		else
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 200f - 25f * (float)this.ID, this.Highlight.localPosition.z);
		this.SchemeIcon.mainTexture = this.SchemeIcons[this.ID];
		this.SchemeDesc.text = this.SchemeDescs[this.ID];
		if (SchemeGlobals.GetSchemeStage(this.ID) == 100)
		{
			this.SchemeInstructions.text = "This scheme is no longer available.";
		}
		else
		{
			this.SchemeInstructions.text = (SchemeGlobals.GetSchemeUnlocked(this.ID) ? this.SchemeSteps[this.ID] : ("Skills Required:\n" + this.SchemeSkills[this.ID]));
		}
		this.UpdatePantyCount();
	}

	public void UpdatePantyCount()
	{
		this.PantyCount.text = PlayerGlobals.PantyShots.ToString();
	}

	public void UpdateInstructions()
	{
		this.Steps = this.SchemeSteps[SchemeGlobals.CurrentScheme].Split(new char[]
		{
			'\n'
		});
		if (SchemeGlobals.CurrentScheme > 0)
		{
			if (SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) < 100)
			{
				this.HUDIcon.SetActive(true);
				this.HUDInstructions.text = this.Steps[SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) - 1].ToString();
			}
			else
			{
				this.Arrow.gameObject.SetActive(false);
				this.HUDIcon.gameObject.SetActive(false);
				this.HUDInstructions.text = string.Empty;
				SchemeGlobals.CurrentScheme = 0;
			}
		}
		else
		{
			this.HUDIcon.SetActive(false);
			this.HUDInstructions.text = string.Empty;
		}
	}

	public void UpdateSchemeDestinations()
	{
		if (this.StudentManager.Students[this.StudentManager.RivalID] != null)
		{
			this.Scheme1Destinations[3] = this.StudentManager.Students[this.StudentManager.RivalID].transform;
			this.Scheme1Destinations[7] = this.StudentManager.Students[this.StudentManager.RivalID].transform;
			this.Scheme4Destinations[5] = this.StudentManager.Students[this.StudentManager.RivalID].transform;
			this.Scheme4Destinations[6] = this.StudentManager.Students[this.StudentManager.RivalID].transform;
		}
		if (this.StudentManager.Students[2] != null)
		{
			this.Scheme2Destinations[1] = this.StudentManager.Students[2].transform;
		}
		if (this.StudentManager.Students[97] != null)
		{
			this.Scheme5Destinations[3] = this.StudentManager.Students[97].transform;
		}
		if (SchemeGlobals.CurrentScheme == 1)
		{
			this.SchemeDestinations = this.Scheme1Destinations;
		}
		else if (SchemeGlobals.CurrentScheme == 2)
		{
			this.SchemeDestinations = this.Scheme2Destinations;
		}
		else if (SchemeGlobals.CurrentScheme == 3)
		{
			this.SchemeDestinations = this.Scheme3Destinations;
		}
		else if (SchemeGlobals.CurrentScheme == 4)
		{
			this.SchemeDestinations = this.Scheme4Destinations;
		}
		else if (SchemeGlobals.CurrentScheme == 5)
		{
			this.SchemeDestinations = this.Scheme5Destinations;
		}
	}
}
