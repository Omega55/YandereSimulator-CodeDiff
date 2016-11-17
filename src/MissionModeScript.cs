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

	public GrayscaleEffect Grayscale;

	public PromptBarScript PromptBar;

	public BoundaryScript Boundary;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public PoliceScript Police;

	public ClockScript Clock;

	public UILabel GameOverHeader;

	public UILabel GameOverReason;

	public UISprite MusicIcon;

	public UILabel TimeLabel;

	public UISprite Darkness;

	public GardenHoleScript[] GardenHoles;

	public string[] GameOverReasons;

	public AudioClip[] StealthMusic;

	public GameObject HeartbrokenCamera;

	public GameObject DetectionCamera;

	public GameObject WitnessCamera;

	public GameObject GameOverText;

	public GameObject ExitPortal;

	public GameObject MurderKit;

	public GameObject Subtitle;

	public int RequiredClothingID;

	public int RequiredDisposalID;

	public int RequiredWeaponID;

	public int Destination;

	public int Difficulty;

	public int GameOverID;

	public int TargetID;

	public int MusicID;

	public int Phase;

	public int ID;

	public bool NoCollateral;

	public bool NoWitnesses;

	public bool NoCorpses;

	public bool NoWeapon;

	public bool NoBlood;

	public bool TimeLimit;

	public bool CorrectClothingConfirmed;

	public bool CorpseDisposed;

	public bool WeaponDisposed;

	public bool BloodCleaned;

	public bool InfoRemark;

	public bool TargetDead;

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

	public MissionModeScript()
	{
		this.MusicID = 1;
		this.Phase = 1;
		this.CauseOfFailure = string.Empty;
		this.TimeRemaining = 300f;
	}

	public virtual void Start()
	{
		this.ExitPortal.active = false;
		if (PlayerPrefs.GetInt("MissionMode") == 1)
		{
			this.StudentManager.MissionMode = true;
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
					this.ID++;
				}
			}
			if (!this.TimeLimit)
			{
				this.TimeLabel.gameObject.active = false;
			}
			if (this.RequiredDisposalID == 0)
			{
				this.CorpseDisposed = true;
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
			if (this.StudentManager.Students[this.TargetID] != null)
			{
				if (this.StudentManager.Students[this.TargetID].Dead)
				{
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
				this.audio.PlayOneShot(this.InfoFailure);
				this.GameOverID = 2;
				this.GameOver();
				this.Phase = 4;
			}
			if (!this.CorrectClothingConfirmed && this.RequiredClothingID > 0 && this.StudentManager.Students[this.TargetID] != null && this.StudentManager.Students[this.TargetID].Dead)
			{
				if (this.Yandere.Schoolwear != this.RequiredClothingID)
				{
					this.audio.PlayOneShot(this.InfoFailure);
					this.GameOverID = 3;
					this.GameOver();
					this.Phase = 4;
				}
				else
				{
					this.CorrectClothingConfirmed = true;
				}
			}
			if (this.RequiredDisposalID > 0 && this.StudentManager.Students[this.TargetID] != null)
			{
				int num6;
				if (this.StudentManager.Students[this.TargetID].Dead)
				{
					this.ID = 1;
					while (this.ID < this.Incinerator.Victims + 1)
					{
						if (this.Incinerator.VictimList[this.ID] == this.TargetID)
						{
							num6 = 1;
						}
						this.ID++;
					}
					this.ID = 1;
					while (this.ID < this.WoodChipper.Victims + 1)
					{
						if (this.WoodChipper.VictimList[this.ID] == this.TargetID)
						{
							num6 = 2;
						}
						this.ID++;
					}
					this.ID = 1;
					while (this.ID < Extensions.get_length(this.GardenHoles))
					{
						if (this.GardenHoles[this.ID].VictimID == this.TargetID)
						{
							num6 = 3;
						}
						this.ID++;
					}
				}
				if (num6 > 0)
				{
					if (num6 != this.RequiredDisposalID)
					{
						this.audio.PlayOneShot(this.InfoFailure);
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
						this.audio.PlayOneShot(this.InfoFailure);
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
						this.audio.PlayOneShot(this.InfoFailure);
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
						this.audio.PlayOneShot(this.InfoFailure);
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
			if (this.NoWeapon)
			{
				this.ID = 1;
				while (this.ID < this.Incinerator.DestroyedEvidence + 1)
				{
					if (this.Incinerator.EvidenceList[this.ID] == this.RequiredWeaponID)
					{
						this.WeaponDisposed = true;
					}
					this.ID++;
				}
			}
			if (this.TimeLimit)
			{
				this.TimeRemaining = Mathf.MoveTowards(this.TimeRemaining, (float)0, Time.deltaTime);
				int num7 = Mathf.CeilToInt(this.TimeRemaining);
				int num8 = num7 / 60;
				int num9 = num7 % 60;
				this.TimeLabel.text = string.Format("{0:00}:{1:00}", num8, num9);
				if (this.TimeRemaining == (float)0)
				{
					this.audio.PlayOneShot(this.InfoFailure);
					this.GameOverID = 10;
					this.GameOver();
					this.Phase = 4;
				}
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
			if (this.ExitPortal.active && this.ExitPortalPrompt.Circle[0].fillAmount == (float)0)
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
				this.Boundary.enabled = false;
				this.Phase++;
			}
			if (this.TargetDead && this.CorpseDisposed && this.BloodCleaned && this.WeaponDisposed && !this.ExitPortal.active)
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
		}
	}

	public virtual void GameOver()
	{
		this.GameOverReason.text = this.GameOverReasons[this.GameOverID];
		this.Jukebox.MissionMode.audio.clip = this.StealthMusic[0];
		this.Jukebox.MissionMode.audio.Play();
		this.DetectionCamera.active = false;
		this.WitnessCamera.active = false;
		this.GameOverText.active = true;
		this.Yandere.HUD.active = false;
		this.Grayscale.enabled = true;
		this.Subtitle.active = false;
		this.Jukebox.Volume = (float)1;
		this.PromptBar.Show = true;
		Time.timeScale = (float)0;
		this.PromptBar.ClearButtons();
		this.PromptBar.Label[0].text = "Retry";
		this.PromptBar.Label[1].text = "Mission Menu";
		this.PromptBar.Label[2].text = "Main Menu";
		this.PromptBar.UpdateButtons();
	}

	public virtual void Success()
	{
		this.GameOverHeader.text = "MISSION ACCOMPLISHED";
		this.GameOverReason.text = "You successfully completed the mission!";
		this.DetectionCamera.active = false;
		this.WitnessCamera.active = false;
		this.GameOverText.active = true;
		this.Grayscale.enabled = true;
		this.Subtitle.active = false;
		this.Jukebox.Volume = (float)1;
		this.PromptBar.Show = true;
		Time.timeScale = (float)0;
		this.PromptBar.ClearButtons();
		this.PromptBar.Label[0].text = "Replay";
		this.PromptBar.Label[1].text = "Mission Menu";
		this.PromptBar.Label[2].text = "Main Menu";
		this.PromptBar.UpdateButtons();
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

	public virtual void Main()
	{
	}
}
