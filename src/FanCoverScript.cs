using System;
using UnityEngine;

[Serializable]
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

	public int Phase;

	public virtual void Start()
	{
		if (this.StudentManager.Students[33] == null)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.enabled = false;
		}
		else
		{
			this.Rival = this.StudentManager.Students[33];
		}
	}

	public virtual void Update()
	{
		if (Vector3.Distance(this.transform.position, this.Yandere.transform.position) < (float)2)
		{
			if (this.Yandere.Armed)
			{
				if (this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 6 && this.Rival.Meeting)
				{
					this.Prompt.HideButton[0] = false;
				}
				else
				{
					this.Prompt.HideButton[0] = true;
				}
			}
			else
			{
				this.Prompt.HideButton[0] = true;
			}
		}
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Yandere.CharacterAnimation.CrossFade("f02_fanMurderA_00");
			this.Rival.CharacterAnimation.CrossFade("f02_fanMurderB_00");
			this.Rival.OsanaHair.animation.CrossFade("fanMurderHair");
			this.Yandere.EmptyHands();
			this.Rival.OsanaHair.transform.parent = this.Rival.transform;
			this.Rival.OsanaHair.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
			this.Rival.OsanaHair.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
			this.Rival.OsanaHair.transform.localScale = new Vector3((float)1, (float)1, (float)1);
			this.Rival.OsanaHairL.enabled = false;
			this.Rival.OsanaHairR.enabled = false;
			this.Rival.Distracted = true;
			this.Yandere.CanMove = false;
			this.Rival.Meeting = false;
			this.FanSFX.enabled = false;
			this.audio.Play();
			float z = this.transform.localEulerAngles.z + (float)15;
			Vector3 localEulerAngles = this.transform.localEulerAngles;
			float num = localEulerAngles.z = z;
			Vector3 vector = this.transform.localEulerAngles = localEulerAngles;
			this.rigidbody.isKinematic = false;
			this.rigidbody.useGravity = true;
			this.Prompt.enabled = false;
			this.Prompt.Hide();
			this.Phase++;
		}
		if (this.Phase > 0)
		{
			if (this.Phase == 1)
			{
				this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.MurderSpot.rotation, Time.deltaTime * (float)10);
				this.Yandere.MoveTowardsTarget(this.MurderSpot.position);
				if (this.Yandere.CharacterAnimation["f02_fanMurderA_00"].time > 3.5f && !this.Reacted)
				{
					AudioSource.PlayClipAtPoint(this.RivalReaction, new Vector3((float)0, (float)0, (float)0));
					this.Reacted = true;
				}
				if (this.Yandere.CharacterAnimation["f02_fanMurderA_00"].time > (float)5)
				{
					this.Rival.LiquidProjector.material.mainTexture = this.Rival.BloodTexture;
					this.Rival.LiquidProjector.enabled = true;
					this.Rival.EyeShrink = (float)1;
					this.Yandere.BloodTextures = this.YandereBloodTextures;
					this.Yandere.Bloodiness = this.Yandere.Bloodiness + (float)20;
					this.Yandere.UpdateBlood();
					this.BloodProjector.active = true;
					this.BloodProjector.material.mainTexture = this.BloodTexture[1];
					this.BloodEffects.transform.parent = this.Rival.Head;
					this.BloodEffects.transform.localPosition = new Vector3((float)0, 0.1f, (float)0);
					this.BloodEffects.Play();
					this.Phase++;
				}
			}
			else if (this.Phase < 10)
			{
				if (this.Phase < 6)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > (float)1)
					{
						this.Phase++;
						if (this.Phase - 1 < 5)
						{
							this.BloodProjector.material.mainTexture = this.BloodTexture[this.Phase - 1];
							this.Yandere.Bloodiness = this.Yandere.Bloodiness + (float)20;
							this.Yandere.UpdateBlood();
							this.Timer = (float)0;
						}
					}
				}
				if (this.Rival.CharacterAnimation["f02_fanMurderB_00"].time >= this.Rival.CharacterAnimation["f02_fanMurderB_00"].length)
				{
					this.BloodProjector.material.mainTexture = this.BloodTexture[5];
					this.Yandere.Bloodiness = this.Yandere.Bloodiness + (float)20;
					this.Yandere.UpdateBlood();
					this.Rival.Ragdoll.Decapitated = true;
					this.Rival.OsanaHair.active = false;
					this.Rival.Dead = true;
					this.Rival.BecomeRagdoll();
					this.BloodEffects.Stop();
					this.Explosion.active = true;
					this.Smoke.active = true;
					this.Fan.enabled = false;
					this.Phase = 10;
				}
			}
			else if (this.Yandere.CharacterAnimation["f02_fanMurderA_00"].time >= this.Yandere.CharacterAnimation["f02_fanMurderA_00"].length)
			{
				this.OfferHelp.active = false;
				this.Yandere.CanMove = true;
				this.enabled = false;
			}
		}
	}

	public virtual void Main()
	{
	}
}
