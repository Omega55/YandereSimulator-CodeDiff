using System;
using UnityEngine;

public class AttackManagerScript : MonoBehaviour
{
	private GameObject OriginalBloodEffect;

	public GameObject BloodEffect;

	public GameObject Victim;

	public YandereScript Yandere;

	public WeaponScript Weapon;

	public string VictimAnimName = string.Empty;

	public string AnimName = string.Empty;

	public string Gender = string.Empty;

	public string Prefix = string.Empty;

	public string Sanity = string.Empty;

	public bool Attacking;

	public bool PingPong;

	public bool Stealth;

	public bool Loop;

	public int CurrentWeapon = 1;

	public int EffectPhase;

	public int LoopPhase;

	public float AttackTimer;

	public float Distance;

	public float Timer;

	public float LoopStart;

	public float LoopEnd;

	public AudioClip[] Clips;

	private void Start()
	{
		this.OriginalBloodEffect = this.BloodEffect;
	}

	public void Attack()
	{
		this.Weapon = this.Yandere.Weapon[this.Yandere.Equipped];
		this.Clips = this.Weapon.Clips;
		if (this.Weapon.Clips2.Length > 0)
		{
			int num = UnityEngine.Random.Range(2, 4);
			this.Clips = ((num != 2) ? this.Weapon.Clips3 : this.Weapon.Clips2);
		}
		this.Yandere.FollowHips = true;
		this.AttackTimer = 0f;
		this.EffectPhase = 0;
		this.SanityCheck();
		if (this.Weapon.Type == 1)
		{
			this.Prefix = "knife";
		}
		else if (this.Weapon.Type == 2)
		{
			this.Prefix = "katana";
		}
		else if (this.Weapon.Type == 3)
		{
			this.Prefix = "bat";
		}
		else if (this.Weapon.Type == 4)
		{
			this.Prefix = "saw";
		}
		else if (this.Weapon.Type == 5)
		{
			this.Prefix = "syringe";
		}
		this.Gender = ((!this.Yandere.TargetStudent.Male) ? "f02_" : string.Empty);
		if (!this.Stealth)
		{
			this.AnimName = "f02_" + this.Prefix + this.Sanity + "SanityA_00";
			this.VictimAnimName = this.Gender + this.Prefix + this.Sanity + "SanityB_00";
		}
		else
		{
			this.AnimName = "f02_" + this.Prefix + "StealthA_00";
			this.VictimAnimName = this.Gender + this.Prefix + "StealthB_00";
		}
		Animation component = this.Yandere.Character.GetComponent<Animation>();
		component[this.AnimName].time = 0f;
		component.CrossFade(this.AnimName);
		Animation component2 = this.Victim.GetComponent<Animation>();
		component2[this.VictimAnimName].time = 0f;
		component2.CrossFade(this.VictimAnimName);
		AudioSource component3 = this.Weapon.gameObject.GetComponent<AudioSource>();
		if (this.Stealth)
		{
			component3.clip = this.Clips[0];
		}
		else if (this.Yandere.Sanity / 100f > 0.6666667f)
		{
			component3.clip = this.Clips[1];
		}
		else if (this.Yandere.Sanity / 100f > 0.333333343f)
		{
			component3.clip = this.Clips[2];
		}
		else
		{
			component3.clip = this.Clips[3];
		}
		component3.time = 0f;
		component3.Play();
		if (this.Weapon.Type == 1)
		{
			this.Weapon.Flip = true;
		}
		this.GetDistance();
		this.Attacking = true;
	}

