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

	public DatingMinigameScript DatingMinigame;

	public TextureManagerScript TextureManager;

	public QualityManagerScript QualityManager;

	public ParticleSystem FemaleDrownSplashes;

	public EmergencyExitScript EmergencyExit;

	public TranqDetectorScript TranqDetector;

	public WitnessCameraScript WitnessCamera;

	public TallLockerScript CommunalLocker;

	public LoveManagerScript LoveManager;

	public TaskManagerScript TaskManager;

	public DoorScript FemaleVomitDoor;

	public ContainerScript Container;

	public OfferHelpScript OfferHelp;

	public RingEventScript RingEvent;

	public FountainScript Fountain;

	public PoseModeScript PoseMode;

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

	public ListScript HidingSpots;

	public ListScript LunchSpots;

	public ListScript Hangouts;

	public ListScript Lockers;

	public ListScript Podiums;

	public ListScript Clubs;

	public ChangingBoothScript[] ChangingBooths;

	public GradingPaperScript[] FacultyDesks;

	public Transform[] LockerPositions;

	public StudentScript[] WitnessList;

	public Transform[] SpawnPositions;

	public Transform[] PinDownSpots;

	public StudentScript[] Teachers;

	public ListScript[] Seats;

	public bool[] SeatsTaken11;

	public bool[] SeatsTaken12;

	public bool[] SeatsTaken21;

	public bool[] SeatsTaken22;

	public bool[] SeatsTaken31;

	public bool[] SeatsTaken32;

	public Collider RivalDeskCollider;

	public Transform FollowerLookAtTarget;

	public Transform SuitorConfessionSpot;

	public Transform ConfessionWaypoint;

	public Transform FemaleCoupleSpot;

	public Transform FemaleStalkSpot;

	public Transform FemaleVomitSpot;

	public Transform ConfessionSpot;

	public Transform CorpseLocation;

	public Transform FemaleWashSpot;

	public Transform MaleCoupleSpot;

	public Transform FastBatheSpot;

	public Transform MaleStalkSpot;

	public Transform MaleVomitSpot;

	public Transform SacrificeSpot;

	public Transform FountainSpot;

	public Transform MaleWashSpot;

	public Transform SuitorLocker;

	public Transform RomanceSpot;

	public Transform BrokenSpot;

	public Transform EdgeOfGrid;

	public Transform GoAwaySpot;

	public Transform SuitorSpot;

	public Transform BatheSpot;

	public Transform MournSpot;

	public Transform ShameSpot;

	public Transform SlaveSpot;

	public Transform StripSpot;

	public Transform Exit;

	public GameObject PortraitChan;

	public GameObject RandomPatrol;

	public GameObject EmptyObject;

	public GameObject PortraitKun;

	public GameObject StudentChan;

	public GameObject StudentKun;

	public GameObject Portal;

	public float[] SpawnTimes;

	public int LowDetailThreshold;

	public int StudentsSpawned;

	public int StudentsTotal;

	public int TeachersTotal;

	public int NPCsSpawned;

	public int NPCsTotal;

	public int Witnesses;

	public int Frame;

	public int GymTeacherID;

	public int SuitorID;

	public int RivalID;

	public int SpawnID;

	public int ID;

	public bool MurderTakingPlace;

	public bool TakingPortraits;

	public bool TeachersSpawned;

	public bool DisableFarAnims;

	public bool FirstUpdate;

	public bool MissionMode;

	public bool PinningDown;

	public bool ForceSpawn;

	public bool Randomize;

	public bool NoSpeech;

	public bool Censor;

	public bool Spooky;

	public bool Pose;

	public bool Sans;

	public bool Stop;

	public bool AoT;

	public bool DK;

	public float ChangeTimer;

	public float Timer;

	public string[] ColorNames;

	public string[] MaleNames;

	public string[] FirstNames;

	public string[] LastNames;

	public AudioClip YanderePinDown;

	public AudioClip PinDownSFX;

	public bool SeatOccupied;

	public int Class;

	public StudentManagerScript()
	{
		this.StudentsTotal = 13;
		this.TeachersTotal = 6;
		this.GymTeacherID = 100;
		this.SuitorID = 13;
		this.RivalID = 7;
		this.Class = 1;
	}

	public virtual void Start()
	{
		this.SetAtmosphere();
		if (PlayerPrefs.GetInt("MissionMode") == 1)
		{
			PlayerPrefs.SetInt("FemaleUniform", 5);
			PlayerPrefs.SetInt("FemaleUniform", 5);
		}
		if (PlayerPrefs.GetInt("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Slave") == 1)
		{
			this.ForceSpawn = true;
			this.SpawnPositions[PlayerPrefs.GetInt("KidnapVictim")] = this.SlaveSpot;
			this.SpawnID = PlayerPrefs.GetInt("KidnapVictim");
			PlayerPrefs.SetInt("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Dead", 0);
			this.SpawnStudent();
			this.Students[PlayerPrefs.GetInt("KidnapVictim")].Slave = true;
			this.SpawnID = 0;
			PlayerPrefs.SetInt("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Slave", 0);
			PlayerPrefs.SetInt("KidnapVictim", 0);
		}
		this.NPCsTotal = this.StudentsTotal + this.TeachersTotal;
		this.SpawnID = 1;
		if (PlayerPrefs.GetInt("MaleUniform") == 0)
		{
			PlayerPrefs.SetInt("MaleUniform", 1);
		}
		this.ID = 1;
		while (this.ID < this.NPCsTotal + 1)
		{
			if (PlayerPrefs.GetInt("Student_" + this.ID + "_Dead") == 0)
			{
				PlayerPrefs.SetInt("Student_" + this.ID + "_Dying", 0);
			}
			this.ID++;
		}
		if (!this.TakingPortraits)
		{
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
		}
		if (PlayerPrefs.GetInt("Late") == 1)
		{
			PlayerPrefs.SetInt("Late", 0);
			this.Clock.PresentTime = (float)480;
			this.Clock.HourTime = (float)8;
			this.AttendClass();
		}
		if (!this.TakingPortraits)
		{
			while (this.SpawnID < this.NPCsTotal + 1)
			{
				this.SpawnStudent();
			}
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
			float num2 = (float)1 - num;
			RenderSettings.fogColor = new Color(num2, num2, num2, (float)1);
			Camera.main.backgroundColor = new Color(num2, num2, num2, (float)1);
			RenderSettings.fogDensity = num * 0.1f;
		}
	}

	public virtual void Update()
	{
		Screen.lockCursor = true;
		if (!this.TakingPortraits)
		{
			this.Frame++;
			if (!this.FirstUpdate)
			{
				this.QualityManager.UpdateOutlines();
				this.FirstUpdate = true;
				this.UpdateStudents();
			}
			if (this.Frame == 3)
			{
				this.LoveManager.CoupleCheck();
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
				((CosmeticScript)this.NewStudent.GetComponent(typeof(CosmeticScript))).StudentManager = this;
				((CosmeticScript)this.NewStudent.GetComponent(typeof(CosmeticScript))).TakingPortrait = true;
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
		if (this.Witnesses > 0)
		{
			this.ID = 1;
			while (this.ID < this.WitnessList.Length)
			{
				if (this.WitnessList[this.ID] != null && (this.WitnessList[this.ID].Attacked || (this.WitnessList[this.ID].Fleeing && !this.WitnessList[this.ID].PinningDown)))
				{
					this.WitnessList[this.ID] = null;
					if (this.ID != this.WitnessList.Length - 1)
					{
						this.Shuffle(this.ID);
					}
					this.Witnesses--;
				}
				this.ID++;
			}
		}
		if (this.PinningDown)
		{
			if (this.WitnessList[1].PinPhase == 0)
			{
				if (this.WitnessList[1].DistanceToDestination < (float)1 && this.WitnessList[2].DistanceToDestination < (float)1 && this.WitnessList[3].DistanceToDestination < (float)1 && this.WitnessList[4].DistanceToDestination < (float)1)
				{
					this.audio.PlayOneShot(this.PinDownSFX);
					this.audio.PlayOneShot(this.YanderePinDown);
					this.Yandere.CharacterAnimation.CrossFade("f02_pinDown_00");
					this.Yandere.CanMove = false;
					this.Yandere.ShoulderCamera.LookDown = true;
					this.Yandere.RPGCamera.enabled = false;
					this.ID = 1;
					while (this.ID < 5)
					{
						this.WitnessList[this.ID].SetLayerRecursively(this.WitnessList[this.ID].gameObject, 13);
						if (!this.WitnessList[this.ID].Male)
						{
							this.WitnessList[this.ID].CharacterAnimation.CrossFade("f02_pinDown_0" + this.ID);
						}
						else
						{
							this.WitnessList[this.ID].CharacterAnimation.CrossFade("pinDown_0" + this.ID);
						}
						this.WitnessList[this.ID].PinPhase = this.WitnessList[this.ID].PinPhase + 1;
						this.ID++;
					}
				}
			}
			else
			{
				bool flag = false;
				if (!this.WitnessList[1].Male)
				{
					if (this.WitnessList[1].CharacterAnimation["f02_pinDown_01"].time >= this.WitnessList[1].CharacterAnimation["f02_pinDown_01"].length)
					{
						flag = true;
					}
				}
				else if (this.WitnessList[1].CharacterAnimation["pinDown_01"].time >= this.WitnessList[1].CharacterAnimation["pinDown_01"].length)
				{
					flag = true;
				}
				if (flag)
				{
					this.Yandere.CharacterAnimation.CrossFade("f02_pinDownLoop_00");
					this.ID = 1;
					while (this.ID < 5)
					{
						if (!this.WitnessList[this.ID].Male)
						{
							this.WitnessList[this.ID].CharacterAnimation.CrossFade("f02_pinDownLoop_0" + this.ID);
						}
						else
						{
							this.WitnessList[this.ID].CharacterAnimation.CrossFade("pinDownLoop_0" + this.ID);
						}
						this.ID++;
					}
					this.PinningDown = false;
				}
			}
		}
	}

	public virtual void SpawnStudent()
	{
		if (this.Students[this.SpawnID] == null && PlayerPrefs.GetInt("Student_" + this.SpawnID + "_Dead") == 0 && PlayerPrefs.GetInt("Student_" + this.SpawnID + "_Kidnapped") == 0 && PlayerPrefs.GetInt("Student_" + this.SpawnID + "_Arrested") == 0 && PlayerPrefs.GetInt("Student_" + this.SpawnID + "_Expelled") == 0 && this.JSON.StudentNames[this.SpawnID] != "Unknown" && this.JSON.StudentNames[this.SpawnID] != "Reserved" && PlayerPrefs.GetInt("Student_" + this.SpawnID + "_Reputation") > -100)
		{
			int num;
			if (this.JSON.StudentNames[this.SpawnID] == "Random")
			{
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.EmptyObject, new Vector3(UnityEngine.Random.Range(-17f, 17f), (float)0, UnityEngine.Random.Range(-17f, 17f)), Quaternion.identity);
				gameObject.transform.parent = this.HidingSpots.transform;
				this.HidingSpots.List[this.SpawnID] = gameObject.transform;
				GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(this.RandomPatrol, new Vector3((float)0, (float)0, (float)0), Quaternion.identity);
				gameObject2.transform.parent = this.Patrols.transform;
				this.Patrols.List[this.SpawnID] = gameObject2.transform;
				if (PlayerPrefs.GetInt("MissionMode") == 1 && PlayerPrefs.GetInt("MissionTarget") == this.SpawnID)
				{
					num = 0;
				}
				else
				{
					num = UnityEngine.Random.Range(0, 2);
				}
				this.FindUnoccupiedSeat();
			}
			else
			{
				num = this.JSON.StudentGenders[this.SpawnID];
			}
			if (num == 0)
			{
				this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.StudentChan, this.SpawnPositions[this.SpawnID].position, Quaternion.identity);
			}
			else
			{
				this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.StudentKun, this.SpawnPositions[this.SpawnID].position, Quaternion.identity);
			}
			((CosmeticScript)this.NewStudent.GetComponent(typeof(CosmeticScript))).LoveManager = this.LoveManager;
			((CosmeticScript)this.NewStudent.GetComponent(typeof(CosmeticScript))).StudentManager = this;
			((CosmeticScript)this.NewStudent.GetComponent(typeof(CosmeticScript))).Randomize = this.Randomize;
			((CosmeticScript)this.NewStudent.GetComponent(typeof(CosmeticScript))).StudentID = this.SpawnID;
			((CosmeticScript)this.NewStudent.GetComponent(typeof(CosmeticScript))).JSON = this.JSON;
			this.Students[this.SpawnID] = (StudentScript)this.NewStudent.GetComponent(typeof(StudentScript));
			this.Students[this.SpawnID].Cosmetic.TextureManager = this.TextureManager;
			this.Students[this.SpawnID].WitnessCamera = this.WitnessCamera;
			this.Students[this.SpawnID].StudentManager = this;
			this.Students[this.SpawnID].StudentID = this.SpawnID;
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
			this.OccupySeat();
		}
		this.NPCsSpawned++;
		this.SpawnID++;
		this.TaskManager.UpdateTaskStatus();
		this.ForceSpawn = false;
	}

	public virtual void UpdateStudents()
	{
		this.ID = 2;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null && this.Students[this.ID].active)
			{
				if (!this.Students[this.ID].Safe)
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
				if (this.NoSpeech && !this.Students[this.ID].Armband.active)
				{
					this.Students[this.ID].Prompt.HideButton[0] = true;
				}
			}
			if (this.Sans && this.Students[this.ID] != null && this.Students[this.ID].Prompt.Label[0] != null)
			{
				this.Students[this.ID].Prompt.HideButton[0] = false;
				this.Students[this.ID].Prompt.Label[0].text = "     " + "Psychokinesis";
			}
			if (this.Pose && this.Students[this.ID] != null && this.Students[this.ID].Prompt.Label[0] != null)
			{
				this.Students[this.ID].Prompt.HideButton[0] = false;
				this.Students[this.ID].Prompt.Label[0].text = "     " + "Pose";
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
			if (this.Pose)
			{
				this.Students[ID].Prompt.HideButton[0] = false;
				this.Students[ID].Prompt.Label[0].text = "     " + "Pose";
			}
			if (this.NoSpeech)
			{
				this.Students[ID].Prompt.HideButton[0] = true;
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
			if (this.Students[this.ID] != null && !this.Students[this.ID].Dead && !this.Students[this.ID].Slave && !this.Students[this.ID].Tranquil)
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
					this.Students[this.ID].transform.position = this.Students[this.ID].Seat.position + Vector3.up * 0.01f;
					this.Students[this.ID].transform.rotation = this.Students[this.ID].Seat.rotation;
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
				else if (this.ID != this.GymTeacherID)
				{
					this.Students[this.ID].transform.position = this.Podiums.List[this.Students[this.ID].Class].position + Vector3.up * 0.01f;
					this.Students[this.ID].transform.rotation = this.Podiums.List[this.Students[this.ID].Class].rotation;
				}
				else
				{
					this.Students[this.ID].transform.position = this.Students[this.ID].Seat.position + Vector3.up * 0.01f;
					this.Students[this.ID].transform.rotation = this.Students[this.ID].Seat.rotation;
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
					else if (this.ID > 1)
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
				if (!this.Students[this.ID].Dead && this.Students[this.ID].SawMask)
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

	public virtual void StopHesitating()
	{
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null)
			{
				if (this.Students[this.ID].AlarmTimer > (float)0)
				{
					this.Students[this.ID].AlarmTimer = (float)1;
				}
				this.Students[this.ID].Hesitation = (float)0;
			}
			this.ID++;
		}
	}

	public virtual void Unstop()
	{
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null)
			{
				this.Students[this.ID].Stop = false;
			}
			this.ID++;
		}
	}

	public virtual void LowerCorpsePostion()
	{
		if (this.CorpseLocation.position.y < (float)4)
		{
			int num = 0;
			Vector3 position = this.CorpseLocation.position;
			float num2 = position.y = (float)num;
			Vector3 vector = this.CorpseLocation.position = position;
		}
		else if (this.CorpseLocation.position.y < (float)8)
		{
			int num3 = 4;
			Vector3 position2 = this.CorpseLocation.position;
			float num4 = position2.y = (float)num3;
			Vector3 vector2 = this.CorpseLocation.position = position2;
		}
		else if (this.CorpseLocation.position.y < (float)12)
		{
			int num5 = 8;
			Vector3 position3 = this.CorpseLocation.position;
			float num6 = position3.y = (float)num5;
			Vector3 vector3 = this.CorpseLocation.position = position3;
		}
		else
		{
			int num7 = 12;
			Vector3 position4 = this.CorpseLocation.position;
			float num8 = position4.y = (float)num7;
			Vector3 vector4 = this.CorpseLocation.position = position4;
		}
	}

	public virtual void CensorStudents()
	{
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Students))
		{
			if (this.Students[this.ID] != null && !this.Students[this.ID].Male && !this.Students[this.ID].Teacher)
			{
				if (this.Censor)
				{
					this.Students[this.ID].Cosmetic.CensorPanties();
				}
				else
				{
					this.Students[this.ID].Cosmetic.RemoveCensor();
				}
			}
			this.ID++;
		}
	}

	public virtual void OccupySeat()
	{
		if (this.JSON.StudentClasses[this.SpawnID] == 11)
		{
			this.SeatsTaken11[this.JSON.StudentSeats[this.SpawnID]] = true;
		}
		else if (this.JSON.StudentClasses[this.SpawnID] == 12)
		{
			this.SeatsTaken12[this.JSON.StudentSeats[this.SpawnID]] = true;
		}
		else if (this.JSON.StudentClasses[this.SpawnID] == 21)
		{
			this.SeatsTaken21[this.JSON.StudentSeats[this.SpawnID]] = true;
		}
		else if (this.JSON.StudentClasses[this.SpawnID] == 22)
		{
			this.SeatsTaken22[this.JSON.StudentSeats[this.SpawnID]] = true;
		}
		else if (this.JSON.StudentClasses[this.SpawnID] == 31)
		{
			this.SeatsTaken31[this.JSON.StudentSeats[this.SpawnID]] = true;
		}
		else if (this.JSON.StudentClasses[this.SpawnID] == 32)
		{
			this.SeatsTaken32[this.JSON.StudentSeats[this.SpawnID]] = true;
		}
	}

	public virtual void FindUnoccupiedSeat()
	{
		this.SeatOccupied = false;
		this.ID = 1;
		if (this.Class == 1)
		{
			this.JSON.StudentClasses[this.SpawnID] = 11;
			while (this.ID < this.SeatsTaken11.Length && !this.SeatOccupied)
			{
				if (!this.SeatsTaken11[this.ID])
				{
					this.JSON.StudentSeats[this.SpawnID] = this.ID;
					this.SeatsTaken11[this.ID] = true;
					this.SeatOccupied = true;
				}
				this.ID++;
				if (this.ID > 15)
				{
					this.Class++;
				}
			}
		}
		else if (this.Class == 2)
		{
			this.JSON.StudentClasses[this.SpawnID] = 12;
			while (this.ID < this.SeatsTaken12.Length && !this.SeatOccupied)
			{
				if (!this.SeatsTaken12[this.ID])
				{
					this.JSON.StudentSeats[this.SpawnID] = this.ID;
					this.SeatsTaken12[this.ID] = true;
					this.SeatOccupied = true;
				}
				this.ID++;
				if (this.ID > 15)
				{
					this.Class++;
				}
			}
		}
		else if (this.Class == 3)
		{
			this.JSON.StudentClasses[this.SpawnID] = 21;
			while (this.ID < this.SeatsTaken21.Length && !this.SeatOccupied)
			{
				if (!this.SeatsTaken21[this.ID])
				{
					this.JSON.StudentSeats[this.SpawnID] = this.ID;
					this.SeatsTaken21[this.ID] = true;
					this.SeatOccupied = true;
				}
				this.ID++;
				if (this.ID > 15)
				{
					this.Class++;
				}
			}
		}
		else if (this.Class == 4)
		{
			this.JSON.StudentClasses[this.SpawnID] = 22;
			while (this.ID < this.SeatsTaken22.Length && !this.SeatOccupied)
			{
				if (!this.SeatsTaken22[this.ID])
				{
					this.JSON.StudentSeats[this.SpawnID] = this.ID;
					this.SeatsTaken22[this.ID] = true;
					this.SeatOccupied = true;
				}
				this.ID++;
				if (this.ID > 15)
				{
					this.Class++;
				}
			}
		}
		else if (this.Class == 5)
		{
			this.JSON.StudentClasses[this.SpawnID] = 31;
			while (this.ID < this.SeatsTaken31.Length && !this.SeatOccupied)
			{
				if (!this.SeatsTaken31[this.ID])
				{
					this.JSON.StudentSeats[this.SpawnID] = this.ID;
					this.SeatsTaken31[this.ID] = true;
					this.SeatOccupied = true;
				}
				this.ID++;
				if (this.ID > 15)
				{
					this.Class++;
				}
			}
		}
		else if (this.Class == 6)
		{
			this.JSON.StudentClasses[this.SpawnID] = 32;
			while (this.ID < this.SeatsTaken32.Length && !this.SeatOccupied)
			{
				if (!this.SeatsTaken32[this.ID])
				{
					this.JSON.StudentSeats[this.SpawnID] = this.ID;
					this.SeatsTaken32[this.ID] = true;
					this.SeatOccupied = true;
				}
				this.ID++;
				if (this.ID > 15)
				{
					this.Class++;
				}
			}
		}
		if (!this.SeatOccupied)
		{
			this.FindUnoccupiedSeat();
		}
	}

	public virtual void PinDownCheck()
	{
		if (!this.PinningDown && this.Witnesses > 3)
		{
			this.Yandere.Chased = true;
			this.Yandere.RunSpeed = (float)2;
			this.PinningDown = true;
			Debug.Log("Met criteria.");
			this.ID = 1;
			while (this.ID < 5)
			{
				if (this.WitnessList[this.ID] != null)
				{
					this.WitnessList[this.ID].CurrentDestination = this.PinDownSpots[this.ID];
					this.WitnessList[this.ID].Pathfinding.target = this.PinDownSpots[this.ID];
					this.WitnessList[this.ID].DistanceToDestination = (float)100;
					this.WitnessList[this.ID].Pathfinding.speed = (float)5;
					this.WitnessList[this.ID].PinningDown = true;
					this.WitnessList[this.ID].Alarmed = false;
					this.WitnessList[this.ID].Routine = false;
					this.WitnessList[this.ID].Fleeing = true;
					this.WitnessList[this.ID].AlarmTimer = (float)0;
					this.WitnessList[this.ID].Safe = true;
					this.WitnessList[this.ID].Prompt.Hide();
					this.WitnessList[this.ID].Prompt.enabled = false;
					Debug.Log(this.WitnessList[this.ID] + "'s current desination is " + this.WitnessList[this.ID].CurrentDestination);
				}
				this.ID++;
			}
		}
	}

	public virtual void Shuffle(int Start)
	{
		for (int i = Start; i < this.WitnessList.Length - 1; i++)
		{
			this.WitnessList[i] = this.WitnessList[i + 1];
		}
	}

	public virtual void Main()
	{
	}
}
