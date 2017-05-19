using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ShutterScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public TaskManagerScript TaskManager;

	public PauseScreenScript PauseScreen;

	public StudentInfoScript StudentInfo;

	public PromptBarScript PromptBar;

	public SchemesScript Schemes;

	public StudentScript Student;

	public YandereScript Yandere;

	public StudentScript FaceStudent;

	public RenderTexture SmartphoneScreen;

	public Camera SmartphoneCamera;

	public Transform TextMessages;

	public Transform ErrorWindow;

	public Camera MainCamera;

	public UISprite Sprite;

	public GameObject NotificationManager;

	public GameObject HeartbeatCamera;

	public GameObject CameraButtons;

	public GameObject NewMessage;

	public GameObject PhotoIcons;

	public GameObject MainMenu;

	public GameObject SubPanel;

	public GameObject Message;

	public GameObject Panel;

	public GameObject ViolenceX;

	public GameObject PantiesX;

	public GameObject SenpaiX;

	public GameObject InfoX;

	public bool DisplayError;

	public bool MissionMode;

	public bool KittenShot;

	public bool FreeSpace;

	public bool TakePhoto;

	public bool TookPhoto;

	public bool Snapping;

	public bool Close;

	public bool Disguise;

	public bool Nemesis;

	public bool NotFace;

	public bool Skirt;

	public RaycastHit hit;

	public float PenaltyTimer;

	public float Timer;

	public int TargetStudent;

	public int NemesisShots;

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
		this.OnlyCharacters = 513;
		this.OnlyRagdolls = 2049;
		this.OnlyBlood = 16385;
	}

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("MissionMode") == 1)
		{
			this.MissionMode = true;
		}
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
					this.Yandere.PhonePromptBar.Show = false;
					this.NotificationManager.active = false;
					this.HeartbeatCamera.active = false;
					this.MainCamera.enabled = false;
					this.PhotoIcons.active = true;
					this.SubPanel.active = false;
					this.Panel.active = false;
					this.Close = false;
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Save";
					this.PromptBar.Label[1].text = "Delete";
					if (!this.Yandere.RivalPhone)
					{
						this.PromptBar.Label[2].text = "Send";
					}
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
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
			this.TargetStudent = 0;
			this.Timer += Time.deltaTime;
			if (this.Timer > 0.5f)
			{
				if (Physics.Raycast(this.SmartphoneCamera.transform.position, this.SmartphoneCamera.transform.TransformDirection(Vector3.forward), out this.hit, float.PositiveInfinity, this.OnlyPhotography))
				{
					if (this.hit.collider.gameObject.name == "Face")
					{
						GameObject gameObject = this.hit.collider.gameObject.transform.root.gameObject;
						this.FaceStudent = (StudentScript)this.hit.collider.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript));
						if (this.FaceStudent != null)
						{
							this.TargetStudent = this.FaceStudent.StudentID;
							if (!this.FaceStudent.Male && !this.FaceStudent.Alarmed && !this.FaceStudent.Distracted && !this.FaceStudent.InEvent && !this.FaceStudent.Wet && !this.FaceStudent.CensorSteam[0].active && !this.FaceStudent.Fleeing && !this.FaceStudent.Following && !this.FaceStudent.ShoeRemoval.enabled && !this.FaceStudent.HoldingHands && this.FaceStudent.Actions[this.FaceStudent.Phase] != 16 && Vector3.Distance(this.Yandere.transform.position, gameObject.transform.position) < 1.66666f)
							{
								Plane[] planes = GeometryUtility.CalculateFrustumPlanes(this.FaceStudent.VisionCone);
								if (GeometryUtility.TestPlanesAABB(planes, this.Yandere.collider.bounds) && Physics.Linecast(this.FaceStudent.Eyes.position, this.Yandere.transform.position + Vector3.up * (float)1, out this.hit) && this.hit.collider.gameObject == this.Yandere.gameObject)
								{
									if (this.MissionMode)
									{
										this.PenaltyTimer += Time.deltaTime;
										if (this.PenaltyTimer > (float)1)
										{
											this.FaceStudent.Reputation.PendingRep = this.FaceStudent.Reputation.PendingRep - (float)10;
											this.PenaltyTimer = (float)0;
										}
									}
									if (!this.FaceStudent.CameraReacting)
									{
										if (this.FaceStudent.enabled)
										{
											this.FaceStudent.CameraReact();
										}
									}
									else
									{
										this.FaceStudent.CameraPoseTimer = (float)1;
									}
								}
							}
						}
					}
					else if (this.hit.collider.gameObject.name == "Panties" || this.hit.collider.gameObject.name == "Skirt")
					{
						GameObject gameObject2 = this.hit.collider.gameObject.transform.root.gameObject;
						if (Physics.Raycast(this.SmartphoneCamera.transform.position, this.SmartphoneCamera.transform.TransformDirection(Vector3.forward), out this.hit, float.PositiveInfinity, this.OnlyCharacters))
						{
							if (Vector3.Distance(this.Yandere.transform.position, gameObject2.transform.position) < (float)5)
							{
								if (this.hit.collider.gameObject == gameObject2)
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
			if (this.PhotoIcons.active && !this.Snapping && !this.TextMessages.active)
			{
				if (Input.GetButtonDown("A"))
				{
					if (!this.Yandere.RivalPhone)
					{
						bool flag = false;
						if (!this.SenpaiX.active)
						{
							flag = true;
						}
						int num3 = -627;
						Vector3 localPosition = this.PromptBar.transform.localPosition;
						float num4 = localPosition.y = (float)num3;
						Vector3 vector = this.PromptBar.transform.localPosition = localPosition;
						this.PromptBar.ClearButtons();
						this.PromptBar.Show = false;
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
							if (this.KittenShot)
							{
								PlayerPrefs.SetInt("KittenPhoto_" + this.Slot, 1);
								this.TaskManager.UpdateTaskStatus();
							}
						}
						else
						{
							this.DisplayError = true;
						}
					}
					else if (!this.PantiesX.active)
					{
						PlayerPrefs.SetInt("Scheme_4_Stage", 3);
						this.Schemes.UpdateInstructions();
						this.ResumeGameplay();
					}
				}
				if (!this.Yandere.RivalPhone && Input.GetButtonDown("X"))
				{
					this.Panel.active = true;
					this.MainMenu.active = false;
					this.PauseScreen.Show = true;
					this.PauseScreen.Panel.enabled = true;
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[1].text = "Exit";
					this.PromptBar.Label[3].text = "Interests";
					this.PromptBar.UpdateButtons();
					if (!this.InfoX.active)
					{
						this.PauseScreen.Sideways = true;
						PlayerPrefs.SetInt("Student_" + this.Student.StudentID + "_Photographed", 1);
						this.ID = 0;
						while (this.ID < Extensions.get_length(this.Student.Outlines))
						{
							this.Student.Outlines[this.ID].enabled = true;
							this.ID++;
						}
						this.StudentInfo.UpdateInfo(this.Student.StudentID);
						this.StudentInfo.active = true;
					}
					else if (!this.TextMessages.active)
					{
						this.PauseScreen.Sideways = false;
						this.TextMessages.active = true;
						this.SpawnMessage();
					}
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
		this.ErrorWindow.transform.localScale = new Vector3((float)0, (float)0, (float)0);
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
		this.KittenShot = false;
		this.Nemesis = false;
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
				if (this.hit.collider.gameObject.tag == "Nemesis")
				{
					this.Nemesis = true;
					this.NemesisShots++;
				}
				else if (this.hit.collider.gameObject.tag == "Disguise")
				{
					this.Disguise = true;
				}
				else
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
			}
			else if (this.hit.collider.gameObject.name == "NotFace")
			{
				this.NotFace = true;
			}
			else if (this.hit.collider.gameObject.name == "Skirt")
			{
				this.Skirt = true;
			}
			if (this.hit.collider.gameObject.name == "Kitten")
			{
				this.KittenShot = true;
				if (PlayerPrefs.GetInt("Topic_20_Discovered") == 0)
				{
					PlayerPrefs.SetInt("Topic_20_Discovered", 1);
					this.Yandere.NotificationManager.DisplayNotification("Topic");
				}
			}
		}
		if (Physics.Raycast(this.SmartphoneCamera.transform.position, this.SmartphoneCamera.transform.TransformDirection(Vector3.forward), out this.hit, float.PositiveInfinity, this.OnlyRagdolls) && this.hit.collider.gameObject.layer == 11)
		{
			this.ViolenceX.active = false;
		}
		if (Physics.Raycast(this.SmartphoneCamera.transform.position, this.SmartphoneCamera.transform.TransformDirection(Vector3.forward), out this.hit, float.PositiveInfinity, this.OnlyBlood) && this.hit.collider.gameObject.layer == 14)
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
		bool flag;
		if (this.hit.collider != null && this.hit.collider.gameObject.name == "Kitten")
		{
			flag = true;
		}
		string text;
		int num;
		if (flag)
		{
			text = "Why are you showing me this? I don't care.";
			num = 2;
		}
		else if (!this.InfoX.active)
		{
			text = "I recognize this person. Here's some information about them.";
			num = 3;
		}
		else if (!this.PantiesX.active)
		{
			if (this.Student != null)
			{
				if (PlayerPrefs.GetInt(this.Student.Name + "PantyShot") == 0)
				{
					PlayerPrefs.SetInt(this.Student.Name + "PantyShot", 1);
					if (this.Student.StudentID != 32)
					{
						text = "Excellent! Now I have a picture of " + this.Student.Name + "'s panties. I owe you a favor for this one.";
						PlayerPrefs.SetInt("PantyShots", PlayerPrefs.GetInt("PantyShots") + 1);
					}
					else
					{
						text = "A high value target! " + this.Student.Name + "'s panties were in high demand. I owe you a big favor for this one.";
						PlayerPrefs.SetInt("PantyShots", PlayerPrefs.GetInt("PantyShots") + 5);
					}
					num = 5;
				}
				else
				{
					text = "I already have a picture of " + this.Student.Name + "'s panties. I don't need this shot.";
					num = 4;
				}
			}
			else
			{
				text = "How peculiar. I don't recognize these panties.";
				num = 2;
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
		else if (this.Nemesis)
		{
			if (this.NemesisShots == 1)
			{
				text = "Strange. I have no profile for this student.";
				num = 2;
			}
			else if (this.NemesisShots == 2)
			{
				text = "...wait. I think I know who she is.";
				num = 2;
			}
			else if (this.NemesisShots == 3)
			{
				text = "You are in danger. Avoid her.";
				num = 2;
			}
			else if (this.NemesisShots == 4)
			{
				text = "Do not engage.";
				num = 1;
			}
			else
			{
				text = "I repeat: Do. Not. Engage.";
				num = 2;
			}
		}
		else if (this.Disguise)
		{
			text = "Something about that student seems...wrong.";
			num = 2;
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
		this.NotificationManager.active = true;
		this.PauseScreen.CorrectingTime = true;
		this.Yandere.HandCamera.active = true;
		this.HeartbeatCamera.active = true;
		this.TextMessages.active = false;
		this.StudentInfo.active = false;
		this.MainCamera.enabled = true;
		this.PhotoIcons.active = false;
		this.PauseScreen.Show = false;
		this.SubPanel.active = true;
		this.MainMenu.active = true;
		this.Yandere.CanMove = true;
		this.DisplayError = false;
		this.Panel.active = true;
		Time.timeScale = (float)1;
		this.TakePhoto = false;
		this.TookPhoto = false;
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
		if (this.NewMessage != null)
		{
			UnityEngine.Object.Destroy(this.NewMessage);
		}
		if (!this.Yandere.CameraEffects.OneCamera)
		{
			this.Yandere.MainCamera.clearFlags = CameraClearFlags.Skybox;
			this.Yandere.MainCamera.farClipPlane = 325f;
		}
	}

	public virtual void Main()
	{
	}
}
