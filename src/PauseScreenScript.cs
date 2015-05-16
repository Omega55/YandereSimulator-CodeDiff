using System;
using UnityEngine;

[Serializable]
public class PauseScreenScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public PhotoGalleryScript PhotoGallery;

	public FavorMenuScript FavorMenu;

	public PassTimeScript PassTime;

	public YandereScript Yandere;

	public RPG_Camera RPGCamera;

	public PoliceScript Police;

	public ClockScript Clock;

	public Blur ScreenBlur;

	public UILabel PassTimeLabel;

	public GameObject LoadingScreen;

	public GameObject StudentInfo;

	public GameObject MainMenu;

	public Transform PromptParent;

	public Transform Highlight;

	public int Selected;

	public bool CorrectingTime;

	public bool BypassPhone;

	public bool PressedA;

	public bool Quitting;

	public bool Sideways;

	public bool Show;

	public PauseScreenScript()
	{
		this.Selected = 1;
	}

	public virtual void Start()
	{
		this.transform.localPosition = new Vector3((float)1350, (float)0, (float)0);
		this.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		int num = 0;
		Vector3 localEulerAngles = this.transform.localEulerAngles;
		float num2 = localEulerAngles.z = (float)num;
		Vector3 vector = this.transform.localEulerAngles = localEulerAngles;
		this.LoadingScreen.active = false;
		this.PhotoGallery.active = false;
		this.StudentInfo.active = false;
		this.FavorMenu.active = false;
		this.PassTime.active = false;
		this.MainMenu.active = true;
		this.CorrectingTime = false;
		Time.timeScale = (float)0;
	}

	public virtual void Update()
	{
		if (!this.Police.FadeOut)
		{
			if (!this.Show)
			{
				this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3((float)1350, (float)0, (float)0), 0.166666672f);
				this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), 0.166666672f);
				float z = Mathf.Lerp(this.transform.localEulerAngles.z, (float)0, 0.166666672f);
				Vector3 localEulerAngles = this.transform.localEulerAngles;
				float num = localEulerAngles.z = z;
				Vector3 vector = this.transform.localEulerAngles = localEulerAngles;
				if (this.CorrectingTime && Time.timeScale < 0.9f)
				{
					Time.timeScale = Mathf.Lerp(Time.timeScale, (float)1, 0.166666672f);
					if (Time.timeScale > 0.9f)
					{
						this.CorrectingTime = false;
						Time.timeScale = (float)1;
					}
				}
				if (Input.GetButtonDown("Start") && !this.Yandere.Shutter.Snapping && !this.Yandere.TimeSkipping && !this.Yandere.Talking && !this.Yandere.Noticed && !this.Yandere.InClass && Time.timeScale > (float)0)
				{
					this.Yandere.StopAiming();
					this.PromptParent.localScale = new Vector3((float)0, (float)0, (float)0);
					this.Yandere.Obscurance.enabled = false;
					this.Yandere.YandereVision = false;
					this.ScreenBlur.enabled = true;
					this.Yandere.YandereTimer = (float)0;
					this.Yandere.Mopping = false;
					this.Show = true;
					if (!this.Yandere.CanMove || this.Yandere.Dragging || this.Police.Corpses > 0)
					{
						float a = 0.5f;
						Color color = this.PassTimeLabel.color;
						float num2 = color.a = a;
						Color color2 = this.PassTimeLabel.color = color;
					}
					else
					{
						int num3 = 1;
						Color color3 = this.PassTimeLabel.color;
						float num4 = color3.a = (float)num3;
						Color color4 = this.PassTimeLabel.color = color3;
					}
				}
			}
			else
			{
				this.RPGCamera.enabled = false;
				if (!this.Quitting)
				{
					this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3((float)0, (float)0, (float)0), 0.166666672f);
				}
				else
				{
					this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3((float)0, (float)-1200, (float)0), 0.166666672f);
				}
				if (!this.Sideways)
				{
					this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), 0.166666672f);
					float z2 = Mathf.Lerp(this.transform.localEulerAngles.z, (float)0, 0.166666672f);
					Vector3 localEulerAngles2 = this.transform.localEulerAngles;
					float num5 = localEulerAngles2.z = z2;
					Vector3 vector2 = this.transform.localEulerAngles = localEulerAngles2;
				}
				else
				{
					this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1.78f, 1.78f, (float)1), 0.166666672f);
					float z3 = Mathf.Lerp(this.transform.localEulerAngles.z, (float)90, 0.166666672f);
					Vector3 localEulerAngles3 = this.transform.localEulerAngles;
					float num6 = localEulerAngles3.z = z3;
					Vector3 vector3 = this.transform.localEulerAngles = localEulerAngles3;
				}
				Time.timeScale = Mathf.Lerp(Time.timeScale, (float)0, 0.166666672f);
				if (this.MainMenu.active && !this.Quitting)
				{
					if (this.InputManager.TappedUp || Input.GetKeyDown("w") || Input.GetKeyDown("up"))
					{
						this.Selected--;
						if (this.Selected < 1)
						{
							this.Selected = 9;
						}
						int num7 = 325 - 75 * this.Selected;
						Vector3 localPosition = this.Highlight.localPosition;
						float num8 = localPosition.y = (float)num7;
						Vector3 vector4 = this.Highlight.localPosition = localPosition;
					}
					if (this.InputManager.TappedDown || Input.GetKeyDown("s") || Input.GetKeyDown("down"))
					{
						this.Selected++;
						if (this.Selected > 9)
						{
							this.Selected = 1;
						}
						int num9 = 325 - 75 * this.Selected;
						Vector3 localPosition2 = this.Highlight.localPosition;
						float num10 = localPosition2.y = (float)num9;
						Vector3 vector5 = this.Highlight.localPosition = localPosition2;
					}
					if (Input.GetButtonDown("A"))
					{
						this.PressedA = true;
						if (this.Selected == 1)
						{
							this.ExitPhone();
						}
						else if (this.Selected == 2)
						{
							if (this.PassTimeLabel.color.a == (float)1 && this.Yandere.CanMove && !this.Yandere.Dragging)
							{
								this.MainMenu.active = false;
								this.PassTime.active = true;
								this.PassTime.GetCurrentTime();
							}
						}
						else if (this.Selected == 4)
						{
							this.MainMenu.active = false;
							this.LoadingScreen.active = true;
							this.StartCoroutine_Auto(this.PhotoGallery.GetPhotos());
						}
						else if (this.Selected == 5)
						{
							this.FavorMenu.UpdatePantyShots();
							this.FavorMenu.active = true;
							this.MainMenu.active = false;
							this.Sideways = true;
						}
						else if (this.Selected == 9)
						{
							this.Quitting = true;
						}
					}
					if (Input.GetButtonDown("Start") || Input.GetButtonDown("B"))
					{
						this.ExitPhone();
					}
				}
				if (!this.PressedA)
				{
					if (this.PassTime.active)
					{
						if (Input.GetButtonDown("A"))
						{
							if (this.Yandere.PickUp != null)
							{
								this.Yandere.PickUp.Drop();
							}
							this.Yandere.Unequip();
							this.ScreenBlur.enabled = false;
							this.RPGCamera.enabled = true;
							this.PassTime.active = false;
							this.MainMenu.active = true;
							this.Show = false;
							this.Clock.TargetTime = (float)this.PassTime.TargetTime;
							this.Clock.TimeSkip = true;
							Time.timeScale = (float)1;
						}
						if (Input.GetButtonDown("B"))
						{
							this.MainMenu.active = true;
							this.PassTime.active = false;
						}
					}
					if (this.PhotoGallery.active && !this.PhotoGallery.Viewing && Input.GetButtonDown("B"))
					{
						this.MainMenu.active = true;
						this.PhotoGallery.active = false;
						this.Sideways = false;
					}
					if (this.Quitting)
					{
						if (Input.GetButtonDown("A"))
						{
							PlayerPrefs.SetInt("Weekday", 5);
							Application.Quit();
						}
						if (Input.GetButtonDown("B"))
						{
							this.Quitting = false;
							if (this.BypassPhone)
							{
								this.transform.localPosition = new Vector3((float)1350, (float)0, (float)0);
								this.ExitPhone();
							}
						}
					}
				}
				if (Input.GetButtonUp("A"))
				{
					this.PressedA = false;
				}
			}
		}
	}

	public virtual void JumpToQuit()
	{
		if (!this.Police.FadeOut && !this.Clock.TimeSkip && !this.Yandere.Noticed)
		{
			this.transform.localPosition = new Vector3((float)0, (float)-1200, (float)0);
			this.Yandere.YandereVision = false;
			if (!this.Yandere.Talking)
			{
				this.RPGCamera.enabled = false;
				this.Yandere.StopAiming();
			}
			this.ScreenBlur.enabled = true;
			this.BypassPhone = true;
			this.Quitting = true;
			this.Show = true;
		}
	}

	public virtual void ExitPhone()
	{
		this.PromptParent.localScale = new Vector3((float)1, (float)1, (float)1);
		this.ScreenBlur.enabled = false;
		this.CorrectingTime = true;
		this.BypassPhone = false;
		this.PressedA = false;
		this.Show = false;
		if (!this.Yandere.Talking)
		{
			this.RPGCamera.enabled = true;
		}
		if (this.Yandere.Laughing)
		{
			this.Yandere.audio.volume = (float)1;
		}
	}

	public virtual void Main()
	{
	}
}
