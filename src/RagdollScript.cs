using System;
using UnityEngine;

[Serializable]
public class RagdollScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public Rigidbody[] Rigidbodies;

	public Transform BloodParent;

	public Transform NearestLimb;

	public Transform[] Limb;

	public Vector3[] LimbAnchor;

	public GameObject Character;

	public bool AddingToCount;

	public bool Dragged;

	public int LimbID;

	public virtual void Start()
	{
		Physics.IgnoreLayerCollision(9, 11, true);
		if (this.Yandere == null)
		{
			this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		}
	}

	public virtual void Update()
	{
		this.Character.animation.enabled = false;
		if (!Input.GetButtonDown("LB"))
		{
			if (this.Prompt.Circle[1].fillAmount <= (float)0)
			{
				if (!this.Dragged)
				{
					this.Prompt.Circle[1].fillAmount = (float)1;
					this.Prompt.Label[1].text = "     " + "Drop";
					this.PickNearestLimb();
					this.Yandere.RagdollDragger.connectedBody = this.Rigidbodies[this.LimbID];
					this.Yandere.RagdollDragger.connectedAnchor = this.LimbAnchor[this.LimbID];
					this.Yandere.Dragging = true;
					this.Yandere.Ragdoll = this.gameObject;
					if (this.Yandere.Armed)
					{
						this.Yandere.Unequip();
					}
					this.Dragged = true;
				}
				else
				{
					this.StopDragging();
				}
			}
		}
		else if (this.Dragged)
		{
			this.StopDragging();
		}
		if (Vector3.Distance(this.Yandere.transform.position, this.transform.position) < (float)2)
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
	}

	public virtual void StopDragging()
	{
		this.Prompt.Circle[1].fillAmount = (float)1;
		this.Prompt.Label[1].text = "     " + "Drag";
		this.Yandere.RagdollDragger.connectedBody = null;
		this.Yandere.Dragging = false;
		this.Yandere.Ragdoll = null;
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

	public virtual void Main()
	{
	}
}