	private void Update()
	{
		if (this.Attacking)
		{
			this.AttackTimer += Time.deltaTime;
			this.SpecialEffect();
			if (this.Yandere.Sanity <= 0.333333343f && !this.Yandere.Chased)
			{
				this.LoopCheck();
			}
			this.SpecialEffect();
			Animation component = this.Yandere.Character.GetComponent<Animation>();
			if (component[this.AnimName].time > component[this.AnimName].length - 0.333333343f)
			{
				component.CrossFade("f02_idle_00");
				this.Weapon.Flip = false;
			}
			if (this.AttackTimer > component[this.AnimName].length)
			{
				if (this.Yandere.TargetStudent == this.Yandere.StudentManager.Reporter)
				{
					this.Yandere.StudentManager.Reporter = null;
				}
				if (!this.Yandere.CanTranq)
				{
					this.Yandere.TargetStudent.Dead = true;
					this.Yandere.Bloodiness += 20f;
					this.Yandere.UpdateBlood();
					this.Yandere.StainWeapon();
				}
				else
				{
					this.Yandere.TargetStudent.Tranquil = true;
					this.Yandere.CanTranq = false;
					this.Yandere.Followers--;
					this.Weapon.Type = 1;
				}
				this.Yandere.TargetStudent.DeathCause = this.Yandere.Weapon[this.Yandere.Equipped].WeaponID;
				this.Yandere.TargetStudent.BecomeRagdoll();
				this.Yandere.Sanity -= 20f * this.Yandere.Numbness;
				this.Yandere.UpdateSanity();
				this.Yandere.Attacking = false;
				this.Yandere.FollowHips = false;
				this.Yandere.MyController.radius = 0.2f;
				this.Attacking = false;
				this.Stealth = false;
				this.EffectPhase = 0;
				this.AttackTimer = 0f;
				this.Timer = 0f;
				this.CheckForSpecialCase();
				if (!this.Yandere.Noticed)
				{
					this.Yandere.CanMove = true;
				}
				else
				{
					this.Yandere.Weapon[this.Yandere.Equipped].Drop();
				}
			}
		}
	}

	private void SanityCheck()
	{
		if (this.Yandere.Sanity > 100f)
		{
			this.Yandere.Sanity = 100f;
		}
		else if (this.Yandere.Sanity < 0f)
		{
			this.Yandere.Sanity = 0f;
		}
		if (this.Yandere.Sanity / 100f > 0.6666667f)
		{
			this.Sanity = "High";
		}
		else if (this.Yandere.Sanity / 100f > 0.333333343f)
		{
			this.Sanity = "Med";
		}
		else
		{
			this.Sanity = "Low";
		}
	}

	private void GetDistance()
	{
		if (this.Weapon.Type == 1)
		{
			if (this.Stealth)
			{
				this.Distance = 0.75f;
			}
			else if (this.Yandere.Sanity / 100f > 0.6666667f)
			{
				this.Distance = 1f;
			}
			else if (this.Yandere.Sanity / 100f > 0.333333343f)
			{
				this.Distance = 0.75f;
			}
			else
			{
				this.Distance = 0.5f;
			}
		}
		else if (this.Weapon.Type == 2)
		{
			this.Distance = ((!this.Stealth) ? 1f : 0.5f);
		}
		else if (this.Weapon.Type == 3)
		{
			if (this.Stealth)
			{
				this.Distance = 0.5f;
			}
			else if (this.Yandere.Sanity / 100f > 0.6666667f)
			{
				this.Distance = 0.75f;
			}
			else if (this.Yandere.Sanity / 100f > 0.333333343f)
			{
				this.Distance = 1f;
			}
			else
			{
				this.Distance = 1f;
			}
		}
		else if (this.Weapon.Type == 4)
		{
			this.Distance = ((!this.Stealth) ? 1f : 0.7f);
		}
		else if (this.Weapon.Type == 5)
		{
			this.Distance = 0.5f;
		}
	}

