using System;
using UnityEngine;

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

	public AudioClip EquipClip;

	public ParticleSystem FireEffect;

	public AudioSource FireAudio;

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

	public WeaponType Type = WeaponType.Knife;

	public bool[] Victims;

	private AudioClip OriginalClip;

	private int ID;

	public GameObject HeartBurst;

	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
		Physics.IgnoreCollision(this.Yandere.GetComponent<Collider>(), this.MyCollider);
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
		AudioSource component = base.GetComponent<AudioSource>();
		if (component != null)
		{
			this.OriginalClip = component.clip;
		}
		base.GetComponent<Rigidbody>().isKinematic = true;
	}

	public string GetTypePrefix()
	{
		if (this.Type == WeaponType.Knife)
		{
			return "knife";
		}
		if (this.Type == WeaponType.Katana)
		{
			return "katana";
		}
		if (this.Type == WeaponType.Bat)
		{
			return "bat";
		}
		if (this.Type == WeaponType.Saw)
		{
			return "saw";
		}
		if (this.Type == WeaponType.Syringe)
		{
			return "syringe";
		}
		Debug.LogError("Weapon type \"" + this.Type.ToString() + "\" not implemented.");
		return string.Empty;
	}

	public AudioClip GetClip(float sanity, bool stealth)
	{
		AudioClip[] array;
		if (this.Clips2.Length == 0)
		{
			array = this.Clips;
		}
		else
		{
			int num = UnityEngine.Random.Range(2, 4);
			array = ((num != 2) ? this.Clips3 : this.Clips2);
		}
		if (stealth)
		{
			return array[0];
		}
		if (sanity > 0.6666667f)
		{
			return array[1];
		}
		if (sanity > 0.333333343f)
		{
			return array[2];
		}
		return array[3];
	}

	private void Update()
	{
		if (this.Dismembering)
		{
			AudioSource component = base.GetComponent<AudioSource>();
			if (this.DismemberPhase < 4)
			{
				if (component.time > 0.75f)
				{
					if (this.Speed < 36f)
					{
						this.Speed += Time.deltaTime + 10f;
					}
					this.Rotation += this.Speed;
					this.Blade.localEulerAngles = new Vector3(this.Rotation, this.Blade.localEulerAngles.y, this.Blade.localEulerAngles.z);
				}
				if (component.time > this.SoundTime[this.DismemberPhase])
				{
					this.Yandere.Sanity -= 5f * this.Yandere.Numbness;
					this.Yandere.Bloodiness += 25f;
					this.ShortBloodSpray[0].Play();
					this.ShortBloodSpray[1].Play();
					this.Blood.enabled = true;
					this.DismemberPhase++;
				}
			}
			else
			{
				this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 2f);
				this.Blade.localEulerAngles = new Vector3(this.Rotation, this.Blade.localEulerAngles.y, this.Blade.localEulerAngles.z);
				if (!component.isPlaying)
				{
					component.clip = this.OriginalClip;
					this.Yandere.StainWeapon();
					this.Dismembering = false;
					this.DismemberPhase = 0;
					this.Rotation = 0f;
					this.Speed = 0f;
				}
			}
		}
		else if (this.Yandere.EquippedWeapon == this)
		{
			if (this.Yandere.AttackManager.IsAttacking())
			{
				if (this.Type == WeaponType.Knife)
				{
					base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, Mathf.Lerp(base.transform.localEulerAngles.y, (!this.Flip) ? 0f : 180f, Time.deltaTime * 10f), base.transform.localEulerAngles.z);
				}
				else if (this.Type == WeaponType.Saw && this.Spin)
				{
					this.Blade.transform.localEulerAngles = new Vector3(this.Blade.transform.localEulerAngles.x + Time.deltaTime * 360f, this.Blade.transform.localEulerAngles.y, this.Blade.transform.localEulerAngles.z);
				}
			}
		}
		else
		{
			Rigidbody component2 = base.GetComponent<Rigidbody>();
			if (!component2.isKinematic)
			{
				this.KinematicTimer = Mathf.MoveTowards(this.KinematicTimer, 5f, Time.deltaTime);
				if (this.KinematicTimer == 5f)
				{
					component2.isKinematic = true;
					this.KinematicTimer = 0f;
				}
			}
			if (base.transform.position.x > -89f && base.transform.position.x < -79f && base.transform.position.z > -13.5f && base.transform.position.z < -3.5f)
			{
				base.transform.position = new Vector3(-80.75f, 1f, -2.75f);
			}
			if (base.transform.position.x > -21f && base.transform.position.x < 21f && base.transform.position.z > 79f && base.transform.position.z < 121f)
			{
				base.transform.position = new Vector3(0f, 1f, 79f);
			}
		}
	}

	private void LateUpdate()
	{
		if (this.Prompt.Circle[3].fillAmount == 0f)
		{
			this.Prompt.Circle[3].fillAmount = 1f;
			if (this.Prompt.Suspicious)
			{
				this.Yandere.TheftTimer = 1f;
			}
			if (!this.Yandere.Gloved)
			{
				this.FingerprintID = 100;
			}
			this.ID = 0;
			while (this.ID < this.Outline.Length)
			{
				this.Outline[this.ID].color = new Color(0f, 0f, 0f, 1f);
				this.ID++;
			}
			base.transform.parent = this.Yandere.ItemParent;
			base.transform.localPosition = Vector3.zero;
			base.transform.localEulerAngles = Vector3.zero;
			this.MyCollider.enabled = false;
			base.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
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
				this.Yandere.Ragdoll.GetComponent<RagdollScript>().StopDragging();
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
						this.Yandere.Weapon[2].gameObject.SetActive(false);
					}
					this.Yandere.Equipped = 1;
					this.Yandere.EquippedWeapon = this;
				}
				else if (this.Yandere.Weapon[2] == null)
				{
					if (this.Yandere.Weapon[1] != null)
					{
						this.Yandere.Weapon[1].gameObject.SetActive(false);
					}
					this.Yandere.Equipped = 2;
					this.Yandere.EquippedWeapon = this;
				}
				else if (this.Yandere.Weapon[2].gameObject.activeInHierarchy)
				{
					this.Yandere.Weapon[2].Drop();
					this.Yandere.Equipped = 2;
					this.Yandere.EquippedWeapon = this;
				}
				else
				{
					this.Yandere.Weapon[1].Drop();
					this.Yandere.Equipped = 1;
					this.Yandere.EquippedWeapon = this;
				}
			}
			else
			{
				if (this.Yandere.Weapon[1] != null)
				{
					this.Yandere.Weapon[1].gameObject.SetActive(false);
				}
				if (this.Yandere.Weapon[2] != null)
				{
					this.Yandere.Weapon[2].gameObject.SetActive(false);
				}
				this.Yandere.Equipped = 3;
				this.Yandere.EquippedWeapon = this;
			}
			this.Yandere.StudentManager.UpdateStudents();
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Yandere.NearestPrompt = null;
			if (this.WeaponID == 9 || this.WeaponID == 10 || this.WeaponID == 12)
			{
				this.SuspicionCheck();
			}
			if (this.Yandere.EquippedWeapon.Suspicious)
			{
				if (!this.Yandere.WeaponWarning)
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Armed);
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
				this.Yandere.Police.BloodyWeapons--;
			}
			if (this.WeaponID == 11)
			{
				this.Yandere.IdleAnim = "CyborgNinja_Idle_Armed";
				this.Yandere.WalkAnim = "CyborgNinja_Walk_Armed";
				this.Yandere.RunAnim = "CyborgNinja_Run_Armed";
			}
			this.KinematicTimer = 0f;
			AudioSource.PlayClipAtPoint(this.EquipClip, Camera.main.transform.position);
		}
		if (this.Yandere.EquippedWeapon == this && this.Yandere.Armed)
		{
			base.transform.localScale = new Vector3(1f, 1f, 1f);
			if (!this.Yandere.Struggling)
			{
				if (this.Yandere.CanMove)
				{
					base.transform.localPosition = Vector3.zero;
					base.transform.localEulerAngles = Vector3.zero;
				}
			}
			else
			{
				base.transform.localPosition = new Vector3(-0.01f, 0.005f, -0.01f);
			}
		}
		if (this.Dumped)
		{
			this.DumpTimer += Time.deltaTime;
			if (this.DumpTimer > 1f)
			{
				this.Yandere.Incinerator.MurderWeapons++;
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
		if (base.transform.parent == this.Yandere.ItemParent && this.Concealable && this.Yandere.Weapon[1] != this && this.Yandere.Weapon[2] != this)
		{
			this.Drop();
		}
	}

	public void Drop()
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
		this.Yandere.EquippedWeapon = null;
		this.Yandere.Equipped = 0;
		this.Yandere.StudentManager.UpdateStudents();
		base.gameObject.SetActive(true);
		base.transform.parent = null;
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.constraints = RigidbodyConstraints.None;
		component.isKinematic = false;
		component.useGravity = true;
		if (this.Dumped)
		{
			base.transform.position = this.Incinerator.DumpPoint.position;
		}
		else
		{
			this.Prompt.enabled = true;
			this.MyCollider.enabled = true;
			if (this.Yandere.GetComponent<Collider>().enabled)
			{
				Physics.IgnoreCollision(this.Yandere.GetComponent<Collider>(), this.MyCollider);
			}
		}
		if (this.Evidence)
		{
			this.Yandere.Police.BloodyWeapons++;
		}
		this.ID = 0;
		while (this.ID < this.Outline.Length)
		{
			this.Outline[this.ID].color = ((!this.Evidence) ? this.OriginalColor : this.EvidenceColor);
			this.ID++;
		}
		if (base.transform.position.y > 1000f)
		{
			base.transform.position = new Vector3(12f, 0f, 28f);
		}
	}

	public void UpdateLabel()
	{
		if (this != null && base.gameObject.activeInHierarchy)
		{
			if (this.Yandere.Weapon[1] != null && this.Yandere.Weapon[2] != null && this.Concealable)
			{
				if (this.Prompt.Label[3] != null)
				{
					if (!this.Yandere.Armed || this.Yandere.Equipped == 3)
					{
						this.Prompt.Label[3].text = "     Swap " + this.Yandere.Weapon[1].Name + " for " + this.Name;
					}
					else
					{
						this.Prompt.Label[3].text = "     Swap " + this.Yandere.EquippedWeapon.Name + " for " + this.Name;
					}
				}
			}
			else if (this.Prompt.Label[3] != null)
			{
				this.Prompt.Label[3].text = "     " + this.Name;
			}
		}
	}

	public void Effect()
	{
		if (this.WeaponID == 7)
		{
			this.BloodSpray[0].Play();
			this.BloodSpray[1].Play();
		}
		else if (this.WeaponID == 8)
		{
			base.gameObject.GetComponent<ParticleSystem>().Play();
			base.GetComponent<AudioSource>().clip = this.OriginalClip;
			base.GetComponent<AudioSource>().Play();
		}
		else if (this.WeaponID == 2 || this.WeaponID == 9 || this.WeaponID == 10 || this.WeaponID == 12 || this.WeaponID == 13)
		{
			base.GetComponent<AudioSource>().Play();
		}
		else if (this.WeaponID == 14)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.HeartBurst, this.Yandere.TargetStudent.Head.position, Quaternion.identity);
			base.GetComponent<AudioSource>().Play();
		}
	}

	public void Dismember()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.DismemberClip;
		component.Play();
		this.Dismembering = true;
	}

	public void SuspicionCheck()
	{
		if ((this.WeaponID == 9 && ClubGlobals.Club == ClubType.Sports) || (this.WeaponID == 10 && ClubGlobals.Club == ClubType.Gardening) || (this.WeaponID == 12 && ClubGlobals.Club == ClubType.Sports))
		{
			this.Suspicious = false;
		}
		else
		{
			this.Suspicious = true;
		}
	}
}
