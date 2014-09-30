using System;
using UnityEngine;

[Serializable]
public class TitleCuteYandereScript : MonoBehaviour
{
	public Transform MainCamera;

	public GameObject Character;

	public Transform RightShoulder;

	public Transform LeftShoulder;

	public Transform RightHand;

	public Transform LeftHand;

	public Transform RightArm;

	public Transform LeftArm;

	public Transform LeftLeg;

	public Transform Head;

	public float HandX;

	public float HandY;

	public float HandZ;

	public float ArmX;

	public float ArmY;

	public float ArmZ;

	public float LegX;

	public float LegY;

	public float LegZ;

	public bool Stop;

	public virtual void Start()
	{
		this.Character.animation["Smile"].layer = 1;
		this.Character.animation.Play("Smile");
		this.Character.animation["holdBookBag"].layer = 2;
		this.Character.animation.Play("holdBookBag");
	}

	public virtual void LateUpdate()
	{
		this.Head.LookAt(this.MainCamera.position);
		this.RightHand.LookAt(this.RightHand.position + Vector3.down * (float)10);
		this.LeftHand.LookAt(this.LeftHand.position + Vector3.down * (float)10);
		float y = this.RightHand.localEulerAngles.y - (float)90;
		Vector3 localEulerAngles = this.RightHand.localEulerAngles;
		float num = localEulerAngles.y = y;
		Vector3 vector = this.RightHand.localEulerAngles = localEulerAngles;
		float x = this.LeftHand.localEulerAngles.x + this.HandX;
		Vector3 localEulerAngles2 = this.LeftHand.localEulerAngles;
		float num2 = localEulerAngles2.x = x;
		Vector3 vector2 = this.LeftHand.localEulerAngles = localEulerAngles2;
		float y2 = this.LeftHand.localEulerAngles.y + this.HandY;
		Vector3 localEulerAngles3 = this.LeftHand.localEulerAngles;
		float num3 = localEulerAngles3.y = y2;
		Vector3 vector3 = this.LeftHand.localEulerAngles = localEulerAngles3;
		float z = this.LeftHand.localEulerAngles.z + this.HandZ;
		Vector3 localEulerAngles4 = this.LeftHand.localEulerAngles;
		float num4 = localEulerAngles4.z = z;
		Vector3 vector4 = this.LeftHand.localEulerAngles = localEulerAngles4;
		float x2 = this.RightArm.localEulerAngles.x + this.ArmX;
		Vector3 localEulerAngles5 = this.RightArm.localEulerAngles;
		float num5 = localEulerAngles5.x = x2;
		Vector3 vector5 = this.RightArm.localEulerAngles = localEulerAngles5;
		float y3 = this.RightArm.localEulerAngles.y - this.ArmY;
		Vector3 localEulerAngles6 = this.RightArm.localEulerAngles;
		float num6 = localEulerAngles6.y = y3;
		Vector3 vector6 = this.RightArm.localEulerAngles = localEulerAngles6;
		float z2 = this.RightArm.localEulerAngles.z - this.ArmZ;
		Vector3 localEulerAngles7 = this.RightArm.localEulerAngles;
		float num7 = localEulerAngles7.z = z2;
		Vector3 vector7 = this.RightArm.localEulerAngles = localEulerAngles7;
		float x3 = this.LeftArm.localEulerAngles.x + this.ArmX;
		Vector3 localEulerAngles8 = this.LeftArm.localEulerAngles;
		float num8 = localEulerAngles8.x = x3;
		Vector3 vector8 = this.LeftArm.localEulerAngles = localEulerAngles8;
		float y4 = this.LeftArm.localEulerAngles.y + this.ArmY;
		Vector3 localEulerAngles9 = this.LeftArm.localEulerAngles;
		float num9 = localEulerAngles9.y = y4;
		Vector3 vector9 = this.LeftArm.localEulerAngles = localEulerAngles9;
		float z3 = this.LeftArm.localEulerAngles.z + this.ArmZ;
		Vector3 localEulerAngles10 = this.LeftArm.localEulerAngles;
		float num10 = localEulerAngles10.z = z3;
		Vector3 vector10 = this.LeftArm.localEulerAngles = localEulerAngles10;
		float x4 = this.LeftLeg.localEulerAngles.x + this.LegX;
		Vector3 localEulerAngles11 = this.LeftLeg.localEulerAngles;
		float num11 = localEulerAngles11.x = x4;
		Vector3 vector11 = this.LeftLeg.localEulerAngles = localEulerAngles11;
		float y5 = this.LeftLeg.localEulerAngles.y + this.LegY;
		Vector3 localEulerAngles12 = this.LeftLeg.localEulerAngles;
		float num12 = localEulerAngles12.y = y5;
		Vector3 vector12 = this.LeftLeg.localEulerAngles = localEulerAngles12;
		float z4 = this.LeftLeg.localEulerAngles.z + this.LegZ;
		Vector3 localEulerAngles13 = this.LeftLeg.localEulerAngles;
		float num13 = localEulerAngles13.z = z4;
		Vector3 vector13 = this.LeftLeg.localEulerAngles = localEulerAngles13;
		this.Character.animation["student_idle"].speed = (float)0;
	}

	public virtual void Main()
	{
	}
}
