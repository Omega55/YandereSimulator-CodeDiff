using System;
using UnityEngine;

[Serializable]
public class DoorOpenerScript : MonoBehaviour
{
	public StudentScript Student;

	public DoorScript Door;

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			this.Student = (StudentScript)other.gameObject.GetComponent(typeof(StudentScript));
			if (this.Student != null && !this.Student.Dying && !this.Door.Open && !this.Door.Locked)
			{
				this.Door.Student = this.Student;
				this.Door.OpenDoor();
			}
		}
	}

	public virtual void Main()
	{
	}
}
