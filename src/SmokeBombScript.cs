using System;
using UnityEngine;

public class SmokeBombScript : MonoBehaviour
{
	public StudentScript[] Students;

	public float Timer;

	public bool Amnesia;

	public bool Stink;

	public int ID;

	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 15f)
		{
			if (!this.Stink)
			{
				foreach (StudentScript studentScript in this.Students)
				{
					if (studentScript != null)
					{
						studentScript.Blind = false;
					}
				}
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				if (this.Stink)
				{
					this.GoAway(component);
				}
				else
				{
					if (this.Amnesia)
					{
						component.ReturnToNormal();
					}
					this.Students[this.ID] = component;
					component.Blind = true;
					this.ID++;
				}
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (this.Stink)
		{
			if (other.gameObject.layer == 9)
			{
				StudentScript component = other.gameObject.GetComponent<StudentScript>();
				if (component != null)
				{
					this.GoAway(component);
				}
			}
		}
		else if (this.Amnesia && other.gameObject.layer == 9)
		{
			StudentScript component2 = other.gameObject.GetComponent<StudentScript>();
			if (component2 != null && component2.Alarmed)
			{
				component2.ReturnToNormal();
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (!this.Stink && other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				Debug.Log(component.Name + " left a smoke cloud and stopped being blind.");
				component.Blind = false;
			}
		}
	}

	private void GoAway(StudentScript Student)
	{
		Student.CurrentDestination = Student.StudentManager.GoAwaySpots.List[Student.StudentID];
		Student.Pathfinding.target = Student.StudentManager.GoAwaySpots.List[Student.StudentID];
		Student.CharacterAnimation.CrossFade(Student.SprintAnim);
		Student.Pathfinding.speed = 4f;
		Student.GoAwayTimer = 11f;
		Student.Routine = false;
		Student.GoAway = true;
	}
}
