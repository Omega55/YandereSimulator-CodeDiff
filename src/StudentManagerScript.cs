using System;
using UnityEngine;

public class StudentManagerScript : MonoBehaviour
{
	private PortraitChanScript NewPortraitChan;

	private GameObject NewStudent;

	public StudentScript[] Students;

	public SelectiveGrayscale SmartphoneSelectiveGreyscale;

	public PickpocketMinigameScript PickpocketMinigame;

	public SelectiveGrayscale HandSelectiveGreyscale;

	public CleaningManagerScript CleaningManager;

	public StolenPhoneSpotScript StolenPhoneSpot;

	public SelectiveGrayscale SelectiveGreyscale;

	public CombatMinigameScript CombatMinigame;

	public DatingMinigameScript DatingMinigame;

	public TextureManagerScript TextureManager;

	public QualityManagerScript QualityManager;

	public ComputerGamesScript ComputerGames;

	public EmergencyExitScript EmergencyExit;

	public TranqDetectorScript TranqDetector;

	public WitnessCameraScript WitnessCamera;

	public ConvoManagerScript ConvoManager;

	public TallLockerScript CommunalLocker;

	public CabinetDoorScript CabinetDoor;

	public LightSwitchScript LightSwitch;

	public LoveManagerScript LoveManager;

	public TaskManagerScript TaskManager;

	public ReputationScript Reputation;

	public WeaponScript FragileWeapon;

	public ContainerScript Container;

	public RingEventScript RingEvent;

	public HologramScript Holograms;

	public RobotArmScript RobotArms;

	public FountainScript Fountain;

	public PoseModeScript PoseMode;

	public TrashCanScript TrashCan;

	public StudentScript Reporter;

	public GhostScript GhostChan;

	public YandereScript Yandere;

	public ListScript MeetSpots;

	public PoliceScript Police;

	public DoorScript ShedDoor;

	public UILabel ErrorLabel;

	public RestScript Rest;

	public TagScript Tag;

	public DoorScript AltFemaleVomitDoor;

	public DoorScript FemaleVomitDoor;

	public ParticleSystem AltFemaleDrownSplashes;

	public ParticleSystem FemaleDrownSplashes;

	public OfferHelpScript FragileOfferHelp;

	public OfferHelpScript OfferHelp;

	public Transform AltFemaleVomitSpot;

	public Transform FemaleVomitSpot;

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

	public StudentScript[] WitnessList;

	public StudentScript[] Teachers;

	public GameObject[] Graffiti;

	public ListScript[] Seats;

	public Transform[] TeacherGuardLocation;

	public Transform[] CorpseGuardLocation;

	public Transform[] SleuthDestinations;

	public Transform[] GardeningPatrols;

	public Transform[] LockerPositions;

	public Transform[] SpawnPositions;

	public Transform[] GraffitiSpots;

	public Transform[] PinDownSpots;

	public Transform[] SupplySpots;

	public Transform[] BullySpots;

	public Transform[] SulkSpots;

	public Transform[] FleeSpots;

	public bool[] SeatsTaken11;

	public bool[] SeatsTaken12;

	public bool[] SeatsTaken21;

	public bool[] SeatsTaken22;

	public bool[] SeatsTaken31;

	public bool[] SeatsTaken32;

	public bool[] NoBully;

	public Collider RivalDeskCollider;

	public Transform FollowerLookAtTarget;

	public Transform SuitorConfessionSpot;

	public Transform RivalConfessionSpot;

	public Transform ConfessionWaypoint;

	public Transform FragileSlaveSpot;

	public Transform FemaleCoupleSpot;

	public Transform YandereStripSpot;

	public Transform FemaleStalkSpot;

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

	public Transform BullyGroup;

	public Transform EdgeOfGrid;

	public Transform GoAwaySpot;

	public Transform SuitorSpot;

	public Transform ToolTarget;

	public Transform BatheSpot;

	public Transform MournSpot;

	public Transform ShameSpot;

	public Transform SlaveSpot;

	public Transform StripSpot;

	public Transform Papers;

	public Transform Exit;

	public GameObject LovestruckCamera;

	public GameObject GardenBlockade;

	public GameObject PortraitChan;

	public GameObject RandomPatrol;

	public GameObject ChaseCamera;

	public GameObject EmptyObject;

	public GameObject PortraitKun;

	public GameObject StudentChan;

	public GameObject StudentKun;

	public GameObject RivalChan;

	public GameObject Flowers;

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

