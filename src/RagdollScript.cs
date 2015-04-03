using System;
using UnityEngine;

[Serializable]
public class RagdollScript : MonoBehaviour
{
	public BloodPoolSpawnerScript BloodPoolSpawner;

	public IncineratorScript Incinerator;

	public TranqCaseScript TranqCase;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public SkinnedMeshRenderer MyRenderer;

	public Rigidbody[] AllRigidbodies;

	public Rigidbody[] Rigidbodies;

	public Transform BloodParent;

	public Transform NearestLimb;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform Ponytail;

	public Transform HairR;

	public Transform HairL;

	public Transform[] Limb;

	public Transform Head;

	public Vector3[] LimbAnchor;

	public GameObject Character;

	public GameObject Zs;

	public bool AddingToCount;

	public bool HidePony;

	public bool Tranquil;

	public bool Dragged;

	public bool Dumped;

	public float AnimStartTime;

	public float DumpTimer;

	public float BreastSize;

	public int LimbID;

	public int Frame;

	public virtual void Start()
	{
		Physics.IgnoreLayerCollision(11, 13, true);
		if (this.Yandere == null)
		{
			this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		}
		this.Character.animation.Play("f02_down_22");
		this.Character.animation["f02_down_22"].time = this.AnimStartTime;
		this.Character.animation["f02_down_22"].speed = (float)0;
		this.Zs.active = this.Tranquil;
		if (this.Tranquil)
		{
			this.BloodPoolSpawner.enabled = false;
		}
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
				this.Character.animation.Play("f02_thrown_20");
				this.DumpTimer += Time.deltaTime;
				if (this.DumpTimer > (float)2)
				{
					if (this.AddingToCount)
					{
						this.Yandere.NearBodies = this.Yandere.NearBodies - 1;
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
	}

	public virtual void LateUpdate()
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
