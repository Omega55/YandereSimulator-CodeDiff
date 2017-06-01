using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
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

	public bool StopAnimation;

	public bool Decapitated;

	public bool Dismembered;

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

	public int DumpType;

	public int LimbID;

	public int Frame;

	public string DumpedAnim;

	public string LiftAnim;

	public string IdleAnim;

	public string WalkAnim;

	public string RunAnim;

	public RagdollScript()
	{
		this.StopAnimation = true;
		this.DumpedAnim = string.Empty;
		this.LiftAnim = string.Empty;
		this.IdleAnim = string.Empty;
		this.WalkAnim = string.Empty;
		this.RunAnim = string.Empty;
	}

	public virtual void Start()
	{
		Physics.IgnoreLayerCollision(11, 13, true);
		this.Zs.active = this.Tranquil;
		if (!this.Tranquil && !this.Poisoned && !this.Drowned && !this.Electrocuted && !this.Burning)
		{
			this.BloodPoolSpawner.gameObject.active = true;
			if (this.Pushed)
			{
				this.BloodPoolSpawner.Timer = (float)5;
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
		if (PlayerPrefs.GetInt("PhysicalGrade") + PlayerPrefs.GetInt("PhysicalBonus") > 0 && !this.Tranquil)
		{
			this.Prompt.HideButton[3] = false;
		}
	}

	public virtual void Update()
	{
		if (!this.Dragged && !this.Carried && !this.Settled && !this.Yandere.PK && !this.Yandere.StudentManager.NoGravity)
		{
			this.SettleTimer += Time.deltaTime;
			if (this.SettleTimer > (float)5)
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
				float a = Mathf.MoveTowards(this.DetectionMarker.Tex.color.a, (float)0, Time.deltaTime * (float)10);
				Color color = this.DetectionMarker.Tex.color;
				float num = color.a = a;
				Color color2 = this.DetectionMarker.Tex.color = color;
			}
			else
			{
				int num2 = 0;
				Color color3 = this.DetectionMarker.Tex.color;
				float num3 = color3.a = (float)num2;
				Color color4 = this.DetectionMarker.Tex.color = color3;
				this.DetectionMarker = null;
			}
		}
		if (!this.Dumped)
		{
			if (this.StopAnimation && this.Character.animation.isPlaying)
			{
				this.Character.animation.Stop();
			}
			if (!Input.GetButtonDown("LB"))
			{
				if (!this.Cauterized)
				{
					if (this.Yandere.PickUp != null)
					{
						if (this.Yandere.PickUp.Blowtorch)
						{
							if (!this.Cauterizable)
							{
								this.Prompt.Label[0].text = "     " + "Cauterize";
								this.Cauterizable = true;
							}
						}
						else if (this.Cauterizable)
						{
							this.Prompt.Label[0].text = "     " + "Dismember";
							this.Cauterizable = false;
						}
					}
					else if (this.Cauterizable)
					{
						this.Prompt.Label[0].text = "     " + "Dismember";
						this.Cauterizable = false;
					}
				}
				if (this.Prompt.Circle[0].fillAmount <= (float)0)
				{
					if (this.Cauterizable)
					{
						this.Prompt.Label[0].text = "     " + "Dismember";
						this.BloodPoolSpawner.enabled = false;
						this.Cauterizable = false;
						this.Cauterized = true;
						this.Yandere.CharacterAnimation.CrossFade("f02_cauterize_00");
						this.Yandere.Cauterizing = true;
						this.Yandere.CanMove = false;
						((BlowtorchScript)this.Yandere.PickUp.GetComponent(typeof(BlowtorchScript))).enabled = true;
						this.Yandere.PickUp.audio.Play();
					}
					else
					{
						this.Yandere.Character.animation.CrossFade("f02_dismember_00");
						this.Yandere.transform.LookAt(this.transform);
						this.Yandere.RPGCamera.transform.position = this.Yandere.DismemberSpot.position;
						this.Yandere.RPGCamera.transform.eulerAngles = this.Yandere.DismemberSpot.eulerAngles;
						this.Yandere.Weapon[this.Yandere.Equipped].Dismember();
						this.Yandere.RPGCamera.enabled = false;
						this.Yandere.TargetStudent = this.Student;
						this.Yandere.Ragdoll = this.gameObject;
						this.Yandere.Dismembering = true;
						this.Yandere.CanMove = false;
					}
				}
				if (this.Prompt.Circle[1].fillAmount <= (float)0)
				{
					this.Prompt.Circle[1].fillAmount = (float)1;
					if (!this.Dragged)
					{
						this.Yandere.EmptyHands();
						this.Prompt.AcceptingInput[1] = false;
						this.Prompt.Label[1].text = "     " + "Drop";
						this.PickNearestLimb();
						this.Yandere.RagdollDragger.connectedBody = this.Rigidbodies[this.LimbID];
						this.Yandere.RagdollDragger.connectedAnchor = this.LimbAnchor[this.LimbID];
						this.Yandere.Dragging = true;
						this.Yandere.DragState = 0;
						this.Yandere.Ragdoll = this.gameObject;
						this.Dragged = true;
						this.Yandere.StudentManager.UpdateStudents();
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
						for (int i = 0; i < Extensions.get_length(this.Student.Ragdoll.AllRigidbodies); i++)
						{
							this.Student.Ragdoll.AllRigidbodies[i].drag = (float)2;
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
					}
					else
					{
						this.StopDragging();
					}
				}
				if (this.Prompt.Circle[3].fillAmount <= (float)0)
				{
					this.Yandere.EmptyHands();
					this.Prompt.Label[1].text = "     " + "Drop";
					this.Prompt.HideButton[1] = true;
					this.Prompt.HideButton[3] = true;
					this.Prompt.enabled = false;
					this.Prompt.Hide();
					for (int i = 0; i < this.AllRigidbodies.Length; i++)
					{
						this.AllRigidbodies[i].isKinematic = true;
						this.AllColliders[i].enabled = false;
					}
					if (this.Male)
					{
						float y = 0.2f;
						Vector3 localPosition = this.AllRigidbodies[0].transform.parent.transform.localPosition;
						float num4 = localPosition.y = y;
						Vector3 vector = this.AllRigidbodies[0].transform.parent.transform.localPosition = localPosition;
					}
					this.Yandere.Character.animation.Play("f02_carryLiftA_00");
					this.Character.animation.Play(this.LiftAnim);
					this.BloodSpawnerCollider.enabled = false;
					int num5 = 0;
					Vector3 localEulerAngles = this.PelvisRoot.localEulerAngles;
					float num6 = localEulerAngles.y = (float)num5;
					Vector3 vector2 = this.PelvisRoot.localEulerAngles = localEulerAngles;
					this.Prompt.MyCollider.enabled = false;
					int num7 = 0;
					Vector3 localPosition2 = this.PelvisRoot.localPosition;
					float num8 = localPosition2.z = (float)num7;
					Vector3 vector3 = this.PelvisRoot.localPosition = localPosition2;
					this.Yandere.Ragdoll = this.gameObject;
					this.Yandere.CanMove = false;
					this.Yandere.Lifting = true;
					this.StopAnimation = false;
					this.Carried = true;
					this.Falling = false;
					this.FallTimer = (float)0;
				}
			}
			else if (!this.Yandere.Dumping && this.Dragged)
			{
				this.StopDragging();
			}
			if (Vector3.Distance(this.Yandere.transform.position, this.Prompt.transform.position) < (float)2)
			{
				if (!this.AddingToCount)
				{
					this.Yandere.NearBodies = this.Yandere.NearBodies + 1;
					this.AddingToCount = true;
				}
			}
			else if (this.AddingToCount)
			{
				this.Yandere.NearBodies = this.Yandere.NearBodies - 1;
				this.AddingToCount = false;
			}
			if (!this.Prompt.AcceptingInput[1] && Input.GetButtonUp("B"))
			{
				this.Prompt.AcceptingInput[1] = true;
			}
			bool flag = false;
			if (this.Yandere.Armed && this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 7)
			{
				flag = true;
			}
			if (!this.Cauterized && this.Yandere.PickUp != null && this.Yandere.PickUp.Blowtorch)
			{
				flag = true;
			}
			if (!this.Dragged && !this.Carried && !this.Tranquil && flag && !this.Nemesis)
			{
				this.Prompt.HideButton[0] = false;
			}
			else
			{
				this.Prompt.HideButton[0] = true;
			}
		}
		else if (this.DumpType == 1)
		{
			if (this.DumpTimer == (float)0 && this.Yandere.Carrying)
			{
				this.Character.animation[this.DumpedAnim].time = 2.5f;
			}
			this.Character.animation.CrossFade(this.DumpedAnim);
			this.DumpTimer += Time.deltaTime;
			if (this.Character.animation[this.DumpedAnim].time >= this.Character.animation[this.DumpedAnim].length)
			{
				this.Incinerator.Corpses = this.Incinerator.Corpses + 1;
				this.Incinerator.CorpseList[this.Incinerator.Corpses] = this.StudentID;
				this.Remove();
			}
		}
		else if (this.DumpType == 2)
		{
			if (this.DumpTimer == (float)0 && this.Yandere.Carrying)
			{
				this.Character.animation[this.DumpedAnim].time = 2.5f;
			}
			this.Character.animation.CrossFade(this.DumpedAnim);
			this.DumpTimer += Time.deltaTime;
			if (this.Character.animation[this.DumpedAnim].time >= this.Character.animation[this.DumpedAnim].length)
			{
				this.TranqCase.Open = false;
				if (this.AddingToCount)
				{
					this.Yandere.NearBodies = this.Yandere.NearBodies - 1;
				}
			}
		}
		else if (this.DumpType == 3)
		{
			if (this.DumpTimer == (float)0 && this.Yandere.Carrying)
			{
				this.Character.animation[this.DumpedAnim].time = 2.5f;
			}
			this.Character.animation.CrossFade(this.DumpedAnim);
			this.DumpTimer += Time.deltaTime;
			if (this.Character.animation[this.DumpedAnim].time >= this.Character.animation[this.DumpedAnim].length)
			{
				this.WoodChipper.VictimID = this.StudentID;
				this.Remove();
			}
		}
		if (this.Hidden && this.HideCollider == null)
		{
			this.Police.HiddenCorpses = this.Police.HiddenCorpses - 1;
			this.Hidden = false;
		}
		if (this.Falling)
		{
			this.FallTimer += Time.deltaTime;
			if (this.FallTimer > (float)2)
			{
				this.BloodSpawnerCollider.enabled = true;
				this.FallTimer = (float)0;
				this.Falling = false;
			}
		}
		if (this.Burning)
		{
			this.MyRenderer.materials[0].color = Vector4.MoveTowards(this.MyRenderer.materials[0].color, new Vector4(0.1f, 0.1f, 0.1f, (float)1), Time.deltaTime * 0.1f);
			this.MyRenderer.materials[1].color = Vector4.MoveTowards(this.MyRenderer.materials[1].color, new Vector4(0.1f, 0.1f, 0.1f, (float)1), Time.deltaTime * 0.1f);
			this.MyRenderer.materials[2].color = Vector4.MoveTowards(this.MyRenderer.materials[2].color, new Vector4(0.1f, 0.1f, 0.1f, (float)1), Time.deltaTime * 0.1f);
			this.Student.Cosmetic.HairRenderer.material.color = Vector4.MoveTowards(this.Student.Cosmetic.HairRenderer.material.color, new Vector4(0.1f, 0.1f, 0.1f, (float)1), Time.deltaTime * 0.1f);
			if (this.MyRenderer.materials[0].color == new Vector4(0.1f, 0.1f, 0.1f, (float)1))
			{
				this.Burning = false;
				this.Burned = true;
			}
		}
		if (this.Burned)
		{
			if (Vector3.Distance(this.Prompt.transform.position, this.Yandere.StudentManager.SacrificeSpot.position) < 1.5f)
			{
				this.Sacrifice = true;
			}
			else
			{
				this.Sacrifice = false;
			}
		}
	}

	public virtual void LateUpdate()
	{
		if (!this.Male)
		{
			float z = this.LeftEyeOrigin.z - this.EyeShrink * 0.01f;
			Vector3 localPosition = this.LeftEye.localPosition;
			float num = localPosition.z = z;
			Vector3 vector = this.LeftEye.localPosition = localPosition;
			float z2 = this.RightEyeOrigin.z + this.EyeShrink * 0.01f;
			Vector3 localPosition2 = this.RightEye.localPosition;
			float num2 = localPosition2.z = z2;
			Vector3 vector2 = this.RightEye.localPosition = localPosition2;
			float x = (float)1 - this.EyeShrink * 0.5f;
			Vector3 localScale = this.LeftEye.localScale;
			float num3 = localScale.x = x;
			Vector3 vector3 = this.LeftEye.localScale = localScale;
			float y = (float)1 - this.EyeShrink * 0.5f;
			Vector3 localScale2 = this.LeftEye.localScale;
			float num4 = localScale2.y = y;
			Vector3 vector4 = this.LeftEye.localScale = localScale2;
			float x2 = (float)1 - this.EyeShrink * 0.5f;
			Vector3 localScale3 = this.RightEye.localScale;
			float num5 = localScale3.x = x2;
			Vector3 vector5 = this.RightEye.localScale = localScale3;
			float y2 = (float)1 - this.EyeShrink * 0.5f;
			Vector3 localScale4 = this.RightEye.localScale;
			float num6 = localScale4.y = y2;
			Vector3 vector6 = this.RightEye.localScale = localScale4;
			if (this.StudentID == 32)
			{
				float y3 = 0.66666f;
				Vector3 localScale5 = this.Student.Skirt[0].transform.localScale;
				float num7 = localScale5.y = y3;
				Vector3 vector7 = this.Student.Skirt[0].transform.localScale = localScale5;
				float y4 = 0.66666f;
				Vector3 localScale6 = this.Student.Skirt[1].transform.localScale;
				float num8 = localScale6.y = y4;
				Vector3 vector8 = this.Student.Skirt[1].transform.localScale = localScale6;
				float y5 = 0.66666f;
				Vector3 localScale7 = this.Student.Skirt[2].transform.localScale;
				float num9 = localScale7.y = y5;
				Vector3 vector9 = this.Student.Skirt[2].transform.localScale = localScale7;
				float y6 = 0.66666f;
				Vector3 localScale8 = this.Student.Skirt[3].transform.localScale;
				float num10 = localScale8.y = y6;
				Vector3 vector10 = this.Student.Skirt[3].transform.localScale = localScale8;
			}
		}
		if (this.Decapitated)
		{
			this.Head.localScale = new Vector3((float)0, (float)0, (float)0);
		}
		if (this.Yandere.Ragdoll == this.gameObject)
		{
			if (this.Yandere.DumpTimer < (float)1)
			{
				if (this.Yandere.Lifting)
				{
					this.transform.position = this.Yandere.transform.position;
					this.transform.eulerAngles = this.Yandere.transform.eulerAngles;
				}
				else if (this.Carried)
				{
					this.transform.position = this.Yandere.transform.position;
					this.transform.eulerAngles = this.Yandere.transform.eulerAngles;
					float axis = Input.GetAxis("Vertical");
					float axis2 = Input.GetAxis("Horizontal");
					if (axis != (float)0 || axis2 != (float)0)
					{
						if (Input.GetButton("LB"))
						{
							this.Character.animation.CrossFade(this.RunAnim);
						}
						else
						{
							this.Character.animation.CrossFade(this.WalkAnim);
						}
					}
					else
					{
						this.Character.animation.CrossFade(this.IdleAnim);
					}
					this.Character.animation[this.IdleAnim].time = this.Yandere.Character.animation["f02_carryIdleA_00"].time;
					this.Character.animation[this.WalkAnim].time = this.Yandere.Character.animation["f02_carryWalkA_00"].time;
					this.Character.animation[this.RunAnim].time = this.Yandere.Character.animation["f02_carryRunA_00"].time;
				}
			}
			if (this.Carried && this.Male)
			{
				float y7 = 0.2f;
				Vector3 localPosition3 = this.AllRigidbodies[0].transform.parent.transform.localPosition;
				float num11 = localPosition3.y = y7;
				Vector3 vector11 = this.AllRigidbodies[0].transform.parent.transform.localPosition = localPosition3;
			}
		}
	}

	public virtual void StopDragging()
	{
		for (int i = 0; i < Extensions.get_length(this.Student.Ragdoll.AllRigidbodies); i++)
		{
			this.Student.Ragdoll.AllRigidbodies[i].drag = (float)0;
		}
		if (PlayerPrefs.GetInt("PhysicalGrade") + PlayerPrefs.GetInt("PhysicalBonus") > 0 && !this.Tranquil)
		{
			this.Prompt.HideButton[3] = false;
		}
		this.Prompt.AcceptingInput[1] = false;
		this.Prompt.Circle[1].fillAmount = (float)1;
		this.Prompt.Label[1].text = "     " + "Drag";
		this.Yandere.RagdollDragger.connectedBody = null;
		this.Yandere.RagdollPK.connectedBody = null;
		this.Yandere.Dragging = false;
		this.Yandere.Ragdoll = null;
		this.Yandere.StudentManager.UpdateStudents();
		this.SettleTimer = (float)0;
		this.Settled = false;
		this.Dragged = false;
	}

	public virtual void PickNearestLimb()
	{
		this.NearestLimb = this.Limb[0];
		this.LimbID = 0;
		for (int i = 1; i < 4; i++)
		{
			if (Vector3.Distance(this.Limb[i].position, this.Yandere.transform.position) < Vector3.Distance(this.NearestLimb.position, this.Yandere.transform.position))
			{
				this.NearestLimb = this.Limb[i];
				this.LimbID = i;
			}
		}
	}

	public virtual void Dump()
	{
		if (this.DumpType == 1)
		{
			this.transform.eulerAngles = this.Yandere.transform.eulerAngles;
			this.transform.position = this.Yandere.transform.position;
			this.Incinerator = this.Yandere.Incinerator;
			this.BloodPoolSpawner.enabled = false;
		}
		else if (this.DumpType == 2)
		{
			this.TranqCase = this.Yandere.TranqCase;
		}
		else if (this.DumpType == 3)
		{
			this.WoodChipper = this.Yandere.WoodChipper;
		}
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Dumped = true;
		for (int i = 0; i < this.AllRigidbodies.Length; i++)
		{
			this.AllRigidbodies[i].isKinematic = true;
		}
	}

	public virtual void Fall()
	{
		float y = this.transform.position.y + 0.0001f;
		Vector3 position = this.transform.position;
		float num = position.y = y;
		Vector3 vector = this.transform.position = position;
		this.Prompt.Label[1].text = "     " + "Drag";
		this.Prompt.HideButton[1] = false;
		this.Prompt.enabled = true;
		if (PlayerPrefs.GetInt("PhysicalGrade") + PlayerPrefs.GetInt("PhysicalBonus") > 0 && !this.Tranquil)
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
		this.SettleTimer = (float)0;
		this.Carried = false;
		this.Settled = false;
		this.Falling = true;
		for (int i = 0; i < this.AllRigidbodies.Length; i++)
		{
			this.AllRigidbodies[i].isKinematic = false;
			this.AllColliders[i].enabled = true;
		}
	}

	public virtual void Dismember()
	{
		if (!this.Dismembered)
		{
			this.Student.LiquidProjector.material.mainTexture = this.Student.BloodTexture;
			for (int i = 0; i < this.BodyParts.Length; i++)
			{
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BodyParts[i], this.SpawnPoints[i].position, Quaternion.identity);
				gameObject.transform.eulerAngles = this.SpawnPoints[i].eulerAngles;
				((BodyPartScript)gameObject.GetComponent(typeof(BodyPartScript))).StudentID = this.StudentID;
				((BodyPartScript)gameObject.GetComponent(typeof(BodyPartScript))).Sacrifice = this.Sacrifice;
				if (this.Yandere.StudentManager.NoGravity)
				{
					gameObject.rigidbody.useGravity = false;
				}
				if (i == 0)
				{
					if (!this.Student.OriginallyTeacher)
					{
						if (!this.Male)
						{
							this.Student.Cosmetic.FemaleHair[this.Student.Cosmetic.Hairstyle].transform.parent = gameObject.transform;
							if (this.Student.Cosmetic.FemaleAccessories[this.Student.Cosmetic.Accessory] != null && this.Student.Cosmetic.Accessory != 3)
							{
								this.Student.Cosmetic.FemaleAccessories[this.Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
							}
						}
						else
						{
							Transform transform = this.Student.Cosmetic.MaleHair[this.Student.Cosmetic.Hairstyle].transform;
							transform.parent = gameObject.transform;
							float x = transform.localScale.x * 1.06382978f;
							Vector3 localScale = transform.localScale;
							float num = localScale.x = x;
							Vector3 vector = transform.localScale = localScale;
							float y = transform.localScale.y * 1.06382978f;
							Vector3 localScale2 = transform.localScale;
							float num2 = localScale2.y = y;
							Vector3 vector2 = transform.localScale = localScale2;
							float z = transform.localScale.z * 1.06382978f;
							Vector3 localScale3 = transform.localScale;
							float num3 = localScale3.z = z;
							Vector3 vector3 = transform.localScale = localScale3;
							float y2 = transform.transform.localPosition.y - 0.1f;
							Vector3 localPosition = transform.transform.localPosition;
							float num4 = localPosition.y = y2;
							Vector3 vector4 = transform.transform.localPosition = localPosition;
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
					if (this.Student.Club < 11 && this.Student.Cosmetic.ClubAccessories[this.Student.Club] != null)
					{
						this.Student.Cosmetic.ClubAccessories[this.Student.Club].transform.parent = gameObject.transform;
						if (this.Student.Club == 3)
						{
							if (!this.Male)
							{
								this.Student.Cosmetic.ClubAccessories[this.Student.Club].transform.localPosition = new Vector3((float)0, -1.5f, 0.01f);
								this.Student.Cosmetic.ClubAccessories[this.Student.Club].transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
							}
							else
							{
								this.Student.Cosmetic.ClubAccessories[this.Student.Club].transform.localPosition = new Vector3((float)0, -1.42f, 0.005f);
								this.Student.Cosmetic.ClubAccessories[this.Student.Club].transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
							}
						}
					}
					((Renderer)gameObject.GetComponent(typeof(Renderer))).materials[0].mainTexture = this.Student.Cosmetic.FaceTexture;
				}
			}
			if (this.BloodPoolSpawner.BloodParent == null)
			{
				this.BloodPoolSpawner.Start();
			}
			this.BloodPoolSpawner.SpawnBigPool();
			this.Police.BodyParts = this.Police.BodyParts + 6;
			this.Yandere.NearBodies = this.Yandere.NearBodies - 1;
			this.Police.Corpses = this.Police.Corpses - 1;
			UnityEngine.Object.Destroy(this.gameObject);
			this.Dismembered = true;
		}
	}

	public virtual void Remove()
	{
		if (this.AddingToCount)
		{
			this.Yandere.NearBodies = this.Yandere.NearBodies - 1;
		}
		if (this.Poisoned)
		{
			this.Police.PoisonScene = false;
		}
		this.active = false;
	}

	public virtual void Main()
	{
	}
}
