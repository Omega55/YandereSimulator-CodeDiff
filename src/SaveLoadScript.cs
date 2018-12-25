using System;
using System.IO;
using Pathfinding;
using UnityEngine;

public class SaveLoadScript : MonoBehaviour
{
	public StudentScript Student;

	public string SerializedData;

	public string SaveFilePath;

	public int SaveProfile;

	public int SaveSlot;

	public RiggedAccessoryAttacher LabcoatAttacher;

	public RiggedAccessoryAttacher ApronAttacher;

	public ChemistScannerScript ChemistScanner;

	public DialogueWheelScript DialogueWheel;

	public RiggedAccessoryAttacher Attacher;

	public CharacterController MyController;

	public ClubManagerScript ClubManager;

	public ShoeRemovalScript ShoeRemoval;

	public LowPolyStudentScript LowPoly;

	public DynamicGridObstacle Obstacle;

	public Animation CharacterAnimation;

	public ReputationScript Reputation;

	public CountdownScript Countdown;

	public Projector LiquidProjector;

	public CosmeticScript Cosmetic;

	public Camera DramaticCamera;

	public ARMiyukiScript Miyuki;

	public RagdollScript Ragdoll;

	public PromptScript Prompt;

	public AIPath Pathfinding;

	public TalkingScript Talk;

	public ParticleSystem DelinquentSpeechLines;

	public ParticleSystem PepperSprayEffect;

	public ParticleSystem BloodFountain;

	public ParticleSystem VomitEmitter;

	public ParticleSystem SpeechLines;

	public ParticleSystem BullyDust;

	public ParticleSystem ChalkDust;

	public ParticleSystem Hearts;

	public SkinnedMeshRenderer MyRenderer;

	public Renderer SmartPhoneScreen;

	public Renderer BookRenderer;

	public Renderer Tears;

	public Transform WeaponBagParent;

	public Transform DefaultTarget;

	public Transform ItemParent;

	public Transform WitnessPOV;

	public Transform RightHand;

	public Transform LeftHand;

	public Transform MyLocker;

	public Transform RightEye;

	public Transform LeftEye;

	public Transform Eyes;

	public Transform Head;

	public Transform Hips;

	public Transform Neck;

	public SphereCollider HipCollider;

	public Collider RightHandCollider;

	public Collider LeftHandCollider;

	public Collider NotFaceCollider;

	public Collider FaceCollider;

	public GameObject BullyPhotoCollider;

	public GameObject WhiteQuestionMark;

	public GameObject MiyukiGameScreen;

	public GameObject RiggedAccessory;

	public GameObject SecurityCamera;

	public GameObject RightEmptyEye;

	public GameObject LeftEmptyEye;

	public GameObject AnimatedBook;

	public GameObject CameraFlash;

	public GameObject ChaseCamera;

	public GameObject PepperSpray;

	public GameObject BloodSpray;

	public GameObject Sketchbook;

	public GameObject SmartPhone;

	public GameObject OccultBook;

	public GameObject Paintbrush;

	public GameObject Character;

	public GameObject EventBook;

	public GameObject Handcuffs;

	public GameObject HealthBar;

	public GameObject OsanaHair;

	public GameObject WeaponBag;

	public GameObject CandyBar;

	public GameObject Earpiece;

	public GameObject Scrubber;

	public GameObject Armband;

	public GameObject BookBag;

	public GameObject Octodog;

	public GameObject Palette;

	public GameObject Eraser;

	public GameObject Pencil;

	public GameObject Bento;

	public GameObject Note;

	public GameObject Lid;

	public GameObject Pen;

	public ParticleSystem[] LiquidEmitters;

	public ParticleSystem[] SplashEmitters;

	public ParticleSystem[] FireEmitters;

	public AudioSource AirGuitar;

	public GameObject WateringCan;

	public GameObject Cigarette;

	public GameObject Lighter;

	public Transform LeftMiddleFinger;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform RightDrill;

	public Transform LeftDrill;

	public Transform Spine;

	public Collider PantyCollider;

	public Collider SkirtCollider;

	public GameObject[] InstrumentBag;

	public GameObject[] ElectroSteam;

	public GameObject[] ScienceProps;

	public GameObject[] CensorSteam;

	public GameObject[] Instruments;

	public GameObject[] Chopsticks;

	public GameObject[] Drumsticks;

	public GameObject[] Fingerfood;

	public Transform[] Skirt;

