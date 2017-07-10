using System;
using UnityEngine;

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

	public int Selected = 1;

	public int ID = 1;

	public AudioClip InfoUnavailable;

	public AudioClip InfoPurchase;

	public AudioClip InfoAfford;

	private void Start()
	{
		this.ID = 1;
		while (this.ID < this.DropNames.Length)
		{
			this.NameLabels[this.ID].text = this.DropNames[this.ID];
			this.ID++;
		}
	}

	private void Update()
	{
		if (this.InputManager.TappedUp)
		{
			this.Selected--;
			if (this.Selected < 1)
			{
				this.Selected = this.DropNames.Length - 1;
			}
			this.UpdateDesc();
		}
		if (this.InputManager.TappedDown)
		{
			this.Selected++;
			if (this.Selected > this.DropNames.Length - 1)
			{
				this.Selected = 1;
			}
			this.UpdateDesc();
		}
		if (Input.GetButtonDown("A"))
		{
			AudioSource component = base.GetComponent<AudioSource>();
			if (!this.Purchased[this.Selected])
			{
				if (!this.PromptBar.Label[0].text.Equals(string.Empty))
				{
					if (PlayerPrefs.GetInt("PantyShots") >= this.DropCosts[this.Selected])
					{
						PlayerPrefs.SetInt("PantyShots", PlayerPrefs.GetInt("PantyShots") - this.DropCosts[this.Selected]);
						this.Purchased[this.Selected] = true;
						this.InfoChanWindow.Orders++;
						this.InfoChanWindow.ItemsToDrop[this.InfoChanWindow.Orders] = this.Selected;
						this.InfoChanWindow.DropObject();
						this.UpdateList();
						this.UpdateDesc();
						component.clip = this.InfoPurchase;
						component.Play();
						if (this.Selected == 2)
						{
							PlayerPrefs.SetInt("Scheme_3_Stage", 2);
							this.Schemes.UpdateInstructions();
						}
					}
				}
				else if (PlayerPrefs.GetInt("PantyShots") < this.DropCosts[this.Selected])
				{
					component.clip = this.InfoAfford;
					component.Play();
				}
				else
				{
					component.clip = this.InfoUnavailable;
					component.Play();
				}
			}
			else
			{
				component.clip = this.InfoUnavailable;
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

	public void UpdateList()
	{
		this.ID = 1;
		while (this.ID < this.DropNames.Length)
		{
			UILabel uilabel = this.NameLabels[this.ID];
			if (!this.Purchased[this.ID])
			{
				this.CostLabels[this.ID].text = this.DropCosts[this.ID].ToString();
				uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 1f);
			}
			else
			{
				this.CostLabels[this.ID].text = string.Empty;
				uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
			}
			this.ID++;
		}
	}

	public void UpdateDesc()
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
		this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 200f - 25f * (float)this.Selected, this.Highlight.localPosition.z);
		this.DropIcon.mainTexture = this.DropIcons[this.Selected];
		this.DropDesc.text = this.DropDescs[this.Selected];
		this.UpdatePantyCount();
	}

	public void UpdatePantyCount()
	{
		this.PantyCount.text = PlayerPrefs.GetInt("PantyShots").ToString();
	}
}
