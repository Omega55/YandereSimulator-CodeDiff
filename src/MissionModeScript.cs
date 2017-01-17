using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class MissionModeScript : MonoBehaviour
{
	public NotificationManagerScript NotificationManager;

	public MissionModeMenuScript MissionModeMenu;

	public StudentManagerScript StudentManager;

	public WeaponManagerScript WeaponManager;

	public PromptScript ExitPortalPrompt;

	public IncineratorScript Incinerator;

	public WoodChipperScript WoodChipper;

	public ReputationScript Reputation;

	public GrayscaleEffect Grayscale;

	public PromptBarScript PromptBar;

	public BoundaryScript Boundary;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public PoliceScript Police;

	public ClockScript Clock;

	public UILabel ReputationLabel;

	public UILabel GameOverHeader;

	public UILabel GameOverReason;

	public UILabel SubtitleLabel;

	public UISprite CautionSign;

	public UISprite MusicIcon;

	public UILabel TimeLabel;

	public UISprite Darkness;

	public GUIText FPS;

	public GardenHoleScript[] GardenHoles;

	public GameObject[] ReputationIcons;

	public string[] GameOverReasons;

	public AudioClip[] StealthMusic;

	public Transform[] SpawnPoints;

	public int[] Conditions;

	public GameObject SecurityCameraGroup;

	public GameObject MetalDetectorGroup;

	public GameObject HeartbrokenCamera;

	public GameObject DetectionCamera;

	public GameObject HeartbeatCamera;

	public GameObject MissionModeHUD;

	public GameObject TranqDetector;

	public GameObject WitnessCamera;

	public GameObject GameOverText;

	public GameObject ExitPortal;

	public GameObject MurderKit;

	public GameObject Subtitle;

	public GameObject Nemesis;

	public GameObject Safe;

	public Transform LastKnownPosition;

	public int RequiredClothingID;

	public int RequiredDisposalID;

	public int RequiredWeaponID;

	public int NemesisDifficulty;

	public int DisposalMethod;

	public int MurderWeaponID;

	public int GameOverPhase;

	public int Destination;

	public int Difficulty;

	public int GameOverID;

	public int TargetID;

	public int MusicID;

	public int Phase;

	public int ID;

	public bool SecurityCameras;

	public bool MetalDetectors;

	public bool StealDocuments;

	public bool NoCollateral;

	public bool NoSuspicion;

	public bool NoWitnesses;

	public bool NoCorpses;

	public bool NoSpeech;

	public bool NoWeapon;

	public bool NoBlood;

	public bool TimeLimit;

	public bool CorrectClothingConfirmed;

	public bool DocumentsStolen;

	public bool CorpseDisposed;

	public bool WeaponDisposed;

	public bool BloodCleaned;

	public bool InfoRemark;

	public bool TargetDead;

	public bool Chastise;

	public bool FadeOut;

	public string CauseOfFailure;

	public float TimeRemaining;

	public float TargetHeight;

	public float Speed;

	public float Timer;

	public AudioClip InfoAccomplished;

	public AudioClip InfoExfiltrate;

	public AudioClip InfoObjective;

	public AudioClip InfoFailure;

	public AudioClip GameOverSound;

	public ColorCorrectionCurves[] ColorCorrections;

	public UILabel Watermark;

	public Font Arial;

	public int Frame;

	public MissionModeScript()
	{
		this.MusicID = 1;
		this.Phase = 1;
		this.CauseOfFailure = string.Empty;
		this.TimeRemaining = 300f;
	}

	public virtual void Start()
	{
		this.SecurityCameraGroup.active = false;
		this.MetalDetectorGroup.active = false;
		this.MissionModeHUD.active = false;
		this.ExitPortal.active = false;
		this.Safe.active = false;
		if (PlayerPrefs.GetInt("MissionMode") == 1)
		{
			this.Yandere.HeartRate.MediumColour = new Color((float)1, 0.5f, 0.5f, (float)1);
			this.Yandere.HeartRate.NormalColour = new Color((float)1, (float)1, (float)1, (float)1);
			this.Clock.PeriodLabel.color = new Color((float)1, (float)1, (float)1, (float)1);
			this.Clock.TimeLabel.color = new Color((float)1, (float)1, (float)1, (float)1);
			this.Clock.DayLabel.enabled = false;
			((UISprite)this.Reputation.PendingRepMarker.GetComponent(typeof(UISprite))).color = new Color((float)1, (float)1, (float)1, (float)1);
			this.Reputation.CurrentRepMarker.gameObject.active = false;
			this.Reputation.PendingRepLabel.color = new Color((float)1, (float)1, (float)1, (float)1);
			this.ReputationLabel.fontStyle = FontStyle.Bold;
			this.ReputationLabel.trueTypeFont = this.Arial;
			this.ReputationLabel.color = new Color((float)1, (float)1, (float)1, (float)1);
			this.ReputationLabel.text = "AWARENESS";
			this.ReputationIcons[0].active = true;
			this.ReputationIcons[1].active = false;
			this.ReputationIcons[2].active = false;
			this.ReputationIcons[3].active = false;
			this.ReputationIcons[4].active = false;
			this.ReputationIcons[5].active = false;
			this.Clock.TimeLabel.fontStyle = FontStyle.Bold;
			this.Clock.TimeLabel.trueTypeFont = this.Arial;
			this.Clock.PeriodLabel.fontStyle = FontStyle.Bold;
			this.Clock.PeriodLabel.trueTypeFont = this.Arial;
			this.Watermark.fontStyle = FontStyle.Bold;
			this.Watermark.color = new Color((float)1, (float)1, (float)1, (float)1);
			this.Watermark.trueTypeFont = this.Arial;
			this.SubtitleLabel.color = new Color((float)1, (float)1, (float)1, (float)1);
			this.CautionSign.color = new Color((float)1, (float)1, (float)1, (float)1);
			this.FPS.color = new Color((float)1, (float)1, (float)1, (float)1);
			this.ColorCorrections = Camera.main.GetComponents<ColorCorrectionCurves>();
			this.StudentManager.MissionMode = true;
			this.NemesisDifficulty = PlayerPrefs.GetInt("NemesisDifficulty");
			this.Difficulty = PlayerPrefs.GetInt("MissionDifficulty");
			this.TargetID = PlayerPrefs.GetInt("MissionTarget");
			if (this.Difficulty > 1)
			{
				this.ID = 2;
				while (this.ID < this.Difficulty + 1)
				{
					if (PlayerPrefs.GetInt("MissionCondition_" + this.ID) == 1)
					{
						this.RequiredWeaponID = PlayerPrefs.GetInt("MissionRequiredWeapon");
					}
					else if (PlayerPrefs.GetInt("MissionCondition_" + this.ID) == 2)
					{
						this.RequiredClothingID = PlayerPrefs.GetInt("MissionRequiredClothing");
					}
					else if (PlayerPrefs.GetInt("MissionCondition_" + this.ID) == 3)
					{
						this.RequiredDisposalID = PlayerPrefs.GetInt("MissionRequiredDisposal");
					}
					else if (PlayerPrefs.GetInt("MissionCondition_" + this.ID) == 4)
					{
						this.NoCollateral = true;
					}
					else if (PlayerPrefs.GetInt("MissionCondition_" + this.ID) == 5)
					{
						this.NoWitnesses = true;
					}
					else if (PlayerPrefs.GetInt("MissionCondition_" + this.ID) == 6)
					{
						this.NoCorpses = true;
					}
					else if (PlayerPrefs.GetInt("MissionCondition_" + this.ID) == 7)
					{
						this.NoWeapon = true;
					}
					else if (PlayerPrefs.GetInt("MissionCondition_" + this.ID) == 8)
					{
						this.NoBlood = true;
					}
					else if (PlayerPrefs.GetInt("MissionCondition_" + this.ID) == 9)
					{
						this.TimeLimit = true;
					}
					else if (PlayerPrefs.GetInt("MissionCondition_" + this.ID) == 10)
					{
						this.NoSuspicion = true;
					}
					else if (PlayerPrefs.GetInt("MissionCondition_" + this.ID) == 11)
					{
						this.SecurityCameras = true;
					}
					else if (PlayerPrefs.GetInt("MissionCondition_" + this.ID) == 12)
					{
						this.MetalDetectors = true;
					}
					else if (PlayerPrefs.GetInt("MissionCondition_" + this.ID) == 13)
					{
						this.NoSpeech = true;
					}
					else if (PlayerPrefs.GetInt("MissionCondition_" + this.ID) == 14)
					{
						this.StealDocuments = true;
					}
					this.Conditions[this.ID] = PlayerPrefs.GetInt("MissionCondition_" + this.ID);
					this.ID++;
				}
			}
			if (!this.StealDocuments)
			{
				this.DocumentsStolen = true;
			}
			else
			{
				this.Safe.active = true;
			}
			if (this.SecurityCameras)
			{
				this.SecurityCameraGroup.active = true;
			}
			if (this.MetalDetectors)
			{
				this.MetalDetectorGroup.active = true;
			}
			if (!this.TimeLimit)
			{
				this.TimeLabel.gameObject.active = false;
			}
			if (this.NoSpeech)
			{
				this.StudentManager.NoSpeech = true;
			}
			if (this.RequiredDisposalID == 0)
			{
				this.CorpseDisposed = true;
			}
			if (this.NemesisDifficulty > 0)
			{
				this.Nemesis.active = true;
			}
			if (!this.NoWeapon)
			{
				this.WeaponDisposed = true;
			}
			if (!this.NoBlood)
			{
				this.BloodCleaned = true;
			}
			this.Jukebox.Egg = true;
			this.Jukebox.KillVolume();
			this.Jukebox.MissionMode.enabled = true;
			this.Jukebox.MissionMode.volume = (float)0;
			this.Yandere.FixCamera();
			float y = 6.51505f;
			Vector3 position = Camera.main.transform.position;
			float num = position.y = y;
			Vector3 vector = Camera.main.transform.position = position;
			float z = -76.9222f;
			Vector3 position2 = Camera.main.transform.position;
			float num2 = position2.z = z;
			Vector3 vector2 = Camera.main.transform.position = position2;
			int num3 = 15;
			Vector3 eulerAngles = Camera.main.transform.eulerAngles;
			float num4 = eulerAngles.x = (float)num3;
			Vector3 vector3 = Camera.main.transform.eulerAngles = eulerAngles;
			this.Yandere.RPGCamera.enabled = false;
			this.Yandere.SanityBased = true;
			this.Yandere.CanMove = false;
			this.HeartbeatCamera.active = false;
			this.TranqDetector.active = false;
			this.MurderKit.active = false;
			this.TargetHeight = 1.51505f;
			this.Yandere.HUD.alpha = (float)0;
			int num5 = 1;
			Color color = this.MusicIcon.color;
			float num6 = color.a = (float)num5;
			Color color2 = this.MusicIcon.color = color;
			int num7 = 1;
			Color color3 = this.Darkness.color;
			float num8 = color3.a = (float)num7;
			Color color4 = this.Darkness.color = color3;
			this.MissionModeMenu.UpdateGraphics();
		}
		else
		{
			this.MissionModeMenu.gameObject.active = false;
			this.TimeLabel.gameObject.active = false;
			this.enabled = false;
		}
	}

	public virtual void Update()
	{
		if (this.Phase == 1)
		{
			float a = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime * (float)1 / (float)3);
			Color color = this.Darkness.color;
			float num = color.a = a;
			Color color2 = this.Darkness.color = color;
			if (this.Darkness.color.a == (float)0)
			{
				this.Speed += Time.deltaTime * (float)1 / (float)3;
				float y = Mathf.Lerp(Camera.main.transform.position.y, this.TargetHeight, Time.deltaTime * this.Speed);
				Vector3 position = Camera.main.transform.position;
				float num2 = position.y = y;
				Vector3 vector = Camera.main.transform.position = position;
				if (Camera.main.transform.position.y < this.TargetHeight + 0.1f)
				{
					this.Yandere.HUD.alpha = Mathf.MoveTowards(this.Yandere.HUD.alpha, (float)1, Time.deltaTime * (float)1 / (float)3);
					if (this.Yandere.HUD.alpha == (float)1)
					{
						this.Yandere.RPGCamera.enabled = true;
						this.HeartbeatCamera.active = true;
						this.Yandere.CanMove = true;
						this.Phase++;
					}
				}
			}
			if (Input.GetButtonDown("A"))
			{
				float targetHeight = this.TargetHeight;
				Vector3 position2 = Camera.main.transform.position;
				float num3 = position2.y = targetHeight;
				Vector3 vector2 = Camera.main.transform.position = position2;
				this.Yandere.RPGCamera.enabled = true;
				this.HeartbeatCamera.active = true;
				this.Yandere.CanMove = true;
				this.Yandere.HUD.alpha = (float)1;
				int num4 = 0;
				Color color3 = this.Darkness.color;
				float num5 = color3.a = (float)num4;
				Color color4 = this.Darkness.color = color3;
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			if (!this.TargetDead && this.StudentManager.Students[this.TargetID] != null)
			{
				if (this.StudentManager.Students[this.TargetID].Dead)
				{
					if (this.Yandere.Equipped > 0)
					{
						this.MurderWeaponID = this.Yandere.Weapon[this.Yandere.Equipped].WeaponID;
					}
					this.TargetDead = true;
				}
				if (this.StudentManager.Students[this.TargetID].transform.position.y < (float)-2)
				{
					this.GameOverID = 1;
					this.GameOver();
					this.Phase = 4;
				}
			}
			if (this.RequiredWeaponID > 0 && this.StudentManager.Students[this.TargetID] != null && this.StudentManager.Students[this.TargetID].Dead && this.StudentManager.Students[this.TargetID].DeathCause != this.RequiredWeaponID)
			{
				this.Chastise = true;
				this.GameOverID = 2;
				this.GameOver();
				this.Phase = 4;
			}
			if (!this.CorrectClothingConfirmed && this.RequiredClothingID > 0 && this.StudentManager.Students[this.TargetID] != null && this.StudentManager.Students[this.TargetID].Dead)
			{
				if (this.Yandere.Schoolwear != this.RequiredClothingID)
				{
					this.Chastise = true;
					this.GameOverID = 3;
					this.GameOver();
					this.Phase = 4;
				}
				else
				{
					this.CorrectClothingConfirmed = true;
				}
			}
			if (this.RequiredDisposalID > 0 && this.DisposalMethod == 0 && this.TargetDead)
			{
				this.ID = 1;
				while (this.ID < this.Incinerator.Victims + 1)
				{
					if (this.Incinerator.VictimList[this.ID] == this.TargetID)
					{
						this.DisposalMethod = 1;
					}
					this.ID++;
				}
				this.ID = 1;
				int num6 = 0;
				while (this.ID < this.Incinerator.Limbs + 1)
				{
					if (this.Incinerator.LimbList[this.ID] == this.TargetID)
					{
						num6++;
					}
					if (num6 == 6)
					{
						this.DisposalMethod = 1;
					}
					this.ID++;
				}
				this.ID = 1;
				while (this.ID < this.WoodChipper.Victims + 1)
				{
					if (this.WoodChipper.VictimList[this.ID] == this.TargetID)
					{
						this.DisposalMethod = 2;
					}
					this.ID++;
				}
				this.ID = 1;
				while (this.ID < Extensions.get_length(this.GardenHoles))
				{
					if (this.GardenHoles[this.ID].VictimID == this.TargetID)
					{
						this.DisposalMethod = 3;
					}
					this.ID++;
				}
				if (this.DisposalMethod > 0)
				{
					if (this.DisposalMethod != this.RequiredDisposalID)
					{
						this.Chastise = true;
						this.GameOverID = 4;
						this.GameOver();
						this.Phase = 4;
					}
					else
					{
						this.CorpseDisposed = true;
					}
				}
			}
			if (this.NoCollateral)
			{
				if (this.Police.Corpses == 1)
				{
					if (this.StudentManager.Students[this.TargetID] != null && !this.StudentManager.Students[this.TargetID].Dead)
					{
						this.Chastise = true;
						this.GameOverID = 5;
						this.GameOver();
						this.Phase = 4;
					}
				}
				else if (this.Police.Corpses > 1)
				{
					this.GameOverID = 5;
					this.GameOver();
					this.Phase = 4;
				}
			}
			if (this.NoWitnesses)
			{
				this.ID = 1;
				while (this.ID < Extensions.get_length(this.StudentManager.Students))
				{
					if (this.StudentManager.Students[this.ID] != null && this.StudentManager.Students[this.ID].WitnessedMurder)
					{
						this.Chastise = true;
						this.GameOverID = 6;
						this.GameOver();
						this.Phase = 4;
					}
					this.ID++;
				}
			}
			if (this.NoCorpses)
			{
				this.ID = 1;
				while (this.ID < Extensions.get_length(this.StudentManager.Students))
				{
					if (this.StudentManager.Students[this.ID] != null && this.StudentManager.Students[this.ID].WitnessedCorpse)
					{
						this.Chastise = true;
						this.GameOverID = 7;
						this.GameOver();
						this.Phase = 4;
					}
					this.ID++;
				}
			}
			if (this.NoBlood)
			{
				if (this.Police.BloodParent.childCount == 0)
				{
					this.BloodCleaned = true;
				}
				else
				{
					this.BloodCleaned = false;
				}
			}
			if (this.NoWeapon && !this.WeaponDisposed && this.Incinerator.Timer > (float)0)
			{
				this.ID = 1;
				while (this.ID < this.Incinerator.DestroyedEvidence + 1)
				{
					if (this.Incinerator.EvidenceList[this.ID] == this.MurderWeaponID)
					{
						this.WeaponDisposed = true;
					}
					this.ID++;
				}
			}
			if (this.TimeLimit)
			{
				if (!this.Yandere.PauseScreen.Show)
				{
					this.TimeRemaining = Mathf.MoveTowards(this.TimeRemaining, (float)0, 0.0166666675f);
				}
				int num7 = Mathf.CeilToInt(this.TimeRemaining);
				int num8 = num7 / 60;
				int num9 = num7 % 60;
				this.TimeLabel.text = string.Format("{0:00}:{1:00}", num8, num9);
				if (this.TimeRemaining == (float)0)
				{
					this.Chastise = true;
					this.GameOverID = 10;
					this.GameOver();
					this.Phase = 4;
				}
			}
			if (this.Reputation.Reputation + this.Reputation.PendingRep <= (float)-100)
			{
				this.GameOverID = 14;
				this.GameOver();
				this.Phase = 4;
			}
			if (this.NoSuspicion && this.Reputation.Reputation + this.Reputation.PendingRep < (float)0)
			{
				this.GameOverID = 14;
				this.GameOver();
				this.Phase = 4;
			}
			if (this.HeartbrokenCamera.active)
			{
				this.HeartbrokenCamera.active = false;
				this.GameOverID = 0;
				this.GameOver();
				this.Phase = 4;
			}
			if (this.Clock.PresentTime > (float)1080)
			{
				this.GameOverID = 11;
				this.GameOver();
				this.Phase = 4;
			}
			else if (this.Police.FadeOut)
			{
				this.GameOverID = 12;
				this.GameOver();
				this.Phase = 4;
			}
			if (this.ExitPortal.active)
			{
				if (this.Yandere.Chased)
				{
					this.ExitPortalPrompt.Label[0].text = "     " + "Cannot Exfiltrate!";
					this.ExitPortalPrompt.Circle[0].fillAmount = (float)1;
				}
				else
				{
					this.ExitPortalPrompt.Label[0].text = "     " + "Exfiltrate";
					if (this.ExitPortalPrompt.Circle[0].fillAmount == (float)0)
					{
						Camera.main.transform.position = new Vector3(0.5f, 2.25f, -100.5f);
						Camera.main.transform.eulerAngles = new Vector3((float)0, (float)0, (float)0);
						this.Yandere.transform.eulerAngles = new Vector3((float)0, (float)180, (float)0);
						this.Yandere.transform.position = new Vector3((float)0, (float)0, -94.5f);
						this.Yandere.Character.animation.Play(this.Yandere.WalkAnim);
						this.Yandere.RPGCamera.enabled = false;
						this.Yandere.HUD.active = false;
						this.Yandere.CanMove = false;
						this.Jukebox.MissionMode.audio.clip = this.StealthMusic[6];
						this.Jukebox.MissionMode.audio.loop = false;
						this.Jukebox.MissionMode.audio.Play();
						this.audio.PlayOneShot(this.InfoAccomplished);
						this.HeartbeatCamera.active = false;
						this.Boundary.enabled = false;
						this.Phase++;
					}
				}
			}
			if (this.TargetDead && this.CorpseDisposed && this.BloodCleaned && this.WeaponDisposed && this.DocumentsStolen && this.GameOverID == 0 && !this.ExitPortal.active)
			{
				this.NotificationManager.DisplayNotification("Complete");
				this.NotificationManager.DisplayNotification("Exfiltrate");
				this.audio.PlayOneShot(this.InfoExfiltrate);
				this.ExitPortal.active = true;
			}
			if (!this.InfoRemark && this.GameOverID == 0 && this.TargetDead && (!this.CorpseDisposed || !this.BloodCleaned || !this.WeaponDisposed))
			{
				this.audio.PlayOneShot(this.InfoObjective);
				this.InfoRemark = true;
			}
		}
		else if (this.Phase == 3)
		{
			this.Timer += Time.deltaTime;
			float y2 = Camera.main.transform.position.y - Time.deltaTime * 0.2f;
			Vector3 position3 = Camera.main.transform.position;
			float num10 = position3.y = y2;
			Vector3 vector3 = Camera.main.transform.position = position3;
			float z = this.Yandere.transform.position.z - Time.deltaTime;
			Vector3 position4 = this.Yandere.transform.position;
			float num11 = position4.z = z;
			Vector3 vector4 = this.Yandere.transform.position = position4;
			if (this.Timer > (float)5)
			{
				this.Success();
				this.Timer = (float)0;
				this.Phase++;
			}
		}
		else if (this.Phase == 4)
		{
			this.Timer += 0.0166666675f;
			if (this.Timer > (float)1)
			{
				if (!this.FadeOut)
				{
					if (!this.PromptBar.Show)
					{
						this.PromptBar.Show = true;
					}
					else if (Input.GetButtonDown("A"))
					{
						this.PromptBar.Show = false;
						this.Destination = 1;
						this.FadeOut = true;
					}
					else if (Input.GetButtonDown("B"))
					{
						this.PromptBar.Show = false;
						this.Destination = 2;
						this.FadeOut = true;
					}
					else if (Input.GetButtonDown("X"))
					{
						this.PromptBar.Show = false;
						this.Destination = 3;
						this.FadeOut = true;
					}
				}
				else
				{
					float a2 = Mathf.MoveTowards(this.Darkness.color.a, (float)1, 0.0166666675f);
					Color color5 = this.Darkness.color;
					float num12 = color5.a = a2;
					Color color6 = this.Darkness.color = color5;
					this.Jukebox.Dip = Mathf.MoveTowards(this.Jukebox.Dip, (float)0, 0.0166666675f);
					if (this.Darkness.color.a > 0.9921875f)
					{
						if (this.Destination == 1)
						{
							this.ResetPlayerPrefs();
							Application.LoadLevel(Application.loadedLevel);
						}
						else if (this.Destination == 2)
						{
							PlayerPrefs.DeleteAll();
							Application.LoadLevel("MissionModeScene");
						}
						else if (this.Destination == 3)
						{
							PlayerPrefs.DeleteAll();
							Application.LoadLevel("TitleScene");
						}
					}
				}
			}
			if (this.GameOverPhase == 1)
			{
				if (this.Timer > 2.5f)
				{
					if (this.Chastise)
					{
						this.audio.PlayOneShot(this.InfoFailure);
						this.GameOverPhase++;
					}
					else
					{
						this.GameOverPhase++;
						this.Timer += (float)5;
					}
				}
			}
			else if (this.GameOverPhase == 2 && this.Timer > 7.5f)
			{
				this.Jukebox.MissionMode.audio.clip = this.StealthMusic[0];
				this.Jukebox.MissionMode.audio.Play();
				this.Jukebox.Volume = 0.5f;
				this.GameOverPhase++;
			}
		}
	}

	public virtual void GameOver()
	{
		if (this.Yandere.Aiming)
		{
			this.Yandere.StopAiming();
			this.Yandere.enabled = false;
		}
		this.GameOverReason.text = this.GameOverReasons[this.GameOverID];
		this.ColorCorrections[2].enabled = true;
		this.audio.PlayOneShot(this.GameOverSound);
		this.DetectionCamera.active = false;
		this.HeartbeatCamera.active = false;
		this.WitnessCamera.active = false;
		this.GameOverText.active = true;
		this.Yandere.HUD.active = false;
		this.Subtitle.active = false;
		Time.timeScale = (float)0;
		this.GameOverPhase = 1;
		this.Jukebox.MissionMode.audio.Stop();
	}

	public virtual void Success()
	{
		int num = 0;
		Vector3 localPosition = this.GameOverHeader.transform.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.GameOverHeader.transform.localPosition = localPosition;
		this.GameOverHeader.text = "MISSION ACCOMPLISHED";
		this.GameOverReason.gameObject.active = false;
		this.ColorCorrections[2].enabled = true;
		this.DetectionCamera.active = false;
		this.WitnessCamera.active = false;
		this.GameOverText.active = true;
		this.GameOverReason.text = string.Empty;
		this.Subtitle.active = false;
		this.Jukebox.Volume = (float)1;
		Time.timeScale = (float)0;
	}

	public virtual void ChangeMusic()
	{
		this.MusicID++;
		if (this.MusicID > 5)
		{
			this.MusicID = 1;
		}
		this.Jukebox.MissionMode.audio.clip = this.StealthMusic[this.MusicID];
		this.Jukebox.MissionMode.audio.Play();
	}

	public virtual void ResetPlayerPrefs()
	{
		int @int = PlayerPrefs.GetInt("DisableFarAnimations");
		int int2 = PlayerPrefs.GetInt("DisablePostAliasing");
		int int3 = PlayerPrefs.GetInt("DisableOutlines");
		int int4 = PlayerPrefs.GetInt("LowDetailStudents");
		int int5 = PlayerPrefs.GetInt("ParticleCount");
		int int6 = PlayerPrefs.GetInt("DisableShadows");
		int int7 = PlayerPrefs.GetInt("DrawDistance");
		int int8 = PlayerPrefs.GetInt("DisableBloom");
		int int9 = PlayerPrefs.GetInt("Fog");
		string @string = PlayerPrefs.GetString("MissionTargetName");
		int int10 = PlayerPrefs.GetInt("HighPopulation");
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetFloat("SchoolAtmosphere", (float)100 - (float)this.Difficulty * 1f / 10f * (float)100);
		PlayerPrefs.SetString("MissionTargetName", @string);
		PlayerPrefs.SetInt("MissionDifficulty", this.Difficulty);
		PlayerPrefs.SetInt("HighPopulation", int10);
		PlayerPrefs.SetInt("MissionTarget", this.TargetID);
		PlayerPrefs.SetInt("SchoolAtmosphereSet", 1);
		PlayerPrefs.SetInt("MissionMode", 1);
		PlayerPrefs.SetInt("MissionRequiredWeapon", this.RequiredWeaponID);
		PlayerPrefs.SetInt("MissionRequiredClothing", this.RequiredClothingID);
		PlayerPrefs.SetInt("MissionRequiredDisposal", this.RequiredDisposalID);
		PlayerPrefs.SetInt("BiologyGrade", 1);
		PlayerPrefs.SetInt("ChemistryGrade", 1);
		PlayerPrefs.SetInt("LanguageGrade", 1);
		PlayerPrefs.SetInt("PhysicalGrade", 1);
		PlayerPrefs.SetInt("PsychologyGrade", 1);
		this.ID = 2;
		while (this.ID < 11)
		{
			PlayerPrefs.SetInt("MissionCondition_" + this.ID, this.Conditions[this.ID]);
			this.ID++;
		}
		PlayerPrefs.SetInt("NemesisDifficulty", this.NemesisDifficulty);
		PlayerPrefs.SetInt("DisableFarAnimations", @int);
		PlayerPrefs.SetInt("DisablePostAliasing", int2);
		PlayerPrefs.SetInt("DisableOutlines", int3);
		PlayerPrefs.SetInt("LowDetailStudents", int4);
		PlayerPrefs.SetInt("ParticleCount", int5);
		PlayerPrefs.SetInt("DisableShadows", int6);
		PlayerPrefs.SetInt("DrawDistance", int7);
		PlayerPrefs.SetInt("DisableBloom", int8);
		PlayerPrefs.SetInt("Fog", int9);
	}

	public virtual void ChangeAllText()
	{
		UILabel[] array = ((UILabel[])UnityEngine.Object.FindObjectsOfType(typeof(UILabel))) as UILabel[];
		int i = 0;
		UILabel[] array2 = array;
		int length = array2.Length;
		while (i < length)
		{
			float a = array2[i].color.a;
			array2[i].color = new Color((float)1, (float)1, (float)1, a);
			array2[i].trueTypeFont = this.Arial;
			i++;
		}
		UISprite[] array3 = ((UISprite[])UnityEngine.Object.FindObjectsOfType(typeof(UISprite))) as UISprite[];
		int j = 0;
		UISprite[] array4 = array3;
		int length2 = array4.Length;
		while (j < length2)
		{
			float a2 = array4[j].color.a;
			if (array4[j].color != new Color((float)0, (float)0, (float)0, a2))
			{
				array4[j].color = new Color((float)1, (float)1, (float)1, a2);
			}
			j++;
		}
	}

	public virtual void Main()
	{
	}
}
