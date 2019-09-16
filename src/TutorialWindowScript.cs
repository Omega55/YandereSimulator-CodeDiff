using System;
using UnityEngine;

public class TutorialWindowScript : MonoBehaviour
{
	public YandereScript Yandere;

	public bool ShowClothingMessage;

	public bool ShowCouncilMessage;

	public bool ShowTeacherMessage;

	public bool ShowLockerMessage;

	public bool ShowPoliceMessage;

	public bool ShowSanityMessage;

	public bool ShowSenpaiMessage;

	public bool ShowVisionMessage;

	public bool ShowWeaponMessage;

	public bool ShowBloodMessage;

	public bool ShowClassMessage;

	public bool ShowPhotoMessage;

	public bool ShowClubMessage;

	public bool ShowInfoMessage;

	public bool ShowPoolMessage;

	public bool ShowRepMessage;

	public bool IgnoreClothing;

	public bool IgnoreCouncil;

	public bool IgnoreTeacher;

	public bool IgnoreLocker;

	public bool IgnorePolice;

	public bool IgnoreSanity;

	public bool IgnoreSenpai;

	public bool IgnoreVision;

	public bool IgnoreWeapon;

	public bool IgnoreBlood;

	public bool IgnoreClass;

	public bool IgnorePhoto;

	public bool IgnoreClub;

	public bool IgnoreInfo;

	public bool IgnorePool;

	public bool IgnoreRep;

	public bool Hide;

	public bool Show;

	public UILabel TutorialLabel;

	public UILabel ShadowLabel;

	public UILabel TitleLabel;

	public UITexture TutorialImage;

	public string DisabledString;

	public Texture DisabledTexture;

	public string ClothingString;

	public Texture ClothingTexture;

	public string CouncilString;

	public Texture CouncilTexture;

	public string TeacherString;

	public Texture TeacherTexture;

	public string LockerString;

	public Texture LockerTexture;

	public string PoliceString;

	public Texture PoliceTexture;

	public string SanityString;

	public Texture SanityTexture;

	public string SenpaiString;

	public Texture SenpaiTexture;

	public string VisionString;

	public Texture VisionTexture;

	public string WeaponString;

	public Texture WeaponTexture;

	public string BloodString;

	public Texture BloodTexture;

	public string ClassString;

	public Texture ClassTexture;

	public string PhotoString;

	public Texture PhotoTexture;

	public string ClubString;

	public Texture ClubTexture;

	public string InfoString;

	public Texture InfoTexture;

	public string PoolString;

	public Texture PoolTexture;

	public string RepString;

	public Texture RepTexture;

