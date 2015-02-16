using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class WeaponScript : MonoBehaviour
{
	public OutlineScript[] Outline;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Collider MyCollider;

	public string SpriteName;

	public string Name;

	public bool Suspicious;

	private int ID;

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
	}

	public virtual void LateUpdate()
	{
		if (this.Prompt.Circle[3].fillAmount <= (float)0)
		{
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.Outline))
			{
				this.Outline[this.ID].color = new Color((float)0, (float)0, (float)0, (float)1);
				this.ID++;
			}
			this.transform.parent = this.Yandere.ItemParent;
			this.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
			this.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
			this.MyCollider.enabled = false;
			this.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			if (this.Yandere.Weapon[1] == null)
			{
				this.Yandere.Weapon[1] = this;
				this.Yandere.Equipped = 1;
			}
			else if (this.Yandere.Weapon[2] == null)
			{
				this.Yandere.Weapon[1].active = false;
				this.Yandere.Weapon[2] = this;
				this.Yandere.Equipped = 2;
			}
			else if (this.Yandere.Weapon[2].active)
			{
				this.Yandere.Weapon[2].Drop();
				this.Yandere.Weapon[2] = this;
				this.Yandere.Equipped = 2;
			}
			else
			{
				this.Yandere.Weapon[1].Drop();
				this.Yandere.Weapon[1] = this;
				this.Yandere.Equipped = 1;
			}
			this.Yandere.Armed = true;
			this.Yandere.StudentManager.UpdateStudents();
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Yandere.NearestPrompt = null;
			if (this.Yandere.Weapon[this.Yandere.Equipped].Suspicious)
			{
				if (!this.Yandere.WeaponWarning)
				{
					this.Yandere.NotificationManager.DisplayNotification("Armed");
					this.Yandere.WeaponWarning = true;
				}
			}
			else
			{
				this.Yandere.WeaponWarning = false;
			}
			this.Yandere.WeaponMenu.UpdateSprites();
			this.Yandere.WeaponManager.UpdateLabels();
		}
		if (this.Yandere.Weapon[this.Yandere.Equipped] == this && this.Yandere.Armed)
		{
			this.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
			this.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		}
	}

	public virtual void Drop()
	{
		this.active = true;
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Outline))
		{
			this.Outline[this.ID].color = new Color((float)0, (float)1, (float)1, (float)1);
			this.ID++;
		}
		this.transform.parent = null;
		this.MyCollider.enabled = true;
		this.rigidbody.constraints = RigidbodyConstraints.None;
		this.Prompt.enabled = true;
	}

	public virtual void UpdateLabel()
	{
		if (this.Yandere.Weapon[1] != null && this.Yandere.Weapon[2] != null)
		{
			if (!this.Yandere.Armed)
			{
				this.Prompt.Label[3].text = "     " + "Swap " + this.Yandere.Weapon[1].Name + " for " + this.Name;
			}
			else
			{
				this.Prompt.Label[3].text = "     " + "Swap " + this.Yandere.Weapon[this.Yandere.Equipped].Name + " for " + this.Name;
			}
		}
		else
		{
			this.Prompt.Label[3].text = "     " + this.Name;
		}
	}

	public virtual void Main()
	{
	}
}
