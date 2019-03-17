using System;
using UnityEngine;

public class MetalDetectorScript : MonoBehaviour
{
	public MissionModeScript MissionMode;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public ParticleSystem PepperSprayEffect;

	public AudioSource MyAudio;

	public AudioClip PepperSpraySFX;

	public AudioClip Alarm;

	public Collider MyCollider;

	public float SprayTimer;

	public bool Spraying;

	private void Start()
	{
		this.MyAudio = base.GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (this.Yandere.Armed)
		{
			if (this.Yandere.EquippedWeapon.WeaponID == 6)
			{
				this.Prompt.enabled = true;
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					this.MyAudio.Play();
					this.MyCollider.enabled = false;
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					base.enabled = false;
				}
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Spraying)
		{
			this.SprayTimer += Time.deltaTime;
			if ((double)this.SprayTimer > 0.66666)
			{
				if (this.Yandere.Armed)
				{
					this.Yandere.EquippedWeapon.Drop();
				}
				this.Yandere.EmptyHands();
				this.PepperSprayEffect.Play();
				this.Spraying = false;
			}
		}
		this.MyAudio.volume -= Time.deltaTime * 0.01f;
	}

	private void OnTriggerStay(Collider other)
	{
		bool flag = false;
		if (this.MissionMode.GameOverID == 0 && other.gameObject.layer == 13)
		{
			for (int i = 1; i < 4; i++)
			{
				WeaponScript weaponScript = this.Yandere.Weapon[i];
				flag |= (weaponScript != null && weaponScript.Metal);
				if (!flag && this.Yandere.Container != null && this.Yandere.Container.Weapon != null)
				{
					weaponScript = this.Yandere.Container.Weapon;
					flag = weaponScript.Metal;
				}
				if (!flag && this.Yandere.PickUp != null && this.Yandere.PickUp.TrashCan != null && this.Yandere.PickUp.TrashCan.Weapon)
				{
					weaponScript = this.Yandere.PickUp.TrashCan.Item.GetComponent<WeaponScript>();
					flag = weaponScript.Metal;
				}
			}
			if (flag && !this.Yandere.Inventory.IDCard)
			{
				if (this.MissionMode.enabled)
				{
					this.MissionMode.GameOverID = 16;
					this.MissionMode.GameOver();
					this.MissionMode.Phase = 4;
					base.enabled = false;
				}
				else if (!this.Yandere.Sprayed)
				{
					this.MyAudio.clip = this.Alarm;
					this.MyAudio.loop = true;
					this.MyAudio.Play();
					this.MyAudio.volume = 0.1f;
					AudioSource.PlayClipAtPoint(this.PepperSpraySFX, base.transform.position);
					if (this.Yandere.Aiming)
					{
						this.Yandere.StopAiming();
					}
					this.PepperSprayEffect.transform.position = new Vector3(base.transform.position.x, this.Yandere.transform.position.y + 1.8f, this.Yandere.transform.position.z);
					this.Spraying = true;
					this.Yandere.CharacterAnimation.CrossFade("f02_sprayed_00");
					this.Yandere.FollowHips = true;
					this.Yandere.Punching = false;
					this.Yandere.CanMove = false;
					this.Yandere.Sprayed = true;
					this.Yandere.StudentManager.YandereDying = true;
					this.Yandere.StudentManager.StopMoving();
					this.Yandere.Blur.blurIterations = 1;
					this.Yandere.Jukebox.Volume = 0f;
					Time.timeScale = 1f;
				}
			}
		}
	}
}
