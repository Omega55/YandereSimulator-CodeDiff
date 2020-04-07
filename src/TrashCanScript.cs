using System;
using UnityEngine;

public class TrashCanScript : MonoBehaviour
{
	public ContainerScript Container;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Transform TrashPosition;

	public GameObject Item;

	public bool Occupied;

	public bool Wearable;

	public bool Weapon;

	private void Update()
	{
		if (!this.Occupied)
		{
			if (this.Prompt.HideButton[0])
			{
				if (this.Yandere.Armed)
				{
					this.UpdatePrompt();
				}
			}
			else if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				if (this.Yandere.PickUp != null)
				{
					this.Item = this.Yandere.PickUp.gameObject;
					this.Yandere.MyController.radius = 0.5f;
					this.Yandere.EmptyHands();
				}
				else
				{
					this.Item = this.Yandere.EquippedWeapon.gameObject;
					this.Yandere.DropTimer[this.Yandere.Equipped] = 0.5f;
					this.Yandere.DropWeapon(this.Yandere.Equipped);
					this.Weapon = true;
				}
				this.Item.transform.parent = this.TrashPosition;
				this.Item.GetComponent<Rigidbody>().useGravity = false;
				this.Item.GetComponent<Collider>().enabled = false;
				this.Item.GetComponent<PromptScript>().Hide();
				this.Item.GetComponent<PromptScript>().enabled = false;
				this.Occupied = true;
				this.UpdatePrompt();
			}
		}
		else if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.Item.GetComponent<PromptScript>().Circle[3].fillAmount = -1f;
			this.Item.GetComponent<PromptScript>().enabled = true;
			this.Item = null;
			this.Occupied = false;
			this.Weapon = false;
			this.UpdatePrompt();
		}
		if (this.Item != null)
		{
			if (this.Weapon)
			{
				this.Item.transform.localPosition = new Vector3(0f, 0.29f, 0f);
				this.Item.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
			}
			else
			{
				this.Item.transform.localPosition = new Vector3(0f, 0f, -0.021f);
				this.Item.transform.localEulerAngles = Vector3.zero;
			}
		}
		if (this.Wearable && this.Prompt.Circle[3].fillAmount == 0f)
		{
			this.Prompt.Circle[3].fillAmount = 1f;
			base.transform.parent = this.Prompt.Yandere.Backpack;
			base.transform.localPosition = Vector3.zero;
			base.transform.localEulerAngles = new Vector3(90f, -154f, 0f);
			this.Prompt.Yandere.Container = this.Container;
			this.Prompt.Yandere.WeaponMenu.UpdateSprites();
			this.Prompt.Yandere.ObstacleDetector.gameObject.SetActive(true);
			this.Prompt.MyCollider.enabled = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			Rigidbody component = base.GetComponent<Rigidbody>();
			component.isKinematic = true;
			component.useGravity = false;
		}
	}

	public void UpdatePrompt()
	{
		if (!this.Occupied)
		{
			if (this.Yandere.Armed)
			{
				this.Prompt.Label[0].text = "     Insert";
				this.Prompt.HideButton[0] = false;
			}
			else if (this.Yandere.PickUp != null)
			{
				if (this.Yandere.PickUp.Evidence || this.Yandere.PickUp.Suspicious)
				{
					this.Prompt.Label[0].text = "     Insert";
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
			this.Prompt.Label[0].text = "     Remove";
			this.Prompt.HideButton[0] = false;
		}
	}
}
