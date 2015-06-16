﻿using System;
using UnityEngine;

[Serializable]
public class DoorOpenerScript : MonoBehaviour
{
	public StudentScript Student;

	public DoorScript Door;

	public virtual void OnTriggerStay(Collider other)
	{
		this.Student = (StudentScript)other.gameObject.GetComponent(typeof(StudentScript));
		if (this.Student != null && !this.Student.Dying && !this.Door.Open)
		{
			this.Door.Student = this.Student;
			this.Door.OpenDoor();
		}
	}

	public virtual void Main()
	{
	}
}
