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

	public TranqDetectorScript TranqDetector;

	public WitnessCameraScript WitnessCamera;

	public TallLockerScript CommunalLocker;

	public TaskManagerScript TaskManager;

	public ContainerScript Container;

	public OfferHelpScript OfferHelp;

	public RingEventScript RingEvent;

	public FountainScript Fountain;

	public TrashCanScript TrashCan;

	public StudentScript Reporter;

	public GhostScript GhostChan;

	public YandereScript Yandere;

	public ListScript MeetSpots;

	public PoliceScript Police;

	public ListScript Patrols;

	public ClockScript Clock;

	public JsonScript JSON;

	public GateScript Gate;

	public ListScript EntranceVectors;

	public ListScript GoAwaySpots;

	public ListScript LunchSpots;

	public ListScript Hangouts;

	public ListScript Lockers;

	public ListScript Podiums;

	public ListScript Clubs;

	public ListScript Seats;

	public ChangingBoothScript[] ChangingBooths;

	public GradingPaperScript[] FacultyDesks;

	public Transform[] LockerPositions;

	public Transform[] SpawnPositions;

	public StudentScript[] Teachers;

	public Transform CorpseLocation;

	public Transform FastBatheSpot;

	public Transform FountainSpot;

	public Transform BrokenSpot;

	public Transform GoAwaySpot;

	public Transform BatheSpot;

	public Transform ShameSpot;

	public Transform SlaveSpot;

	public Transform StripSpot;

	public Transform Exit;

	public GameObject PortraitChan;

	public GameObject PortraitKun;

	public GameObject StudentChan;

	public GameObject StudentKun;

	public GameObject Portal;

	public GameObject EmptyObject;

	public float[] SpawnTimes;

	public int StudentsSpawned;

	public int StudentsTotal;

	public int TeachersTotal;

	public int NPCsSpawned;

	public int NPCsTotal;

	public int SpawnID;

	public int Frame;

	public int ID;

	public bool MurderTakingPlace;

	public bool TakingPortraits;

	public bool ForceSpawn;

	public bool Randomize;

	public bool Spooky;

	public bool Sans;

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
		this.SetAtmosphere();
		if (PlayerPrefs.GetInt("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Slave") == 1)
		{
			this.ForceSpawn = true;
			this.SpawnPositions[PlayerPrefs.GetInt("KidnapVictim")] = this.SlaveSpot;
			this.SpawnID = PlayerPrefs.GetInt("KidnapVictim");
			this.SpawnStudent();
			this.Students[PlayerPrefs.GetInt("KidnapVictim")].Slave = true;
			this.SpawnID = 0;
			PlayerPrefs.SetInt("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Slave", 0);
			PlayerPrefs.SetInt("KidnapVictim", 0);
		}
		this.NPCsTotal = this.StudentsTotal + this.TeachersTotal;
		this.SpawnID = this.StudentsTotal + 1;
		if (PlayerPrefs.GetInt("MaleUniform") == 0)
		{
			PlayerPrefs.SetInt("MaleUniform", 1);
		}
		this.ID = 1;
		while (this.ID < this.NPCsTotal)
		{
			if (PlayerPrefs.GetInt("Student_" + this.ID + "_Dead") == 0)
			{
				PlayerPrefs.SetInt("Student_" + this.ID + "_Dying", 0);
			}
			this.ID++;
		}
		this.ID = 1;
		while (this.ID < Extensions.get_length(this.Lockers.List))
		{
			Transform transform = ((GameObject)UnityEngine.Object.Instantiate(this.EmptyObject, this.Lockers.List[this.ID].position + this.Lockers.List[this.ID].forward * 0.5f, this.Lockers.List[this.ID].rotation)).transform;
			transform.parent = this.Lockers.transform;
			float y = transform.transform.eulerAngles.y + (float)180;
			Vector3 eulerAngles = transform.transform.eulerAngles;
			float num = eulerAngles.y = y;
			Vector3 vector = transform.transform.eulerAngles = eulerAngles;
			this.LockerPositions[this.ID] = transform;
			this.ID++;
		}
		if (PlayerPrefs.GetInt("Late") == 1)
		{
			PlayerPrefs.SetInt("Late", 0);
			this.Clock.PresentTime = (float)480;
			this.Clock.HourTime = (float)8;
			this.AttendClass();
		}
	}

	public virtual void SetAtmosphere()
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
				if (this.Randomize)
				{
					if (UnityEngine.Random.Range(0, 2) == 0)
					{
						this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.PortraitChan, new Vector3((float)0, (float)0, (float)0), Quaternion.identity);
					}
					else
					{
						this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.PortraitKun, new Vector3((float)0, (float)0, (float)0), Quaternion.identity);
					}
				}
				else if (this.JSON.StudentGenders[this.NPCsSpawned + 1] == 0)
				{
					this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.PortraitChan, new Vector3((float)0, (float)0, (float)0), Quaternion.identity);
				}
				else
				{
					this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.PortraitKun, new Vector3((float)0, (float)0, (float)0), Quaternion.identity);
				}
				((CosmeticScript)this.NewStudent.GetComponent(typeof(CosmeticScript))).StudentID = this.NPCsSpawned + 1;
				((CosmeticScript)this.NewStudent.GetComponent(typeof(CosmeticScript))).Randomize = this.Randomize;
				((CosmeticScript)this.NewStudent.GetComponent(typeof(CosmeticScript))).JSON = this.JSON;
				this.NewPortraitChan = (PortraitChanScript)this.NewStudent.GetComponent(typeof(PortraitChanScript));
				this.NewPortraitChan.StudentID = this.NPCsSpawned + 1;
				this.NewPortraitChan.StudentManager = this;
				this.NewPortraitChan.JSON = this.JSON;
				if (!this.Randomize)
				{
					this.NPCsSpawned++;
				}
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

	public virtual void SpawnStudent()
	{
		if (this.ForceSpawn || (!this.Stop && this.Clock.HourTime >= this.SpawnTimes[this.SpawnID]))
		{
			if (this.Students[this.SpawnID] == null && PlayerPrefs.GetInt("Student_" + this.SpawnID + "_Dead") == 0 && PlayerPrefs.GetInt("Student_" + this.SpawnID + "_Kidnapped") == 0 && PlayerPrefs.GetInt("Student_" + this.SpawnID + "_Arrested") == 0 && PlayerPrefs.GetInt("Student_" + this.SpawnID + "_Expelled") == 0 && this.JSON.StudentNames[this.SpawnID] != "Unknown" && PlayerPrefs.GetInt("Student_" + this.SpawnID + "_Reputation") > -100)
			{
				if (this.JSON.StudentGenders[this.SpawnID] == 0)
				{
					this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.StudentChan, this.SpawnPositions[this.SpawnID].position, Quaternion.identity);
				}
				else
				{
					this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.StudentKun, this.SpawnPositions[this.SpawnID].position, Quaternion.identity);
				}
				((CosmeticScript)this.NewStudent.GetComponent(typeof(CosmeticScript))).Randomize = this.Randomize;
				((CosmeticScript)this.NewStudent.GetComponent(typeof(CosmeticScript))).StudentID = this.SpawnID;
				((CosmeticScript)this.NewStudent.GetComponent(typeof(CosmeticScript))).JSON = this.JSON;
				this.Students[this.SpawnID] = (StudentScript)this.NewStudent.GetComponent(typeof(StudentScript));
				this.Students[this.SpawnID].StudentID = this.SpawnID;
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
				if (this.Sans)
				{
					this.Students[this.SpawnID].BadTime = true;
				}
				if (this.SpawnID == 7)
				{
					this.CommunalLocker.Student = this.Students[this.SpawnID];
				}
			}
			this.NPCsSpawned++;
			this.SpawnID++;
			if (this.SpawnID > this.NPCsTotal)
			{
				this.SpawnID = 1;
			}
			this.UpdateStudents();
			if (!this.TakingPortraits)
			{
				this.TaskManager.UpdateTaskStatus();
			}
			this.ForceSpawn = false;
		}
	}

	public virtual void UpdateStudents()
	{
		this.ID = 2;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null && !this.Students[this.ID].Safe)
			{
				if (!this.Students[this.ID].Slave)
				{
					if (!this.Students[this.ID].Following)
					{
						this.Students[this.ID].Prompt.Label[0].text = "     " + "Talk";
					}
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
					if (this.Yandere.Mask != null)
					{
						this.Students[this.ID].Prompt.HideButton[0] = true;
					}
					if (this.Yandere.Dragging || this.Yandere.PickUp != null || this.Yandere.Chased)
					{
						this.Students[this.ID].Prompt.HideButton[0] = true;
						this.Students[this.ID].Prompt.HideButton[2] = true;
						if (this.Yandere.PickUp != null && this.Yandere.PickUp.Food > 0)
						{
							this.Students[this.ID].Prompt.Label[0].text = "     " + "Feed";
							this.Students[this.ID].Prompt.HideButton[0] = false;
							this.Students[this.ID].Prompt.HideButton[2] = true;
						}
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
				else if (this.Yandere.Armed)
				{
					if (this.Yandere.Weapon[this.Yandere.Equipped].Concealable)
					{
						this.Students[this.ID].Prompt.HideButton[0] = false;
						this.Students[this.ID].Prompt.Label[0].text = "     " + "Give Weapon";
					}
					else
					{
						this.Students[this.ID].Prompt.HideButton[0] = true;
						this.Students[this.ID].Prompt.Label[0].text = string.Empty;
					}
				}
				else
				{
					this.Students[this.ID].Prompt.HideButton[0] = true;
					this.Students[this.ID].Prompt.Label[0].text = string.Empty;
				}
			}
			if (this.Sans && this.Students[this.ID] != null && this.Students[this.ID].Prompt.Label[0] != null)
			{
				this.Students[this.ID].Prompt.HideButton[0] = false;
				this.Students[this.ID].Prompt.Label[0].text = "     " + "Psychokinesis";
			}
			this.ID++;
		}
		this.Container.UpdatePrompts();
		this.TrashCan.UpdatePrompt();
	}

	public virtual void UpdateMe(int ID)
	{
		if (ID > 1)
		{
			if (!this.Students[ID].Safe)
			{
				this.Students[ID].Prompt.Label[0].text = "     " + "Talk";
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
			if (this.Sans)
			{
				this.Students[ID].Prompt.HideButton[0] = false;
				this.Students[ID].Prompt.Label[0].text = "     " + "Psychokinesis";
			}
		}
	}

	public virtual void AttendClass()
	{
		if (this.RingEvent.EventActive)
		{
			this.RingEvent.ReturnRing();
		}
		while (this.NPCsSpawned < this.NPCsTotal)
		{
			this.SpawnStudent();
		}
		this.ID = 1;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null && !this.Students[this.ID].Dead && !this.Students[this.ID].Slave && !this.Students[this.ID].Tranquil && this.ID < Extensions.get_length(this.Seats.List))
			{
				if (!this.Students[this.ID].Started)
				{
					this.Students[this.ID].Start();
				}
				if (!this.Students[this.ID].Teacher)
				{
					if (!this.Students[this.ID].Indoors)
					{
						if (this.Students[this.ID].ShoeRemoval.Locker == null)
						{
							this.Students[this.ID].ShoeRemoval.Start();
						}
						this.Students[this.ID].ShoeRemoval.PutOnShoes();
					}
					this.Students[this.ID].transform.position = this.Seats.List[this.Students[this.ID].StudentID].position + Vector3.up * 0.01f;
					this.Students[this.ID].transform.rotation = this.Seats.List[this.Students[this.ID].StudentID].rotation;
					this.Students[this.ID].Character.animation.Play(this.Students[this.ID].SitAnim);
					this.Students[this.ID].Pathfinding.canSearch = false;
					this.Students[this.ID].Pathfinding.canMove = false;
					this.Students[this.ID].OccultBook.active = false;
					this.Students[this.ID].Pathfinding.speed = (float)0;
					this.Students[this.ID].Phone.active = false;
					this.Students[this.ID].Distracted = false;
					this.Students[this.ID].OnPhone = false;
					this.Students[this.ID].Routine = false;
					this.Students[this.ID].Safe = false;
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
					if (this.Students[this.ID].ClubAttire)
					{
						this.Students[this.ID].ChangeSchoolwear();
						this.Students[this.ID].ClubAttire = false;
					}
				}
				else if (this.ID != 41)
				{
					this.Students[this.ID].transform.position = this.Podiums.List[this.Students[this.ID].Class].position + Vector3.up * 0.01f;
					this.Students[this.ID].transform.rotation = this.Podiums.List[this.Students[this.ID].Class].rotation;
				}
				else
				{
					this.Students[this.ID].transform.position = this.Seats.List[this.Students[this.ID].StudentID].position + Vector3.up * 0.01f;
					this.Students[this.ID].transform.rotation = this.Seats.List[this.Students[this.ID].StudentID].rotation;
				}
			}
			this.ID++;
		}
	}

	public virtual void ResumeMovement()
	{
		this.ID = 1;
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
			if (this.Students[this.ID] != null)
			{
				if (!this.Students[this.ID].Dying)
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
				if (this.Students[this.ID].SawMask)
				{
					this.Police.MaskReported = true;
				}
			}
			this.ID++;
		}
	}

	public virtual void StopFleeing()
	{
		this.ID = 1;
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
		this.ID = 2;
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
		this.ID = 2;
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
		this.ID = 2;
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
		this.ID = 2;
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
		this.ID = 1;
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
		this.ID = 2;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null && !this.Students[this.ID].Male)
			{
				this.Students[this.ID].Spook();
			}
			this.ID++;
		}
	}

	public virtual void BadTime()
	{
		this.Sans = true;
		this.ID = 2;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null)
			{
				this.Students[this.ID].BadTime = true;
			}
			this.ID++;
		}
	}

	public virtual void UpdateBooths()
	{
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.ChangingBooths))
		{
			if (this.ChangingBooths[this.ID] != null)
			{
				this.ChangingBooths[this.ID].CheckYandereClub();
			}
			this.ID++;
		}
	}

	public virtual void UpdatePerception()
	{
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null)
			{
				this.Students[this.ID].UpdatePerception();
			}
			this.ID++;
		}
	}

	public virtual void Main()
	{
	}
}
