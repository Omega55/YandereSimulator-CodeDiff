using System;
using UnityEngine;

[Serializable]
public class GradingPaperScript : MonoBehaviour
{
	public StudentScript Teacher;

	public GameObject Character;

	public Transform LeftHand;

	public Transform Chair;

	public Transform Paper;

	public float PickUpTime1;

	public float SetDownTime1;

	public float PickUpTime2;

	public float SetDownTime2;

	public Vector3 OriginalPosition;

	public Vector3 PickUpPosition1;

	public Vector3 SetDownPosition1;

	public Vector3 PickUpPosition2;

	public Vector3 PickUpRotation1;

	public Vector3 SetDownRotation1;

	public Vector3 PickUpRotation2;

	public int Phase;

	public float Speed;

	public bool Writing;

	public GradingPaperScript()
	{
		this.Phase = 1;
		this.Speed = 1f;
	}

	public virtual void Start()
	{
		this.OriginalPosition = this.Chair.position;
	}

	public virtual void Update()
	{
		if (!this.Writing)
		{
			this.Chair.position = Vector3.Lerp(this.Chair.position, this.OriginalPosition, Time.deltaTime * (float)10);
		}
		else
		{
			this.Chair.position = Vector3.Lerp(this.Chair.position, this.Character.transform.position + this.Character.transform.forward * 0.1f, Time.deltaTime * (float)10);
			if (this.Phase == 1)
			{
				if (this.Character.animation["f02_deskWrite"].time > this.PickUpTime1)
				{
					this.Character.animation["f02_deskWrite"].speed = this.Speed;
					this.Paper.parent = this.LeftHand;
					this.Paper.localPosition = this.PickUpPosition1;
					this.Paper.localEulerAngles = this.PickUpRotation1;
					this.Paper.localScale = new Vector3(0.9090909f, 0.9090909f, 0.9090909f);
					this.Phase++;
				}
			}
			else if (this.Phase == 2)
			{
				if (this.Character.animation["f02_deskWrite"].time > this.SetDownTime1)
				{
					this.Paper.parent = this.Character.transform;
					this.Paper.localPosition = this.SetDownPosition1;
					this.Paper.localEulerAngles = this.SetDownRotation1;
					this.Phase++;
				}
			}
			else if (this.Phase == 3)
			{
				if (this.Character.animation["f02_deskWrite"].time > this.PickUpTime2)
				{
					this.Paper.parent = this.LeftHand;
					this.Paper.localPosition = this.PickUpPosition2;
					this.Paper.localEulerAngles = this.PickUpRotation2;
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				if (this.Character.animation["f02_deskWrite"].time > this.SetDownTime2)
				{
					this.Paper.parent = this.Character.transform;
					this.Paper.localScale = new Vector3((float)0, (float)0, (float)0);
					this.Phase++;
				}
			}
			else if (this.Phase == 5 && this.Character.animation["f02_deskWrite"].time >= this.Character.animation["f02_deskWrite"].length)
			{
				this.Character.animation["f02_deskWrite"].time = (float)0;
				this.Character.animation.Play("f02_deskWrite");
				this.Phase = 1;
			}
			if (this.Teacher.Actions[this.Teacher.Phase] != 12 || !this.Teacher.Routine || this.Teacher.Stop)
			{
				this.Paper.localScale = new Vector3((float)0, (float)0, (float)0);
				this.Teacher.Pen.active = false;
				this.Writing = false;
				this.Phase = 1;
			}
		}
	}

	public virtual void Main()
	{
	}
}
