using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class NemesisScript : MonoBehaviour
{
	public MissionModeScript MissionMode;

	public CosmeticScript Cosmetic;

	public StudentScript Student;

	public YandereScript Yandere;

	public AudioClip YandereDeath;

	public Texture NemesisUniform;

	public Texture NemesisFace;

	public Texture NemesisEyes;

	public GameObject BloodEffect;

	public GameObject NemesisHair;

	public GameObject Knife;

	public bool PutOnDisguise;

	public bool Attacking;

	public bool InView;

	public bool Dying;

	public int EffectPhase;

	public int Difficulty;

	public float ScanTimer;

	public NemesisScript()
	{
		this.ScanTimer = 6f;
	}

	public virtual void Start()
	{
		this.Difficulty = PlayerPrefs.GetInt("NemesisDifficulty");
		this.Student.StudentManager = (StudentManagerScript)GameObject.Find("StudentManager").GetComponent(typeof(StudentManagerScript));
		this.Student.WitnessCamera = (WitnessCameraScript)GameObject.Find("WitnessCamera").GetComponent(typeof(WitnessCameraScript));
		this.Student.Reputation = (ReputationScript)GameObject.Find("Reputation").GetComponent(typeof(ReputationScript));
		this.Student.Police = (PoliceScript)GameObject.Find("Police").GetComponent(typeof(PoliceScript));
		this.Student.JSON = (JsonScript)GameObject.Find("JSON").GetComponent(typeof(JsonScript));
		this.Student.CharacterAnimation = this.Student.Character.animation;
		this.Student.Yandere = this.Yandere;
		this.Student.ShoeRemoval.RightCasualShoe.gameObject.active = false;
		this.Student.ShoeRemoval.LeftCasualShoe.gameObject.active = false;
		if (this.Difficulty < 3)
		{
			this.Student.Character.animation["f02_nemesisEyes_00"].layer = 2;
			this.Student.Character.animation.Play("f02_nemesisEyes_00");
			if (this.Cosmetic.Hairstyle > 0)
			{
				RuntimeServices.SetProperty(RuntimeServices.GetSlice(this.Cosmetic, "FemaleHairstyles", new object[]
				{
					this.Cosmetic.Hairstyle
				}), "active", false);
				this.NemesisHair.active = true;
			}
			this.Cosmetic.MyRenderer.sharedMesh = this.Cosmetic.FemaleUniforms[5];
			this.Cosmetic.MyRenderer.materials[0].mainTexture = this.NemesisUniform;
			this.Cosmetic.MyRenderer.materials[1].mainTexture = this.NemesisUniform;
			this.Cosmetic.MyRenderer.materials[2].mainTexture = this.NemesisFace;
			this.Cosmetic.RightEyeRenderer.material.mainTexture = this.NemesisEyes;
			this.Cosmetic.LeftEyeRenderer.material.mainTexture = this.NemesisEyes;
			this.Student.FaceCollider.tag = "Nemesis";
		}
		else
		{
			this.NemesisHair.active = false;
			this.PutOnDisguise = true;
		}
		this.Student.LowPoly.enabled = false;
		this.Student.DisableEffects();
		for (int i = 0; i < this.Student.Ragdoll.AllRigidbodies.Length; i++)
		{
			this.Student.Ragdoll.AllRigidbodies[i].isKinematic = true;
			this.Student.Ragdoll.AllColliders[i].enabled = false;
		}
		this.Student.Ragdoll.AllColliders[10].enabled = true;
		this.Student.Prompt.HideButton[0] = true;
		this.Student.Prompt.HideButton[2] = true;
		UnityEngine.Object.Destroy(this.Student.MyRigidbody);
		this.transform.position = this.MissionMode.SpawnPoints[UnityEngine.Random.Range(0, 5)].position;
		this.MissionMode.LastKnownPosition.position = new Vector3((float)0, (float)0, (float)-36);
		this.UpdateLKP();
	}

	public virtual void Update()
	{
		if (this.PutOnDisguise)
		{
			int num = 1;
			while (this.Student.StudentManager.Students[num].Male && num != this.MissionMode.TargetID)
			{
				num = UnityEngine.Random.Range(2, 33);
			}
			this.Student.StudentManager.Students[num].active = false;
			this.Cosmetic.StudentID = num;
			this.Cosmetic.Start();
			this.Student.FaceCollider.tag = "Disguise";
			this.PutOnDisguise = false;
		}
		if (!this.Dying)
		{
			if (!this.Attacking)
			{
				if (!this.Yandere.CanMove)
				{
					if (!this.Yandere.Laughing)
					{
						if (this.Student.Pathfinding.enabled)
						{
							this.Student.Character.animation.CrossFade(this.Student.IdleAnim);
							this.Student.Pathfinding.enabled = false;
							this.Student.Pathfinding.speed = (float)0;
						}
					}
					else if (Vector3.Distance(this.transform.position, this.Yandere.transform.position) < (float)10)
					{
						this.MissionMode.LastKnownPosition.position = this.Yandere.transform.position;
						this.UpdateLKP();
					}
				}
				else
				{
					if (!this.Yandere.Crouching && !this.Yandere.Crawling && Vector3.Distance(this.transform.position, this.Yandere.transform.position) < (float)10 && Input.GetButton("LB"))
					{
						this.MissionMode.LastKnownPosition.position = this.Yandere.transform.position;
						this.UpdateLKP();
					}
					if (!this.Student.Pathfinding.enabled)
					{
						this.Student.Character.animation.CrossFade(this.Student.WalkAnim);
						this.Student.Pathfinding.enabled = true;
						this.Student.Pathfinding.speed = (float)1;
					}
					this.InView = false;
					this.LookForYandere();
					if (this.InView)
					{
						this.Student.Pathfinding.speed = Mathf.MoveTowards(this.Student.Pathfinding.speed, (float)2, Time.deltaTime * 0.1f);
					}
					else
					{
						this.Student.Pathfinding.speed = Mathf.MoveTowards(this.Student.Pathfinding.speed, (float)1, Time.deltaTime * 0.1f);
					}
					this.Student.Character.animation[this.Student.WalkAnim].speed = this.Student.Pathfinding.speed;
					if (Vector3.Distance(this.transform.position, this.Yandere.transform.position) < (float)1)
					{
						if (this.InView)
						{
							this.Student.Character.animation.CrossFade("f02_knifeLowSanityA_00");
							this.Yandere.CharacterAnimation.CrossFade("f02_knifeLowSanityB_00");
							AudioSource.PlayClipAtPoint(this.YandereDeath, this.transform.position);
							this.Student.Pathfinding.enabled = false;
							this.Yandere.FollowHips = true;
							this.Yandere.CanMove = false;
							this.Yandere.EyeShrink = (float)1;
							this.Knife.active = true;
							this.Attacking = true;
							this.audio.Play();
						}
					}
					else if (Vector3.Distance(this.transform.position, this.MissionMode.LastKnownPosition.position) < (float)1)
					{
						this.Student.Character.animation.CrossFade("f02_nemesisScan_00");
						this.Student.Pathfinding.speed = (float)0;
						this.ScanTimer += Time.deltaTime;
						if (this.ScanTimer > (float)6)
						{
							if (this.MissionMode.LastKnownPosition.position == new Vector3((float)0, (float)0, -2.5f))
							{
								this.MissionMode.LastKnownPosition.position = this.Yandere.transform.position;
								this.UpdateLKP();
							}
							else
							{
								this.MissionMode.LastKnownPosition.position = new Vector3((float)0, (float)0, -2.5f);
								this.UpdateLKP();
							}
						}
					}
				}
				if (this.Difficulty == 1)
				{
					float f = Vector3.Angle(this.transform.forward * (float)-1, this.Yandere.transform.position - this.transform.position);
					if (Mathf.Abs(f) > (float)45)
					{
						this.Student.Prompt.HideButton[2] = true;
					}
					else if (this.Yandere.Armed)
					{
						this.Student.Prompt.HideButton[2] = false;
					}
					if (!this.Yandere.Armed)
					{
						this.Student.Prompt.HideButton[2] = true;
					}
					if (this.Student.Prompt.Circle[2].fillAmount < (float)1)
					{
						this.Yandere.TargetStudent = this.Student;
						this.Yandere.AttackManager.Stealth = true;
						this.Student.AttackReaction();
						this.Student.Pathfinding.enabled = false;
						this.Student.Prompt.HideButton[2] = true;
						this.Dying = true;
					}
				}
			}
			else
			{
				this.Yandere.audio.volume = (float)1;
				this.SpecialEffect();
				this.Yandere.targetRotation = Quaternion.LookRotation(this.transform.position - this.Yandere.transform.position);
				this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.Yandere.targetRotation, Time.deltaTime * (float)10);
				this.Yandere.MoveTowardsTarget(this.transform.position + this.transform.forward * 0.5f);
				Quaternion to = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, to, Time.deltaTime * (float)10);
				if (this.Student.Character.animation["f02_knifeLowSanityA_00"].time >= this.Student.Character.animation["f02_knifeLowSanityA_00"].length)
				{
					this.MissionMode.GameOverID = 13;
					this.MissionMode.GameOver();
					this.MissionMode.Phase = 4;
					this.enabled = false;
				}
			}
		}
		else if (!this.Student.Dead)
		{
			this.Student.DeltaTime = Time.deltaTime;
			this.Student.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * this.Yandere.AttackManager.Distance);
			Quaternion to = Quaternion.LookRotation(this.transform.position - new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z));
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, to, Time.deltaTime * (float)10);
		}
		else
		{
			this.enabled = false;
		}
	}

	public virtual void LookForYandere()
	{
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(this.Student.VisionCone);
		if (GeometryUtility.TestPlanesAABB(planes, this.Yandere.collider.bounds))
		{
			RaycastHit raycastHit = default(RaycastHit);
			Debug.DrawLine(this.Student.Eyes.transform.position, new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z), Color.green);
			if (Physics.Linecast(this.Student.Eyes.transform.position, new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z), out raycastHit) && raycastHit.collider.gameObject == this.Yandere.gameObject)
			{
				this.MissionMode.LastKnownPosition.position = this.Yandere.transform.position;
				this.InView = true;
				this.UpdateLKP();
			}
		}
	}

	public virtual void UpdateLKP()
	{
		this.Student.Character.animation.CrossFade(this.Student.WalkAnim);
		if (this.Student.Pathfinding.speed == (float)0)
		{
			this.Student.Pathfinding.speed = (float)1;
		}
		this.ScanTimer = (float)0;
		this.InView = true;
	}

	public virtual void SpecialEffect()
	{
		if (this.EffectPhase == 0)
		{
			if (this.Student.Character.animation["f02_knifeLowSanityA_00"].time > 2.76666665f)
			{
				UnityEngine.Object.Instantiate(this.BloodEffect, this.Knife.transform.position + this.Knife.transform.forward * 0.1f, Quaternion.identity);
				this.EffectPhase++;
			}
		}
		else if (this.EffectPhase == 1)
		{
			if (this.Student.Character.animation["f02_knifeLowSanityA_00"].time > 3.5333333f)
			{
				UnityEngine.Object.Instantiate(this.BloodEffect, this.Knife.transform.position + this.Knife.transform.forward * 0.1f, Quaternion.identity);
				this.EffectPhase++;
			}
		}
		else if (this.EffectPhase == 2 && this.Student.Character.animation["f02_knifeLowSanityA_00"].time > 4.16666651f)
		{
			UnityEngine.Object.Instantiate(this.BloodEffect, this.Knife.transform.position + this.Knife.transform.forward * 0.1f, Quaternion.identity);
			this.EffectPhase++;
		}
	}

	public virtual void Main()
	{
	}
}
