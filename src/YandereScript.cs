using System;
using UnityEngine;

[Serializable]
public class YandereScript : MonoBehaviour
{
	private Quaternion targetRotation;

	private Vector3 targetDirection;

	private GameObject NewTrail;

	private int ID;

	public FootprintSpawnerScript RightFootprintSpawner;

	public FootprintSpawnerScript LeftFootprintSpawner;

	public ColorCorrectionCurves ColorCorrection;

	public StudentManagerScript StudentManager;

	public SWP_HeartRateMonitor HeartRate;

	public IncineratorScript Incinerator;

	public StudentScript TargetStudent;

	public DepthOfField34 DepthOfField;

	public PromptScript NearestPrompt;

	public SubtitleScript Subtitle;

	public WeaponScript Weapon;

	public WarningScript VisiblyArmed;

	public WarningScript VisiblyBloody;

	public WarningScript VisiblyInsane;

	public WarningScript NearBody;

	public SpringJoint RagdollDragger;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform ItemParent;

	public Transform Homeroom;

	public Transform Senpai;

	public Transform Head;

	public AudioSource HeartBeat;

	public AudioSource Jukebox;

	public GameObject Character;

	public GameObject DumpChan;

	public GameObject Eyepatch;

	public GameObject Ragdoll;

	public GameObject Trail;

	public Renderer MyRenderer;

	public float AttackTimer;

	public float DumpTimer;

	public float TalkTimer;

	public float PreviousBloodiness;

	public float Bloodiness;

	public float PreviousSanity;

	public float Sanity;

	public float TwitchFactor;

	public float TwitchTimer;

	public float NextTwitch;

	public float BreastSize;

	public float WalkSpeed;

	public float RunSpeed;

	public float Slouch;

	public float Tint;

	public int AttackPhase;

	public int Interaction;

	public int NearBodies;

	public bool Attacking;

	public bool Dragging;

	public bool Throwing;

	public bool Dumping;

	public bool Talking;

	public bool Heartbroken;

	public bool DpadPressed;

	public bool CanMove;

	public bool Armed;

	public bool Die;

	public Texture[] UniformTextures;

	public Transform[] Spine;

	public Transform[] Arm;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public Transform RightEye;

	public Transform LeftEye;

	public float EyeShrink;

	public Vector3 Twitch;

	public YandereScript()
	{
		this.Sanity = 100f;
		this.BreastSize = 1f;
		this.CanMove = true;
	}

	public virtual void Start()
	{
		this.RightEyeOrigin = this.RightEye.localPosition;
		this.LeftEyeOrigin = this.LeftEye.localPosition;
		this.Character.animation["f02_yanderePose_00"].weight = (float)0;
		this.ResetEffects();
		this.UpdateHeartRate();
	}

