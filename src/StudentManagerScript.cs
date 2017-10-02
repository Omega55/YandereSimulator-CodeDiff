using System;
using UnityEngine;

public class StudentManagerScript : MonoBehaviour
{
	private PortraitChanScript NewPortraitChan;

	private GameObject NewStudent;

	public StudentScript[] Students;

	public SelectiveGrayscale SmartphoneSelectiveGreyscale;

	public SelectiveGrayscale HandSelectiveGreyscale;

	public CleaningManagerScript CleaningManager;

	public StolenPhoneSpotScript StolenPhoneSpot;

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

	public UILabel ErrorLabel;

	public ListScript SearchPatrols;

	public ListScript CleaningSpots;

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

	public Transform RivalConfessionSpot;

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

	public Transform SenpaiLocker;

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

	public Transform Papers;

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

	public int StudentsTotal = 13;

	public int TeachersTotal = 6;

	public int NPCsSpawned;

	public int NPCsTotal;

	public int Witnesses;

	public int PinPhase;

	public int Frame;

	public int GymTeacherID = 100;

	public int SuitorID = 13;

	public int RivalID = 7;

	public int SpawnID;

	public int ID;

	public bool MurderTakingPlace;

	public bool TakingPortraits;

	public bool TeachersSpawned;

	public bool DisableFarAnims;

	public bool YandereDying;

	public bool YandereLate;

	public bool FirstUpdate;

	public bool MissionMode;

	public bool PinningDown;

	public bool ForceSpawn;

	public bool NoGravity;

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

	public float PinTimer;

	public float Timer;

	public string[] ColorNames;

	public string[] MaleNames;

	public string[] FirstNames;

	public string[] LastNames;

	public AudioClip YanderePinDown;

	public AudioClip PinDownSFX;

	public bool Problem;

	public int ProblemID;

	public bool SeatOccupied;

	public int Class = 1;

