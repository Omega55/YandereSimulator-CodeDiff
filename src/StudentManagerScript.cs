using System;
using System.Collections;
using UnityEngine;

public class StudentManagerScript : MonoBehaviour
{
	private PortraitChanScript NewPortraitChan;

	private GameObject NewStudent;

	public StudentScript[] Students;

	public SelectiveGrayscale SmartphoneSelectiveGreyscale;

	public PickpocketMinigameScript PickpocketMinigame;

	public PopulationManagerScript PopulationManager;

	public SelectiveGrayscale HandSelectiveGreyscale;

	public SkinnedMeshRenderer FemaleShowerCurtain;

	public CleaningManagerScript CleaningManager;

	public StolenPhoneSpotScript StolenPhoneSpot;

	public SelectiveGrayscale SelectiveGreyscale;

	public CombatMinigameScript CombatMinigame;

	public DatingMinigameScript DatingMinigame;

	public TextureManagerScript TextureManager;

	public TutorialWindowScript TutorialWindow;

	public QualityManagerScript QualityManager;

	public ComputerGamesScript ComputerGames;

	public EmergencyExitScript EmergencyExit;

	public MemorialSceneScript MemorialScene;

	public TranqDetectorScript TranqDetector;

	public WitnessCameraScript WitnessCamera;

	public ConvoManagerScript ConvoManager;

	public TallLockerScript CommunalLocker;

	public CabinetDoorScript CabinetDoor;

	public LightSwitchScript LightSwitch;

	public LoveManagerScript LoveManager;

	public MiyukiEnemyScript MiyukiEnemy;

	public TaskManagerScript TaskManager;

	public StudentScript BloodReporter;

	public HeadmasterScript Headmaster;

	public NoteWindowScript NoteWindow;

	public ReputationScript Reputation;

	public WeaponScript FragileWeapon;

	public AudioSource PracticeVocals;

	public AudioSource PracticeMusic;

	public ContainerScript Container;

	public RedStringScript RedString;

	public RingEventScript RingEvent;

	public RivalPoseScript RivalPose;

	public GazerEyesScript Shinigami;

	public HologramScript Holograms;

	public RobotArmScript RobotArms;

	public PickUpScript Flashlight;

	public FountainScript Fountain;

	public PoseModeScript PoseMode;

	public TrashCanScript TrashCan;

	public Collider LockerRoomArea;

	public StudentScript Reporter;

	public DoorScript GamingDoor;

	public GhostScript GhostChan;

	public YandereScript Yandere;

	public ListScript MeetSpots;

	public PoliceScript Police;

	public DoorScript ShedDoor;

	public UILabel ErrorLabel;

	public RestScript Rest;

	public TagScript Tag;

	public Collider EastBathroomArea;

	public Collider WestBathroomArea;

	public Collider IncineratorArea;

	public Collider HeadmasterArea;

	public Collider NEStairs;

	public Collider NWStairs;

	public Collider SEStairs;

	public Collider SWStairs;

	public DoorScript AltFemaleVomitDoor;

	public DoorScript FemaleVomitDoor;

	public CounselorDoorScript[] CounselorDoor;

	public ParticleSystem AltFemaleDrownSplashes;

	public ParticleSystem FemaleDrownSplashes;

	public OfferHelpScript FragileOfferHelp;

	public OfferHelpScript OfferHelp;

	public Transform AltFemaleVomitSpot;

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

	public Collider[] Blood;

	public Collider[] Limbs;

	public Transform[] TeacherGuardLocation;

	public Transform[] CorpseGuardLocation;

	public Transform[] BloodGuardLocation;

	public Transform[] SleuthDestinations;

	public Transform[] GardeningPatrols;

	public Transform[] MartialArtsSpots;

	public Transform[] LockerPositions;

	public Transform[] BackstageSpots;

	public Transform[] SpawnPositions;

	public Transform[] GraffitiSpots;

	public Transform[] PracticeSpots;

	public Transform[] SunbatheSpots;

	public Transform[] MeetingSpots;

	public Transform[] PinDownSpots;

	public Transform[] ShockedSpots;

	public Transform[] MiyukiSpots;

	public Transform[] SocialSeats;

	public Transform[] SocialSpots;

	public Transform[] SupplySpots;

	public Transform[] BullySpots;

	public Transform[] DramaSpots;

	public Transform[] MournSpots;

	public Transform[] ClubZones;

	public Transform[] SulkSpots;

	public Transform[] FleeSpots;

	public Transform[] Plates;

	public Transform[] FemaleVomitSpots;

	public Transform[] MaleVomitSpots;

	public Transform[] FemaleWashSpots;

	public Transform[] MaleWashSpots;

	public DoorScript[] FemaleToiletDoors;

	public DoorScript[] MaleToiletDoors;

	public DrinkingFountainScript[] DrinkingFountains;

	public bool[] SeatsTaken11;

	public bool[] SeatsTaken12;

	public bool[] SeatsTaken21;

	public bool[] SeatsTaken22;

	public bool[] SeatsTaken31;

	public bool[] SeatsTaken32;

	public bool[] NoBully;

	public Quaternion[] OriginalClubRotations;

	public Vector3[] OriginalClubPositions;

	public Collider RivalDeskCollider;

	public Transform FollowerLookAtTarget;

	public Transform SuitorConfessionSpot;

	public Transform RivalConfessionSpot;

	public Transform OriginalLyricsSpot;

	public Transform FragileSlaveSpot;

