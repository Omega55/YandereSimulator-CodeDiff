﻿using System;
using UnityEngine;

[Serializable]
public class StandWeaponScript : MonoBehaviour
{
	public PromptScript Prompt;

	public StandScript Stand;

	public float RotationSpeed;

	public virtual void Update()
	{
		if (this.Prompt.enabled)
		{
			if (this.Prompt.Circle[0].fillAmount == (float)0)
			{
				this.MoveToStand();
			}
		}
		else
		{
			this.transform.Rotate(Vector3.forward * Time.deltaTime * this.RotationSpeed);
			this.transform.Rotate(Vector3.right * Time.deltaTime * this.RotationSpeed);
			this.transform.Rotate(Vector3.up * Time.deltaTime * this.RotationSpeed);
		}
	}

	public virtual void MoveToStand()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
		this.Stand.Weapons = this.Stand.Weapons + 1;
		this.transform.parent = this.Stand.Hands[this.Stand.Weapons];
		this.transform.localPosition = new Vector3(-0.277f, (float)0, (float)0);
	}

	public virtual void Main()
	{
	}
}
