using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class DropsScript : MonoBehaviour
{
	public InfoChanWindowScript InfoChanWindow;

	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public SchemesScript Schemes;

	public GameObject FavorMenu;

	public Transform Highlight;

	public UILabel PantyCount;

	public UITexture DropIcon;

	public UILabel DropDesc;

	public UILabel[] CostLabels;

	public UILabel[] NameLabels;

	public bool[] Purchased;

	public Texture[] DropIcons;

	public int[] DropCosts;

	public string[] DropDescs;

	public string[] DropNames;

	public int Selected;

	public int ID;

	public AudioClip InfoUnavailable;

	public AudioClip InfoPurchase;

	public AudioClip InfoAfford;

	public DropsScript()
	{
		this.Selected = 1;
		this.ID = 1;
	}

	public virtual void Start()
	{
		for (int i = 1; i < Extensions.get_length(this.DropNames); i++)
		{
			this.NameLabels[i].text = this.DropNames[i];
		}
	}

	public virtual void Update()
	{
		if (this.InputManager.TappedUp)
		{
			this.Selected--;
			if (this.Selected < 1)
			{
				this.Selected = Extensions.get_length(this.DropNames) - 1;
			}
			this.UpdateDesc();
		}
		if (this.InputManager.TappedDown)
		{
			this.Selected++;
			if (this.Selected > Extensions.get_length(this.DropNames) - 1)
			{
				this.Selected = 1;
			}
			this.UpdateDesc();
		}
		if (Input.GetButtonDown("A"))
		{
			if (!this.Purchased[this.Selected])
			{
				if (this.PromptBar.Label[0].text != string.Empty)
				{
					if (PlayerPrefs.GetInt("PantyShots") >= this.DropCosts[this.Selected])
					{
						PlayerPrefs.SetInt("PantyShots", PlayerPrefs.GetInt("PantyShots") - this.DropCosts[this.Selected]);
						this.Purchased[this.Selected] = true;
						this.InfoChanWindow.Orders = this.InfoChanWindow.Orders + 1;
						this.InfoChanWindow.ItemsToDrop[this.InfoChanWindow.Orders] = this.Selected;
						this.InfoChanWindow.DropObject();
						this.UpdateList();
						this.UpdateDesc();
						this.audio.clip = this.InfoPurchase;
						this.audio.Play();
						if (this.Selected == 2)
						{
							PlayerPrefs.SetInt("Scheme_3_Stage", 2);
							this.Schemes.UpdateInstructions();
						}
					}
				}
				else if (PlayerPrefs.GetInt("PantyShots") < this.DropCosts[this.Selected])
				{
					this.audio.clip = this.InfoAfford;
					this.audio.Play();
				}
				else
				{
					this.audio.clip = this.InfoUnavailable;
					this.audio.Play();
				}
			}
			else
			{
				this.audio.clip = this.InfoUnavailable;
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

	public virtual void UpdateList()
	{
		this.ID = 1;
		while (this.ID < Extensions.get_length(this.DropNames))
		{
			if (!this.Purchased[this.ID])
			{
				this.CostLabels[this.ID].text = string.Empty + this.DropCosts[this.ID];
				int num = 1;
				Color color = this.NameLabels[this.ID].color;
				float num2 = color.a = (float)num;
				Color color2 = this.NameLabels[this.ID].color = color;
			}
			else
			{
				this.CostLabels[this.ID].text = string.Empty;
				float a = 0.5f;
				Color color3 = this.NameLabels[this.ID].color;
				float num3 = color3.a = a;
				Color color4 = this.NameLabels[this.ID].color = color3;
			}
			this.ID++;
		}
	}

	public virtual void UpdateDesc()
	{
		if (!this.Purchased[this.Selected])
		{
			if (PlayerPrefs.GetInt("PantyShots") >= this.DropCosts[this.Selected])
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
		else
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		int num = 200 - 25 * this.Selected;
		Vector3 localPosition = this.Highlight.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.Highlight.localPosition = localPosition;
		this.DropIcon.mainTexture = this.DropIcons[this.Selected];
		this.DropDesc.text = this.DropDescs[this.Selected];
		this.UpdatePantyCount();
	}

	public virtual void UpdatePantyCount()
	{
		this.PantyCount.text = string.Empty + PlayerPrefs.GetInt("PantyShots");
	}

	public virtual void Main()
	{
	}
}
