using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class PickUpScript : MonoBehaviour
{
	public RigidbodyConstraints OriginalConstraints;

	public IncineratorScript Incinerator;

	public OutlineScript[] Outline;

	public YandereScript Yandere;

	public BucketScript Bucket;

	public PromptScript Prompt;

	public Collider MyCollider;

	public Vector3 HoldPosition;

	public Vector3 HoldRotation;

	public Color EvidenceColor;

	public Color OriginalColor;

	public bool LockRotation;

	public bool CanCollide;

	public bool Suspicious;

	public bool Evidence;

	public bool Dumped;

	public bool Usable;

	public int CarryAnimID;

	public float DumpTimer;

	public bool Empty;

	public PickUpScript()
	{
		this.Empty = true;
	}

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		if (!this.CanCollide)
		{
			Physics.IgnoreCollision(this.Yandere.collider, this.MyCollider);
		}
		this.OriginalConstraints = this.rigidbody.constraints;
		this.OriginalColor = this.Outline[0].color;
	}

	public virtual void LateUpdate()
	{
		if (this.Prompt.Circle[3].fillAmount <= (float)0)
		{
			if (this.Yandere.PickUp != null)
			{
				this.Yandere.PickUp.Drop();
			}
			if (this.Yandere.Equipped == 3)
			{
				this.Yandere.Weapon[3].Drop();
			}
			else if (this.Yandere.Equipped > 0)
			{
				this.Yandere.Unequip();
			}
			if (this.Yandere.Dragging)
			{
				((RagdollScript)this.Yandere.Ragdoll.GetComponent(typeof(RagdollScript))).StopDragging();
			}
			this.transform.parent = this.Yandere.ItemParent;
			this.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
			this.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
			this.MyCollider.enabled = false;
			this.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			if (!this.Usable)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.Yandere.NearestPrompt = null;
			}
			else
			{
				this.Prompt.Carried = true;
			}
			this.Yandere.PickUp = this;
			this.Yandere.CarryAnimID = this.CarryAnimID;
			for (int i = 0; i < Extensions.get_length(this.Outline); i++)
			{
				this.Outline[i].color = new Color((float)0, (float)0, (float)0, (float)1);
			}
			this.Yandere.StudentManager.UpdateStudents();
		}
		if (this.Yandere.PickUp == this)
		{
			this.transform.localPosition = this.HoldPosition;
			this.transform.localEulerAngles = this.HoldRotation;
		}
		if (this.Dumped)
		{
			this.DumpTimer += Time.deltaTime;
			if (this.DumpTimer > (float)1)
			{
				this.Yandere.Incinerator.BloodyUniforms = this.Yandere.Incinerator.BloodyUniforms + 1;
				UnityEngine.Object.Destroy(this.gameObject);
			}
		}
	}

	public virtual void Drop()
	{
		this.Yandere.PickUp = null;
		this.transform.parent = null;
		if (this.LockRotation)
		{
			int num = 0;
			Vector3 localEulerAngles = this.transform.localEulerAngles;
			float num2 = localEulerAngles.x = (float)num;
			Vector3 vector = this.transform.localEulerAngles = localEulerAngles;
			int num3 = 0;
			Vector3 localEulerAngles2 = this.transform.localEulerAngles;
			float num4 = localEulerAngles2.z = (float)num3;
			Vector3 vector2 = this.transform.localEulerAngles = localEulerAngles2;
		}
		this.rigidbody.constraints = this.OriginalConstraints;
		if (this.Dumped)
		{
			this.transform.position = this.Incinerator.DumpPoint.position;
		}
		else
		{
			this.Prompt.enabled = true;
			this.MyCollider.enabled = true;
			if (!this.CanCollide)
			{
				Physics.IgnoreCollision(this.Yandere.collider, this.MyCollider);
			}
		}
		this.Prompt.Carried = false;
		for (int i = 0; i < Extensions.get_length(this.Outline); i++)
		{
			if (!this.Evidence)
			{
				this.Outline[i].color = this.OriginalColor;
			}
			else
			{
				this.Outline[i].color = this.EvidenceColor;
			}
		}
		this.Yandere.StudentManager.UpdateStudents();
	}

	public virtual void Main()
	{
	}
}
