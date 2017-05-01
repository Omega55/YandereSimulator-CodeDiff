using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class WeaponScript : MonoBehaviour
{
	public ParticleSystem[] ShortBloodSpray;

	public ParticleSystem[] BloodSpray;

	public OutlineScript[] Outline;

	public float[] SoundTime;

	public IncineratorScript Incinerator;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public AudioClip[] Clips;

	public AudioClip[] Clips2;

	public AudioClip[] Clips3;

	public AudioClip DismemberClip;

	public GameObject FireEffect;

	public Collider MyCollider;

	public Renderer MyRenderer;

	public Transform Blade;

	public Projector Blood;

	public bool DisableCollider;

	public bool Dismembering;

	public bool WeaponEffect;

	public bool Concealable;

	public bool Suspicious;

	public bool Evidence;

	public bool StartLow;

	public bool Flaming;

	public bool Bloody;

	public bool Dumped;

	public bool Heated;

	public bool Metal;

	public bool Flip;

	public bool Spin;

	public Color EvidenceColor;

	public Color OriginalColor;

	public float OriginalOffset;

	public float KinematicTimer;

	public float DumpTimer;

	public float Rotation;

	public float Speed;

	public string SpriteName;

	public string Name;

	public int DismemberPhase;

	public int FingerprintID;

	public int WeaponID;

	public int AnimID;

	public int Type;

	public bool[] Victims;

	private AudioClip OriginalClip;

	private int ID;

	public GameObject HeartBurst;

	public WeaponScript()
	{
		this.Type = 1;
	}

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		Physics.IgnoreCollision(this.Yandere.collider, this.MyCollider);
		this.OriginalColor = this.Outline[0].color;
		if (this.StartLow)
		{
			this.OriginalOffset = this.Prompt.OffsetY[3];
			this.Prompt.OffsetY[3] = 0.2f;
		}
		if (this.DisableCollider)
		{
			this.MyCollider.enabled = false;
		}
		if (this.audio != null)
		{
			this.OriginalClip = this.audio.clip;
		}
		this.rigidbody.isKinematic = true;
	}

	public virtual void Update()
	{
		if (this.Dismembering)
		{
			if (this.DismemberPhase < 4)
			{
				if (this.audio.time > 0.75f)
				{
					if (this.Speed < (float)36)
					{
						this.Speed += Time.deltaTime + (float)10;
					}
					this.Rotation += this.Speed;
					float rotation = this.Rotation;
					Vector3 localEulerAngles = this.Blade.localEulerAngles;
					float num = localEulerAngles.x = rotation;
					Vector3 vector = this.Blade.localEulerAngles = localEulerAngles;
				}
				if (this.audio.time > this.SoundTime[this.DismemberPhase])
				{
					this.Yandere.Sanity = this.Yandere.Sanity - (float)5 * this.Yandere.Numbness;
					this.Yandere.UpdateSanity();
					this.Yandere.Bloodiness = this.Yandere.Bloodiness + (float)25;
					this.Yandere.UpdateBlood();
					this.ShortBloodSpray[0].Play();
					this.ShortBloodSpray[1].Play();
					this.Blood.enabled = true;
					this.DismemberPhase++;
				}
			}
			else
			{
				this.Rotation = Mathf.Lerp(this.Rotation, (float)0, Time.deltaTime * (float)2);
				float rotation2 = this.Rotation;
				Vector3 localEulerAngles2 = this.Blade.localEulerAngles;
				float num2 = localEulerAngles2.x = rotation2;
				Vector3 vector2 = this.Blade.localEulerAngles = localEulerAngles2;
				if (!this.audio.isPlaying)
				{
					this.audio.clip = this.OriginalClip;
					this.Yandere.StainWeapon();
					this.Dismembering = false;
					this.DismemberPhase = 0;
					this.Rotation = (float)0;
					this.Speed = (float)0;
				}
			}
		}
		else if (this.Yandere.Weapon[this.Yandere.Equipped] == this)
		{
			if (this.Yandere.AttackManager.Attacking)
			{
				if (this.Type == 1)
				{
					if (this.Flip)
					{
						float y = Mathf.Lerp(this.transform.localEulerAngles.y, (float)180, Time.deltaTime * (float)10);
						Vector3 localEulerAngles3 = this.transform.localEulerAngles;
						float num3 = localEulerAngles3.y = y;
						Vector3 vector3 = this.transform.localEulerAngles = localEulerAngles3;
					}
					else
					{
						float y2 = Mathf.Lerp(this.transform.localEulerAngles.y, (float)0, Time.deltaTime * (float)10);
						Vector3 localEulerAngles4 = this.transform.localEulerAngles;
						float num4 = localEulerAngles4.y = y2;
						Vector3 vector4 = this.transform.localEulerAngles = localEulerAngles4;
					}
				}
				else if (this.Type == 4 && this.Spin)
				{
					float x = this.Blade.transform.localEulerAngles.x + Time.deltaTime * (float)360;
					Vector3 localEulerAngles5 = this.Blade.transform.localEulerAngles;
					float num5 = localEulerAngles5.x = x;
					Vector3 vector5 = this.Blade.transform.localEulerAngles = localEulerAngles5;
				}
			}
		}
		else
		{
			if (!this.rigidbody.isKinematic)
			{
				this.KinematicTimer = Mathf.MoveTowards(this.KinematicTimer, (float)5, Time.deltaTime);
				if (this.KinematicTimer == (float)5)
				{
					this.rigidbody.isKinematic = true;
					this.KinematicTimer = (float)0;
				}
			}
			if ((this.transform.position.x > (float)-89 & this.transform.position.x < (float)-79) && this.transform.position.z > -13.5f && this.transform.position.z < -3.5f)
			{
				this.transform.position = new Vector3(-80.75f, (float)1, -2.75f);
			}
		}
	}

	public virtual void LateUpdate()
	{
		if (this.Prompt.Circle[3].fillAmount <= (float)0)
		{
			this.Prompt.Circle[3].fillAmount = (float)1;
			if (!this.Yandere.Gloved)
			{
				this.FingerprintID = 100;
			}
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.Outline))
			{
				this.Outline[this.ID].color = new Color((float)0, (float)0, (float)0, (float)1);
				this.ID++;
			}
			this.transform.parent = this.Yandere.ItemParent;
			this.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
			this.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
			this.MyCollider.enabled = false;
			this.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			if (this.Yandere.Equipped == 3)
			{
				this.Yandere.Weapon[3].Drop();
			}
			if (this.Yandere.PickUp != null)
			{
				this.Yandere.PickUp.Drop();
			}
			if (this.Yandere.Dragging)
			{
				((RagdollScript)this.Yandere.Ragdoll.GetComponent(typeof(RagdollScript))).StopDragging();
			}
			if (this.Yandere.Carrying)
			{
				this.Yandere.StopCarrying();
			}
			if (this.Concealable)
			{
				if (this.Yandere.Weapon[1] == null)
				{
					if (this.Yandere.Weapon[2] != null)
					{
						this.Yandere.Weapon[2].active = false;
					}
					this.Yandere.Weapon[1] = this;
					this.Yandere.Equipped = 1;
				}
				else if (this.Yandere.Weapon[2] == null)
				{
					if (this.Yandere.Weapon[1] != null)
					{
						this.Yandere.Weapon[1].active = false;
					}
					this.Yandere.Weapon[2] = this;
					this.Yandere.Equipped = 2;
				}
				else if (this.Yandere.Weapon[2].active)
				{
					this.Yandere.Weapon[2].Drop();
					this.Yandere.Weapon[2] = this;
					this.Yandere.Equipped = 2;
				}
				else
				{
					this.Yandere.Weapon[1].Drop();
					this.Yandere.Weapon[1] = this;
					this.Yandere.Equipped = 1;
				}
			}
			else
			{
				if (this.Yandere.Weapon[1] != null)
				{
					this.Yandere.Weapon[1].active = false;
				}
				if (this.Yandere.Weapon[2] != null)
				{
					this.Yandere.Weapon[2].active = false;
				}
				this.Yandere.Weapon[3] = this;
				this.Yandere.Equipped = 3;
			}
			this.Yandere.Armed = true;
			this.Yandere.StudentManager.UpdateStudents();
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Yandere.NearestPrompt = null;
			if (this.WeaponID == 9 || this.WeaponID == 10 || this.WeaponID == 12)
			{
				this.SuspicionCheck();
			}
			if (this.Yandere.Weapon[this.Yandere.Equipped].Suspicious)
			{
				if (!this.Yandere.WeaponWarning)
				{
					this.Yandere.NotificationManager.DisplayNotification("Armed");
					this.Yandere.WeaponWarning = true;
				}
			}
			else
			{
				this.Yandere.WeaponWarning = false;
			}
			this.Yandere.WeaponMenu.UpdateSprites();
			this.Yandere.WeaponManager.UpdateLabels();
			if (this.Evidence)
			{
				this.Yandere.Police.BloodyWeapons = this.Yandere.Police.BloodyWeapons - 1;
			}
			if (this.WeaponID == 11)
			{
				this.Yandere.IdleAnim = "CyborgNinja_Idle_Armed";
				this.Yandere.WalkAnim = "CyborgNinja_Walk_Armed";
				this.Yandere.RunAnim = "CyborgNinja_Run_Armed";
			}
			this.KinematicTimer = (float)0;
		}
		if (this.Yandere.Weapon[this.Yandere.Equipped] == this && this.Yandere.Armed)
		{
			this.transform.localScale = new Vector3((float)1, (float)1, (float)1);
			if (!this.Yandere.Struggling)
			{
				if (this.Yandere.CanMove)
				{
					this.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
					this.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
				}
			}
			else
			{
				this.transform.localPosition = new Vector3(-0.01f, 0.005f, -0.01f);
			}
		}
		if (this.Dumped)
		{
			this.DumpTimer += Time.deltaTime;
			if (this.DumpTimer > (float)1)
			{
				this.Yandere.Incinerator.MurderWeapons = this.Yandere.Incinerator.MurderWeapons + 1;
				UnityEngine.Object.Destroy(this.gameObject);
			}
		}
		if (this.transform.parent == this.Yandere.ItemParent && this.Concealable && this.Yandere.Weapon[1] != this && this.Yandere.Weapon[2] != this)
		{
			this.Drop();
		}
	}

	public virtual void Drop()
	{
		if (this.WeaponID == 11)
		{
			this.Yandere.IdleAnim = "CyborgNinja_Idle_Unarmed";
			this.Yandere.WalkAnim = this.Yandere.OriginalWalkAnim;
			this.Yandere.RunAnim = "CyborgNinja_Run_Unarmed";
		}
		if (this.StartLow)
		{
			this.Prompt.OffsetY[3] = this.OriginalOffset;
		}
		this.Yandere.Weapon[this.Yandere.Equipped] = null;
		this.Yandere.Armed = false;
		this.Yandere.Equipped = 0;
		this.Yandere.StudentManager.UpdateStudents();
		this.active = true;
		this.transform.parent = null;
		this.rigidbody.constraints = RigidbodyConstraints.None;
		this.rigidbody.isKinematic = false;
		this.rigidbody.useGravity = true;
		if (this.Dumped)
		{
			this.transform.position = this.Incinerator.DumpPoint.position;
		}
		else
		{
			this.Prompt.enabled = true;
			this.MyCollider.enabled = true;
			if (this.Yandere.collider.enabled)
			{
				Physics.IgnoreCollision(this.Yandere.collider, this.MyCollider);
			}
		}
		if (this.Evidence)
		{
			this.Yandere.Police.BloodyWeapons = this.Yandere.Police.BloodyWeapons + 1;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Outline))
		{
			if (!this.Evidence)
			{
				this.Outline[this.ID].color = this.OriginalColor;
			}
			else
			{
				this.Outline[this.ID].color = this.EvidenceColor;
			}
			this.ID++;
		}
		if (this.transform.position.y > (float)1000)
		{
			this.transform.position = new Vector3((float)12, (float)0, (float)28);
		}
	}

	public virtual void UpdateLabel()
	{
		if (this != null && this.active)
		{
			if (this.Yandere.Weapon[1] != null && this.Yandere.Weapon[2] != null && this.Concealable)
			{
				if (this.Prompt.Label[3] != null)
				{
					if (!this.Yandere.Armed || this.Yandere.Equipped == 3)
					{
						this.Prompt.Label[3].text = "     " + "Swap " + this.Yandere.Weapon[1].Name + " for " + this.Name;
					}
					else
					{
						this.Prompt.Label[3].text = "     " + "Swap " + this.Yandere.Weapon[this.Yandere.Equipped].Name + " for " + this.Name;
					}
				}
			}
			else if (this.Prompt.Label[3] != null)
			{
				this.Prompt.Label[3].text = "     " + this.Name;
			}
		}
	}

	public virtual void Effect()
	{
		if (this.WeaponID == 7)
		{
			this.BloodSpray[0].Play();
			this.BloodSpray[1].Play();
		}
		else if (this.WeaponID == 8)
		{
			((ParticleSystem)this.gameObject.GetComponent(typeof(ParticleSystem))).Play();
			this.audio.Play();
		}
		else if (this.WeaponID == 2 || this.WeaponID == 9 || this.WeaponID == 10 || this.WeaponID == 12 || this.WeaponID == 13)
		{
			this.audio.Play();
		}
		else if (this.WeaponID == 14)
		{
			UnityEngine.Object.Instantiate(this.HeartBurst, this.Yandere.TargetStudent.Head.position, Quaternion.identity);
			this.audio.Play();
		}
	}

	public virtual void Dismember()
	{
		this.audio.clip = this.DismemberClip;
		this.audio.Play();
		this.Dismembering = true;
	}

	public virtual void SuspicionCheck()
	{
		if (this.WeaponID == 9 && PlayerPrefs.GetInt("Club") == 9)
		{
			this.Suspicious = false;
		}
		else if (this.WeaponID == 10 && PlayerPrefs.GetInt("Club") == 10)
		{
			this.Suspicious = false;
		}
		else if (this.WeaponID == 12 && PlayerPrefs.GetInt("Club") == 9)
		{
			this.Suspicious = false;
		}
		else
		{
			this.Suspicious = true;
		}
	}

	public virtual void Main()
	{
	}
}
