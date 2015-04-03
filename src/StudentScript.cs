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

	public WitnessCameraScript WitnessCamera;

	public RagdollScript NewRagdollScript;

	public DynamicGridObstacle Obstacle;

	public ReputationScript Reputation;

	public SubtitleScript Subtitle;

	public YandereScript Yandere;

	public PoliceScript Police;

	public PromptScript Prompt;

	public AIPath Pathfinding;

	public ClockScript Clock;

	public JsonScript JSON;

	public CharacterController MyController;

	public Texture DrillTexture;

	public Texture HairTexture;

	public Camera Eyes;

	public SkinnedMeshRenderer MyRenderer;

	public Renderer PigtailR;

	public Renderer PigtailL;

	public Renderer Drills;

	public Transform CurrentDestination;

	public Transform WitnessPOV;

	public string[] DestinationNames;

	public Transform[] Destinations;

	public string[] ActionNames;

	public int[] Actions;

	public OutlineScript[] Outlines;

	public string[] AnimationNames;

	public float[] PhaseTimes;

	public Plane[] Planes;

	public Collider PantyCollider;

	public Collider SkirtCollider;

	public Collider MyCollider;

	public GameObject BloodSpray;

	public GameObject MainCamera;

	public GameObject Character;

	public GameObject Ragdoll;

	public GameObject Marker;

	public bool WitnessedMurder;

	public bool RepeatReaction;

	public bool Complimented;

	public bool HidePony;

	public bool Tranquil;

	public bool Forgave;

	public bool Alarmed;

	public bool Reacted;

	public bool Witness;

	public bool Routine;

	public bool Dead;

	public bool Following;

	public bool Fleeing;

	public bool Talking;

	public bool Waiting;

	public bool Dying;

	public float DistanceToDestination;

	public float DistanceToPlayer;

	public float IgnoreTimer;

	public float AlarmTimer;

	public float TalkTimer;

	public float WaitTimer;

	public float GroundHeight;

	public float BreastSize;

	public float PendingRep;

	public float EyeShrink;

	public float RepLoss;

	public float Alarm;

	public int WeaponWitnessed;

	public int Interaction;

	public int Phase;

	public string RandomAnim;

	public string Witnessed;

	public string Hairstyle;

	public string Name;

	public int StudentID;

	public int Persona;

	public int Class;

	public int Club;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform Ponytail;

	public Transform RightEye;

	public Transform LeftEye;

	public Transform HairL;

	public Transform HairR;

	private float MaxSpeed;

	public Mesh NudeMesh;

	public Texture NudeTexture;

	public bool AoT;

	public StudentScript()
	{
		this.Routine = true;
		this.RandomAnim = string.Empty;
		this.Witnessed = string.Empty;
		this.Hairstyle = string.Empty;
		this.Name = string.Empty;
		this.MaxSpeed = 10f;
	}

	public virtual void Start()
	{
		this.DetectionMarker = (DetectionMarkerScript)((GameObject)UnityEngine.Object.Instantiate(this.Marker, GameObject.Find("DetectionPanel").transform.position, Quaternion.identity)).GetComponent(typeof(DetectionMarkerScript));
		this.DetectionMarker.transform.parent = GameObject.Find("DetectionPanel").transform;
		this.DetectionMarker.Target = this.transform;
		this.PhaseTimes = (float[])this.JSON.StudentTimes[this.StudentID].ToBuiltin(typeof(float));
		this.Persona = this.JSON.StudentPersonas[this.StudentID];
		this.Class = this.JSON.StudentClasses[this.StudentID];
		this.Club = this.JSON.StudentClubs[this.StudentID];
		this.BreastSize = this.JSON.StudentBreasts[this.StudentID];
		this.Hairstyle = this.JSON.StudentHairstyles[this.StudentID];
		this.Name = this.JSON.StudentNames[this.StudentID];
		this.GetDestinations();
		this.DialogueWheel = (DialogueWheelScript)GameObject.Find("DialogueWheel").GetComponent(typeof(DialogueWheelScript));
		this.Reputation = (ReputationScript)GameObject.Find("Reputation").GetComponent(typeof(ReputationScript));
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		this.Subtitle = (SubtitleScript)GameObject.Find("Subtitle").GetComponent(typeof(SubtitleScript));
		this.Police = (PoliceScript)GameObject.Find("Police").GetComponent(typeof(PoliceScript));
		this.Clock = (ClockScript)GameObject.Find("Clock").GetComponent(typeof(ClockScript));
		this.MainCamera = GameObject.Find("MainCamera");
		this.ShoulderCamera = (ShoulderCameraScript)this.MainCamera.GetComponent(typeof(ShoulderCameraScript));
		this.CameraEffects = (CameraEffectsScript)this.MainCamera.GetComponent(typeof(CameraEffectsScript));
		this.RightEyeOrigin = this.RightEye.localPosition;
		this.LeftEyeOrigin = this.LeftEye.localPosition;
		this.SetColors();
		this.UpdateHair();
		this.PickRandomAnim();
		if (this.AoT)
		{
			this.AttackOnTitan();
		}
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
		if (PlayerPrefs.GetInt("Student_" + this.StudentID + "_Photographed") == 0)
		{
			for (int i = 0; i < Extensions.get_length(this.Outlines); i++)
			{
				this.Outlines[i].enabled = false;
			}
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
				this.transform.position = Vector3.Lerp(this.transform.position, this.CurrentDestination.position, Time.deltaTime * (float)10);
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, (float)10 * Time.deltaTime);
				if (this.Actions[this.Phase] == 0)
				{
					this.Character.animation.CrossFade("f02_idleShort_00");
				}
				else
				{
					this.Character.animation.CrossFade(this.RandomAnim);
					if (this.Character.animation[this.RandomAnim].time >= this.Character.animation[this.RandomAnim].length)
					{
						this.PickRandomAnim();
					}
				}
			}
		}
		else
		{
			if (this.Fleeing)
			{
				this.DistanceToDestination = Vector3.Distance(this.transform.position, this.Pathfinding.target.position);
				if (this.transform.position.y < (float)-2)
				{
					this.Police.Witnesses = this.Police.Witnesses - 1;
					this.Police.Show = true;
					this.active = false;
				}
				if (this.DistanceToDestination > 0.5f)
				{
					this.Pathfinding.canMove = true;
					this.Character.animation.CrossFade("f02_sprint_00");
				}
				else
				{
					this.Pathfinding.canMove = false;
					this.Character.animation.CrossFade("f02_scaredIdle_00");
					this.transform.position = Vector3.Lerp(this.transform.position, this.Pathfinding.target.position, Time.deltaTime * (float)10);
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.Pathfinding.target.rotation, (float)10 * Time.deltaTime);
				}
			}
			if (this.Following && !this.Waiting)
			{
				this.DistanceToDestination = Vector3.Distance(this.transform.position, this.Pathfinding.target.position);
				if (this.DistanceToDestination > (float)5)
				{
					this.Character.animation.CrossFade("f02_run_00");
					this.Pathfinding.speed = (float)4;
				}
				else if (this.DistanceToDestination > (float)1)
				{
					this.Character.animation.CrossFade("f02_walk_00");
					this.Pathfinding.canMove = true;
					this.Pathfinding.speed = (float)1;
				}
				else
				{
					this.Character.animation.CrossFade("f02_idleShort_00");
					this.Pathfinding.canMove = false;
				}
				if (this.Phase < Extensions.get_length(this.PhaseTimes) - 1 && this.Clock.PresentTime / (float)60 >= this.PhaseTimes[this.Phase])
				{
					this.Phase++;
					this.CurrentDestination = this.Destinations[this.Phase];
					this.Pathfinding.target = this.Destinations[this.Phase];
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.Pathfinding.speed = (float)1;
					this.Following = false;
					this.Routine = true;
					this.Subtitle.UpdateLabel("Stop Follow Apology", 0, (float)3);
					this.Prompt.Label[0].text = "     " + "Talk";
				}
			}
		}
		if (!this.Dying)
		{
			this.DistanceToPlayer = Vector3.Distance(this.transform.position, this.Yandere.transform.position);
			if (this.DistanceToPlayer < (float)10)
			{
				if (!this.WitnessedMurder)
				{
					if (!this.Talking)
					{
						if ((this.Yandere.Armed && this.Yandere.Weapon[this.Yandere.Equipped].Suspicious) || this.Yandere.Bloodiness > (float)0 || this.Yandere.Sanity < 33.333f || this.Yandere.Attacking)
						{
							this.Planes = GeometryUtility.CalculateFrustumPlanes(this.Eyes);
							if (GeometryUtility.TestPlanesAABB(this.Planes, this.Yandere.collider.bounds))
							{
								RaycastHit raycastHit = default(RaycastHit);
								if (Physics.Linecast(this.Eyes.transform.position, this.Yandere.transform.position + Vector3.up * (float)1, out raycastHit))
								{
									if (raycastHit.collider.gameObject == this.Yandere.gameObject)
									{
										if (this.Yandere.Attacking || (this.Yandere.NearBodies > 0 && this.Yandere.Bloodiness > (float)0) || (this.Yandere.NearBodies > 0 && this.Yandere.Armed) || (this.Yandere.NearBodies > 0 && this.Yandere.Sanity < 66.66666f))
										{
											this.WitnessMurder();
										}
										else if (!this.Alarmed && this.IgnoreTimer <= (float)0)
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
					}
					else
					{
						this.Alarm -= Time.deltaTime * (float)100;
					}
				}
				if (this.Alarm > (float)100 && !this.Alarmed)
				{
					for (int i = 0; i < Extensions.get_length(this.Outlines); i++)
					{
						this.Outlines[i].color = new Color((float)1, (float)1, (float)0, (float)1);
					}
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.Routine = false;
					this.Alarmed = true;
					this.Witness = true;
					this.CameraEffects.Alarm();
					string witnessed = this.Witnessed;
					if (this.Yandere.Armed && this.Yandere.Bloodiness > (float)0 && this.Yandere.Sanity < 33.333f)
					{
						this.Witnessed = "Weapon and Blood and Insanity";
						this.RepLoss = (float)30;
					}
					else if (this.Yandere.Armed && this.Yandere.Sanity < 33.333f)
					{
						this.Witnessed = "Weapon and Insanity";
						this.RepLoss = (float)20;
					}
					else if (this.Yandere.Bloodiness > (float)0 && this.Yandere.Sanity < 33.333f)
					{
						this.Witnessed = "Blood and Insanity";
						this.RepLoss = (float)20;
					}
					else if (this.Yandere.Armed && this.Yandere.Bloodiness > (float)0)
					{
						this.Witnessed = "Weapon and Blood";
						this.RepLoss = (float)20;
					}
					else if (this.Yandere.Armed)
					{
						this.WeaponWitnessed = this.Yandere.Weapon[this.Yandere.Equipped].WeaponID;
						this.Witnessed = "Weapon";
						this.RepLoss = (float)10;
					}
					else if (this.Yandere.Bloodiness > (float)0)
					{
						this.Witnessed = "Blood";
						this.RepLoss = (float)10;
					}
					else if (this.Yandere.Sanity < 33.333f)
					{
						this.Witnessed = "Insanity";
						this.RepLoss = (float)10;
					}
					if (this.Witnessed == witnessed)
					{
						this.RepeatReaction = true;
					}
					this.Reputation.PendingRep = this.Reputation.PendingRep - this.RepLoss;
					this.PendingRep -= this.RepLoss;
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
			if (!this.Following)
			{
				if (!this.Witness && this.Yandere.Bloodiness > (float)0)
				{
					this.Prompt.Circle[0].fillAmount = (float)1;
					this.Alarm = (float)200;
				}
				else
				{
					this.Subtitle.UpdateLabel("Greeting", 0, (float)3);
					this.ShoulderCamera.OverShoulder = true;
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.Obstacle.enabled = true;
					this.Yandere.TargetStudent = this;
					this.Yandere.YandereVision = false;
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
					if (this.Complimented)
					{
						float a3 = 0.75f;
						Color color5 = this.DialogueWheel.Shadow[2].color;
						float num4 = color5.a = a3;
						Color color6 = this.DialogueWheel.Shadow[2].color = color5;
					}
					this.Yandere.WeaponMenu.KeyboardShow = false;
					this.Yandere.WeaponMenu.Show = false;
					this.DialogueWheel.Show = true;
					this.TalkTimer = (float)0;
				}
			}
			else
			{
				this.Subtitle.UpdateLabel("Student Farewell", 0, (float)3);
				this.Prompt.Label[0].text = "     " + "Talk";
				this.Prompt.Circle[0].fillAmount = (float)1;
				this.Following = false;
				this.Routine = true;
				this.CurrentDestination = this.Destinations[this.Phase];
				this.Pathfinding.target = this.Destinations[this.Phase];
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.Pathfinding.speed = (float)1;
			}
		}
		if (this.Prompt.Circle[2].fillAmount <= (float)0 && !this.Yandere.Attacking)
		{
			this.WitnessCamera.Show = false;
			this.Subtitle.UpdateLabel("Dying", 0, (float)1);
			this.Pathfinding.canSearch = false;
			this.Pathfinding.canMove = false;
			this.Yandere.Character.animation["f02_idleShort_00"].time = (float)0;
			this.Yandere.TargetStudent = this;
			this.Yandere.YandereVision = false;
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
					for (int i = 0; i < Extensions.get_length(this.Outlines); i++)
					{
						this.Outlines[i].color = new Color((float)0, (float)1, (float)0, (float)1);
					}
					this.Forgave = true;
					if (this.Witnessed == "Insanity" || this.Witnessed == "Weapon and Blood and Insanity" || this.Witnessed == "Weapon and Insanity" || this.Witnessed == "Blood and Insanity")
					{
						this.Subtitle.UpdateLabel("Forgiving Insanity", 0, (float)3);
					}
					else
					{
						this.Subtitle.UpdateLabel("Forgiving", 0, (float)3);
					}
				}
				else
				{
					if (this.Character.animation["f02_nod_01"].time >= this.Character.animation["f02_nod_01"].length)
					{
						this.Character.animation.CrossFade("f02_idleShort_00");
					}
					if (this.TalkTimer <= (float)0)
					{
						this.IgnoreTimer = (float)5;
						this.DialogueWheel.End();
					}
				}
				this.TalkTimer -= Time.deltaTime;
			}
			else if (this.Interaction == 2)
			{
				if (this.TalkTimer == (float)3)
				{
					this.Subtitle.UpdateLabel("Student Compliment", 0, (float)3);
					this.Reputation.PendingRep = this.Reputation.PendingRep + (float)2;
					this.PendingRep += (float)2;
					this.Complimented = true;
				}
				this.Character.animation.CrossFade("f02_lookdown_00");
				this.TalkTimer -= Time.deltaTime;
				if (this.TalkTimer <= (float)0)
				{
					this.DialogueWheel.End();
				}
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
			else if (this.Interaction == 9)
			{
				if (this.TalkTimer == (float)2)
				{
					this.Character.animation.CrossFade("f02_nod_00");
					this.Subtitle.UpdateLabel("Student Follow", 0, (float)2);
				}
				else
				{
					if (this.Character.animation["f02_nod_00"].time >= this.Character.animation["f02_nod_00"].length)
					{
						this.Character.animation.CrossFade("f02_idleShort_00");
					}
					if (this.TalkTimer <= (float)0)
					{
						this.DialogueWheel.End();
						this.Pathfinding.target = this.Yandere.transform;
						this.Prompt.Label[0].text = "     " + "Stop";
						this.Yandere.Follower = this;
						this.Following = true;
					}
				}
				this.TalkTimer -= Time.deltaTime;
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
					if (!this.Following)
					{
						this.Routine = true;
					}
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
					this.NewRagdollScript = (RagdollScript)gameObject.GetComponent(typeof(RagdollScript));
					this.NewRagdollScript.AnimStartTime = this.Character.animation["f02_down_22"].time;
					this.NewRagdollScript.BreastSize = this.BreastSize;
					this.NewRagdollScript.Yandere = this.Yandere;
					this.NewRagdollScript.MyRenderer.materials[1].mainTexture = this.HairTexture;
					this.NewRagdollScript.MyRenderer.materials[3].mainTexture = this.HairTexture;
					if (!this.Tranquil)
					{
						this.BloodSpray.transform.parent = ((RagdollScript)gameObject.GetComponent(typeof(RagdollScript))).BloodParent;
						this.BloodSpray.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
						this.BloodSpray.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
					}
					else
					{
						((RagdollScript)gameObject.GetComponent(typeof(RagdollScript))).Tranquil = true;
					}
					this.Reputation.PendingRep = this.Reputation.PendingRep + this.PendingRep * (float)-1;
					if (this.WitnessedMurder)
					{
						this.Police.Witnesses = this.Police.Witnesses - 1;
					}
					this.TransferHair();
					UnityEngine.Object.Destroy(this.DetectionMarker);
					UnityEngine.Object.Destroy(this.gameObject);
				}
			}
		}
		else if (this.WitnessedMurder)
		{
			if (!this.Fleeing)
			{
				if (this.EyeShrink < (float)1)
				{
					this.EyeShrink += Time.deltaTime * 0.2f;
				}
				this.Character.animation.CrossFade("f02_scaredIdle_00");
				this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
				this.AlarmTimer += Time.deltaTime;
				if (this.AlarmTimer > (float)5)
				{
					this.Subtitle.UpdateLabel("Coward Reaction", 1, (float)3);
					this.Pathfinding.target = this.StudentManager.EmergencyExit.Gateway;
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.Pathfinding.speed = (float)4;
					this.Fleeing = true;
				}
				else if (this.AlarmTimer > (float)1 && !this.Reacted)
				{
					this.Subtitle.UpdateLabel("Murder Reaction", 1, (float)3);
					this.Reacted = true;
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
				if (this.RepeatReaction)
				{
					this.Subtitle.UpdateLabel("Repeat Reaction", 1, (float)3);
					this.RepeatReaction = false;
				}
				else if (this.Witnessed == "Weapon and Blood and Insanity")
				{
					this.Subtitle.UpdateLabel("Weapon and Blood and Insanity Reaction", 1, (float)3);
				}
				else if (this.Witnessed == "Weapon and Blood")
				{
					this.Subtitle.UpdateLabel("Weapon and Blood Reaction", 1, (float)3);
				}
				else if (this.Witnessed == "Weapon and Insanity")
				{
					this.Subtitle.UpdateLabel("Weapon and Insanity Reaction", 1, (float)3);
				}
				else if (this.Witnessed == "Blood and Insanity")
				{
					this.Subtitle.UpdateLabel("Blood and Insanity Reaction", 1, (float)3);
				}
				else if (this.Witnessed == "Weapon")
				{
					this.Subtitle.UpdateLabel("Weapon Reaction", this.WeaponWitnessed, (float)3);
				}
				else if (this.Witnessed == "Blood")
				{
					this.Subtitle.UpdateLabel("Blood Reaction", 1, (float)3);
				}
				else if (this.Witnessed == "Insanity")
				{
					this.Subtitle.UpdateLabel("Insanity Reaction", 1, (float)3);
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
			float num5 = position.y = y2;
			Vector3 vector2 = this.transform.position = position;
		}
		if (this.AoT)
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)10, (float)10, (float)10), Time.deltaTime);
		}
		int num6 = 0;
		Vector3 localEulerAngles = this.transform.localEulerAngles;
		float num7 = localEulerAngles.x = (float)num6;
		Vector3 vector3 = this.transform.localEulerAngles = localEulerAngles;
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
		this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
		this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
		if (this.HidePony)
		{
			this.Ponytail.parent.transform.localScale = new Vector3((float)1, (float)1, 0.93f);
			this.Ponytail.localScale = new Vector3((float)0, (float)0, (float)0);
			this.HairR.localScale = new Vector3((float)0, (float)0, (float)0);
			this.HairL.localScale = new Vector3((float)0, (float)0, (float)0);
		}
	}

	public virtual void WitnessMurder()
	{
		for (int i = 0; i < Extensions.get_length(this.Outlines); i++)
		{
			this.Outlines[i].color = new Color((float)1, (float)0, (float)0, (float)1);
		}
		this.WitnessCamera.transform.parent = this.WitnessPOV;
		this.WitnessCamera.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
		this.WitnessCamera.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		this.WitnessCamera.MyCamera.enabled = true;
		this.WitnessCamera.Show = true;
		this.CameraEffects.MurderWitnessed();
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.Prompt.HideButton[0] = true;
		this.WitnessedMurder = true;
		this.Following = false;
		this.Reacted = false;
		this.Routine = false;
		this.Alarmed = true;
		this.Witnessed = "Murder";
		this.Police.Witnesses = this.Police.Witnesses + 1;
		this.AlarmTimer = (float)0;
		this.Alarm = (float)0;
		this.Witnessed = "Murder";
		if (this.Talking)
		{
			this.DialogueWheel.End();
			this.Pathfinding.canSearch = true;
			this.Pathfinding.canMove = true;
			this.Obstacle.enabled = false;
			this.Talking = false;
			this.Waiting = false;
			this.StudentManager.EnablePrompts();
		}
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
			else if (this.DestinationNames[i] == "Class")
			{
				this.Destinations[i] = this.StudentManager.Classrooms.List[this.Class];
			}
			else if (this.DestinationNames[i] == "Exit")
			{
				this.Destinations[i] = this.StudentManager.Hangouts.List[0];
			}
			else if (this.DestinationNames[i] == "Hangout1")
			{
				this.Destinations[i] = this.StudentManager.Hangouts.List[1];
			}
			else if (this.DestinationNames[i] == "Hangout2")
			{
				this.Destinations[i] = this.StudentManager.Hangouts.List[2];
			}
			else if (this.DestinationNames[i] == "Hangout3")
			{
				this.Destinations[i] = this.StudentManager.Hangouts.List[3];
			}
			else if (this.DestinationNames[i] == "Hangout4")
			{
				this.Destinations[i] = this.StudentManager.Hangouts.List[4];
			}
			else if (this.DestinationNames[i] == "Hangout5")
			{
				this.Destinations[i] = this.StudentManager.Hangouts.List[5];
			}
			else if (this.DestinationNames[i] == "Hangout6")
			{
				this.Destinations[i] = this.StudentManager.Hangouts.List[6];
			}
		}
		this.ActionNames = (string[])this.JSON.StudentActions[this.StudentID].ToBuiltin(typeof(string));
		for (int i = 1; i < Extensions.get_length(this.Actions); i++)
		{
			if (this.ActionNames[i] == "Stand")
			{
				this.Actions[i] = 0;
			}
			else if (this.ActionNames[i] == "Socialize")
			{
				this.Actions[i] = 1;
			}
		}
	}

	public virtual void SetColors()
	{
		string a = this.JSON.StudentColors[this.StudentID];
		if (a == "Red")
		{
			this.HairTexture = this.StudentManager.Colors[0];
		}
		else if (a == "Yellow")
		{
			this.HairTexture = this.StudentManager.Colors[1];
		}
		else if (a == "Green")
		{
			this.HairTexture = this.StudentManager.Colors[2];
		}
		else if (a == "Cyan")
		{
			this.HairTexture = this.StudentManager.Colors[3];
		}
		else if (a == "Blue")
		{
			this.HairTexture = this.StudentManager.Colors[4];
		}
		else if (a == "Purple")
		{
			this.HairTexture = this.StudentManager.Colors[5];
			this.DrillTexture = this.StudentManager.Colors[6];
		}
		this.MyRenderer.materials[1].mainTexture = this.HairTexture;
		this.MyRenderer.materials[3].mainTexture = this.HairTexture;
		this.PigtailR.material.mainTexture = this.HairTexture;
		this.PigtailL.material.mainTexture = this.HairTexture;
		if (this.DrillTexture != null)
		{
			this.Drills.materials[0].mainTexture = this.DrillTexture;
			this.Drills.materials[1].mainTexture = this.DrillTexture;
			this.Drills.materials[2].mainTexture = this.DrillTexture;
		}
		for (int i = 0; i < Extensions.get_length(this.Outlines); i++)
		{
			this.Outlines[i].h.ReinitMaterials();
		}
	}

	public virtual void UpdateHair()
	{
		this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3((float)1, 0.75f, (float)1);
		this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3((float)1, 0.75f, (float)1);
		this.PigtailR.active = false;
		this.PigtailL.active = false;
		this.Drills.active = false;
		this.HidePony = true;
		if (this.Hairstyle == "PonyTail")
		{
			this.HidePony = false;
			this.Ponytail.localScale = new Vector3((float)1, (float)1, (float)1);
			this.HairR.localScale = new Vector3((float)1, (float)1, (float)1);
			this.HairL.localScale = new Vector3((float)1, (float)1, (float)1);
		}
		else if (this.Hairstyle == "RightTail")
		{
			this.PigtailR.active = true;
		}
		else if (this.Hairstyle == "LeftTail")
		{
			this.PigtailL.active = true;
		}
		else if (this.Hairstyle == "PigTails")
		{
			this.PigtailR.active = true;
			this.PigtailL.active = true;
		}
		else if (this.Hairstyle == "TriTails")
		{
			this.PigtailR.active = true;
			this.PigtailL.active = true;
			this.HidePony = false;
			this.Ponytail.localScale = new Vector3((float)1, (float)1, (float)1);
			this.HairR.localScale = new Vector3((float)1, (float)1, (float)1);
			this.HairL.localScale = new Vector3((float)1, (float)1, (float)1);
		}
		else if (this.Hairstyle == "TwinTails")
		{
			this.PigtailR.active = true;
			this.PigtailL.active = true;
			this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3((float)2, (float)2, (float)2);
			this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3((float)2, (float)2, (float)2);
		}
		else if (this.Hairstyle == "Drills")
		{
			this.Drills.active = true;
		}
	}

	public virtual void TransferHair()
	{
		for (int i = 0; i < Extensions.get_length(this.Outlines); i++)
		{
			this.Outlines[i].color = new Color((float)1, 0.5f, (float)0, (float)1);
		}
		if (this.Hairstyle == "RightTail")
		{
			this.PigtailR.transform.parent.transform.parent.transform.parent = this.NewRagdollScript.Head;
			this.PigtailR.transform.parent.transform.parent.transform.localPosition = new Vector3(0.085f, 0.15f, (float)0);
			this.PigtailR.transform.parent.transform.parent.transform.localEulerAngles = new Vector3((float)0, (float)-90, (float)0);
			this.NewRagdollScript.HidePony = true;
		}
		else if (this.Hairstyle == "LeftTail")
		{
			this.PigtailL.transform.parent.transform.parent.transform.parent = this.NewRagdollScript.Head;
			this.PigtailL.transform.parent.transform.parent.transform.localPosition = new Vector3(-0.085f, 0.15f, (float)0);
			this.PigtailL.transform.parent.transform.parent.transform.localEulerAngles = new Vector3((float)0, (float)90, (float)0);
			this.NewRagdollScript.HidePony = true;
		}
		else if (this.Hairstyle == "PigTails")
		{
			this.PigtailR.transform.parent.transform.parent.transform.parent = this.NewRagdollScript.Head;
			this.PigtailR.transform.parent.transform.parent.transform.localPosition = new Vector3(0.085f, 0.15f, (float)0);
			this.PigtailR.transform.parent.transform.parent.transform.localEulerAngles = new Vector3((float)0, (float)-90, (float)0);
			this.PigtailL.transform.parent.transform.parent.transform.parent = this.NewRagdollScript.Head;
			this.PigtailL.transform.parent.transform.parent.transform.localPosition = new Vector3(-0.085f, 0.15f, (float)0);
			this.PigtailL.transform.parent.transform.parent.transform.localEulerAngles = new Vector3((float)0, (float)90, (float)0);
			this.NewRagdollScript.HidePony = true;
		}
		else if (this.Hairstyle == "TriTails")
		{
			this.PigtailR.transform.parent.transform.parent.transform.parent = this.NewRagdollScript.Head;
			this.PigtailR.transform.parent.transform.parent.transform.localPosition = new Vector3(0.085f, 0.15f, (float)0);
			this.PigtailR.transform.parent.transform.parent.transform.localEulerAngles = new Vector3((float)0, (float)-90, (float)0);
			this.PigtailL.transform.parent.transform.parent.transform.parent = this.NewRagdollScript.Head;
			this.PigtailL.transform.parent.transform.parent.transform.localPosition = new Vector3(-0.085f, 0.15f, (float)0);
			this.PigtailL.transform.parent.transform.parent.transform.localEulerAngles = new Vector3((float)0, (float)90, (float)0);
		}
		else if (this.Hairstyle == "TwinTails")
		{
			this.PigtailR.transform.parent.transform.parent.transform.parent = this.NewRagdollScript.Head;
			this.PigtailR.transform.parent.transform.parent.transform.localPosition = new Vector3(0.085f, 0.15f, (float)0);
			this.PigtailR.transform.parent.transform.parent.transform.localEulerAngles = new Vector3((float)0, (float)-90, (float)0);
			this.PigtailL.transform.parent.transform.parent.transform.parent = this.NewRagdollScript.Head;
			this.PigtailL.transform.parent.transform.parent.transform.localPosition = new Vector3(-0.085f, 0.15f, (float)0);
			this.PigtailL.transform.parent.transform.parent.transform.localEulerAngles = new Vector3((float)0, (float)90, (float)0);
			this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3((float)2, (float)2, (float)2);
			this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3((float)2, (float)2, (float)2);
			this.NewRagdollScript.HidePony = true;
		}
		else if (this.Hairstyle == "Drills")
		{
			this.Drills.transform.parent.transform.parent.transform.parent = this.NewRagdollScript.Head;
			this.Drills.transform.parent.transform.parent.transform.localPosition = new Vector3((float)0, -0.9f, 0.1f);
			this.Drills.transform.parent.transform.parent.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
			this.NewRagdollScript.HidePony = true;
		}
	}

	public virtual void PickRandomAnim()
	{
		this.RandomAnim = this.AnimationNames[UnityEngine.Random.Range(0, Extensions.get_length(this.AnimationNames))];
	}

	public virtual void AttackOnTitan()
	{
		this.AoT = true;
		float y = 0.0825f;
		Vector3 center = this.MyController.center;
		float num = center.y = y;
		Vector3 vector = this.MyController.center = center;
		this.MyController.radius = 0.015f;
		this.MyController.height = 0.15f;
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[3].mainTexture = this.NudeTexture;
		this.MyRenderer.materials[0].mainTexture = this.HairTexture;
		for (int i = 0; i < Extensions.get_length(this.Outlines); i++)
		{
			this.Outlines[i].h.ReinitMaterials();
		}
		this.PantyCollider.enabled = false;
		this.SkirtCollider.enabled = false;
	}

	public virtual void Main()
	{
	}
}
