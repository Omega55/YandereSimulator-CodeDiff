using System;
using UnityEngine;

public class HeadmasterScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public HeartbrokenScript Heartbroken;

	public YandereScript Yandere;

	public JukeboxScript Jukebox;

	public AudioClip[] HeadmasterSpeechClips;

	public AudioClip[] HeadmasterThreatClips;

	public AudioClip[] HeadmasterBoxClips;

	public AudioClip HeadmasterRelaxClip;

	public AudioClip HeadmasterAttackClip;

	public AudioClip HeadmasterCrypticClip;

	public AudioClip HeadmasterShockClip;

	public AudioClip HeadmasterPatienceClip;

	public AudioClip HeadmasterCorpseClip;

	public AudioClip HeadmasterWeaponClip;

	public AudioClip Crumple;

	public AudioClip StandUp;

	public AudioClip SitDown;

	public readonly string[] HeadmasterSpeechText = new string[]
	{
		string.Empty,
		"Ahh...! It's...it's you!",
		"No, that would be impossible...you must be...her daughter...",
		"I'll tolerate you in my school, but not in my office.",
		"Leave at once.",
		"There is nothing for you to achieve here. Just. Get. Out."
	};

	public readonly string[] HeadmasterThreatText = new string[]
	{
		string.Empty,
		"Not another step!",
		"You're up to no good! I know it!",
		"I'm not going to let you harm me!",
		"I'll use self-defense if I deem it necessary!",
		"This is your final warning. Get out of here...or else."
	};

	public readonly string[] HeadmasterBoxText = new string[]
	{
		string.Empty,
		"What...in...blazes are you doing?",
		"Are you trying to re-enact something you saw in a video game?",
		"Ugh, do you really think such a stupid ploy is going to work?",
		"I know who you are. It's obvious. You're not fooling anyone.",
		"I don't have time for this tomfoolery. Leave at once!"
	};

	public readonly string HeadmasterRelaxText = "Hmm...a wise decision.";

	public readonly string HeadmasterAttackText = "You asked for it!";

	public readonly string HeadmasterCrypticText = "Mr. Saikou...the deal is off.";

	public readonly string HeadmasterWeaponText = "How dare you raise a weapon in my office!";

	public readonly string HeadmasterPatienceText = "Enough of this nonsense!";

	public readonly string HeadmasterCorpseText = "You...you murderer!";

	public UILabel HeadmasterSubtitle;

	public Animation MyAnimation;

	public AudioSource MyAudio;

	public GameObject LightningEffect;

	public GameObject Tazer;

	public Transform TazerEffectTarget;

	public Transform CardboardBox;

	public Transform Chair;

	public Quaternion targetRotation;

	public float PatienceTimer;

	public float ScratchTimer;

	public float SpeechTimer;

	public float ThreatTimer;

	public float Distance;

	public int Patience = 10;

	public int ThreatID;

	public int VoiceID;

	public int BoxID;

	public bool PlayedStandSound;

	public bool PlayedSitSound;

	public bool LostPatience;

	public bool Threatened;

	public bool Relaxing;

	public bool Shooting;

	public bool Aiming;

	public Vector3 LookAtTarget;

	public bool LookAtPlayer;

	public Transform Default;

	public Transform Head;

	private void Start()
	{
		this.MyAnimation["HeadmasterRaiseTazer"].speed = 2f;
		this.Tazer.SetActive(false);
	}

	private void Update()
	{
		if (this.Yandere.transform.position.y > base.transform.position.y - 1f && this.Yandere.transform.position.y < base.transform.position.y + 1f && this.Yandere.transform.position.x < 6f && this.Yandere.transform.position.x > -6f)
		{
			this.Distance = Vector3.Distance(base.transform.position, this.Yandere.transform.position);
			if (this.Shooting)
			{
				this.targetRotation = Quaternion.LookRotation(base.transform.position - this.Yandere.transform.position);
				this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.AimWeaponAtYandere();
				this.AimBodyAtYandere();
			}
			else if ((double)this.Distance < 1.2)
			{
				this.AimBodyAtYandere();
				if (this.Yandere.CanMove && !this.Shooting)
				{
					this.Shoot();
				}
			}
			else if ((double)this.Distance < 2.8)
			{
				this.PlayedSitSound = false;
				this.PatienceTimer -= Time.deltaTime;
				if (this.PatienceTimer < 0f)
				{
					this.LostPatience = true;
					this.PatienceTimer = 60f;
					this.Patience = 0;
					this.Shoot();
				}
				if (!this.LostPatience)
				{
					this.LostPatience = true;
					this.Patience--;
					if (this.Patience < 1 && !this.Shooting)
					{
						this.Shoot();
					}
				}
				this.AimBodyAtYandere();
				this.Threatened = true;
				this.AimWeaponAtYandere();
				this.ThreatTimer = Mathf.MoveTowards(this.ThreatTimer, 0f, Time.deltaTime);
				if (this.ThreatTimer == 0f)
				{
					this.ThreatID++;
					if (this.ThreatID < 5)
					{
						this.HeadmasterSubtitle.text = this.HeadmasterThreatText[this.ThreatID];
						this.MyAudio.clip = this.HeadmasterThreatClips[this.ThreatID];
						this.MyAudio.Play();
						this.ThreatTimer = this.HeadmasterThreatClips[this.ThreatID].length + 1f;
					}
				}
				this.CheckBehavior();
			}
			else if (this.Distance < 10f)
			{
				this.PlayedStandSound = false;
				this.LostPatience = false;
				this.targetRotation = Quaternion.LookRotation(new Vector3(0f, 8f, 0f) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.Chair.localPosition = Vector3.Lerp(this.Chair.localPosition, new Vector3(this.Chair.localPosition.x, this.Chair.localPosition.y, -4.66666f), Time.deltaTime * 1f);
				this.LookAtPlayer = true;
				if (!this.Threatened)
				{
					this.MyAnimation.CrossFade("HeadmasterAttention", 1f);
					this.ScratchTimer = 0f;
					this.SpeechTimer = Mathf.MoveTowards(this.SpeechTimer, 0f, Time.deltaTime);
					if (this.SpeechTimer == 0f)
					{
						if (this.CardboardBox.parent == null && this.Yandere.Mask == null)
						{
							this.VoiceID++;
							if (this.VoiceID < 6)
							{
								this.HeadmasterSubtitle.text = this.HeadmasterSpeechText[this.VoiceID];
								this.MyAudio.clip = this.HeadmasterSpeechClips[this.VoiceID];
								this.MyAudio.Play();
								this.SpeechTimer = this.HeadmasterSpeechClips[this.VoiceID].length + 1f;
							}
						}
						else
						{
							this.BoxID++;
							if (this.BoxID < 6)
							{
								this.HeadmasterSubtitle.text = this.HeadmasterBoxText[this.BoxID];
								this.MyAudio.clip = this.HeadmasterBoxClips[this.BoxID];
								this.MyAudio.Play();
								this.SpeechTimer = this.HeadmasterBoxClips[this.BoxID].length + 1f;
							}
						}
					}
				}
				else if (!this.Relaxing)
				{
					this.HeadmasterSubtitle.text = this.HeadmasterRelaxText;
					this.MyAudio.clip = this.HeadmasterRelaxClip;
					this.MyAudio.Play();
					this.Relaxing = true;
				}
				else
				{
					if (!this.PlayedSitSound)
					{
						AudioSource.PlayClipAtPoint(this.SitDown, base.transform.position);
						this.PlayedSitSound = true;
					}
					this.MyAnimation.CrossFade("HeadmasterLowerTazer");
					this.Aiming = false;
					if ((double)this.MyAnimation["HeadmasterLowerTazer"].time > 1.33333)
					{
						this.Tazer.SetActive(false);
					}
					if (this.MyAnimation["HeadmasterLowerTazer"].time > this.MyAnimation["HeadmasterLowerTazer"].length)
					{
						this.Threatened = false;
						this.Relaxing = false;
					}
				}
				this.CheckBehavior();
			}
			else
			{
				if (this.LookAtPlayer)
				{
					this.MyAnimation.CrossFade("HeadmasterType");
					this.LookAtPlayer = false;
					this.Threatened = false;
					this.Relaxing = false;
					this.Aiming = false;
				}
				this.ScratchTimer += Time.deltaTime;
				if (this.ScratchTimer > 10f)
				{
					this.MyAnimation.CrossFade("HeadmasterScratch");
					if (this.MyAnimation["HeadmasterScratch"].time > this.MyAnimation["HeadmasterScratch"].length)
					{
						this.MyAnimation.CrossFade("HeadmasterType");
						this.ScratchTimer = 0f;
					}
				}
			}
			if (!this.MyAudio.isPlaying)
			{
				this.HeadmasterSubtitle.text = string.Empty;
				if (this.Shooting)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.LightningEffect, this.TazerEffectTarget.position, Quaternion.identity);
					UnityEngine.Object.Instantiate<GameObject>(this.LightningEffect, this.Yandere.Spine[3].position, Quaternion.identity);
					this.MyAudio.clip = this.HeadmasterShockClip;
					this.MyAudio.Play();
					this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_swingB_00");
					this.Yandere.Character.GetComponent<Animation>()["f02_swingB_00"].time = 0.5f;
					this.Yandere.RPGCamera.enabled = false;
					this.Yandere.Attacked = true;
					this.Heartbroken.Headmaster = true;
					this.Jukebox.Volume = 0f;
					this.Shooting = false;
				}
			}
			if (this.Yandere.Attacked && this.Yandere.Character.GetComponent<Animation>()["f02_swingB_00"].time >= this.Yandere.Character.GetComponent<Animation>()["f02_swingB_00"].length * 0.85f)
			{
				this.MyAudio.clip = this.Crumple;
				this.MyAudio.Play();
				base.enabled = false;
			}
		}
		else
		{
			this.HeadmasterSubtitle.text = string.Empty;
		}
	}

	private void LateUpdate()
	{
		this.LookAtTarget = Vector3.Lerp(this.LookAtTarget, (!this.LookAtPlayer) ? this.Default.position : this.Yandere.Head.position, Time.deltaTime * 1f);
		this.Head.LookAt(this.LookAtTarget);
	}

	private void AimBodyAtYandere()
	{
		this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
		this.Chair.localPosition = Vector3.Lerp(this.Chair.localPosition, new Vector3(this.Chair.localPosition.x, this.Chair.localPosition.y, -5.2f), Time.deltaTime * 1f);
	}

	private void AimWeaponAtYandere()
	{
		if (!this.Aiming)
		{
			this.MyAnimation.CrossFade("HeadmasterRaiseTazer");
			if (!this.PlayedStandSound)
			{
				AudioSource.PlayClipAtPoint(this.StandUp, base.transform.position);
				this.PlayedStandSound = true;
			}
			if ((double)this.MyAnimation["HeadmasterRaiseTazer"].time > 1.166666)
			{
				this.Tazer.SetActive(true);
				this.Aiming = true;
			}
		}
		else if (this.MyAnimation["HeadmasterRaiseTazer"].time > this.MyAnimation["HeadmasterRaiseTazer"].length)
		{
			this.MyAnimation.CrossFade("HeadmasterAimTazer");
		}
	}

	private void Shoot()
	{
		this.Yandere.StopAiming();
		this.Yandere.StopLaughing();
		this.Yandere.CharacterAnimation.CrossFade("f02_readyToFight_00");
		if (this.Patience < 1)
		{
			this.HeadmasterSubtitle.text = this.HeadmasterPatienceText;
			this.MyAudio.clip = this.HeadmasterPatienceClip;
		}
		else if (this.Yandere.Armed)
		{
			this.HeadmasterSubtitle.text = this.HeadmasterWeaponText;
			this.MyAudio.clip = this.HeadmasterWeaponClip;
		}
		else if (this.Yandere.Carrying || this.Yandere.Dragging || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart))
		{
			this.HeadmasterSubtitle.text = this.HeadmasterCorpseText;
			this.MyAudio.clip = this.HeadmasterCorpseClip;
		}
		else
		{
			this.HeadmasterSubtitle.text = this.HeadmasterAttackText;
			this.MyAudio.clip = this.HeadmasterAttackClip;
		}
		this.StudentManager.StopMoving();
		this.Yandere.EmptyHands();
		this.Yandere.CanMove = false;
		this.MyAudio.Play();
		this.Shooting = true;
	}

	private void CheckBehavior()
	{
		if (this.Yandere.CanMove)
		{
			if (this.Yandere.Chased)
			{
				if (!this.Shooting)
				{
					this.Shoot();
				}
			}
			else if (this.Yandere.Armed)
			{
				if (!this.Shooting)
				{
					this.Shoot();
				}
			}
			else if ((this.Yandere.Carrying || this.Yandere.Dragging || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart)) && !this.Shooting)
			{
				this.Shoot();
			}
		}
	}
}
