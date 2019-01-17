using System;
using UnityEngine;

public class RagdollScript : MonoBehaviour
{
	public BloodPoolSpawnerScript BloodPoolSpawner;

	public DetectionMarkerScript DetectionMarker;

	public IncineratorScript Incinerator;

	public WoodChipperScript WoodChipper;

	public TranqCaseScript TranqCase;

	public StudentScript Student;

	public YandereScript Yandere;

	public PoliceScript Police;

	public PromptScript Prompt;

	public SkinnedMeshRenderer MyRenderer;

	public Collider BloodSpawnerCollider;

	public Animation CharacterAnimation;

	public Collider HideCollider;

	public Rigidbody[] AllRigidbodies;

	public Collider[] AllColliders;

	public Rigidbody[] Rigidbodies;

	public Transform[] SpawnPoints;

	public GameObject[] BodyParts;

	public Transform NearestLimb;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform PelvisRoot;

	public Transform Ponytail;

	public Transform RightEye;

	public Transform LeftEye;

	public Transform HairR;

	public Transform HairL;

	public Transform[] Limb;

	public Transform Head;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public Vector3[] LimbAnchor;

	public GameObject Character;

	public GameObject Zs;

	public bool AddingToCount;

	public bool MurderSuicide;

	public bool Cauterizable;

	public bool Electrocuted;

	public bool StopAnimation = true;

	public bool Decapitated;

	public bool Dismembered;

	public bool NeckSnapped;

	public bool Cauterized;

	public bool Disturbing;

	public bool Sacrifice;

	public bool Poisoned;

	public bool Tranquil;

	public bool Burning;

	public bool Carried;

	public bool Dragged;

	public bool Drowned;

	public bool Falling;

	public bool Nemesis;

	public bool Settled;

	public bool Suicide;

	public bool Burned;

	public bool Dumped;

	public bool Hidden;

	public bool Pushed;

	public bool Male;

	public float AnimStartTime;

	public float SettleTimer;

	public float BreastSize;

	public float DumpTimer;

	public float EyeShrink;

	public float FallTimer;

	public int StudentID;

	public RagdollDumpType DumpType;

	public int LimbID;

	public int Frame;

	public string DumpedAnim = string.Empty;

	public string LiftAnim = string.Empty;

	public string IdleAnim = string.Empty;

	public string WalkAnim = string.Empty;

	public string RunAnim = string.Empty;

	private void Start()
	{
		Physics.IgnoreLayerCollision(11, 13, true);
		this.Zs.SetActive(this.Tranquil);
		if (!this.Tranquil && !this.Poisoned && !this.Drowned && !this.Electrocuted && !this.Burning && !this.NeckSnapped)
		{
			this.BloodPoolSpawner.gameObject.SetActive(true);
			if (this.Pushed)
			{
				this.BloodPoolSpawner.Timer = 5f;
			}
		}
		for (int i = 0; i < this.AllRigidbodies.Length; i++)
		{
			this.AllRigidbodies[i].isKinematic = false;
			this.AllColliders[i].enabled = true;
			if (this.Yandere.StudentManager.NoGravity)
			{
				this.AllRigidbodies[i].useGravity = false;
			}
		}
		this.Prompt.enabled = true;
		if (ClassGlobals.PhysicalGrade + ClassGlobals.PhysicalBonus > 0 && !this.Tranquil)
		{
			this.Prompt.HideButton[3] = false;
		}
	}

