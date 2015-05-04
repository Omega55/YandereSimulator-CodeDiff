using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class WeaponScript : MonoBehaviour
{
	public IncineratorScript Incinerator;

	public OutlineScript[] Outline;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Collider MyCollider;

	public Color EvidenceColor;

	public Color OriginalColor;

	public string SpriteName;

	public string Name;

	public bool Concealable;

	public bool Suspicious;

	public bool Evidence;

	public bool Dumped;

	public float DumpTimer;

	public int WeaponID;

	private int ID;

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		Physics.IgnoreCollision(this.Yandere.collider, this.MyCollider);
		this.OriginalColor = this.Outline[0].color;
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
			if (this.Yandere.Equipped == 3)
			{
				this.Yandere.Weapon[3].Drop();
			}
			if (this.Yandere.PickUp != null)
			{
				this.Yandere.PickUp.Drop();
			}
			if (this.Yandere.Dragging)
			{
				((RagdollScript)this.Yandere.Ragdoll.GetComponent(typeof(RagdollScript))).StopDragging();
			}
			if (this.Concealable)
			{
				if (this.Yandere.Weapon[1] == null)
				{
					if (this.Yandere.Weapon[2] != null)
					{
						this.Yandere.Weapon[2].active = false;
					}
					this.Yandere.Weapon[1] = this;
					this.Yandere.Equipped = 1;
				}
				else if (this.Yandere.Weapon[2] == null)
				{
					if (this.Yandere.Weapon[1] != null)
					{
						this.Yandere.Weapon[1].active = false;
					}
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
			}
			else
			{
				if (this.Yandere.Weapon[1] != null)
				{
					this.Yandere.Weapon[1].active = false;
				}
				if (this.Yandere.Weapon[2] != null)
				{
					this.Yandere.Weapon[2].active = false;
				}
				this.Yandere.Weapon[3] = this;
				this.Yandere.Equipped = 3;
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
			if (this.Evidence)
			{
				this.Yandere.Police.BloodyWeapons = this.Yandere.Police.BloodyWeapons - 1;
			}
		}
		if (this.Yandere.Weapon[this.Yandere.Equipped] == this && this.Yandere.Armed)
		{
			this.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
			this.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		}
		if (this.Dumped)
		{
			this.DumpTimer += Time.deltaTime;
			if (this.DumpTimer > (float)1)
			{
				this.Yandere.Incinerator.MurderWeapons = this.Yandere.Incinerator.MurderWeapons + 1;
				UnityEngine.Object.Destroy(this.gameObject);
			}
		}
	}

	public virtual void Drop()
	{
		this.Yandere.Weapon[this.Yandere.Equipped] = null;
		this.Yandere.Armed = false;
		this.Yandere.Equipped = 0;
		this.Yandere.StudentManager.UpdateStudents();
		if (this.Yandere.Weapon[3] == this)
		{
			this.Yandere.Weapon[3] = null;
		}
		this.active = true;
		this.transform.parent = null;
		this.rigidbody.constraints = RigidbodyConstraints.None;
		if (this.Dumped)
		{
			this.transform.position = this.Incinerator.DumpPoint.position;
		}
		else
		{
			this.Prompt.enabled = true;
			this.MyCollider.enabled = true;
			Physics.IgnoreCollision(this.Yandere.collider, this.MyCollider);
		}
		if (this.Evidence)
		{
			this.Yandere.Police.BloodyWeapons = this.Yandere.Police.BloodyWeapons + 1;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Outline))
		{
			if (!this.Evidence)
			{
				this.Outline[this.ID].color = this.OriginalColor;
			}
			else
			{
				this.Outline[this.ID].color = this.EvidenceColor;
			}
			this.ID++;
		}
	}

	public virtual void UpdateLabel()
	{
		if (this.Yandere.Weapon[1] != null && this.Yandere.Weapon[2] != null && this.Concealable)
		{
			if (this.Prompt.Label[3] != null)
			{
				if (!this.Yandere.Armed || this.Yandere.Equipped == 3)
				{
					this.Prompt.Label[3].text = "     " + "Swap " + this.Yandere.Weapon[1].Name + " for " + this.Name;
				}
				else
				{
					this.Prompt.Label[3].text = "     " + "Swap " + this.Yandere.Weapon[this.Yandere.Equipped].Name + " for " + this.Name;
				}
			}
		}
		else if (this.Prompt.Label[3] != null)
		{
			this.Prompt.Label[3].text = "     " + this.Name;
		}
	}

	public virtual void Main()
	{
	}
}