	public Transform FemaleCoupleSpot;

	public Transform YandereStripSpot;

	public Transform FemaleBatheSpot;

	public Transform FemaleStalkSpot;

	public Transform FemaleStripSpot;

	public Transform FemaleVomitSpot;

	public Transform MedicineCabinet;

	public Transform ConfessionSpot;

	public Transform CorpseLocation;

	public Transform FemaleRestSpot;

	public Transform FemaleWashSpot;

	public Transform MaleCoupleSpot;

	public Transform AirGuitarSpot;

	public Transform BloodLocation;

	public Transform FastBatheSpot;

	public Transform InfirmarySeat;

	public Transform MaleBatheSpot;

	public Transform MaleStalkSpot;

	public Transform MaleStripSpot;

	public Transform MaleVomitSpot;

	public Transform SacrificeSpot;

	public Transform WeaponBoxSpot;

	public Transform FountainSpot;

	public Transform MaleWashSpot;

	public Transform SenpaiLocker;

	public Transform SuitorLocker;

	public Transform MaleRestSpot;

	public Transform RomanceSpot;

	public Transform BrokenSpot;

	public Transform BullyGroup;

	public Transform EdgeOfGrid;

	public Transform GoAwaySpot;

	public Transform LyricsSpot;

	public Transform MainCamera;

	public Transform SuitorSpot;

	public Transform ToolTarget;

	public Transform MiyukiCat;

	public Transform ShameSpot;

	public Transform SlaveSpot;

	public Transform Papers;

	public Transform Exit;

	public GameObject LovestruckCamera;

	public GameObject DelinquentRadio;

	public GameObject GardenBlockade;

	public GameObject PortraitChan;

	public GameObject RandomPatrol;

	public GameObject ChaseCamera;

	public GameObject EmptyObject;

	public GameObject PortraitKun;

	public GameObject StudentChan;

	public GameObject StudentKun;

	public GameObject RivalChan;

	public GameObject Medicine;

	public GameObject DrumSet;

	public GameObject Flowers;

	public GameObject Portal;

	public float[] SpawnTimes;

	public int LowDetailThreshold;

	public int FarAnimThreshold;

	public int MartialArtsPhase;

	public int StudentsSpawned;

	public int SedatedStudents;

	public int StudentsTotal = 13;

	public int TeachersTotal = 6;

	public int NPCsSpawned;

	public int SleuthPhase = 1;

	public int DramaPhase = 1;

	public int NPCsTotal;

	public int Witnesses;

	public int PinPhase;

	public int Bullies;

	public int Speaker = 21;

	public int Frame;

	public int GymTeacherID = 100;

	public int ObstacleID = 6;

	public int CurrentID;

	public int SuitorID = 13;

	public int VictimID;

	public int NurseID = 93;

	public int RivalID = 7;

	public int SpawnID;

	public int ID;

	public bool ReactedToGameLeader;

	public bool MurderTakingPlace;

	public bool TakingPortraits;

	public bool TeachersSpawned;

	public bool DisableFarAnims;

	public bool MetalDetectors;

	public bool YandereVisible;

	public bool NoClubMeeting;

	public bool UpdatedBlood;

	public bool YandereDying;

	public bool FirstUpdate;

	public bool MissionMode;

	public bool OpenCurtain;

	public bool PinningDown;

	public bool RoofFenceUp;

	public bool YandereLate;

	public bool ForceSpawn;

	public bool NoGravity;

	public bool Randomize;

	public bool LoveSick;

	public bool NoSpeech;

	public bool Meeting;

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

	public float Atmosphere;

	public float OpenValue = 100f;

	public float MeetingTimer;

	public float PinDownTimer;

	public float ChangeTimer;

	public float SleuthTimer;

	public float DramaTimer;

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

	public Mesh OpenChipBag;

	public Renderer[] Trees;

	public bool SeatOccupied;

	public int Class = 1;

	public int Thins;

	public int Seriouses;

	public int Rounds;

	public int Sads;

	public int Means;

	public int Smugs;

	public int Gentles;

	public int Rival1s;

	public DoorScript[] Doors;

	public int DoorID;