	private void Update()
	{
		if (!this.Dragged && !this.Carried && !this.Settled && !this.Yandere.PK && !this.Yandere.StudentManager.NoGravity)
		{
			this.SettleTimer += Time.deltaTime;
			if (this.SettleTimer > 5f)
			{
				this.Settled = true;
				for (int i = 0; i < this.AllRigidbodies.Length; i++)
				{
					this.AllRigidbodies[i].isKinematic = true;
					this.AllColliders[i].enabled = false;
				}
			}
		}
		if (this.DetectionMarker != null)
		{
			if (this.DetectionMarker.Tex.color.a > 0.1f)
			{
				this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, Mathf.MoveTowards(this.DetectionMarker.Tex.color.a, 0f, Time.deltaTime * 10f));
			}
			else
			{
				this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, 0f);
				this.DetectionMarker = null;
			}
		}
		if (!this.Dumped)
		{
			if (this.StopAnimation && this.Student.CharacterAnimation.isPlaying)
			{
				this.Student.CharacterAnimation.Stop();
			}
			if (!Input.GetButtonDown("LB"))
			{
				if (this.BloodPoolSpawner != null && this.BloodPoolSpawner.gameObject.activeInHierarchy && !this.Cauterized)
				{
					if (this.Yandere.PickUp != null)
					{
						if (this.Yandere.PickUp.Blowtorch)
						{
							if (!this.Cauterizable)
							{
								this.Prompt.Label[0].text = "     Cauterize";
								this.Cauterizable = true;
							}
						}
						else if (this.Cauterizable)
						{
							this.Prompt.Label[0].text = "     Dismember";
							this.Cauterizable = false;
						}
					}
					else if (this.Cauterizable)
					{
						this.Prompt.Label[0].text = "     Dismember";
						this.Cauterizable = false;
					}
				}
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					this.Prompt.Circle[0].fillAmount = 1f;
					if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
					{
						if (this.Cauterizable)
						{
							this.Prompt.Label[0].text = "     Dismember";
							this.BloodPoolSpawner.enabled = false;
							this.Cauterizable = false;
							this.Cauterized = true;
							this.Yandere.CharacterAnimation.CrossFade("f02_cauterize_00");
							this.Yandere.Cauterizing = true;
							this.Yandere.CanMove = false;
							this.Yandere.PickUp.GetComponent<BlowtorchScript>().enabled = true;
							this.Yandere.PickUp.GetComponent<AudioSource>().Play();
						}
						else
						{
							this.Yandere.CharacterAnimation.CrossFade("f02_dismember_00");
							this.Yandere.transform.LookAt(base.transform);
							this.Yandere.RPGCamera.transform.position = this.Yandere.DismemberSpot.position;
							this.Yandere.RPGCamera.transform.eulerAngles = this.Yandere.DismemberSpot.eulerAngles;
							this.Yandere.EquippedWeapon.Dismember();
							this.Yandere.RPGCamera.enabled = false;
							this.Yandere.TargetStudent = this.Student;
							this.Yandere.Ragdoll = base.gameObject;
							this.Yandere.Dismembering = true;
							this.Yandere.CanMove = false;
						}
					}
				}
				if (this.Prompt.Circle[1].fillAmount == 0f)
				{
					this.Prompt.Circle[1].fillAmount = 1f;
					if (!this.Student.FireEmitters[1].isPlaying)
					{
						if (!this.Dragged)
						{
							this.Yandere.EmptyHands();
							this.Prompt.AcceptingInput[1] = false;
							this.Prompt.Label[1].text = "     Drop";
							this.PickNearestLimb();
							this.Yandere.RagdollDragger.connectedBody = this.Rigidbodies[this.LimbID];
							this.Yandere.RagdollDragger.connectedAnchor = this.LimbAnchor[this.LimbID];
							this.Yandere.Dragging = true;
							this.Yandere.DragState = 0;
							this.Yandere.Ragdoll = base.gameObject;
							this.Dragged = true;
							this.Yandere.StudentManager.UpdateStudents(0);
							if (this.MurderSuicide)
							{
								this.Police.MurderSuicideScene = false;
								this.MurderSuicide = false;
							}
							if (this.Suicide)
							{
								this.Police.Suicide = false;
								this.Suicide = false;
							}
							for (int j = 0; j < this.Student.Ragdoll.AllRigidbodies.Length; j++)
							{
								this.Student.Ragdoll.AllRigidbodies[j].drag = 2f;
							}
							for (int k = 0; k < this.AllRigidbodies.Length; k++)
							{
								this.AllRigidbodies[k].isKinematic = false;
								this.AllColliders[k].enabled = true;
								if (this.Yandere.StudentManager.NoGravity)
								{
									this.AllRigidbodies[k].useGravity = false;
								}
							}
						}
						else
						{
							this.StopDragging();
						}
					}
				}
				if (this.Prompt.Circle[3].fillAmount == 0f)
				{
					this.Prompt.Circle[3].fillAmount = 1f;
					if (!this.Student.FireEmitters[1].isPlaying)
					{
						this.Yandere.EmptyHands();
						this.Prompt.Label[1].text = "     Drop";
						this.Prompt.HideButton[1] = true;
						this.Prompt.HideButton[3] = true;
						this.Prompt.enabled = false;
						this.Prompt.Hide();
						for (int l = 0; l < this.AllRigidbodies.Length; l++)
						{
							this.AllRigidbodies[l].isKinematic = true;
							this.AllColliders[l].enabled = false;
						}
						if (this.Male)
						{
							Rigidbody rigidbody = this.AllRigidbodies[0];
							rigidbody.transform.parent.transform.localPosition = new Vector3(rigidbody.transform.parent.transform.localPosition.x, 0.2f, rigidbody.transform.parent.transform.localPosition.z);
						}
						this.Yandere.CharacterAnimation.Play("f02_carryLiftA_00");
						this.Student.CharacterAnimation.Play(this.LiftAnim);
						this.BloodSpawnerCollider.enabled = false;
						this.PelvisRoot.localEulerAngles = new Vector3(this.PelvisRoot.localEulerAngles.x, 0f, this.PelvisRoot.localEulerAngles.z);
						this.Prompt.MyCollider.enabled = false;
						this.PelvisRoot.localPosition = new Vector3(this.PelvisRoot.localPosition.x, this.PelvisRoot.localPosition.y, 0f);
						this.Yandere.Ragdoll = base.gameObject;
						this.Yandere.CurrentRagdoll = this;
						this.Yandere.CanMove = false;
						this.Yandere.Lifting = true;
						this.StopAnimation = false;
						this.Carried = true;
						this.Falling = false;
						this.FallTimer = 0f;
					}
				}
			}
			else if (this.Yandere.CanMove && this.Dragged)
			{
				this.StopDragging();
			}
			if (Vector3.Distance(this.Yandere.transform.position, this.Prompt.transform.position) < 2f)
			{
				if (!this.Suicide && !this.AddingToCount)
				{
					this.Yandere.NearestCorpseID = this.StudentID;
					this.Yandere.NearBodies++;
					this.AddingToCount = true;
				}
			}
			else if (this.AddingToCount)
			{
				this.Yandere.NearBodies--;
				this.AddingToCount = false;
			}
			if (!this.Prompt.AcceptingInput[1] && Input.GetButtonUp("B"))
			{
				this.Prompt.AcceptingInput[1] = true;
			}
			bool flag = false;
			if (this.Yandere.Armed && this.Yandere.EquippedWeapon.WeaponID == 7)
			{
				flag = true;
			}
			if (!this.Cauterized && this.Yandere.PickUp != null && this.Yandere.PickUp.Blowtorch && this.BloodPoolSpawner.gameObject.activeInHierarchy)
			{
				flag = true;
			}
			this.Prompt.HideButton[0] = (this.Dragged || this.Carried || this.Tranquil || !flag || this.Nemesis);
		}
		else if (this.DumpType == RagdollDumpType.Incinerator)
		{
			if (this.DumpTimer == 0f && this.Yandere.Carrying)
			{
				this.Student.CharacterAnimation[this.DumpedAnim].time = 2.5f;
			}
			this.Student.CharacterAnimation.CrossFade(this.DumpedAnim);
			this.DumpTimer += Time.deltaTime;
			if (this.Student.CharacterAnimation[this.DumpedAnim].time >= this.Student.CharacterAnimation[this.DumpedAnim].length)
			{
				this.Incinerator.Corpses++;
				this.Incinerator.CorpseList[this.Incinerator.Corpses] = this.StudentID;
				this.Remove();
				base.enabled = false;
			}
		}
		else if (this.DumpType == RagdollDumpType.TranqCase)
		{
			if (this.DumpTimer == 0f && this.Yandere.Carrying)
			{
				this.Student.CharacterAnimation[this.DumpedAnim].time = 2.5f;
			}
			this.Student.CharacterAnimation.CrossFade(this.DumpedAnim);
			this.DumpTimer += Time.deltaTime;
			if (this.Student.CharacterAnimation[this.DumpedAnim].time >= this.Student.CharacterAnimation[this.DumpedAnim].length)
			{
				this.TranqCase.Open = false;
				if (this.AddingToCount)
				{
					this.Yandere.NearBodies--;
				}
				base.enabled = false;
			}
		}
		else if (this.DumpType == RagdollDumpType.WoodChipper)
		{
			if (this.DumpTimer == 0f && this.Yandere.Carrying)
			{
				this.Student.CharacterAnimation[this.DumpedAnim].time = 2.5f;
			}
			this.Student.CharacterAnimation.CrossFade(this.DumpedAnim);
			this.DumpTimer += Time.deltaTime;
			if (this.Student.CharacterAnimation[this.DumpedAnim].time >= this.Student.CharacterAnimation[this.DumpedAnim].length)
			{
				this.WoodChipper.VictimID = this.StudentID;
				this.Remove();
				base.enabled = false;
			}
		}
		if (this.Hidden && this.HideCollider == null)
		{
			this.Police.HiddenCorpses--;
			this.Hidden = false;
		}
		if (this.Falling)
		{
			this.FallTimer += Time.deltaTime;
			if (this.FallTimer > 2f)
			{
				this.BloodSpawnerCollider.enabled = true;
				this.FallTimer = 0f;
				this.Falling = false;
			}
		}
		if (this.Burning)
		{
			for (int m = 0; m < 3; m++)
			{
				Material material = this.MyRenderer.materials[m];
				material.color = Vector4.MoveTowards(material.color, new Vector4(0.1f, 0.1f, 0.1f, 1f), Time.deltaTime * 0.1f);
			}
			this.Student.Cosmetic.HairRenderer.material.color = Vector4.MoveTowards(this.Student.Cosmetic.HairRenderer.material.color, new Vector4(0.1f, 0.1f, 0.1f, 1f), Time.deltaTime * 0.1f);
			if (this.MyRenderer.materials[0].color == new Color(0.1f, 0.1f, 0.1f, 1f))
			{
				this.Burning = false;
				this.Burned = true;
			}
		}
		if (this.Burned)
		{
			this.Sacrifice = (Vector3.Distance(this.Prompt.transform.position, this.Yandere.StudentManager.SacrificeSpot.position) < 1.5f);
		}
	}

	private void LateUpdate()
	{
		if (!this.Male)
		{
			if (this.LeftEye != null)
			{
				this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x, this.LeftEye.localPosition.y, this.LeftEyeOrigin.z - this.EyeShrink * 0.01f);
				this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x, this.RightEye.localPosition.y, this.RightEyeOrigin.z + this.EyeShrink * 0.01f);
				this.LeftEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.LeftEye.localScale.z);
				this.RightEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.RightEye.localScale.z);
			}
			if (this.StudentID == 81)
			{
				for (int i = 0; i < 4; i++)
				{
					Transform transform = this.Student.Skirt[i];
					transform.transform.localScale = new Vector3(transform.transform.localScale.x, 0.6666667f, transform.transform.localScale.z);
				}
			}
		}
		if (this.Decapitated)
		{
			this.Head.localScale = Vector3.zero;
		}
		if (this.Yandere.Ragdoll == base.gameObject)
		{
			if (this.Yandere.DumpTimer < 1f)
			{
				if (this.Yandere.Lifting)
				{
					base.transform.position = this.Yandere.transform.position;
					base.transform.eulerAngles = this.Yandere.transform.eulerAngles;
				}
				else if (this.Carried)
				{
					base.transform.position = this.Yandere.transform.position;
					base.transform.eulerAngles = this.Yandere.transform.eulerAngles;
					float axis = Input.GetAxis("Vertical");
					float axis2 = Input.GetAxis("Horizontal");
					if (axis != 0f || axis2 != 0f)
					{
						this.Student.CharacterAnimation.CrossFade((!Input.GetButton("LB")) ? this.WalkAnim : this.RunAnim);
					}
					else
					{
						this.Student.CharacterAnimation.CrossFade(this.IdleAnim);
					}
					this.Student.CharacterAnimation[this.IdleAnim].time = this.Yandere.CharacterAnimation["f02_carryIdleA_00"].time;
					this.Student.CharacterAnimation[this.WalkAnim].time = this.Yandere.CharacterAnimation["f02_carryWalkA_00"].time;
					this.Student.CharacterAnimation[this.RunAnim].time = this.Yandere.CharacterAnimation["f02_carryRunA_00"].time;
				}
			}
			if (this.Carried)
			{
				if (this.Male)
				{
					Rigidbody rigidbody = this.AllRigidbodies[0];
					rigidbody.transform.parent.transform.localPosition = new Vector3(rigidbody.transform.parent.transform.localPosition.x, 0.2f, rigidbody.transform.parent.transform.localPosition.z);
				}
				if (this.Yandere.Struggling || this.Yandere.DelinquentFighting || this.Yandere.Sprayed)
				{
					this.Fall();
				}
			}
		}
	}

	public void StopDragging()
	{
		foreach (Rigidbody rigidbody in this.Student.Ragdoll.AllRigidbodies)
		{
			rigidbody.drag = 0f;
		}
		if (ClassGlobals.PhysicalGrade + ClassGlobals.PhysicalBonus > 0 && !this.Tranquil)
		{
			this.Prompt.HideButton[3] = false;
		}
		this.Prompt.AcceptingInput[1] = false;
		this.Prompt.Circle[1].fillAmount = 1f;
		this.Prompt.Label[1].text = "     Drag";
		this.Yandere.RagdollDragger.connectedBody = null;
		this.Yandere.RagdollPK.connectedBody = null;
		this.Yandere.Dragging = false;
		this.Yandere.Ragdoll = null;
		this.Yandere.StudentManager.UpdateStudents(0);
		this.SettleTimer = 0f;
		this.Settled = false;
		this.Dragged = false;
	}

	private void PickNearestLimb()
	{
		this.NearestLimb = this.Limb[0];
		this.LimbID = 0;
		for (int i = 1; i < 4; i++)
		{
			Transform transform = this.Limb[i];
			if (Vector3.Distance(transform.position, this.Yandere.transform.position) < Vector3.Distance(this.NearestLimb.position, this.Yandere.transform.position))
			{
				this.NearestLimb = transform;
				this.LimbID = i;
			}
		}
	}

	public void Dump()
	{
		if (this.DumpType == RagdollDumpType.Incinerator)
		{
			base.transform.eulerAngles = this.Yandere.transform.eulerAngles;
			base.transform.position = this.Yandere.transform.position;
			this.Incinerator = this.Yandere.Incinerator;
			this.BloodPoolSpawner.enabled = false;
		}
		else if (this.DumpType == RagdollDumpType.TranqCase)
		{
			this.TranqCase = this.Yandere.TranqCase;
		}
		else if (this.DumpType == RagdollDumpType.WoodChipper)
		{
			this.WoodChipper = this.Yandere.WoodChipper;
		}
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Dumped = true;
		foreach (Rigidbody rigidbody in this.AllRigidbodies)
		{
			rigidbody.isKinematic = true;
		}
	}

	public void Fall()
	{
		base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.0001f, base.transform.position.z);
		this.Prompt.Label[1].text = "     Drag";
		this.Prompt.HideButton[1] = false;
		this.Prompt.enabled = true;
		if (ClassGlobals.PhysicalGrade + ClassGlobals.PhysicalBonus > 0 && !this.Tranquil)
		{
			this.Prompt.HideButton[3] = false;
		}
		if (this.Dragged)
		{
			this.Yandere.RagdollDragger.connectedBody = null;
			this.Yandere.RagdollPK.connectedBody = null;
			this.Yandere.Dragging = false;
			this.Dragged = false;
		}
		this.Yandere.Ragdoll = null;
		this.Prompt.MyCollider.enabled = true;
		this.BloodPoolSpawner.NearbyBlood = 0;
		this.StopAnimation = true;
		this.SettleTimer = 0f;
		this.Carried = false;
		this.Settled = false;
		this.Falling = true;
		for (int i = 0; i < this.AllRigidbodies.Length; i++)
		{
			this.AllRigidbodies[i].isKinematic = false;
			this.AllColliders[i].enabled = true;
		}
	}

	public void Dismember()
	{
		if (!this.Dismembered)
		{
			this.Student.LiquidProjector.material.mainTexture = this.Student.BloodTexture;
			for (int i = 0; i < this.BodyParts.Length; i++)
			{
				if (this.Decapitated)
				{
					i++;
					this.Decapitated = false;
				}
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BodyParts[i], this.SpawnPoints[i].position, Quaternion.identity);
				gameObject.transform.eulerAngles = this.SpawnPoints[i].eulerAngles;
				gameObject.GetComponent<BodyPartScript>().StudentID = this.StudentID;
				gameObject.GetComponent<BodyPartScript>().Sacrifice = this.Sacrifice;
				if (this.Yandere.StudentManager.NoGravity)
				{
					gameObject.GetComponent<Rigidbody>().useGravity = false;
				}
				if (i == 0)
				{
					if (!this.Student.OriginallyTeacher)
					{
						if (!this.Male)
						{
							this.Student.Cosmetic.FemaleHair[this.Student.Cosmetic.Hairstyle].transform.parent = gameObject.transform;
							if (this.Student.Cosmetic.FemaleAccessories[this.Student.Cosmetic.Accessory] != null && this.Student.Cosmetic.Accessory != 3 && this.Student.Cosmetic.Accessory != 6)
							{
								this.Student.Cosmetic.FemaleAccessories[this.Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
							}
						}
						else
						{
							Transform transform = this.Student.Cosmetic.MaleHair[this.Student.Cosmetic.Hairstyle].transform;
							transform.parent = gameObject.transform;
							transform.localScale *= 1.06382978f;
							if (transform.transform.localPosition.y < -1f)
							{
								transform.transform.localPosition = new Vector3(transform.transform.localPosition.x, transform.transform.localPosition.y - 0.095f, transform.transform.localPosition.z);
							}
							if (this.Student.Cosmetic.MaleAccessories[this.Student.Cosmetic.Accessory] != null)
							{
								this.Student.Cosmetic.MaleAccessories[this.Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
							}
						}
					}
					else
					{
						this.Student.Cosmetic.TeacherHair[this.Student.Cosmetic.Hairstyle].transform.parent = gameObject.transform;
						if (this.Student.Cosmetic.TeacherAccessories[this.Student.Cosmetic.Accessory] != null)
						{
							this.Student.Cosmetic.TeacherAccessories[this.Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
						}
					}
					if (this.Student.Club != ClubType.Photography && this.Student.Club < ClubType.Gaming && this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club] != null)
					{
						this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club].transform.parent = gameObject.transform;
						if (this.Student.Club == ClubType.Occult)
						{
							if (!this.Male)
							{
								this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club].transform.localPosition = new Vector3(0f, -1.5f, 0.01f);
								this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club].transform.localEulerAngles = Vector3.zero;
							}
							else
							{
								this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club].transform.localPosition = new Vector3(0f, -1.42f, 0.005f);
								this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club].transform.localEulerAngles = Vector3.zero;
							}
						}
					}
					gameObject.GetComponent<Renderer>().materials[0].mainTexture = this.Student.Cosmetic.FaceTexture;
					if (i == 0)
					{
						gameObject.transform.position += new Vector3(0f, 1f, 0f);
					}
				}
				else if (i == 1)
				{
					if (this.Student.Club == ClubType.Photography && this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club] != null)
					{
						this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club].transform.parent = gameObject.transform;
					}
				}
				else if (i == 2 && !this.Student.Male && this.Student.Cosmetic.Accessory == 6)
				{
					this.Student.Cosmetic.FemaleAccessories[this.Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
				}
			}
			if (this.BloodPoolSpawner.BloodParent == null)
			{
				this.BloodPoolSpawner.Start();
			}
			this.BloodPoolSpawner.SpawnBigPool();
			this.Police.BodyParts += 6;
			this.Yandere.NearBodies--;
			this.Police.Corpses--;
			UnityEngine.Object.Destroy(base.gameObject);
			this.Dismembered = true;
		}
	}

	public void Remove()
	{
		if (this.AddingToCount)
		{
			this.Yandere.NearBodies--;
		}
		if (this.Poisoned)
		{
			this.Police.PoisonScene = false;
		}
		base.gameObject.SetActive(false);
	}
}
