using System;
using UnityEngine;

public class RooftopCorpseDisposalScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public Collider MyCollider;

	public Transform DropSpot;

	private void Start()
	{
		if (SchoolGlobals.RoofFence)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void Update()
	{
		if (this.MyCollider.bounds.Contains(this.Yandere.transform.position))
		{
			if (this.Yandere.Ragdoll != null)
			{
				if (!this.Yandere.Dropping)
				{
					this.Prompt.enabled = true;
					this.Prompt.transform.position = new Vector3(this.Yandere.transform.position.x, this.Yandere.transform.position.y + 1.66666f, this.Yandere.transform.position.z);
					if (this.Prompt.Circle[0].fillAmount == 0f)
					{
						this.DropSpot.position = new Vector3(this.DropSpot.position.x, this.DropSpot.position.y, this.Yandere.transform.position.z);
						this.Yandere.Character.GetComponent<Animation>().CrossFade((!this.Yandere.Carrying) ? "f02_dragIdle_00" : "f02_carryIdleA_00");
						this.Yandere.DropSpot = this.DropSpot;
						this.Yandere.Dropping = true;
						this.Yandere.CanMove = false;
						this.Prompt.Hide();
						this.Prompt.enabled = false;
						this.Yandere.CurrentRagdoll.BloodPoolSpawner.Falling = true;
					}
				}
			}
			else
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}
}
