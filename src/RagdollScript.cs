using System;
using UnityEngine;

[Serializable]
public class RagdollScript : MonoBehaviour
{
	public BloodPoolSpawnerScript BloodPoolSpawner;

	public DetectionMarkerScript DetectionMarker;

	public IncineratorScript Incinerator;

	public TranqCaseScript TranqCase;

	public StudentScript Student;

	public YandereScript Yandere;

	public PoliceScript Police;

	public PromptScript Prompt;

	public SkinnedMeshRenderer MyRenderer;

	public Collider BloodSpawnerCollider;

	public Collider HideCollider;

	public Rigidbody[] AllRigidbodies;

	public Collider[] AllColliders;

	public Rigidbody[] Rigidbodies;

	public Transform[] SpawnPoints;

	public GameObject[] BodyParts;

	public Transform NearestLimb;

	public Transform RightBreast;

	public Transform LeftBreast;

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

	public bool Electrocuted;

	public bool StopAnimation;

	public bool Dismembered;

	public bool Sacrifice;

	public bool Poisoned;

	public bool Tranquil;

	public bool Carried;

	public bool Dragged;

	public bool Drowned;

	public bool Suicide;

	public bool Dumped;

	public bool Hidden;

	public bool Pushed;

	public bool Male;

	public float AnimStartTime;

	public float BreastSize;

	public float DumpTimer;

	public float EyeShrink;

