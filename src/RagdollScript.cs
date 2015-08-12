using System;
using UnityEngine;

[Serializable]
public class RagdollScript : MonoBehaviour
{
	public BloodPoolSpawnerScript BloodPoolSpawner;

	public IncineratorScript Incinerator;

	public TranqCaseScript TranqCase;

	public YandereScript Yandere;

	public PoliceScript Police;

	public PromptScript Prompt;

	public SkinnedMeshRenderer MyRenderer;

	public Collider HideCollider;

	public Rigidbody[] AllRigidbodies;

	public Collider[] AllColliders;

	public Rigidbody[] Rigidbodies;

	public Transform NearestLimb;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform Ponytail;

	public Transform RightEye;

	public Transform LeftEye;

	public Transform HairR;

	public Transform HairL;

	public Transform[] Limb;

	public Transform Head;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public Vector3[] LimbAnchor;

	public GameObject Character;

	public GameObject Zs;

	public bool AddingToCount;

	public bool Electrocuted;

	public bool HidePony;

	public bool Tranquil;

	public bool Dragged;

	public bool Drowned;

	public bool Natural;

	public bool Suicide;

	public bool Dumped;

	public bool Hidden;

	public bool Pushed;

	public bool Male;

	public float AnimStartTime;

	public float BreastSize;

	public float DumpTimer;

	public float EyeShrink;

	public int LimbID;

	public int Frame;

	public string DumpedAnim;

	public RagdollScript()
	{
		this.DumpedAnim = string.Empty;
	}

	public virtual void Start()
	{
		Physics.IgnoreLayerCollision(11, 13, true);
		this.Zs.active = this.Tranquil;
		if (!this.Tranquil && !this.Natural && !this.Drowned && !this.Electrocuted)
		{
			this.BloodPoolSpawner.gameObject.active = true;
			if (this.Pushed)
			{
				this.BloodPoolSpawner.Timer = (float)5;
			}
		}
		for (int i = 0; i < this.AllRigidbodies.Length; i++)
		{
			this.AllRigidbodies[i].isKinematic = false;
			this.AllColliders[i].enabled = true;
		}
		this.Prompt.enabled = true;
	}

	public virtual void Update()
	{
		if (!this.Dumped)
		{
			this.Character.animation.Stop();
			if (!Input.GetButtonDown("LB"))
			{
				if (this.Prompt.Circle[1].fillAmount <= (float)0)
				{
					if (!this.Dragged)
					{
						if (this.Yandere.Ragdoll != null)
						{
							((RagdollScript)this.Yandere.Ragdoll.GetComponent(typeof(RagdollScript))).StopDragging();
						}
						if (this.Yandere.Armed)
						{
							this.Yandere.Unequip();
						}
						if (this.Yandere.PickUp != null)
						{
							this.Yandere.PickUp.Drop();
						}
						this.Prompt.AcceptingInput[1] = false;
						this.Prompt.Circle[1].fillAmount = (float)1;
						this.Prompt.Label[1].text = "     " + "Drop";
						this.PickNearestLimb();
						this.Yandere.RagdollDragger.connectedBody = this.Rigidbodies[this.LimbID];
						this.Yandere.RagdollDragger.connectedAnchor = this.LimbAnchor[this.LimbID];
						this.Yandere.Dragging = true;
						this.Yandere.Ragdoll = this.gameObject;
						this.Dragged = true;
						this.Yandere.StudentManager.UpdateStudents();
						if (this.Suicide)
						{
							this.Police.Suicide = false;
							this.Suicide = false;
						}
					}
					else
					{
						this.StopDragging();
					}
				}
			}
			else if (!this.Yandere.Dumping && this.Dragged)
			{
				this.StopDragging();
			}
			if (Vector3.Distance(this.Yandere.transform.position, this.Prompt.transform.position) < (float)2)
			{
				if (!this.AddingToCount)
				{
					this.Yandere.NearBodies = this.Yandere.NearBodies + 1;
					this.AddingToCount = true;
				}
			}
			else if (this.AddingToCount)
			{
				this.Yandere.NearBodies = this.Yandere.NearBodies - 1;
				this.AddingToCount = false;
			}
			if (!this.Prompt.AcceptingInput[1] && Input.GetButtonUp("B"))
			{
				this.Prompt.AcceptingInput[1] = true;
			}
		}
		else
		{
			if (this.Incinerator != null)
			{
				this.Character.animation.Play(this.DumpedAnim);
				this.DumpTimer += Time.deltaTime;
				if (this.DumpTimer > (float)2)
				{
					if (this.AddingToCount)
					{
						this.Yandere.NearBodies = this.Yandere.NearBodies - 1;
					}
					if (this.Natural)
					{
						this.Police.NaturalScene = false;
						this.Natural = false;
					}
					this.Incinerator.Corpses = this.Incinerator.Corpses + 1;
					UnityEngine.Object.Destroy(this.gameObject);
				}
			}
			if (this.TranqCase != null)
			{
				this.Character.animation.Play("f02_fetal_00");
				float y = Mathf.MoveTowards(this.transform.localPosition.y, 0.36f, Time.deltaTime);
				Vector3 localPosition = this.transform.localPosition;
				float num = localPosition.y = y;
				Vector3 vector = this.transform.localPosition = localPosition;
				if (this.transform.localPosition.y == 0.36f)
				{
					this.TranqCase.Open = false;
					if (this.AddingToCount)
					{
						this.Yandere.NearBodies = this.Yandere.NearBodies - 1;
					}
				}
			}
		}
		if (this.Hidden && this.HideCollider == null)
		{
			this.Police.HiddenCorpses = this.Police.HiddenCorpses - 1;
			this.Hidden = false;
		}
	}

