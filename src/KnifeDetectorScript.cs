using System;
using UnityEngine;

[Serializable]
public class KnifeDetectorScript : MonoBehaviour
{
	public BlowtorchScript[] Blowtorches;

	public Transform HeatingSpot;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public float Timer;

	public virtual void Start()
	{
		this.Disable();
	}

	public virtual void Update()
	{
		if (!this.Blowtorches[1].rigidbody.useGravity || !this.Blowtorches[2].rigidbody.useGravity || !this.Blowtorches[3].rigidbody.useGravity)
		{
			this.enabled = false;
		}
		if (this.Yandere.Armed)
		{
			if (this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 8)
			{
				this.Prompt.MyCollider.enabled = true;
				this.Prompt.enabled = true;
				if (this.Prompt.Circle[0].fillAmount == (float)0)
				{
					this.Yandere.CharacterAnimation.CrossFade("f02_heating_00");
					this.Yandere.CanMove = false;
					this.Timer = (float)5;
					this.Blowtorches[1].enabled = true;
					this.Blowtorches[2].enabled = true;
					this.Blowtorches[3].enabled = true;
					this.Blowtorches[1].audio.Play();
					this.Blowtorches[2].audio.Play();
					this.Blowtorches[3].audio.Play();
				}
			}
			else
			{
				this.Disable();
			}
		}
		else
		{
			this.Disable();
		}
		if (this.Timer > (float)0)
		{
			this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.HeatingSpot.rotation, Time.deltaTime * (float)10);
			this.Yandere.MoveTowardsTarget(this.HeatingSpot.position);
			float g = Mathf.MoveTowards(this.Yandere.Weapon[this.Yandere.Equipped].MyRenderer.material.color.g, 0.5f, Time.deltaTime * 0.2f);
			Color color = this.Yandere.Weapon[this.Yandere.Equipped].MyRenderer.material.color;
			float num = color.g = g;
			Color color2 = this.Yandere.Weapon[this.Yandere.Equipped].MyRenderer.material.color = color;
			float b = Mathf.MoveTowards(this.Yandere.Weapon[this.Yandere.Equipped].MyRenderer.material.color.b, 0.5f, Time.deltaTime * 0.2f);
			Color color3 = this.Yandere.Weapon[this.Yandere.Equipped].MyRenderer.material.color;
			float num2 = color3.b = b;
			Color color4 = this.Yandere.Weapon[this.Yandere.Equipped].MyRenderer.material.color = color3;
			this.Timer = Mathf.MoveTowards(this.Timer, (float)0, Time.deltaTime);
			if (this.Timer == (float)0)
			{
				this.Yandere.Weapon[this.Yandere.Equipped].Heated = true;
				this.enabled = false;
				this.Disable();
			}
		}
	}

	public virtual void Disable()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
	}

	public virtual void Main()
	{
	}
}