	public StudentManagerScript StudentManager;

	private void DetermineFilePath()
	{
		this.SaveProfile = GameGlobals.Profile;
		this.SaveSlot = PlayerPrefs.GetInt("SaveSlot");
		this.SaveFilePath = string.Concat(new object[]
		{
			Application.streamingAssetsPath,
			"/SaveData/Profile_",
			this.SaveProfile,
			"/Slot_",
			this.SaveSlot,
			"/Student_",
			this.Student.StudentID,
			"_Data.txt"
		});
	}

	public void SaveData()
	{
		this.DetermineFilePath();
		this.SerializedData = JsonUtility.ToJson(this.Student);
		File.WriteAllText(this.SaveFilePath, this.SerializedData);
		PlayerPrefs.SetFloat(string.Concat(new object[]
		{
			"Profile_",
			this.SaveProfile,
			"_Slot_",
			this.SaveSlot,
			"Student_",
			this.Student.StudentID,
			"_posX"
		}), base.transform.position.x);
		PlayerPrefs.SetFloat(string.Concat(new object[]
		{
			"Profile_",
			this.SaveProfile,
			"_Slot_",
			this.SaveSlot,
			"Student_",
			this.Student.StudentID,
			"_posY"
		}), base.transform.position.y);
		PlayerPrefs.SetFloat(string.Concat(new object[]
		{
			"Profile_",
			this.SaveProfile,
			"_Slot_",
			this.SaveSlot,
			"Student_",
			this.Student.StudentID,
			"_posZ"
		}), base.transform.position.z);
		PlayerPrefs.SetFloat(string.Concat(new object[]
		{
			"Profile_",
			this.SaveProfile,
			"_Slot_",
			this.SaveSlot,
			"Student_",
			this.Student.StudentID,
			"_rotX"
		}), base.transform.eulerAngles.x);
		PlayerPrefs.SetFloat(string.Concat(new object[]
		{
			"Profile_",
			this.SaveProfile,
			"_Slot_",
			this.SaveSlot,
			"Student_",
			this.Student.StudentID,
			"_rotY"
		}), base.transform.eulerAngles.y);
		PlayerPrefs.SetFloat(string.Concat(new object[]
		{
			"Profile_",
			this.SaveProfile,
			"_Slot_",
			this.SaveSlot,
			"Student_",
			this.Student.StudentID,
			"_rotZ"
		}), base.transform.eulerAngles.z);
	}