	private void Start()
	{
		this.ID = 1;
		while (!this.Problem && this.ID < this.JSON.Students.Length)
		{
			if (!this.JSON.Students[this.ID].Success)
			{
				this.ProblemID = this.ID;
				this.Problem = true;
			}
			this.ID++;
		}
		if (!this.Problem)
		{
			if (this.ErrorLabel != null)
			{
				this.ErrorLabel.text = string.Empty;
			}
			this.SetAtmosphere();
			GameGlobals.Paranormal = false;
			if (MissionModeGlobals.MissionMode)
			{
				StudentGlobals.FemaleUniform = 5;
				StudentGlobals.MaleUniform = 5;
			}
			if (StudentGlobals.GetStudentSlave(SchoolGlobals.KidnapVictim))
			{
				this.ForceSpawn = true;
				this.SpawnPositions[SchoolGlobals.KidnapVictim] = this.SlaveSpot;
				this.SpawnID = SchoolGlobals.KidnapVictim;
				StudentGlobals.SetStudentDead(SchoolGlobals.KidnapVictim, false);
				this.SpawnStudent();
				this.Students[SchoolGlobals.KidnapVictim].Slave = true;
				this.SpawnID = 0;
				StudentGlobals.SetStudentSlave(SchoolGlobals.KidnapVictim, false);
				SchoolGlobals.KidnapVictim = 0;
			}
			this.NPCsTotal = this.StudentsTotal + this.TeachersTotal;
			this.SpawnID = 1;
			if (StudentGlobals.MaleUniform == 0)
			{
				StudentGlobals.MaleUniform = 1;
			}
			this.ID = 1;
			while (this.ID < this.NPCsTotal + 1)
			{
				if (!StudentGlobals.GetStudentDead(this.ID))
				{
					StudentGlobals.SetStudentDying(this.ID, false);
				}
				this.ID++;
			}
			if (!this.TakingPortraits)
			{
				this.ID = 1;
				while (this.ID < this.Lockers.List.Length)
				{
					Transform transform = UnityEngine.Object.Instantiate<GameObject>(this.EmptyObject, this.Lockers.List[this.ID].position + this.Lockers.List[this.ID].forward * 0.5f, this.Lockers.List[this.ID].rotation).transform;
					transform.parent = this.Lockers.transform;
					transform.transform.eulerAngles = new Vector3(transform.transform.eulerAngles.x, transform.transform.eulerAngles.y + 180f, transform.transform.eulerAngles.z);
					this.LockerPositions[this.ID] = transform;
					this.ID++;
				}
			}
			this.ID = 1;
			while (this.ID < this.HidingSpots.List.Length)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.EmptyObject, new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f)), Quaternion.identity);
				while ((double)gameObject.transform.position.x < 2.5 && (double)gameObject.transform.position.x > -2.5 && (double)gameObject.transform.position.z > -2.5 && (double)gameObject.transform.position.z < 2.5)
				{
					gameObject.transform.position = new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f));
				}
				gameObject.transform.parent = this.HidingSpots.transform;
				this.HidingSpots.List[this.ID] = gameObject.transform;
				this.ID++;
			}
			if (HomeGlobals.LateForSchool)
			{
				HomeGlobals.LateForSchool = false;
				this.YandereLate = true;
				this.Clock.PresentTime = 480f;
				this.Clock.HourTime = 8f;
				this.SkipTo8();
			}
			if (!this.TakingPortraits)
			{
				while (this.SpawnID < this.NPCsTotal + 1)
				{
					this.SpawnStudent();
				}
				this.UpdateStudents();
			}
		}
		else
		{
			string str = string.Empty;
			if (this.ProblemID > 1)
			{
				str = "The problem may be caused by Student " + this.ProblemID.ToString() + ".";
			}
			if (this.ErrorLabel != null)
			{
				this.ErrorLabel.text = "The game cannot compile Students.JSON! There is a typo somewhere in the JSON file. The problem might be a missing quotation mark, a missing colon, a missing comma, or something else like that. Please find your typo and fix it, or revert to a backup of the JSON file. " + str;
			}
		}
	}

	public void SetAtmosphere()
	{
		if (GameGlobals.LoveSick)
		{
			SchoolGlobals.SchoolAtmosphereSet = true;
			SchoolGlobals.SchoolAtmosphere = 0f;
		}
		if (!SchoolGlobals.SchoolAtmosphereSet)
		{
			SchoolGlobals.SchoolAtmosphereSet = true;
			SchoolGlobals.SchoolAtmosphere = 1f;
		}
		Vignetting[] components = Camera.main.GetComponents<Vignetting>();
		float num = 1f - SchoolGlobals.SchoolAtmosphere;
		if (!this.TakingPortraits)
		{
			this.SmartphoneSelectiveGreyscale.desaturation = num;
			this.SelectiveGreyscale.desaturation = num;
			components[2].intensity = num * 5f;
			components[2].blur = num;
			components[2].chromaticAberration = num * 5f;
			float num2 = 1f - num;
			RenderSettings.fogColor = new Color(num2, num2, num2, 1f);
			Camera.main.backgroundColor = new Color(num2, num2, num2, 1f);
			RenderSettings.fogDensity = num * 0.1f;
		}
	}

	private void Update()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		if (!this.TakingPortraits)
		{
			this.Frame++;
			if (!this.FirstUpdate)
			{
				this.QualityManager.UpdateOutlines();
				this.FirstUpdate = true;
				this.UpdateStudents();
				this.AssignTeachers();
			}
			if (this.Frame == 3)
			{
				this.LoveManager.CoupleCheck();
			}
		}
		else if (this.NPCsSpawned < this.StudentsTotal + this.TeachersTotal)
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
					this.NewStudent = UnityEngine.Object.Instantiate<GameObject>((UnityEngine.Random.Range(0, 2) != 0) ? this.PortraitKun : this.PortraitChan, Vector3.zero, Quaternion.identity);
				}
				else
				{
					this.NewStudent = UnityEngine.Object.Instantiate<GameObject>((this.JSON.Students[this.NPCsSpawned + 1].Gender != 0) ? this.PortraitKun : this.PortraitChan, Vector3.zero, Quaternion.identity);
				}
				this.NewStudent.GetComponent<CosmeticScript>().StudentID = this.NPCsSpawned + 1;
				this.NewStudent.GetComponent<CosmeticScript>().StudentManager = this;
				this.NewStudent.GetComponent<CosmeticScript>().TakingPortrait = true;
				this.NewStudent.GetComponent<CosmeticScript>().Randomize = this.Randomize;
				this.NewStudent.GetComponent<CosmeticScript>().JSON = this.JSON;
				this.NewPortraitChan = this.NewStudent.GetComponent<PortraitChanScript>();
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
				Application.CaptureScreenshot(Application.streamingAssetsPath + "/Portraits/Student_" + this.NPCsSpawned.ToString() + ".png");
				this.Frame = 0;
			}
		}
		else
		{
			Application.CaptureScreenshot(Application.streamingAssetsPath + "/Portraits/Student_" + this.NPCsSpawned.ToString() + ".png");
			base.gameObject.SetActive(false);
		}
		if (this.Witnesses > 0)
		{
			this.ID = 1;
			while (this.ID < this.WitnessList.Length)
			{
				StudentScript studentScript = this.WitnessList[this.ID];
				if (studentScript != null && (!studentScript.Alive || studentScript.Attacked || (studentScript.Fleeing && !studentScript.PinningDown)))
				{
					studentScript.PinDownWitness = false;
					if (this.ID != this.WitnessList.Length - 1)
					{
						this.Shuffle(this.ID);
					}
					this.Witnesses--;
				}
				this.ID++;
			}
			if (this.PinningDown && this.Witnesses < 4)
			{
				this.PinningDown = false;
				this.PinPhase = 0;
			}
		}
		if (this.PinningDown)
		{
			if (!this.Yandere.Attacking && this.Yandere.CanMove)
			{
				this.Yandere.CharacterAnimation.CrossFade("f02_pinDownPanic_00");
				this.Yandere.EmptyHands();
				this.Yandere.CanMove = false;
			}
			if (this.PinPhase == 1)
			{
				if (!this.Yandere.Attacking && !this.Yandere.Struggling)
				{
					this.PinTimer += Time.deltaTime;
				}
				if (this.PinTimer > 1f)
				{
					this.ID = 1;
					while (this.ID < 5)
					{
						StudentScript studentScript2 = this.WitnessList[this.ID];
						if (studentScript2 != null)
						{
							studentScript2.transform.position = new Vector3(studentScript2.transform.position.x, studentScript2.transform.position.y + 0.1f, studentScript2.transform.position.z);
							studentScript2.CurrentDestination = this.PinDownSpots[this.ID];
							studentScript2.Pathfinding.target = this.PinDownSpots[this.ID];
							studentScript2.DistanceToDestination = 100f;
							studentScript2.Pathfinding.speed = 5f;
							studentScript2.MyController.radius = 0f;
							studentScript2.PinningDown = true;
							studentScript2.Alarmed = false;
							studentScript2.Routine = false;
							studentScript2.Fleeing = true;
							studentScript2.AlarmTimer = 0f;
							studentScript2.Safe = true;
							studentScript2.Prompt.Hide();
							studentScript2.Prompt.enabled = false;
							Debug.Log(studentScript2 + "'s current destination is " + studentScript2.CurrentDestination);
						}
						this.ID++;
					}
					this.PinPhase++;
				}
			}
			else if (this.WitnessList[1].PinPhase == 0)
			{
				if (this.WitnessList[1].DistanceToDestination < 1f && this.WitnessList[2].DistanceToDestination < 1f && this.WitnessList[3].DistanceToDestination < 1f && this.WitnessList[4].DistanceToDestination < 1f)
				{
					this.Clock.StopTime = true;
					if (this.Yandere.Aiming)
					{
						this.Yandere.StopAiming();
						this.Yandere.enabled = false;
					}
					this.Yandere.Mopping = false;
					this.Yandere.EmptyHands();
					AudioSource component = base.GetComponent<AudioSource>();
					component.PlayOneShot(this.PinDownSFX);
					component.PlayOneShot(this.YanderePinDown);
					this.Yandere.CharacterAnimation.CrossFade("f02_pinDown_00");
					this.Yandere.CanMove = false;
					this.Yandere.ShoulderCamera.LookDown = true;
					this.Yandere.RPGCamera.enabled = false;
					this.StopMoving();
					this.ID = 1;
					while (this.ID < 5)
					{
						StudentScript studentScript3 = this.WitnessList[this.ID];
						studentScript3.SetLayerRecursively(studentScript3.gameObject, 13);
						studentScript3.CharacterAnimation.CrossFade((((!studentScript3.Male) ? "f02_pinDown_0" : "pinDown_0") + this.ID).ToString());
						studentScript3.PinPhase++;
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
						StudentScript studentScript4 = this.WitnessList[this.ID];
						studentScript4.CharacterAnimation.CrossFade((((!studentScript4.Male) ? "f02_pinDownLoop_0" : "pinDownLoop_0") + this.ID).ToString());
						this.ID++;
					}
					this.PinningDown = false;
				}
			}
		}
	}

	public void SpawnStudent()
	{
		if (this.Students[this.SpawnID] == null && !StudentGlobals.GetStudentDead(this.SpawnID) && !StudentGlobals.GetStudentKidnapped(this.SpawnID) && !StudentGlobals.GetStudentArrested(this.SpawnID) && !StudentGlobals.GetStudentExpelled(this.SpawnID) && this.JSON.Students[this.SpawnID].Name != "Unknown" && this.JSON.Students[this.SpawnID].Name != "Reserved" && StudentGlobals.GetStudentReputation(this.SpawnID) > -100)
		{
			int num;
			if (this.JSON.Students[this.SpawnID].Name == "Random")
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.EmptyObject, new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f)), Quaternion.identity);
				while ((double)gameObject.transform.position.x < 2.5 && (double)gameObject.transform.position.x > -2.5 && (double)gameObject.transform.position.z > -2.5 && (double)gameObject.transform.position.z < 2.5)
				{
					gameObject.transform.position = new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f));
				}
				gameObject.transform.parent = this.HidingSpots.transform;
				this.HidingSpots.List[this.SpawnID] = gameObject.transform;
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.RandomPatrol, Vector3.zero, Quaternion.identity);
				gameObject2.transform.parent = this.Patrols.transform;
				this.Patrols.List[this.SpawnID] = gameObject2.transform;
				GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.RandomPatrol, Vector3.zero, Quaternion.identity);
				gameObject3.transform.parent = this.CleaningSpots.transform;
				this.CleaningSpots.List[this.SpawnID] = gameObject3.transform;
				num = ((!MissionModeGlobals.MissionMode || MissionModeGlobals.MissionTarget != this.SpawnID) ? UnityEngine.Random.Range(0, 2) : 0);
				this.FindUnoccupiedSeat();
			}
			else
			{
				num = this.JSON.Students[this.SpawnID].Gender;
			}
			this.NewStudent = UnityEngine.Object.Instantiate<GameObject>((num != 0) ? this.StudentKun : this.StudentChan, this.SpawnPositions[this.SpawnID].position, Quaternion.identity);
			this.NewStudent.GetComponent<CosmeticScript>().LoveManager = this.LoveManager;
			this.NewStudent.GetComponent<CosmeticScript>().StudentManager = this;
			this.NewStudent.GetComponent<CosmeticScript>().Randomize = this.Randomize;
			this.NewStudent.GetComponent<CosmeticScript>().StudentID = this.SpawnID;
			this.NewStudent.GetComponent<CosmeticScript>().JSON = this.JSON;
			if (this.JSON.Students[this.SpawnID].Name == "Random")
			{
				this.NewStudent.GetComponent<StudentScript>().CleaningSpot = this.CleaningSpots.List[this.SpawnID];
				this.NewStudent.GetComponent<StudentScript>().CleaningRole = 3;
			}
			this.Students[this.SpawnID] = this.NewStudent.GetComponent<StudentScript>();
			StudentScript studentScript = this.Students[this.SpawnID];
			studentScript.Cosmetic.TextureManager = this.TextureManager;
			studentScript.WitnessCamera = this.WitnessCamera;
			studentScript.StudentManager = this;
			studentScript.StudentID = this.SpawnID;
			studentScript.JSON = this.JSON;
			if (this.AoT)
			{
				studentScript.AoT = true;
			}
			if (this.DK)
			{
				studentScript.DK = true;
			}
			if (this.Spooky)
			{
				studentScript.Spooky = true;
			}
			if (this.Sans)
			{
				studentScript.BadTime = true;
			}
			if (this.SpawnID == this.RivalID)
			{
				studentScript.Rival = true;
			}
			this.OccupySeat();
		}
		this.NPCsSpawned++;
		this.SpawnID++;
		this.TaskManager.UpdateTaskStatus();
		this.ForceSpawn = false;
	}

	public void UpdateStudents()
	{
		this.ID = 2;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && studentScript.gameObject.activeInHierarchy)
			{
				if (!studentScript.Safe)
				{
					if (!studentScript.Slave)
					{
						if (!studentScript.Following)
						{
							studentScript.Prompt.Label[0].text = "     Talk";
						}
						studentScript.Prompt.HideButton[0] = false;
						studentScript.Prompt.HideButton[2] = false;
						studentScript.Prompt.Attack = false;
						if (this.Yandere.Mask != null)
						{
							studentScript.Prompt.HideButton[0] = true;
						}
						if (this.Yandere.Dragging || this.Yandere.PickUp != null || this.Yandere.Chased)
						{
							studentScript.Prompt.HideButton[0] = true;
							studentScript.Prompt.HideButton[2] = true;
							if (this.Yandere.PickUp != null && this.Yandere.PickUp.Food > 0)
							{
								studentScript.Prompt.Label[0].text = "     Feed";
								studentScript.Prompt.HideButton[0] = false;
								studentScript.Prompt.HideButton[2] = true;
							}
						}
						if (this.Yandere.Armed)
						{
							studentScript.Prompt.HideButton[0] = true;
							studentScript.Prompt.Attack = true;
						}
						else
						{
							studentScript.Prompt.HideButton[2] = true;
							if (studentScript.WitnessedMurder || studentScript.WitnessedCorpse || studentScript.Private)
							{
								studentScript.Prompt.HideButton[0] = true;
							}
						}
						if (this.Yandere.NearBodies > 0 || this.Yandere.Sanity < 33.33333f)
						{
							studentScript.Prompt.HideButton[0] = true;
						}
						if (studentScript.Teacher)
						{
							studentScript.Prompt.HideButton[0] = true;
						}
					}
					else if (this.Yandere.Armed)
					{
						if (this.Yandere.EquippedWeapon.Concealable)
						{
							studentScript.Prompt.HideButton[0] = false;
							studentScript.Prompt.Label[0].text = "     Give Weapon";
						}
						else
						{
							studentScript.Prompt.HideButton[0] = true;
							studentScript.Prompt.Label[0].text = string.Empty;
						}
					}
					else
					{
						studentScript.Prompt.HideButton[0] = true;
						studentScript.Prompt.Label[0].text = string.Empty;
					}
				}
				if (this.NoSpeech && !studentScript.Armband.activeInHierarchy)
				{
					studentScript.Prompt.HideButton[0] = true;
				}
			}
			if (this.Sans && studentScript != null && studentScript.Prompt.Label[0] != null)
			{
				studentScript.Prompt.HideButton[0] = false;
				studentScript.Prompt.Label[0].text = "     Psychokinesis";
			}
			if (this.Pose && studentScript != null && studentScript.Prompt.Label[0] != null)
			{
				studentScript.Prompt.HideButton[0] = false;
				studentScript.Prompt.Label[0].text = "     Pose";
			}
			this.ID++;
		}
		this.Container.UpdatePrompts();
		this.TrashCan.UpdatePrompt();
	}

	public void UpdateMe(int ID)
	{
		if (ID > 1)
		{
			StudentScript studentScript = this.Students[ID];
			if (!studentScript.Safe)
			{
				studentScript.Prompt.Label[0].text = "     Talk";
				studentScript.Prompt.HideButton[0] = false;
				studentScript.Prompt.HideButton[2] = false;
				studentScript.Prompt.Attack = false;
				if (this.Yandere.Armed)
				{
					studentScript.Prompt.HideButton[0] = true;
					studentScript.Prompt.Attack = true;
				}
				else
				{
					studentScript.Prompt.HideButton[2] = true;
					if (studentScript.WitnessedMurder || studentScript.WitnessedCorpse || studentScript.Private)
					{
						studentScript.Prompt.HideButton[0] = true;
					}
				}
				if (this.Yandere.Dragging || this.Yandere.PickUp != null || this.Yandere.Chased)
				{
					studentScript.Prompt.HideButton[0] = true;
					studentScript.Prompt.HideButton[2] = true;
				}
				if (this.Yandere.NearBodies > 0 || this.Yandere.Sanity < 33.33333f)
				{
					studentScript.Prompt.HideButton[0] = true;
				}
				if (studentScript.Teacher)
				{
					studentScript.Prompt.HideButton[0] = true;
				}
			}
			if (this.Sans)
			{
				studentScript.Prompt.HideButton[0] = false;
				studentScript.Prompt.Label[0].text = "     Psychokinesis";
			}
			if (this.Pose)
			{
				studentScript.Prompt.HideButton[0] = false;
				studentScript.Prompt.Label[0].text = "     Pose";
			}
			if (this.NoSpeech)
			{
				studentScript.Prompt.HideButton[0] = true;
			}
		}
	}

	public void AttendClass()
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
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && studentScript.Alive && !studentScript.Slave && !studentScript.Tranquil)
			{
				if (!studentScript.Started)
				{
					studentScript.Start();
				}
				if (!studentScript.Teacher)
				{
					if (!studentScript.Indoors)
					{
						if (studentScript.ShoeRemoval.Locker == null)
						{
							studentScript.ShoeRemoval.Start();
						}
						studentScript.ShoeRemoval.PutOnShoes();
					}
					studentScript.transform.position = studentScript.Seat.position + Vector3.up * 0.01f;
					studentScript.transform.rotation = studentScript.Seat.rotation;
					studentScript.Character.GetComponent<Animation>().Play(studentScript.SitAnim);
					studentScript.Pathfinding.canSearch = false;
					studentScript.Pathfinding.canMove = false;
					studentScript.OccultBook.SetActive(false);
					studentScript.Pathfinding.speed = 0f;
					studentScript.Phone.SetActive(false);
					studentScript.Distracted = false;
					studentScript.OnPhone = false;
					studentScript.Routine = true;
					studentScript.Safe = false;
					if (studentScript.Wet)
					{
						studentScript.Schoolwear = 3;
						studentScript.ChangeSchoolwear();
						studentScript.LiquidProjector.enabled = false;
						studentScript.Splashed = false;
						studentScript.Bloody = false;
						studentScript.BathePhase = 1;
						studentScript.Wet = false;
						studentScript.UnWet();
						if (studentScript.Rival && this.CommunalLocker.RivalPhone.Stolen)
						{
							studentScript.RealizePhoneIsMissing();
						}
					}
					if (studentScript.ClubAttire)
					{
						studentScript.ChangeSchoolwear();
						studentScript.ClubAttire = false;
					}
				}
				else if (this.ID != this.GymTeacherID)
				{
					studentScript.transform.position = this.Podiums.List[studentScript.Class].position + Vector3.up * 0.01f;
					studentScript.transform.rotation = this.Podiums.List[studentScript.Class].rotation;
				}
				else
				{
					studentScript.transform.position = studentScript.Seat.position + Vector3.up * 0.01f;
					studentScript.transform.rotation = studentScript.Seat.rotation;
				}
			}
			this.ID++;
		}
	}

	public void SkipTo8()
	{
		while (this.NPCsSpawned < this.NPCsTotal)
		{
			this.SpawnStudent();
		}
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && studentScript.Alive && !studentScript.Slave && !studentScript.Tranquil)
			{
				if (!studentScript.Started)
				{
					studentScript.Start();
				}
				if (!studentScript.Teacher)
				{
					if (!studentScript.Indoors)
					{
						if (studentScript.ShoeRemoval.Locker == null)
						{
							studentScript.ShoeRemoval.Start();
						}
						studentScript.ShoeRemoval.PutOnShoes();
					}
					studentScript.transform.position = studentScript.Seat.position + Vector3.up * 0.01f;
					studentScript.transform.rotation = studentScript.Seat.rotation;
					studentScript.Pathfinding.canSearch = true;
					studentScript.Pathfinding.canMove = true;
					studentScript.OccultBook.SetActive(false);
					studentScript.Pathfinding.speed = 1f;
					studentScript.Phone.SetActive(false);
					studentScript.Distracted = false;
					studentScript.OnPhone = false;
					studentScript.Routine = true;
					studentScript.Safe = false;
					if (studentScript.ClubAttire)
					{
						studentScript.ChangeSchoolwear();
						studentScript.ClubAttire = true;
					}
					studentScript.TeleportToDestination();
					studentScript.TeleportToDestination();
				}
				else
				{
					studentScript.TeleportToDestination();
					studentScript.TeleportToDestination();
				}
			}
			this.ID++;
		}
	}

	public void ResumeMovement()
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.Pathfinding.canSearch = true;
				studentScript.Pathfinding.canMove = true;
				studentScript.Pathfinding.speed = 1f;
				studentScript.Routine = true;
			}
			this.ID++;
		}
	}

	public void StopMoving()
	{
		this.Stop = true;
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				if (!studentScript.Dying && !studentScript.PinningDown)
				{
					if (this.YandereDying)
					{
						studentScript.IdleAnim = studentScript.ScaredAnim;
					}
					if (this.Yandere.Attacking)
					{
						if (studentScript.MurderReaction == 0)
						{
							studentScript.Character.GetComponent<Animation>().CrossFade(studentScript.ScaredAnim);
						}
					}
					else if (this.ID > 1)
					{
						studentScript.Character.GetComponent<Animation>().CrossFade(studentScript.IdleAnim);
					}
					studentScript.Pathfinding.canSearch = false;
					studentScript.Pathfinding.canMove = false;
					studentScript.Pathfinding.speed = 0f;
					studentScript.Stop = true;
					if (studentScript.EventManager != null)
					{
						studentScript.EventManager.EndEvent();
					}
				}
				if (studentScript.Alive && studentScript.SawMask)
				{
					this.Police.MaskReported = true;
				}
			}
			this.ID++;
		}
	}

	public void StopFleeing()
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && !studentScript.Teacher)
			{
				studentScript.Pathfinding.target = studentScript.Destinations[studentScript.Phase];
				studentScript.Pathfinding.speed = 1f;
				studentScript.WitnessedCorpse = false;
				studentScript.WitnessedMurder = false;
				studentScript.Alarmed = false;
				studentScript.Fleeing = false;
				studentScript.Reacted = false;
				studentScript.Witness = false;
				studentScript.Routine = true;
			}
			this.ID++;
		}
	}

	public void EnablePrompts()
	{
		this.ID = 2;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.Prompt.enabled = true;
			}
			this.ID++;
		}
	}

	public void DisablePrompts()
	{
		this.ID = 2;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.Prompt.Hide();
				studentScript.Prompt.enabled = false;
			}
			this.ID++;
		}
	}

	public void WipePendingRep()
	{
		this.ID = 2;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.PendingRep = 0f;
			}
			this.ID++;
		}
	}

	public void AttackOnTitan()
	{
		this.AoT = true;
		this.ID = 2;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && !studentScript.Teacher)
			{
				studentScript.AttackOnTitan();
			}
			this.ID++;
		}
	}

	public void Kong()
	{
		this.DK = true;
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.DK = true;
			}
			this.ID++;
		}
	}

	public void Spook()
	{
		this.Spooky = true;
		this.ID = 2;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && !studentScript.Male)
			{
				studentScript.Spook();
			}
			this.ID++;
		}
	}

	public void BadTime()
	{
		this.Sans = true;
		this.ID = 2;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.Prompt.HideButton[0] = false;
				studentScript.BadTime = true;
			}
			this.ID++;
		}
	}

	public void UpdateBooths()
	{
		this.ID = 0;
		while (this.ID < this.ChangingBooths.Length)
		{
			ChangingBoothScript changingBoothScript = this.ChangingBooths[this.ID];
			if (changingBoothScript != null)
			{
				changingBoothScript.CheckYandereClub();
			}
			this.ID++;
		}
	}

	public void UpdatePerception()
	{
		this.ID = 0;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.UpdatePerception();
			}
			this.ID++;
		}
	}

	public void StopHesitating()
	{
		this.ID = 0;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				if (studentScript.AlarmTimer > 0f)
				{
					studentScript.AlarmTimer = 1f;
				}
				studentScript.Hesitation = 0f;
			}
			this.ID++;
		}
	}

	private void Unstop()
	{
		this.ID = 0;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.Stop = false;
			}
			this.ID++;
		}
	}

	public void LowerCorpsePostion()
	{
		if (this.CorpseLocation.position.y < 4f)
		{
			this.CorpseLocation.position = new Vector3(this.CorpseLocation.position.x, 0f, this.CorpseLocation.position.z);
		}
		else if (this.CorpseLocation.position.y < 8f)
		{
			this.CorpseLocation.position = new Vector3(this.CorpseLocation.position.x, 4f, this.CorpseLocation.position.z);
		}
		else if (this.CorpseLocation.position.y < 12f)
		{
			this.CorpseLocation.position = new Vector3(this.CorpseLocation.position.x, 8f, this.CorpseLocation.position.z);
		}
		else
		{
			this.CorpseLocation.position = new Vector3(this.CorpseLocation.position.x, 12f, this.CorpseLocation.position.z);
		}
	}

	public void CensorStudents()
	{
		this.ID = 0;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && !studentScript.Male && !studentScript.Teacher)
			{
				if (this.Censor)
				{
					studentScript.Cosmetic.CensorPanties();
				}
				else
				{
					studentScript.Cosmetic.RemoveCensor();
				}
			}
			this.ID++;
		}
	}

	private void OccupySeat()
	{
		int @class = this.JSON.Students[this.SpawnID].Class;
		int seat = this.JSON.Students[this.SpawnID].Seat;
		if (@class == 11)
		{
			this.SeatsTaken11[seat] = true;
		}
		else if (@class == 12)
		{
			this.SeatsTaken12[seat] = true;
		}
		else if (@class == 21)
		{
			this.SeatsTaken21[seat] = true;
		}
		else if (@class == 22)
		{
			this.SeatsTaken22[seat] = true;
		}
		else if (@class == 31)
		{
			this.SeatsTaken31[seat] = true;
		}
		else if (@class == 32)
		{
			this.SeatsTaken32[seat] = true;
		}
	}

	private void FindUnoccupiedSeat()
	{
		this.SeatOccupied = false;
		if (this.Class == 1)
		{
			this.JSON.Students[this.SpawnID].Class = 11;
			this.ID = 1;
			while (this.ID < this.SeatsTaken11.Length && !this.SeatOccupied)
			{
				if (!this.SeatsTaken11[this.ID])
				{
					this.JSON.Students[this.SpawnID].Seat = this.ID;
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
			this.JSON.Students[this.SpawnID].Class = 12;
			this.ID = 1;
			while (this.ID < this.SeatsTaken12.Length && !this.SeatOccupied)
			{
				if (!this.SeatsTaken12[this.ID])
				{
					this.JSON.Students[this.SpawnID].Seat = this.ID;
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
			this.JSON.Students[this.SpawnID].Class = 21;
			this.ID = 1;
			while (this.ID < this.SeatsTaken21.Length && !this.SeatOccupied)
			{
				if (!this.SeatsTaken21[this.ID])
				{
					this.JSON.Students[this.SpawnID].Seat = this.ID;
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
			this.JSON.Students[this.SpawnID].Class = 22;
			this.ID = 1;
			while (this.ID < this.SeatsTaken22.Length && !this.SeatOccupied)
			{
				if (!this.SeatsTaken22[this.ID])
				{
					this.JSON.Students[this.SpawnID].Seat = this.ID;
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
			this.JSON.Students[this.SpawnID].Class = 31;
			this.ID = 1;
			while (this.ID < this.SeatsTaken31.Length && !this.SeatOccupied)
			{
				if (!this.SeatsTaken31[this.ID])
				{
					this.JSON.Students[this.SpawnID].Seat = this.ID;
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
			this.JSON.Students[this.SpawnID].Class = 32;
			this.ID = 1;
			while (this.ID < this.SeatsTaken32.Length && !this.SeatOccupied)
			{
				if (!this.SeatsTaken32[this.ID])
				{
					this.JSON.Students[this.SpawnID].Seat = this.ID;
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

	public void PinDownCheck()
	{
		if (!this.PinningDown && this.Witnesses > 3)
		{
			this.ID = 1;
			while (this.ID < this.WitnessList.Length)
			{
				StudentScript studentScript = this.WitnessList[this.ID];
				if (studentScript != null && (!studentScript.Alive || studentScript.Attacked || studentScript.Fleeing))
				{
					if (this.ID != this.WitnessList.Length - 1)
					{
						this.Shuffle(this.ID);
					}
					this.Witnesses--;
				}
				this.ID++;
			}
			if (this.Witnesses > 3)
			{
				this.PinningDown = true;
				this.PinPhase = 1;
			}
		}
	}

	private void Shuffle(int Start)
	{
		for (int i = Start; i < this.WitnessList.Length - 1; i++)
		{
			this.WitnessList[i] = this.WitnessList[i + 1];
		}
	}

	public void ChangeOka()
	{
		StudentScript studentScript = this.Students[26];
		if (studentScript != null)
		{
			studentScript.AttachRiggedAccessory();
		}
	}

	public void RemovePapersFromDesks()
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			if (this.Students[this.ID] != null && this.Students[this.ID].MyPaper != null)
			{
				this.Students[this.ID].MyPaper.SetActive(false);
			}
			this.ID++;
		}
	}

	public void SetStudentsActive(bool active)
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.gameObject.SetActive(active);
			}
			this.ID++;
		}
	}

	public void AssignTeachers()
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			if (this.Students[this.ID] != null)
			{
				this.Students[this.ID].MyTeacher = this.Teachers[this.JSON.Students[this.Students[this.ID].StudentID].Class];
			}
			this.ID++;
		}
	}
}
