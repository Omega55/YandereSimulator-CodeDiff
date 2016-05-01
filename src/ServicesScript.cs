using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ServicesScript : MonoBehaviour
{
	public TextMessageManagerScript TextMessageManager;

	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public SchemesScript Schemes;

	public GameObject FavorMenu;

	public Transform Highlight;

	public UILabel PantyCount;

	public UITexture ServiceIcon;

	public UILabel ServiceLimit;

	public UILabel ServiceDesc;

	public UILabel[] CostLabels;

	public UILabel[] NameLabels;

	public Texture[] ServiceIcons;

	public int[] ServiceCosts;

	public bool[] ServiceActive;

	public string[] ServiceLimits;

	public string[] ServiceDescs;

	public string[] ServiceNames;

	public int Selected;

	public int ID;

	public AudioClip InfoPurchase;

	public AudioClip InfoAfford;

	public ServicesScript()
	{
		this.Selected = 1;
		this.ID = 1;
	}

	public virtual void Start()
	{
		for (int i = 1; i < Extensions.get_length(this.ServiceNames); i++)
		{
			PlayerPrefs.SetInt("Service_" + i + "_Purchased", 0);
			this.NameLabels[i].text = this.ServiceNames[i];
		}
	}

	public virtual void Update()
	{
		if (this.InputManager.TappedUp)
		{
			this.Selected--;
			if (this.Selected < 1)
			{
				this.Selected = Extensions.get_length(this.ServiceNames) - 1;
			}
			this.UpdateDesc();
		}
		if (this.InputManager.TappedDown)
		{
			this.Selected++;
			if (this.Selected > Extensions.get_length(this.ServiceNames) - 1)
			{
				this.Selected = 1;
			}
			this.UpdateDesc();
		}
		if (Input.GetButtonDown("A") && PlayerPrefs.GetInt("Service_" + this.Selected + "_Purchased") == 0)
		{
			if (this.PromptBar.Label[0].text != string.Empty)
			{
				if (PlayerPrefs.GetInt("PantyShots") >= this.ServiceCosts[this.Selected])
				{
					PlayerPrefs.SetInt("PantyShots", PlayerPrefs.GetInt("PantyShots") - this.ServiceCosts[this.Selected]);
					PlayerPrefs.SetInt("Service_" + this.Selected + "_Purchased", 1);
					if (this.Selected == 4)
					{
						PlayerPrefs.SetInt("Scheme_1_Stage", 2);
						this.Schemes.UpdateInstructions();
						PlayerPrefs.SetInt("DarkSecret", 1);
						this.TextMessageManager.SpawnMessage();
					}
					this.UpdateList();
					this.UpdateDesc();
					this.audio.clip = this.InfoPurchase;
					this.audio.Play();
				}
			}
			else if (PlayerPrefs.GetInt("PantyShots") < this.ServiceCosts[this.Selected])
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

	public virtual void UpdateList()
	{
		this.ID = 1;
		while (this.ID < Extensions.get_length(this.ServiceNames))
		{
			this.CostLabels[this.ID].text = string.Empty + this.ServiceCosts[this.ID];
			if (this.ServiceActive[this.ID] && PlayerPrefs.GetInt("Service_" + this.ID + "_Purchased") == 0)
			{
				int num = 1;
				Color color = this.NameLabels[this.ID].color;
				float num2 = color.a = (float)num;
				Color color2 = this.NameLabels[this.ID].color = color;
			}
			else
			{
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
		if (this.ServiceActive[this.Selected] && PlayerPrefs.GetInt("Service_" + this.Selected + "_Purchased") == 0)
		{
			if (PlayerPrefs.GetInt("PantyShots") >= this.ServiceCosts[this.Selected])
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
		this.ServiceIcon.mainTexture = this.ServiceIcons[this.Selected];
		this.ServiceLimit.text = this.ServiceLimits[this.Selected];
		this.ServiceDesc.text = this.ServiceDescs[this.Selected];
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
