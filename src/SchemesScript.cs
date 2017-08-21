using System;
using UnityEngine;

public class SchemesScript : MonoBehaviour
{
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

	public string[] SchemeDeadlines;

	public string[] SchemeSkills;

	public string[] SchemeDescs;

	public string[] SchemeNames;

	public string[] SchemeSteps;

	public int ID = 1;

	public string[] Steps;

	public AudioClip InfoPurchase;

	public AudioClip InfoAfford;

	public GameObject HUDIcon;

	public UILabel HUDInstructions;

	private void Start()
	{
		for (int i = 1; i < this.SchemeNames.Length; i++)
		{
			if (!Globals.GetSchemeStatus(i))
			{
				this.SchemeDeadlineLabels[i].text = this.SchemeDeadlines[i];
				this.SchemeNameLabels[i].text = this.SchemeNames[i];
			}
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
				if (!Globals.GetSchemeUnlocked(this.ID))
				{
					if (Globals.PantyShots >= this.SchemeCosts[this.ID])
					{
						Globals.PantyShots -= this.SchemeCosts[this.ID];
						Globals.SetSchemeUnlocked(this.ID, true);
						Globals.CurrentScheme = this.ID;
						if (Globals.GetSchemeStage(this.ID) == 0)
						{
							Globals.SetSchemeStage(this.ID, 1);
						}
						this.UpdateInstructions();
						this.UpdateSchemeList();
						this.UpdateSchemeInfo();
						component.clip = this.InfoPurchase;
						component.Play();
					}
				}
				else
				{
					if (Globals.CurrentScheme == this.ID)
					{
						Globals.CurrentScheme = 0;
					}
					else
					{
						Globals.CurrentScheme = this.ID;
					}
					this.UpdateSchemeInfo();
					this.UpdateInstructions();
				}
			}
			else if (Globals.GetSchemeStage(this.ID) != 100 && Globals.PantyShots < this.SchemeCosts[this.ID])
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
			if (Globals.GetSchemeStage(i) == 100)
			{
				UILabel uilabel = this.SchemeNameLabels[i];
				uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
				this.Exclamations[i].enabled = false;
				this.SchemeCostLabels[i].text = string.Empty;
			}
			else
			{
				this.SchemeCostLabels[i].text = (Globals.GetSchemeUnlocked(i) ? string.Empty : this.SchemeCosts[i].ToString());
				if (Globals.GetSchemeStage(i) > Globals.GetSchemePreviousStage(i))
				{
					Globals.SetSchemePreviousStage(i, Globals.GetSchemeStage(i));
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
		if (Globals.GetSchemeStage(this.ID) != 100)
		{
			if (!Globals.GetSchemeUnlocked(this.ID))
			{
				this.Arrow.gameObject.SetActive(false);
				this.PromptBar.Label[0].text = ((Globals.PantyShots < this.SchemeCosts[this.ID]) ? string.Empty : "Purchase");
				this.PromptBar.UpdateButtons();
			}
			else if (Globals.CurrentScheme == this.ID)
			{
				this.Arrow.gameObject.SetActive(true);
				this.Arrow.localPosition = new Vector3(this.Arrow.localPosition.x, -17f - 28f * (float)Globals.GetSchemeStage(this.ID), this.Arrow.localPosition.z);
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
		if (Globals.GetSchemeStage(this.ID) == 100)
		{
			this.SchemeInstructions.text = "This scheme is no longer available.";
		}
		else
		{
			this.SchemeInstructions.text = (Globals.GetSchemeUnlocked(this.ID) ? this.SchemeSteps[this.ID] : ("Skills Required:\n" + this.SchemeSkills[this.ID]));
		}
		this.UpdatePantyCount();
	}

	public void UpdatePantyCount()
	{
		this.PantyCount.text = Globals.PantyShots.ToString();
	}

	public void UpdateInstructions()
	{
		this.Steps = this.SchemeSteps[Globals.CurrentScheme].Split(new char[]
		{
			'\n'
		});
		if (Globals.CurrentScheme > 0)
		{
			if (Globals.GetSchemeStage(Globals.CurrentScheme) < 100)
			{
				this.HUDIcon.SetActive(true);
				this.HUDInstructions.text = this.Steps[Globals.GetSchemeStage(Globals.CurrentScheme) - 1].ToString();
			}
			else
			{
				this.Arrow.gameObject.SetActive(false);
				this.HUDIcon.gameObject.SetActive(false);
				this.HUDInstructions.text = string.Empty;
				Globals.CurrentScheme = 0;
			}
		}
		else
		{
			this.HUDIcon.SetActive(false);
			this.HUDInstructions.text = string.Empty;
		}
	}
}
