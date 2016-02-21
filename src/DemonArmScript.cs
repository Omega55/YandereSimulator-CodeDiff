using System;
using UnityEngine;

[Serializable]
public class DemonArmScript : MonoBehaviour
{
	public GameObject DismembermentCollider;

	public Collider ClawCollider;

	public bool Attacking;

	public bool Attacked;

	public bool Rising;

	public string IdleAnim;

	public AudioClip Whoosh;

	public DemonArmScript()
	{
		this.Rising = true;
		this.IdleAnim = "DemonArmIdle";
	}

	public virtual void Update()
	{
		if (!this.Rising)
		{
			if (!this.Attacking)
			{
				this.animation.CrossFade(this.IdleAnim);
			}
			else if (!this.Attacked)
			{
				if (this.animation["DemonArmAttack"].time >= this.animation["DemonArmAttack"].length * 0.25f)
				{
					this.ClawCollider.enabled = true;
					this.Attacked = true;
				}
			}
			else if (this.animation["DemonArmAttack"].time >= this.animation["DemonArmAttack"].length)
			{
				this.animation.CrossFade(this.IdleAnim);
				this.Attacking = false;
				this.Attacked = false;
			}
		}
		else if (this.animation["DemonArmRise"].time > this.animation["DemonArmRise"].length)
		{
			this.Rising = false;
		}
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if ((StudentScript)other.gameObject.GetComponent(typeof(StudentScript)) != null && ((StudentScript)other.gameObject.GetComponent(typeof(StudentScript))).StudentID > 1)
		{
			this.audio.clip = this.Whoosh;
			this.audio.pitch = UnityEngine.Random.Range(-0.9f, 1.1f);
			this.audio.Play();
			this.animation.CrossFade("DemonArmAttack");
			this.Attacking = true;
		}
	}

	public virtual void Main()
	{
	}
}
