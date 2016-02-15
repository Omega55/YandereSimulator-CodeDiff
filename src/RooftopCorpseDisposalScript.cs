using System;
using UnityEngine;

[Serializable]
public class RooftopCorpseDisposalScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public Collider MyCollider;

	public Transform DropSpot;

	public virtual void Update()
	{
		if (this.MyCollider.bounds.Contains(this.Yandere.transform.position))
		{
			if (this.Yandere.Ragdoll != null)
			{
				if (!this.Yandere.Dropping)
				{
					this.Prompt.enabled = true;
					this.Prompt.transform.position = new Vector3(this.Yandere.transform.position.x, this.Yandere.transform.position.y + 1.66666f, this.Yandere.transform.position.z);
					if (this.Prompt.Circle[0].fillAmount == (float)0)
					{
						float z = this.Yandere.transform.position.z;
						Vector3 position = this.DropSpot.position;
						float num = position.z = z;
						Vector3 vector = this.DropSpot.position = position;
						if (!this.Yandere.Carrying)
						{
							this.Yandere.Character.animation.CrossFade("f02_dragIdle_00");
						}
						else
						{
							this.Yandere.Character.animation.CrossFade("f02_carryIdleA_00");
						}
						this.Yandere.DropSpot = this.DropSpot;
						this.Yandere.Dropping = true;
						this.Yandere.CanMove = false;
						this.Prompt.Hide();
						this.Prompt.enabled = false;
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

	public virtual void Main()
	{
	}
}
