using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class StudentManagerScript : MonoBehaviour
{
	private GameObject NewStudent;

	public StudentScript[] Students;

	public YandereScript Yandere;

	public ClockScript Clock;

	public ListScript Lockers;

	public ListScript LockerFs;

	public ListScript Classrooms;

	public ListScript ClassroomFs;

	public ListScript Hangouts;

	public ListScript HangoutFs;

	public Transform[] SpawnPositions;

	public GameObject StudentChan;

	public float[] SpawnTimes;

	public int StudentsSpawned;

	public int StudentsTotal;

	public int ID;

	public StudentManagerScript()
	{
		this.StudentsTotal = 5;
	}

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
		if (this.StudentsSpawned < this.StudentsTotal && this.Clock.PresentTime / (float)60 >= this.SpawnTimes[this.StudentsSpawned])
		{
			this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.StudentChan, this.SpawnPositions[this.StudentsSpawned].position, Quaternion.identity);
			this.Students[this.StudentsSpawned] = (StudentScript)this.NewStudent.GetComponent(typeof(StudentScript));
			this.Students[this.StudentsSpawned].StudentID = this.StudentsSpawned;
			this.Students[this.StudentsSpawned].StudentManager = this;
			this.StudentsSpawned++;
		}
	}

	public virtual void UpdateStudents()
	{
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null)
			{
				if (this.Yandere.Armed)
				{
					this.Students[this.ID].Prompt.HideButton[0] = true;
					this.Students[this.ID].Prompt.HideButton[2] = false;
				}
				else
				{
					this.Students[this.ID].Prompt.HideButton[0] = false;
					this.Students[this.ID].Prompt.HideButton[2] = true;
				}
			}
			this.ID++;
		}
	}

	public virtual void EnablePrompts()
	{
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null)
			{
				this.Students[this.ID].Prompt.enabled = true;
			}
			this.ID++;
		}
	}

	public virtual void DisablePrompts()
	{
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null)
			{
				this.Students[this.ID].Prompt.Hide();
				this.Students[this.ID].Prompt.enabled = false;
			}
			this.ID++;
		}
	}

	public virtual void Main()
	{
	}
}
