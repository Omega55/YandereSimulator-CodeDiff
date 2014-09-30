using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class StudentScript : MonoBehaviour
{
	public GameObject Character;

	public GameObject RagdollChan;

	public GameObject BloodSpray;

	public Transform WitnessViewpoint;

	public Transform LookAtTarget;

	public Transform Default;

	public Transform Neck;

	public AIPath Pathfinding;

	public MurderCamScript MurderCam;

	public YandereScript Yandere;

	public Plane[] Planes;

	public Camera Eyes;

	public float DistanceToPlayer;

	public bool PerformRandomAnim;

	public bool WitnessedMurder;

	public bool LookAtPlayer;

	public bool Fleeing;

	public bool Scared;

	public bool Dying;

	public float Timer;

	public Collider MyCollider;

	public string HitReactAnim;

	private Quaternion targetRotation;

	public string[] Animations;

	public string RandomAnim;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public Transform RightEye;

	public Transform LeftEye;

	public Transform RightHand;

	public Transform LeftHand;

	public Renderer MyRenderer;

	public Material[] YandereVisionMaterials;

	public Material[] OriginalMaterials;

	public int StudentID;

	public int StudentClub;

	public string StudentName;

	public string StudentCrush;

	public string StudentPortrait;

	public int StudentPersonality;

	public ControllerInventoryScript ControllerInventoryPanel;

	public GameObject ButtonObject;

	public GameObject LabelObject;

	public Transform ButtonPanel;

	public Camera UICamera;

	public UISprite Button;

	public UILabel Label;

	public bool InView;

	public StudentScript()
	{
		this.HitReactAnim = string.Empty;
		this.StudentName = string.Empty;
		this.StudentCrush = string.Empty;
		this.StudentPortrait = string.Empty;
	}

	public virtual void Start()
	{
		this.Character.animation.Play("student_idle");
		this.ControllerInventoryPanel = (ControllerInventoryScript)GameObject.Find("ControllerInventoryPanel").GetComponent(typeof(ControllerInventoryScript));
		this.MurderCam = (MurderCamScript)GameObject.Find("MurderCam").GetComponent(typeof(MurderCamScript));
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		this.ButtonPanel = (Transform)GameObject.Find("ButtonPanel").GetComponent(typeof(Transform));
		this.UICamera = (Camera)GameObject.Find("UI Camera").GetComponent(typeof(Camera));
		this.Button = (UISprite)((GameObject)UnityEngine.Object.Instantiate(this.ButtonObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UISprite));
		this.Button.transform.parent = this.ButtonPanel;
		this.Button.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		this.Button.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		int num = 0;
		Color color = this.Button.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Button.color = color;
		this.Label = (UILabel)((GameObject)UnityEngine.Object.Instantiate(this.LabelObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UILabel));
		this.Label.transform.parent = this.ButtonPanel;
		this.Label.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		this.Label.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		int num3 = 0;
		Color color3 = this.Label.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.Label.color = color3;
		this.Label.text = "     " + "Attack";
		this.PickNewRandomAnim();
		this.RightEyeOrigin = this.RightEye.localPosition;
		this.LeftEyeOrigin = this.LeftEye.localPosition;
		this.OriginalMaterials = this.MyRenderer.materials;
	}

	public virtual void Update()
	{
		if (!this.Dying)
		{
			if (this.Fleeing)
			{
				this.Character.animation.CrossFade("f02_sprint_00");
			}
			else if (this.WitnessedMurder)
			{
				this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
				this.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
				this.Character.animation.CrossFade("f02_greet_03");
				if (this.Character.animation["f02_greet_03"].time > this.Character.animation["f02_greet_03"].length * 0.35f)
				{
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.Fleeing = true;
				}
			}
			else if (this.Scared)
			{
				this.Character.animation.CrossFade("defensivePosture", 0.5f);
				this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
				this.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
			}
			else if (this.PerformRandomAnim)
			{
				this.Character.animation.CrossFade(this.RandomAnim);
				if (this.Character.animation[this.RandomAnim].time >= this.Character.animation[this.RandomAnim].length)
				{
					this.PickNewRandomAnim();
				}
			}
			this.DistanceToPlayer = Vector3.Distance(this.transform.position, this.Yandere.transform.position);
			if (this.DistanceToPlayer < (float)5 || this.LookAtPlayer)
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
							if (this.Yandere.YandereMeter == (float)100 || this.Yandere.Bloodiness > 0 || this.Yandere.Armed)
							{
								this.Scared = true;
								this.LookAtPlayer = true;
							}
							if (this.Yandere.Attacking && !this.WitnessedMurder && !this.MurderCam.ZoomIn)
							{
								this.MurderCam.WitnessViewpoint = this.WitnessViewpoint.position;
								this.MurderCam.MurderWitnessed();
								this.WitnessedMurder = true;
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
			this.DisplayButtonPrompt();
		}
		else
		{
			this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
			this.Timer += Time.deltaTime;
			if (this.Timer > 0.1f && this.Timer < 0.6f)
			{
				this.Character.animation.CrossFade("defensivePosture", 0.5f);
				this.transform.position = Vector3.Lerp(this.transform.position, this.Yandere.transform.position + this.Yandere.transform.forward * 0.125f, Time.deltaTime * (float)10);
			}
			if (this.Timer > 0.6f)
			{
				this.Character.animation.CrossFade(this.HitReactAnim);
				this.transform.Translate(Vector3.back * Time.deltaTime * 0.5f);
				if (!this.BloodSpray.active)
				{
					this.Yandere.Bloodiness = this.Yandere.Bloodiness + 1;
					this.Yandere.UpdateBlood();
					this.BloodSpray.active = true;
				}
			}
			if (this.Timer > 1.6f)
			{
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.RagdollChan, this.transform.position, this.transform.rotation);
				RagdollScript ragdollScript = (RagdollScript)gameObject.GetComponent(typeof(RagdollScript));
				ragdollScript.AnimName = this.HitReactAnim;
				ragdollScript.AnimTime = this.Character.animation[this.HitReactAnim].time;
				this.BloodSpray.transform.parent = ragdollScript.Neck;
				this.BloodSpray.transform.localPosition = new Vector3(-0.055f, 0.0188f, 0.0137f);
				UnityEngine.Object.Destroy(this.gameObject);
			}
		}
	}

	public virtual void LateUpdate()
	{
		if (!this.Dying)
		{
			if (!this.WitnessedMurder)
			{
				if (!this.LookAtPlayer)
				{
					this.LookAtTarget.position = Vector3.Lerp(this.LookAtTarget.position, this.Default.position, Time.deltaTime * (float)10);
				}
				else
				{
					this.LookAtTarget.position = Vector3.Lerp(this.LookAtTarget.position, this.Yandere.transform.position + Vector3.up * 1.45f, Time.deltaTime * (float)10);
				}
				this.Neck.LookAt(this.LookAtTarget.position);
				if (this.Scared)
				{
					float y = this.Neck.transform.localEulerAngles.y + (float)15;
					Vector3 localEulerAngles = this.Neck.transform.localEulerAngles;
					float num = localEulerAngles.y = y;
					Vector3 vector = this.Neck.transform.localEulerAngles = localEulerAngles;
				}
			}
			else
			{
				float z = this.LeftEyeOrigin.z - 0.01f;
				Vector3 localPosition = this.LeftEye.localPosition;
				float num2 = localPosition.z = z;
				Vector3 vector2 = this.LeftEye.localPosition = localPosition;
				float z2 = this.RightEyeOrigin.z + 0.01f;
				Vector3 localPosition2 = this.RightEye.localPosition;
				float num3 = localPosition2.z = z2;
				Vector3 vector3 = this.RightEye.localPosition = localPosition2;
				float x = 0.5f;
				Vector3 localScale = this.LeftEye.localScale;
				float num4 = localScale.x = x;
				Vector3 vector4 = this.LeftEye.localScale = localScale;
				float y2 = 0.5f;
				Vector3 localScale2 = this.LeftEye.localScale;
				float num5 = localScale2.y = y2;
				Vector3 vector5 = this.LeftEye.localScale = localScale2;
				float x2 = 0.5f;
				Vector3 localScale3 = this.RightEye.localScale;
				float num6 = localScale3.x = x2;
				Vector3 vector6 = this.RightEye.localScale = localScale3;
				float y3 = 0.5f;
				Vector3 localScale4 = this.RightEye.localScale;
				float num7 = localScale4.y = y3;
				Vector3 vector7 = this.RightEye.localScale = localScale4;
			}
		}
		int num8 = 0;
		Vector3 eulerAngles = this.transform.eulerAngles;
		float num9 = eulerAngles.x = (float)num8;
		Vector3 vector8 = this.transform.eulerAngles = eulerAngles;
	}

	public virtual void DisplayButtonPrompt()
	{
		if (this.InView)
		{
			if (!this.Dying)
			{
				if (this.DistanceToPlayer <= (float)1)
				{
					if (this.Yandere.NearestStudent == null)
					{
						this.Yandere.NearestStudent = this;
					}
					if (this.Yandere.NearestStudent == this && this.Yandere.EquippedID > 0)
					{
						Vector2 vector = this.UICamera.WorldToScreenPoint(this.transform.position + Vector3.up * 1.75f);
						this.Button.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
						Vector2 vector2 = this.UICamera.WorldToScreenPoint(this.transform.position + Vector3.up * 1.75f);
						this.Label.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector2.x, vector2.y, 1f));
						this.Button.color = new Color((float)1, (float)1, (float)1, (float)1);
						int num = 1;
						Color color = this.Label.color;
						float num2 = color.a = (float)num;
						Color color2 = this.Label.color = color;
					}
				}
				else
				{
					this.Deselect();
				}
			}
			else
			{
				this.Deselect();
			}
		}
		else
		{
			this.Deselect();
		}
	}

	public virtual void OnBecameVisible()
	{
		this.InView = true;
	}

	public virtual void OnBecameInvisible()
	{
		this.InView = false;
		if (this.Button != null)
		{
			int num = 0;
			Color color = this.Button.color;
			float num2 = color.a = (float)num;
			Color color2 = this.Button.color = color;
			int num3 = 0;
			Color color3 = this.Label.color;
			float num4 = color3.a = (float)num3;
			Color color4 = this.Label.color = color3;
		}
	}

	public virtual void Deselect()
	{
		if (this.Yandere.NearestStudent == this)
		{
			this.Yandere.NearestStudent = null;
		}
		int num = 0;
		Color color = this.Button.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Button.color = color;
		int num3 = 0;
		Color color3 = this.Label.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.Label.color = color3;
	}

	public virtual void StartDying()
	{
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		int num = 0;
		Color color = this.Button.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Button.color = color;
		int num3 = 0;
		Color color3 = this.Label.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.Label.color = color3;
		this.rigidbody.useGravity = false;
		this.MyCollider.enabled = false;
		this.Dying = true;
	}

	public virtual void PickNewRandomAnim()
	{
		this.RandomAnim = this.Animations[UnityEngine.Random.Range(0, Extensions.get_length(this.Animations))];
	}

	public virtual void YandereVision()
	{
		this.MyRenderer.materials = this.YandereVisionMaterials;
	}

	public virtual void NormalVision()
	{
		this.MyRenderer.materials = this.OriginalMaterials;
	}

	public virtual void Main()
	{
	}
}
