using System;
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

	public bool Loop;

	public int EffectPhase;

	public int LoopPhase;

	public float AttackTimer;

	public float Distance;

	public float Timer;

	public float LoopStart;

	public float LoopEnd;

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
		else
		{
			if (weaponType == WeaponType.Katana)
			{
				return (!this.Stealth) ? 1f : 0.5f;
			}
			if (weaponType == WeaponType.Bat)
			{
				if (this.Stealth)
				{
					return 0.5f;
				}
				if (sanityType == SanityType.High)
				{
					return 0.75f;
				}
				if (sanityType == SanityType.Medium)
				{
					return 1f;
				}
				return 1f;
			}
			else
			{
				if (weaponType == WeaponType.Saw)
				{
					return (!this.Stealth) ? 1f : 0.7f;
				}
				if (weaponType == WeaponType.Syringe)
				{
					return 0.5f;
				}
				Debug.LogError("Weapon type \"" + weaponType.ToString() + "\" not implemented.");
				return 0f;
			}
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
		string typePrefix = weapon.GetTypePrefix();
		string str = (!this.Yandere.TargetStudent.Male) ? "f02_" : string.Empty;
		if (!this.Stealth)
		{
			this.AnimName = "f02_" + typePrefix + sanityString + "SanityA_00";
			this.VictimAnimName = str + typePrefix + sanityString + "SanityB_00";
		}
		else
		{
			this.AnimName = "f02_" + typePrefix + "StealthA_00";
			this.VictimAnimName = str + typePrefix + "StealthB_00";
		}
		Animation component = this.Yandere.Character.GetComponent<Animation>();
		component[this.AnimName].time = 0f;
		component.CrossFade(this.AnimName);
		Animation component2 = this.Victim.GetComponent<Animation>();
		component2[this.VictimAnimName].time = 0f;
		component2.CrossFade(this.VictimAnimName);
		AudioSource component3 = weapon.gameObject.GetComponent<AudioSource>();
		component3.clip = weapon.GetClip(this.Yandere.Sanity / 100f, this.Stealth);
		component3.time = 0f;
		component3.Play();
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
			this.AttackTimer += Time.deltaTime;
			WeaponScript equippedWeapon = this.Yandere.EquippedWeapon;
			SanityType sanityType = this.Yandere.SanityType;
			this.SpecialEffect(equippedWeapon, sanityType);
			if (sanityType == SanityType.Low)
			{
				this.LoopCheck(equippedWeapon);
			}
			this.SpecialEffect(equippedWeapon, sanityType);
			Animation component = this.Yandere.Character.GetComponent<Animation>();
			if (component[this.AnimName].time > component[this.AnimName].length - 0.333333343f)
			{
				component.CrossFade("f02_idle_00");
				equippedWeapon.Flip = false;
			}
			if (this.AttackTimer > component[this.AnimName].length)
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
					this.Yandere.CanTranq = false;
					this.Yandere.Followers--;
					equippedWeapon.Type = WeaponType.Knife;
				}
				this.Yandere.TargetStudent.DeathCause = equippedWeapon.WeaponID;
				this.Yandere.TargetStudent.BecomeRagdoll();
				this.Yandere.Sanity -= ((PlayerGlobals.PantiesEquipped != 10) ? 20f : 10f) * this.Yandere.Numbness;
				this.Yandere.Attacking = false;
				this.Yandere.FollowHips = false;
				this.Yandere.MyController.radius = 0.2f;
				bool flag = false;
				if (this.Yandere.EquippedWeapon.Type == WeaponType.Bat && this.Stealth)
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
				if (!this.Yandere.Noticed)
				{
					Debug.Log("Finished attacking.");
					this.Yandere.EquippedWeapon.MurderWeapon = true;
					this.Yandere.CanMove = true;
				}
				else
				{
					equippedWeapon.Drop();
				}
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
		Animation component = this.Yandere.Character.GetComponent<Animation>();
		if (weapon.Type == WeaponType.Knife)
		{
			if (!this.Stealth)
			{
				if (sanityType == SanityType.High)
				{
					if (this.EffectPhase == 0 && component[this.AnimName].time > 1.06666672f)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (sanityType == SanityType.Medium)
				{
					if (this.EffectPhase == 0)
					{
						if (component[this.AnimName].time > 2.16666675f)
						{
							this.Yandere.Bloodiness += 20f;
							this.Yandere.StainWeapon();
							UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 1 && component[this.AnimName].time > 3.0333333f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 0)
				{
					if (component[this.AnimName].time > 2.76666665f)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 1)
				{
					if (component[this.AnimName].time > 3.5333333f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 2 && component[this.AnimName].time > 4.16666651f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
					this.EffectPhase++;
				}
			}
			else if (this.EffectPhase == 0 && component[this.AnimName].time > 0.966666639f)
			{
				this.Yandere.Bloodiness += 20f;
				this.Yandere.StainWeapon();
				UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
				this.EffectPhase++;
			}
		}
		else if (weapon.Type == WeaponType.Katana)
		{
			if (!this.Stealth)
			{
				if (sanityType == SanityType.High)
				{
					if (this.EffectPhase == 0 && component[this.AnimName].time > 0.483333319f)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (sanityType == SanityType.Medium)
				{
					if (this.EffectPhase == 0)
					{
						if (component[this.AnimName].time > 0.55f)
						{
							this.Yandere.Bloodiness += 20f;
							this.Yandere.StainWeapon();
							UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 1 && component[this.AnimName].time > 1.51666665f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 0)
				{
					if (component[this.AnimName].time > 0.5f)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 1)
				{
					if (component[this.AnimName].time > 1f)
					{
						weapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 2)
				{
					if (component[this.AnimName].time > 2.33333325f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 3)
				{
					if (component[this.AnimName].time > 2.73333335f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 4)
				{
					if (component[this.AnimName].time > 3.13333344f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 5)
				{
					if (component[this.AnimName].time > 3.5333333f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 6)
				{
					if (component[this.AnimName].time > 4.133333f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 8 && component[this.AnimName].time > 5f)
				{
					weapon.transform.localEulerAngles = Vector3.zero;
					this.EffectPhase++;
				}
			}
			else if (this.EffectPhase == 0)
			{
				if (component[this.AnimName].time > 0.366666675f)
				{
					this.Yandere.Bloodiness += 20f;
					this.Yandere.StainWeapon();
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
					this.EffectPhase++;
				}
			}
			else if (this.EffectPhase == 1 && component[this.AnimName].time > 1f)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.333333343f, Quaternion.identity);
				this.EffectPhase++;
			}
		}
		else if (weapon.Type == WeaponType.Bat)
		{
			if (!this.Stealth)
			{
				if (sanityType == SanityType.High)
				{
					if (this.EffectPhase == 0 && component[this.AnimName].time > 0.733333349f)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (sanityType == SanityType.Medium)
				{
					if (this.EffectPhase == 0)
					{
						if (component[this.AnimName].time > 1f)
						{
							this.Yandere.Bloodiness += 20f;
							this.Yandere.StainWeapon();
							UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 1 && component[this.AnimName].time > 2.9666667f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 0)
				{
					if (component[this.AnimName].time > 0.7f)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 1)
				{
					if (component[this.AnimName].time > 3.1f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 2)
				{
					if (component[this.AnimName].time > 3.76666665f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 3 && component[this.AnimName].time > 4.4f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
					this.EffectPhase++;
				}
			}
			else
			{
				this.Yandere.TargetStudent.Ragdoll.NeckSnapped = true;
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
						if (component[this.AnimName].time > 0f)
						{
							weapon.Spin = true;
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 1)
					{
						if (component[this.AnimName].time > 0.733333349f)
						{
							this.Yandere.Bloodiness += 20f;
							this.Yandere.StainWeapon();
							weapon.BloodSpray[0].Play();
							weapon.BloodSpray[1].Play();
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 2 && component[this.AnimName].time > 1.43333328f)
					{
						weapon.Spin = false;
						weapon.BloodSpray[0].Stop();
						weapon.BloodSpray[1].Stop();
						this.EffectPhase++;
					}
				}
				else if (sanityType == SanityType.Medium)
				{
					if (this.EffectPhase == 0)
					{
						if (component[this.AnimName].time > 0f)
						{
							weapon.Spin = true;
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 1)
					{
						if (component[this.AnimName].time > 1.1f)
						{
							this.Yandere.Bloodiness += 20f;
							this.Yandere.StainWeapon();
							weapon.BloodSpray[0].Play();
							weapon.BloodSpray[1].Play();
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 2)
					{
						if (component[this.AnimName].time > 1.43333328f)
						{
							weapon.BloodSpray[0].Stop();
							weapon.BloodSpray[1].Stop();
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 3)
					{
						if (component[this.AnimName].time > 2.36666656f)
						{
							weapon.BloodSpray[0].Play();
							weapon.BloodSpray[1].Play();
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 4 && component[this.AnimName].time > 2.4f)
					{
						weapon.Spin = true;
						weapon.BloodSpray[0].Stop();
						weapon.BloodSpray[1].Stop();
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 0)
				{
					if (component[this.AnimName].time > 0f)
					{
						weapon.Spin = true;
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 1)
				{
					if (component[this.AnimName].time > 0.6666667f)
					{
						this.Yandere.Bloodiness += 20f;
						this.Yandere.StainWeapon();
						weapon.BloodSpray[0].Play();
						weapon.BloodSpray[1].Play();
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 2)
				{
					if (component[this.AnimName].time > 0.733333349f)
					{
						weapon.BloodSpray[0].Stop();
						weapon.BloodSpray[1].Stop();
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 3)
				{
					if (component[this.AnimName].time > 3f)
					{
						weapon.BloodSpray[0].Play();
						weapon.BloodSpray[1].Play();
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 4 && component[this.AnimName].time > 4.866667f)
				{
					weapon.Spin = false;
					weapon.BloodSpray[0].Stop();
					weapon.BloodSpray[1].Stop();
					this.EffectPhase++;
				}
			}
			else if (this.EffectPhase == 0 && component[this.AnimName].time > 1f)
			{
				this.Yandere.Bloodiness += 20f;
				this.Yandere.StainWeapon();
				UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.right * 0.2f + weapon.transform.forward * -0.06666667f, Quaternion.identity);
				this.EffectPhase++;
			}
		}
	}

	private void LoopCheck(WeaponScript weapon)
	{
		Animation component = this.Yandere.Character.GetComponent<Animation>();
		if (Input.GetButtonDown("X") && !this.Yandere.Chased)
		{
			if (weapon.Type == WeaponType.Knife)
			{
				if (component[this.AnimName].time > 3.5333333f && component[this.AnimName].time < 4.16666651f)
				{
					this.LoopStart = 106f;
					this.LoopEnd = 125f;
					this.LoopPhase = 2;
					this.Loop = true;
				}
			}
			else if (weapon.Type == WeaponType.Katana)
			{
				if (component[this.AnimName].time > 3.36666656f && component[this.AnimName].time < 3.9f)
				{
					this.LoopStart = 101f;
					this.LoopEnd = 117f;
					this.LoopPhase = 5;
					this.Loop = true;
				}
			}
			else if (weapon.Type == WeaponType.Bat)
			{
				if (component[this.AnimName].time > 3.76666665f && component[this.AnimName].time < 4.4f)
				{
					this.LoopStart = 113f;
					this.LoopEnd = 132f;
					this.LoopPhase = 2;
					this.Loop = true;
				}
			}
			else if (weapon.Type == WeaponType.Saw && component[this.AnimName].time > 3.0333333f && component[this.AnimName].time < 4.5666666f)
			{
				this.LoopStart = 91f;
				this.LoopEnd = 137f;
				this.LoopPhase = 3;
				this.PingPong = true;
			}
		}
		AudioSource component2 = weapon.gameObject.GetComponent<AudioSource>();
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

	private void CheckForSpecialCase(WeaponScript weapon)
	{
		if (weapon.WeaponID == 8)
		{
			this.Yandere.TargetStudent.Ragdoll.Sacrifice = true;
			if (GameGlobals.Paranormal)
			{
				weapon.Effect();
			}
		}
	}
}
