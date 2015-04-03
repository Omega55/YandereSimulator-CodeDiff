using System;
using UnityEngine;

[Serializable]
public class CharacterScript : MonoBehaviour
{
	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform ItemParent;

	public Transform PelvisRoot;

	public Transform RightEye;

	public Transform LeftEye;

	public Transform Head;

	public Transform[] Spine;

	public Transform[] Arm;

	public SkinnedMeshRenderer MyRenderer;

	public Renderer RightYandereEye;

	public Renderer LeftYandereEye;

	public virtual void SetAnimations()
	{
		this.animation["f02_yanderePose_00"].layer = 1;
		this.animation["f02_yanderePose_00"].weight = (float)0;
		this.animation.Play("f02_yanderePose_00");
		this.animation["f02_shy_00"].layer = 2;
		this.animation["f02_shy_00"].weight = (float)0;
		this.animation.Play("f02_shy_00");
		this.animation["f02_fist_00"].layer = 3;
		this.animation["f02_fist_00"].weight = (float)0;
		this.animation.Play("f02_fist_00");
		this.animation["f02_mopping_00"].layer = 4;
		this.animation["f02_mopping_00"].weight = (float)0;
		this.animation["f02_mopping_00"].speed = (float)2;
		this.animation.Play("f02_mopping_00");
		this.animation["f02_carry_00"].layer = 5;
		this.animation["f02_carry_00"].weight = (float)0;
		this.animation.Play("f02_carry_00");
		this.animation["f02_mopCarry_00"].layer = 6;
		this.animation["f02_mopCarry_00"].weight = (float)0;
		this.animation.Play("f02_mopCarry_00");
		this.animation["f02_bucketCarry_00"].layer = 7;
		this.animation["f02_bucketCarry_00"].weight = (float)0;
		this.animation.Play("f02_bucketCarry_00");
		this.animation["f02_cameraPose_00"].layer = 8;
		this.animation["f02_cameraPose_00"].weight = (float)0;
		this.animation.Play("f02_cameraPose_00");
		this.animation["f02_dipping_00"].speed = (float)2;
		this.animation["f02_cameraPose_00"].weight = (float)0;
		this.animation["f02_shy_00"].weight = (float)0;
	}

	public virtual void Main()
	{
	}
}
