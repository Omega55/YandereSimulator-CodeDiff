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

	public GateScript Gate;

	public ListScript Lockers;

	public ListScript LockerFs;

	public ListScript Classrooms;

	public ListScript ClassroomFs;

	public ListScript Hangouts;

	public ListScript HangoutFs;

	public Transform[] SpawnPositions;

	public Transform Exit;

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

	public float ChangeTimer;

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
		if (Input.GetKey("space") && this.ChangeTimer < (float)5)
		{
			this.ChangeTimer += Time.deltaTime;
			if (this.ChangeTimer >= (float)5)
			{
				this.ID = 0;
				while (this.ID < Extensions.get_length(this.Hangouts.List))
				{
					float z = this.Hangouts.List[this.ID].position.z - (float)40;
					Vector3 position = this.Hangouts.List[this.ID].position;
					float num = position.z = z;
					Vector3 vector = this.Hangouts.List[this.ID].position = position;
					this.ID++;
				}
			}
		}
	}

	public virtual void UpdateStudents()
	{
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null && !this.Students[this.ID].Safe)
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

	public virtual void AttendClass()
	{
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null)
			{
				this.Students[this.ID].transform.position = this.Classrooms.List[this.Students[this.ID].Class].position;
				this.Students[this.ID].Character.animation.Play("f02_idleShort_00");
				this.Students[this.ID].Pathfinding.canSearch = false;
				this.Students[this.ID].Pathfinding.canMove = false;
				this.Students[this.ID].Pathfinding.speed = (float)0;
				this.Students[this.ID].Routine = false;
			}
			this.ID++;
		}
	}

	public virtual void ResumeMovement()
	{
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null)
			{
				this.Students[this.ID].Pathfinding.canSearch = true;
				this.Students[this.ID].Pathfinding.canMove = true;
				this.Students[this.ID].Pathfinding.speed = (float)1;
				this.Students[this.ID].Routine = true;
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
