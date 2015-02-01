using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class StudentScript : MonoBehaviour
{
	private Quaternion targetRotation;

	public DetectionMarkerScript DetectionMarker;

	public ShoulderCameraScript ShoulderCamera;

	public StudentManagerScript StudentManager;

	public CameraEffectsScript CameraEffects;

	public DialogueWheelScript DialogueWheel;

	public ExclamationScript Exclamation;

	public DynamicGridObstacle Obstacle;

	public ColoredOutlineScript Outline;

	public ReputationScript Reputation;

	public SubtitleScript Subtitle;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public AIPath Pathfinding;

	public ClockScript Clock;

	public JsonScript JSON;

	public Transform CurrentDestination;

	public string[] DestinationNames;

	public Transform[] Destinations;

	public float[] PhaseTimes;

	public Plane[] Planes;

	public GameObject BloodSpray;

	public GameObject Character;

	public GameObject Ragdoll;

	public GameObject Marker;

	public CharacterController MyController;

	public Collider MyCollider;

	public Camera Eyes;

	public float DistanceToDestination;

	public float DistanceToPlayer;

	public float IgnoreTimer;

	public float AlarmTimer;

	public float TalkTimer;

	public float WaitTimer;

	public float GroundHeight;

	public float PendingRep;

	public float Alarm;

	public bool Forgave;

	public bool Alarmed;

	public bool Reacted;

	public bool Witness;

	public bool Routine;

	public bool Dead;

	public bool Talking;

	public bool Waiting;

	public bool Dying;

	public int Interaction;

	public int StudentID;

	public int Class;

	public int Phase;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public Transform RightEye;

	public Transform LeftEye;

	public float EyeShrink;

	public string Witnessed;

	private float MaxSpeed;

	public SkinnedMeshRenderer MyRenderer;

	public Mesh NudeMesh;

	public Texture[] NudeTexture;

	public bool AoT;

	public StudentScript()
	{
		this.Routine = true;
		this.Witnessed = string.Empty;
		this.MaxSpeed = 10f;
	}

	public virtual void Start()
	{
		this.DetectionMarker = (DetectionMarkerScript)((GameObject)UnityEngine.Object.Instantiate(this.Marker, GameObject.Find("DetectionPanel").transform.position, Quaternion.identity)).GetComponent(typeof(DetectionMarkerScript));
		this.DetectionMarker.transform.parent = GameObject.Find("DetectionPanel").transform;
		this.DetectionMarker.Target = this.transform;
		this.Class = this.JSON.StudentClasses[this.StudentID];
		this.GetDestinations();
		this.DialogueWheel = (DialogueWheelScript)GameObject.Find("DialogueWheel").GetComponent(typeof(DialogueWheelScript));
		this.Reputation = (ReputationScript)GameObject.Find("Reputation").GetComponent(typeof(ReputationScript));
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		this.Subtitle = (SubtitleScript)GameObject.Find("Subtitle").GetComponent(typeof(SubtitleScript));
		this.Clock = (ClockScript)GameObject.Find("Clock").GetComponent(typeof(ClockScript));
		this.ShoulderCamera = (ShoulderCameraScript)Camera.main.GetComponent(typeof(ShoulderCameraScript));
		this.CameraEffects = (CameraEffectsScript)Camera.main.GetComponent(typeof(CameraEffectsScript));
		this.RightEyeOrigin = this.RightEye.localPosition;
		this.LeftEyeOrigin = this.LeftEye.localPosition;
		if (this.Yandere.Armed)
		{
			this.Prompt.HideButton[0] = true;
			this.Prompt.HideButton[2] = false;
		}
		else
		{
			this.Prompt.HideButton[0] = false;
			this.Prompt.HideButton[2] = true;
		}
	}

	public virtual void Update()
	{
		if (this.Routine)
		{
			if (this.Phase < Extensions.get_length(this.PhaseTimes) - 1 && this.Clock.PresentTime / (float)60 >= this.PhaseTimes[this.Phase])
			{
				this.Phase++;
				this.CurrentDestination = this.Destinations[this.Phase];
				this.Pathfinding.target = this.Destinations[this.Phase];
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
			}
			this.DistanceToDestination = Vector3.Distance(this.transform.position, this.CurrentDestination.position);
			if (this.DistanceToDestination > 0.5f)
			{
				this.Character.animation.CrossFade("f02_walk_00");
				this.Character.animation["f02_walk_00"].speed = this.Pathfinding.currentSpeed;
			}
			else
			{
				this.Pathfinding.canSearch = false;
				this.Pathfinding.canMove = false;
				this.Character.animation.CrossFade("f02_idleShort_00");
				this.transform.position = Vector3.Lerp(this.transform.position, this.CurrentDestination.position, Time.deltaTime * (float)10);
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, (float)10 * Time.deltaTime);
			}
			this.DistanceToPlayer = Vector3.Distance(this.transform.position, this.Yandere.transform.position);
			if (this.DistanceToPlayer < (float)10)
			{
				if (this.Yandere.Armed || this.Yandere.Bloodiness > (float)0)
				{
					this.Planes = GeometryUtility.CalculateFrustumPlanes(this.Eyes);
					if (GeometryUtility.TestPlanesAABB(this.Planes, this.Yandere.collider.bounds))
					{
						RaycastHit raycastHit = default(RaycastHit);
						if (Physics.Linecast(this.Eyes.transform.position, this.Yandere.transform.position + Vector3.up * (float)1, out raycastHit))
						{
							if (raycastHit.collider.gameObject == this.Yandere.gameObject)
							{
								if (!this.Alarmed && this.IgnoreTimer <= (float)0)
								{
									this.Alarm += Time.deltaTime * ((float)100 / this.DistanceToPlayer);
								}
							}
							else
							{
								this.Alarm -= Time.deltaTime * (float)100;
							}
						}
					}
					else if (!this.Alarmed)
					{
						this.Alarm -= Time.deltaTime * (float)100;
					}
				}
				else if (!this.Alarmed)
				{
					this.Alarm -= Time.deltaTime * (float)100;
				}
				if (this.Alarm > (float)100 && !this.Alarmed)
				{
					this.Outline.color = new Color((float)1, (float)1, (float)0, (float)1);
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.Routine = false;
					this.Alarmed = true;
					this.Witness = true;
					this.Reputation.PendingRep = this.Reputation.PendingRep - (float)10;
					this.PendingRep -= (float)10;
					this.Exclamation.Timer = (float)3;
					this.CameraEffects.Alarm();
					if (this.Yandere.Armed)
					{
						this.Witnessed = "Weapon";
					}
					if (this.Yandere.Armed && this.Yandere.Bloodiness > (float)0)
					{
						this.Witnessed = "Weapon and Blood";
					}
					else if (this.Yandere.Armed)
					{
						this.Witnessed = "Weapon";
					}
					else if (this.Yandere.Bloodiness > (float)0)
					{
						this.Witnessed = "Blood";
					}
				}
			}
			else if (!this.Alarmed)
			{
				this.Alarm -= Time.deltaTime * (float)100;
			}
		}
		if (this.Alarm > (float)100)
		{
			this.Alarm = (float)100;
		}
		if (this.Alarm < (float)0)
		{
			this.Alarm = (float)0;
		}
		float y = this.Alarm / (float)100;
		Vector3 localScale = this.DetectionMarker.Tex.transform.localScale;
		float num = localScale.y = y;
		Vector3 vector = this.DetectionMarker.Tex.transform.localScale = localScale;
		float a = this.Alarm / (float)100;
		Color color = this.DetectionMarker.Tex.color;
		float num2 = color.a = a;
		Color color2 = this.DetectionMarker.Tex.color = color;
		if (this.Alarm > (float)0 || this.Yandere.Armed)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
		}
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Subtitle.UpdateLabel("Greeting", 0, (float)3);
			this.ShoulderCamera.OverShoulder = true;
			this.Pathfinding.canSearch = false;
			this.Pathfinding.canMove = false;
			this.Obstacle.enabled = true;
			this.Yandere.TargetStudent = this;
			this.Yandere.CanMove = false;
			this.Yandere.Talking = true;
			this.Reacted = false;
			this.Talking = true;
			this.Routine = false;
			this.StudentManager.DisablePrompts();
			this.DialogueWheel.HideShadows();
			if (!this.Witness || this.Forgave)
			{
				float a2 = 0.75f;
				Color color3 = this.DialogueWheel.Shadow[1].color;
				float num3 = color3.a = a2;
				Color color4 = this.DialogueWheel.Shadow[1].color = color3;
			}
			this.DialogueWheel.Show = true;
			this.TalkTimer = (float)0;
		}
		if (this.Prompt.Circle[2].fillAmount <= (float)0)
		{
			this.Subtitle.UpdateLabel("Dying", 0, (float)1);
			this.Pathfinding.canSearch = false;
			this.Pathfinding.canMove = false;
			this.Yandere.TargetStudent = this;
			this.Yandere.Attacking = true;
			this.Yandere.CanMove = false;
			this.MyCollider.enabled = false;
			this.Alarmed = false;
			this.Routine = false;
			this.Dying = true;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Talking)
		{
			if (this.Interaction == 0)
			{
				this.Character.animation.CrossFade("f02_idleShort_00");
				if (this.TalkTimer == (float)0)
				{
					this.DialogueWheel.Impatience.fillAmount = this.DialogueWheel.Impatience.fillAmount + Time.deltaTime * 0.1f;
					if (this.DialogueWheel.Impatience.fillAmount > 0.5f && this.Subtitle.Timer == (float)0)
					{
						this.Subtitle.UpdateLabel("Impatience", 1, (float)5);
					}
					if (this.DialogueWheel.Impatience.fillAmount >= (float)1)
					{
						this.Subtitle.UpdateLabel("Impatience", 2, (float)3);
						this.DialogueWheel.End();
						this.WaitTimer = (float)0;
					}
				}
			}
			else if (this.Interaction == 1)
			{
				if (this.TalkTimer == (float)3)
				{
					this.Character.animation.CrossFade("f02_nod_01");
					this.Reputation.PendingRep = this.Reputation.PendingRep + (float)5;
					this.PendingRep += (float)5;
					this.Outline.color = new Color((float)0, (float)1, (float)0, (float)1);
					this.Forgave = true;
					this.Subtitle.UpdateLabel("Forgiving", 0, (float)3);
				}
				else
				{
					if (this.Character.animation["f02_nod_01"].time >= this.Character.animation["f02_nod_01"].length)
					{
						this.Character.animation.CrossFade("f02_idleShort_00");
					}
					if (this.TalkTimer <= (float)0)
					{
						this.DialogueWheel.End();
					}
				}
				this.TalkTimer -= Time.deltaTime;
			}
			else if (this.Interaction == 4)
			{
				if (this.TalkTimer == (float)2)
				{
					this.Subtitle.UpdateLabel("Student Farewell", 0, (float)2);
				}
				this.Character.animation.CrossFade("f02_idleShort_00");
				this.TalkTimer -= Time.deltaTime;
				if (this.TalkTimer <= (float)0)
				{
					this.DialogueWheel.End();
				}
			}
			if (this.Waiting)
			{
				this.WaitTimer -= Time.deltaTime;
				if (this.WaitTimer <= (float)0)
				{
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.Obstacle.enabled = false;
					this.Alarmed = false;
					this.Talking = false;
					this.Waiting = false;
					this.Routine = true;
					this.StudentManager.EnablePrompts();
				}
			}
			else
			{
				this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
			}
		}
		else if (this.Dying)
		{
			this.Alarm -= Time.deltaTime * (float)100;
			this.EyeShrink = Mathf.Lerp(this.EyeShrink, (float)1, Time.deltaTime * (float)10);
			if (!this.Dead)
			{
				this.Character.animation.CrossFade("f02_defend_00");
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z) - this.transform.position);
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
				this.transform.position = Vector3.Lerp(this.transform.position, this.Yandere.transform.position + this.Yandere.transform.forward * 0.1f, Time.deltaTime * (float)10);
			}
			else
			{
				this.Character.animation.CrossFade("f02_down_22");
				if (this.Character.animation["f02_down_22"].time < (float)1)
				{
					this.transform.Translate(Vector3.back * Time.deltaTime);
				}
				else
				{
					GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.Ragdoll, this.transform.position, this.transform.rotation);
					((RagdollScript)gameObject.GetComponent(typeof(RagdollScript))).AnimStartTime = this.Character.animation["f02_down_22"].time;
					((RagdollScript)gameObject.GetComponent(typeof(RagdollScript))).Yandere = this.Yandere;
					this.BloodSpray.transform.parent = ((RagdollScript)gameObject.GetComponent(typeof(RagdollScript))).BloodParent;
					this.BloodSpray.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
					this.BloodSpray.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
					this.Reputation.PendingRep = this.Reputation.PendingRep + this.PendingRep * (float)-1;
					UnityEngine.Object.Destroy(this.DetectionMarker);
					UnityEngine.Object.Destroy(this.gameObject);
				}
			}
		}
		else if (this.Alarmed)
		{
			this.Character.animation.CrossFade("f02_idleShort_00");
			this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
			this.AlarmTimer += Time.deltaTime;
			this.Alarm -= Time.deltaTime * (float)100;
			if (this.AlarmTimer > (float)5)
			{
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.IgnoreTimer = (float)5;
				this.Alarmed = false;
				this.Reacted = false;
				this.Routine = true;
				this.AlarmTimer = (float)0;
			}
			else if (this.AlarmTimer > (float)1 && !this.Reacted)
			{
				if (this.Witnessed == "Weapon")
				{
					this.Subtitle.UpdateLabel("Weapon Reaction", 1, (float)3);
				}
				else if (this.Witnessed == "Blood")
				{
					this.Subtitle.UpdateLabel("Blood Reaction", 1, (float)3);
				}
				else if (this.Witnessed == "Weapon and Blood")
				{
					this.Subtitle.UpdateLabel("Weapon and Blood Reaction", 1, (float)3);
				}
				this.Reacted = true;
			}
		}
		if (this.IgnoreTimer > (float)0)
		{
			this.IgnoreTimer -= Time.deltaTime;
		}
		if (this.MyController.isGrounded && this.MyController.velocity.y <= (float)3)
		{
			this.GroundHeight = this.transform.position.y;
		}
		if (this.MyController.velocity.y > (float)3)
		{
			float y2 = this.GroundHeight + 0.1f;
			Vector3 position = this.transform.position;
			float num4 = position.y = y2;
			Vector3 vector2 = this.transform.position = position;
		}
		if (this.AoT)
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)10, (float)10, (float)10), Time.deltaTime);
		}
	}

	public virtual void LateUpdate()
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
	}

	public virtual void GetDestinations()
	{
		this.DestinationNames = (string[])this.JSON.StudentDestinations[this.StudentID].ToBuiltin(typeof(string));
		for (int i = 1; i < Extensions.get_length(this.Destinations); i++)
		{
			if (this.DestinationNames[i] == "Locker")
			{
				this.Destinations[i] = this.StudentManager.Lockers.List[this.StudentID];
			}
			if (this.DestinationNames[i] == "Class")
			{
				this.Destinations[i] = this.StudentManager.Classrooms.List[this.Class];
			}
			if (this.DestinationNames[i] == "Rooftop")
			{
				this.Destinations[i] = this.StudentManager.Hangouts.List[0];
			}
			if (this.DestinationNames[i] == "Exit")
			{
				this.Destinations[i] = this.StudentManager.Hangouts.List[1];
			}
		}
	}

	public virtual void AttackOnTitan()
	{
		this.AoT = true;
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[3].mainTexture = this.NudeTexture[0];
		this.MyRenderer.materials[0].mainTexture = this.NudeTexture[1];
	}

	public virtual void Main()
	{
	}
}
