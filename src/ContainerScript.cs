using System;
using UnityEngine;

[Serializable]
public class ContainerScript : MonoBehaviour
{
	public Transform[] BodyPartPositions;

	public Transform WeaponSpot;

	public Transform Lid;

	public PickUpScript[] BodyParts;

	public PickUpScript BodyPart;

	public WeaponScript Weapon;

	public PromptScript Prompt;

	public string SpriteName;

	public bool Open;

	public int Contents;

	public int ID;

	public ContainerScript()
	{
		this.SpriteName = string.Empty;
	}

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			if (!this.Open)
			{
				this.Open = true;
			}
			else
			{
				this.Open = false;
			}
			this.UpdatePrompts();
		}
		if (this.Prompt.Circle[1].fillAmount <= (float)0)
		{
			this.Prompt.Circle[1].fillAmount = (float)1;
			if (this.Prompt.Yandere.Armed)
			{
				this.Weapon = (WeaponScript)this.Prompt.Yandere.Weapon[this.Prompt.Yandere.Equipped].gameObject.GetComponent(typeof(WeaponScript));
				this.Prompt.Yandere.EmptyHands();
				this.Weapon.transform.parent = this.WeaponSpot;
				this.Weapon.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
				this.Weapon.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
				this.Weapon.gameObject.rigidbody.useGravity = false;
				this.Weapon.MyCollider.enabled = false;
				this.Weapon.Prompt.Hide();
				this.Weapon.Prompt.enabled = false;
			}
			else
			{
				this.BodyPart = this.Prompt.Yandere.PickUp;
				this.Prompt.Yandere.EmptyHands();
				this.BodyPart.transform.parent = this.BodyPartPositions[((BodyPartScript)this.BodyPart.GetComponent(typeof(BodyPartScript))).Type];
				this.BodyPart.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
				this.BodyPart.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
				this.BodyPart.gameObject.rigidbody.useGravity = false;
				this.BodyPart.MyCollider.enabled = false;
				this.BodyParts[((BodyPartScript)this.BodyPart.GetComponent(typeof(BodyPartScript))).Type] = this.BodyPart;
			}
			this.Contents++;
			this.UpdatePrompts();
		}
		if (this.Prompt.Circle[3].fillAmount <= (float)0)
		{
			this.Prompt.Circle[3].fillAmount = (float)1;
			if (!this.Open)
			{
				this.transform.parent = this.Prompt.Yandere.Backpack;
				this.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
				this.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
				this.Prompt.Yandere.Container = this;
				this.Prompt.Yandere.WeaponMenu.UpdateSprites();
				this.Prompt.Yandere.ObstacleDetector.UpdateX();
				this.Prompt.Yandere.ObstacleDetector.gameObject.active = true;
				this.Prompt.MyCollider.enabled = false;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.rigidbody.isKinematic = true;
				this.rigidbody.useGravity = false;
			}
			else
			{
				if (this.Weapon != null)
				{
					this.Weapon.Prompt.Circle[3].fillAmount = (float)-1;
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
					this.BodyPart.Prompt.Circle[3].fillAmount = (float)-1;
				}
				this.Contents--;
				this.UpdatePrompts();
			}
		}
		if (this.Open)
		{
			float z = Mathf.Lerp(this.Lid.localEulerAngles.z, (float)90, Time.deltaTime * (float)10);
			Vector3 localEulerAngles = this.Lid.localEulerAngles;
			float num = localEulerAngles.z = z;
			Vector3 vector = this.Lid.localEulerAngles = localEulerAngles;
		}
		else
		{
			float z2 = Mathf.Lerp(this.Lid.localEulerAngles.z, (float)0, Time.deltaTime * (float)10);
			Vector3 localEulerAngles2 = this.Lid.localEulerAngles;
			float num2 = localEulerAngles2.z = z2;
			Vector3 vector2 = this.Lid.localEulerAngles = localEulerAngles2;
		}
		if (this.Weapon != null)
		{
			this.Weapon.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
			this.Weapon.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		}
		this.ID = 1;
		while (this.ID < this.BodyParts.Length)
		{
			if (this.BodyParts[this.ID] != null)
			{
				this.BodyParts[this.ID].transform.localPosition = new Vector3((float)0, (float)0, (float)0);
				this.BodyParts[this.ID].transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
			}
			this.ID++;
		}
	}

	public virtual void Drop()
	{
		this.transform.parent = null;
		this.transform.position = this.Prompt.Yandere.ObstacleDetector.transform.position;
		this.transform.eulerAngles = this.Prompt.Yandere.ObstacleDetector.transform.eulerAngles;
		this.Prompt.Yandere.Container = null;
		this.Prompt.MyCollider.enabled = true;
		this.Prompt.enabled = true;
		this.rigidbody.isKinematic = false;
		this.rigidbody.useGravity = true;
	}

	public virtual void UpdatePrompts()
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
				if (!this.Prompt.Yandere.Weapon[this.Prompt.Yandere.Equipped].Concealable)
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
				if (this.Prompt.Yandere.PickUp.BodyPart)
				{
					if (this.BodyParts[((BodyPartScript)this.Prompt.Yandere.PickUp.gameObject.GetComponent(typeof(BodyPartScript))).Type] == null)
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

	public virtual void Main()
	{
	}
}
