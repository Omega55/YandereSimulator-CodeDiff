using System;
using UnityEngine;

public class RPG_Animation : MonoBehaviour
{
	public enum CharacterMoveDirection
	{
		None,
		Forward,
		Backward,
		StrafeLeft,
		StrafeRight,
		StrafeForwardLeft,
		StrafeForwardRight,
		StrafeBackLeft,
		StrafeBackRight
	}

	public enum CharacterState
	{
		Idle,
		Walk,
		WalkBack,
		StrafeLeft,
		StrafeRight,
		Jump
	}

	public static RPG_Animation instance;

	public RPG_Animation.CharacterMoveDirection currentMoveDir;

	public RPG_Animation.CharacterState currentState;

	private void Awake()
	{
		RPG_Animation.instance = this;
	}

	private void Update()
	{
		this.SetCurrentState();
		this.StartAnimation();
	}

	public void SetCurrentMoveDir(Vector3 playerDir)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		if (playerDir.z > 0f)
		{
			flag = true;
		}
		if (playerDir.z < 0f)
		{
			flag2 = true;
		}
		if (playerDir.x < 0f)
		{
			flag3 = true;
		}
		if (playerDir.x > 0f)
		{
			flag4 = true;
		}
		if (flag)
		{
			if (flag3)
			{
				this.currentMoveDir = RPG_Animation.CharacterMoveDirection.StrafeForwardLeft;
				return;
			}
			if (flag4)
			{
				this.currentMoveDir = RPG_Animation.CharacterMoveDirection.StrafeForwardRight;
				return;
			}
			this.currentMoveDir = RPG_Animation.CharacterMoveDirection.Forward;
			return;
		}
		else if (flag2)
		{
			if (flag3)
			{
				this.currentMoveDir = RPG_Animation.CharacterMoveDirection.StrafeBackLeft;
				return;
			}
			if (flag4)
			{
				this.currentMoveDir = RPG_Animation.CharacterMoveDirection.StrafeBackRight;
				return;
			}
			this.currentMoveDir = RPG_Animation.CharacterMoveDirection.Backward;
			return;
		}
		else
		{
			if (flag3)
			{
				this.currentMoveDir = RPG_Animation.CharacterMoveDirection.StrafeLeft;
				return;
			}
			if (flag4)
			{
				this.currentMoveDir = RPG_Animation.CharacterMoveDirection.StrafeRight;
				return;
			}
			this.currentMoveDir = RPG_Animation.CharacterMoveDirection.None;
			return;
		}
	}

	public void SetCurrentState()
	{
		if (RPG_Controller.instance.characterController.isGrounded)
		{
			switch (this.currentMoveDir)
			{
			case RPG_Animation.CharacterMoveDirection.None:
				this.currentState = RPG_Animation.CharacterState.Idle;
				return;
			case RPG_Animation.CharacterMoveDirection.Forward:
				this.currentState = RPG_Animation.CharacterState.Walk;
				return;
			case RPG_Animation.CharacterMoveDirection.Backward:
				this.currentState = RPG_Animation.CharacterState.WalkBack;
				return;
			case RPG_Animation.CharacterMoveDirection.StrafeLeft:
				this.currentState = RPG_Animation.CharacterState.StrafeLeft;
				return;
			case RPG_Animation.CharacterMoveDirection.StrafeRight:
				this.currentState = RPG_Animation.CharacterState.StrafeRight;
				break;
			case RPG_Animation.CharacterMoveDirection.StrafeForwardLeft:
				this.currentState = RPG_Animation.CharacterState.Walk;
				return;
			case RPG_Animation.CharacterMoveDirection.StrafeForwardRight:
				this.currentState = RPG_Animation.CharacterState.Walk;
				return;
			case RPG_Animation.CharacterMoveDirection.StrafeBackLeft:
				this.currentState = RPG_Animation.CharacterState.WalkBack;
				return;
			case RPG_Animation.CharacterMoveDirection.StrafeBackRight:
				this.currentState = RPG_Animation.CharacterState.WalkBack;
				return;
			default:
				return;
			}
		}
	}

	public void StartAnimation()
	{
		switch (this.currentState)
		{
		case RPG_Animation.CharacterState.Idle:
			this.Idle();
			return;
		case RPG_Animation.CharacterState.Walk:
			if (this.currentMoveDir == RPG_Animation.CharacterMoveDirection.StrafeForwardLeft)
			{
				this.StrafeForwardLeft();
				return;
			}
			if (this.currentMoveDir == RPG_Animation.CharacterMoveDirection.StrafeForwardRight)
			{
				this.StrafeForwardRight();
				return;
			}
			this.Walk();
			return;
		case RPG_Animation.CharacterState.WalkBack:
			if (this.currentMoveDir == RPG_Animation.CharacterMoveDirection.StrafeBackLeft)
			{
				this.StrafeBackLeft();
				return;
			}
			if (this.currentMoveDir == RPG_Animation.CharacterMoveDirection.StrafeBackRight)
			{
				this.StrafeBackRight();
				return;
			}
			this.WalkBack();
			return;
		case RPG_Animation.CharacterState.StrafeLeft:
			this.StrafeLeft();
			return;
		case RPG_Animation.CharacterState.StrafeRight:
			this.StrafeRight();
			return;
		default:
			return;
		}
	}

	private void Idle()
	{
		base.GetComponent<Animation>().CrossFade("idle");
	}

	private void Walk()
	{
		base.GetComponent<Animation>().CrossFade("walk");
	}

	private void StrafeForwardLeft()
	{
		base.GetComponent<Animation>().CrossFade("strafeforwardleft");
	}

	private void StrafeForwardRight()
	{
		base.GetComponent<Animation>().CrossFade("strafeforwardright");
	}

	private void WalkBack()
	{
		base.GetComponent<Animation>().CrossFade("walkback");
	}

	private void StrafeBackLeft()
	{
		base.GetComponent<Animation>().CrossFade("strafebackleft");
	}

	private void StrafeBackRight()
	{
		base.GetComponent<Animation>().CrossFade("strafebackright");
	}

	private void StrafeLeft()
	{
		base.GetComponent<Animation>().CrossFade("strafeleft");
	}

	private void StrafeRight()
	{
		base.GetComponent<Animation>().CrossFade("straferight");
	}

	public void Jump()
	{
		this.currentState = RPG_Animation.CharacterState.Jump;
		if (base.GetComponent<Animation>().IsPlaying("jump"))
		{
			base.GetComponent<Animation>().Stop("jump");
		}
		base.GetComponent<Animation>().CrossFade("jump");
	}
}
