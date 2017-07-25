using System;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
	public RigidbodyConstraints OriginalConstraints;

	public BloodCleanerScript BloodCleaner;

	public IncineratorScript Incinerator;

	public OutlineScript[] Outline;

	public YandereScript Yandere;

	public BucketScript Bucket;

	public PromptScript Prompt;

	public Rigidbody MyRigidbody;

	public Collider MyCollider;

	public Vector3 TrashPosition;

	public Vector3 TrashRotation;

	public Vector3 OriginalScale;

	public Vector3 HoldPosition;

	public Vector3 HoldRotation;

	public Color EvidenceColor;

	public Color OriginalColor;

	public bool LockRotation;

	public bool BeingLifted;

	public bool CanCollide;

	public bool Suspicious;

	public bool Blowtorch;

	public bool BodyPart;

	public bool Clothing;

	public bool Evidence;

	public bool JerryCan;

	public bool LeftHand;

	public bool Garbage;

	public bool Dumped;

	public bool Usable;

	public bool Weight;

	public int CarryAnimID;

	public int Food;

	public float KinematicTimer;

	public float DumpTimer;

	public bool Empty = true;

	public GameObject[] FoodPieces;

	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
		if (!this.CanCollide)
		{
			Physics.IgnoreCollision(this.Yandere.GetComponent<Collider>(), this.MyCollider);
		}
		this.OriginalColor = this.Outline[0].color;
		this.OriginalScale = base.transform.localScale;
		this.MyRigidbody = base.GetComponent<Rigidbody>();
	}

	private void LateUpdate()
	{
		if (this.Prompt.Circle[3].fillAmount <= 0f)
		{
			if (this.Weight)
			{
				if (this.Yandere.PickUp != null)
				{
					this.Yandere.CharacterAnimation[this.Yandere.CarryAnims[this.Yandere.PickUp.CarryAnimID]].weight = 0f;
				}
				if (this.Yandere.Armed)
				{
					this.Yandere.CharacterAnimation[this.Yandere.ArmedAnims[this.Yandere.Weapon[this.Yandere.Equipped].AnimID]].weight = 0f;
				}
				this.Yandere.EmptyHands();
				base.transform.parent = this.Yandere.transform;
				base.transform.localPosition = new Vector3(0f, 0f, 0.75f);
				base.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
				base.transform.parent = null;
				this.Yandere.Character.GetComponent<Animation>().Play("f02_heavyWeightLift_00");
				this.Yandere.HeavyWeight = true;
				this.Yandere.CanMove = false;
				this.Yandere.Lifting = true;
				this.BeingLifted = true;
			}
			else
			{
				this.BePickedUp();
			}
		}
		if (this.Yandere.PickUp == this)
		{
			base.transform.localPosition = this.HoldPosition;
			base.transform.localEulerAngles = this.HoldRotation;
		}
		if (this.Dumped)
		{
			this.DumpTimer += Time.deltaTime;
			if (this.DumpTimer > 1f)
			{
				if (this.Clothing)
				{
					this.Yandere.Incinerator.BloodyClothing++;
				}
				else if (this.BodyPart)
				{
					this.Yandere.Incinerator.BodyParts++;
				}
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
		if (this.MyRigidbody != null && !this.MyRigidbody.isKinematic)
		{
			this.KinematicTimer = Mathf.MoveTowards(this.KinematicTimer, 5f, Time.deltaTime);
			if (this.KinematicTimer == 5f)
			{
				this.MyRigidbody.isKinematic = true;
				this.KinematicTimer = 0f;
			}
		}
		if (this.Weight && this.BeingLifted)
		{
			if (this.Yandere.Lifting)
			{
				if (this.Yandere.CharacterAnimation["f02_heavyWeightLift_00"].time >= 2f)
				{
					base.transform.parent = this.Yandere.LeftItemParent;
					base.transform.localPosition = this.HoldPosition;
					base.transform.localEulerAngles = this.HoldRotation;
				}
			}
			else
			{
				this.BePickedUp();
				this.BeingLifted = false;
			}
		}
	}

	private void BePickedUp()
	{
		this.Prompt.Circle[3].fillAmount = 1f;
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
			this.Yandere.Ragdoll.GetComponent<RagdollScript>().StopDragging();
		}
		if (this.Yandere.Carrying)
		{
			this.Yandere.StopCarrying();
		}
		if (!this.LeftHand)
		{
			base.transform.parent = this.Yandere.ItemParent;
		}
		else
		{
			base.transform.parent = this.Yandere.LeftItemParent;
		}
		if (base.GetComponent<RadioScript>() != null)
		{
			base.GetComponent<RadioScript>().TurnOff();
		}
		base.transform.localPosition = new Vector3(0f, 0f, 0f);
		base.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		this.MyCollider.enabled = false;
		if (this.MyRigidbody != null)
		{
			this.MyRigidbody.constraints = RigidbodyConstraints.FreezeAll;
		}
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
		foreach (OutlineScript outlineScript in this.Outline)
		{
			outlineScript.color = new Color(0f, 0f, 0f, 1f);
		}
		if (this.BodyPart)
		{
			this.Yandere.NearBodies++;
		}
		this.Yandere.StudentManager.UpdateStudents();
		this.KinematicTimer = 0f;
	}

	public void Drop()
	{
		if (this.Weight)
		{
			this.Yandere.IdleAnim = this.Yandere.OriginalIdleAnim;
			this.Yandere.WalkAnim = this.Yandere.OriginalWalkAnim;
			this.Yandere.RunAnim = this.Yandere.OriginalRunAnim;
		}
		if (this.BloodCleaner != null)
		{
			this.BloodCleaner.enabled = true;
			this.BloodCleaner.Pathfinding.enabled = true;
		}
		this.Yandere.PickUp = null;
		base.transform.parent = null;
		if (this.LockRotation)
		{
			base.transform.localEulerAngles = new Vector3(0f, base.transform.localEulerAngles.y, 0f);
		}
		if (this.MyRigidbody != null)
		{
			this.MyRigidbody.constraints = this.OriginalConstraints;
			this.MyRigidbody.isKinematic = false;
			this.MyRigidbody.useGravity = true;
		}
		if (this.Dumped)
		{
			base.transform.position = this.Incinerator.DumpPoint.position;
		}
		else
		{
			this.Prompt.enabled = true;
			this.MyCollider.enabled = true;
			this.MyCollider.isTrigger = false;
			if (!this.CanCollide)
			{
				Physics.IgnoreCollision(this.Yandere.GetComponent<Collider>(), this.MyCollider);
			}
		}
		this.Prompt.Carried = false;
		foreach (OutlineScript outlineScript in this.Outline)
		{
			outlineScript.color = ((!this.Evidence) ? this.OriginalColor : this.EvidenceColor);
		}
		base.transform.localScale = this.OriginalScale;
		if (this.BodyPart)
		{
			this.Yandere.NearBodies--;
		}
		this.Yandere.StudentManager.UpdateStudents();
	}
}