	public void LoadData()
	{
		this.DetermineFilePath();
		this.SaveReferences();
		if (File.Exists(this.SaveFilePath))
		{
			base.transform.position = new Vector3(PlayerPrefs.GetFloat(string.Concat(new object[]
			{
				"Profile_",
				this.SaveProfile,
				"_Slot_",
				this.SaveSlot,
				"Student_",
				this.Student.StudentID,
				"_posX"
			})), PlayerPrefs.GetFloat(string.Concat(new object[]
			{
				"Profile_",
				this.SaveProfile,
				"_Slot_",
				this.SaveSlot,
				"Student_",
				this.Student.StudentID,
				"_posY"
			})), PlayerPrefs.GetFloat(string.Concat(new object[]
			{
				"Profile_",
				this.SaveProfile,
				"_Slot_",
				this.SaveSlot,
				"Student_",
				this.Student.StudentID,
				"_posZ"
			})));
			base.transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat(string.Concat(new object[]
			{
				"Profile_",
				this.SaveProfile,
				"Slot_",
				this.SaveSlot,
				"Student_",
				this.Student.StudentID,
				"_rotX"
			})), PlayerPrefs.GetFloat(string.Concat(new object[]
			{
				"Profile_",
				this.SaveProfile,
				"Slot_",
				this.SaveSlot,
				"Student_",
				this.Student.StudentID,
				"_rotY"
			})), PlayerPrefs.GetFloat(string.Concat(new object[]
			{
				"Profile_",
				this.SaveProfile,
				"Slot_",
				this.SaveSlot,
				"Student_",
				this.Student.StudentID,
				"_rotZ"
			})));
			string json = File.ReadAllText(this.SaveFilePath);
			JsonUtility.FromJsonOverwrite(json, this.Student);
		}
		this.LoadReferences();
	}

	private void SaveReferences()
	{
		this.CharacterAnimation = this.Student.CharacterAnimation;
		this.LabcoatAttacher = this.Student.LabcoatAttacher;
		this.LiquidProjector = this.Student.LiquidProjector;
		this.ChemistScanner = this.Student.ChemistScanner;
		this.DramaticCamera = this.Student.DramaticCamera;
		this.ApronAttacher = this.Student.ApronAttacher;
		this.DialogueWheel = this.Student.DialogueWheel;
		this.MyController = this.Student.MyController;
		this.ClubManager = this.Student.ClubManager;
		this.Pathfinding = this.Student.Pathfinding;
		this.ShoeRemoval = this.Student.ShoeRemoval;
		this.Countdown = this.Student.Countdown;
		this.Attacher = this.Student.Attacher;
		this.Cosmetic = this.Student.Cosmetic;
		this.Obstacle = this.Student.Obstacle;
		this.LowPoly = this.Student.LowPoly;
		this.Ragdoll = this.Student.Ragdoll;
		this.Miyuki = this.Student.Miyuki;
		this.Prompt = this.Student.Prompt;
		this.Talk = this.Student.Talk;
		this.DelinquentSpeechLines = this.Student.DelinquentSpeechLines;
		this.PepperSprayEffect = this.Student.PepperSprayEffect;
		this.BloodFountain = this.Student.BloodFountain;
		this.VomitEmitter = this.Student.VomitEmitter;
		this.SpeechLines = this.Student.SpeechLines;
		this.BullyDust = this.Student.BullyDust;
		this.ChalkDust = this.Student.ChalkDust;
		this.Hearts = this.Student.Hearts;
		this.SmartPhoneScreen = this.Student.SmartPhoneScreen;
		this.BookRenderer = this.Student.BookRenderer;
		this.MyRenderer = this.Student.MyRenderer;
		this.Tears = this.Student.Tears;
		this.WeaponBagParent = this.Student.WeaponBagParent;
		this.DefaultTarget = this.Student.DefaultTarget;
		this.ItemParent = this.Student.ItemParent;
		this.WitnessPOV = this.Student.WitnessPOV;
		this.RightHand = this.Student.RightHand;
		this.LeftHand = this.Student.LeftHand;
		this.MyLocker = this.Student.MyLocker;
		this.RightEye = this.Student.RightEye;
		this.LeftEye = this.Student.LeftEye;
		this.Eyes = this.Student.Eyes;
		this.Head = this.Student.Head;
		this.Hips = this.Student.Hips;
		this.Neck = this.Student.Neck;
		this.RightHandCollider = this.Student.RightHandCollider;
		this.LeftHandCollider = this.Student.LeftHandCollider;
		this.NotFaceCollider = this.Student.NotFaceCollider;
		this.FaceCollider = this.Student.FaceCollider;
		this.HipCollider = this.Student.HipCollider;
		this.BullyPhotoCollider = this.Student.BullyPhotoCollider;
		this.WhiteQuestionMark = this.Student.WhiteQuestionMark;
		this.MiyukiGameScreen = this.Student.MiyukiGameScreen;
		this.RiggedAccessory = this.Student.RiggedAccessory;
		this.SecurityCamera = this.Student.SecurityCamera;
		this.RightEmptyEye = this.Student.RightEmptyEye;
		this.LeftEmptyEye = this.Student.LeftEmptyEye;
		this.AnimatedBook = this.Student.AnimatedBook;
		this.CameraFlash = this.Student.CameraFlash;
		this.ChaseCamera = this.Student.ChaseCamera;
		this.PepperSpray = this.Student.PepperSpray;
		this.BloodSpray = this.Student.BloodSpray;
		this.Sketchbook = this.Student.Sketchbook;
		this.SmartPhone = this.Student.SmartPhone;
		this.OccultBook = this.Student.OccultBook;
		this.Paintbrush = this.Student.Paintbrush;
		this.Character = this.Student.Character;
		this.EventBook = this.Student.EventBook;
		this.Handcuffs = this.Student.Handcuffs;
		this.HealthBar = this.Student.HealthBar;
		this.OsanaHair = this.Student.OsanaHair;
		this.WeaponBag = this.Student.WeaponBag;
		this.CandyBar = this.Student.CandyBar;
		this.Earpiece = this.Student.Earpiece;
		this.Scrubber = this.Student.Scrubber;
		this.Armband = this.Student.Armband;
		this.BookBag = this.Student.BookBag;
		this.Octodog = this.Student.Octodog;
		this.Palette = this.Student.Palette;
		this.Eraser = this.Student.Eraser;
		this.Pencil = this.Student.Pencil;
		this.Bento = this.Student.Bento;
		this.Note = this.Student.Note;
		this.Lid = this.Student.Lid;
		this.Pen = this.Student.Pen;
		this.AirGuitar = this.Student.AirGuitar;
		this.PantyCollider = this.Student.PantyCollider;
		this.SkirtCollider = this.Student.SkirtCollider;
		this.LeftMiddleFinger = this.Student.LeftMiddleFinger;
		this.RightBreast = this.Student.RightBreast;
		this.LeftBreast = this.Student.LeftBreast;
		this.RightDrill = this.Student.RightDrill;
		this.LeftDrill = this.Student.LeftDrill;
		this.Spine = this.Student.Spine;
		this.WateringCan = this.Student.WateringCan;
		this.Cigarette = this.Student.Cigarette;
		this.Lighter = this.Student.Lighter;
		this.StudentManager = this.Student.StudentManager;
	}

	private void LoadReferences()
	{
		this.Student.SaveLoad = this;
		this.Student.CharacterAnimation = this.CharacterAnimation;
		this.Student.LabcoatAttacher = this.LabcoatAttacher;
		this.Student.LiquidProjector = this.LiquidProjector;
		this.Student.ChemistScanner = this.ChemistScanner;
		this.Student.DramaticCamera = this.DramaticCamera;
		this.Student.ApronAttacher = this.ApronAttacher;
		this.Student.DialogueWheel = this.DialogueWheel;
		this.Student.MyController = this.MyController;
		this.Student.ClubManager = this.ClubManager;
		this.Student.Pathfinding = this.Pathfinding;
		this.Student.ShoeRemoval = this.ShoeRemoval;
		this.Student.Countdown = this.Countdown;
		this.Student.Attacher = this.Attacher;
		this.Student.Cosmetic = this.Cosmetic;
		this.Student.Obstacle = this.Obstacle;
		this.Student.LowPoly = this.LowPoly;
		this.Student.Ragdoll = this.Ragdoll;
		this.Student.Miyuki = this.Miyuki;
		this.Student.Prompt = this.Prompt;
		this.Student.Talk = this.Talk;
		this.Student.DelinquentSpeechLines = this.DelinquentSpeechLines;
		this.Student.PepperSprayEffect = this.PepperSprayEffect;
		this.Student.BloodFountain = this.BloodFountain;
		this.Student.VomitEmitter = this.VomitEmitter;
		this.Student.SpeechLines = this.SpeechLines;
		this.Student.BullyDust = this.BullyDust;
		this.Student.ChalkDust = this.ChalkDust;
		this.Student.Hearts = this.Hearts;
		this.Student.SmartPhoneScreen = this.SmartPhoneScreen;
		this.Student.BookRenderer = this.BookRenderer;
		this.Student.MyRenderer = this.MyRenderer;
		this.Student.Tears = this.Tears;
		this.Student.WeaponBagParent = this.WeaponBagParent;
		this.Student.DefaultTarget = this.DefaultTarget;
		this.Student.ItemParent = this.ItemParent;
		this.Student.WitnessPOV = this.WitnessPOV;
		this.Student.RightHand = this.RightHand;
		this.Student.LeftHand = this.LeftHand;
		this.Student.MyLocker = this.MyLocker;
		this.Student.RightEye = this.RightEye;
		this.Student.LeftEye = this.LeftEye;
		this.Student.Eyes = this.Eyes;
		this.Student.Head = this.Head;
		this.Student.Hips = this.Hips;
		this.Student.Neck = this.Neck;
		this.Student.RightHandCollider = this.RightHandCollider;
		this.Student.LeftHandCollider = this.LeftHandCollider;
		this.Student.NotFaceCollider = this.NotFaceCollider;
		this.Student.FaceCollider = this.FaceCollider;
		this.Student.HipCollider = this.HipCollider;
		this.Student.BullyPhotoCollider = this.BullyPhotoCollider;
		this.Student.WhiteQuestionMark = this.WhiteQuestionMark;
		this.Student.MiyukiGameScreen = this.MiyukiGameScreen;
		this.Student.RiggedAccessory = this.RiggedAccessory;
		this.Student.SecurityCamera = this.SecurityCamera;
		this.Student.RightEmptyEye = this.RightEmptyEye;
		this.Student.LeftEmptyEye = this.LeftEmptyEye;
		this.Student.AnimatedBook = this.AnimatedBook;
		this.Student.CameraFlash = this.CameraFlash;
		this.Student.ChaseCamera = this.ChaseCamera;
		this.Student.PepperSpray = this.PepperSpray;
		this.Student.BloodSpray = this.BloodSpray;
		this.Student.Sketchbook = this.Sketchbook;
		this.Student.SmartPhone = this.SmartPhone;
		this.Student.OccultBook = this.OccultBook;
		this.Student.Paintbrush = this.Paintbrush;
		this.Student.Character = this.Character;
		this.Student.EventBook = this.EventBook;
		this.Student.Handcuffs = this.Handcuffs;
		this.Student.HealthBar = this.HealthBar;
		this.Student.OsanaHair = this.OsanaHair;
		this.Student.WeaponBag = this.WeaponBag;
		this.Student.CandyBar = this.CandyBar;
		this.Student.Earpiece = this.Earpiece;
		this.Student.Scrubber = this.Scrubber;
		this.Student.Armband = this.Armband;
		this.Student.BookBag = this.BookBag;
		this.Student.Octodog = this.Octodog;
		this.Student.Palette = this.Palette;
		this.Student.Eraser = this.Eraser;
		this.Student.Pencil = this.Pencil;
		this.Student.Bento = this.Bento;
		this.Student.Note = this.Note;
		this.Student.Lid = this.Lid;
		this.Student.Pen = this.Pen;
		this.Student.ScienceProps = this.ScienceProps;
		this.Student.Fingerfood = this.Fingerfood;
		this.Student.LiquidEmitters = this.LiquidEmitters;
		this.Student.SplashEmitters = this.SplashEmitters;
		this.Student.FireEmitters = this.FireEmitters;
		this.Student.PantyCollider = this.PantyCollider;
		this.Student.SkirtCollider = this.SkirtCollider;
		this.Student.AirGuitar = this.AirGuitar;
		this.Student.WateringCan = this.WateringCan;
		this.Student.Cigarette = this.Cigarette;
		this.Student.Lighter = this.Lighter;
		this.Student.LeftMiddleFinger = this.LeftMiddleFinger;
		this.Student.RightBreast = this.RightBreast;
		this.Student.LeftBreast = this.LeftBreast;
		this.Student.RightDrill = this.RightDrill;
		this.Student.LeftDrill = this.LeftDrill;
		this.Student.Spine = this.Spine;
		this.Student.SplashEmitters = this.SplashEmitters;
		this.Student.InstrumentBag = this.InstrumentBag;
		this.Student.ElectroSteam = this.ElectroSteam;
		this.Student.CensorSteam = this.CensorSteam;
		this.Student.Instruments = this.Instruments;
		this.Student.Chopsticks = this.Chopsticks;
		this.Student.Drumsticks = this.Drumsticks;
		this.Student.Skirt = this.Skirt;
		this.Student.StudentManager = this.StudentManager;
		if (this.Student.Club < ClubType.Gaming)
		{
			this.Student.ChangingBooth = this.StudentManager.ChangingBooths[(int)this.Student.Club];
		}
		if (this.Student.Club == ClubType.Cooking)
		{
			this.Student.MyPlate = this.StudentManager.Plates[this.Student.ClubMemberID];
		}
		if (!this.Student.Teacher)
		{
			this.StudentManager.CleaningManager.GetRole(this.Student.StudentID);
			this.Student.CleaningSpot = this.StudentManager.CleaningManager.Spot;
			this.Student.CleaningRole = this.StudentManager.CleaningManager.Role;
		}
		this.Student.Reputation = this.StudentManager.Reputation;
		this.Student.Yandere = this.StudentManager.Yandere;
		this.Student.Police = this.StudentManager.Police;
		this.Student.Clock = this.StudentManager.Clock;
		this.Student.JSON = this.StudentManager.JSON;
		this.Student.Seat = this.StudentManager.Seats[this.Student.Class].List[this.Student.JSON.Students[this.Student.StudentID].Seat];
		this.Student.Subtitle = this.Student.Yandere.Subtitle;
		this.Student.GetDestinations();
		this.Student.CurrentDestination = this.Student.Destinations[this.Student.Phase];
		this.Student.Pathfinding.target = this.Student.Destinations[this.Student.Phase];
		if (this.Student.Teacher)
		{
			this.Student.GradingPaper = this.StudentManager.FacultyDesks[this.Student.Class];
		}
	}
}