	private void SpecialEffect()
	{
		this.BloodEffect = this.OriginalBloodEffect;
		if (this.Weapon.WeaponID == 14)
		{
			this.BloodEffect = this.Weapon.HeartBurst;
		}
		Animation component = this.Yandere.Character.GetComponent<Animation>();
		if (this.Weapon.Type == 1)
		{
			if (!this.Stealth)
			{
				if (this.Yandere.Sanity / 100f > 0.6666667f)
				{
					if (this.EffectPhase == 0 && component[this.AnimName].time > 1.06666672f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.Yandere.Sanity / 100f > 0.333333343f)
				{
					if (this.EffectPhase == 0)
					{
						if (component[this.AnimName].time > 2.16666675f)
						{
							UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.1f, Quaternion.identity);
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 1 && component[this.AnimName].time > 3.0333333f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 0)
				{
					if (component[this.AnimName].time > 2.76666665f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 1)
				{
					if (component[this.AnimName].time > 3.5333333f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 2 && component[this.AnimName].time > 4.16666651f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.1f, Quaternion.identity);
					this.EffectPhase++;
				}
			}
			else if (this.EffectPhase == 0 && component[this.AnimName].time > 0.966666639f)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.1f, Quaternion.identity);
				this.EffectPhase++;
			}
		}
		else if (this.Weapon.Type == 2)
		{
			if (!this.Stealth)
			{
				if (this.Yandere.Sanity / 100f > 0.6666667f)
				{
					if (this.EffectPhase == 0 && component[this.AnimName].time > 0.483333319f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.Yandere.Sanity / 100f > 0.333333343f)
				{
					if (this.EffectPhase == 0)
					{
						if (component[this.AnimName].time > 0.55f)
						{
							UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.5f, Quaternion.identity);
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 1 && component[this.AnimName].time > 1.51666665f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 0)
				{
					if (component[this.AnimName].time > 0.5f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 1)
				{
					if (component[this.AnimName].time > 1f)
					{
						this.Weapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 2)
				{
					if (component[this.AnimName].time > 2.33333325f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 3)
				{
					if (component[this.AnimName].time > 2.73333335f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 4)
				{
					if (component[this.AnimName].time > 3.13333344f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 5)
				{
					if (component[this.AnimName].time > 3.5333333f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 6)
				{
					if (component[this.AnimName].time > 4.133333f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 8 && component[this.AnimName].time > 5f)
				{
					this.Weapon.transform.localEulerAngles = Vector3.zero;
					this.EffectPhase++;
				}
			}
			else if (this.EffectPhase == 0)
			{
				if (component[this.AnimName].time > 0.366666675f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.6666667f, Quaternion.identity);
					this.EffectPhase++;
				}
			}
			else if (this.EffectPhase == 1 && component[this.AnimName].time > 1f)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.333333343f, Quaternion.identity);
				this.EffectPhase++;
			}
		}
		else if (this.Weapon.Type == 3)
		{
			if (!this.Stealth)
			{
				if (this.Yandere.Sanity / 100f > 0.6666667f)
				{
					if (this.EffectPhase == 0 && component[this.AnimName].time > 0.733333349f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.Yandere.Sanity / 100f > 0.333333343f)
				{
					if (this.EffectPhase == 0)
					{
						if (component[this.AnimName].time > 1f)
						{
							UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.5f, Quaternion.identity);
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 1 && component[this.AnimName].time > 2.9666667f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 0)
				{
					if (component[this.AnimName].time > 0.7f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 1)
				{
					if (component[this.AnimName].time > 3.1f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 2)
				{
					if (component[this.AnimName].time > 3.76666665f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 3 && component[this.AnimName].time > 4.4f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.5f, Quaternion.identity);
					this.EffectPhase++;
				}
			}
		}
		else if (this.Weapon.Type == 4)
		{
			if (!this.Stealth)
			{
				if (this.Yandere.Sanity / 100f > 0.6666667f)
				{
					if (this.EffectPhase == 0)
					{
						if (component[this.AnimName].time > 0f)
						{
							this.Weapon.Spin = true;
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 1)
					{
						if (component[this.AnimName].time > 0.733333349f)
						{
							this.Weapon.BloodSpray[0].Play();
							this.Weapon.BloodSpray[1].Play();
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 2 && component[this.AnimName].time > 1.43333328f)
					{
						this.Weapon.Spin = false;
						this.Weapon.BloodSpray[0].Stop();
						this.Weapon.BloodSpray[1].Stop();
						this.EffectPhase++;
					}
				}
				else if (this.Yandere.Sanity / 100f > 0.333333343f)
				{
					if (this.EffectPhase == 0)
					{
						if (component[this.AnimName].time > 0f)
						{
							this.Weapon.Spin = true;
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 1)
					{
						if (component[this.AnimName].time > 1.1f)
						{
							this.Weapon.BloodSpray[0].Play();
							this.Weapon.BloodSpray[1].Play();
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 2)
					{
						if (component[this.AnimName].time > 1.43333328f)
						{
							this.Weapon.BloodSpray[0].Stop();
							this.Weapon.BloodSpray[1].Stop();
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 3)
					{
						if (component[this.AnimName].time > 2.36666656f)
						{
							this.Weapon.BloodSpray[0].Play();
							this.Weapon.BloodSpray[1].Play();
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 4 && component[this.AnimName].time > 2.4f)
					{
						this.Weapon.Spin = true;
						this.Weapon.BloodSpray[0].Stop();
						this.Weapon.BloodSpray[1].Stop();
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 0)
				{
					if (component[this.AnimName].time > 0f)
					{
						this.Weapon.Spin = true;
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 1)
				{
					if (component[this.AnimName].time > 0.6666667f)
					{
						this.Weapon.BloodSpray[0].Play();
						this.Weapon.BloodSpray[1].Play();
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 2)
				{
					if (component[this.AnimName].time > 0.733333349f)
					{
						this.Weapon.BloodSpray[0].Stop();
						this.Weapon.BloodSpray[1].Stop();
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 3)
				{
					if (component[this.AnimName].time > 3f)
					{
						this.Weapon.BloodSpray[0].Play();
						this.Weapon.BloodSpray[1].Play();
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 4 && component[this.AnimName].time > 4.866667f)
				{
					this.Weapon.Spin = false;
					this.Weapon.BloodSpray[0].Stop();
					this.Weapon.BloodSpray[1].Stop();
					this.EffectPhase++;
				}
			}
			else if (this.EffectPhase == 0 && component[this.AnimName].time > 1f)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.right * 0.2f + this.Weapon.transform.forward * -0.06666667f, Quaternion.identity);
				this.EffectPhase++;
			}
		}
	}

	private void LoopCheck()
	{
		Animation component = this.Yandere.Character.GetComponent<Animation>();
		if (Input.GetButtonDown("X"))
		{
			if (this.Weapon.Type == 1)
			{
				if (component[this.AnimName].time > 3.5333333f && component[this.AnimName].time < 4.16666651f)
				{
					this.LoopStart = 106f;
					this.LoopEnd = 125f;
					this.LoopPhase = 2;
					this.Loop = true;
				}
			}
			else if (this.Weapon.Type == 2)
			{
				if (component[this.AnimName].time > 3.36666656f && component[this.AnimName].time < 3.9f)
				{
					this.LoopStart = 101f;
					this.LoopEnd = 117f;
					this.LoopPhase = 5;
					this.Loop = true;
				}
			}
			else if (this.Weapon.Type == 3)
			{
				if (component[this.AnimName].time > 3.76666665f && component[this.AnimName].time < 4.4f)
				{
					this.LoopStart = 113f;
					this.LoopEnd = 132f;
					this.LoopPhase = 2;
					this.Loop = true;
				}
			}
			else if (this.Weapon.Type == 4 && component[this.AnimName].time > 3.0333333f && component[this.AnimName].time < 4.5666666f)
			{
				this.LoopStart = 91f;
				this.LoopEnd = 137f;
				this.LoopPhase = 3;
				this.PingPong = true;
			}
		}
		AudioSource component2 = this.Weapon.gameObject.GetComponent<AudioSource>();
		Animation component3 = this.Victim.GetComponent<Animation>();
		if (this.PingPong)
		{
			if (component[this.AnimName].time > this.LoopEnd / 30f)
			{
				component2.pitch = 1f + UnityEngine.Random.Range(0.1f, -0.1f);
				component2.time = this.LoopStart / 30f;
				component3[this.VictimAnimName].speed = -1f;
				component[this.AnimName].speed = -1f;
				this.EffectPhase = this.LoopPhase;
				this.AttackTimer = 0f;
			}
			else if (component[this.AnimName].time < this.LoopStart / 30f)
			{
				component2.pitch = 1f + UnityEngine.Random.Range(0.1f, -0.1f);
				component2.time = this.LoopStart / 30f;
				component3[this.VictimAnimName].speed = 1f;
				component[this.AnimName].speed = 1f;
				this.EffectPhase = this.LoopPhase;
				this.AttackTimer = this.LoopStart / 30f;
				this.EffectPhase = this.LoopPhase;
				this.PingPong = false;
			}
		}
		if (this.Loop && component[this.AnimName].time > this.LoopEnd / 30f)
		{
			component2.pitch = 1f + UnityEngine.Random.Range(0.1f, -0.1f);
			component2.time = this.LoopStart / 30f;
			component3[this.VictimAnimName].time = this.LoopStart / 30f;
			component[this.AnimName].time = this.LoopStart / 30f;
			this.AttackTimer = this.LoopStart / 30f;
			this.EffectPhase = this.LoopPhase;
			this.Loop = false;
		}
	}

	private void CheckForSpecialCase()
	{
		if (this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 8)
		{
			this.Yandere.TargetStudent.Ragdoll.Sacrifice = true;
			if (PlayerPrefs.GetInt("Paranormal") == 1)
			{
				this.Yandere.Weapon[this.Yandere.Equipped].Effect();
			}
		}
	}
}
