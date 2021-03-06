﻿using System;
using UnityEngine;

public class AttackManagerScript : MonoBehaviour
{
	public GameObject BloodEffect;

	private GameObject OriginalBloodEffect;

	private GameObject Victim;

	private YandereScript Yandere;

	private string VictimAnimName = string.Empty;

	private string AnimName = string.Empty;

	public bool PingPong;

	public bool Stealth;

	public bool Censor;

	public bool Loop;

	public int EffectPhase;

	public int LoopPhase;

	public float AttackTimer;

	public float Distance;

	public float Timer;

	public float LoopStart;

	public float LoopEnd;

	public Animation YandereAnim;

	public Animation VictimAnim;

	private void Awake()
	{
		this.Yandere = base.GetComponent<YandereScript>();
	}

	private void Start()
	{
		this.OriginalBloodEffect = this.BloodEffect;
	}

	public bool IsAttacking()
	{
		return this.Victim != null;
	}

	private float GetReachDistance(WeaponType weaponType, SanityType sanityType)
	{
		if (weaponType == WeaponType.Knife)
		{
			if (this.Stealth)
			{
				return 0.75f;
			}
			if (sanityType == SanityType.High)
			{
				return 1f;
			}
			if (sanityType == SanityType.Medium)
			{
				return 0.75f;
			}
			return 0.5f;
		}
		else if (weaponType == WeaponType.Katana)
		{
			if (!this.Stealth)
			{
				return 1f;
			}
			return 0.5f;
		}
		else if (weaponType == WeaponType.Bat)
		{
			if (this.Stealth)
			{
				return 0.5f;
			}
			if (sanityType == SanityType.High)
			{
				return 0.75f;
			}
			return 1f;
		}
		else if (weaponType == WeaponType.Saw)
		{
			if (!this.Stealth)
			{
				return 1f;
			}
			return 0.7f;
		}
		else if (weaponType == WeaponType.Weight)
		{
			if (this.Stealth)
			{
				return 0.75f;
			}
			if (sanityType == SanityType.High)
			{
				return 0.75f;
			}
			return 0.75f;
		}
		else
		{
			if (weaponType == WeaponType.Syringe)
			{
				return 0.5f;
			}
			if (weaponType == WeaponType.Garrote)
			{
				return 0.5f;
			}
			Debug.LogError("Weapon type \"" + weaponType.ToString() + "\" not implemented.");
			return 0f;
		}
	}

	public void Attack(GameObject victim, WeaponScript weapon)
	{
		this.Victim = victim;
		this.Yandere.FollowHips = true;
		this.AttackTimer = 0f;
		this.EffectPhase = 0;
		this.Yandere.Sanity = Mathf.Clamp(this.Yandere.Sanity, 0f, 100f);
		SanityType sanityType = this.Yandere.SanityType;
		string sanityString = this.Yandere.GetSanityString(sanityType);
		string str = weapon.GetTypePrefix();
		string str2 = this.Yandere.TargetStudent.Male ? string.Empty : "f02_";
		if (!this.Stealth)
		{
			this.VictimAnimName = str2 + str + sanityString + "SanityB_00";
			if (weapon.WeaponID == 23)
			{
				str = "extin";
			}
			this.AnimName = "f02_" + str + sanityString + "SanityA_00";
		}
		else
		{
			this.VictimAnimName = str2 + str + "StealthB_00";
			if (weapon.WeaponID == 23)
			{
				str = "extin";
			}
			this.AnimName = "f02_" + str + "StealthA_00";
		}
		this.YandereAnim = this.Yandere.CharacterAnimation;
		this.YandereAnim[this.AnimName].time = 0f;
		this.YandereAnim.CrossFade(this.AnimName);
		this.VictimAnim = this.Yandere.TargetStudent.CharacterAnimation;
		this.VictimAnim[this.VictimAnimName].time = 0f;
		this.VictimAnim.CrossFade(this.VictimAnimName);
		weapon.MyAudio.clip = weapon.GetClip(this.Yandere.Sanity / 100f, this.Stealth);
		weapon.MyAudio.time = 0f;
		weapon.MyAudio.Play();
		if (weapon.Type == WeaponType.Knife)
		{
			weapon.Flip = true;
		}
		this.Distance = this.GetReachDistance(weapon.Type, sanityType);
	}