	public virtual void LateUpdate()
	{
		if (this.CanMove)
		{
			Vector3 a = Camera.main.transform.TransformDirection(Vector3.forward);
			a.y = (float)0;
			a = a.normalized;
			Vector3 a2 = new Vector3(a.z, (float)0, -a.x);
			float axis = Input.GetAxis("Vertical");
			float axis2 = Input.GetAxis("Horizontal");
			this.targetDirection = axis2 * a2 + axis * a;
			if (this.targetDirection != Vector3.zero)
			{
				this.targetRotation = Quaternion.LookRotation(this.targetDirection);
				this.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
			}
			else
			{
				this.targetRotation = new Quaternion((float)0, (float)0, (float)0, (float)0);
			}
			if (axis != (float)0 || axis2 != (float)0)
			{
				if (Input.GetButton("LB") && Vector3.Distance(this.transform.position, this.Senpai.position) > (float)2)
				{
					this.Character.animation.CrossFade("f02_sprint_00");
					this.transform.Translate(Vector3.forward * this.RunSpeed * Time.deltaTime);
				}
				else if (!this.Dragging)
				{
					this.Character.animation.CrossFade("f02_walk_00");
					this.transform.Translate(Vector3.forward * this.WalkSpeed * Time.deltaTime);
				}
				else
				{
					this.Character.animation.CrossFade("f02_dragWalk_00");
					this.transform.Translate(Vector3.forward * this.WalkSpeed * Time.deltaTime);
				}
			}
			else if (!this.Dragging)
			{
				if (Time.timeScale > (float)2)
				{
				}
				this.Character.animation.CrossFade("f02_idleShort_00");
			}
			else
			{
				this.Character.animation.CrossFade("f02_dragIdle_00");
			}
		}
		else
		{
			if (this.Dumping)
			{
				this.targetRotation = Quaternion.LookRotation(this.Incinerator.transform.position + Vector3.fwd * (float)4 - this.transform.position);
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
				this.transform.position = Vector3.Lerp(this.transform.position, this.Incinerator.transform.position + Vector3.fwd * (float)3, Time.deltaTime * (float)10);
				this.DumpTimer += Time.deltaTime;
				if (this.DumpTimer > (float)1)
				{
					if (this.Character.animation["f02_throw_20_p"].time == (float)0)
					{
						this.SpawnDumpChan();
					}
					this.Character.animation.CrossFade("f02_throw_20_p");
					if (this.Character.animation["f02_throw_20_p"].time >= this.Character.animation["f02_throw_20_p"].length)
					{
						this.Incinerator.Prompt.Label[3].text = "     " + "Activate";
						this.Incinerator.Occupied = true;
						this.Incinerator.Open = false;
						this.Dragging = false;
						this.Dumping = false;
						this.CanMove = true;
						this.DumpTimer = (float)0;
					}
				}
			}
			if (this.Heartbroken && this.Character.animation["f02_down_22"].time >= this.Character.animation["f02_down_22"].length)
			{
				this.Character.animation.CrossFade("f02_down_23");
			}
		}
		if (this.Die)
		{
			this.Character.animation.CrossFade("f02_down_22");
			this.Heartbroken = true;
			this.CanMove = false;
			this.Die = false;
		}
		if (Input.GetButtonDown("LS") || Input.GetKeyDown("t"))
		{
			if (this.NewTrail != null)
			{
				UnityEngine.Object.Destroy(this.NewTrail);
			}
			this.NewTrail = (GameObject)UnityEngine.Object.Instantiate(this.Trail, this.transform.position + Vector3.fwd * 0.5f + Vector3.up * 0.1f, Quaternion.identity);
			((AIPath)this.NewTrail.GetComponent(typeof(AIPath))).target = this.Homeroom;
		}
		if (!this.DpadPressed && this.Weapon != null && this.CanMove && !this.Dragging)
		{
			if (Input.GetKeyDown("1") || Input.GetAxis("DpadY") < -0.5f)
			{
				this.Unequip();
			}
			else if (Input.GetKeyDown("2") || Input.GetAxis("DpadY") > 0.5f)
			{
				this.Weapon.active = true;
				this.DpadPressed = true;
				this.Armed = true;
				this.StudentManager.UpdateStudents();
				this.VisiblyArmed.Warn();
			}
		}
		if (Input.GetAxis("DpadY") > -0.5f && Input.GetAxis("DpadY") < 0.5f && Input.GetAxis("DpadX") > -0.5f && Input.GetAxis("DpadX") < 0.5f)
		{
			this.DpadPressed = false;
		}
		else
		{
			this.DpadPressed = true;
		}
		if (Vector3.Distance(this.transform.position, this.Senpai.position) < (float)2)
		{
			if (this.Dragging)
			{
				((RagdollScript)this.Ragdoll.GetComponent(typeof(RagdollScript))).StopDragging();
			}
			if (this.Armed)
			{
				this.VisiblyArmed.Display = false;
				this.Weapon.Drop();
			}
			this.ColorCorrection.enabled = true;
			this.DepthOfField.enabled = true;
			this.DepthOfField.focalSize = Mathf.Lerp(this.DepthOfField.focalSize, (float)0, Time.deltaTime * (float)10);
			this.DepthOfField.focalZStartCurve = Mathf.Lerp(this.DepthOfField.focalZStartCurve, (float)20, Time.deltaTime * (float)10);
			this.DepthOfField.focalZEndCurve = Mathf.Lerp(this.DepthOfField.focalZEndCurve, (float)20, Time.deltaTime * (float)10);
			this.Tint = (float)1 - this.DepthOfField.focalSize / (float)150;
			this.ColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, 0.5f + this.Tint * 0.5f));
			this.ColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, 0.5f - this.Tint * 0.5f));
			this.ColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, 0.5f + this.Tint * 0.5f));
			this.ColorCorrection.redChannel.SmoothTangents(1, (float)0);
			this.ColorCorrection.greenChannel.SmoothTangents(1, (float)0);
			this.ColorCorrection.blueChannel.SmoothTangents(1, (float)0);
			this.ColorCorrection.UpdateTextures();
			this.Character.animation["f02_shy_00"].weight = this.Tint;
			this.HeartBeat.volume = this.Tint;
			this.Sanity += Time.deltaTime * (float)10;
			this.UpdateHeartRate();
		}
		else if (this.DepthOfField.focalSize < (float)149)
		{
			this.DepthOfField.focalSize = Mathf.Lerp(this.DepthOfField.focalSize, (float)150, Time.deltaTime * (float)10);
			this.DepthOfField.focalZStartCurve = Mathf.Lerp(this.DepthOfField.focalZStartCurve, (float)0, Time.deltaTime * (float)10);
			this.DepthOfField.focalZEndCurve = Mathf.Lerp(this.DepthOfField.focalZEndCurve, (float)0, Time.deltaTime * (float)10);
			this.Tint = this.DepthOfField.focalSize / (float)150;
			this.ColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, (float)1 - this.Tint * 0.5f));
			this.ColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, this.Tint * 0.5f));
			this.ColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, (float)1 - this.Tint * 0.5f));
			this.ColorCorrection.redChannel.SmoothTangents(1, (float)0);
			this.ColorCorrection.greenChannel.SmoothTangents(1, (float)0);
			this.ColorCorrection.blueChannel.SmoothTangents(1, (float)0);
			this.ColorCorrection.UpdateTextures();
			this.Character.animation["f02_shy_00"].weight = (float)1 - this.Tint;
			this.HeartBeat.volume = (float)1 - this.Tint;
		}
		else
		{
			this.ResetEffects();
		}
		if (this.Armed)
		{
			this.Character.animation["f02_fist_00"].weight = Mathf.Lerp(this.Character.animation["f02_fist_00"].weight, (float)1, Time.deltaTime * (float)10);
		}
		else
		{
			this.Character.animation["f02_fist_00"].weight = Mathf.Lerp(this.Character.animation["f02_fist_00"].weight, (float)0, Time.deltaTime * (float)10);
		}
		if (this.Talking)
		{
			this.targetRotation = Quaternion.LookRotation(this.TargetStudent.transform.position - this.transform.position);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
			if (this.Interaction == 0)
			{
				this.Character.animation.CrossFade("f02_idleShort_00");
			}
			else if (this.Interaction == 1)
			{
				if (this.TalkTimer == (float)3)
				{
					this.Character.animation.CrossFade("f02_greet_00");
					if (this.TargetStudent.Witnessed == "Weapon and Blood")
					{
						this.Subtitle.UpdateLabel("Weapon and Blood Apology", 0, (float)3);
					}
					else if (this.TargetStudent.Witnessed == "Weapon")
					{
						this.Subtitle.UpdateLabel("Weapon Apology", 0, (float)3);
					}
					else if (this.TargetStudent.Witnessed == "Blood")
					{
						this.Subtitle.UpdateLabel("Blood Apology", 0, (float)3);
					}
				}
				else
				{
					if (this.Character.animation["f02_greet_00"].time >= this.Character.animation["f02_greet_00"].length)
					{
						this.Character.animation.CrossFade("f02_idleShort_00");
					}
					if (this.TalkTimer <= (float)0)
					{
						this.TargetStudent.Interaction = 1;
						this.TargetStudent.TalkTimer = (float)3;
						this.Interaction = 0;
					}
				}
				this.TalkTimer -= Time.deltaTime;
			}
			else if (this.Interaction == 4)
			{
				if (this.TalkTimer == (float)2)
				{
					this.Character.animation.CrossFade("f02_greet_00");
					this.Subtitle.UpdateLabel("Player Farewell", 0, (float)2);
				}
				else
				{
					if (this.Character.animation["f02_greet_00"].time >= this.Character.animation["f02_greet_00"].length)
					{
						this.Character.animation.CrossFade("f02_idleShort_00");
					}
					if (this.TalkTimer <= (float)0)
					{
						this.TargetStudent.Interaction = 4;
						this.TargetStudent.TalkTimer = (float)2;
						this.Interaction = 0;
					}
				}
				this.TalkTimer -= Time.deltaTime;
			}
		}
		if (this.Attacking)
		{
			this.targetRotation = Quaternion.LookRotation(this.TargetStudent.transform.position - this.transform.position);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
			if (this.AttackPhase == 1)
			{
				this.Character.animation.CrossFade("f02_stab_00");
				if (this.Character.animation["f02_stab_00"].time > this.Character.animation["f02_stab_00"].length * 0.4f)
				{
					this.Character.animation.CrossFade("f02_idleShort_00");
					this.TargetStudent.BloodSpray.active = true;
					this.TargetStudent.Dead = true;
					this.Bloodiness += (float)20;
					this.AttackPhase = 2;
					this.Sanity -= (float)20;
					this.UpdateHeartRate();
					this.UpdateBlood();
				}
			}
			else
			{
				this.AttackTimer += Time.deltaTime;
				if (this.AttackTimer > 0.3f)
				{
					this.Attacking = false;
					this.AttackPhase = 1;
					this.AttackTimer = (float)0;
					this.CanMove = true;
				}
			}
		}
		if (!this.Attacking && !this.Dragging)
		{
			this.Character.animation["f02_yanderePose_00"].weight = Mathf.Lerp(this.Character.animation["f02_yanderePose_00"].weight, (float)1 - this.Sanity / (float)100, Time.deltaTime * (float)10);
			this.Slouch = Mathf.Lerp(this.Slouch, (float)5 * ((float)1 - this.Sanity / (float)100), Time.deltaTime * (float)10);
		}
		else
		{
			this.Character.animation["f02_yanderePose_00"].weight = Mathf.Lerp(this.Character.animation["f02_yanderePose_00"].weight, (float)0, Time.deltaTime * (float)10);
			this.Slouch = Mathf.Lerp(this.Slouch, (float)0, Time.deltaTime * (float)10);
		}
		this.ID = 0;
		while (this.ID < this.Spine.Length)
		{
			float x = this.Spine[this.ID].transform.localEulerAngles.x + this.Slouch;
			Vector3 localEulerAngles = this.Spine[this.ID].transform.localEulerAngles;
			float num = localEulerAngles.x = x;
			Vector3 vector = this.Spine[this.ID].transform.localEulerAngles = localEulerAngles;
			this.ID++;
		}
		float z = this.Arm[0].transform.localEulerAngles.z - this.Slouch * (float)3;
		Vector3 localEulerAngles2 = this.Arm[0].transform.localEulerAngles;
		float num2 = localEulerAngles2.z = z;
		Vector3 vector2 = this.Arm[0].transform.localEulerAngles = localEulerAngles2;
		float z2 = this.Arm[1].transform.localEulerAngles.z + this.Slouch * (float)3;
		Vector3 localEulerAngles3 = this.Arm[1].transform.localEulerAngles;
		float num3 = localEulerAngles3.z = z2;
		Vector3 vector3 = this.Arm[1].transform.localEulerAngles = localEulerAngles3;
		this.EyeShrink = Mathf.Lerp(this.EyeShrink, (float)1 - this.Sanity / (float)100, Time.deltaTime * (float)10);
		float z3 = this.LeftEyeOrigin.z - this.EyeShrink * 0.01f;
		Vector3 localPosition = this.LeftEye.localPosition;
		float num4 = localPosition.z = z3;
		Vector3 vector4 = this.LeftEye.localPosition = localPosition;
		float z4 = this.RightEyeOrigin.z + this.EyeShrink * 0.01f;
		Vector3 localPosition2 = this.RightEye.localPosition;
		float num5 = localPosition2.z = z4;
		Vector3 vector5 = this.RightEye.localPosition = localPosition2;
		float x2 = (float)1 - this.EyeShrink * 0.5f;
		Vector3 localScale = this.LeftEye.localScale;
		float num6 = localScale.x = x2;
		Vector3 vector6 = this.LeftEye.localScale = localScale;
		float y = (float)1 - this.EyeShrink * 0.5f;
		Vector3 localScale2 = this.LeftEye.localScale;
		float num7 = localScale2.y = y;
		Vector3 vector7 = this.LeftEye.localScale = localScale2;
		float x3 = (float)1 - this.EyeShrink * 0.5f;
		Vector3 localScale3 = this.RightEye.localScale;
		float num8 = localScale3.x = x3;
		Vector3 vector8 = this.RightEye.localScale = localScale3;
		float y2 = (float)1 - this.EyeShrink * 0.5f;
		Vector3 localScale4 = this.RightEye.localScale;
		float num9 = localScale4.y = y2;
		Vector3 vector9 = this.RightEye.localScale = localScale4;
		if (this.Sanity < (float)100)
		{
			this.TwitchTimer += Time.deltaTime;
			if (this.TwitchTimer > this.NextTwitch)
			{
				this.Twitch.x = ((float)1 - this.Sanity / (float)100) * UnityEngine.Random.Range(-10f, 10f);
				this.Twitch.y = ((float)1 - this.Sanity / (float)100) * UnityEngine.Random.Range(-10f, 10f);
				this.Twitch.z = ((float)1 - this.Sanity / (float)100) * UnityEngine.Random.Range(-10f, 10f);
				this.NextTwitch = UnityEngine.Random.Range((float)0, 1f);
				this.TwitchTimer = (float)0;
			}
			this.Head.localEulerAngles = this.Head.localEulerAngles + this.Twitch;
			this.Twitch = Vector3.Lerp(this.Twitch, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
		}
		if (this.NearBodies > 0)
		{
			this.NearBody.Warn();
		}
		else
		{
			this.NearBody.Display = false;
		}
		if (this.transform.position.y < (float)-1 || Input.GetKeyDown("`"))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown("escape"))
		{
			Application.Quit();
		}
		if (Input.GetKeyDown("p"))
		{
			if (!this.Eyepatch.active)
			{
				this.Eyepatch.active = true;
			}
			else
			{
				this.Eyepatch.active = false;
			}
		}
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale -= (float)10;
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += (float)10;
		}
		if (Input.GetKey("."))
		{
			this.BreastSize += Time.deltaTime;
			if (this.BreastSize > (float)2)
			{
				this.BreastSize = (float)2;
			}
		}
		if (Input.GetKey(","))
		{
			this.BreastSize -= Time.deltaTime;
			if (this.BreastSize < (float)0)
			{
				this.BreastSize = (float)0;
			}
		}
		if (this.transform.position.z < (float)-50)
		{
			int num10 = -50;
			Vector3 position = this.transform.position;
			float num11 = position.z = (float)num10;
			Vector3 vector10 = this.transform.position = position;
		}
		this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
		this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
	}

	public virtual void ResetEffects()
	{
		this.DepthOfField.focalSize = (float)150;
		this.DepthOfField.focalZStartCurve = (float)0;
		this.DepthOfField.focalZEndCurve = (float)0;
		this.ColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
		this.ColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
		this.ColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
		this.ColorCorrection.redChannel.SmoothTangents(1, (float)0);
		this.ColorCorrection.greenChannel.SmoothTangents(1, (float)0);
		this.ColorCorrection.blueChannel.SmoothTangents(1, (float)0);
		this.ColorCorrection.UpdateTextures();
		this.ColorCorrection.enabled = false;
		this.DepthOfField.enabled = false;
		this.Character.animation["f02_shy_00"].weight = (float)0;
		this.HeartBeat.volume = (float)0;
	}

	public virtual void SpawnDumpChan()
	{
		UnityEngine.Object.Destroy(this.Ragdoll);
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.DumpChan, this.transform.position, Quaternion.identity);
		gameObject.transform.LookAt(this.Incinerator.transform.position);
		float y = gameObject.transform.eulerAngles.y + (float)180;
		Vector3 eulerAngles = gameObject.transform.eulerAngles;
		float num = eulerAngles.y = y;
		Vector3 vector = gameObject.transform.eulerAngles = eulerAngles;
	}

	public virtual void Unequip()
	{
		this.Weapon.active = false;
		this.DpadPressed = true;
		this.Armed = false;
		this.StudentManager.UpdateStudents();
		this.VisiblyArmed.Display = false;
	}

	public virtual void UpdateHeartRate()
	{
		if (this.Sanity > (float)100)
		{
			this.Sanity = (float)100;
		}
		else if (this.Sanity < (float)0)
		{
			this.Sanity = (float)0;
		}
		if (this.Sanity > 66.66666f)
		{
			this.HeartRate.SetHeartRateColour(this.HeartRate.NormalColour);
			if (this.PreviousSanity < 33.33333f)
			{
				this.VisiblyInsane.Display = false;
			}
		}
		else if (this.Sanity > 33.33333f)
		{
			this.HeartRate.SetHeartRateColour(this.HeartRate.MediumColour);
			if (this.PreviousSanity < 33.33333f)
			{
				this.VisiblyInsane.Display = false;
			}
		}
		else
		{
			this.HeartRate.SetHeartRateColour(this.HeartRate.BadColour);
			if (this.PreviousSanity > 33.33333f)
			{
				this.VisiblyInsane.Warn();
			}
		}
		this.HeartRate.BeatsPerMinute = (int)((float)240 - this.Sanity * 1.8f);
		this.PreviousSanity = this.Sanity;
	}

	public virtual void UpdateBlood()
	{
		if (this.PreviousBloodiness == (float)0 && this.Bloodiness > (float)0)
		{
			this.VisiblyBloody.Warn();
		}
		if (this.Bloodiness > (float)100)
		{
			this.Bloodiness = (float)100;
		}
		if (this.Bloodiness == (float)100)
		{
			this.MyRenderer.material.mainTexture = this.UniformTextures[5];
		}
		else if (this.Bloodiness >= (float)80)
		{
			this.MyRenderer.material.mainTexture = this.UniformTextures[4];
		}
		else if (this.Bloodiness >= (float)60)
		{
			this.MyRenderer.material.mainTexture = this.UniformTextures[3];
		}
		else if (this.Bloodiness >= (float)40)
		{
			this.MyRenderer.material.mainTexture = this.UniformTextures[2];
		}
		else if (this.Bloodiness >= (float)20)
		{
			this.MyRenderer.material.mainTexture = this.UniformTextures[1];
		}
		else
		{
			this.MyRenderer.material.mainTexture = this.UniformTextures[0];
			this.VisiblyBloody.Display = false;
		}
		this.PreviousBloodiness = this.Bloodiness;
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.RightFootprintSpawner.Bloodiness = 10;
			this.LeftFootprintSpawner.Bloodiness = 10;
		}
	}

	public virtual void Main()
	{
		this.Character.animation["f02_yanderePose_00"].layer = 1;
		this.Character.animation["f02_yanderePose_00"].weight = (float)0;
		this.Character.animation.Play("f02_yanderePose_00");
		this.Character.animation["f02_shy_00"].layer = 2;
		this.Character.animation["f02_shy_00"].weight = (float)0;
		this.Character.animation.Play("f02_shy_00");
		this.Character.animation["f02_fist_00"].layer = 3;
		this.Character.animation["f02_fist_00"].weight = (float)0;
		this.Character.animation.Play("f02_fist_00");
	}
}