	public int StudentID;

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
		if (!this.Tranquil && !this.Poisoned && !this.Drowned && !this.Electrocuted)
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
		}
		this.Prompt.enabled = true;
		if (PlayerPrefs.GetInt("PhysicalGrade") > 0 && !this.Tranquil)
		{
			this.Prompt.HideButton[3] = false;
		}
	}

	public virtual void Update()
	{
		if (this.DetectionMarker != null)
		{
			float a = Mathf.MoveTowards(this.DetectionMarker.Tex.color.a, (float)0, Time.deltaTime * (float)10);
			Color color = this.DetectionMarker.Tex.color;
			float num = color.a = a;
			Color color2 = this.DetectionMarker.Tex.color = color;
		}
		if (!this.Dumped)
		{
			if (this.StopAnimation)
			{
				this.Character.animation.Stop();
			}
			if (!Input.GetButtonDown("LB"))
			{
				if (this.Prompt.Circle[0].fillAmount <= (float)0)
				{
					this.Yandere.Character.animation.CrossFade("f02_dismember_00");
					this.Yandere.transform.LookAt(this.transform);
					this.Yandere.RPGCamera.transform.position = this.Yandere.DismemberSpot.position;
					this.Yandere.RPGCamera.transform.eulerAngles = this.Yandere.DismemberSpot.eulerAngles;
					this.Yandere.Weapon[this.Yandere.Equipped].Dismember();
					this.Yandere.RPGCamera.enabled = false;
					this.Yandere.Ragdoll = this.gameObject;
					this.Yandere.Dismembering = true;
					this.Yandere.CanMove = false;
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
						this.Yandere.Ragdoll = this.gameObject;
						this.Dragged = true;
						this.Yandere.StudentManager.UpdateStudents();
						if (this.Suicide)
						{
							this.Police.Suicide = false;
							this.Suicide = false;
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
					for (int i = 0; i < this.AllRigidbodies.Length; i++)
					{
						this.AllRigidbodies[i].isKinematic = true;
						this.AllColliders[i].enabled = false;
					}
					if (this.Male)
					{
						float y = 0.2f;
						Vector3 localPosition = this.AllRigidbodies[0].transform.parent.transform.localPosition;
						float num2 = localPosition.y = y;
						Vector3 vector = this.AllRigidbodies[0].transform.parent.transform.localPosition = localPosition;
					}
					this.Yandere.Character.animation.Play("f02_carryLiftA_00");
					this.Character.animation.Play(this.LiftAnim);
					this.BloodSpawnerCollider.enabled = false;
					this.Prompt.MyCollider.enabled = false;
					this.Yandere.Ragdoll = this.gameObject;
					this.Yandere.CanMove = false;
					this.Yandere.Lifting = true;
					this.StopAnimation = false;
					this.Carried = true;
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
			if (!this.Dragged && !this.Carried && !this.Tranquil && this.Yandere.Armed && this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 7)
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
			if (this.Incinerator != null)
			{
				if (this.DumpTimer == (float)0 && this.Yandere.Carrying)
				{
					this.Character.animation[this.DumpedAnim].time = 2.5f;
				}
				this.Character.animation.CrossFade(this.DumpedAnim);
				this.DumpTimer += Time.deltaTime;
				if (this.Character.animation[this.DumpedAnim].time >= this.Character.animation[this.DumpedAnim].length)
				{
					if (this.AddingToCount)
					{
						this.Yandere.NearBodies = this.Yandere.NearBodies - 1;
					}
					if (this.Poisoned)
					{
						this.Police.PoisonScene = false;
					}
					this.Incinerator.Corpses = this.Incinerator.Corpses + 1;
					this.Incinerator.CorpseList[this.Incinerator.Corpses] = this.StudentID;
					this.active = false;
				}
			}
			if (this.TranqCase != null)
			{
				this.Character.animation.Play("f02_fetal_00");
				float y2 = Mathf.MoveTowards(this.transform.localPosition.y, 0.36f, Time.deltaTime);
				Vector3 localPosition2 = this.transform.localPosition;
				float num3 = localPosition2.y = y2;
				Vector3 vector2 = this.transform.localPosition = localPosition2;
				if (this.transform.localPosition.y == 0.36f)
				{
					this.TranqCase.Open = false;
					if (this.AddingToCount)
					{
						this.Yandere.NearBodies = this.Yandere.NearBodies - 1;
					}
				}
			}
		}
		if (this.Hidden && this.HideCollider == null)
		{
			this.Police.HiddenCorpses = this.Police.HiddenCorpses - 1;
			this.Hidden = false;
		}
	}

	public virtual void LateUpdate()
	{
		if (!this.Male)
		{
			this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
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
				float y3 = 0.2f;
				Vector3 localPosition3 = this.AllRigidbodies[0].transform.parent.transform.localPosition;
				float num7 = localPosition3.y = y3;
				Vector3 vector7 = this.AllRigidbodies[0].transform.parent.transform.localPosition = localPosition3;
			}
		}
	}

	public virtual void StopDragging()
	{
		this.Prompt.AcceptingInput[1] = false;
		this.Prompt.Circle[1].fillAmount = (float)1;
		this.Prompt.Label[1].text = "     " + "Drag";
		this.Yandere.RagdollDragger.connectedBody = null;
		this.Yandere.RagdollPK.connectedBody = null;
		this.Yandere.Dragging = false;
		this.Yandere.Ragdoll = null;
		this.Yandere.StudentManager.UpdateStudents();
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

	public virtual void Dump(int Type)
	{
		if (Type == 1)
		{
			this.transform.eulerAngles = this.Yandere.transform.eulerAngles;
			this.transform.position = this.Yandere.transform.position;
			this.Incinerator = this.Yandere.Incinerator;
			this.BloodPoolSpawner.enabled = false;
		}
		else
		{
			this.TranqCase = this.Yandere.TranqCase;
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
		if (PlayerPrefs.GetInt("PhysicalGrade") > 0 && !this.Tranquil)
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
		this.BloodSpawnerCollider.enabled = true;
		this.Prompt.MyCollider.enabled = true;
		this.StopAnimation = true;
		this.Carried = false;
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
			for (int i = 0; i < this.BodyParts.Length; i++)
			{
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BodyParts[i], this.SpawnPoints[i].position, Quaternion.identity);
				gameObject.transform.eulerAngles = this.SpawnPoints[i].eulerAngles;
				((BodyPartScript)gameObject.GetComponent(typeof(BodyPartScript))).StudentID = this.StudentID;
				((BodyPartScript)gameObject.GetComponent(typeof(BodyPartScript))).Sacrifice = this.Sacrifice;
				if (i == 0)
				{
					if (!this.Student.Teacher)
					{
						if (!this.Male)
						{
							this.Student.Cosmetic.FemaleHair[this.Student.Cosmetic.Hairstyle].transform.parent = gameObject.transform;
							this.Student.Cosmetic.FemaleHair[this.Student.Cosmetic.Hairstyle].transform.parent = gameObject.transform;
							if (this.Student.Cosmetic.FemaleAccessories[this.Student.Cosmetic.Accessory] != null)
							{
								this.Student.Cosmetic.FemaleAccessories[this.Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
							}
						}
						else
						{
							this.Student.Cosmetic.MaleHair[this.Student.Cosmetic.Hairstyle].transform.parent = gameObject.transform;
							this.Student.Cosmetic.MaleHair[this.Student.Cosmetic.Hairstyle].transform.parent = gameObject.transform;
							if (this.Student.Cosmetic.MaleAccessories[this.Student.Cosmetic.Accessory] != null)
							{
								this.Student.Cosmetic.MaleAccessories[this.Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
							}
						}
					}
					else
					{
						this.Student.Cosmetic.TeacherHair[this.Student.Cosmetic.Hairstyle].transform.parent = gameObject.transform;
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

	public virtual void Main()
	{
	}
}