	private void Update()
	{
		if (this.IsAttacking())
		{
			this.VictimAnim.CrossFade(this.VictimAnimName);
			if (this.Censor)
			{
				if (this.AttackTimer == 0f)
				{
					this.Yandere.Blur.enabled = true;
					this.Yandere.Blur.blurSize = 0f;
					this.Yandere.Blur.blurIterations = 0;
				}
				if (this.AttackTimer < this.YandereAnim[this.AnimName].length - 0.5f)
				{
					this.Yandere.Blur.blurSize = Mathf.MoveTowards(this.Yandere.Blur.blurSize, 10f, Time.deltaTime * 10f);
					if (this.Yandere.Blur.blurSize > (float)this.Yandere.Blur.blurIterations)
					{
						this.Yandere.Blur.blurIterations++;
					}
				}
				else
				{
					this.Yandere.Blur.blurSize = Mathf.Lerp(this.Yandere.Blur.blurSize, 0f, Time.deltaTime * 10f);
					if (this.Yandere.Blur.blurSize < (float)this.Yandere.Blur.blurIterations)
					{
						this.Yandere.Blur.blurIterations--;
					}
				}
			}
			this.AttackTimer += Time.deltaTime;
			WeaponScript equippedWeapon = this.Yandere.EquippedWeapon;
			SanityType sanityType = this.Yandere.SanityType;
			this.SpecialEffect(equippedWeapon, sanityType);
			if (sanityType == SanityType.Low)
			{
				this.LoopCheck(equippedWeapon);
			}
			this.SpecialEffect(equippedWeapon, sanityType);
			if (this.YandereAnim[this.AnimName].time > this.YandereAnim[this.AnimName].length - 0.333333343f)
			{
				this.YandereAnim.CrossFade("f02_idle_00");
				equippedWeapon.Flip = false;
			}
			if (this.AttackTimer > this.YandereAnim[this.AnimName].length)
			{
				if (this.Yandere.TargetStudent == this.Yandere.StudentManager.Reporter)
				{
					this.Yandere.StudentManager.Reporter = null;
				}
				if (!this.Yandere.CanTranq)
				{
					this.Yandere.TargetStudent.DeathType = DeathType.Weapon;
				}
				else
				{
					this.Yandere.TargetStudent.Tranquil = true;
					this.Yandere.NoStainGloves = true;
					this.Yandere.CanTranq = false;
					this.Yandere.StainWeapon();
					this.Yandere.Follower = null;
					this.Yandere.Followers--;
					equippedWeapon.Type = WeaponType.Knife;
				}
				this.Yandere.TargetStudent.DeathCause = equippedWeapon.WeaponID;
				this.Yandere.TargetStudent.BecomeRagdoll();
				this.Yandere.Sanity -= ((PlayerGlobals.PantiesEquipped == 10) ? 10f : 20f) * this.Yandere.Numbness;
				this.Yandere.Attacking = false;
				this.Yandere.FollowHips = false;
				this.Yandere.HipCollider.enabled = false;
				bool flag = false;
				if (this.Yandere.EquippedWeapon.Type == WeaponType.Bat)
				{
					flag = true;
				}
				if (!flag)
				{
					this.Yandere.EquippedWeapon.Evidence = true;
				}
				this.Victim = null;
				this.VictimAnimName = null;
				this.AnimName = null;
				this.Stealth = false;
				this.EffectPhase = 0;
				this.AttackTimer = 0f;
				this.Timer = 0f;
				this.CheckForSpecialCase(equippedWeapon);
				this.Yandere.Blur.enabled = false;
				this.Yandere.Blur.blurSize = 0f;
				if (equippedWeapon.Blunt)
				{
					this.Yandere.TargetStudent.Ragdoll.NeckSnapped = true;
					this.Yandere.TargetStudent.NeckSnapped = true;
				}
				if (!this.Yandere.Noticed)
				{
					this.Yandere.EquippedWeapon.MurderWeapon = true;
					this.Yandere.CanMove = true;
					return;
				}
				equippedWeapon.Drop();
			}
		}
	}

