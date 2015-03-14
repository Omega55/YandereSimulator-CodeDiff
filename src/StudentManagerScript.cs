using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class StudentManagerScript : MonoBehaviour
{
	private PortraitChanScript NewPortraitChan;

	private GameObject NewStudent;

	public StudentScript[] Students;

	public EmergencyExitScript EmergencyExit;

	public WitnessCameraScript WitnessCamera;

	public YandereScript Yandere;

	public ClockScript Clock;

	public JsonScript JSON;

	public ListScript Lockers;

	public ListScript LockerFs;

	public ListScript Classrooms;

	public ListScript ClassroomFs;

	public ListScript Hangouts;

	public ListScript HangoutFs;

	public Transform[] SpawnPositions;

	public GameObject PortraitChan;

	public GameObject StudentChan;

	public GhostScript GhostChan;

	public float[] SpawnTimes;

	public int StudentsSpawned;

	public int StudentsTotal;

	public int ID;

	public Texture[] Colors;

	public bool TakingPortraits;

	public int Frame;

	public bool AoT;

	public StudentManagerScript()
	{
		this.StudentsTotal = 5;
	}

	public virtual void Update()
	{
		if (!this.TakingPortraits)
		{
			if (this.StudentsSpawned < this.StudentsTotal && this.Clock.PresentTime / (float)60 >= this.SpawnTimes[this.StudentsSpawned])
			{
				this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.StudentChan, this.SpawnPositions[this.StudentsSpawned].position, Quaternion.identity);
				this.Students[this.StudentsSpawned] = (StudentScript)this.NewStudent.GetComponent(typeof(StudentScript));
				this.Students[this.StudentsSpawned].StudentID = this.StudentsSpawned + 1;
				this.Students[this.StudentsSpawned].WitnessCamera = this.WitnessCamera;
				this.Students[this.StudentsSpawned].StudentManager = this;
				this.Students[this.StudentsSpawned].JSON = this.JSON;
				if (this.AoT)
				{
					this.Students[this.StudentsSpawned].AoT = true;
				}
				this.StudentsSpawned++;
				this.UpdateStudents();
			}
		}
		else if (this.StudentsSpawned < this.StudentsTotal)
		{
			this.Frame++;
			if (this.Frame == 1)
			{
				if (this.NewStudent != null)
				{
					UnityEngine.Object.Destroy(this.NewStudent);
				}
				this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.PortraitChan, this.SpawnPositions[this.StudentsSpawned].position, Quaternion.identity);
				this.NewPortraitChan = (PortraitChanScript)this.NewStudent.GetComponent(typeof(PortraitChanScript));
				this.NewPortraitChan.StudentID = this.StudentsSpawned + 1;
				this.NewPortraitChan.StudentManager = this;
				this.NewPortraitChan.JSON = this.JSON;
				this.StudentsSpawned++;
			}
			if (this.Frame == 2)
			{
				Application.CaptureScreenshot(Application.streamingAssetsPath + "/Portraits/" + "Student_" + this.StudentsSpawned + ".png");
				this.Frame = 0;
			}
		}
		else
		{
			Application.CaptureScreenshot(Application.streamingAssetsPath + "/Portraits/" + "Student_" + this.StudentsSpawned + ".png");
			this.active = false;
		}
	}

	public virtual void UpdateStudents()
	{
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null)
			{
				this.Students[this.ID].Prompt.HideButton[0] = false;
				this.Students[this.ID].Prompt.HideButton[2] = false;
				this.Students[this.ID].Prompt.Attack = false;
				if (this.Yandere.Armed)
				{
					this.Students[this.ID].Prompt.HideButton[0] = true;
					this.Students[this.ID].Prompt.Attack = true;
				}
				else
				{
					this.Students[this.ID].Prompt.HideButton[2] = true;
					if (this.Students[this.ID].WitnessedMurder)
					{
						this.Students[this.ID].Prompt.HideButton[0] = true;
					}
				}
				if (this.Yandere.Dragging || this.Yandere.PickUp != null)
				{
					this.Students[this.ID].Prompt.HideButton[0] = true;
					this.Students[this.ID].Prompt.HideButton[2] = true;
				}
				if (this.Yandere.NearBodies > 0)
				{
					this.Students[this.ID].Prompt.HideButton[0] = true;
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

	public virtual void WipePendingRep()
	{
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null)
			{
				this.Students[this.ID].PendingRep = (float)0;
			}
			this.ID++;
		}
	}

	public virtual void AttackOnTitan()
	{
		this.AoT = true;
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null)
			{
				this.Students[this.ID].AttackOnTitan();
			}
			this.ID++;
		}
	}

	public virtual void Main()
	{
	}
}
