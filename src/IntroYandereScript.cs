using System;
using UnityEngine;

[Serializable]
public class IntroYandereScript : MonoBehaviour
{
	public Transform Hips;

	public Transform Spine;

	public Transform Spine1;

	public Transform Spine2;

	public Transform Spine3;

	public Transform Neck;

	public Transform Head;

	public Transform RightUpLeg;

	public Transform RightLeg;

	public Transform RightFoot;

	public Transform LeftUpLeg;

	public Transform LeftLeg;

	public Transform LeftFoot;

	public float X;

	public virtual void LateUpdate()
	{
		float x = this.Hips.localEulerAngles.x + this.X;
		Vector3 localEulerAngles = this.Hips.localEulerAngles;
		float num = localEulerAngles.x = x;
		Vector3 vector = this.Hips.localEulerAngles = localEulerAngles;
		float x2 = this.Spine.localEulerAngles.x + this.X;
		Vector3 localEulerAngles2 = this.Spine.localEulerAngles;
		float num2 = localEulerAngles2.x = x2;
		Vector3 vector2 = this.Spine.localEulerAngles = localEulerAngles2;
		float x3 = this.Spine1.localEulerAngles.x + this.X;
		Vector3 localEulerAngles3 = this.Spine1.localEulerAngles;
		float num3 = localEulerAngles3.x = x3;
		Vector3 vector3 = this.Spine1.localEulerAngles = localEulerAngles3;
		float x4 = this.Spine2.localEulerAngles.x + this.X;
		Vector3 localEulerAngles4 = this.Spine2.localEulerAngles;
		float num4 = localEulerAngles4.x = x4;
		Vector3 vector4 = this.Spine2.localEulerAngles = localEulerAngles4;
		float x5 = this.Spine3.localEulerAngles.x + this.X;
		Vector3 localEulerAngles5 = this.Spine3.localEulerAngles;
		float num5 = localEulerAngles5.x = x5;
		Vector3 vector5 = this.Spine3.localEulerAngles = localEulerAngles5;
		float x6 = this.Neck.localEulerAngles.x + this.X;
		Vector3 localEulerAngles6 = this.Neck.localEulerAngles;
		float num6 = localEulerAngles6.x = x6;
		Vector3 vector6 = this.Neck.localEulerAngles = localEulerAngles6;
		float x7 = this.Head.localEulerAngles.x + this.X;
		Vector3 localEulerAngles7 = this.Head.localEulerAngles;
		float num7 = localEulerAngles7.x = x7;
		Vector3 vector7 = this.Head.localEulerAngles = localEulerAngles7;
		float x8 = this.RightUpLeg.localEulerAngles.x - this.X;
		Vector3 localEulerAngles8 = this.RightUpLeg.localEulerAngles;
		float num8 = localEulerAngles8.x = x8;
		Vector3 vector8 = this.RightUpLeg.localEulerAngles = localEulerAngles8;
		float x9 = this.RightLeg.localEulerAngles.x - this.X;
		Vector3 localEulerAngles9 = this.RightLeg.localEulerAngles;
		float num9 = localEulerAngles9.x = x9;
		Vector3 vector9 = this.RightLeg.localEulerAngles = localEulerAngles9;
		float x10 = this.RightFoot.localEulerAngles.x - this.X;
		Vector3 localEulerAngles10 = this.RightFoot.localEulerAngles;
		float num10 = localEulerAngles10.x = x10;
		Vector3 vector10 = this.RightFoot.localEulerAngles = localEulerAngles10;
		float x11 = this.LeftUpLeg.localEulerAngles.x - this.X;
		Vector3 localEulerAngles11 = this.LeftUpLeg.localEulerAngles;
		float num11 = localEulerAngles11.x = x11;
		Vector3 vector11 = this.LeftUpLeg.localEulerAngles = localEulerAngles11;
		float x12 = this.LeftLeg.localEulerAngles.x - this.X;
		Vector3 localEulerAngles12 = this.LeftLeg.localEulerAngles;
		float num12 = localEulerAngles12.x = x12;
		Vector3 vector12 = this.LeftLeg.localEulerAngles = localEulerAngles12;
		float x13 = this.LeftFoot.localEulerAngles.x - this.X;
		Vector3 localEulerAngles13 = this.LeftFoot.localEulerAngles;
		float num13 = localEulerAngles13.x = x13;
		Vector3 vector13 = this.LeftFoot.localEulerAngles = localEulerAngles13;
	}

	public virtual void Main()
	{
	}
}