	private void SpecialEffect(WeaponScript weapon, SanityType sanityType)
	{
		this.BloodEffect = this.OriginalBloodEffect;
		if (weapon.WeaponID == 14)
		{
			this.BloodEffect = weapon.HeartBurst;
		}
		if (weapon.Type == WeaponType.Knife)
		{
			if (!this.Stealth)
			{
				if (sanityType == SanityType.High)
				{
					if (this.EffectPhase == 0 && this.YandereAnim[this.AnimName].time > 1.06666672f)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (sanityType == SanityType.Medium)
				{
					if (this.EffectPhase == 0)
					{
						if (this.YandereAnim[this.AnimName].time > 2.16666675f)
						{
							this.Yandere.Bloodiness += 20f;
							this.Yandere.StainWeapon();
							UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
							this.EffectPhase++;
							return;
						}
					}
					else if (this.EffectPhase == 1 && this.YandereAnim[this.AnimName].time > 3.0333333f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 0)
				{
					if (this.YandereAnim[this.AnimName].time > 2.76666665f)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 1)
				{
					if (this.YandereAnim[this.AnimName].time > 3.5333333f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 2 && this.YandereAnim[this.AnimName].time > 4.16666651f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
					this.EffectPhase++;
					return;
				}
			}
			else if (this.EffectPhase == 0 && this.YandereAnim[this.AnimName].time > 0.966666639f)
			{
				this.Yandere.Bloodiness += 20f;
				this.Yandere.StainWeapon();
				UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
				this.EffectPhase++;
				return;
			}
		}
		else if (weapon.Type == WeaponType.Katana)
		{
			if (!this.Stealth)
			{
				if (sanityType == SanityType.High)
				{
					if (this.EffectPhase == 0 && this.YandereAnim[this.AnimName].time > 0.483333319f)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (sanityType == SanityType.Medium)
				{
					if (this.EffectPhase == 0)
					{
						if (this.YandereAnim[this.AnimName].time > 0.55f)
						{
							this.Yandere.Bloodiness += 20f;
							this.Yandere.StainWeapon();
							UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
							this.EffectPhase++;
							return;
						}
					}
					else if (this.EffectPhase == 1 && this.YandereAnim[this.AnimName].time > 1.51666665f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 0)
				{
					if (this.YandereAnim[this.AnimName].time > 0.5f)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 1)
				{
					if (this.YandereAnim[this.AnimName].time > 1f)
					{
						weapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 2)
				{
					if (this.YandereAnim[this.AnimName].time > 2.33333325f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 3)
				{
					if (this.YandereAnim[this.AnimName].time > 2.73333335f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 4)
				{
					if (this.YandereAnim[this.AnimName].time > 3.13333344f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 5)
				{
					if (this.YandereAnim[this.AnimName].time > 3.5333333f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 6)
				{
					if (this.YandereAnim[this.AnimName].time > 4.133333f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 8 && this.YandereAnim[this.AnimName].time > 5f)
				{
					weapon.transform.localEulerAngles = Vector3.zero;
					this.EffectPhase++;
					return;
				}
			}
			else if (this.EffectPhase == 0)
			{
				if (this.YandereAnim[this.AnimName].time > 0.366666675f)
				{
					this.Yandere.Bloodiness += 20f;
					this.Yandere.StainWeapon();
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
					this.EffectPhase++;
					return;
				}
			}
			else if (this.EffectPhase == 1 && this.YandereAnim[this.AnimName].time > 1f)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.333333343f, Quaternion.identity);
				this.EffectPhase++;
				return;
			}
		}
		else if (weapon.Type == WeaponType.Bat)
		{
			if (this.Stealth)
			{
				this.Yandere.TargetStudent.Ragdoll.NeckSnapped = true;
				this.Yandere.TargetStudent.NeckSnapped = true;
				return;
			}
			if (sanityType == SanityType.High)
			{
				if (this.EffectPhase == 0 && this.YandereAnim[this.AnimName].time > 0.733333349f)
				{
					if (!weapon.Blunt)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
					}
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
					this.EffectPhase++;
					return;
				}
			}
			else if (sanityType == SanityType.Medium)
			{
				if (this.EffectPhase == 0)
				{
					if (this.YandereAnim[this.AnimName].time > 1f)
					{
						if (!weapon.Blunt)
						{
							this.Yandere.Bloodiness += 20f;
							this.Yandere.StainWeapon();
						}
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 1 && this.YandereAnim[this.AnimName].time > 2.9666667f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
					this.EffectPhase++;
					return;
				}
			}
			else if (this.EffectPhase == 0)
			{
				if (this.YandereAnim[this.AnimName].time > 0.7f)
				{
					if (!weapon.Blunt)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
					}
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
					this.EffectPhase++;
					return;
				}
			}
			else if (this.EffectPhase == 1)
			{
				if (this.YandereAnim[this.AnimName].time > 3.1f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
					this.EffectPhase++;
					return;
				}
			}
			else if (this.EffectPhase == 2)
			{
				if (this.YandereAnim[this.AnimName].time > 3.76666665f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
					this.EffectPhase++;
					return;
				}
			}
			else if (this.EffectPhase == 3 && this.YandereAnim[this.AnimName].time > 4.4f)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
				this.EffectPhase++;
				return;
			}
		}
		else if (weapon.Type == WeaponType.Saw)
		{
			if (!this.Stealth)
			{
				if (sanityType == SanityType.High)
				{
					if (this.EffectPhase == 0)
					{
						if (this.YandereAnim[this.AnimName].time > 0f)
						{
							weapon.Spin = true;
							this.EffectPhase++;
							return;
						}
					}
					else if (this.EffectPhase == 1)
					{
						if (this.YandereAnim[this.AnimName].time > 0.733333349f)
						{
							this.Yandere.Bloodiness += 20f;
							this.Yandere.StainWeapon();
							weapon.BloodSpray[0].Play();
							weapon.BloodSpray[1].Play();
							this.EffectPhase++;
							return;
						}
					}
					else if (this.EffectPhase == 2 && this.YandereAnim[this.AnimName].time > 1.43333328f)
					{
						weapon.Spin = false;
						weapon.BloodSpray[0].Stop();
						weapon.BloodSpray[1].Stop();
						this.EffectPhase++;
						return;
					}
				}
				else if (sanityType == SanityType.Medium)
				{
					if (this.EffectPhase == 0)
					{
						if (this.YandereAnim[this.AnimName].time > 0f)
						{
							weapon.Spin = true;
							this.EffectPhase++;
							return;
						}
					}
					else if (this.EffectPhase == 1)
					{
						if (this.YandereAnim[this.AnimName].time > 1.1f)
						{
							this.Yandere.Bloodiness += 20f;
							this.Yandere.StainWeapon();
							weapon.BloodSpray[0].Play();
							weapon.BloodSpray[1].Play();
							this.EffectPhase++;
							return;
						}
					}
					else if (this.EffectPhase == 2)
					{
						if (this.YandereAnim[this.AnimName].time > 1.43333328f)
						{
							weapon.BloodSpray[0].Stop();
							weapon.BloodSpray[1].Stop();
							this.EffectPhase++;
							return;
						}
					}
					else if (this.EffectPhase == 3)
					{
						if (this.YandereAnim[this.AnimName].time > 2.36666656f)
						{
							weapon.BloodSpray[0].Play();
							weapon.BloodSpray[1].Play();
							this.EffectPhase++;
							return;
						}
					}
					else if (this.EffectPhase == 4 && this.YandereAnim[this.AnimName].time > 2.4f)
					{
						weapon.Spin = true;
						weapon.BloodSpray[0].Stop();
						weapon.BloodSpray[1].Stop();
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 0)
				{
					if (this.YandereAnim[this.AnimName].time > 0f)
					{
						weapon.Spin = true;
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 1)
				{
					if (this.YandereAnim[this.AnimName].time > 0.6666667f)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
						weapon.BloodSpray[0].Play();
						weapon.BloodSpray[1].Play();
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 2)
				{
					if (this.YandereAnim[this.AnimName].time > 0.733333349f)
					{
						weapon.BloodSpray[0].Stop();
						weapon.BloodSpray[1].Stop();
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 3)
				{
					if (this.YandereAnim[this.AnimName].time > 3f)
					{
						weapon.BloodSpray[0].Play();
						weapon.BloodSpray[1].Play();
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 4 && this.YandereAnim[this.AnimName].time > 4.866667f)
				{
					weapon.Spin = false;
					weapon.BloodSpray[0].Stop();
					weapon.BloodSpray[1].Stop();
					this.EffectPhase++;
					return;
				}
			}
			else if (this.EffectPhase == 0 && this.YandereAnim[this.AnimName].time > 1f)
			{
				this.Yandere.Bloodiness += 20f;
				this.Yandere.StainWeapon();
				UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.right * 0.2f + weapon.transform.forward * -0.06666667f, Quaternion.identity);
				this.EffectPhase++;
				return;
			}
		}
		else if (weapon.Type == WeaponType.Weight)
		{
			if (this.Stealth)
			{
				this.Yandere.TargetStudent.Ragdoll.NeckSnapped = true;
				this.Yandere.TargetStudent.NeckSnapped = true;
				return;
			}
			if (sanityType == SanityType.High)
			{
				if (this.EffectPhase == 0 && this.YandereAnim[this.AnimName].time > 0.6666667f)
				{
					if (!weapon.Blunt)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
					}
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
					this.EffectPhase++;
					return;
				}
			}
			else if (sanityType == SanityType.Medium)
			{
				if (this.EffectPhase == 0)
				{
					if (this.YandereAnim[this.AnimName].time > 1f)
					{
						if (!weapon.Blunt)
						{
							this.Yandere.Bloodiness += 20f;
							this.Yandere.StainWeapon();
						}
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
						return;
					}
				}
				else if (this.EffectPhase == 1 && this.YandereAnim[this.AnimName].time > 2.83333325f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
					this.EffectPhase++;
					return;
				}
			}
			else if (this.EffectPhase == 0)
			{
				if (this.YandereAnim[this.AnimName].time > 2.16666675f)
				{
					if (!weapon.Blunt)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
					}
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
					this.EffectPhase++;
					return;
				}
			}
			else if (this.EffectPhase == 1 && this.YandereAnim[this.AnimName].time > 4.16666651f)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
				this.EffectPhase++;
				return;
			}
		}
		else if (weapon.Type == WeaponType.Garrote)
		{
			this.Yandere.TargetStudent.Ragdoll.NeckSnapped = true;
			this.Yandere.TargetStudent.NeckSnapped = true;
		}
	}

	private void LoopCheck(WeaponScript weapon)
	{
		if (Input.GetButtonDown("X") && !this.Yandere.Chased && this.Yandere.Chasers == 0)
		{
			if (weapon.Type == WeaponType.Knife)
			{
				if (this.YandereAnim[this.AnimName].time > 3.5333333f && this.YandereAnim[this.AnimName].time < 4.16666651f)
				{
					this.LoopStart = 106f;
					this.LoopEnd = 125f;
					this.LoopPhase = 2;
					this.Loop = true;
				}
			}
			else if (weapon.Type == WeaponType.Katana)
			{
				if (this.YandereAnim[this.AnimName].time > 3.36666656f && this.YandereAnim[this.AnimName].time < 3.9f)
				{
					this.LoopStart = 101f;
					this.LoopEnd = 117f;
					this.LoopPhase = 5;
					this.Loop = true;
				}
			}
			else if (weapon.Type == WeaponType.Bat)
			{
				if (this.YandereAnim[this.AnimName].time > 3.76666665f && this.YandereAnim[this.AnimName].time < 4.4f)
				{
					this.LoopStart = 113f;
					this.LoopEnd = 132f;
					this.LoopPhase = 2;
					this.Loop = true;
				}
			}
			else if (weapon.Type == WeaponType.Saw)
			{
				if (this.YandereAnim[this.AnimName].time > 3.0333333f && this.YandereAnim[this.AnimName].time < 4.5666666f)
				{
					this.LoopStart = 91f;
					this.LoopEnd = 137f;
					this.LoopPhase = 3;
					this.PingPong = true;
				}
			}
			else if (weapon.Type == WeaponType.Weight && this.YandereAnim[this.AnimName].time > 3f && this.YandereAnim[this.AnimName].time < 4.5f)
			{
				this.LoopStart = 90f;
				this.LoopEnd = 135f;
				this.LoopPhase = 1;
				this.Loop = true;
			}
		}
		if (this.PingPong)
		{
			if (this.YandereAnim[this.AnimName].time > this.LoopEnd / 30f)
			{
				weapon.MyAudio.pitch = 1f + UnityEngine.Random.Range(0.1f, -0.1f);
				weapon.MyAudio.time = this.LoopStart / 30f;
				this.VictimAnim[this.VictimAnimName].speed = -1f;
				this.YandereAnim[this.AnimName].speed = -1f;
				this.EffectPhase = this.LoopPhase;
				this.AttackTimer = 0f;
			}
			else if (this.YandereAnim[this.AnimName].time < this.LoopStart / 30f)
			{
				weapon.MyAudio.pitch = 1f + UnityEngine.Random.Range(0.1f, -0.1f);
				weapon.MyAudio.time = this.LoopStart / 30f;
				this.VictimAnim[this.VictimAnimName].speed = 1f;
				this.YandereAnim[this.AnimName].speed = 1f;
				this.EffectPhase = this.LoopPhase;
				this.AttackTimer = this.LoopStart / 30f;
				this.EffectPhase = this.LoopPhase;
				this.PingPong = false;
			}
		}
		if (this.Loop && this.YandereAnim[this.AnimName].time > this.LoopEnd / 30f)
		{
			weapon.MyAudio.pitch = 1f + UnityEngine.Random.Range(0.1f, -0.1f);
			weapon.MyAudio.time = this.LoopStart / 30f;
			this.VictimAnim[this.VictimAnimName].time = this.LoopStart / 30f;
			this.YandereAnim[this.AnimName].time = this.LoopStart / 30f;
			this.AttackTimer = this.LoopStart / 30f;
			this.EffectPhase = this.LoopPhase;
			this.Loop = false;
		}
	}

	private void CheckForSpecialCase(WeaponScript weapon)
	{
		if (weapon.WeaponID == 8 && GameGlobals.Paranormal)
		{
			this.Yandere.TargetStudent.Ragdoll.Sacrifice = true;
			weapon.Effect();
		}
	}
}
