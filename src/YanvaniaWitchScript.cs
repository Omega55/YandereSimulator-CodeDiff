using System;
using UnityEngine;

[Serializable]
public class YanvaniaWitchScript : MonoBehaviour
{
	public YanvaniaYanmontScript Yanmont;

	public GameObject GroundImpact;

	public GameObject BlackHole;

	public GameObject Character;

	public GameObject HitEffect;

	public GameObject Wall;

	public AudioClip DeathScream;

	public AudioClip HitSound;

	public float HitReactTimer;

	public float AttackTimer;

	public float HP;

	public bool CastSpell;

	public bool Casting;

	public YanvaniaWitchScript()
	{
		this.AttackTimer = 10f;
		this.HP = 100f;
	}

	public virtual void Update()
	{
		if (this.AttackTimer < (float)10)
		{
			this.AttackTimer += Time.deltaTime;
			if (this.AttackTimer > 0.8f && !this.CastSpell)
			{
				this.CastSpell = true;
				UnityEngine.Object.Instantiate(this.BlackHole, this.transform.position + Vector3.up * (float)3 + Vector3.right * (float)6, Quaternion.identity);
				UnityEngine.Object.Instantiate(this.GroundImpact, this.transform.position + Vector3.right * 1.15f, Quaternion.identity);
			}
			if (this.Character.animation["Staff Spell Ground"].time >= this.Character.animation["Staff Spell Ground"].length)
			{
				this.Character.animation.CrossFade("Staff Stance");
				this.Casting = false;
			}
		}
		else if (Vector3.Distance(this.transform.position, this.Yanmont.transform.position) < (float)5)
		{
			this.AttackTimer = (float)0;
			this.Casting = true;
			this.CastSpell = false;
			this.Character.animation["Staff Spell Ground"].time = (float)0;
			this.Character.animation.CrossFade("Staff Spell Ground");
		}
		if (!this.Casting && this.Character.animation["Receive Damage"].time >= this.Character.animation["Receive Damage"].length)
		{
			this.Character.animation.CrossFade("Staff Stance");
		}
		this.HitReactTimer += Time.deltaTime * (float)10;
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (this.HP > (float)0)
		{
			if (other.gameObject.tag == "Player")
			{
				this.Yanmont.TakeDamage(5);
			}
			if (other.gameObject.name == "Heart")
			{
				if (!this.Casting)
				{
					this.Character.animation["Receive Damage"].time = (float)0;
					this.Character.animation.Play("Receive Damage");
				}
				if (this.HitReactTimer >= (float)1)
				{
					UnityEngine.Object.Instantiate(this.HitEffect, other.transform.position, Quaternion.identity);
					this.HitReactTimer = (float)0;
					this.HP -= (float)(5 + (this.Yanmont.Level * 5 - 5));
					if (this.HP <= (float)0)
					{
						this.audio.PlayOneShot(this.DeathScream);
						this.Character.animation.Play("Die 2");
						this.Yanmont.EXP = this.Yanmont.EXP + (float)100;
						this.enabled = false;
						UnityEngine.Object.Destroy(this.Wall);
					}
					else
					{
						this.audio.PlayOneShot(this.HitSound);
					}
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
