using System;
using UnityEngine;

[Serializable]
public class TranqDetectorScript : MonoBehaviour
{
	public YandereScript Yandere;

	public DoorScript Door;

	public UIPanel Checklist;

	public Collider MyCollider;

	public UILabel KidnappingLabel;

	public UISprite TranquilizerIcon;

	public UISprite FollowerIcon;

	public UISprite BiologyIcon;

	public UISprite SyringeIcon;

	public UISprite DoorIcon;

	public bool StopChecking;

	public virtual void Start()
	{
		this.Checklist.alpha = (float)0;
	}

	public virtual void Update()
	{
		if (!this.StopChecking)
		{
			if (this.MyCollider.bounds.Contains(this.Yandere.transform.position))
			{
				if (PlayerPrefs.GetInt("KidnapVictim") > 0)
				{
					this.KidnappingLabel.text = "There is no room for another prisoner in your basement.";
				}
				else
				{
					if (!this.Yandere.Inventory.Tranquilizer)
					{
						this.TranquilizerIcon.spriteName = "No";
					}
					else
					{
						this.TranquilizerIcon.spriteName = "Yes";
					}
					if (this.Yandere.Followers != 1)
					{
						this.FollowerIcon.spriteName = "No";
					}
					else if (this.Yandere.Follower.Male)
					{
						this.KidnappingLabel.text = "You cannot kidnap male students at this point in time.";
						this.FollowerIcon.spriteName = "No";
					}
					else
					{
						this.KidnappingLabel.text = "Kidnapping Checklist";
						this.FollowerIcon.spriteName = "Yes";
					}
					if (PlayerPrefs.GetInt("BiologyGrade") + PlayerPrefs.GetInt("BiologyBonus") == 0)
					{
						this.BiologyIcon.spriteName = "No";
					}
					else
					{
						this.BiologyIcon.spriteName = "Yes";
					}
					if (!this.Yandere.Armed)
					{
						this.SyringeIcon.spriteName = "No";
					}
					else if (this.Yandere.Weapon[this.Yandere.Equipped].WeaponID != 3)
					{
						this.SyringeIcon.spriteName = "No";
					}
					else
					{
						this.SyringeIcon.spriteName = "Yes";
					}
					if (this.Door.Open)
					{
						this.DoorIcon.spriteName = "No";
					}
					else
					{
						this.DoorIcon.spriteName = "Yes";
					}
				}
				this.Checklist.alpha = Mathf.MoveTowards(this.Checklist.alpha, (float)1, Time.deltaTime);
			}
			else
			{
				this.Checklist.alpha = Mathf.MoveTowards(this.Checklist.alpha, (float)0, Time.deltaTime);
			}
		}
		else
		{
			this.Checklist.alpha = Mathf.MoveTowards(this.Checklist.alpha, (float)0, Time.deltaTime);
			if (this.Checklist.alpha == (float)0)
			{
				this.enabled = false;
			}
		}
	}

	public virtual void TranqCheck()
	{
		if (!this.StopChecking && this.KidnappingLabel.text == "Kidnapping Checklist" && this.TranquilizerIcon.spriteName == "Yes" && this.FollowerIcon.spriteName == "Yes" && this.BiologyIcon.spriteName == "Yes" && this.SyringeIcon.spriteName == "Yes" && this.DoorIcon.spriteName == "Yes")
		{
			this.Door.Prompt.Hide();
			this.Door.Prompt.enabled = false;
			this.Door.enabled = false;
			this.Yandere.Inventory.Tranquilizer = false;
			this.Yandere.CanTranq = true;
			this.StopChecking = true;
		}
	}

	public virtual void Main()
	{
	}
}
