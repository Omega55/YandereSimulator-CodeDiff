using System;
using UnityEngine;

public class ContainerScript : MonoBehaviour
{
	public Transform[] BodyPartPositions;

	public Transform WeaponSpot;

	public Transform Lid;

	public PickUpScript[] BodyParts;

	public PickUpScript BodyPart;

	public WeaponScript Weapon;

	public PromptScript Prompt;

	public string SpriteName = string.Empty;

	public bool Open;

	public int Contents;

	public int ID;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.Open = !this.Open;
			this.UpdatePrompts();
		}
		if (this.Prompt.Circle[1].fillAmount == 0f)
		{
			this.Prompt.Circle[1].fillAmount = 1f;
			if (this.Prompt.Yandere.Armed)
			{
				this.Weapon = this.Prompt.Yandere.EquippedWeapon.gameObject.GetComponent<WeaponScript>();
				this.Prompt.Yandere.EmptyHands();
				this.Weapon.transform.parent = this.WeaponSpot;
				this.Weapon.transform.localPosition = Vector3.zero;
				this.Weapon.transform.localEulerAngles = Vector3.zero;
				this.Weapon.gameObject.GetComponent<Rigidbody>().useGravity = false;
				this.Weapon.MyCollider.enabled = false;
				this.Weapon.Prompt.Hide();
				this.Weapon.Prompt.enabled = false;
			}
			else
			{
				this.BodyPart = this.Prompt.Yandere.PickUp;
				this.Prompt.Yandere.EmptyHands();
				this.BodyPart.transform.parent = this.BodyPartPositions[this.BodyPart.GetComponent<BodyPartScript>().Type];
				this.BodyPart.transform.localPosition = Vector3.zero;
				this.BodyPart.transform.localEulerAngles = Vector3.zero;
				this.BodyPart.gameObject.GetComponent<Rigidbody>().useGravity = false;
				this.BodyPart.MyCollider.enabled = false;
				this.BodyParts[this.BodyPart.GetComponent<BodyPartScript>().Type] = this.BodyPart;
			}
			this.Contents++;
			this.UpdatePrompts();
		}
		if (this.Prompt.Circle[3].fillAmount == 0f)
		{
			this.Prompt.Circle[3].fillAmount = 1f;
			if (!this.Open)
			{
				base.transform.parent = this.Prompt.Yandere.Backpack;
				base.transform.localPosition = Vector3.zero;
				base.transform.localEulerAngles = Vector3.zero;
				this.Prompt.Yandere.Container = this;
				this.Prompt.Yandere.WeaponMenu.UpdateSprites();
				this.Prompt.Yandere.ObstacleDetector.gameObject.SetActive(true);
				this.Prompt.MyCollider.enabled = false;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				Rigidbody component = base.GetComponent<Rigidbody>();
				component.isKinematic = true;
				component.useGravity = false;
			}
			else
			{
				if (this.Weapon != null)
				{
					this.Weapon.Prompt.Circle[3].fillAmount = -1f;
					this.Weapon.Prompt.enabled = true;
					this.Weapon = null;
				}
				else
				{
					this.BodyPart = null;
					this.ID = 1;
					while (this.BodyPart == null)
					{
						this.BodyPart = this.BodyParts[this.ID];
						this.BodyParts[this.ID] = null;
						this.ID++;
					}
					this.BodyPart.Prompt.Circle[3].fillAmount = -1f;
				}
				this.Contents--;
				this.UpdatePrompts();
			}
		}
		this.Lid.localEulerAngles = new Vector3(this.Lid.localEulerAngles.x, this.Lid.localEulerAngles.y, Mathf.Lerp(this.Lid.localEulerAngles.z, (!this.Open) ? 0f : 90f, Time.deltaTime * 10f));
		if (this.Weapon != null)
		{
			this.Weapon.transform.localPosition = Vector3.zero;
			this.Weapon.transform.localEulerAngles = Vector3.zero;
		}
		this.ID = 1;
		while (this.ID < this.BodyParts.Length)
		{
			if (this.BodyParts[this.ID] != null)
			{
				this.BodyParts[this.ID].transform.localPosition = Vector3.zero;
				this.BodyParts[this.ID].transform.localEulerAngles = Vector3.zero;
			}
			this.ID++;
		}
	}

	public void Drop()
	{
		base.transform.parent = null;
		base.transform.position = this.Prompt.Yandere.ObstacleDetector.transform.position;
		base.transform.eulerAngles = this.Prompt.Yandere.ObstacleDetector.transform.eulerAngles;
		this.Prompt.Yandere.Container = null;
		this.Prompt.MyCollider.enabled = true;
		this.Prompt.enabled = true;
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.isKinematic = false;
		component.useGravity = true;
	}

	public void UpdatePrompts()
	{
		if (this.Open)
		{
			this.Prompt.Label[0].text = "     Close";
			if (this.Contents > 0)
			{
				this.Prompt.Label[3].text = "     Remove";
				this.Prompt.HideButton[3] = false;
			}
			else
			{
				this.Prompt.HideButton[3] = true;
			}
			if (this.Prompt.Yandere.Armed)
			{
				if (!this.Prompt.Yandere.EquippedWeapon.Concealable)
				{
					if (this.Weapon == null)
					{
						this.Prompt.Label[1].text = "     Insert";
						this.Prompt.HideButton[1] = false;
					}
					else
					{
						this.Prompt.HideButton[1] = true;
					}
				}
				else
				{
					this.Prompt.HideButton[1] = true;
				}
			}
			else if (this.Prompt.Yandere.PickUp != null)
			{
				if (this.Prompt.Yandere.PickUp.BodyPart != null)
				{
					if (this.BodyParts[this.Prompt.Yandere.PickUp.gameObject.GetComponent<BodyPartScript>().Type] == null)
					{
						this.Prompt.Label[1].text = "     Insert";
						this.Prompt.HideButton[1] = false;
					}
					else
					{
						this.Prompt.HideButton[1] = true;
					}
				}
				else
				{
					this.Prompt.HideButton[1] = true;
				}
			}
			else
			{
				this.Prompt.HideButton[1] = true;
			}
		}
		else if (this.Prompt.Label[0] != null)
		{
			this.Prompt.Label[0].text = "     Open";
			this.Prompt.HideButton[1] = true;
			this.Prompt.Label[3].text = "     Wear";
			this.Prompt.HideButton[3] = false;
		}
	}
}
