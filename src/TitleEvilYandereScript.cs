using System;
using UnityEngine;

[Serializable]
public class TitleEvilYandereScript : MonoBehaviour
{
	public GameObject Character;

	public GameObject BloodEmitter;

	public GameObject SeveredHead;

	public GameObject Senpai;

	public GameObject Knife;

	public Transform MainCamera;

	public Transform RightArm;

	public Transform Head;

	public int ArmX;

	public int ArmY;

	public int ArmZ;

	public int AnimationID;

	public TitleEvilYandereScript()
	{
		this.AnimationID = 1;
	}

	public virtual void Start()
	{
		this.transform.position = new Vector3(0.6666667f, -0.8f, 1.66666f);
		this.transform.localEulerAngles = new Vector3((float)0, (float)225, (float)0);
		this.BloodEmitter.active = false;
		this.SeveredHead.active = false;
		this.Senpai.active = false;
		this.Knife.active = false;
		this.Character.animation.Stop();
		if (this.AnimationID > 3)
		{
			this.AnimationID = 1;
		}
		if (this.AnimationID == 1)
		{
			this.BloodEmitter.active = true;
			this.SeveredHead.active = true;
			this.Character.animation["student_idle"].layer = 0;
			this.Character.animation.Play("student_idle");
			this.Character.animation["holdBookBag"].layer = 1;
			this.Character.animation.Play("holdBookBag");
		}
		else if (this.AnimationID == 2)
		{
			this.Senpai.active = true;
			this.Knife.active = true;
			this.Character.animation["YanderePose"].layer = 0;
			this.Character.animation.Play("YanderePose");
			this.Character.animation["clenchFist"].layer = 1;
			this.Character.animation.Play("clenchFist");
			this.Character.animation["Stabbing"].speed = (float)10;
			this.Character.animation["Stabbing"].layer = 2;
			this.Character.animation.Play("Stabbing");
		}
		else if (this.AnimationID == 3)
		{
			this.transform.position = new Vector3(0.1f, -1.525f, 0.25f);
			this.transform.localEulerAngles = new Vector3((float)0, (float)180, (float)0);
			this.Character.animation["student_idle"].layer = 0;
			this.Character.animation.Play("student_idle");
		}
	}

	public virtual void LateUpdate()
	{
		if (this.AnimationID == 1)
		{
			this.Head.LookAt(this.MainCamera.position);
			float x = this.RightArm.localEulerAngles.x + (float)this.ArmX;
			Vector3 localEulerAngles = this.RightArm.localEulerAngles;
			float num = localEulerAngles.x = x;
			Vector3 vector = this.RightArm.localEulerAngles = localEulerAngles;
			float y = this.RightArm.localEulerAngles.y - (float)this.ArmY;
			Vector3 localEulerAngles2 = this.RightArm.localEulerAngles;
			float num2 = localEulerAngles2.y = y;
			Vector3 vector2 = this.RightArm.localEulerAngles = localEulerAngles2;
			float z = this.RightArm.localEulerAngles.z - (float)this.ArmZ;
			Vector3 localEulerAngles3 = this.RightArm.localEulerAngles;
			float num3 = localEulerAngles3.z = z;
			Vector3 vector3 = this.RightArm.localEulerAngles = localEulerAngles3;
		}
		else if (this.AnimationID == 3)
		{
			this.Head.LookAt(this.MainCamera.position);
		}
	}

	public virtual void Main()
	{
	}
}
