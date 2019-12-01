using System;
using UnityEngine;

public class FanCoverScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public StudentScript Rival;

	public SM_rotateThis Fan;

	public ParticleSystem BloodEffects;

	public Projector BloodProjector;

	public Rigidbody MyRigidbody;

	public Transform MurderSpot;

	public GameObject Explosion;

	public GameObject OfferHelp;

	public GameObject Smoke;

	public AudioClip RivalReaction;

	public AudioSource FanSFX;

	public Texture[] YandereBloodTextures;

	public Texture[] BloodTexture;

	public bool Reacted;

	public float Timer;

	public int RivalID = 11;

	public int Phase;

	private void Start()
	{
		if (this.StudentManager.Students[this.RivalID] == null)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
		else
		{
			this.Rival = this.StudentManager.Students[this.RivalID];
		}
	}

	private void Update()
	{
		if (Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 2f)
		{
			if (this.Yandere.Armed)
			{
				this.Prompt.HideButton[0] = (this.Yandere.EquippedWeapon.WeaponID != 6 || !this.Rival.Meeting);
			}
			else
			{
				this.Prompt.HideButton[0] = true;
			}
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.CharacterAnimation.CrossFade("f02_fanMurderA_00");
			this.Rival.CharacterAnimation.CrossFade("f02_fanMurderB_00");
			this.Rival.OsanaHair.GetComponent<Animation>().CrossFade("fanMurderHair");
			this.Yandere.EmptyHands();
			this.Rival.OsanaHair.transform.parent = this.Rival.transform;
			this.Rival.OsanaHair.transform.localEulerAngles = Vector3.zero;
			this.Rival.OsanaHair.transform.localPosition = Vector3.zero;
			this.Rival.OsanaHair.transform.localScale = new Vector3(1f, 1f, 1f);
			this.Rival.OsanaHairL.enabled = false;
			this.Rival.OsanaHairR.enabled = false;
			this.Rival.Distracted = true;
			this.Yandere.CanMove = false;
			this.Rival.Meeting = false;
			this.FanSFX.enabled = false;
			base.GetComponent<AudioSource>().Play();
			base.transform.localPosition = new Vector3(-1.733f, 0.465f, 0.952f);
			base.transform.localEulerAngles = new Vector3(-90f, 165f, 0f);
			Physics.SyncTransforms();
			Rigidbody component = base.GetComponent<Rigidbody>();
			component.isKinematic = false;
			component.useGravity = true;
			this.Prompt.enabled = false;
			this.Prompt.Hide();
			this.Phase++;
		}
		if (this.Phase > 0)
		{
			if (this.Phase == 1)
			{
				this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.MurderSpot.rotation, Time.deltaTime * 10f);
				this.Yandere.MoveTowardsTarget(this.MurderSpot.position);
				if (this.Yandere.CharacterAnimation["f02_fanMurderA_00"].time > 3.5f && !this.Reacted)
				{
					AudioSource.PlayClipAtPoint(this.RivalReaction, this.Rival.transform.position + new Vector3(0f, 1f, 0f));
					this.Yandere.MurderousActionTimer = this.Yandere.CharacterAnimation["f02_fanMurderA_00"].length - 3.5f;
					this.Reacted = true;
				}
				if (this.Yandere.CharacterAnimation["f02_fanMurderA_00"].time > 5f)
				{
					this.Rival.LiquidProjector.material.mainTexture = this.Rival.BloodTexture;
					this.Rival.LiquidProjector.enabled = true;
					this.Rival.EyeShrink = 1f;
					this.Yandere.BloodTextures = this.YandereBloodTextures;
					this.Yandere.Bloodiness += 20f;
					this.BloodProjector.gameObject.SetActive(true);
					this.BloodProjector.material.mainTexture = this.BloodTexture[1];
					this.BloodEffects.transform.parent = this.Rival.Head;
					this.BloodEffects.transform.localPosition = new Vector3(0f, 0.1f, 0f);
					this.BloodEffects.Play();
					this.Phase++;
				}
			}
			else if (this.Phase < 10)
			{
				if (this.Phase < 6)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 1f)
					{
						this.Phase++;
						if (this.Phase - 1 < 5)
						{
							this.BloodProjector.material.mainTexture = this.BloodTexture[this.Phase - 1];
							this.Yandere.Bloodiness += 20f;
							this.Timer = 0f;
						}
					}
				}
				if (this.Rival.CharacterAnimation["f02_fanMurderB_00"].time >= this.Rival.CharacterAnimation["f02_fanMurderB_00"].length)
				{
					this.BloodProjector.material.mainTexture = this.BloodTexture[5];
					this.Yandere.Bloodiness += 20f;
					this.Rival.Ragdoll.Decapitated = true;
					this.Rival.OsanaHair.SetActive(false);
					this.Rival.DeathType = DeathType.Weapon;
					this.Rival.BecomeRagdoll();
					this.BloodEffects.Stop();
					this.Explosion.SetActive(true);
					this.Smoke.SetActive(true);
					this.Fan.enabled = false;
					this.Phase = 10;
				}
			}
			else if (this.Yandere.CharacterAnimation["f02_fanMurderA_00"].time >= this.Yandere.CharacterAnimation["f02_fanMurderA_00"].length)
			{
				this.OfferHelp.SetActive(false);
				this.Yandere.CanMove = true;
				base.enabled = false;
			}
		}
	}
}
