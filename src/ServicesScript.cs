using System;
using UnityEngine;

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

	public int Selected = 1;

	public int ID = 1;

	public AudioClip InfoUnavailable;

	public AudioClip InfoPurchase;

	public AudioClip InfoAfford;

	private void Start()
	{
		for (int i = 1; i < this.ServiceNames.Length; i++)
		{
			PlayerPrefs.SetInt("Service_" + i.ToString() + "_Purchased", 0);
			this.NameLabels[i].text = this.ServiceNames[i];
		}
	}

	private void Update()
	{
		if (this.InputManager.TappedUp)
		{
			this.Selected--;
			if (this.Selected < 1)
			{
				this.Selected = this.ServiceNames.Length - 1;
			}
			this.UpdateDesc();
		}
		if (this.InputManager.TappedDown)
		{
			this.Selected++;
			if (this.Selected > this.ServiceNames.Length - 1)
			{
				this.Selected = 1;
			}
			this.UpdateDesc();
		}
		AudioSource component = base.GetComponent<AudioSource>();
		if (Input.GetButtonDown("A"))
		{
			if (PlayerPrefs.GetInt("Service_" + this.Selected.ToString() + "_Purchased") == 0)
			{
				if (this.PromptBar.Label[0].text != string.Empty)
				{
					if (PlayerPrefs.GetInt("PantyShots") >= this.ServiceCosts[this.Selected])
					{
						PlayerPrefs.SetInt("PantyShots", PlayerPrefs.GetInt("PantyShots") - this.ServiceCosts[this.Selected]);
						PlayerPrefs.SetInt("Service_" + this.Selected.ToString() + "_Purchased", 1);
						AudioSource.PlayClipAtPoint(this.InfoPurchase, base.transform.position);
						if (this.Selected == 4)
						{
							PlayerPrefs.SetInt("Scheme_1_Stage", 2);
							this.Schemes.UpdateInstructions();
							PlayerPrefs.SetInt("DarkSecret", 1);
							this.TextMessageManager.SpawnMessage();
						}
						this.UpdateList();
						this.UpdateDesc();
					}
				}
				else if (PlayerPrefs.GetInt("PantyShots") < this.ServiceCosts[this.Selected])
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
		while (this.ID < this.ServiceNames.Length)
		{
			this.CostLabels[this.ID].text = this.ServiceCosts[this.ID].ToString();
			int @int = PlayerPrefs.GetInt("Service_" + this.ID.ToString() + "_Purchased");
			UILabel uilabel = this.NameLabels[this.ID];
			uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, (!this.ServiceActive[this.ID] || @int != 0) ? 0.5f : 1f);
			this.ID++;
		}
	}

	public void UpdateDesc()
	{
		if (this.ServiceActive[this.Selected] && PlayerPrefs.GetInt("Service_" + this.Selected.ToString() + "_Purchased") == 0)
		{
			this.PromptBar.Label[0].text = ((PlayerPrefs.GetInt("PantyShots") < this.ServiceCosts[this.Selected]) ? string.Empty : "Purchase");
			this.PromptBar.UpdateButtons();
		}
		else
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 200f - 25f * (float)this.Selected, this.Highlight.localPosition.z);
		this.ServiceIcon.mainTexture = this.ServiceIcons[this.Selected];
		this.ServiceLimit.text = this.ServiceLimits[this.Selected];
		this.ServiceDesc.text = this.ServiceDescs[this.Selected];
		this.UpdatePantyCount();
	}

	public void UpdatePantyCount()
	{
		this.PantyCount.text = PlayerPrefs.GetInt("PantyShots").ToString();
	}
}