	public float Timer;

	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 0f, 0f);
		if (OptionGlobals.TutorialsOff)
		{
			base.enabled = false;
		}
		else
		{
			this.IgnoreClothing = TutorialGlobals.IgnoreClothing;
			this.IgnoreCouncil = TutorialGlobals.IgnoreCouncil;
			this.IgnoreTeacher = TutorialGlobals.IgnoreTeacher;
			this.IgnoreLocker = TutorialGlobals.IgnoreLocker;
			this.IgnorePolice = TutorialGlobals.IgnorePolice;
			this.IgnoreSanity = TutorialGlobals.IgnoreSanity;
			this.IgnoreSenpai = TutorialGlobals.IgnoreSenpai;
			this.IgnoreVision = TutorialGlobals.IgnoreVision;
			this.IgnoreWeapon = TutorialGlobals.IgnoreWeapon;
			this.IgnoreBlood = TutorialGlobals.IgnoreBlood;
			this.IgnoreClass = TutorialGlobals.IgnoreClass;
			this.IgnorePhoto = TutorialGlobals.IgnorePhoto;
			this.IgnoreClub = TutorialGlobals.IgnoreClub;
			this.IgnoreInfo = TutorialGlobals.IgnoreInfo;
			this.IgnorePool = TutorialGlobals.IgnorePool;
			this.IgnoreRep = TutorialGlobals.IgnoreRep;
		}
	}

	private void Update()
	{
		if (this.Show)
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1.2925f, 1.2925f, 1.2925f), Time.unscaledDeltaTime * 10f);
			if (base.transform.localScale.x > 1f)
			{
				if (Input.GetButtonDown("B"))
				{
					OptionGlobals.TutorialsOff = true;
					this.TitleLabel.text = "Tutorials Disabled";
					this.TutorialLabel.text = this.DisabledString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.DisabledTexture;
					this.ShadowLabel.text = this.TutorialLabel.text;
				}
				else if (Input.GetButtonDown("A"))
				{
					this.Yandere.RPGCamera.enabled = true;
					this.Yandere.Blur.enabled = false;
					Time.timeScale = 1f;
					this.Show = false;
					this.Hide = true;
				}
			}
		}
		else if (this.Hide)
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
			if (base.transform.localScale.x < 0.1f)
			{
				base.transform.localScale = new Vector3(0f, 0f, 0f);
				this.Hide = false;
				if (OptionGlobals.TutorialsOff)
				{
					base.enabled = false;
				}
			}
		}
		if (this.Yandere.CanMove && !this.Yandere.Egg && !this.Yandere.Aiming && !this.Yandere.PauseScreen.Show && !this.Yandere.CinematicCamera.activeInHierarchy)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 5f)
			{
				if (!this.IgnoreClothing && this.ShowClothingMessage && !this.Show)
				{
					TutorialGlobals.IgnoreClothing = true;
					this.IgnoreClothing = true;
					this.TitleLabel.text = "No Spare Clothing";
					this.TutorialLabel.text = this.ClothingString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.ClothingTexture;
					this.SummonWindow();
				}
				if (!this.IgnoreCouncil && this.ShowCouncilMessage && !this.Show)
				{
					TutorialGlobals.IgnoreCouncil = true;
					this.IgnoreCouncil = true;
					this.TitleLabel.text = "Student Council";
					this.TutorialLabel.text = this.CouncilString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.CouncilTexture;
					this.SummonWindow();
				}
				if (!this.IgnoreTeacher && this.ShowTeacherMessage && !this.Show)
				{
					TutorialGlobals.IgnoreTeacher = true;
					this.IgnoreTeacher = true;
					this.TitleLabel.text = "Teachers";
					this.TutorialLabel.text = this.TeacherString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.TeacherTexture;
					this.SummonWindow();
				}
				if (!this.IgnoreLocker && this.ShowLockerMessage && !this.Show)
				{
					TutorialGlobals.IgnoreLocker = true;
					this.IgnoreLocker = true;
					this.TitleLabel.text = "Notes In Lockers";
					this.TutorialLabel.text = this.LockerString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.LockerTexture;
					this.SummonWindow();
				}
				if (!this.IgnorePolice && this.ShowPoliceMessage && !this.Show)
				{
					TutorialGlobals.IgnorePolice = true;
					this.IgnorePolice = true;
					this.TitleLabel.text = "Police";
					this.TutorialLabel.text = this.PoliceString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.PoliceTexture;
					this.SummonWindow();
				}
				if (!this.IgnoreSanity && this.ShowSanityMessage && !this.Show)
				{
					TutorialGlobals.IgnoreSanity = true;
					this.IgnoreSanity = true;
					this.TitleLabel.text = "Restoring Sanity";
					this.TutorialLabel.text = this.SanityString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.SanityTexture;
					this.SummonWindow();
				}
				if (!this.IgnoreSenpai && this.ShowSenpaiMessage && !this.Show)
				{
					TutorialGlobals.IgnoreSenpai = true;
					this.IgnoreSenpai = true;
					this.TitleLabel.text = "Your Senpai";
					this.TutorialLabel.text = this.SenpaiString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.SenpaiTexture;
					this.SummonWindow();
				}
				if (!this.IgnoreVision)
				{
					if (this.Yandere.StudentManager.WestBathroomArea.bounds.Contains(this.Yandere.transform.position) || this.Yandere.StudentManager.EastBathroomArea.bounds.Contains(this.Yandere.transform.position))
					{
						this.ShowVisionMessage = true;
					}
					if (this.ShowVisionMessage && !this.Show)
					{
						TutorialGlobals.IgnoreVision = true;
						this.IgnoreVision = true;
						this.TitleLabel.text = "Yandere Vision";
						this.TutorialLabel.text = this.VisionString;
						this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
						this.TutorialImage.mainTexture = this.VisionTexture;
						this.SummonWindow();
					}
				}
				if (!this.IgnoreWeapon)
				{
					if (this.Yandere.Armed)
					{
						this.ShowWeaponMessage = true;
					}
					if (this.ShowWeaponMessage && !this.Show)
					{
						TutorialGlobals.IgnoreWeapon = true;
						this.IgnoreWeapon = true;
						this.TitleLabel.text = "Weapons";
						this.TutorialLabel.text = this.WeaponString;
						this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
						this.TutorialImage.mainTexture = this.WeaponTexture;
						this.SummonWindow();
					}
				}
				if (!this.IgnoreBlood && this.ShowBloodMessage && !this.Show)
				{
					TutorialGlobals.IgnoreBlood = true;
					this.IgnoreBlood = true;
					this.TitleLabel.text = "Bloody Clothing";
					this.TutorialLabel.text = this.BloodString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.BloodTexture;
					this.SummonWindow();
				}
				if (!this.IgnoreClass && this.ShowClassMessage && !this.Show)
				{
					TutorialGlobals.IgnoreClass = true;
					this.IgnoreClass = true;
					this.TitleLabel.text = "Attending Class";
					this.TutorialLabel.text = this.ClassString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.ClassTexture;
					this.SummonWindow();
				}
				if (!this.IgnorePhoto)
				{
					if (this.Yandere.transform.position.z > -50f)
					{
						this.ShowPhotoMessage = true;
					}
					if (this.ShowPhotoMessage && !this.Show)
					{
						TutorialGlobals.IgnorePhoto = true;
						this.IgnorePhoto = true;
						this.TitleLabel.text = "Taking Photographs";
						this.TutorialLabel.text = this.PhotoString;
						this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
						this.TutorialImage.mainTexture = this.PhotoTexture;
						this.SummonWindow();
					}
				}
				if (!this.IgnoreClub && this.ShowClubMessage && !this.Show)
				{
					TutorialGlobals.IgnoreClub = true;
					this.IgnoreClub = true;
					this.TitleLabel.text = "Joining Clubs";
					this.TutorialLabel.text = this.ClubString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.ClubTexture;
					this.SummonWindow();
				}
				if (!this.IgnoreInfo && this.ShowInfoMessage && !this.Show)
				{
					TutorialGlobals.IgnoreInfo = true;
					this.IgnoreInfo = true;
					this.TitleLabel.text = "Info-chan's Services";
					this.TutorialLabel.text = this.InfoString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.InfoTexture;
					this.SummonWindow();
				}
				if (!this.IgnorePool && this.ShowPoolMessage && !this.Show)
				{
					TutorialGlobals.IgnorePool = true;
					this.IgnorePool = true;
					this.TitleLabel.text = "Cleaning Blood";
					this.TutorialLabel.text = this.PoolString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.PoolTexture;
					this.SummonWindow();
				}
				if (!this.IgnoreRep && this.ShowRepMessage && !this.Show)
				{
					TutorialGlobals.IgnoreRep = true;
					this.IgnoreRep = true;
					this.TitleLabel.text = "Reputation";
					this.TutorialLabel.text = this.RepString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.RepTexture;
					this.SummonWindow();
				}
			}
		}
	}

	private void SummonWindow()
	{
		this.ShadowLabel.text = this.TutorialLabel.text;
		this.Yandere.RPGCamera.enabled = false;
		this.Yandere.Blur.enabled = true;
		Time.timeScale = 0f;
		this.Show = true;
		this.Timer = 0f;
	}
}
