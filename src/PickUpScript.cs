using System;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
	public RigidbodyConstraints OriginalConstraints;

	public BloodCleanerScript BloodCleaner;

	public IncineratorScript Incinerator;

	public BodyPartScript BodyPart;

	public TrashCanScript TrashCan;

	public OutlineScript[] Outline;

	public YandereScript Yandere;

	public Animation MyAnimation;

	public BucketScript Bucket;

	public PromptScript Prompt;

	public ClockScript Clock;

	public MopScript Mop;

	public Mesh ClosedBook;

	public Mesh OpenBook;

	public Rigidbody MyRigidbody;

	public Collider MyCollider;

	public MeshFilter MyRenderer;

	public Vector3 TrashPosition;

	public Vector3 TrashRotation;

	public Vector3 OriginalScale;

	public Vector3 HoldPosition;

	public Vector3 HoldRotation;

	public Color EvidenceColor;

	public Color OriginalColor;

	public bool CleaningProduct;

	public bool DisableAtStart;

	public bool LockRotation;

	public bool BeingLifted;

	public bool CanCollide;

	public bool Electronic;

	public bool Flashlight;

	public bool PuzzleCube;

	public bool Suspicious;

	public bool Blowtorch;

	public bool Clothing;

	public bool Evidence;

	public bool JerryCan;

	public bool LeftHand;

	public bool RedPaint;

	public bool Garbage;

	public bool Bleach;

	public bool Dumped;

	public bool Usable;

	public bool Weight;

	public bool Radio;

	public bool Salty;

	public int CarryAnimID;

	public int Strength;

	public int Period;

	public int Food;

	public float KinematicTimer;

	public float DumpTimer;

	public bool Empty = true;

	public GameObject[] FoodPieces;

	public WeaponScript StuckBoxCutter;

	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
		this.Clock = GameObject.Find("Clock").GetComponent<ClockScript>();
		if (!this.CanCollide)
		{
			Physics.IgnoreCollision(this.Yandere.GetComponent<Collider>(), this.MyCollider);
		}
		if (this.Outline.Length != 0)
		{
			this.OriginalColor = this.Outline[0].color;
		}
		this.OriginalScale = base.transform.localScale;
		if (this.MyRigidbody == null)
		{
			this.MyRigidbody = base.GetComponent<Rigidbody>();
		}
		if (this.DisableAtStart)
		{
			base.gameObject.SetActive(false);
		}
	}

	private void LateUpdate()
	{
		if (this.CleaningProduct)
		{
			if (this.Clock.Period == 5)
			{
				this.Suspicious = false;
			}
			else
			{
				this.Suspicious = true;
			}
		}
		if (this.Weight)
		{
			if (this.Period < this.Clock.Period)
			{
				this.Strength = ClassGlobals.PhysicalGrade + ClassGlobals.PhysicalBonus;
				this.Period++;
			}
			if (this.Strength == 0)
			{
				this.Prompt.Label[3].text = "     Physical Stat Too Low";
				this.Prompt.Circle[3].fillAmount = 1f;
			}
			else
			{
				this.Prompt.Label[3].text = "     Carry";
			}
		}
		if (this.Prompt.Circle[3].fillAmount == 0f)
		{
			this.Prompt.Circle[3].fillAmount = 1f;
			if (this.Weight)
			{
				if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
				{
					if (this.Yandere.PickUp != null)
					{
						this.Yandere.CharacterAnimation[this.Yandere.CarryAnims[this.Yandere.PickUp.CarryAnimID]].weight = 0f;
					}
					if (this.Yandere.Armed)
					{
						this.Yandere.CharacterAnimation[this.Yandere.ArmedAnims[this.Yandere.EquippedWeapon.AnimID]].weight = 0f;
					}
					this.Yandere.targetRotation = Quaternion.LookRotation(new Vector3(base.transform.position.x, this.Yandere.transform.position.y, base.transform.position.z) - this.Yandere.transform.position);
					this.Yandere.transform.rotation = this.Yandere.targetRotation;
					this.Yandere.EmptyHands();
					base.transform.parent = this.Yandere.transform;
					base.transform.localPosition = new Vector3(0f, 0f, 0.79184f);
					base.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					this.Yandere.Character.GetComponent<Animation>().Play("f02_heavyWeightLift_00");
					this.Yandere.HeavyWeight = true;
					this.Yandere.CanMove = false;
					this.Yandere.Lifting = true;
					this.MyAnimation.Play("Weight_liftUp_00");
					this.MyRigidbody.isKinematic = true;
					this.BeingLifted = true;
				}
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
			if (this.Garbage && !this.Yandere.StudentManager.IncineratorArea.bounds.Contains(this.Yandere.transform.position))
			{
				this.Drop();
				base.transform.position = new Vector3(-40f, 0f, 24f);
			}
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
				Object.Destroy(base.gameObject);
			}
		}
		if (this.Yandere.PickUp != this && !this.MyRigidbody.isKinematic)
		{
			this.KinematicTimer = Mathf.MoveTowards(this.KinematicTimer, 5f, Time.deltaTime);
			if (this.KinematicTimer == 5f)
			{
				this.MyRigidbody.isKinematic = true;
				this.KinematicTimer = 0f;
			}
			if (base.transform.position.x > -71f && base.transform.position.x < -61f && base.transform.position.z > -37.5f && base.transform.position.z < -27.5f)
			{
				base.transform.position = new Vector3(-63f, 1f, -26.5f);
				this.KinematicTimer = 0f;
			}
			if (base.transform.position.x > -46f && base.transform.position.x < -18f && base.transform.position.z > 66f && base.transform.position.z < 78f)
			{
				base.transform.position = new Vector3(-16f, 5f, 72f);
				this.KinematicTimer = 0f;
			}
		}
		if (this.Weight && this.BeingLifted)
		{
			if (this.Yandere.Lifting)
			{
				if (this.Yandere.StudentManager.Stop)
				{
					this.Drop();
					return;
				}
			}
			else
			{
				this.BePickedUp();
			}
		}
	}

	public void BePickedUp()
	{
		if (this.Radio && SchemeGlobals.GetSchemeStage(5) == 2)
		{
			SchemeGlobals.SetSchemeStage(5, 3);
			this.Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		if (this.Salty && SchemeGlobals.GetSchemeStage(4) == 4)
		{
			SchemeGlobals.SetSchemeStage(4, 5);
			this.Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		if (this.CarryAnimID == 10)
		{
			this.MyRenderer.mesh = this.OpenBook;
			this.Yandere.LifeNotePen.SetActive(true);
		}
		if (this.MyAnimation != null)
		{
			this.MyAnimation.Stop();
		}
		this.Prompt.Circle[3].fillAmount = 1f;
		this.BeingLifted = false;
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
		if (base.GetComponent<RadioScript>() != null && base.GetComponent<RadioScript>().On)
		{
			base.GetComponent<RadioScript>().TurnOff();
		}
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
		OutlineScript[] outline = this.Outline;
		for (int i = 0; i < outline.Length; i++)
		{
			outline[i].color = new Color(0f, 0f, 0f, 1f);
		}
		if (this.BodyPart)
		{
			this.Yandere.NearBodies++;
		}
		this.Yandere.StudentManager.UpdateStudents(0);
		this.MyRigidbody.isKinematic = true;
		this.KinematicTimer = 0f;
	}

	public void Drop()
	{
		if (this.Salty && SchemeGlobals.GetSchemeStage(4) == 5)
		{
			SchemeGlobals.SetSchemeStage(4, 4);
			this.Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		if (this.TrashCan)
		{
			this.Yandere.MyController.radius = 0.2f;
		}
		if (this.CarryAnimID == 10)
		{
			this.MyRenderer.mesh = this.ClosedBook;
			this.Yandere.LifeNotePen.SetActive(false);
		}
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
		if (this.BodyPart)
		{
			base.transform.parent = this.Yandere.LimbParent;
		}
		else
		{
			base.transform.parent = null;
		}
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
		OutlineScript[] outline = this.Outline;
		for (int i = 0; i < outline.Length; i++)
		{
			outline[i].color = (this.Evidence ? this.EvidenceColor : this.OriginalColor);
		}
		base.transform.localScale = this.OriginalScale;
		if (this.BodyPart)
		{
			this.Yandere.NearBodies--;
		}
		this.Yandere.StudentManager.UpdateStudents(0);
		if (this.Clothing && this.Evidence)
		{
			base.transform.parent = this.Yandere.Police.BloodParent;
		}
	}
}
