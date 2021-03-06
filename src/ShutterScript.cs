﻿using System;
using UnityEngine;

public class ShutterScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public TaskManagerScript TaskManager;

	public PauseScreenScript PauseScreen;

	public StudentInfoScript StudentInfo;

	public PromptBarScript PromptBar;

	public SubtitleScript Subtitle;

	public SchemesScript Schemes;

	public StudentScript Student;

	public YandereScript Yandere;

	public StudentScript FaceStudent;

	public RenderTexture SmartphoneScreen;

	public Camera SmartphoneCamera;

	public Transform TextMessages;

	public Transform ErrorWindow;

	public Camera MainCamera;

	public UILabel PhotoDescLabel;

	public UISprite Sprite;

	public GameObject NotificationManager;

	public GameObject BullyPhotoCollider;

	public GameObject PhotoDescription;

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

	public GameObject BullyX;

	public GameObject InfoX;

	public bool AirGuitarShot;

	public bool DisplayError;

	public bool MissionMode;

	public bool HorudaShot;

	public bool KittenShot;

	public bool OsanaShot;

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

	public float ReactionDistance;

	public float PenaltyTimer;

	public float Timer;

	private float currentPercent;

	public int TargetStudent;

	public int NemesisShots;

	public int Frame;

	public int Slot;

	public int ID;

	public AudioSource MyAudio;

	public Transform SelfieRayParent;

	public int OnlyPhotography
	{
		get
		{
			return 65537;
		}
	}

	public int OnlyCharacters
	{
		get
		{
			return 513;
		}
	}

	public int OnlyRagdolls
	{
		get
		{
			return 2049;
		}
	}

	public int OnlyBlood
	{
		get
		{
			return 16385;
		}
	}

	private void Start()
	{
		if (MissionModeGlobals.MissionMode)
		{
			this.MissionMode = true;
		}
		this.ErrorWindow.transform.localScale = Vector3.zero;
		this.CameraButtons.SetActive(false);
		this.PhotoIcons.SetActive(false);
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
	}

	private void Update()
	{
		bool selfie = this.Yandere.Selfie;
		if (this.Snapping)
		{
			if (this.Yandere.Noticed)
			{
				this.Yandere.Shutter.ResumeGameplay();
				this.Yandere.StopAiming();
			}
			else if (this.Close)
			{
				this.currentPercent += 60f * Time.unscaledDeltaTime;
				while (this.currentPercent >= 1f)
				{
					this.Frame = Mathf.Min(this.Frame + 1, 8);
					this.currentPercent -= 1f;
				}
				this.Sprite.spriteName = "Shutter" + this.Frame.ToString();
				if (this.Frame == 8)
				{
					this.StudentManager.GhostChan.gameObject.SetActive(true);
					this.PhotoDescription.SetActive(false);
					this.PhotoDescLabel.text = "";
					this.StudentManager.GhostChan.Look();
					this.CheckPhoto();
					if (this.PhotoDescLabel.text == "")
					{
						this.PhotoDescLabel.text = "Cannot determine subject of photo. Try again.";
					}
					this.PhotoDescription.SetActive(true);
					this.SmartphoneCamera.targetTexture = null;
					this.Yandere.PhonePromptBar.Show = false;
					this.NotificationManager.SetActive(false);
					this.HeartbeatCamera.SetActive(false);
					this.Yandere.SelfieGuide.SetActive(false);
					this.MainCamera.enabled = false;
					this.PhotoIcons.SetActive(true);
					this.SubPanel.SetActive(false);
					this.Panel.SetActive(false);
					this.Close = false;
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Save";
					this.PromptBar.Label[1].text = "Delete";
					if (!this.Yandere.RivalPhone)
					{
						this.PromptBar.Label[2].text = "Send";
					}
					else if (this.PantiesX.activeInHierarchy)
					{
						this.PromptBar.Label[0].text = "";
					}
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
					Time.timeScale = 0.0001f;
				}
			}
			else
			{
				this.currentPercent += 60f * Time.unscaledDeltaTime;
				while (this.currentPercent >= 1f)
				{
					this.Frame = Mathf.Max(this.Frame - 1, 1);
					this.currentPercent -= 1f;
				}
				this.Sprite.spriteName = "Shutter" + this.Frame.ToString();
				if (this.Frame == 1)
				{
					this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
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
				Vector3 direction;
				if (!this.Yandere.Selfie)
				{
					direction = this.SmartphoneCamera.transform.TransformDirection(Vector3.forward);
				}
				else
				{
					direction = this.SelfieRayParent.TransformDirection(Vector3.forward);
				}
				if (Physics.Raycast(this.SmartphoneCamera.transform.position, direction, out this.hit, float.PositiveInfinity, this.OnlyPhotography))
				{
					if (this.hit.collider.gameObject.name == "Face")
					{
						GameObject gameObject = this.hit.collider.gameObject.transform.root.gameObject;
						this.FaceStudent = gameObject.GetComponent<StudentScript>();
						if (this.FaceStudent != null)
						{
							this.TargetStudent = this.FaceStudent.StudentID;
							if (this.TargetStudent > 1)
							{
								this.ReactionDistance = 1.66666f;
							}
							else
							{
								this.ReactionDistance = this.FaceStudent.VisionDistance;
							}
							bool enabled = this.FaceStudent.ShoeRemoval.enabled;
							if (!this.FaceStudent.Alarmed && !this.FaceStudent.Dying && !this.FaceStudent.Distracted && !this.FaceStudent.InEvent && !this.FaceStudent.Wet && this.FaceStudent.Schoolwear > 0 && !this.FaceStudent.Fleeing && !this.FaceStudent.Following && !enabled && !this.FaceStudent.HoldingHands && this.FaceStudent.Actions[this.FaceStudent.Phase] != StudentActionType.Mourn && !this.FaceStudent.Guarding && !this.FaceStudent.Confessing && !this.FaceStudent.DiscCheck && !this.FaceStudent.TurnOffRadio && !this.FaceStudent.Investigating && !this.FaceStudent.Distracting && !this.FaceStudent.WitnessedLimb && !this.FaceStudent.WitnessedWeapon && !this.FaceStudent.WitnessedBloodPool && !this.FaceStudent.WitnessedBloodyWeapon && Vector3.Distance(this.Yandere.transform.position, gameObject.transform.position) < this.ReactionDistance && this.FaceStudent.CanSeeObject(this.Yandere.gameObject, this.Yandere.transform.position + Vector3.up))
							{
								if (this.MissionMode)
								{
									this.PenaltyTimer += Time.deltaTime;
									if (this.PenaltyTimer > 1f)
									{
										this.FaceStudent.Reputation.PendingRep -= -10f;
										this.PenaltyTimer = 0f;
									}
								}
								if (!this.FaceStudent.CameraReacting)
								{
									if (this.FaceStudent.enabled && !this.FaceStudent.Stop)
									{
										if ((this.FaceStudent.DistanceToDestination < 5f && this.FaceStudent.Actions[this.FaceStudent.Phase] == StudentActionType.Graffiti) || (this.FaceStudent.DistanceToDestination < 5f && this.FaceStudent.Actions[this.FaceStudent.Phase] == StudentActionType.Bully))
										{
											this.FaceStudent.PhotoPatience = 0f;
											this.FaceStudent.KilledMood = true;
											this.FaceStudent.Ignoring = true;
											this.PenaltyTimer = 1f;
											this.Penalize();
										}
										else if (this.FaceStudent.PhotoPatience > 0f)
										{
											if (this.FaceStudent.StudentID > 1)
											{
												if ((this.Yandere.Bloodiness > 0f && !this.Yandere.Paint) || (double)this.Yandere.Sanity < 33.33333)
												{
													this.FaceStudent.Alarm += 200f;
												}
												else
												{
													this.FaceStudent.CameraReact();
												}
											}
											else
											{
												this.FaceStudent.Alarm += Time.deltaTime * (100f / this.FaceStudent.DistanceToPlayer) * this.FaceStudent.Paranoia * this.FaceStudent.Perception * this.FaceStudent.DistanceToPlayer * 2f;
												this.FaceStudent.YandereVisible = true;
											}
										}
										else
										{
											this.Penalize();
										}
									}
								}
								else
								{
									this.FaceStudent.PhotoPatience = Mathf.MoveTowards(this.FaceStudent.PhotoPatience, 0f, Time.deltaTime);
									if (this.FaceStudent.PhotoPatience > 0f)
									{
										this.FaceStudent.CameraPoseTimer = 1f;
										if (this.MissionMode)
										{
											this.FaceStudent.PhotoPatience = 0f;
										}
									}
								}
							}
						}
					}
					else if (this.hit.collider.gameObject.name == "Panties" || this.hit.collider.gameObject.name == "Skirt")
					{
						GameObject gameObject2 = this.hit.collider.gameObject.transform.root.gameObject;
						if (Physics.Raycast(this.SmartphoneCamera.transform.position, direction, out this.hit, float.PositiveInfinity, this.OnlyCharacters))
						{
							if (Vector3.Distance(this.Yandere.transform.position, gameObject2.transform.position) < 5f)
							{
								if (this.hit.collider.gameObject == gameObject2)
								{
									if (!this.Yandere.Lewd)
									{
										this.Yandere.NotificationManager.DisplayNotification(NotificationType.Lewd);
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
			this.Timer = 0f;
		}
		if (this.TookPhoto)
		{
			this.ResumeGameplay();
		}
		if (!this.DisplayError)
		{
			if (this.PhotoIcons.activeInHierarchy && !this.Snapping && !this.TextMessages.gameObject.activeInHierarchy)
			{
				if (Input.GetButtonDown("A"))
				{
					if (!this.Yandere.RivalPhone)
					{
						bool flag = !this.BullyX.activeInHierarchy;
						bool flag2 = !this.SenpaiX.activeInHierarchy;
						this.PromptBar.transform.localPosition = new Vector3(this.PromptBar.transform.localPosition.x, -627f, this.PromptBar.transform.localPosition.z);
						this.PromptBar.ClearButtons();
						this.PromptBar.Show = false;
						this.PhotoIcons.SetActive(false);
						this.ID = 0;
						this.FreeSpace = false;
						while (this.ID < 26)
						{
							this.ID++;
							if (!PlayerGlobals.GetPhoto(this.ID))
							{
								this.FreeSpace = true;
								this.Slot = this.ID;
								this.ID = 26;
							}
						}
						if (this.FreeSpace)
						{
							ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/Photographs/Photo_" + this.Slot.ToString() + ".png");
							this.TookPhoto = true;
							Debug.Log("Setting Photo " + this.Slot + " to ''true''.");
							PlayerGlobals.SetPhoto(this.Slot, true);
							if (flag)
							{
								Debug.Log("Saving a bully photo!");
								int studentID = this.BullyPhotoCollider.transform.parent.gameObject.GetComponent<StudentScript>().StudentID;
								if (this.StudentManager.Students[studentID].Club != ClubType.Bully)
								{
									PlayerGlobals.SetBullyPhoto(this.Slot, studentID);
								}
								else
								{
									PlayerGlobals.SetBullyPhoto(this.Slot, this.StudentManager.Students[studentID].DistractionTarget.StudentID);
								}
							}
							if (flag2)
							{
								PlayerGlobals.SetSenpaiPhoto(this.Slot, true);
							}
							if (this.AirGuitarShot)
							{
								TaskGlobals.SetGuitarPhoto(this.Slot, true);
								this.TaskManager.UpdateTaskStatus();
							}
							if (this.KittenShot)
							{
								TaskGlobals.SetKittenPhoto(this.Slot, true);
								this.TaskManager.UpdateTaskStatus();
							}
							if (this.HorudaShot)
							{
								TaskGlobals.SetHorudaPhoto(this.Slot, true);
								this.TaskManager.UpdateTaskStatus();
							}
							if (this.OsanaShot && SchemeGlobals.GetSchemeStage(4) == 6)
							{
								SchemeGlobals.SetSchemeStage(4, 7);
								this.Yandere.PauseScreen.Schemes.UpdateInstructions();
							}
						}
						else
						{
							this.DisplayError = true;
						}
					}
					else if (!this.PantiesX.activeInHierarchy)
					{
						if (SchemeGlobals.GetSchemeStage(1) == 5)
						{
							SchemeGlobals.SetSchemeStage(1, 6);
							this.Schemes.UpdateInstructions();
						}
						this.StudentManager.CommunalLocker.RivalPhone.LewdPhotos = true;
						this.ResumeGameplay();
					}
				}
				if (!this.Yandere.RivalPhone && Input.GetButtonDown("X"))
				{
					this.Panel.SetActive(true);
					this.MainMenu.SetActive(false);
					this.PauseScreen.Show = true;
					this.PauseScreen.Panel.enabled = true;
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[1].text = "Exit";
					if (this.PantiesX.activeInHierarchy)
					{
						this.PromptBar.Label[3].text = "Interests";
					}
					else
					{
						this.PromptBar.Label[3].text = "";
					}
					this.PromptBar.UpdateButtons();
					if (!this.InfoX.activeInHierarchy)
					{
						this.PauseScreen.Sideways = true;
						StudentGlobals.SetStudentPhotographed(this.Student.StudentID, true);
						this.ID = 0;
						while (this.ID < this.Student.Outlines.Length)
						{
							this.Student.Outlines[this.ID].enabled = true;
							this.ID++;
						}
						this.StudentInfo.UpdateInfo(this.Student.StudentID);
						this.StudentInfo.gameObject.SetActive(true);
					}
					else if (!this.TextMessages.gameObject.activeInHierarchy)
					{
						this.PauseScreen.Sideways = false;
						this.TextMessages.gameObject.SetActive(true);
						this.SpawnMessage();
					}
				}
				if (Input.GetButtonDown("B"))
				{
					this.ResumeGameplay();
					return;
				}
			}
			else if (this.PhotoIcons.activeInHierarchy && Input.GetButtonDown("B"))
			{
				this.ResumeGameplay();
				return;
			}
		}
		else
		{
			float t = Time.unscaledDeltaTime * 10f;
			this.ErrorWindow.transform.localScale = Vector3.Lerp(this.ErrorWindow.transform.localScale, new Vector3(1f, 1f, 1f), t);
			if (Input.GetButtonDown("A"))
			{
				this.ResumeGameplay();
			}
		}
	}

	public void Snap()
	{
		this.ErrorWindow.transform.localScale = Vector3.zero;
		this.Yandere.HandCamera.gameObject.SetActive(false);
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 1f);
		this.MyAudio.Play();
		this.Snapping = true;
		this.Close = true;
		this.Frame = 0;
	}

	private void CheckPhoto()
	{
		this.InfoX.SetActive(true);
		this.BullyX.SetActive(true);
		this.SenpaiX.SetActive(true);
		this.PantiesX.SetActive(true);
		this.ViolenceX.SetActive(true);
		this.AirGuitarShot = false;
		this.HorudaShot = false;
		this.KittenShot = false;
		this.OsanaShot = false;
		this.Nemesis = false;
		this.NotFace = false;
		this.Skirt = false;
		Vector3 direction;
		if (!this.Yandere.Selfie)
		{
			direction = this.SmartphoneCamera.transform.TransformDirection(Vector3.forward);
		}
		else
		{
			direction = this.SelfieRayParent.TransformDirection(Vector3.forward);
		}
		this.StudentManager.UpdateSkirts(true);
		if (Physics.Raycast(this.SmartphoneCamera.transform.position, direction, out this.hit, float.PositiveInfinity, this.OnlyPhotography))
		{
			Debug.Log("Took a picture of " + this.hit.collider.gameObject.name);
			Debug.Log("The root is " + this.hit.collider.gameObject.transform.root.name);
			if (this.hit.collider.gameObject.name == "Panties")
			{
				this.Student = this.hit.collider.gameObject.transform.root.gameObject.GetComponent<StudentScript>();
				this.PhotoDescLabel.text = "Photo of: " + this.Student.Name + "'s Panties";
				this.PantiesX.SetActive(false);
			}
			else if (this.hit.collider.gameObject.name == "Face")
			{
				if (this.hit.collider.gameObject.tag == "Nemesis")
				{
					this.PhotoDescLabel.text = "Photo of: Nemesis";
					this.Nemesis = true;
					this.NemesisShots++;
				}
				else if (this.hit.collider.gameObject.tag == "Disguise")
				{
					this.PhotoDescLabel.text = "Photo of: ?????";
					this.Disguise = true;
				}
				else
				{
					this.Student = this.hit.collider.gameObject.transform.root.gameObject.GetComponent<StudentScript>();
					if (this.Student.StudentID == 1)
					{
						this.PhotoDescLabel.text = "Photo of: Senpai";
						this.SenpaiX.SetActive(false);
					}
					else
					{
						this.PhotoDescLabel.text = "Photo of: " + this.Student.Name;
						this.InfoX.SetActive(false);
					}
				}
			}
			else if (this.hit.collider.gameObject.name == "NotFace")
			{
				this.PhotoDescLabel.text = "Photo of: Blocked Face";
				this.NotFace = true;
			}
			else if (this.hit.collider.gameObject.name == "Skirt")
			{
				this.PhotoDescLabel.text = "Photo of: Skirt";
				this.Skirt = true;
			}
			if (this.hit.collider.transform.root.gameObject.name == "Student_51 (Miyuji Shan)" && this.StudentManager.Students[51].AirGuitar.isPlaying)
			{
				this.AirGuitarShot = true;
				this.PhotoDescription.SetActive(true);
				this.PhotoDescLabel.text = "Photo of: Miyuji's True Nature?";
			}
			if (this.hit.collider.gameObject.name == "Kitten")
			{
				this.KittenShot = true;
				this.PhotoDescription.SetActive(true);
				this.PhotoDescLabel.text = "Photo of: Kitten";
				if (!ConversationGlobals.GetTopicDiscovered(15))
				{
					ConversationGlobals.SetTopicDiscovered(15, true);
					this.Yandere.NotificationManager.TopicName = "Cats";
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				}
			}
			if (this.hit.collider.gameObject.tag == "Horuda")
			{
				this.HorudaShot = true;
				this.PhotoDescription.SetActive(true);
				this.PhotoDescLabel.text = "Photo of: Horuda's Hiding Spot";
			}
			if (this.hit.collider.gameObject.tag == "Bully")
			{
				this.PhotoDescLabel.text = "Photo of: Student Speaking With Bully";
				this.BullyPhotoCollider = this.hit.collider.gameObject;
				this.BullyX.SetActive(false);
			}
			if (this.hit.collider.gameObject.tag == "RivalEvidence")
			{
				this.OsanaShot = true;
				this.PhotoDescription.SetActive(true);
				this.PhotoDescLabel.text = "Photo of: Osana Vandalizing School Property";
			}
		}
		if (Physics.Raycast(this.SmartphoneCamera.transform.position, direction, out this.hit, float.PositiveInfinity, this.OnlyRagdolls) && this.hit.collider.gameObject.layer == 11)
		{
			this.PhotoDescLabel.text = "Photo of: Corpse";
			this.ViolenceX.SetActive(false);
		}
		if (Physics.Raycast(this.SmartphoneCamera.transform.position, this.SmartphoneCamera.transform.TransformDirection(Vector3.forward), out this.hit, float.PositiveInfinity, this.OnlyBlood) && this.hit.collider.gameObject.layer == 14)
		{
			this.PhotoDescLabel.text = "Photo of: Blood";
			this.ViolenceX.SetActive(false);
		}
		this.StudentManager.UpdateSkirts(false);
	}

	private void SpawnMessage()
	{
		if (this.NewMessage != null)
		{
			UnityEngine.Object.Destroy(this.NewMessage);
		}
		this.NewMessage = UnityEngine.Object.Instantiate<GameObject>(this.Message);
		this.NewMessage.transform.parent = this.TextMessages;
		this.NewMessage.transform.localPosition = new Vector3(-225f, -275f, 0f);
		this.NewMessage.transform.localEulerAngles = Vector3.zero;
		this.NewMessage.transform.localScale = new Vector3(1f, 1f, 1f);
		bool flag = false;
		if (this.hit.collider != null && this.hit.collider.gameObject.name == "Kitten")
		{
			flag = true;
		}
		string text = string.Empty;
		int num;
		if (flag)
		{
			text = "Why are you showing me this? I don't care.";
			num = 2;
		}
		else if (!this.InfoX.activeInHierarchy)
		{
			text = "I recognize this person. Here's some information about them.";
			num = 3;
		}
		else if (!this.PantiesX.activeInHierarchy)
		{
			if (this.Student != null)
			{
				if (!PlayerGlobals.GetStudentPantyShot(this.Student.Name))
				{
					PlayerGlobals.SetStudentPantyShot(this.Student.Name, true);
					if (this.Student.Nemesis)
					{
						text = "Hey, wait a minute...I recognize those panties! This person is extremely dangerous! Avoid her at all costs!";
					}
					else if (this.Student.Club == ClubType.Bully || this.Student.Club == ClubType.Council || this.Student.Club == ClubType.Nurse || this.Student.StudentID == 20)
					{
						text = "A high value target! " + this.Student.Name + "'s panties were in high demand. I owe you a big favor for this one.";
						this.Yandere.Inventory.PantyShots += 5;
					}
					else
					{
						text = "Excellent! Now I have a picture of " + this.Student.Name + "'s panties. I owe you a favor for this one.";
						this.Yandere.Inventory.PantyShots++;
					}
					num = 5;
				}
				else if (!this.Student.Nemesis)
				{
					text = "I already have a picture of " + this.Student.Name + "'s panties. I don't need this shot.";
					num = 4;
				}
				else
				{
					text = "You are in danger. Avoid her.";
					num = 2;
				}
			}
			else
			{
				text = "How peculiar. I don't recognize these panties.";
				num = 2;
			}
		}
		else if (!this.ViolenceX.activeInHierarchy)
		{
			text = "Good work, but don't send me this stuff. I have no use for it.";
			num = 3;
		}
		else if (!this.SenpaiX.activeInHierarchy)
		{
			if (PlayerGlobals.SenpaiShots == 0)
			{
				text = "I don't need any pictures of your Senpai.";
				num = 2;
			}
			else if (PlayerGlobals.SenpaiShots == 1)
			{
				text = "I know how you feel about this person, but I have no use for these pictures.";
				num = 4;
			}
			else if (PlayerGlobals.SenpaiShots == 2)
			{
				text = "Okay, I get it, you love your Senpai, and you love taking pictures of your Senpai. I still don't need these shots.";
				num = 5;
			}
			else if (PlayerGlobals.SenpaiShots == 3)
			{
				text = "You're spamming my inbox. Cut it out.";
				num = 2;
			}
			else
			{
				text = "...";
				num = 1;
			}
			PlayerGlobals.SenpaiShots++;
		}
		else if (!this.BullyX.activeInHierarchy)
		{
			text = "I have no interest in this.";
			num = 2;
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
		this.NewMessage.GetComponent<UISprite>().height = 36 + 36 * num;
		this.NewMessage.GetComponent<TextMessageScript>().Label.text = text;
	}

	public void ResumeGameplay()
	{
		this.ErrorWindow.transform.localScale = Vector3.zero;
		this.SmartphoneCamera.targetTexture = this.SmartphoneScreen;
		this.StudentManager.GhostChan.gameObject.SetActive(false);
		this.Yandere.HandCamera.gameObject.SetActive(true);
		this.NotificationManager.SetActive(true);
		this.PauseScreen.CorrectingTime = true;
		this.HeartbeatCamera.SetActive(true);
		this.TextMessages.gameObject.SetActive(false);
		this.StudentInfo.gameObject.SetActive(false);
		this.MainCamera.enabled = true;
		this.PhotoIcons.SetActive(false);
		this.PauseScreen.Show = false;
		this.SubPanel.SetActive(true);
		this.MainMenu.SetActive(true);
		this.Yandere.CanMove = true;
		this.DisplayError = false;
		this.Panel.SetActive(true);
		Time.timeScale = 1f;
		this.TakePhoto = false;
		this.TookPhoto = false;
		this.Yandere.PhonePromptBar.Panel.enabled = true;
		this.Yandere.PhonePromptBar.Show = true;
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
		if (this.NewMessage != null)
		{
			UnityEngine.Object.Destroy(this.NewMessage);
		}
		if (!this.Yandere.CameraEffects.OneCamera)
		{
			if (!OptionGlobals.Fog)
			{
				this.Yandere.MainCamera.clearFlags = CameraClearFlags.Skybox;
			}
			else
			{
				this.Yandere.MainCamera.clearFlags = CameraClearFlags.Color;
			}
			this.Yandere.MainCamera.farClipPlane = (float)OptionGlobals.DrawDistance;
		}
		this.Yandere.UpdateSelfieStatus();
	}

	public void Penalize()
	{
		this.PenaltyTimer += Time.deltaTime;
		if (this.PenaltyTimer >= 1f)
		{
			this.Subtitle.UpdateLabel(SubtitleType.PhotoAnnoyance, 0, 3f);
			if (this.MissionMode)
			{
				if (this.FaceStudent.TimesAnnoyed < 5)
				{
					this.FaceStudent.TimesAnnoyed++;
				}
				else
				{
					this.FaceStudent.RepDeduction = 0f;
					this.FaceStudent.RepLoss = 20f;
					this.FaceStudent.Reputation.PendingRep -= this.FaceStudent.RepLoss * this.FaceStudent.Paranoia;
					this.FaceStudent.PendingRep -= this.FaceStudent.RepLoss * this.FaceStudent.Paranoia;
				}
			}
			else
			{
				this.FaceStudent.RepDeduction = 0f;
				this.FaceStudent.RepLoss = 1f;
				this.FaceStudent.CalculateReputationPenalty();
				if (this.FaceStudent.RepDeduction >= 0f)
				{
					this.FaceStudent.RepLoss -= this.FaceStudent.RepDeduction;
				}
				this.FaceStudent.Reputation.PendingRep -= this.FaceStudent.RepLoss * this.FaceStudent.Paranoia;
				this.FaceStudent.PendingRep -= this.FaceStudent.RepLoss * this.FaceStudent.Paranoia;
			}
			this.PenaltyTimer = 0f;
		}
	}
}