	public virtual void LateUpdate()
	{
		if (!this.Male)
		{
			if (this.HidePony)
			{
				this.Ponytail.parent.transform.localScale = new Vector3((float)1, (float)1, 0.93f);
				this.Ponytail.localScale = new Vector3((float)0, (float)0, (float)0);
				this.HairR.localScale = new Vector3((float)0, (float)0, (float)0);
				this.HairL.localScale = new Vector3((float)0, (float)0, (float)0);
			}
			this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			float z = this.LeftEyeOrigin.z - this.EyeShrink * 0.01f;
			Vector3 localPosition = this.LeftEye.localPosition;
			float num = localPosition.z = z;
			Vector3 vector = this.LeftEye.localPosition = localPosition;
			float z2 = this.RightEyeOrigin.z + this.EyeShrink * 0.01f;
			Vector3 localPosition2 = this.RightEye.localPosition;
			float num2 = localPosition2.z = z2;
			Vector3 vector2 = this.RightEye.localPosition = localPosition2;
			float x = (float)1 - this.EyeShrink * 0.5f;
			Vector3 localScale = this.LeftEye.localScale;
			float num3 = localScale.x = x;
			Vector3 vector3 = this.LeftEye.localScale = localScale;
			float y = (float)1 - this.EyeShrink * 0.5f;
			Vector3 localScale2 = this.LeftEye.localScale;
			float num4 = localScale2.y = y;
			Vector3 vector4 = this.LeftEye.localScale = localScale2;
			float x2 = (float)1 - this.EyeShrink * 0.5f;
			Vector3 localScale3 = this.RightEye.localScale;
			float num5 = localScale3.x = x2;
			Vector3 vector5 = this.RightEye.localScale = localScale3;
			float y2 = (float)1 - this.EyeShrink * 0.5f;
			Vector3 localScale4 = this.RightEye.localScale;
			float num6 = localScale4.y = y2;
			Vector3 vector6 = this.RightEye.localScale = localScale4;
		}
	}

	public virtual void StopDragging()
	{
		this.Prompt.AcceptingInput[1] = false;
		this.Prompt.Circle[1].fillAmount = (float)1;
		this.Prompt.Label[1].text = "     " + "Drag";
		this.Yandere.RagdollDragger.connectedBody = null;
		this.Yandere.Dragging = false;
		this.Yandere.Ragdoll = null;
		this.Yandere.StudentManager.UpdateStudents();
		this.Dragged = false;
	}

	public virtual void PickNearestLimb()
	{
		this.NearestLimb = this.Limb[0];
		this.LimbID = 0;
		for (int i = 1; i < 4; i++)
		{
			if (Vector3.Distance(this.Limb[i].position, this.Yandere.transform.position) < Vector3.Distance(this.NearestLimb.position, this.Yandere.transform.position))
			{
				this.NearestLimb = this.Limb[i];
				this.LimbID = i;
			}
		}
	}

	public virtual void Dump(int Type)
	{
		if (Type == 1)
		{
			this.Incinerator = this.Yandere.Incinerator;
			this.BloodPoolSpawner.enabled = false;
		}
		else
		{
			this.TranqCase = this.Yandere.TranqCase;
		}
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Dumped = true;
		for (int i = 0; i < this.AllRigidbodies.Length; i++)
		{
			this.AllRigidbodies[i].isKinematic = true;
		}
	}

	public virtual void Main()
	{
	}
}
