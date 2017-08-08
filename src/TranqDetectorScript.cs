using System;
using UnityEngine;

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

	public AudioClip[] TranqClips;

	private void Start()
	{
		this.Checklist.alpha = 0f;
	}

	private void Update()
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
					this.TranquilizerIcon.spriteName = ((!this.Yandere.Inventory.Tranquilizer) ? "No" : "Yes");
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
					this.BiologyIcon.spriteName = ((PlayerPrefs.GetInt("BiologyGrade") + PlayerPrefs.GetInt("BiologyBonus") == 0) ? "No" : "Yes");
					if (!this.Yandere.Armed)
					{
						this.SyringeIcon.spriteName = "No";
					}
					else if (this.Yandere.EquippedWeapon.WeaponID != 3)
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
				this.Checklist.alpha = Mathf.MoveTowards(this.Checklist.alpha, 1f, Time.deltaTime);
			}
			else
			{
				this.Checklist.alpha = Mathf.MoveTowards(this.Checklist.alpha, 0f, Time.deltaTime);
			}
		}
		else
		{
			this.Checklist.alpha = Mathf.MoveTowards(this.Checklist.alpha, 0f, Time.deltaTime);
			if (this.Checklist.alpha == 0f)
			{
				base.enabled = false;
			}
		}
	}

	public void TranqCheck()
	{
		if (!this.StopChecking && this.KidnappingLabel.text == "Kidnapping Checklist" && this.TranquilizerIcon.spriteName == "Yes" && this.FollowerIcon.spriteName == "Yes" && this.BiologyIcon.spriteName == "Yes" && this.SyringeIcon.spriteName == "Yes" && this.DoorIcon.spriteName == "Yes")
		{
			AudioSource component = base.GetComponent<AudioSource>();
			component.clip = this.TranqClips[UnityEngine.Random.Range(0, this.TranqClips.Length)];
			component.Play();
			this.Door.Prompt.Hide();
			this.Door.Prompt.enabled = false;
			this.Door.enabled = false;
			this.Yandere.Inventory.Tranquilizer = false;
			this.Yandere.CanTranq = true;
			this.Yandere.EquippedWeapon.Type = WeaponType.Syringe;
			this.Yandere.AttackManager.Stealth = true;
			this.StopChecking = true;
		}
	}
}
