using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
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

	public int ID;

	public string[] Steps;

	public AudioClip InfoPurchase;

	public AudioClip InfoAfford;

	public GameObject HUDIcon;

	public UILabel HUDInstructions;

	public SchemesScript()
	{
		this.ID = 1;
	}

	public virtual void Start()
	{
		for (int i = 1; i < Extensions.get_length(this.SchemeNames); i++)
		{
			if (PlayerPrefs.GetInt("Scheme_" + i + "_Status") == 0)
			{
				this.SchemeDeadlineLabels[i].text = this.SchemeDeadlines[i];
				this.SchemeNameLabels[i].text = this.SchemeNames[i];
			}
		}
	}

	public virtual void Update()
	{
		if (this.InputManager.TappedUp)
		{
			this.ID--;
			if (this.ID < 1)
			{
				this.ID = Extensions.get_length(this.SchemeNames) - 1;
			}
			this.UpdateSchemeInfo();
		}
		if (this.InputManager.TappedDown)
		{
			this.ID++;
			if (this.ID > Extensions.get_length(this.SchemeNames) - 1)
			{
				this.ID = 1;
			}
			this.UpdateSchemeInfo();
		}
		if (Input.GetButtonDown("A"))
		{
			if (this.PromptBar.Label[0].text != string.Empty)
			{
				if (PlayerPrefs.GetInt("Scheme_" + this.ID + "_Unlocked") == 0)
				{
					if (PlayerPrefs.GetInt("PantyShots") >= this.SchemeCosts[this.ID])
					{
						PlayerPrefs.SetInt("PantyShots", PlayerPrefs.GetInt("PantyShots") - this.SchemeCosts[this.ID]);
						PlayerPrefs.SetInt("Scheme_" + this.ID + "_Unlocked", 1);
						PlayerPrefs.SetInt("CurrentScheme", this.ID);
						if (PlayerPrefs.GetInt("Scheme_" + this.ID + "_Stage") == 0)
						{
							PlayerPrefs.SetInt("Scheme_" + this.ID + "_Stage", 1);
						}
						this.UpdateInstructions();
						this.UpdateSchemeList();
						this.UpdateSchemeInfo();
						this.audio.clip = this.InfoPurchase;
						this.audio.Play();
					}
				}
				else
				{
					if (PlayerPrefs.GetInt("CurrentScheme") == this.ID)
					{
						PlayerPrefs.SetInt("CurrentScheme", 0);
					}
					else
					{
						PlayerPrefs.SetInt("CurrentScheme", this.ID);
					}
					this.UpdateSchemeInfo();
					this.UpdateInstructions();
				}
			}
			else if (PlayerPrefs.GetInt("Scheme_" + this.ID + "_Stage") != 100 && PlayerPrefs.GetInt("PantyShots") < this.SchemeCosts[this.ID])
			{
				this.audio.clip = this.InfoAfford;
				this.audio.Play();
			}
		}
		if (Input.GetButtonDown("B") && Input.GetButtonDown("B"))
		{
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[5].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.FavorMenu.active = true;
			this.active = false;
		}
	}

	public virtual void UpdateSchemeList()
	{
		for (int i = 1; i < Extensions.get_length(this.SchemeNames); i++)
		{
			if (PlayerPrefs.GetInt("Scheme_" + i + "_Stage") == 100)
			{
				float a = 0.5f;
				Color color = this.SchemeNameLabels[i].color;
				float num = color.a = a;
				Color color2 = this.SchemeNameLabels[i].color = color;
				this.Exclamations[i].enabled = false;
				this.SchemeCostLabels[i].text = string.Empty;
			}
			else
			{
				if (PlayerPrefs.GetInt("Scheme_" + i + "_Unlocked") == 0)
				{
					this.SchemeCostLabels[i].text = string.Empty + this.SchemeCosts[i];
				}
				else
				{
					this.SchemeCostLabels[i].text = string.Empty;
				}
				if (PlayerPrefs.GetInt("Scheme_" + i + "_Stage") > PlayerPrefs.GetInt("Scheme_" + i + "_PreviousStage"))
				{
					PlayerPrefs.SetInt("Scheme_" + i + "_PreviousStage", PlayerPrefs.GetInt("Scheme_" + i + "_Stage"));
					this.Exclamations[i].enabled = true;
				}
				else
				{
					this.Exclamations[i].enabled = false;
				}
			}
		}
	}

	public virtual void UpdateSchemeInfo()
	{
		if (PlayerPrefs.GetInt("Scheme_" + this.ID + "_Stage") != 100)
		{
			if (PlayerPrefs.GetInt("Scheme_" + this.ID + "_Unlocked") == 0)
			{
				this.Arrow.gameObject.active = false;
				if (PlayerPrefs.GetInt("PantyShots") >= this.SchemeCosts[this.ID])
				{
					this.PromptBar.Label[0].text = "Purchase";
					this.PromptBar.UpdateButtons();
				}
				else
				{
					this.PromptBar.Label[0].text = string.Empty;
					this.PromptBar.UpdateButtons();
				}
			}
			else if (PlayerPrefs.GetInt("CurrentScheme") == this.ID)
			{
				this.Arrow.gameObject.active = true;
				int num = -17 - 28 * PlayerPrefs.GetInt("Scheme_" + this.ID + "_Stage");
				Vector3 localPosition = this.Arrow.localPosition;
				float num2 = localPosition.y = (float)num;
				Vector3 vector = this.Arrow.localPosition = localPosition;
				this.PromptBar.Label[0].text = "Stop Tracking";
				this.PromptBar.UpdateButtons();
			}
			else
			{
				this.Arrow.gameObject.active = false;
				this.PromptBar.Label[0].text = "Start Tracking";
				this.PromptBar.UpdateButtons();
			}
		}
		else
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		int num3 = 200 - 25 * this.ID;
		Vector3 localPosition2 = this.Highlight.localPosition;
		float num4 = localPosition2.y = (float)num3;
		Vector3 vector2 = this.Highlight.localPosition = localPosition2;
		this.SchemeIcon.mainTexture = this.SchemeIcons[this.ID];
		this.SchemeDesc.text = this.SchemeDescs[this.ID];
		if (PlayerPrefs.GetInt("Scheme_" + this.ID + "_Stage") == 100)
		{
			this.SchemeInstructions.text = "This scheme is no longer available.";
		}
		else if (PlayerPrefs.GetInt("Scheme_" + this.ID + "_Unlocked") == 0)
		{
			this.SchemeInstructions.text = "Skills Required:" + "\n" + this.SchemeSkills[this.ID];
		}
		else
		{
			this.SchemeInstructions.text = this.SchemeSteps[this.ID];
		}
		this.UpdatePantyCount();
	}

	public virtual void UpdatePantyCount()
	{
		this.PantyCount.text = string.Empty + PlayerPrefs.GetInt("PantyShots");
	}

	public virtual void UpdateInstructions()
	{
		this.Steps = this.SchemeSteps[PlayerPrefs.GetInt("CurrentScheme")].Split(new char[]
		{
			"\n"[0]
		});
		if (PlayerPrefs.GetInt("CurrentScheme") > 0)
		{
			if (PlayerPrefs.GetInt("Scheme_" + PlayerPrefs.GetInt("CurrentScheme") + "_Stage") < 100)
			{
				this.HUDIcon.active = true;
				this.HUDInstructions.text = string.Empty + this.Steps[PlayerPrefs.GetInt("Scheme_" + PlayerPrefs.GetInt("CurrentScheme") + "_Stage") - 1];
			}
			else
			{
				this.Arrow.gameObject.active = false;
				this.HUDIcon.gameObject.active = false;
				this.HUDInstructions.text = string.Empty;
				PlayerPrefs.SetInt("CurrentScheme", 0);
			}
		}
		else
		{
			this.HUDIcon.active = false;
			this.HUDInstructions.text = string.Empty;
		}
	}

	public virtual void Main()
	{
	}
}
