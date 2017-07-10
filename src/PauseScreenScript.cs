using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenScript : MonoBehaviour
{
	public StudentInfoMenuScript StudentInfoMenu;

	public InputManagerScript InputManager;

	public PhotoGalleryScript PhotoGallery;

	public HomeYandereScript HomeYandere;

	public MissionModeScript MissionMode;

	public HomeCameraScript HomeCamera;

	public FavorMenuScript FavorMenu;

	public MusicMenuScript MusicMenu;

	public PromptBarScript PromptBar;

	public PassTimeScript PassTime;

	public SettingsScript Settings;

	public TaskListScript TaskList;

	public SchemesScript Schemes;

	public YandereScript Yandere;

	public RPG_Camera RPGCamera;

	public PoliceScript Police;

	public ClockScript Clock;

	public StatsScript Stats;

	public Blur ScreenBlur;

	public UILabel SelectionLabel;

	public UIPanel Panel;

	public UISprite Wifi;

	public GameObject MissionModeIcons;

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

	public int Selected = 1;

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

	public int Row = 1;

	public int Column = 2;

	private void Start()
	{
		PlayerPrefs.SetInt("Student_0_Photographed", 1);
		PlayerPrefs.SetInt("Student_1_Photographed", 1);
		base.transform.localPosition = new Vector3(1350f, 0f, 0f);
		base.transform.localScale = new Vector3(0.9133334f, 0.9133334f, 0.9133334f);
		base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, 0f);
		this.StudentInfoMenu.gameObject.SetActive(false);
		this.PhotoGallery.gameObject.SetActive(false);
		this.FavorMenu.gameObject.SetActive(false);
		this.MusicMenu.gameObject.SetActive(false);
		this.PassTime.gameObject.SetActive(false);
		this.Settings.gameObject.SetActive(false);
		this.Stats.gameObject.SetActive(false);
		this.LoadingScreen.SetActive(false);
		this.SchemesMenu.SetActive(false);
		this.ServiceMenu.SetActive(false);
		this.StudentInfo.SetActive(false);
		this.DropsMenu.SetActive(false);
		this.MainMenu.SetActive(true);
		if (SceneManager.GetActiveScene().name.Equals("SchoolScene"))
		{
			this.Schemes.UpdateInstructions();
		}
		else
		{
			this.MissionModeIcons.SetActive(false);
			UISprite uisprite = this.PhoneIcons[5];
			uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 0.5f);
			UISprite uisprite2 = this.PhoneIcons[8];
			uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 0.5f);
		}
		if (PlayerPrefs.GetInt("MissionMode") == 1)
		{
		}
		this.UpdateSelection();
		this.CorrectingTime = false;
	}

	private void Update()
	{
		this.Speed = ((!this.Home) ? 0.166666672f : (Time.deltaTime * 10f));
		if (!this.Police.FadeOut)
		{
			if (!this.Show)
			{
				base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(1350f, 50f, 0f), this.Speed);
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(0.9133334f, 0.9133334f, 0.9133334f), this.Speed);
				base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, Mathf.Lerp(base.transform.localEulerAngles.z, 0f, this.Speed));
				if (base.transform.localPosition.x > 1349f && this.Panel.enabled)
				{
					this.Panel.enabled = false;
				}
				if (this.CorrectingTime && Time.timeScale < 0.9f)
				{
					Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, this.Speed);
					if (Time.timeScale > 0.9f)
					{
						this.CorrectingTime = false;
						Time.timeScale = 1f;
					}
				}
				if (Input.GetButtonDown("Start"))
				{
					if (!this.Home)
					{
						if (!this.Yandere.Shutter.Snapping && !this.Yandere.TimeSkipping && !this.Yandere.Talking && !this.Yandere.Noticed && !this.Yandere.InClass && !this.Yandere.Struggling && !this.Yandere.Won && !this.Yandere.Dismembering && !this.Yandere.Attacked && this.Yandere.CanMove && Time.timeScale > 0f)
						{
							this.Yandere.StopAiming();
							this.PromptParent.localScale = Vector3.zero;
							this.Yandere.Obscurance.enabled = false;
							this.Yandere.YandereVision = false;
							this.ScreenBlur.enabled = true;
							this.Yandere.YandereTimer = 0f;
							this.Yandere.Mopping = false;
							this.Panel.enabled = true;
							this.Sideways = false;
							this.Show = true;
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Accept";
							this.PromptBar.Label[1].text = "Exit";
							this.PromptBar.Label[4].text = "Choose";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
							UISprite uisprite = this.PhoneIcons[3];
							if (!this.Yandere.CanMove || this.Yandere.Dragging || (this.Police.Corpses - this.Police.HiddenCorpses > 0 && !this.Police.SuicideScene && !this.Police.PoisonScene))
							{
								uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 0.5f);
							}
							else
							{
								uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 1f);
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
						UISprite uisprite2 = this.PhoneIcons[3];
						uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 0.5f);
						this.Panel.enabled = true;
						this.Sideways = false;
						this.Show = true;
					}
				}
			}
			else
			{
				if (!this.EggsChecked)
				{
					float num = 99999f;
					for (int i = 0; i < this.Eggs.Length; i++)
					{
						if (this.Eggs[i] != null)
						{
							float num2 = Vector3.Distance(this.Yandere.transform.position, this.Eggs[i].position);
							if (num2 < num)
							{
								num = num2;
							}
						}
					}
					if (num < 5f)
					{
						this.Wifi.spriteName = "5Bars";
					}
					else if (num < 10f)
					{
						this.Wifi.spriteName = "4Bars";
					}
					else if (num < 15f)
					{
						this.Wifi.spriteName = "3Bars";
					}
					else if (num < 20f)
					{
						this.Wifi.spriteName = "2Bars";
					}
					else if (num < 25f)
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
					Time.timeScale = Mathf.Lerp(Time.timeScale, 0f, this.Speed);
					this.RPGCamera.enabled = false;
				}
				if (this.Quitting)
				{
					base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), this.Speed);
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, -1200f, 0f), this.Speed);
				}
				else if (!this.Sideways)
				{
					base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(0.9133334f, 0.9133334f, 0.9133334f), this.Speed);
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, 50f, 0f), this.Speed);
					base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, Mathf.Lerp(base.transform.localEulerAngles.z, 0f, this.Speed));
				}
				else
				{
					base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1.78f, 1.78f, 1.78f), this.Speed);
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, 14f, 0f), this.Speed);
					base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, Mathf.Lerp(base.transform.localEulerAngles.z, 90f, this.Speed));
				}
				if (this.MainMenu.activeInHierarchy && !this.Quitting)
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
					for (int j = 1; j < this.PhoneIcons.Length; j++)
					{
						if (this.PhoneIcons[j] != null)
						{
							Vector3 b = (this.Selected == j) ? new Vector3(1.5f, 1.5f, 1.5f) : new Vector3(1f, 1f, 1f);
							this.PhoneIcons[j].transform.localScale = Vector3.Lerp(this.PhoneIcons[j].transform.localScale, b, this.Speed);
						}
					}
					if (Input.GetButtonDown("A"))
					{
						this.PressedA = true;
						if (this.PhoneIcons[this.Selected].color.a == 1f)
						{
							if (this.Selected == 1)
							{
								this.MainMenu.SetActive(false);
								this.LoadingScreen.SetActive(true);
								base.StartCoroutine(this.PhotoGallery.GetPhotos());
							}
							else if (this.Selected == 2)
							{
								this.TaskList.gameObject.SetActive(true);
								this.MainMenu.SetActive(false);
								this.Sideways = true;
								this.TaskList.UpdateTaskList();
								base.StartCoroutine(this.TaskList.UpdateTaskInfo());
							}
							else if (this.Selected == 3)
							{
								if (this.PhoneIcons[3].color.a == 1f && this.Yandere.CanMove && !this.Yandere.Dragging)
								{
									for (int k = 0; k < this.Yandere.ArmedAnims.Length; k++)
									{
										this.Yandere.CharacterAnimation[this.Yandere.ArmedAnims[k]].weight = 0f;
									}
									this.MainMenu.SetActive(false);
									this.PassTime.gameObject.SetActive(true);
									this.PassTime.GetCurrentTime();
								}
							}
							else if (this.Selected == 4)
							{
								this.PromptBar.ClearButtons();
								this.PromptBar.Label[1].text = "Exit";
								this.PromptBar.UpdateButtons();
								this.Stats.gameObject.SetActive(true);
								this.Stats.UpdateStats();
								this.MainMenu.SetActive(false);
								this.Sideways = true;
							}
							else if (this.Selected == 5)
							{
								if (this.PhoneIcons[5].color.a == 1f)
								{
									this.PromptBar.ClearButtons();
									this.PromptBar.Label[0].text = "Accept";
									this.PromptBar.Label[1].text = "Exit";
									this.PromptBar.Label[5].text = "Choose";
									this.PromptBar.UpdateButtons();
									this.FavorMenu.gameObject.SetActive(true);
									this.FavorMenu.gameObject.GetComponent<AudioSource>().Play();
									this.MainMenu.SetActive(false);
									this.Sideways = true;
								}
							}
							else if (this.Selected == 6)
							{
								this.StudentInfoMenu.gameObject.SetActive(true);
								base.StartCoroutine(this.StudentInfoMenu.UpdatePortraits());
								this.MainMenu.SetActive(false);
								this.Sideways = true;
								this.PromptBar.ClearButtons();
								this.PromptBar.Label[0].text = "View Info";
								this.PromptBar.Label[1].text = "Back";
								this.PromptBar.UpdateButtons();
								this.PromptBar.Show = true;
							}
							else if (this.Selected != 7)
							{
								if (this.Selected == 8)
								{
									this.Settings.gameObject.SetActive(true);
									this.ScreenBlur.enabled = false;
									this.Settings.UpdateText();
									this.MainMenu.SetActive(false);
									this.PromptBar.ClearButtons();
									this.PromptBar.Label[1].text = "Back";
									this.PromptBar.Label[4].text = "Choose";
									this.PromptBar.Label[5].text = "Change";
									this.PromptBar.UpdateButtons();
									this.PromptBar.Show = true;
								}
								else if (this.Selected != 9)
								{
									if (this.Selected == 10)
									{
										if (PlayerPrefs.GetInt("MissionMode") == 0)
										{
											this.MusicMenu.gameObject.SetActive(true);
											this.Settings.UpdateText();
											this.MainMenu.SetActive(false);
											this.PromptBar.ClearButtons();
											this.PromptBar.Label[0].text = "Play";
											this.PromptBar.Label[1].text = "Back";
											this.PromptBar.Label[4].text = "Choose";
											this.PromptBar.UpdateButtons();
											this.PromptBar.Show = true;
										}
										else
										{
											this.PhoneIcons[this.Selected].transform.localScale = new Vector3(1f, 1f, 1f);
											this.MissionMode.ChangeMusic();
										}
									}
									else if (this.Selected == 11)
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
					if (this.PassTime.gameObject.activeInHierarchy)
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
							this.PassTime.gameObject.SetActive(false);
							this.MainMenu.SetActive(true);
							this.PromptBar.Show = false;
							this.Show = false;
							this.Clock.TargetTime = (float)this.PassTime.TargetTime;
							this.Clock.TimeSkip = true;
							Time.timeScale = 1f;
						}
						if (Input.GetButtonDown("B"))
						{
							this.MainMenu.SetActive(true);
							this.PassTime.gameObject.SetActive(false);
						}
					}
					if (this.Quitting)
					{
						if (Input.GetButtonDown("A"))
						{
							SceneManager.LoadScene("TitleScene");
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
								base.transform.localPosition = new Vector3(1350f, 0f, 0f);
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

	public void JumpToQuit()
	{
		if (!this.Police.FadeOut && !this.Clock.TimeSkip && !this.Yandere.Noticed)
		{
			base.transform.localPosition = new Vector3(0f, -1200f, 0f);
			this.Yandere.YandereVision = false;
			if (!this.Yandere.Talking && !this.Yandere.Dismembering)
			{
				this.RPGCamera.enabled = false;
				this.Yandere.StopAiming();
			}
			this.ScreenBlur.enabled = true;
			this.Panel.enabled = true;
			this.BypassPhone = true;
			this.Quitting = true;
			this.Show = true;
		}
	}

	private void ExitPhone()
	{
		if (!this.Home)
		{
			this.PromptParent.localScale = new Vector3(1f, 1f, 1f);
			this.ScreenBlur.enabled = false;
			this.CorrectingTime = true;
			if (!this.Yandere.Talking && !this.Yandere.Dismembering)
			{
				this.RPGCamera.enabled = true;
			}
			if (this.Yandere.Laughing)
			{
				this.Yandere.GetComponent<AudioSource>().volume = 1f;
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

	private void UpdateSelection()
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
		this.SelectionLabel.text = this.SelectionNames[this.Selected];
	}
}