	public int Bullies;

	public int Frame;

	public int GymTeacherID = 100;

	public int SleuthPhase = 1;

	public int SuitorID = 13;

	public int VictimID;

	public int NurseID = 93;

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

	public bool Bully;

	public bool Gaze;

	public bool Pose;

	public bool Sans;

	public bool Stop;

	public bool Egg;

	public bool Six;

	public bool AoT;

	public bool DK;

	public float ChangeTimer;

	public float SleuthTimer;

	public float LowestRep;

	public float PinTimer;

	public float Timer;

	public string[] ColorNames;

	public string[] MaleNames;

	public string[] FirstNames;

	public string[] LastNames;

	public AudioClip YanderePinDown;

	public AudioClip PinDownSFX;

	[SerializeField]
	private int ProblemID = -1;

	public GameObject Cardigan;

	public SkinnedMeshRenderer CardiganRenderer;

	public bool SeatOccupied;

	public int Class = 1;

	private void Start()
	{
		this.ID = 76;
		while (this.ID < 81)
		{
			if (StudentGlobals.GetStudentReputation(this.ID) > -67)
			{
				StudentGlobals.SetStudentReputation(this.ID, -67);
			}
			this.ID++;
		}
		if (ClubGlobals.GetClubClosed(ClubType.Gardening))
		{
			this.GardenBlockade.SetActive(true);
			this.Flowers.SetActive(false);
		}
		this.ID = 0;
		this.SeatsTaken31[13] = true;
		this.SeatsTaken21[12] = true;
		this.SeatsTaken21[14] = true;
		this.SeatsTaken22[12] = true;
		this.SeatsTaken22[14] = true;
		this.SeatsTaken32[1] = true;
		this.SeatsTaken31[1] = true;
		this.SeatsTaken22[1] = true;
		this.SeatsTaken21[1] = true;
		this.SeatsTaken12[1] = true;
		this.SeatsTaken32[3] = true;
		this.SeatsTaken31[3] = true;
		this.SeatsTaken22[3] = true;
		this.SeatsTaken21[3] = true;
		this.SeatsTaken32[2] = true;
		this.SeatsTaken31[2] = true;
		this.SeatsTaken22[2] = true;
		this.SeatsTaken21[2] = true;
		this.SeatsTaken12[2] = true;
		this.SeatsTaken32[4] = true;
		this.SeatsTaken31[4] = true;
		this.SeatsTaken22[4] = true;
		this.SeatsTaken21[4] = true;
		this.SeatsTaken12[4] = true;
		this.SeatsTaken32[6] = true;
		this.SeatsTaken31[6] = true;
		this.SeatsTaken22[6] = true;
		this.SeatsTaken21[6] = true;
		this.SeatsTaken12[6] = true;
		this.SeatsTaken32[11] = true;
		this.SeatsTaken31[11] = true;
		this.SeatsTaken22[11] = true;
		this.SeatsTaken12[11] = true;
		this.SeatsTaken11[11] = true;
		this.SeatsTaken31[15] = true;
		this.SeatsTaken22[15] = true;
		this.SeatsTaken21[15] = true;
		this.SeatsTaken12[15] = true;
		this.SeatsTaken11[15] = true;
		this.ID = 1;
		while (this.ID < this.JSON.Students.Length)
		{
			if (!this.JSON.Students[this.ID].Success)
			{
				this.ProblemID = this.ID;
				break;
			}
			this.ID++;
		}
		bool flag = this.ProblemID != -1;
		if (flag)
		{
			if (this.ErrorLabel != null)
			{
				this.ErrorLabel.text = string.Empty;
				this.ErrorLabel.enabled = false;
			}
			this.SetAtmosphere();
			GameGlobals.Paranormal = false;
			if (MissionModeGlobals.MissionMode)
			{
				StudentGlobals.FemaleUniform = 5;
				StudentGlobals.MaleUniform = 5;
			}
			if (StudentGlobals.GetStudentSlave() > 0 && !StudentGlobals.GetStudentDead(StudentGlobals.GetStudentSlave()))
			{
				int studentSlave = StudentGlobals.GetStudentSlave();
				this.ForceSpawn = true;
				this.SpawnPositions[studentSlave] = this.SlaveSpot;
				this.SpawnID = studentSlave;
				StudentGlobals.SetStudentDead(studentSlave, false);
				this.SpawnStudent(this.SpawnID);
				this.Students[studentSlave].Slave = true;
				this.SpawnID = 0;
			}
			if (StudentGlobals.GetStudentFragileSlave() > 0 && !StudentGlobals.GetStudentDead(StudentGlobals.GetStudentFragileSlave()))
			{
				int studentFragileSlave = StudentGlobals.GetStudentFragileSlave();
				this.ForceSpawn = true;
				this.SpawnPositions[studentFragileSlave] = this.FragileSlaveSpot;
				this.SpawnID = studentFragileSlave;
				StudentGlobals.SetStudentDead(studentFragileSlave, false);
				this.SpawnStudent(this.SpawnID);
				this.Students[studentFragileSlave].FragileSlave = true;
				this.Students[studentFragileSlave].Slave = true;
				this.SpawnID = 0;
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
				this.ID = 1;
				while (this.ID < this.HidingSpots.List.Length)
				{
					if (this.HidingSpots.List[this.ID] == null)
					{
						GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.EmptyObject, new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f)), Quaternion.identity);
						while (gameObject.transform.position.x < 2.5f && gameObject.transform.position.x > -2.5f && gameObject.transform.position.z > -2.5f && gameObject.transform.position.z < 2.5f)
						{
							gameObject.transform.position = new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f));
						}
						gameObject.transform.parent = this.HidingSpots.transform;
						this.HidingSpots.List[this.ID] = gameObject.transform;
					}
					this.ID++;
				}
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
					this.SpawnStudent(this.SpawnID);
					this.SpawnID++;
				}
				this.Graffiti[1].SetActive(false);
				this.Graffiti[2].SetActive(false);
				this.Graffiti[3].SetActive(false);
				this.Graffiti[4].SetActive(false);
				this.Graffiti[5].SetActive(false);
				if (this.Students[34] != null)
				{
					this.RivalChan.SetActive(false);
				}
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
				this.ErrorLabel.enabled = true;
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
				this.AssignTeachers();
			}
			if (this.Frame == 3)
			{
				this.LoveManager.CoupleCheck();
				if (this.Bullies > 0)
				{
					this.DetermineVictim();
				}
				this.UpdateStudents();
				if (!OptionGlobals.RimLight)
				{
					this.QualityManager.RimLight();
				}
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
				ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/Portraits/Student_" + this.NPCsSpawned.ToString() + ".png");
				this.Frame = 0;
			}
		}
		else
		{
			ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/Portraits/Student_" + this.NPCsSpawned.ToString() + ".png");
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
				Debug.Log("Students were going to pin Yandere-chan down, but now there are less than 4 witnesses, so it's not going to happen.");
				this.Yandere.CanMove = true;
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
							studentScript2.SprintAnim = studentScript2.OriginalSprintAnim;
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
					this.Yandere.ShoulderCamera.HeartbrokenCamera.GetComponent<Camera>().cullingMask |= 512;
					this.ID = 1;
					while (this.ID < 5)
					{
						StudentScript studentScript3 = this.WitnessList[this.ID];
						if (studentScript3.MyWeapon != null)
						{
							GameObjectUtils.SetLayerRecursively(studentScript3.MyWeapon.gameObject, 13);
						}
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
		if (Input.GetKeyDown("space"))
		{
			this.DetermineVictim();
		}
	}

	public void SpawnStudent(int spawnID)
	{
		bool flag = false;
		if (spawnID == 33 || spawnID == 34 || spawnID == 35)
		{
			flag = true;
		}
		if (!flag && this.Students[spawnID] == null && !StudentGlobals.GetStudentDead(spawnID) && !StudentGlobals.GetStudentKidnapped(spawnID) && !StudentGlobals.GetStudentArrested(spawnID) && !StudentGlobals.GetStudentExpelled(spawnID) && this.JSON.Students[spawnID].Name != "Unknown" && this.JSON.Students[spawnID].Name != "Reserved" && StudentGlobals.GetStudentReputation(spawnID) > -100)
		{
			int num;
			if (this.JSON.Students[spawnID].Name == "Random")
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.EmptyObject, new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f)), Quaternion.identity);
				while (gameObject.transform.position.x < 2.5f && gameObject.transform.position.x > -2.5f && gameObject.transform.position.z > -2.5f && gameObject.transform.position.z < 2.5f)
				{
					gameObject.transform.position = new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f));
				}
				gameObject.transform.parent = this.HidingSpots.transform;
				this.HidingSpots.List[spawnID] = gameObject.transform;
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.RandomPatrol, Vector3.zero, Quaternion.identity);
				gameObject2.transform.parent = this.Patrols.transform;
				this.Patrols.List[spawnID] = gameObject2.transform;
				GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.RandomPatrol, Vector3.zero, Quaternion.identity);
				gameObject3.transform.parent = this.CleaningSpots.transform;
				this.CleaningSpots.List[spawnID] = gameObject3.transform;
				num = ((!MissionModeGlobals.MissionMode || MissionModeGlobals.MissionTarget != spawnID) ? UnityEngine.Random.Range(0, 2) : 0);
				this.FindUnoccupiedSeat();
			}
			else
			{
				num = this.JSON.Students[spawnID].Gender;
			}
			this.NewStudent = UnityEngine.Object.Instantiate<GameObject>((num != 0) ? this.StudentKun : this.StudentChan, this.SpawnPositions[spawnID].position, Quaternion.identity);
			this.NewStudent.GetComponent<CosmeticScript>().LoveManager = this.LoveManager;
			this.NewStudent.GetComponent<CosmeticScript>().StudentManager = this;
			this.NewStudent.GetComponent<CosmeticScript>().Randomize = this.Randomize;
			this.NewStudent.GetComponent<CosmeticScript>().StudentID = spawnID;
			this.NewStudent.GetComponent<CosmeticScript>().JSON = this.JSON;
			if (this.JSON.Students[spawnID].Name == "Random")
			{
				this.NewStudent.GetComponent<StudentScript>().CleaningSpot = this.CleaningSpots.List[spawnID];
				this.NewStudent.GetComponent<StudentScript>().CleaningRole = 3;
			}
			if (this.JSON.Students[spawnID].Club == ClubType.Bully)
			{
				this.Bullies++;
			}
			this.Students[spawnID] = this.NewStudent.GetComponent<StudentScript>();
			StudentScript studentScript = this.Students[spawnID];
			studentScript.Cosmetic.TextureManager = this.TextureManager;
			studentScript.WitnessCamera = this.WitnessCamera;
			studentScript.StudentManager = this;
			studentScript.StudentID = spawnID;
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
			if (spawnID == this.RivalID)
			{
				studentScript.Rival = true;
			}
			this.OccupySeat();
		}
		this.NPCsSpawned++;
		this.TaskManager.UpdateTaskStatus();
		this.ForceSpawn = false;
	}

	public void UpdateStudents()
	{
		this.ID = 2;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				if (studentScript.gameObject.activeInHierarchy)
				{
					if (!studentScript.Safe)
					{
						if (!studentScript.Slave)
						{
							if (studentScript.Pushable)
							{
								studentScript.Prompt.Label[0].text = "     Push";
							}
							else if (!studentScript.Following)
							{
								studentScript.Prompt.Label[0].text = "     Talk";
							}
							else
							{
								studentScript.Prompt.Label[0].text = "     Stop";
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
								studentScript.Prompt.MinimumDistance = 1f;
								studentScript.Prompt.Attack = true;
							}
							else
							{
								studentScript.Prompt.HideButton[2] = true;
								studentScript.Prompt.MinimumDistance = 2f;
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
						else if (studentScript.Persona != PersonaType.Fragile)
						{
							if (this.Yandere.Armed)
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
					}
					if (this.NoSpeech && !studentScript.Armband.activeInHierarchy)
					{
						studentScript.Prompt.HideButton[0] = true;
					}
				}
				if (studentScript.Prompt.Label[0] != null)
				{
					if (this.Sans)
					{
						studentScript.Prompt.HideButton[0] = false;
						studentScript.Prompt.Label[0].text = "     Psychokinesis";
					}
					if (this.Pose)
					{
						studentScript.Prompt.HideButton[0] = false;
						studentScript.Prompt.Label[0].text = "     Pose";
						studentScript.Prompt.BloodMask = 1;
						studentScript.Prompt.BloodMask |= 2;
						studentScript.Prompt.BloodMask |= 512;
						studentScript.Prompt.BloodMask |= 8192;
						studentScript.Prompt.BloodMask |= 16384;
						studentScript.Prompt.BloodMask |= 65536;
						studentScript.Prompt.BloodMask |= 2097152;
						studentScript.Prompt.BloodMask = ~studentScript.Prompt.BloodMask;
					}
					if (!studentScript.Teacher && this.Six)
					{
						studentScript.Prompt.MinimumDistance = 0.75f;
						studentScript.Prompt.HideButton[0] = false;
						studentScript.Prompt.Label[0].text = "     Eat";
					}
					if (this.Gaze)
					{
						studentScript.Prompt.MinimumDistance = 5f;
						studentScript.Prompt.HideButton[0] = false;
						studentScript.Prompt.Label[0].text = "     Gaze";
					}
				}
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
					studentScript.Prompt.MinimumDistance = 1f;
					studentScript.Prompt.Attack = true;
				}
				else
				{
					studentScript.Prompt.HideButton[2] = true;
					studentScript.Prompt.MinimumDistance = 2f;
					if (studentScript.WitnessedMurder || studentScript.WitnessedCorpse || studentScript.Private)
					{
						studentScript.Prompt.HideButton[0] = true;
					}
				}
				if (this.Yandere.Dragging || this.Yandere.PickUp != null || this.Yandere.Chased || this.Yandere.Chasers > 0)
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
		Debug.Log("All students are now being told to attend class.");
		this.ConvoManager.Confirmed = false;
		this.SleuthPhase = 3;
		if (this.RingEvent.EventActive)
		{
			this.RingEvent.ReturnRing();
		}
		while (this.NPCsSpawned < this.NPCsTotal)
		{
			this.SpawnStudent(this.SpawnID);
			this.SpawnID++;
		}
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && studentScript.Alive && !studentScript.Slave && !studentScript.Tranquil && !studentScript.Fleeing && studentScript.enabled && studentScript.gameObject.activeInHierarchy)
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
					studentScript.SmartPhone.SetActive(false);
					studentScript.Pathfinding.speed = 0f;
					studentScript.Distracted = false;
					studentScript.Pushable = false;
					studentScript.Routine = true;
					studentScript.Hurry = false;
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
					if (studentScript.Meeting && this.Clock.HourTime > studentScript.MeetTime)
					{
						studentScript.Meeting = false;
					}
					if (studentScript.Club == ClubType.Sports)
					{
						studentScript.SetSplashes(false);
						studentScript.WalkAnim = studentScript.OriginalWalkAnim;
						studentScript.Character.transform.localPosition = new Vector3(0f, 0f, 0f);
						studentScript.Cosmetic.Goggles[studentScript.StudentID].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 0f);
						studentScript.Cosmetic.MaleHair[studentScript.Cosmetic.Hairstyle].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 0f);
					}
				}
				else if (this.ID != this.GymTeacherID && this.ID != this.NurseID)
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
		this.UpdateStudents();
		Physics.SyncTransforms();
	}

	public void SkipTo8()
	{
		while (this.NPCsSpawned < this.NPCsTotal)
		{
			this.SpawnStudent(this.SpawnID);
			this.SpawnID++;
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
					studentScript.SmartPhone.SetActive(false);
					studentScript.OccultBook.SetActive(false);
					studentScript.Pathfinding.speed = 1f;
					studentScript.Distracted = false;
					studentScript.Spawned = true;
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
			if (studentScript != null && !studentScript.Fleeing)
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
		this.CombatMinigame.enabled = false;
		this.Stop = true;
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				if (!studentScript.Dying && !studentScript.PinningDown && !studentScript.Spraying)
				{
					if (this.YandereDying && studentScript.Club != ClubType.Council)
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
				if (studentScript.Slave)
				{
					studentScript.Broken.Subtitle.text = string.Empty;
					studentScript.Broken.Done = true;
					UnityEngine.Object.Destroy(studentScript.Broken);
					studentScript.Slave = false;
					studentScript.Suicide = true;
					studentScript.BecomeRagdoll();
					studentScript.DeathType = DeathType.Mystery;
					StudentGlobals.SetStudentSlave(studentScript.StudentID);
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

	public void LowerCorpsePosition()
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
			if (studentScript != null && !studentScript.Male && studentScript.Club != ClubType.Teacher && studentScript.Club != ClubType.GymTeacher && studentScript.Club != ClubType.Nurse)
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
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && studentScript.MyPaper != null)
			{
				studentScript.MyPaper.SetActive(false);
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
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.MyTeacher = this.Teachers[this.JSON.Students[studentScript.StudentID].Class];
			}
			this.ID++;
		}
	}

	public void ToggleBookBags()
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.BookBag.SetActive(!studentScript.BookBag.activeInHierarchy);
			}
			this.ID++;
		}
	}

	public void DetermineVictim()
	{
		this.Bully = false;
		this.ID = 2;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && !studentScript.Teacher && !studentScript.Slave && studentScript.Club != ClubType.Bully && studentScript.Club != ClubType.Council && studentScript.Club != ClubType.Delinquent && (float)StudentGlobals.GetStudentReputation(this.ID) < this.LowestRep)
			{
				this.LowestRep = (float)StudentGlobals.GetStudentReputation(this.ID);
				this.VictimID = this.ID;
				this.Bully = true;
			}
			this.ID++;
		}
		if (this.Bully)
		{
			Debug.Log("A student has been chosen to be bullied. It's Student #" + this.VictimID + ".");
			if (this.Students[this.VictimID].Seat.position.x > 0f)
			{
				this.BullyGroup.position = this.Students[this.VictimID].Seat.position + new Vector3(0.33333f, 0f, 0f);
			}
			else
			{
				this.BullyGroup.position = this.Students[this.VictimID].Seat.position - new Vector3(0.33333f, 0f, 0f);
				this.BullyGroup.eulerAngles = new Vector3(0f, 90f, 0f);
			}
			StudentScript studentScript2 = this.Students[this.VictimID];
			ScheduleBlock scheduleBlock = studentScript2.ScheduleBlocks[2];
			scheduleBlock.destination = "ShameSpot";
			scheduleBlock.action = "Shamed";
			ScheduleBlock scheduleBlock2 = studentScript2.ScheduleBlocks[4];
			scheduleBlock2.destination = "Seat";
			scheduleBlock2.action = "Sit";
			studentScript2.IdleAnim = studentScript2.BulliedIdleAnim;
			studentScript2.WalkAnim = studentScript2.BulliedWalkAnim;
			studentScript2.Bullied = true;
			studentScript2.GetDestinations();
			studentScript2.CameraAnims = studentScript2.CowardAnims;
			studentScript2.BusyAtLunch = true;
			studentScript2.Shy = false;
		}
	}

	public void SecurityCameras()
	{
		this.Egg = true;
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null && studentScript.SecurityCamera != null && studentScript.Ragdoll != base.enabled)
			{
				studentScript.SecurityCamera.SetActive(true);
			}
			this.ID++;
		}
	}

	public void DisableStudent(int DisableID)
	{
		StudentScript studentScript = this.Students[DisableID];
		if (studentScript != null)
		{
			if (studentScript.gameObject.activeInHierarchy)
			{
				studentScript.gameObject.SetActive(false);
			}
			else
			{
				studentScript.gameObject.SetActive(true);
				if (studentScript.Club == ClubType.Council)
				{
					string str = string.Empty;
					if (studentScript.StudentID == 86)
					{
						str = "Strict";
					}
					else if (studentScript.StudentID == 87)
					{
						str = "Casual";
					}
					else if (studentScript.StudentID == 88)
					{
						str = "Grace";
					}
					else if (studentScript.StudentID == 89)
					{
						str = "Edgy";
					}
					studentScript.CharacterAnimation["f02_faceCouncil" + str + "_00"].layer = 10;
					studentScript.CharacterAnimation.Play("f02_faceCouncil" + str + "_00");
				}
			}
		}
	}

	public void UpdateGrafitti()
	{
		this.ID = 1;
		while (this.ID < 6)
		{
			if (!this.NoBully[this.ID])
			{
				this.Graffiti[this.ID].SetActive(true);
			}
			this.ID++;
		}
	}

	public void UpdateSleuths()
	{
		this.SleuthPhase++;
		this.ID = 56;
		while (this.ID < 61)
		{
			if (this.Students[this.ID] != null)
			{
				if (this.SleuthPhase < 3)
				{
					this.Students[this.ID].SleuthTarget = this.SleuthDestinations[this.ID - 55];
					this.Students[this.ID].Pathfinding.target = this.Students[this.ID].SleuthTarget;
					this.Students[this.ID].CurrentDestination = this.Students[this.ID].SleuthTarget;
				}
				else if (this.SleuthPhase == 3)
				{
					this.Students[this.ID].GetSleuthTarget();
				}
				else if (this.SleuthPhase == 4)
				{
					this.Students[this.ID].SleuthTarget = this.Clubs.List[this.ID];
					this.Students[this.ID].Pathfinding.target = this.Students[this.ID].SleuthTarget;
					this.Students[this.ID].CurrentDestination = this.Students[this.ID].SleuthTarget;
				}
				this.Students[this.ID].SmartPhone.SetActive(true);
				this.Students[this.ID].SpeechLines.Stop();
			}
			this.ID++;
		}
	}
}