	private void Start()
	{
		this.LoveSick = GameGlobals.LoveSick;
		this.MetalDetectors = SchoolGlobals.HighSecurity;
		this.RoofFenceUp = SchoolGlobals.RoofFence;
		if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
		{
			this.SpawnPositions[51].position = new Vector3(3f, 0f, -95f);
		}
		if (HomeGlobals.LateForSchool)
		{
			HomeGlobals.LateForSchool = false;
			this.YandereLate = true;
			Debug.Log("Yandere-chan is late for school!");
		}
		if (!this.YandereLate && StudentGlobals.MemorialStudents > 0)
		{
			this.Yandere.HUD.alpha = 0f;
			this.Yandere.HeartCamera.enabled = false;
		}
		if (GameGlobals.Profile == 0)
		{
			GameGlobals.Profile = 1;
			PlayerGlobals.Money = 10f;
		}
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
			if (MissionModeGlobals.MissionMode)
			{
				StudentGlobals.FemaleUniform = 5;
				StudentGlobals.MaleUniform = 5;
			}
			this.SetAtmosphere();
			GameGlobals.Paranormal = false;
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
					this.LockerPositions[this.ID].transform.position = this.Lockers.List[this.ID].position + this.Lockers.List[this.ID].forward * 0.5f;
					this.LockerPositions[this.ID].LookAt(this.Lockers.List[this.ID].position);
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
			if (this.YandereLate)
			{
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
		if (!this.TakingPortraits)
		{
			this.NEStairs = GameObject.Find("NEStairs").GetComponent<Collider>();
			this.NWStairs = GameObject.Find("NWStairs").GetComponent<Collider>();
			this.SEStairs = GameObject.Find("SEStairs").GetComponent<Collider>();
			this.SWStairs = GameObject.Find("SWStairs").GetComponent<Collider>();
		}
	}

	public void SetAtmosphere()
	{
		if (GameGlobals.LoveSick)
		{
			SchoolGlobals.SchoolAtmosphereSet = true;
			SchoolGlobals.SchoolAtmosphere = 0f;
		}
		if (!MissionModeGlobals.MissionMode)
		{
			if (!SchoolGlobals.SchoolAtmosphereSet)
			{
				SchoolGlobals.SchoolAtmosphereSet = true;
				SchoolGlobals.SchoolAtmosphere = 1f;
			}
			this.Atmosphere = SchoolGlobals.SchoolAtmosphere;
		}
		Vignetting[] components = Camera.main.GetComponents<Vignetting>();
		float num = 1f - this.Atmosphere;
		if (!this.TakingPortraits)
		{
			this.SelectiveGreyscale.desaturation = num;
			if (this.HandSelectiveGreyscale != null)
			{
				this.HandSelectiveGreyscale.desaturation = num;
				this.SmartphoneSelectiveGreyscale.desaturation = num;
			}
			components[2].intensity = num * 5f;
			components[2].blur = num;
			components[2].chromaticAberration = num * 5f;
			float num2 = 1f - num;
			RenderSettings.fogColor = new Color(num2, num2, num2, 1f);
			Camera.main.backgroundColor = new Color(num2, num2, num2, 1f);
			RenderSettings.fogDensity = num * 0.1f;
		}
		if (this.Yandere != null)
		{
			this.Yandere.GreyTarget = num;
		}
	}

	private void Update()
	{
		if (!this.TakingPortraits)
		{
			if (!this.Yandere.ShoulderCamera.Counselor.Interrogating)
			{
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}
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
				this.UpdateStudents(0);
				if (!OptionGlobals.RimLight)
				{
					this.QualityManager.RimLight();
				}
				this.ID = 26;
				while (this.ID < 31)
				{
					if (this.Students[this.ID] != null)
					{
						this.OriginalClubPositions[this.ID - 25] = this.Clubs.List[this.ID].position;
						this.OriginalClubRotations[this.ID - 25] = this.Clubs.List[this.ID].rotation;
					}
					this.ID++;
				}
				if (!this.TakingPortraits)
				{
					this.TaskManager.UpdateTaskStatus();
				}
				this.Yandere.GloveAttacher.newRenderer.enabled = false;
				this.UpdateAprons();
				if (PlayerPrefs.GetInt("LoadingSave") == 1)
				{
					this.Load();
					PlayerPrefs.SetInt("LoadingSave", 0);
				}
				if (!this.YandereLate && StudentGlobals.MemorialStudents > 0)
				{
					this.Yandere.HUD.alpha = 0f;
					this.Yandere.RPGCamera.transform.position = new Vector3(38f, 4.125f, 68.825f);
					this.Yandere.RPGCamera.transform.eulerAngles = new Vector3(22.5f, 67.5f, 0f);
					this.Yandere.RPGCamera.transform.Translate(Vector3.forward, Space.Self);
					this.Yandere.RPGCamera.enabled = false;
					this.Yandere.HeartCamera.enabled = false;
					this.Yandere.CanMove = false;
					this.Clock.StopTime = true;
					this.StopMoving();
					this.MemorialScene.gameObject.SetActive(true);
					this.MemorialScene.enabled = true;
				}
				this.ID = 1;
				while (this.ID < 90)
				{
					if (this.Students[this.ID] != null)
					{
						this.Students[this.ID].ShoeRemoval.Start();
					}
					this.ID++;
				}
			}
			if ((double)this.Clock.HourTime > 16.9)
			{
				this.CheckMusic();
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
				if (studentScript != null && (!studentScript.Alive || studentScript.Attacked || studentScript.Dying || (studentScript.Fleeing && !studentScript.PinningDown)))
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
				if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
				{
					this.Yandere.CanMove = true;
				}
				this.PinningDown = false;
				this.PinDownTimer = 0f;
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
							studentScript2.SmartPhone.SetActive(false);
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
				if (!this.Yandere.ShoulderCamera.Noticed && !this.Yandere.ShoulderCamera.HeartbrokenCamera.activeInHierarchy)
				{
					this.PinDownTimer += Time.deltaTime;
					if (this.PinDownTimer > 10f || (this.WitnessList[1].DistanceToDestination < 1f && this.WitnessList[2].DistanceToDestination < 1f && this.WitnessList[3].DistanceToDestination < 1f && this.WitnessList[4].DistanceToDestination < 1f))
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
		if (this.Meeting)
		{
			this.UpdateMeeting();
		}
		if (Input.GetKeyDown("space"))
		{
			this.DetermineVictim();
		}
		if (this.Police != null && (this.Police.BloodParent.childCount > 0 || this.Police.LimbParent.childCount > 0 || this.Yandere.WeaponManager.MisplacedWeapons > 0))
		{
			this.CurrentID++;
			if (this.CurrentID > 97)
			{
				this.UpdateBlood();
				this.CurrentID = 1;
			}
			if (this.Students[this.CurrentID] == null)
			{
				this.CurrentID++;
			}
			else if (!this.Students[this.CurrentID].gameObject.activeInHierarchy)
			{
				this.CurrentID++;
			}
		}
		if (this.OpenCurtain)
		{
			this.OpenValue = Mathf.Lerp(this.OpenValue, 100f, Time.deltaTime * 10f);
			if (this.OpenValue > 99f)
			{
				this.OpenCurtain = false;
			}
			this.FemaleShowerCurtain.SetBlendShapeWeight(0, this.OpenValue);
		}
		this.YandereVisible = false;
	}

	public void SpawnStudent(int spawnID)
	{
		bool flag = false;
		if (spawnID > 9 && spawnID < 21)
		{
			flag = true;
		}
		if (!flag && this.Students[spawnID] == null && !StudentGlobals.GetStudentDead(spawnID) && !StudentGlobals.GetStudentKidnapped(spawnID) && !StudentGlobals.GetStudentArrested(spawnID) && !StudentGlobals.GetStudentExpelled(spawnID) && StudentGlobals.GetStudentReputation(spawnID) > -100)
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
			studentScript.ChaseSelectiveGrayscale.desaturation = 1f - SchoolGlobals.SchoolAtmosphere;
			studentScript.Cosmetic.TextureManager = this.TextureManager;
			studentScript.WitnessCamera = this.WitnessCamera;
			studentScript.StudentManager = this;
			studentScript.StudentID = spawnID;
			studentScript.JSON = this.JSON;
			if (studentScript.Miyuki != null)
			{
				studentScript.Miyuki.Enemy = this.MiyukiCat;
			}
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
				this.RedString.transform.parent = studentScript.LeftPinky;
				this.RedString.transform.localPosition = new Vector3(0f, 0f, 0f);
			}
			if (spawnID == 1)
			{
				this.RedString.Target = studentScript.LeftPinky;
			}
			this.OccupySeat();
		}
		this.NPCsSpawned++;
		this.ForceSpawn = false;
		if (this.Students[10] != null || this.Students[11] != null)
		{
			UnityEngine.Object.Destroy(this.Students[10].gameObject);
			UnityEngine.Object.Destroy(this.Students[11].gameObject);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public void UpdateStudents(int SpecificStudent = 0)
	{
		this.ID = 2;
		while (this.ID < this.Students.Length)
		{
			bool flag = false;
			if (SpecificStudent != 0)
			{
				this.ID = SpecificStudent;
				flag = true;
			}
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
							else if (this.Yandere.SpiderGrow)
							{
								if (!studentScript.Cosmetic.Empty)
								{
									studentScript.Prompt.Label[0].text = "     Send Husk";
								}
								else
								{
									studentScript.Prompt.Label[0].text = "     Talk";
								}
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
								if (this.Yandere.PickUp != null && !studentScript.Following)
								{
									if (this.Yandere.PickUp.Food > 0)
									{
										studentScript.Prompt.Label[0].text = "     Feed";
										studentScript.Prompt.HideButton[0] = false;
										studentScript.Prompt.HideButton[2] = true;
									}
									else if (this.Yandere.PickUp.Salty)
									{
										studentScript.Prompt.Label[0].text = "     Give Snack";
										studentScript.Prompt.HideButton[0] = false;
										studentScript.Prompt.HideButton[2] = true;
									}
									else if (this.Yandere.PickUp.StuckBoxCutter != null)
									{
										studentScript.Prompt.Label[0].text = "     Ask For Help";
										studentScript.Prompt.HideButton[0] = false;
										studentScript.Prompt.HideButton[2] = true;
									}
								}
							}
							if (this.Yandere.Armed)
							{
								studentScript.Prompt.HideButton[0] = true;
								studentScript.Prompt.Attack = true;
								studentScript.Prompt.MinimumDistanceSqr = 1f;
								studentScript.Prompt.MinimumDistance = 1f;
							}
							else
							{
								studentScript.Prompt.HideButton[2] = true;
								studentScript.Prompt.MinimumDistanceSqr = 2f;
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
						else if (!studentScript.FragileSlave)
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
				if (GameGlobals.EmptyDemon)
				{
					studentScript.Prompt.HideButton[0] = false;
				}
			}
			this.ID++;
			if (flag)
			{
				this.ID = this.Students.Length;
			}
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
		if (this.Clock.LateStudent)
		{
			this.Clock.ActivateLateStudent();
		}
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				if (studentScript.WitnessedBloodPool && !studentScript.WitnessedMurder && !studentScript.WitnessedCorpse)
				{
					studentScript.Fleeing = false;
					studentScript.Alarmed = false;
					studentScript.AlarmTimer = 0f;
					studentScript.ReportPhase = 0;
					studentScript.WitnessedBloodPool = false;
				}
				if (studentScript.Alive && !studentScript.Slave && !studentScript.Tranquil && !studentScript.Fleeing && studentScript.enabled && studentScript.gameObject.activeInHierarchy)
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
						studentScript.Pathfinding.speed = 0f;
						studentScript.ClubActivityPhase = 0;
						studentScript.ClubTimer = 0f;
						studentScript.Pestered = 0;
						studentScript.Distracting = false;
						studentScript.Distracted = false;
						studentScript.Ignoring = false;
						studentScript.Pushable = false;
						studentScript.Vomiting = false;
						studentScript.Private = false;
						studentScript.Sedated = false;
						studentScript.Emetic = false;
						studentScript.Hurry = false;
						studentScript.Safe = false;
						studentScript.CanTalk = true;
						studentScript.Routine = true;
						if (studentScript.Wet)
						{
							this.CommunalLocker.Student = null;
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
						if (studentScript.Schoolwear != 1 && !studentScript.BeenSplashed)
						{
							studentScript.Schoolwear = 1;
							studentScript.ChangeSchoolwear();
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
							if (!studentScript.Cosmetic.Empty)
							{
								studentScript.Cosmetic.MaleHair[studentScript.Cosmetic.Hairstyle].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 0f);
							}
						}
						if (studentScript.MyPlate != null && studentScript.MyPlate.transform.parent == studentScript.RightHand)
						{
							studentScript.MyPlate.transform.parent = null;
							studentScript.MyPlate.transform.position = studentScript.OriginalPlatePosition;
							studentScript.MyPlate.transform.rotation = studentScript.OriginalPlateRotation;
							studentScript.IdleAnim = studentScript.OriginalIdleAnim;
							studentScript.WalkAnim = studentScript.OriginalWalkAnim;
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
			}
			this.ID++;
		}
		this.UpdateStudents(0);
		Physics.SyncTransforms();
	}

	public void SkipTo8()
	{
		while (this.NPCsSpawned < this.NPCsTotal)
		{
			this.SpawnStudent(this.SpawnID);
			this.SpawnID++;
		}
		int num = 0;
		int num2 = 0;
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
				bool flag = false;
				if (this.MemorialScene.enabled && studentScript.Teacher)
				{
					flag = true;
					studentScript.Teacher = false;
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
					studentScript.Pathfinding.speed = 1f;
					studentScript.ClubActivityPhase = 0;
					studentScript.Distracted = false;
					studentScript.Spawned = true;
					studentScript.Routine = true;
					studentScript.Safe = false;
					studentScript.SprintAnim = studentScript.OriginalSprintAnim;
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
				if (this.MemorialScene.enabled)
				{
					if (flag)
					{
						studentScript.Teacher = true;
					}
					if (studentScript.Persona == PersonaType.PhoneAddict)
					{
						studentScript.SmartPhone.SetActive(true);
					}
					if (studentScript.Actions[studentScript.Phase] == StudentActionType.Graffiti && !this.Bully)
					{
						ScheduleBlock scheduleBlock = studentScript.ScheduleBlocks[2];
						scheduleBlock.destination = "Patrol";
						scheduleBlock.action = "Patrol";
						studentScript.GetDestinations();
					}
					studentScript.SpeechLines.Stop();
					studentScript.transform.position = new Vector3(20f + (float)num * 1.1f, 0f, (float)(82 - num2 * 5));
					num2++;
					if (num2 > 4)
					{
						num++;
						num2 = 0;
					}
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
					else if (this.ID > 1 && studentScript.CharacterAnimation != null)
					{
						studentScript.CharacterAnimation.CrossFade(studentScript.IdleAnim);
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
				if (studentScript.Slave && this.Police.DayOver)
				{
					Debug.Log("A mind-broken slave committed suicide.");
					studentScript.Broken.Subtitle.text = string.Empty;
					studentScript.Broken.Done = true;
					UnityEngine.Object.Destroy(studentScript.Broken);
					studentScript.BecomeRagdoll();
					studentScript.Slave = false;
					studentScript.Suicide = true;
					studentScript.DeathType = DeathType.Mystery;
					StudentGlobals.SetStudentSlave(studentScript.StudentID);
				}
			}
			this.ID++;
		}
	}

	public void ComeBack()
	{
		this.Stop = false;
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				if (!studentScript.Dying && !studentScript.Replaced && !StudentGlobals.GetStudentExpelled(this.ID))
				{
					studentScript.gameObject.SetActive(true);
					studentScript.Pathfinding.canSearch = true;
					studentScript.Pathfinding.canMove = true;
					studentScript.Pathfinding.speed = 1f;
					studentScript.Stop = false;
				}
				if (studentScript.Teacher)
				{
					studentScript.CurrentDestination = studentScript.Destinations[studentScript.Phase];
					studentScript.Pathfinding.target = studentScript.Destinations[studentScript.Phase];
					studentScript.Alarmed = false;
					studentScript.Reacted = false;
					studentScript.Witness = false;
					studentScript.Routine = true;
					studentScript.AlarmTimer = 0f;
					studentScript.Concern = 0;
				}
				if (studentScript.Club == ClubType.Council)
				{
					studentScript.Teacher = false;
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

	public void Unstop()
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

	public void LowerBloodPosition()
	{
		if (this.BloodLocation.position.y < 4f)
		{
			this.BloodLocation.position = new Vector3(this.BloodLocation.position.x, 0f, this.BloodLocation.position.z);
		}
		else if (this.BloodLocation.position.y < 8f)
		{
			this.BloodLocation.position = new Vector3(this.BloodLocation.position.x, 4f, this.BloodLocation.position.z);
		}
		else if (this.BloodLocation.position.y < 12f)
		{
			this.BloodLocation.position = new Vector3(this.BloodLocation.position.x, 8f, this.BloodLocation.position.z);
		}
		else
		{
			this.BloodLocation.position = new Vector3(this.BloodLocation.position.x, 12f, this.BloodLocation.position.z);
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
				if (studentScript != null && (!studentScript.Alive || studentScript.Attacked || studentScript.Fleeing || studentScript.Dying))
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
			if (studentScript != null)
			{
				if (this.ID != 36 || TaskGlobals.GetTaskStatus(36) != 3)
				{
					if (!studentScript.Teacher && !studentScript.Slave && studentScript.Club != ClubType.Bully && studentScript.Club != ClubType.Council && studentScript.Club != ClubType.Photography && studentScript.Club != ClubType.Delinquent && (float)StudentGlobals.GetStudentReputation(this.ID) < this.LowestRep)
					{
						this.LowestRep = (float)StudentGlobals.GetStudentReputation(this.ID);
						this.VictimID = this.ID;
						this.Bully = true;
					}
				}
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
			if (studentScript2.Male)
			{
				studentScript2.ChemistScanner.MyRenderer.materials[1].mainTexture = studentScript2.ChemistScanner.SadEyes;
				studentScript2.ChemistScanner.enabled = false;
			}
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
			if (studentScript != null && studentScript.SecurityCamera != null && studentScript.Alive)
			{
				Debug.Log("Enabling security camera on this character's head.");
				studentScript.SecurityCamera.SetActive(true);
			}
			this.ID++;
		}
	}

	public void DisableEveryone()
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.gameObject.SetActive(false);
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
				this.UpdateOneAnimLayer(DisableID);
				this.Students[DisableID].ReadPhase = 0;
			}
		}
	}

	public void UpdateOneAnimLayer(int DisableID)
	{
		this.Students[DisableID].UpdateAnimLayers();
		this.Students[DisableID].ReadPhase = 0;
	}

	public void UpdateAllAnimLayers()
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.UpdateAnimLayers();
				studentScript.ReadPhase = 0;
			}
			this.ID++;
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

	public void UpdateAllBentos()
	{
		this.ID = 1;
		while (this.ID < this.Students.Length)
		{
			StudentScript studentScript = this.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.Bento.GetComponent<GenericBentoScript>().Prompt.Yandere = this.Yandere;
				studentScript.Bento.GetComponent<GenericBentoScript>().UpdatePrompts();
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
			if (this.Students[this.ID] != null && !this.Students[this.ID].Slave && !this.Students[this.ID].Following)
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

	public void UpdateDrama()
	{
		if (!this.MemorialScene.gameObject.activeInHierarchy)
		{
			this.DramaPhase++;
			this.ID = 26;
			while (this.ID < 31)
			{
				if (this.Students[this.ID] != null)
				{
					if (this.DramaPhase == 1)
					{
						this.Clubs.List[this.ID].position = this.OriginalClubPositions[this.ID - 25];
						this.Clubs.List[this.ID].rotation = this.OriginalClubRotations[this.ID - 25];
						this.Students[this.ID].ClubAnim = this.Students[this.ID].OriginalClubAnim;
					}
					else if (this.DramaPhase == 2)
					{
						this.Clubs.List[this.ID].position = this.DramaSpots[this.ID - 25].position;
						this.Clubs.List[this.ID].rotation = this.DramaSpots[this.ID - 25].rotation;
						if (this.ID == 26)
						{
							this.Students[this.ID].ClubAnim = this.Students[this.ID].ActAnim;
						}
						else if (this.ID == 27)
						{
							this.Students[this.ID].ClubAnim = this.Students[this.ID].ThinkAnim;
						}
						else if (this.ID == 28)
						{
							this.Students[this.ID].ClubAnim = this.Students[this.ID].ThinkAnim;
						}
						else if (this.ID == 29)
						{
							this.Students[this.ID].ClubAnim = this.Students[this.ID].ActAnim;
						}
						else if (this.ID == 30)
						{
							this.Students[this.ID].ClubAnim = this.Students[this.ID].ThinkAnim;
						}
					}
					else if (this.DramaPhase == 3)
					{
						this.Clubs.List[this.ID].position = this.BackstageSpots[this.ID - 25].position;
						this.Clubs.List[this.ID].rotation = this.BackstageSpots[this.ID - 25].rotation;
					}
					else if (this.DramaPhase == 4)
					{
						this.DramaPhase = 1;
						this.UpdateDrama();
					}
					this.Students[this.ID].DistanceToDestination = 100f;
					this.Students[this.ID].SmartPhone.SetActive(false);
					this.Students[this.ID].SpeechLines.Stop();
				}
				this.ID++;
			}
		}
	}

	public void UpdateMartialArts()
	{
		this.ConvoManager.Confirmed = false;
		this.MartialArtsPhase++;
		this.ID = 46;
		while (this.ID < 51)
		{
			if (this.Students[this.ID] != null)
			{
				if (this.MartialArtsPhase == 1)
				{
					this.Clubs.List[this.ID].position = this.MartialArtsSpots[this.ID - 45].position;
					this.Clubs.List[this.ID].rotation = this.MartialArtsSpots[this.ID - 45].rotation;
				}
				else if (this.MartialArtsPhase == 2)
				{
					this.Clubs.List[this.ID].position = this.MartialArtsSpots[this.ID - 40].position;
					this.Clubs.List[this.ID].rotation = this.MartialArtsSpots[this.ID - 40].rotation;
				}
				else if (this.MartialArtsPhase == 3)
				{
					this.Clubs.List[this.ID].position = this.MartialArtsSpots[this.ID - 35].position;
					this.Clubs.List[this.ID].rotation = this.MartialArtsSpots[this.ID - 35].rotation;
				}
				else if (this.MartialArtsPhase == 4)
				{
					this.MartialArtsPhase = 0;
					this.UpdateMartialArts();
				}
				this.Students[this.ID].DistanceToDestination = 100f;
				this.Students[this.ID].SmartPhone.SetActive(false);
				this.Students[this.ID].SpeechLines.Stop();
			}
			this.ID++;
		}
	}

	public void UpdateMeeting()
	{
		this.MeetingTimer += Time.deltaTime;
		if (this.MeetingTimer > 5f)
		{
			this.Speaker += 5;
			if (this.Speaker == 91)
			{
				this.Speaker = 21;
			}
			else if (this.Speaker == 76)
			{
				this.Speaker = 86;
			}
			else if (this.Speaker == 36)
			{
				this.Speaker = 41;
			}
			this.MeetingTimer = 0f;
		}
	}

	public void CheckMusic()
	{
		int num = 0;
		this.ID = 51;
		while (this.ID < 56)
		{
			if (this.Students[this.ID] != null && this.Students[this.ID].Routine && this.Students[this.ID].DistanceToDestination < 0.1f)
			{
				num++;
			}
			this.ID++;
		}
		if (num == 5)
		{
			this.PracticeVocals.pitch = Time.timeScale;
			this.PracticeMusic.pitch = Time.timeScale;
			if (!this.PracticeMusic.isPlaying)
			{
				this.PracticeVocals.Play();
				this.PracticeMusic.Play();
			}
		}
		else
		{
			this.PracticeVocals.Stop();
			this.PracticeMusic.Stop();
		}
	}

	public void UpdateAprons()
	{
		this.ID = 21;
		while (this.ID < 26)
		{
			if (this.Students[this.ID] != null && this.Students[this.ID].ClubMemberID > 0 && this.Students[this.ID].ApronAttacher != null && this.Students[this.ID].ApronAttacher.newRenderer != null)
			{
				this.Students[this.ID].ApronAttacher.newRenderer.material.mainTexture = this.Students[this.ID].Cosmetic.ApronTextures[this.Students[this.ID].ClubMemberID];
			}
			this.ID++;
		}
	}

	public void PreventAlarm()
	{
		this.ID = 1;
		while (this.ID < 101)
		{
			if (this.Students[this.ID] != null)
			{
				this.Students[this.ID].Alarm = 0f;
			}
			this.ID++;
		}
	}

	public void VolumeDown()
	{
		this.ID = 51;
		while (this.ID < 56)
		{
			if (this.Students[this.ID] != null && this.Students[this.ID].Instruments[this.Students[this.ID].ClubMemberID] != null)
			{
				this.Students[this.ID].Instruments[this.Students[this.ID].ClubMemberID].GetComponent<AudioSource>().volume = 0.2f;
			}
			this.ID++;
		}
	}

	public void VolumeUp()
	{
		this.ID = 51;
		while (this.ID < 56)
		{
			if (this.Students[this.ID] != null && this.Students[this.ID].Instruments[this.Students[this.ID].ClubMemberID] != null)
			{
				this.Students[this.ID].Instruments[this.Students[this.ID].ClubMemberID].GetComponent<AudioSource>().volume = 1f;
			}
			this.ID++;
		}
	}

	public void GetMaleVomitSpot(StudentScript VomitStudent)
	{
		if (VomitStudent.transform.position.y < 1f)
		{
			this.MaleVomitSpot = this.MaleVomitSpots[1];
			VomitStudent.VomitDoor = this.MaleToiletDoors[1];
		}
		else if (VomitStudent.transform.position.y < 5f)
		{
			this.MaleVomitSpot = this.MaleVomitSpots[2];
			VomitStudent.VomitDoor = this.MaleToiletDoors[2];
		}
		else
		{
			this.MaleVomitSpot = this.MaleVomitSpots[3];
			VomitStudent.VomitDoor = this.MaleToiletDoors[3];
		}
	}

	public void GetFemaleVomitSpot(StudentScript VomitStudent)
	{
		if (VomitStudent.transform.position.y < 1f)
		{
			this.FemaleVomitSpot = this.FemaleVomitSpots[1];
			VomitStudent.VomitDoor = this.FemaleToiletDoors[1];
		}
		else if (VomitStudent.transform.position.y < 5f)
		{
			this.FemaleVomitSpot = this.FemaleVomitSpots[2];
			VomitStudent.VomitDoor = this.FemaleToiletDoors[2];
		}
		else
		{
			this.FemaleVomitSpot = this.FemaleVomitSpots[3];
			VomitStudent.VomitDoor = this.FemaleToiletDoors[3];
		}
	}

	public void GetMaleWashSpot(StudentScript VomitStudent)
	{
		if (VomitStudent.transform.position.y < 1f)
		{
			this.MaleWashSpot = this.MaleWashSpots[1];
		}
		else if (VomitStudent.transform.position.y < 5f)
		{
			this.MaleWashSpot = this.MaleWashSpots[2];
		}
		else
		{
			this.MaleWashSpot = this.MaleWashSpots[3];
		}
	}

	public void GetFemaleWashSpot(StudentScript VomitStudent)
	{
		if (VomitStudent.transform.position.y < 1f)
		{
			this.FemaleWashSpot = this.FemaleWashSpots[1];
		}
		else if (VomitStudent.transform.position.y < 5f)
		{
			this.FemaleWashSpot = this.FemaleWashSpots[2];
		}
		else
		{
			this.FemaleWashSpot = this.FemaleWashSpots[3];
		}
	}

	public void GetNearestFountain(StudentScript Student)
	{
		DrinkingFountainScript drinkingFountainScript = this.DrinkingFountains[1];
		this.ID = 2;
		while (this.ID < 8)
		{
			if (Vector3.Distance(Student.transform.position, this.DrinkingFountains[this.ID].transform.position) < Vector3.Distance(Student.transform.position, drinkingFountainScript.transform.position) && !this.DrinkingFountains[this.ID].Occupied)
			{
				drinkingFountainScript = this.DrinkingFountains[this.ID];
			}
			this.ID++;
		}
		Student.DrinkingFountain = drinkingFountainScript;
		Student.DrinkingFountain.Occupied = true;
	}

	public void Save()
	{
		this.ID = 1;
		while (this.ID < 101)
		{
			if (this.Students[this.ID] != null)
			{
				this.Students[this.ID].SaveLoad.SaveData();
			}
			this.ID++;
		}
		int profile = GameGlobals.Profile;
		int @int = PlayerPrefs.GetInt("SaveSlot");
		foreach (DoorScript doorScript in this.Doors)
		{
			if (doorScript != null)
			{
				if (doorScript.Open)
				{
					PlayerPrefs.SetInt(string.Concat(new object[]
					{
						"Profile_",
						profile,
						"_Slot_",
						@int,
						"_Door",
						doorScript.DoorID,
						"_Open"
					}), 1);
				}
				else
				{
					PlayerPrefs.SetInt(string.Concat(new object[]
					{
						"Profile_",
						profile,
						"_Slot_",
						@int,
						"_Door",
						doorScript.DoorID,
						"_Open"
					}), 0);
				}
			}
		}
	}

	public void Load()
	{
		this.ID = 1;
		while (this.ID < 101)
		{
			if (this.Students[this.ID] != null)
			{
				this.Students[this.ID].SaveLoad.LoadData();
			}
			this.ID++;
		}
		int profile = GameGlobals.Profile;
		int @int = PlayerPrefs.GetInt("SaveSlot");
		this.Yandere.transform.position = new Vector3(PlayerPrefs.GetFloat(string.Concat(new object[]
		{
			"Profile_",
			profile,
			"_Slot_",
			@int,
			"_YanderePosX"
		})), PlayerPrefs.GetFloat(string.Concat(new object[]
		{
			"Profile_",
			profile,
			"_Slot_",
			@int,
			"_YanderePosY"
		})), PlayerPrefs.GetFloat(string.Concat(new object[]
		{
			"Profile_",
			profile,
			"_Slot_",
			@int,
			"_YanderePosZ"
		})));
		this.Yandere.transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat(string.Concat(new object[]
		{
			"Profile_",
			profile,
			"_Slot_",
			@int,
			"_YandereRotX"
		})), PlayerPrefs.GetFloat(string.Concat(new object[]
		{
			"Profile_",
			profile,
			"_Slot_",
			@int,
			"_YandereRotY"
		})), PlayerPrefs.GetFloat(string.Concat(new object[]
		{
			"Profile_",
			profile,
			"_Slot_",
			@int,
			"_YandereRotZ"
		})));
		this.Yandere.FixCamera();
		Physics.SyncTransforms();
		foreach (DoorScript doorScript in this.Doors)
		{
			if (doorScript != null)
			{
				if (PlayerPrefs.GetInt(string.Concat(new object[]
				{
					"Profile_",
					profile,
					"_Slot_",
					@int,
					"_Door",
					doorScript.DoorID,
					"_Open"
				})) == 1)
				{
					doorScript.Open = true;
					doorScript.OpenDoor();
				}
				else
				{
					doorScript.Open = false;
				}
			}
		}
	}

	public void UpdateBlood()
	{
		if (this.Police.BloodParent.childCount > 0)
		{
			this.ID = 0;
			IEnumerator enumerator = this.Police.BloodParent.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform transform = (Transform)obj;
					if (this.ID < 100)
					{
						this.Blood[this.ID] = transform.gameObject.GetComponent<Collider>();
						this.ID++;
					}
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
		}
		if (this.Police.BloodParent.childCount > 0 || this.Police.LimbParent.childCount > 0)
		{
			this.ID = 0;
			IEnumerator enumerator2 = this.Police.LimbParent.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object obj2 = enumerator2.Current;
					Transform transform2 = (Transform)obj2;
					if (this.ID < 100)
					{
						this.Limbs[this.ID] = transform2.gameObject.GetComponent<Collider>();
						this.ID++;
					}
				}
			}
			finally
			{
				IDisposable disposable2;
				if ((disposable2 = (enumerator2 as IDisposable)) != null)
				{
					disposable2.Dispose();
				}
			}
		}
	}

	public void CanAnyoneSeeYandere()
	{
		this.YandereVisible = false;
		foreach (StudentScript studentScript in this.Students)
		{
			if (studentScript != null && studentScript.CanSeeObject(studentScript.Yandere.gameObject, studentScript.Yandere.HeadPosition))
			{
				this.YandereVisible = true;
				break;
			}
		}
	}

	public void SetFaces(float alpha)
	{
		foreach (StudentScript studentScript in this.Students)
		{
			if (studentScript != null && studentScript.StudentID > 1)
			{
				studentScript.MyRenderer.materials[0].color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
				studentScript.MyRenderer.materials[1].color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
				studentScript.MyRenderer.materials[2].color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
				studentScript.Cosmetic.LeftEyeRenderer.material.color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
				studentScript.Cosmetic.RightEyeRenderer.material.color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
				studentScript.Cosmetic.HairRenderer.material.color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
			}
		}
	}
}
