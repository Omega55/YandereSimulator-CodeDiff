using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class StudentManagerScript : MonoBehaviour
{
	private PortraitChanScript NewPortraitChan;

	private GameObject NewStudent;

	public StudentScript[] Students;

	public SelectiveGrayscale SmartphoneSelectiveGreyscale;

	public SelectiveGrayscale HandSelectiveGreyscale;

	public SelectiveGrayscale SelectiveGreyscale;

	public EmergencyExitScript EmergencyExit;

	public WitnessCameraScript WitnessCamera;

	public TallLockerScript CommunalLocker;

	public StudentScript Reporter;

	public GhostScript GhostChan;

	public YandereScript Yandere;

	public ClockScript Clock;

	public JsonScript JSON;

	public GateScript Gate;

	public ListScript LunchSpots;

	public ListScript Hangouts;

	public ListScript Lockers;

	public ListScript Podiums;

	public ListScript Seats;

	public Transform[] SpawnPositions;

	public StudentScript[] Teachers;

	public Transform CorpseLocation;

	public Transform FastBatheSpot;

	public Transform BatheSpot;

	public Transform StripSpot;

	public Transform Exit;

	public GameObject PortraitChan;

	public GameObject PortraitKun;

	public GameObject StudentChan;

	public GameObject StudentKun;

	public GameObject Portal;

	public float[] SpawnTimes;

	public int StudentsSpawned;

	public int StudentsTotal;

	public int TeachersTotal;

	public int NPCsSpawned;

	public int NPCsTotal;

	public int SpawnID;

	public int Frame;

	public int ID;

	public Texture[] Stockings;

	public Texture[] MaleColors;

	public Texture[] Colors;

	public bool TakingPortraits;

	public bool Spooky;

	public bool Stop;

	public bool AoT;

	public bool DK;

	public float ChangeTimer;

	public StudentManagerScript()
	{
		this.StudentsTotal = 13;
		this.TeachersTotal = 6;
	}

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("SchoolAtmosphereSet") == 0)
		{
			PlayerPrefs.SetInt("SchoolAtmosphereSet", 1);
			PlayerPrefs.SetFloat("SchoolAtmosphere", (float)100);
		}
		Vignetting[] components = Camera.main.GetComponents<Vignetting>();
		float num = (float)1 - PlayerPrefs.GetFloat("SchoolAtmosphere") * 0.01f;
		if (!this.TakingPortraits)
		{
			this.SelectiveGreyscale.desaturation = num;
			components[2].intensity = num * (float)5;
			components[2].blur = num;
			components[2].chromaticAberration = num * (float)5;
			RenderSettings.fogDensity = num * 0.05f;
		}
		this.NPCsTotal = this.StudentsTotal + this.TeachersTotal;
		this.SpawnID = this.StudentsTotal;
		if (PlayerPrefs.GetInt("MaleUniform") == 0)
		{
			PlayerPrefs.SetInt("MaleUniform", 1);
		}
	}

	public virtual void Update()
	{
		if (!this.TakingPortraits)
		{
			if (this.NPCsSpawned < this.NPCsTotal)
			{
				this.SpawnStudent();
			}
		}
		else if (this.NPCsSpawned < this.NPCsTotal)
		{
			this.Frame++;
			if (this.Frame == 1)
			{
				if (this.NewStudent != null)
				{
					UnityEngine.Object.Destroy(this.NewStudent);
				}
				if (this.JSON.StudentGenders[this.NPCsSpawned + 1] == 0)
				{
					this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.PortraitChan, this.SpawnPositions[this.NPCsSpawned].position, Quaternion.identity);
				}
				else
				{
					this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.PortraitKun, this.SpawnPositions[this.NPCsSpawned].position, Quaternion.identity);
				}
				this.NewPortraitChan = (PortraitChanScript)this.NewStudent.GetComponent(typeof(PortraitChanScript));
				this.NewPortraitChan.StudentID = this.NPCsSpawned + 1;
				this.NewPortraitChan.StudentManager = this;
				this.NewPortraitChan.JSON = this.JSON;
				this.NPCsSpawned++;
			}
			if (this.Frame == 2)
			{
				Application.CaptureScreenshot(Application.streamingAssetsPath + "/Portraits/" + "Student_" + this.NPCsSpawned + ".png");
				this.Frame = 0;
			}
		}
		else
		{
			Application.CaptureScreenshot(Application.streamingAssetsPath + "/Portraits/" + "Student_" + this.NPCsSpawned + ".png");
			this.active = false;
		}
	}

	public virtual void UpdateStudents()
	{
		this.ID = 1;
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
					if (this.Students[this.ID].WitnessedMurder || this.Students[this.ID].WitnessedCorpse || this.Students[this.ID].Private)
					{
						this.Students[this.ID].Prompt.HideButton[0] = true;
					}
				}
				if (this.Yandere.Dragging || this.Yandere.PickUp != null || this.Yandere.Chased)
				{
					this.Students[this.ID].Prompt.HideButton[0] = true;
					this.Students[this.ID].Prompt.HideButton[2] = true;
				}
				if (this.Yandere.NearBodies > 0 || this.Yandere.Sanity < 33.33333f)
				{
					this.Students[this.ID].Prompt.HideButton[0] = true;
				}
				if (this.Students[this.ID].Teacher)
				{
					this.Students[this.ID].Prompt.HideButton[0] = true;
				}
			}
			this.ID++;
		}
	}

	public virtual void UpdateMe(int ID)
	{
		if (!this.Students[ID].Safe)
		{
			this.Students[ID].Prompt.HideButton[0] = false;
			this.Students[ID].Prompt.HideButton[2] = false;
			this.Students[ID].Prompt.Attack = false;
			if (this.Yandere.Armed)
			{
				this.Students[ID].Prompt.HideButton[0] = true;
				this.Students[ID].Prompt.Attack = true;
			}
			else
			{
				this.Students[ID].Prompt.HideButton[2] = true;
				if (this.Students[ID].WitnessedMurder || this.Students[ID].WitnessedCorpse || this.Students[ID].Private)
				{
					this.Students[ID].Prompt.HideButton[0] = true;
				}
			}
			if (this.Yandere.Dragging || this.Yandere.PickUp != null || this.Yandere.Chased)
			{
				this.Students[ID].Prompt.HideButton[0] = true;
				this.Students[ID].Prompt.HideButton[2] = true;
			}
			if (this.Yandere.NearBodies > 0 || this.Yandere.Sanity < 33.33333f)
			{
				this.Students[ID].Prompt.HideButton[0] = true;
			}
			if (this.Students[ID].Teacher)
			{
				this.Students[ID].Prompt.HideButton[0] = true;
			}
		}
	}

	public virtual void AttendClass()
	{
		while (this.NPCsSpawned < this.NPCsTotal)
		{
			this.SpawnStudent();
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null && !this.Students[this.ID].Dead && !this.Students[this.ID].Teacher)
			{
				this.Students[this.ID].transform.position = this.Seats.List[this.Students[this.ID].StudentID].position + Vector3.up * 0.01f;
				this.Students[this.ID].Character.animation.Play(this.Students[this.ID].IdleAnim);
				this.Students[this.ID].Pathfinding.canSearch = false;
				this.Students[this.ID].Pathfinding.canMove = false;
				this.Students[this.ID].Pathfinding.speed = (float)0;
				this.Students[this.ID].Routine = false;
				if (this.Students[this.ID].Wet)
				{
					this.Students[this.ID].Schoolwear = 3;
					this.Students[this.ID].ChangeSchoolwear();
					this.Students[this.ID].LiquidProjector.enabled = false;
					this.Students[this.ID].Splashed = false;
					this.Students[this.ID].Bloody = false;
					this.Students[this.ID].BathePhase = 1;
					this.Students[this.ID].Wet = false;
					this.Students[this.ID].UnWet();
				}
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

	public virtual void StopMoving()
	{
		this.Stop = true;
		this.ID = 1;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null && !this.Students[this.ID].Dying)
			{
				if (this.Yandere.Attacking)
				{
					this.Students[this.ID].Character.animation.CrossFade(this.Students[this.ID].ScaredAnim);
				}
				else
				{
					this.Students[this.ID].Character.animation.CrossFade(this.Students[this.ID].IdleAnim);
				}
				this.Students[this.ID].Pathfinding.canSearch = false;
				this.Students[this.ID].Pathfinding.canMove = false;
				this.Students[this.ID].Pathfinding.speed = (float)0;
				this.Students[this.ID].Stop = true;
				if (this.Students[this.ID].EventManager != null)
				{
					this.Students[this.ID].EventManager.EndEvent();
				}
			}
			this.ID++;
		}
	}

	public virtual void StopFleeing()
	{
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null && !this.Students[this.ID].Teacher)
			{
				this.Students[this.ID].Pathfinding.target = this.Students[this.ID].Destinations[this.Students[this.ID].Phase];
				this.Students[this.ID].Pathfinding.speed = (float)1;
				this.Students[this.ID].WitnessedCorpse = false;
				this.Students[this.ID].WitnessedMurder = false;
				this.Students[this.ID].Alarmed = false;
				this.Students[this.ID].Fleeing = false;
				this.Students[this.ID].Reacted = false;
				this.Students[this.ID].Witness = false;
				this.Students[this.ID].Routine = true;
			}
			this.ID++;
		}
	}

	public virtual void EnablePrompts()
	{
		this.ID = 1;
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
		this.ID = 1;
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
		this.ID = 1;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null)
			{
				this.Students[this.ID].PendingRep = (float)0;
			}
			this.ID++;
		}
	}

	public virtual void SpawnStudent()
	{
		if (this.Clock.HourTime >= this.SpawnTimes[this.NPCsSpawned])
		{
			if (PlayerPrefs.GetInt("Student_" + (this.SpawnID + 1) + "_Dead") == 0 && this.JSON.StudentNames[this.SpawnID + 1] != "Unknown")
			{
				if (this.JSON.StudentGenders[this.SpawnID + 1] == 0)
				{
					this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.StudentChan, this.SpawnPositions[this.NPCsSpawned].position, Quaternion.identity);
				}
				else
				{
					this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.StudentKun, this.SpawnPositions[this.NPCsSpawned].position, Quaternion.identity);
				}
				this.Students[this.SpawnID] = (StudentScript)this.NewStudent.GetComponent(typeof(StudentScript));
				this.Students[this.SpawnID].StudentID = this.SpawnID + 1;
				this.Students[this.SpawnID].WitnessCamera = this.WitnessCamera;
				this.Students[this.SpawnID].StudentManager = this;
				this.Students[this.SpawnID].JSON = this.JSON;
				if (this.AoT)
				{
					this.Students[this.SpawnID].AoT = true;
				}
				if (this.DK)
				{
					this.Students[this.SpawnID].DK = true;
				}
				if (this.Spooky)
				{
					this.Students[this.SpawnID].Spooky = true;
				}
				if (this.SpawnID == 15)
				{
					this.CommunalLocker.Student = this.Students[this.SpawnID];
				}
			}
			this.NPCsSpawned++;
			this.SpawnID++;
			if (this.SpawnID == this.NPCsTotal)
			{
				this.SpawnID = 0;
			}
			this.UpdateStudents();
		}
	}

	public virtual void AttackOnTitan()
	{
		this.AoT = true;
		this.ID = 1;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null && !this.Students[this.ID].Teacher)
			{
				this.Students[this.ID].AttackOnTitan();
			}
			this.ID++;
		}
	}

	public virtual void Kong()
	{
		this.DK = true;
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null)
			{
				this.Students[this.ID].DK = true;
			}
			this.ID++;
		}
	}

	public virtual void Spook()
	{
		this.Spooky = true;
		this.ID = 1;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null && !this.Students[this.ID].Male)
			{
				this.Students[this.ID].Spook();
			}
			this.ID++;
		}
	}

	public virtual void Main()
	{
	}
}
