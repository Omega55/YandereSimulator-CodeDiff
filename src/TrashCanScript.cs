using System;
using UnityEngine;

[Serializable]
public class TrashCanScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public Transform TrashPosition;

	public GameObject Item;

	public bool Occupied;

	public bool Weapon;

	public virtual void Update()
	{
		if (!this.Occupied)
		{
			if (this.Prompt.Circle[0].fillAmount <= (float)0)
			{
				this.Prompt.Circle[0].fillAmount = (float)1;
				if (this.Yandere.PickUp != null)
				{
					this.Item = this.Yandere.PickUp.gameObject;
					this.Yandere.EmptyHands();
				}
				else
				{
					this.Item = this.Yandere.Weapon[this.Yandere.Equipped].gameObject;
					this.Yandere.DropTimer[this.Yandere.Equipped] = 0.5f;
					this.Yandere.DropWeapon(this.Yandere.Equipped);
					this.Weapon = true;
				}
				this.Item.transform.parent = this.TrashPosition;
				this.Item.rigidbody.useGravity = false;
				((Collider)this.Item.GetComponent(typeof(Collider))).enabled = false;
				((PromptScript)this.Item.GetComponent(typeof(PromptScript))).Hide();
				((PromptScript)this.Item.GetComponent(typeof(PromptScript))).enabled = false;
				this.Occupied = true;
				this.UpdatePrompt();
			}
		}
		else if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			((PromptScript)this.Item.GetComponent(typeof(PromptScript))).Circle[3].fillAmount = (float)-1;
			((PromptScript)this.Item.GetComponent(typeof(PromptScript))).enabled = true;
			this.Item = null;
			this.Occupied = false;
			this.Weapon = false;
			this.UpdatePrompt();
		}
		if (this.Item != null)
		{
			if (this.Weapon)
			{
				this.Item.transform.localPosition = new Vector3((float)0, 0.29f, (float)0);
				this.Item.transform.localEulerAngles = new Vector3((float)90, (float)0, (float)0);
			}
			else
			{
				this.Item.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
				this.Item.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
			}
		}
	}

	public virtual void UpdatePrompt()
	{
		if (!this.Occupied)
		{
			if (this.Yandere.Armed)
			{
				this.Prompt.Label[0].text = "     " + "Insert";
				this.Prompt.HideButton[0] = false;
			}
			else if (this.Yandere.PickUp != null)
			{
				if (this.Yandere.PickUp.Evidence || this.Yandere.PickUp.Suspicious)
				{
					this.Prompt.Label[0].text = "     " + "Insert";
					this.Prompt.HideButton[0] = false;
				}
				else
				{
					this.Prompt.HideButton[0] = true;
				}
			}
			else
			{
				this.Prompt.HideButton[0] = true;
			}
		}
		else
		{
			this.Prompt.Label[0].text = "     " + "Remove";
			this.Prompt.HideButton[0] = false;
		}
	}

	public virtual void Main()
	{
	}
}
