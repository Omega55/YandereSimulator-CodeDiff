﻿using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ShutterScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public PauseScreenScript PauseScreen;

	public StudentInfoScript StudentInfo;

	public StudentScript Student;

	public YandereScript Yandere;

	public RenderTexture SmartphoneScreen;

	public Camera SmartphoneCamera;

	public Transform TextMessages;

	public Transform ErrorWindow;

	public Camera MainCamera;

	public UISprite Sprite;

	public GameObject HeartbeatCamera;

	public GameObject CameraButtons;

	public GameObject NewMessage;

	public GameObject PhotoIcons;

	public GameObject MainMenu;

	public GameObject Message;

	public GameObject Panel;

	public GameObject ViolenceX;

	public GameObject PantiesX;

	public GameObject SenpaiX;

	public GameObject InfoX;

	public bool DisplayError;

	public bool FreeSpace;

	public bool TakePhoto;

	public bool TookPhoto;

	public bool Snapping;

	public bool Close;

	public bool NotFace;

	public bool Skirt;

	public RaycastHit hit;

	public float Timer;

	public int Frame;

	public int Slot;

	public int ID;

	public int OnlyPhotography;

	public int OnlyCharacters;

	public int OnlyRagdolls;

	public int OnlyBlood;

	public ShutterScript()
	{
		this.OnlyPhotography = 65537;
		this.OnlyCharacters = 257;
		this.OnlyRagdolls = 2049;
		this.OnlyBlood = 16385;
	}

	public virtual void Start()
	{
		this.ErrorWindow.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		this.CameraButtons.active = false;
		this.PhotoIcons.active = false;
		int num = 0;
		Color color = this.Sprite.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Sprite.color = color;
		this.OnlyPhotography = 65537;
		this.OnlyCharacters = 513;
		this.OnlyRagdolls = 2049;
		this.OnlyBlood = 16385;
	}

	public virtual void Update()
	{
		Debug.DrawRay(this.SmartphoneCamera.transform.position, this.SmartphoneCamera.transform.TransformDirection(Vector3.forward), Color.green);
		if (this.Snapping)
		{
			if (this.Close)
			{
				this.Frame++;
				this.Sprite.spriteName = "Shutter" + this.Frame;
				if (this.Frame == 8)
				{
					this.StudentManager.GhostChan.active = true;
					this.StudentManager.GhostChan.Look();
					this.CheckPhoto();
					this.SmartphoneCamera.targetTexture = null;
					this.HeartbeatCamera.active = false;
					this.CameraButtons.active = true;
					this.MainCamera.enabled = false;
					this.PhotoIcons.active = true;
					this.Panel.active = false;
					this.Close = false;
					Time.timeScale = (float)0;
				}
			}
			else
			{
				this.Frame--;
				this.Sprite.spriteName = "Shutter" + this.Frame;
				if (this.Frame == 1)
				{
					int num = 0;
					Color color = this.Sprite.color;
					float num2 = color.a = (float)num;
					Color color2 = this.Sprite.color = color;
					this.Snapping = false;
				}
			}
		}
		else if (this.Yandere.Aiming)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 0.5f)
			{
				if (Physics.Raycast(this.SmartphoneCamera.transform.position, this.SmartphoneCamera.transform.TransformDirection(Vector3.forward), out this.hit, float.PositiveInfinity, this.OnlyPhotography))
				{
					if (this.hit.collider.gameObject.name == "Panties" || this.hit.collider.gameObject.name == "Skirt")
					{
						GameObject gameObject = this.hit.collider.gameObject.transform.root.gameObject;
						if (Physics.Raycast(this.SmartphoneCamera.transform.position, this.SmartphoneCamera.transform.TransformDirection(Vector3.forward), out this.hit, float.PositiveInfinity, this.OnlyCharacters))
						{
							if (this.hit.collider.gameObject == gameObject)
							{
								if (!this.Yandere.Lewd)
								{
									this.Yandere.NotificationManager.DisplayNotification("Lewd");
								}
								this.Yandere.Lewd = true;
							}
							else
							{
								this.Yandere.Lewd = false;
							}
						}
					}
					else
					{
						this.Yandere.Lewd = false;
					}
				}
				else
				{
					this.Yandere.Lewd = false;
				}
			}
		}
		else
		{
			this.Timer = (float)0;
		}
		if (this.TookPhoto)
		{
			this.ResumeGameplay();
		}
		if (!this.DisplayError)
		{
			if (this.CameraButtons.active && !this.Snapping)
			{
				if (Input.GetButtonDown("A"))
				{
					bool flag = false;
					if (!this.SenpaiX.active)
					{
						flag = true;
					}
					this.CameraButtons.active = false;
					this.PhotoIcons.active = false;
					this.ID = 0;
					this.FreeSpace = false;
					while (this.ID < 26)
					{
						this.ID++;
						if (PlayerPrefs.GetInt("Photo_" + this.ID) == 0)
						{
							this.FreeSpace = true;
							this.Slot = this.ID;
							this.ID = 26;
						}
					}
					if (this.FreeSpace)
					{
						Application.CaptureScreenshot(Application.streamingAssetsPath + "/Photographs/" + "Photo_" + this.Slot + ".png");
						this.TookPhoto = true;
						PlayerPrefs.SetInt("Photo_" + this.Slot, 1);
						if (flag)
						{
							PlayerPrefs.SetInt("SenpaiPhoto_" + this.Slot, 1);
						}
					}
					else
					{
						this.DisplayError = true;
					}
				}
				if (Input.GetButtonDown("X"))
				{
					this.Panel.active = true;
					this.MainMenu.active = false;
					this.PauseScreen.Show = true;
					this.TextMessages.active = true;
					this.CameraButtons.active = false;
					if (!this.InfoX.active)
					{
						PlayerPrefs.SetInt("Student_" + this.Student.StudentID + "_Photographed", 1);
						this.ID = 0;
						while (this.ID < Extensions.get_length(this.Student.Outlines))
						{
							this.Student.Outlines[this.ID].enabled = true;
							this.ID++;
						}
						this.StudentInfo.active = true;
						this.StudentInfo.Student = this.Student;
						this.StartCoroutine_Auto(this.StudentInfo.UpdateInfo());
					}
					this.SpawnMessage();
				}
				if (Input.GetButtonDown("B"))
				{
					this.ResumeGameplay();
				}
			}
			else if (this.PhotoIcons.active && Input.GetButtonDown("B"))
			{
				this.ResumeGameplay();
			}
		}
		else
		{
			this.ErrorWindow.transform.localScale = Vector3.Lerp(this.ErrorWindow.transform.localScale, new Vector3((float)1, (float)1, (float)1), 0.166666672f);
			if (Input.GetButtonDown("A"))
			{
				this.ResumeGameplay();
			}
		}
	}

	public virtual void Snap()
	{
		this.ErrorWindow.transform.localScale = Vector3.Lerp(this.ErrorWindow.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
		this.Yandere.HandCamera.active = false;
		int num = 1;
		Color color = this.Sprite.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Sprite.color = color;
		this.Snapping = true;
		this.Close = true;
		this.Frame = 0;
	}

	public virtual void CheckPhoto()
	{
		this.InfoX.active = true;
		this.PantiesX.active = true;
		this.SenpaiX.active = true;
		this.ViolenceX.active = true;
		this.NotFace = false;
		this.Skirt = false;
		if (Physics.Raycast(this.SmartphoneCamera.transform.position, this.SmartphoneCamera.transform.TransformDirection(Vector3.forward), out this.hit, float.PositiveInfinity, this.OnlyPhotography))
		{
			if (this.hit.collider.gameObject.name == "Panties")
			{
				this.Student = (StudentScript)this.hit.collider.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript));
				this.PantiesX.active = false;
			}
			else if (this.hit.collider.gameObject.name == "Face")
			{
				this.Student = (StudentScript)this.hit.collider.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript));
				if (this.Student.StudentID == 1)
				{
					this.SenpaiX.active = false;
				}
				else
				{
					this.InfoX.active = false;
				}
			}
			else if (this.hit.collider.gameObject.name == "NotFace")
			{
				this.NotFace = true;
			}
			else if (this.hit.collider.gameObject.name == "Skirt")
			{
				this.Skirt = true;
			}
		}
		if (Physics.Raycast(this.SmartphoneCamera.transform.position, this.SmartphoneCamera.transform.TransformDirection(Vector3.forward), out this.hit, float.PositiveInfinity, this.OnlyRagdolls) && this.hit.collider.gameObject.layer == 11)
		{
			this.ViolenceX.active = false;
		}
		if (Physics.Raycast(this.SmartphoneCamera.transform.position, this.SmartphoneCamera.transform.TransformDirection(Vector3.forward), out this.hit, float.PositiveInfinity, this.OnlyBlood) && this.hit.collider.gameObject.tag == "Blood")
		{
			this.ViolenceX.active = false;
		}
	}

	public virtual void SpawnMessage()
	{
		if (this.NewMessage != null)
		{
			UnityEngine.Object.Destroy(this.NewMessage);
		}
		this.NewMessage = (GameObject)UnityEngine.Object.Instantiate(this.Message);
		this.NewMessage.transform.parent = this.TextMessages;
		this.NewMessage.transform.localPosition = new Vector3((float)-225, (float)-275, (float)0);
		this.NewMessage.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		this.NewMessage.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		string text;
		int num;
		if (!this.InfoX.active)
		{
			text = "I recognize this person. Here's some information about them.";
			num = 3;
		}
		else if (!this.PantiesX.active)
		{
			if (PlayerPrefs.GetInt(this.Student.Name + "PantyShot") == 0)
			{
				text = "Excellent! Now I have a picture of " + this.Student.Name + "'s panties. I owe you a favor for this one.";
				num = 4;
				PlayerPrefs.SetInt(this.Student.Name + "PantyShot", 1);
				PlayerPrefs.SetInt("PantyShots", PlayerPrefs.GetInt("PantyShots") + 1);
			}
			else
			{
				text = "I already have a picture of " + this.Student.Name + "'s panties. I don't need this shot.";
				num = 4;
			}
		}
		else if (!this.ViolenceX.active)
		{
			text = "Good work, but don't send me this stuff. I have no use for it.";
			num = 3;
		}
		else if (!this.SenpaiX.active)
		{
			if (PlayerPrefs.GetInt("SenpaiShots") == 0)
			{
				text = "I don't need any pictures of your Senpai.";
				num = 2;
			}
			else if (PlayerPrefs.GetInt("SenpaiShots") == 1)
			{
				text = "I know how you feel about this person, but I have no use for these pictures.";
				num = 4;
			}
			else if (PlayerPrefs.GetInt("SenpaiShots") == 2)
			{
				text = "Okay, I get it, you love your Senpai, and you love taking pictures of your Senpai. I still don't need these shots.";
				num = 5;
			}
			else if (PlayerPrefs.GetInt("SenpaiShots") == 3)
			{
				text = "You're spamming my inbox. Cut it out.";
				num = 2;
			}
			else
			{
				text = "...";
				num = 1;
			}
			PlayerPrefs.SetInt("SenpaiShots", PlayerPrefs.GetInt("SenpaiShots") + 1);
		}
		else if (this.NotFace)
		{
			text = "Do you want me to identify this person? Please get me a clear shot of their face.";
			num = 4;
		}
		else if (this.Skirt)
		{
			text = "Is this supposed to be a panty shot? My clients are picky. The panties need to be in the EXACT center of the shot.";
			num = 5;
		}
		else
		{
			text = "I don't get it. What are you trying to show me? Make sure the subject is in the EXACT center of the photo.";
			num = 5;
		}
		((UISprite)this.NewMessage.GetComponent(typeof(UISprite))).height = 36 + 36 * num;
		((TextMessageScript)this.NewMessage.GetComponent(typeof(TextMessageScript))).Label.text = text;
	}

	public virtual void ResumeGameplay()
	{
		this.ErrorWindow.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		this.SmartphoneCamera.targetTexture = this.SmartphoneScreen;
		this.StudentManager.GhostChan.active = false;
		this.PauseScreen.CorrectingTime = true;
		this.Yandere.HandCamera.active = true;
		this.HeartbeatCamera.active = true;
		this.CameraButtons.active = false;
		this.TextMessages.active = false;
		this.StudentInfo.active = false;
		this.MainCamera.enabled = true;
		this.PhotoIcons.active = false;
		this.PauseScreen.Show = false;
		this.MainMenu.active = true;
		this.Yandere.CanMove = true;
		this.DisplayError = false;
		this.Panel.active = true;
		Time.timeScale = (float)1;
		this.TakePhoto = false;
		this.TookPhoto = false;
		if (!this.Yandere.CameraEffects.OneCamera)
		{
			this.Yandere.MainCamera.clearFlags = CameraClearFlags.Skybox;
			this.Yandere.MainCamera.farClipPlane = 200f;
		}
	}

	public virtual void Main()
	{
	}
}
