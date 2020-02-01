using System;
using UnityEngine;

public class StalkerYandereScript : MonoBehaviour
{
	public CharacterController MyController;

	public Transform TrellisClimbSpot;

	public Transform CameraTarget;

	public Transform EntryPOV;

	public Transform Hips;

	public RPG_Camera RPGCamera;

	public Animation MyAnimation;

	public AudioSource Jukebox;

	public Camera MainCamera;

	public bool Climbing;

	public bool Running;

	public bool CanMove;

	public bool Street;

	public Stance Stance = new Stance(StanceType.Standing);

	public string IdleAnim;

	public string WalkAnim;

	public string RunAnim;

	public string CrouchIdleAnim;

	public string CrouchWalkAnim;

	public string CrouchRunAnim;

	public float WalkSpeed;

	public float RunSpeed;

	public float CrouchWalkSpeed;

	public float CrouchRunSpeed;

	public int ClimbPhase;

	public int Frame;

	private void Update()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		if (Input.GetKeyDown("=") && Time.timeScale < 10f)
		{
			Time.timeScale += 1f;
		}
		if (Input.GetKeyDown("-") && Time.timeScale > 1f)
		{
			Time.timeScale -= 1f;
		}
		if (Input.GetKeyDown("m"))
		{
			PlayerGlobals.Money += 1f;
			if (this.Jukebox != null)
			{
				if (this.Jukebox.isPlaying)
				{
					this.Jukebox.Stop();
				}
				else
				{
					this.Jukebox.Play();
				}
			}
		}
		if (this.CanMove)
		{
			if (this.CameraTarget != null)
			{
				this.CameraTarget.localPosition = new Vector3(0f, 1f + (this.RPGCamera.distanceMax - this.RPGCamera.distance) * 0.2f, 0f);
			}
			this.UpdateMovement();
		}
		else if (this.CameraTarget != null && this.Climbing)
		{
			if (this.ClimbPhase == 1)
			{
				if (this.MyAnimation["f02_climbTrellis_00"].time < this.MyAnimation["f02_climbTrellis_00"].length - 1f)
				{
					this.CameraTarget.position = Vector3.MoveTowards(this.CameraTarget.position, this.Hips.position + new Vector3(0f, 0.103729f, 0.003539f), Time.deltaTime);
				}
				else
				{
					this.CameraTarget.position = Vector3.MoveTowards(this.CameraTarget.position, new Vector3(-9.5f, 5f, -2.5f), Time.deltaTime);
				}
				this.MoveTowardsTarget(this.TrellisClimbSpot.position);
				this.SpinTowardsTarget(this.TrellisClimbSpot.rotation);
				if (this.MyAnimation["f02_climbTrellis_00"].time > 7.5f)
				{
					this.RPGCamera.transform.position = this.EntryPOV.position;
					this.RPGCamera.transform.eulerAngles = this.EntryPOV.eulerAngles;
					this.RPGCamera.enabled = false;
					RenderSettings.ambientIntensity = 8f;
					this.ClimbPhase++;
				}
			}
			else
			{
				this.RPGCamera.transform.position = this.EntryPOV.position;
				this.RPGCamera.transform.eulerAngles = this.EntryPOV.eulerAngles;
				if (this.MyAnimation["f02_climbTrellis_00"].time > 11f)
				{
					base.transform.position = Vector3.MoveTowards(base.transform.position, this.TrellisClimbSpot.position + new Vector3(0.4f, 0f, 0f), Time.deltaTime * 0.5f);
				}
			}
			if (this.MyAnimation["f02_climbTrellis_00"].time > this.MyAnimation["f02_climbTrellis_00"].length)
			{
				this.MyAnimation.Play(this.IdleAnim);
				base.transform.position = new Vector3(-9.1f, 4f, -2.5f);
				this.CameraTarget.position = base.transform.position + new Vector3(0f, 1f, 0f);
				this.RPGCamera.enabled = true;
				this.Climbing = false;
				this.CanMove = true;
			}
		}
		if (this.Street && base.transform.position.x < -16f)
		{
			base.transform.position = new Vector3(-16f, 0f, base.transform.position.z);
		}
	}

	private void UpdateMovement()
	{
		if (!OptionGlobals.ToggleRun)
		{
			this.Running = false;
			if (Input.GetButton("LB"))
			{
				this.Running = true;
			}
		}
		else if (Input.GetButtonDown("LB"))
		{
			this.Running = !this.Running;
		}
		this.MyController.Move(Physics.gravity * Time.deltaTime);
		float axis = Input.GetAxis("Vertical");
		float axis2 = Input.GetAxis("Horizontal");
		Vector3 a = this.MainCamera.transform.TransformDirection(Vector3.forward);
		a.y = 0f;
		a = a.normalized;
		Vector3 a2 = new Vector3(a.z, 0f, -a.x);
		Vector3 vector = axis2 * a2 + axis * a;
		Quaternion b = Quaternion.identity;
		if (vector != Vector3.zero)
		{
			b = Quaternion.LookRotation(vector);
		}
		if (vector != Vector3.zero)
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime * 10f);
		}
		else
		{
			b = new Quaternion(0f, 0f, 0f, 0f);
		}
		if (!this.Street)
		{
			if (this.Stance.Current == StanceType.Standing)
			{
				if (Input.GetButtonDown("RS"))
				{
					this.Stance.Current = StanceType.Crouching;
				}
			}
			else if (Input.GetButtonDown("RS"))
			{
				this.Stance.Current = StanceType.Standing;
			}
		}
		if (axis != 0f || axis2 != 0f)
		{
			if (this.Running)
			{
				if (this.Stance.Current == StanceType.Crouching)
				{
					this.MyAnimation.CrossFade(this.CrouchRunAnim);
					this.MyController.Move(base.transform.forward * this.CrouchRunSpeed * Time.deltaTime);
				}
				else
				{
					this.MyAnimation.CrossFade(this.RunAnim);
					this.MyController.Move(base.transform.forward * this.RunSpeed * Time.deltaTime);
				}
			}
			else if (this.Stance.Current == StanceType.Crouching)
			{
				this.MyAnimation.CrossFade(this.CrouchWalkAnim);
				this.MyController.Move(base.transform.forward * (this.CrouchWalkSpeed * Time.deltaTime));
			}
			else
			{
				this.MyAnimation.CrossFade(this.WalkAnim);
				this.MyController.Move(base.transform.forward * (this.WalkSpeed * Time.deltaTime));
			}
		}
		else if (this.Stance.Current == StanceType.Crouching)
		{
			this.MyAnimation.CrossFade(this.CrouchIdleAnim);
		}
		else
		{
			this.MyAnimation.CrossFade(this.IdleAnim);
		}
	}

	private void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		this.MyController.Move(a * (Time.deltaTime * 10f));
	}

	private void SpinTowardsTarget(Quaternion target)
	{
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, target, Time.deltaTime * 10f);
	}
}
