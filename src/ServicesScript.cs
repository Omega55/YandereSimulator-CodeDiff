﻿using System;
using UnityEngine;

public class ServicesScript : MonoBehaviour
{
	public TextMessageManagerScript TextMessageManager;

	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public ReputationScript Reputation;

	public InventoryScript Inventory;

	public PromptBarScript PromptBar;

	public SchemesScript Schemes;

	public YandereScript Yandere;

	public GameObject FavorMenu;

	public Transform Highlight;

	public AudioSource MyAudio;

	public PoliceScript Police;

	public UITexture ServiceIcon;

	public UILabel ServiceLimit;

	public UILabel ServiceDesc;

	public UILabel PantyCount;

	public UILabel[] CostLabels;

	public UILabel[] NameLabels;

	public Texture[] ServiceIcons;

	public string[] ServiceLimits;

	public string[] ServiceDescs;

	public string[] ServiceNames;

	public bool[] ServiceAvailable;

	public bool[] ServicePurchased;

	public int[] ServiceCosts;

	public int Selected = 1;

	public int ID = 1;

	public AudioClip InfoUnavailable;

	public AudioClip InfoPurchase;

	public AudioClip InfoAfford;

	private void Start()
	{
		for (int i = 1; i < this.ServiceNames.Length; i++)
		{
			SchemeGlobals.SetServicePurchased(i, false);
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
		if (Input.GetButtonDown("A"))
		{
			if (!SchemeGlobals.GetServicePurchased(this.Selected) && (double)this.NameLabels[this.Selected].color.a == 1.0)
			{
				if (this.PromptBar.Label[0].text != string.Empty)
				{
					if (this.Inventory.PantyShots >= this.ServiceCosts[this.Selected])
					{
						if (this.Selected == 1)
						{
							this.Yandere.PauseScreen.StudentInfoMenu.GettingInfo = true;
							this.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
							this.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
							this.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
							this.Yandere.PauseScreen.Sideways = true;
							this.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
							base.StartCoroutine(this.Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
							this.Yandere.PromptBar.ClearButtons();
							this.Yandere.PromptBar.Label[1].text = "Cancel";
							this.Yandere.PromptBar.UpdateButtons();
							this.Yandere.PromptBar.Show = true;
							base.gameObject.SetActive(false);
						}
						if (this.Selected == 2)
						{
							this.Reputation.PendingRep += 5f;
							this.Purchase();
						}
						else if (this.Selected == 3)
						{
							StudentGlobals.SetStudentReputation(this.StudentManager.RivalID, StudentGlobals.GetStudentReputation(this.StudentManager.RivalID) - 5);
							this.Purchase();
						}
						else if (this.Selected == 4)
						{
							SchemeGlobals.SetServicePurchased(this.Selected, true);
							SchemeGlobals.DarkSecret = true;
							this.Purchase();
						}
						else if (this.Selected == 5)
						{
							this.Yandere.PauseScreen.StudentInfoMenu.SendingHome = true;
							this.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
							this.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
							this.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
							this.Yandere.PauseScreen.Sideways = true;
							this.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
							this.Yandere.PauseScreen.StudentInfoMenu.GrabbedPortraits = false;
							base.StartCoroutine(this.Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
							this.Yandere.PromptBar.ClearButtons();
							this.Yandere.PromptBar.Label[1].text = "Cancel";
							this.Yandere.PromptBar.UpdateButtons();
							this.Yandere.PromptBar.Show = true;
							base.gameObject.SetActive(false);
						}
						else if (this.Selected == 6)
						{
							this.Police.Timer += 300f;
							this.Police.Delayed = true;
							this.Purchase();
						}
						else if (this.Selected == 7)
						{
							SchemeGlobals.SetServicePurchased(this.Selected, true);
							CounselorGlobals.CounselorTape = 1;
							this.Purchase();
						}
						else if (this.Selected == 8)
						{
							SchemeGlobals.SetServicePurchased(this.Selected, true);
							for (int i = 1; i < 26; i++)
							{
								ConversationGlobals.SetTopicLearnedByStudent(i, 11, true);
							}
							this.Purchase();
						}
						else if (this.Selected == 9)
						{
							this.Yandere.PauseScreen.StudentInfoMenu.FiringCouncilMember = true;
							this.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
							this.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
							this.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
							this.Yandere.PauseScreen.Sideways = true;
							this.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
							this.Yandere.PauseScreen.StudentInfoMenu.GrabbedPortraits = false;
							base.StartCoroutine(this.Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
							this.Yandere.PromptBar.ClearButtons();
							this.Yandere.PromptBar.Label[1].text = "Cancel";
							this.Yandere.PromptBar.UpdateButtons();
							this.Yandere.PromptBar.Show = true;
							base.gameObject.SetActive(false);
						}
					}
				}
				else if (this.Inventory.PantyShots < this.ServiceCosts[this.Selected])
				{
					this.MyAudio.clip = this.InfoAfford;
					this.MyAudio.Play();
				}
				else
				{
					this.MyAudio.clip = this.InfoUnavailable;
					this.MyAudio.Play();
				}
			}
			else
			{
				this.MyAudio.clip = this.InfoUnavailable;
				this.MyAudio.Play();
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
			bool servicePurchased = SchemeGlobals.GetServicePurchased(this.ID);
			this.ServiceAvailable[this.ID] = false;
			if (this.ID == 1 || this.ID == 2 || this.ID == 3)
			{
				this.ServiceAvailable[this.ID] = true;
			}
			else if (this.ID == 4)
			{
				if (!SchemeGlobals.DarkSecret)
				{
					this.ServiceAvailable[this.ID] = true;
				}
			}
			else if (this.ID == 5)
			{
				if (!this.ServicePurchased[this.ID])
				{
					this.ServiceAvailable[this.ID] = true;
				}
			}
			else if (this.ID == 6)
			{
				if (this.Police.Show && !this.Police.Delayed)
				{
					this.ServiceAvailable[this.ID] = true;
				}
			}
			else if (this.ID == 7)
			{
				if (CounselorGlobals.CounselorTape == 0)
				{
					this.ServiceAvailable[this.ID] = true;
				}
			}
			else if (this.ID == 8)
			{
				if (!SchemeGlobals.GetServicePurchased(8))
				{
					this.ServiceAvailable[this.ID] = true;
				}
			}
			else if (this.ID == 9 && MissionModeGlobals.MissionMode)
			{
				this.ServiceAvailable[this.ID] = true;
			}
			UILabel uilabel = this.NameLabels[this.ID];
			uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, (this.ServiceAvailable[this.ID] && !servicePurchased) ? 1f : 0.5f);
			this.ID++;
		}
	}

	public void UpdateDesc()
	{
		if (this.ServiceAvailable[this.Selected] && !SchemeGlobals.GetServicePurchased(this.Selected))
		{
			this.PromptBar.Label[0].text = ((this.Inventory.PantyShots >= this.ServiceCosts[this.Selected]) ? "Purchase" : string.Empty);
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
		if (this.Selected == 5)
		{
			this.ServiceDesc.text = this.ServiceDescs[this.Selected] + "\n\nIf student portraits don't appear, back out of the menu, load the Student Info menu, then return to this screen.";
		}
		this.UpdatePantyCount();
	}

	public void UpdatePantyCount()
	{
		this.PantyCount.text = this.Inventory.PantyShots.ToString();
	}

	public void Purchase()
	{
		this.ServicePurchased[this.Selected] = true;
		this.TextMessageManager.SpawnMessage(this.Selected);
		this.Inventory.PantyShots -= this.ServiceCosts[this.Selected];
		AudioSource.PlayClipAtPoint(this.InfoPurchase, base.transform.position);
		this.UpdateList();
		this.UpdateDesc();
		this.PromptBar.Label[0].text = string.Empty;
		this.PromptBar.Label[1].text = "Back";
		this.PromptBar.UpdateButtons();
	}
}
