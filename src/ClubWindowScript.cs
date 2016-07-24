using System;
using UnityEngine;

[Serializable]
public class ClubWindowScript : MonoBehaviour
{
	public ClubManagerScript ClubManager;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public Transform ActivityWindow;

	public GameObject ClubInfo;

	public GameObject Window;

	public GameObject Warning;

	public string[] ActivityDescs;

	public string[] ClubNames;

	public string[] ClubDescs;

	public string MedAtmosphereDesc;

	public string LowAtmosphereDesc;

	public UILabel ActivityLabel;

	public UILabel BottomLabel;

	public UILabel ClubName;

	public UILabel ClubDesc;

	public bool PerformingActivity;

	public bool Activity;

	public bool Quitting;

	public float Timer;

	public int Club;

	public virtual void Start()
	{
		this.Window.active = false;
		if (PlayerPrefs.GetFloat("SchoolAtmosphere") < 33.33333f)
		{
			this.ActivityDescs[7] = this.LowAtmosphereDesc;
		}
		else if (PlayerPrefs.GetFloat("SchoolAtmosphere") < 66.66666f)
		{
			this.ActivityDescs[7] = this.MedAtmosphereDesc;
		}
	}

	public virtual void Update()
	{
		if (this.Window.active)
		{
			if (this.Timer > 0.5f)
			{
				if (Input.GetButtonDown("A"))
				{
					if (!this.Quitting && !this.Activity)
					{
						PlayerPrefs.SetInt("Club", this.Club);
						this.Yandere.ClubAccessory();
						this.Yandere.TargetStudent.Interaction = 11;
						this.ClubManager.ActivateClubBenefit();
					}
					else if (this.Quitting)
					{
						this.ClubManager.DeactivateClubBenefit();
						PlayerPrefs.SetInt("QuitClub_" + this.Club, 1);
						PlayerPrefs.SetInt("Club", 0);
						this.Yandere.ClubAccessory();
						this.Yandere.TargetStudent.Interaction = 12;
						this.Quitting = false;
					}
					else if (this.Activity)
					{
						this.Yandere.TargetStudent.Interaction = 14;
					}
					this.Yandere.TargetStudent.TalkTimer = (float)100;
					this.Yandere.TargetStudent.ClubPhase = 2;
					this.PromptBar.ClearButtons();
					this.PromptBar.Show = false;
					this.Window.active = false;
				}
				if (Input.GetButtonDown("B"))
				{
					if (!this.Quitting && !this.Activity)
					{
						this.Yandere.TargetStudent.Interaction = 11;
					}
					else if (this.Quitting)
					{
						this.Yandere.TargetStudent.Interaction = 12;
						this.Quitting = false;
					}
					else if (this.Activity)
					{
						this.Yandere.TargetStudent.Interaction = 14;
						this.Activity = false;
					}
					this.Yandere.TargetStudent.TalkTimer = (float)100;
					this.Yandere.TargetStudent.ClubPhase = 3;
					this.PromptBar.ClearButtons();
					this.PromptBar.Show = false;
					this.Window.active = false;
				}
				if (Input.GetButtonDown("X") && !this.Quitting && !this.Activity)
				{
					if (!this.Warning.active)
					{
						this.ClubInfo.active = false;
						this.Warning.active = true;
					}
					else
					{
						this.ClubInfo.active = true;
						this.Warning.active = false;
					}
				}
			}
			this.Timer += Time.deltaTime;
		}
		if (this.PerformingActivity)
		{
			this.ActivityWindow.localScale = Vector3.Lerp(this.ActivityWindow.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
		}
		else if (this.ActivityWindow.localScale.x > 0.1f)
		{
			this.ActivityWindow.localScale = Vector3.Lerp(this.ActivityWindow.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
		}
		else
		{
			this.ActivityWindow.localScale = new Vector3((float)0, (float)0, (float)0);
		}
	}

	public virtual void UpdateWindow()
	{
		this.ClubName.text = this.ClubNames[this.Club];
		if (!this.Quitting && !this.Activity)
		{
			this.ClubDesc.text = this.ClubDescs[this.Club];
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Refuse";
			this.PromptBar.Label[2].text = "More Info";
			this.PromptBar.UpdateButtons();
			this.PromptBar.Show = true;
			this.BottomLabel.text = "Will you join the " + this.ClubNames[this.Club] + "?";
		}
		else if (this.Activity)
		{
			this.ClubDesc.text = "Club activities last until 6:00 PM. If you choose to participate in club activities now, the day will end." + "\n" + "\n" + "If you don't join by 5:30 PM, you won't be able to participate in club activities today." + "\n" + "\n" + "If you don't participate in club activities at least once a week, you will be removed from the club.";
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Yes";
			this.PromptBar.Label[1].text = "No";
			this.PromptBar.UpdateButtons();
			this.PromptBar.Show = true;
			this.BottomLabel.text = "Will you participate in club activities?";
		}
		else if (this.Quitting)
		{
			this.ClubDesc.text = "Are you sure you want to quit this club? If you quit, you will never be allowed to return.";
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Confirm";
			this.PromptBar.Label[1].text = "Deny";
			this.PromptBar.UpdateButtons();
			this.PromptBar.Show = true;
			this.BottomLabel.text = "Will you quit the " + this.ClubNames[this.Club] + "?";
		}
		this.ClubInfo.active = true;
		this.Warning.active = false;
		this.Window.active = true;
		this.Timer = (float)0;
	}

	public virtual void Main()
	{
	}
}
