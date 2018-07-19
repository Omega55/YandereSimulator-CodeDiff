using System;
using UnityEngine;

public class RPG_Controller : MonoBehaviour
{
	public static RPG_Controller instance;

	public CharacterController characterController;

	public float walkSpeed = 10f;

	public float turnSpeed = 2.5f;

	public float jumpHeight = 10f;

	public float gravity = 20f;

	public float fallingThreshold = -6f;

	private Vector3 playerDir;

	private Vector3 playerDirWorld;

	private Vector3 rotation = Vector3.zero;

	private void Awake()
	{
		RPG_Controller.instance = this;
		this.characterController = (base.GetComponent("CharacterController") as CharacterController);
		RPG_Camera.CameraSetup();
	}

	private void Update()
	{
		if (Camera.main == null)
		{
			return;
		}
		if (this.characterController == null)
		{
			Debug.Log("Error: No Character Controller component found! Please add one to the GameObject which has this script attached.");
			return;
		}
		this.GetInput();
		this.StartMotor();
	}

	private void GetInput()
	{
		float d = 0f;
		float d2 = 0f;
		if (Input.GetButton("Horizontal Strafe"))
		{
			d = ((Input.GetAxis("Horizontal Strafe") >= 0f) ? ((Input.GetAxis("Horizontal Strafe") <= 0f) ? 0f : 1f) : -1f);
		}
		if (Input.GetButton("Vertical"))
		{
			d2 = ((Input.GetAxis("Vertical") >= 0f) ? ((Input.GetAxis("Vertical") <= 0f) ? 0f : 1f) : -1f);
		}
		if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
		{
			d2 = 1f;
		}
		this.playerDir = d * Vector3.right + d2 * Vector3.forward;
		if (RPG_Animation.instance != null)
		{
			RPG_Animation.instance.SetCurrentMoveDir(this.playerDir);
		}
		if (this.characterController.isGrounded)
		{
			this.playerDirWorld = base.transform.TransformDirection(this.playerDir);
			if (Mathf.Abs(this.playerDir.x) + Mathf.Abs(this.playerDir.z) > 1f)
			{
				this.playerDirWorld.Normalize();
			}
			this.playerDirWorld *= this.walkSpeed;
			this.playerDirWorld.y = this.fallingThreshold;
			if (Input.GetButtonDown("Jump"))
			{
				this.playerDirWorld.y = this.jumpHeight;
				if (RPG_Animation.instance != null)
				{
					RPG_Animation.instance.Jump();
				}
			}
		}
		this.rotation.y = Input.GetAxis("Horizontal") * this.turnSpeed;
	}

	private void StartMotor()
	{
		this.playerDirWorld.y = this.playerDirWorld.y - this.gravity * Time.deltaTime;
		this.characterController.Move(this.playerDirWorld * Time.deltaTime);
		base.transform.Rotate(this.rotation);
		if (!Input.GetMouseButton(0))
		{
			RPG_Camera.instance.RotateWithCharacter();
		}
	}
}
