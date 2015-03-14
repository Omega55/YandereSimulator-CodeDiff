using System;
using UnityEngine;

[Serializable]
public class EmergencyExitScript : MonoBehaviour
{
	public StudentScript FleeingStudent;

	public StudentScript Student;

	public Collider StudentCollider;

	public Transform Neighborhood;

	public Transform Gateway;

	public Transform Pivot;

	public bool Open;

	public float Timer;

	public virtual void Update()
	{
		if (!this.Open)
		{
			float y = Mathf.Lerp(this.Pivot.localEulerAngles.y, (float)0, Time.deltaTime * (float)10);
			Vector3 localEulerAngles = this.Pivot.localEulerAngles;
			float num = localEulerAngles.y = y;
			Vector3 vector = this.Pivot.localEulerAngles = localEulerAngles;
		}
		else
		{
			float y2 = Mathf.Lerp(this.Pivot.localEulerAngles.y, (float)90, Time.deltaTime * (float)10);
			Vector3 localEulerAngles2 = this.Pivot.localEulerAngles;
			float num2 = localEulerAngles2.y = y2;
			Vector3 vector2 = this.Pivot.localEulerAngles = localEulerAngles2;
			if (this.FleeingStudent != null && this.Pivot.localEulerAngles.y > (float)89)
			{
				this.FleeingStudent.Pathfinding.target = this.Neighborhood;
				this.FleeingStudent.Pathfinding.SearchPath();
			}
			if (this.Student == null)
			{
				this.Open = false;
			}
		}
	}

	public virtual void OnTriggerStay(Collider other)
	{
		this.Student = (StudentScript)other.gameObject.GetComponent(typeof(StudentScript));
		if (this.Student != null)
		{
			this.StudentCollider = other;
			if (this.Student.Fleeing)
			{
				this.FleeingStudent = this.Student;
				this.Open = true;
			}
		}
	}

	public virtual void OnTriggerExit(Collider other)
	{
		if (other == this.StudentCollider)
		{
			this.Open = false;
		}
	}

	public virtual void Main()
	{
	}
}
