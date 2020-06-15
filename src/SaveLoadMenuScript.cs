using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadMenuScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public GameObject ConfirmWindow;

	public GameObject WarningWindow;

	public ClockScript Clock;

	public Texture DefaultThumbnail;

	public UILabel AreYouSureLabel;

	public UILabel Header;

	public UITexture[] Thumbnails;

	public UILabel[] DataLabels;

	public Transform Highlight;

	public Camera UICamera;

	public bool GrabScreenshot;

	public bool Loading;

	public bool Saving;

	public int Profile;

	public int Row = 1;

	public int Column = 1;

	public int Selected = 1;

	public void Start()
	{
		if (GameGlobals.Profile == 0)
		{
			GameGlobals.Profile = 1;
		}
		this.Profile = GameGlobals.Profile;
		this.WarningWindow.SetActive(true);
		this.ConfirmWindow.SetActive(false);
		base.StartCoroutine(this.GetThumbnails());
	}

	public void Update()
	{
		if (!this.ConfirmWindow.activeInHierarchy)
		{
			if (this.InputManager.TappedUp)
			{
				this.Row--;
				this.UpdateHighlight();
			}
			else if (this.InputManager.TappedDown)
			{
				this.Row++;
				this.UpdateHighlight();
			}
			if (this.InputManager.TappedLeft)
			{
				this.Column--;
				this.UpdateHighlight();
			}
			else if (this.InputManager.TappedRight)
			{
				this.Column++;
				this.UpdateHighlight();
			}
		}
		if (this.GrabScreenshot)
		{
			if (GameGlobals.Profile == 0)
			{
				GameGlobals.Profile = 1;
				this.Profile = 1;
			}
			this.PauseScreen.ScreenBlur.enabled = true;
			this.UICamera.enabled = true;
			this.StudentManager.Save();
			base.StartCoroutine(this.GetThumbnails());
			if (DateGlobals.Weekday == DayOfWeek.Monday)
			{
				PlayerPrefs.SetInt(string.Concat(new object[]
				{
					"Profile_",
					this.Profile,
					"_Slot_",
					this.Selected,
					"_Weekday"
				}), 1);
			}
			else if (DateGlobals.Weekday == DayOfWeek.Tuesday)
			{
				PlayerPrefs.SetInt(string.Concat(new object[]
				{
					"Profile_",
					this.Profile,
					"_Slot_",
					this.Selected,
					"_Weekday"
				}), 2);
			}
			else if (DateGlobals.Weekday == DayOfWeek.Wednesday)
			{
				PlayerPrefs.SetInt(string.Concat(new object[]
				{
					"Profile_",
					this.Profile,
					"_Slot_",
					this.Selected,
					"_Weekday"
				}), 3);
			}
			else if (DateGlobals.Weekday == DayOfWeek.Thursday)
			{
				PlayerPrefs.SetInt(string.Concat(new object[]
				{
					"Profile_",
					this.Profile,
					"_Slot_",
					this.Selected,
					"_Weekday"
				}), 4);
			}
			else if (DateGlobals.Weekday == DayOfWeek.Friday)
			{
				PlayerPrefs.SetInt(string.Concat(new object[]
				{
					"Profile_",
					this.Profile,
					"_Slot_",
					this.Selected,
					"_Weekday"
				}), 5);
			}
			this.GrabScreenshot = false;
		}
		if (this.WarningWindow.activeInHierarchy)
		{
			if (Input.GetButtonDown("A"))
			{
				this.WarningWindow.SetActive(false);
				return;
			}
			if (Input.GetButtonDown("B"))
			{
				this.PauseScreen.MainMenu.SetActive(true);
				this.PauseScreen.Sideways = false;
				this.PauseScreen.PressedB = true;
				base.gameObject.SetActive(false);
				this.PauseScreen.PromptBar.ClearButtons();
				this.PauseScreen.PromptBar.Label[0].text = "Accept";
				this.PauseScreen.PromptBar.Label[1].text = "Exit";
				this.PauseScreen.PromptBar.Label[4].text = "Choose";
				this.PauseScreen.PromptBar.UpdateButtons();
				this.PauseScreen.PromptBar.Show = true;
				return;
			}
		}
		else
		{
			if (Input.GetButtonDown("A"))
			{
				if (this.Loading)
				{
					if (this.DataLabels[this.Selected].text != "No Data")
					{
						if (!this.ConfirmWindow.activeInHierarchy)
						{
							this.AreYouSureLabel.text = "Are you sure you'd like to load?";
							this.ConfirmWindow.SetActive(true);
						}
						else if (this.DataLabels[this.Selected].text != "No Data")
						{
							PlayerPrefs.SetInt("LoadingSave", 1);
							PlayerPrefs.SetInt("SaveSlot", this.Selected);
							YanSave.LoadPrefs(string.Concat(new object[]
							{
								"Profile_",
								GameGlobals.Profile,
								"_Slot_",
								this.Selected
							}));
							SceneManager.LoadScene("LoadingScene");
						}
					}
				}
				else if (this.Saving)
				{
					if (!this.ConfirmWindow.activeInHierarchy)
					{
						this.AreYouSureLabel.text = "Are you sure you'd like to save?";
						this.ConfirmWindow.SetActive(true);
					}
					else
					{
						this.ConfirmWindow.SetActive(false);
						PlayerPrefs.SetInt("SaveSlot", this.Selected);
						GameGlobals.MostRecentSlot = this.Selected;
						PlayerPrefs.SetString(string.Concat(new object[]
						{
							"Profile_",
							this.Profile,
							"_Slot_",
							this.Selected,
							"_DateTime"
						}), DateTime.Now.ToString());
						ScreenCapture.CaptureScreenshot(string.Concat(new object[]
						{
							Application.streamingAssetsPath,
							"/SaveData/Profile_",
							this.Profile,
							"/Slot_",
							this.Selected,
							"_Thumbnail.png"
						}));
						this.PauseScreen.ScreenBlur.enabled = false;
						this.UICamera.enabled = false;
						this.GrabScreenshot = true;
					}
				}
			}
			if (Input.GetButtonDown("X"))
			{
				if (this.Loading)
				{
					if (this.DataLabels[this.Selected].text != "No Data")
					{
						PlayerPrefs.SetInt("SaveSlot", this.Selected);
						this.StudentManager.Load();
						Physics.SyncTransforms();
						if (PlayerPrefs.GetInt(string.Concat(new object[]
						{
							"Profile_",
							this.Profile,
							"_Slot_",
							this.Selected,
							"_Weekday"
						})) == 1)
						{
							DateGlobals.Weekday = DayOfWeek.Monday;
						}
						else if (PlayerPrefs.GetInt(string.Concat(new object[]
						{
							"Profile_",
							this.Profile,
							"_Slot_",
							this.Selected,
							"_Weekday"
						})) == 2)
						{
							DateGlobals.Weekday = DayOfWeek.Tuesday;
						}
						else if (PlayerPrefs.GetInt(string.Concat(new object[]
						{
							"Profile_",
							this.Profile,
							"_Slot_",
							this.Selected,
							"_Weekday"
						})) == 3)
						{
							DateGlobals.Weekday = DayOfWeek.Wednesday;
						}
						else if (PlayerPrefs.GetInt(string.Concat(new object[]
						{
							"Profile_",
							this.Profile,
							"_Slot_",
							this.Selected,
							"_Weekday"
						})) == 4)
						{
							DateGlobals.Weekday = DayOfWeek.Tuesday;
						}
						else if (PlayerPrefs.GetInt(string.Concat(new object[]
						{
							"Profile_",
							this.Profile,
							"_Slot_",
							this.Selected,
							"_Weekday"
						})) == 5)
						{
							DateGlobals.Weekday = DayOfWeek.Wednesday;
						}
						this.Clock.DayLabel.text = this.Clock.GetWeekdayText(DateGlobals.Weekday);
						this.PauseScreen.MainMenu.SetActive(true);
						this.PauseScreen.Sideways = false;
						this.PauseScreen.PressedB = true;
						base.gameObject.SetActive(false);
						this.PauseScreen.ExitPhone();
					}
				}
				else if (this.Saving && PlayerPrefs.GetString(string.Concat(new object[]
				{
					"Profile_",
					this.Profile,
					"_Slot_",
					this.Selected,
					"_DateTime"
				})) != "")
				{
					File.Delete(string.Concat(new object[]
					{
						Application.streamingAssetsPath,
						"/SaveData/Profile_",
						this.Profile,
						"/Slot_",
						this.Selected,
						"_Thumbnail.png"
					}));
					PlayerPrefs.SetString(string.Concat(new object[]
					{
						"Profile_",
						this.Profile,
						"_Slot_",
						this.Selected,
						"_DateTime"
					}), "");
					this.Thumbnails[this.Selected].mainTexture = this.DefaultThumbnail;
					this.DataLabels[this.Selected].text = "No Data";
				}
			}
			if (Input.GetButtonDown("B"))
			{
				if (this.ConfirmWindow.activeInHierarchy)
				{
					this.ConfirmWindow.SetActive(false);
					return;
				}
				this.PauseScreen.MainMenu.SetActive(true);
				this.PauseScreen.Sideways = false;
				this.PauseScreen.PressedB = true;
				base.gameObject.SetActive(false);
				this.PauseScreen.PromptBar.ClearButtons();
				this.PauseScreen.PromptBar.Label[0].text = "Accept";
				this.PauseScreen.PromptBar.Label[1].text = "Exit";
				this.PauseScreen.PromptBar.Label[4].text = "Choose";
				this.PauseScreen.PromptBar.UpdateButtons();
				this.PauseScreen.PromptBar.Show = true;
			}
		}
	}

	public IEnumerator GetThumbnails()
	{
		int num;
		for (int ID = 1; ID < 11; ID = num + 1)
		{
			if (PlayerPrefs.GetString(string.Concat(new object[]
			{
				"Profile_",
				this.Profile,
				"_Slot_",
				ID,
				"_DateTime"
			})) != "")
			{
				this.DataLabels[ID].text = PlayerPrefs.GetString(string.Concat(new object[]
				{
					"Profile_",
					this.Profile,
					"_Slot_",
					ID,
					"_DateTime"
				}));
				string url = string.Concat(new object[]
				{
					"file:///",
					Application.streamingAssetsPath,
					"/SaveData/Profile_",
					this.Profile,
					"/Slot_",
					ID,
					"_Thumbnail.png"
				});
				WWW www = new WWW(url);
				yield return www;
				if (www.error == null)
				{
					this.Thumbnails[ID].mainTexture = www.texture;
				}
				else
				{
					Debug.Log("Could not retrieve the thumbnail. Maybe it was deleted from Streaming Assets?");
				}
				www = null;
			}
			else
			{
				this.DataLabels[ID].text = "No Data";
			}
			num = ID;
		}
		yield break;
	}

	public void UpdateHighlight()
	{
		if (this.Row < 1)
		{
			this.Row = 2;
		}
		else if (this.Row > 2)
		{
			this.Row = 1;
		}
		if (this.Column < 1)
		{
			this.Column = 5;
		}
		else if (this.Column > 5)
		{
			this.Column = 1;
		}
		this.Highlight.localPosition = new Vector3((float)(-510 + 170 * this.Column), (float)(313 - 226 * this.Row), this.Highlight.localPosition.z);
		this.Selected = this.Column + (this.Row - 1) * 5;
	}
}
