using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class PauseScreenScript : MonoBehaviour
{
	public StudentInfoMenuScript StudentInfoMenu;

	public InputManagerScript InputManager;

	public PhotoGalleryScript PhotoGallery;

	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public FavorMenuScript FavorMenu;

	public PromptBarScript PromptBar;

	public PassTimeScript PassTime;

	public TaskListScript TaskList;

	public SchemesScript Schemes;

	public YandereScript Yandere;

	public RPG_Camera RPGCamera;

	public PoliceScript Police;

	public ClockScript Clock;

	public StatsScript Stats;

	public Blur ScreenBlur;

	public UILabel SelectionLabel;

	public UISprite Wifi;

	public GameObject LoadingScreen;

	public GameObject SchemesMenu;

	public GameObject ServiceMenu;

	public GameObject StudentInfo;

	public GameObject DropsMenu;

	public GameObject MainMenu;

	public Transform PromptParent;

	public string[] SelectionNames;

	public UISprite[] PhoneIcons;

	public Transform[] Eggs;

	public int Selected;

	public float Speed;

	public bool CorrectingTime;

	public bool BypassPhone;

	public bool EggsChecked;

	public bool PressedA;

	public bool PressedB;

	public bool Quitting;

	public bool Sideways;

	public bool Home;

	public bool Show;

	public int Row;

	public int Column;

	public PauseScreenScript()
	{
		this.Selected = 1;
		this.Row = 1;
		this.Column = 2;
	}

	public virtual void Start()
	{
		PlayerPrefs.SetInt("Student_0_Photographed", 1);
		PlayerPrefs.SetInt("Student_1_Photographed", 1);
		this.transform.localPosition = new Vector3((float)1350, (float)0, (float)0);
		this.transform.localScale = new Vector3(0.9133334f, 0.9133334f, 0.9133334f);
		int num = 0;
		Vector3 localEulerAngles = this.transform.localEulerAngles;
		float num2 = localEulerAngles.z = (float)num;
		Vector3 vector = this.transform.localEulerAngles = localEulerAngles;
		this.StudentInfoMenu.gameObject.active = false;
		this.PhotoGallery.gameObject.active = false;
		this.FavorMenu.gameObject.active = false;
		this.PassTime.gameObject.active = false;
		this.Stats.gameObject.active = false;
		this.LoadingScreen.active = false;
		this.SchemesMenu.active = false;
		this.ServiceMenu.active = false;
		this.StudentInfo.active = false;
		this.DropsMenu.active = false;
		this.MainMenu.active = true;
		if (Application.loadedLevelName == "SchoolScene")
		{
			this.Schemes.UpdateInstructions();
		}
		this.UpdateSelection();
		this.CorrectingTime = false;
	}

	public virtual void Update()
	{
		if (!this.Home)
		{
			this.Speed = 0.166666672f;
		}
		else
		{
			this.Speed = Time.deltaTime * (float)10;
		}
		if (!this.Police.FadeOut)
		{
			if (!this.Show)
			{
				this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3((float)1350, (float)50, (float)0), this.Speed);
				this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(0.9133334f, 0.9133334f, 0.9133334f), this.Speed);
				float z = Mathf.Lerp(this.transform.localEulerAngles.z, (float)0, this.Speed);
				Vector3 localEulerAngles = this.transform.localEulerAngles;
				float num = localEulerAngles.z = z;
				Vector3 vector = this.transform.localEulerAngles = localEulerAngles;
				if (this.CorrectingTime && Time.timeScale < 0.9f)
				{
					Time.timeScale = Mathf.Lerp(Time.timeScale, (float)1, this.Speed);
					if (Time.timeScale > 0.9f)
					{
						this.CorrectingTime = false;
						Time.timeScale = (float)1;
					}
				}
				if (Input.GetButtonDown("Start"))
				{
					if (!this.Home)
					{
						if (!this.Yandere.Shutter.Snapping && !this.Yandere.TimeSkipping && !this.Yandere.Talking && !this.Yandere.Noticed && !this.Yandere.InClass && !this.Yandere.Struggling && !this.Yandere.Won && !this.Yandere.Dismembering && Time.timeScale > (float)0)
						{
							this.Yandere.StopAiming();
							this.PromptParent.localScale = new Vector3((float)0, (float)0, (float)0);
							this.Yandere.Obscurance.enabled = false;
							this.Yandere.YandereVision = false;
							this.ScreenBlur.enabled = true;
							this.Yandere.YandereTimer = (float)0;
							this.Yandere.Mopping = false;
							this.Sideways = false;
							this.Show = true;
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Accept";
							this.PromptBar.Label[1].text = "Exit";
							this.PromptBar.Label[4].text = "Choose";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
							if (!this.Yandere.CanMove || this.Yandere.Dragging || (this.Police.Corpses - this.Police.HiddenCorpses > 0 && !this.Police.SuicideScene && !this.Police.PoisonScene))
							{
								float a = 0.5f;
								Color color = this.PhoneIcons[3].color;
								float num2 = color.a = a;
								Color color2 = this.PhoneIcons[3].color = color;
							}
							else
							{
								int num3 = 1;
								Color color3 = this.PhoneIcons[3].color;
								float num4 = color3.a = (float)num3;
								Color color4 = this.PhoneIcons[3].color = color3;
							}
						}
					}
					else if (this.HomeCamera.Destination == this.HomeCamera.Destinations[0])
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[0].text = "Accept";
						this.PromptBar.Label[1].text = "Exit";
						this.PromptBar.Label[4].text = "Choose";
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = true;
						this.HomeYandere.CanMove = false;
						float a2 = 0.5f;
						Color color5 = this.PhoneIcons[3].color;
						float num5 = color5.a = a2;
						Color color6 = this.PhoneIcons[3].color = color5;
						this.Sideways = false;
						this.Show = true;
					}
				}
			}
			else
			{
				if (!this.EggsChecked)
				{
					int num6 = 99999;
					for (int i = 0; i < Extensions.get_length(this.Eggs); i++)
					{
						if (this.Eggs[i] != null)
						{
							float num7 = Vector3.Distance(this.Yandere.transform.position, this.Eggs[i].position);
							if (num7 < (float)num6)
							{
								num6 = (int)num7;
							}
						}
					}
					if (num6 < 5)
					{
						this.Wifi.spriteName = "5Bars";
					}
					else if (num6 < 10)
					{
						this.Wifi.spriteName = "4Bars";
					}
					else if (num6 < 15)
					{
						this.Wifi.spriteName = "3Bars";
					}
					else if (num6 < 20)
					{
						this.Wifi.spriteName = "2Bars";
					}
					else if (num6 < 25)
					{
						this.Wifi.spriteName = "1Bars";
					}
					else
					{
						this.Wifi.spriteName = "0Bars";
					}
					this.EggsChecked = true;
				}
				if (!this.Home)
				{
					Time.timeScale = Mathf.Lerp(Time.timeScale, (float)0, this.Speed);
					this.RPGCamera.enabled = false;
				}
				if (this.Quitting)
				{
					this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), this.Speed);
					this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3((float)0, (float)-1200, (float)0), this.Speed);
				}
				else if (!this.Sideways)
				{
					this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(0.9133334f, 0.9133334f, 0.9133334f), this.Speed);
					this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3((float)0, (float)50, (float)0), this.Speed);
					float z2 = Mathf.Lerp(this.transform.localEulerAngles.z, (float)0, this.Speed);
					Vector3 localEulerAngles2 = this.transform.localEulerAngles;
					float num8 = localEulerAngles2.z = z2;
					Vector3 vector2 = this.transform.localEulerAngles = localEulerAngles2;
				}
				else
				{
					this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1.78f, 1.78f, 1.78f), this.Speed);
					this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3((float)0, (float)14, (float)0), this.Speed);
					float z3 = Mathf.Lerp(this.transform.localEulerAngles.z, (float)90, this.Speed);
					Vector3 localEulerAngles3 = this.transform.localEulerAngles;
					float num9 = localEulerAngles3.z = z3;
					Vector3 vector3 = this.transform.localEulerAngles = localEulerAngles3;
				}
				if (this.MainMenu.active && !this.Quitting)
				{
					if (this.InputManager.TappedUp || Input.GetKeyDown("w") || Input.GetKeyDown("up"))
					{
						this.Row--;
						this.UpdateSelection();
					}
					if (this.InputManager.TappedDown || Input.GetKeyDown("s") || Input.GetKeyDown("down"))
					{
						this.Row++;
						this.UpdateSelection();
					}
					if (this.InputManager.TappedRight || Input.GetKeyDown("d") || Input.GetKeyDown("right"))
					{
						this.Column++;
						this.UpdateSelection();
					}
					if (this.InputManager.TappedLeft || Input.GetKeyDown("a") || Input.GetKeyDown("left"))
					{
						this.Column--;
						this.UpdateSelection();
					}
					for (int i = 1; i < Extensions.get_length(this.PhoneIcons); i++)
					{
						if (this.PhoneIcons[i] != null)
						{
							if (this.Selected != i)
							{
								this.PhoneIcons[i].transform.localScale = Vector3.Lerp(this.PhoneIcons[i].transform.localScale, new Vector3((float)1, (float)1, (float)1), this.Speed);
							}
							else
							{
								this.PhoneIcons[i].transform.localScale = Vector3.Lerp(this.PhoneIcons[i].transform.localScale, new Vector3(1.5f, 1.5f, 1.5f), this.Speed);
							}
						}
					}
					if (Input.GetButtonDown("A"))
					{
						this.PressedA = true;
						if (this.Selected == 1)
						{
							this.MainMenu.active = false;
							this.LoadingScreen.active = true;
							this.StartCoroutine_Auto(this.PhotoGallery.GetPhotos());
						}
						else if (this.Selected == 2)
						{
							this.TaskList.gameObject.active = true;
							this.MainMenu.active = false;
							this.Sideways = true;
							this.TaskList.UpdateTaskList();
							this.StartCoroutine_Auto(this.TaskList.UpdateTaskInfo());
						}
						else if (this.Selected == 3)
						{
							if (this.PhoneIcons[3].color.a == (float)1 && this.Yandere.CanMove && !this.Yandere.Dragging)
							{
								this.MainMenu.active = false;
								this.PassTime.active = true;
								this.PassTime.GetCurrentTime();
							}
						}
						else if (this.Selected == 4)
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[1].text = "Exit";
							this.PromptBar.UpdateButtons();
							this.Stats.gameObject.active = true;
							this.Stats.UpdateStats();
							this.MainMenu.active = false;
							this.Sideways = true;
						}
						else if (this.Selected == 5)
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Accept";
							this.PromptBar.Label[1].text = "Exit";
							this.PromptBar.Label[5].text = "Choose";
							this.PromptBar.UpdateButtons();
							this.FavorMenu.gameObject.active = true;
							this.FavorMenu.gameObject.audio.Play();
							this.MainMenu.active = false;
							this.Sideways = true;
						}
						else if (this.Selected == 6)
						{
							this.StudentInfoMenu.gameObject.active = true;
							this.StartCoroutine_Auto(this.StudentInfoMenu.UpdatePortraits());
							this.MainMenu.active = false;
							this.Sideways = true;
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "View Info";
							this.PromptBar.Label[1].text = "Back";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
						}
						else if (this.Selected != 7)
						{
							if (this.Selected != 8)
							{
								if (this.Selected != 9)
								{
									if (this.Selected != 10)
									{
										if (this.Selected == 11)
										{
											this.PromptBar.ClearButtons();
											this.PromptBar.Show = false;
											this.Quitting = true;
										}
										else if (this.Selected == 12)
										{
										}
									}
								}
							}
						}
					}
					if (!this.PressedB && (Input.GetButtonDown("Start") || Input.GetButtonDown("B")))
					{
						this.ExitPhone();
					}
					if (Input.GetButtonUp("B"))
					{
						this.PressedB = false;
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
							this.PromptBar.Show = false;
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
					if (this.Quitting)
					{
						if (Input.GetButtonDown("A"))
						{
							Application.LoadLevel("TitleScene");
						}
						if (Input.GetButtonDown("B"))
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Accept";
							this.PromptBar.Label[1].text = "Exit";
							this.PromptBar.Label[4].text = "Choose";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
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
			if (!this.Yandere.Talking && !this.Yandere.Dismembering)
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
		if (!this.Home)
		{
			this.PromptParent.localScale = new Vector3((float)1, (float)1, (float)1);
			this.ScreenBlur.enabled = false;
			this.CorrectingTime = true;
			if (!this.Yandere.Talking && !this.Yandere.Dismembering)
			{
				this.RPGCamera.enabled = true;
			}
			if (this.Yandere.Laughing)
			{
				this.Yandere.audio.volume = (float)1;
			}
		}
		else
		{
			this.HomeYandere.CanMove = true;
		}
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
		this.BypassPhone = false;
		this.EggsChecked = false;
		this.PressedA = false;
		this.Show = false;
	}

	public virtual void UpdateSelection()
	{
		if (this.Row < 0)
		{
			this.Row = 3;
		}
		else if (this.Row > 3)
		{
			this.Row = 0;
		}
		if (this.Column < 1)
		{
			this.Column = 3;
		}
		else if (this.Column > 3)
		{
			this.Column = 1;
		}
		this.Selected = this.Row * 3 + this.Column;
		this.SelectionLabel.text = string.Empty + this.SelectionNames[this.Selected];
	}

	public virtual void Main()
	{
	}
}
