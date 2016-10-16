using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class DelinquentScript : MonoBehaviour
{
	private Quaternion targetRotation;

	public DelinquentManagerScript DelinquentManager;

	public YandereScript Yandere;

	public Quaternion OriginalRotation;

	public Vector3 LookAtTarget;

	public GameObject Character;

	public Renderer MyRenderer;

	public GameObject Jukebox;

	public Mesh LongSkirt;

	public Camera Eyes;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform Default;

	public Transform Weapon;

	public Transform Neck;

	public Transform Head;

	public Plane[] Planes;

	public string CooldownAnim;

	public string ThreatenAnim;

	public string SurpriseAnim;

	public string ShoveAnim;

	public string SwingAnim;

	public string RunAnim;

	public string IdleAnim;

	public bool ExpressedSurprise;

	public bool LookAtPlayer;

	public bool Threatening;

	public bool Attacking;

	public bool HeadStill;

	public bool Cooldown;

	public bool Shoving;

	public bool Run;

	public float DistanceToPlayer;

	public float RunSpeed;

	public float BustSize;

	public float Rotation;

	public float Timer;

	public int AudioPhase;

	public AudioClip[] ProximityClips;

	public AudioClip[] SurrenderClips;

	public AudioClip[] SurpriseClips;

	public AudioClip[] ThreatenClips;

	public AudioClip[] AggroClips;

	public AudioClip[] ShoveClips;

	public AudioClip[] CaseClips;

	public AudioClip SurpriseClip;

	public AudioClip AttackClip;

	public AudioClip Crumple;

	public AudioClip Strike;

	public DelinquentScript()
	{
		this.CooldownAnim = "f02_idleShort_00";
		this.ThreatenAnim = "f02_threaten_00";
		this.SurpriseAnim = "f02_surprise_00";
		this.ShoveAnim = "f02_shoveB_00";
		this.SwingAnim = "f02_swingA_00";
		this.RunAnim = "f02_spring_00";
		this.IdleAnim = string.Empty;
		this.AudioPhase = 1;
	}

	public virtual void Start()
	{
		this.OriginalRotation = this.transform.rotation;
		this.LookAtTarget = this.Default.position;
		if (this.Weapon != null)
		{
			float y = -0.145f;
			Vector3 localPosition = this.Weapon.localPosition;
			float num = localPosition.y = y;
			Vector3 vector = this.Weapon.localPosition = localPosition;
			this.Rotation = (float)90;
			float rotation = this.Rotation;
			Vector3 localEulerAngles = this.Weapon.localEulerAngles;
			float num2 = localEulerAngles.x = rotation;
			Vector3 vector2 = this.Weapon.localEulerAngles = localEulerAngles;
		}
	}

	public virtual void Update()
	{
		this.DistanceToPlayer = Vector3.Distance(this.transform.position, this.Yandere.transform.position);
		if (this.DistanceToPlayer < (float)7)
		{
			this.Planes = GeometryUtility.CalculateFrustumPlanes(this.Eyes);
			if (GeometryUtility.TestPlanesAABB(this.Planes, this.Yandere.collider.bounds))
			{
				RaycastHit raycastHit = default(RaycastHit);
				if (Physics.Linecast(this.Eyes.transform.position, this.Yandere.transform.position + Vector3.up * (float)1, out raycastHit))
				{
					if (raycastHit.collider.gameObject == this.Yandere.gameObject)
					{
						this.LookAtPlayer = true;
						if (this.Yandere.Armed)
						{
							if (!this.Threatening)
							{
								this.audio.clip = this.SurpriseClips[UnityEngine.Random.Range(0, this.SurpriseClips.Length)];
								this.audio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
								this.audio.Play();
							}
							this.Threatening = true;
							if (this.Cooldown)
							{
								this.Cooldown = false;
								this.Timer = (float)0;
							}
						}
						else
						{
							if (this.Yandere.CorpseWarning)
							{
								if (!this.Threatening)
								{
									this.audio.clip = this.SurpriseClips[UnityEngine.Random.Range(0, this.SurpriseClips.Length)];
									this.audio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
									this.audio.Play();
								}
								this.Threatening = true;
								if (!this.Yandere.Chased)
								{
									this.DelinquentManager.Attacker = this;
									this.Run = true;
								}
								this.Yandere.Chased = true;
							}
							else if (!this.Threatening && this.DelinquentManager.SpeechTimer == (float)0)
							{
								if (this.Yandere.Container == null)
								{
									this.audio.clip = this.ProximityClips[UnityEngine.Random.Range(0, Extensions.get_length(this.ProximityClips))];
								}
								else
								{
									this.audio.clip = this.CaseClips[UnityEngine.Random.Range(0, Extensions.get_length(this.CaseClips))];
								}
								this.audio.Play();
								this.DelinquentManager.SpeechTimer = (float)10;
							}
							this.LookAtPlayer = true;
						}
					}
					else
					{
						this.LookAtPlayer = false;
					}
				}
			}
			else
			{
				this.LookAtPlayer = false;
			}
		}
		if (!this.Threatening)
		{
			if (this.Shoving)
			{
				this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
				this.targetRotation = Quaternion.LookRotation(this.transform.position - this.Yandere.transform.position);
				this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
				if (this.Character.animation[this.ShoveAnim].time >= this.Character.animation[this.ShoveAnim].length)
				{
					this.LookAtTarget = this.Neck.position + this.Neck.forward;
					this.Character.animation.CrossFade(this.IdleAnim, (float)1);
					this.Shoving = false;
				}
				if (this.Weapon != null)
				{
					float y = Mathf.Lerp(this.Weapon.localPosition.y, (float)0, Time.deltaTime * (float)10);
					Vector3 localPosition = this.Weapon.localPosition;
					float num = localPosition.y = y;
					Vector3 vector = this.Weapon.localPosition = localPosition;
					this.Rotation = Mathf.Lerp(this.Rotation, (float)0, Time.deltaTime * (float)10);
					float rotation = this.Rotation;
					Vector3 localEulerAngles = this.Weapon.localEulerAngles;
					float num2 = localEulerAngles.x = rotation;
					Vector3 vector2 = this.Weapon.localEulerAngles = localEulerAngles;
				}
			}
			else
			{
				this.Shove();
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.OriginalRotation, Time.deltaTime);
				if (this.Weapon != null)
				{
					float y2 = Mathf.Lerp(this.Weapon.localPosition.y, -0.145f, Time.deltaTime * (float)10);
					Vector3 localPosition2 = this.Weapon.localPosition;
					float num3 = localPosition2.y = y2;
					Vector3 vector3 = this.Weapon.localPosition = localPosition2;
					this.Rotation = Mathf.Lerp(this.Rotation, (float)90, Time.deltaTime * (float)10);
					float rotation2 = this.Rotation;
					Vector3 localEulerAngles2 = this.Weapon.localEulerAngles;
					float num4 = localEulerAngles2.x = rotation2;
					Vector3 vector4 = this.Weapon.localEulerAngles = localEulerAngles2;
				}
			}
		}
		else
		{
			this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
			if (this.Weapon != null)
			{
				float y3 = Mathf.Lerp(this.Weapon.localPosition.y, (float)0, Time.deltaTime * (float)10);
				Vector3 localPosition3 = this.Weapon.localPosition;
				float num5 = localPosition3.y = y3;
				Vector3 vector5 = this.Weapon.localPosition = localPosition3;
				this.Rotation = Mathf.Lerp(this.Rotation, (float)0, Time.deltaTime * (float)10);
				float rotation3 = this.Rotation;
				Vector3 localEulerAngles3 = this.Weapon.localEulerAngles;
				float num6 = localEulerAngles3.x = rotation3;
				Vector3 vector6 = this.Weapon.localEulerAngles = localEulerAngles3;
			}
			if (this.DistanceToPlayer < (float)1)
			{
				if (this.Yandere.Armed || this.Run)
				{
					if (!this.Yandere.Attacked)
					{
						if (this.Yandere.CanMove && (!this.Yandere.Chased || (this.Yandere.Chased && this.DelinquentManager.Attacker == this)))
						{
							if (!this.DelinquentManager.audio.isPlaying)
							{
								this.DelinquentManager.audio.clip = this.AttackClip;
								this.DelinquentManager.audio.Play();
								this.DelinquentManager.enabled = false;
							}
							if (this.Yandere.Laughing)
							{
								this.Yandere.StopLaughing();
							}
							if (this.Yandere.Aiming)
							{
								this.Yandere.StopAiming();
							}
							this.Character.animation.CrossFade(this.SwingAnim);
							this.Attacking = true;
							this.Yandere.Character.animation.CrossFade("f02_swingB_00");
							this.Yandere.RPGCamera.enabled = false;
							this.Yandere.CanMove = false;
							this.Yandere.Attacked = true;
							this.Yandere.EmptyHands();
						}
					}
					else if (this.Attacking)
					{
						if (this.AudioPhase == 1)
						{
							if (this.Character.animation[this.SwingAnim].time >= this.Character.animation[this.SwingAnim].length * 0.3f)
							{
								this.Jukebox.active = false;
								this.AudioPhase++;
								this.audio.pitch = (float)1;
								this.audio.clip = this.Strike;
								this.audio.Play();
							}
						}
						else if (this.AudioPhase == 2 && this.Character.animation[this.SwingAnim].time >= this.Character.animation[this.SwingAnim].length * 0.85f)
						{
							this.AudioPhase++;
							this.audio.pitch = (float)1;
							this.audio.clip = this.Crumple;
							this.audio.Play();
						}
						this.targetRotation = Quaternion.LookRotation(this.transform.position - this.Yandere.transform.position);
						this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
					}
				}
				else
				{
					this.Shove();
				}
			}
			else if (!this.ExpressedSurprise)
			{
				this.Character.animation.CrossFade(this.SurpriseAnim);
				if (this.Character.animation[this.SurpriseAnim].time >= this.Character.animation[this.SurpriseAnim].length)
				{
					this.ExpressedSurprise = true;
				}
			}
			else if (this.Run)
			{
				if (this.DistanceToPlayer > (float)1)
				{
					this.transform.position = Vector3.MoveTowards(this.transform.position, this.Yandere.transform.position, Time.deltaTime * this.RunSpeed);
					this.Character.animation.CrossFade(this.RunAnim);
					this.RunSpeed += Time.deltaTime;
				}
			}
			else if (!this.Cooldown)
			{
				this.Character.animation.CrossFade(this.ThreatenAnim);
				if (!this.Yandere.Armed)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 2.5f)
					{
						this.Cooldown = true;
						if (!this.DelinquentManager.audio.isPlaying)
						{
							this.DelinquentManager.SpeechTimer = Time.deltaTime;
						}
					}
				}
				else
				{
					this.Timer = (float)0;
					if (this.DelinquentManager.SpeechTimer == (float)0)
					{
						this.DelinquentManager.audio.clip = this.ThreatenClips[UnityEngine.Random.Range(0, Extensions.get_length(this.ThreatenClips))];
						this.DelinquentManager.audio.Play();
						this.DelinquentManager.SpeechTimer = (float)10;
					}
				}
			}
			else
			{
				if (this.DelinquentManager.SpeechTimer == (float)0 && !this.DelinquentManager.audio.isPlaying)
				{
					this.DelinquentManager.audio.clip = this.SurrenderClips[UnityEngine.Random.Range(0, Extensions.get_length(this.SurrenderClips))];
					this.DelinquentManager.audio.Play();
					this.DelinquentManager.SpeechTimer = (float)5;
				}
				this.Character.animation.CrossFade(this.CooldownAnim, 2.5f);
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)5)
				{
					this.Character.animation.CrossFade(this.IdleAnim, (float)1);
					this.ExpressedSurprise = false;
					this.Threatening = false;
					this.Cooldown = false;
					this.Timer = (float)0;
				}
				this.Shove();
			}
		}
		if (Input.GetKeyDown("v") && this.LongSkirt != null)
		{
			RuntimeServices.SetProperty(this.MyRenderer, "sharedMesh", this.LongSkirt);
		}
	}

	public virtual void Shove()
	{
		if (!this.Yandere.Shoved && !this.Yandere.Tripping && this.DistanceToPlayer < 0.5f)
		{
			this.DelinquentManager.audio.clip = this.ShoveClips[UnityEngine.Random.Range(0, Extensions.get_length(this.ShoveClips))];
			this.DelinquentManager.audio.Play();
			this.DelinquentManager.SpeechTimer = (float)5;
			if (this.Yandere.transform.position.x > this.transform.position.x)
			{
				float x = this.transform.position.x - 0.001f;
				Vector3 position = this.Yandere.transform.position;
				float num = position.x = x;
				Vector3 vector = this.Yandere.transform.position = position;
			}
			if (this.Yandere.Aiming)
			{
				this.Yandere.StopAiming();
			}
			this.Character.animation[this.ShoveAnim].time = (float)0;
			this.Character.animation.CrossFade(this.ShoveAnim);
			this.Shoving = true;
			this.Yandere.Character.animation.CrossFade("f02_shoveA_00");
			this.Yandere.CanMove = false;
			this.Yandere.Shoved = true;
			this.ExpressedSurprise = false;
			this.Threatening = false;
			this.Cooldown = false;
			this.Timer = (float)0;
		}
	}

	public virtual void LateUpdate()
	{
		if (!this.Threatening)
		{
			if (!this.Shoving)
			{
				if (!this.LookAtPlayer)
				{
					this.LookAtTarget = Vector3.Lerp(this.LookAtTarget, this.Default.position, Time.deltaTime * (float)2);
				}
				else
				{
					this.LookAtTarget = Vector3.Lerp(this.LookAtTarget, this.Yandere.Head.position, Time.deltaTime * (float)2);
				}
				this.Neck.LookAt(this.LookAtTarget);
			}
			if (this.HeadStill)
			{
				this.Head.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
			}
		}
		if (this.BustSize > (float)0)
		{
			this.RightBreast.localScale = new Vector3(this.BustSize, this.BustSize, this.BustSize);
			this.LeftBreast.localScale = new Vector3(this.BustSize, this.BustSize, this.BustSize);
		}
	}

	public virtual void Main()
	{
	}
}
