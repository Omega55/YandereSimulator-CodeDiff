using System;
using UnityEngine;

[Serializable]
public class FirstPersonYandereScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public SenpaiPhotosScript SenpaiPhotos;

	public StudentInfoScript StudentInfo;

	public StudentScript TargetStudent;

	public RPG_Camera MainCamera;

	public ShutterScript Shutter;

	public YandereScript Yandere;

	public UILabel TextMessageLabel;

	public GameObject CellPhoneGroup;

	public GameObject CameraOptions;

	public GameObject TextMessage;

	public GameObject PhonePanel;

	public GameObject Viewfinder;

	public GameObject CellPhone;

	public GameObject SenpaiX;

	public GameObject PantiesX;

	public GameObject InfoX;

	public GameObject EvidenceX;

	public Camera PhoneCamera;

	public Transform Eyes;

	public float StandingHeight;

	public float CrouchingHeight;

	public float EyeHeight;

	public float Timer;

	public bool Crouching;

	public bool TakePhoto;

	public bool TookPhoto;

	public bool TextingMode;

	public bool NotFace;

	public bool Skirt;

	public Vector3 OriginalPosition;

	public Vector3 OriginalRotation;

	public FirstPersonYandereScript()
	{
		this.StandingHeight = 1.5f;
		this.CrouchingHeight = 0.5f;
	}

	public virtual void Start()
	{
		PlayerPrefs.SetInt("PhotographsTaken", 0);
		this.OriginalPosition = this.CellPhone.transform.localPosition;
		this.OriginalRotation = this.CellPhone.transform.localEulerAngles;
		this.CellPhoneGroup.animation.Play("tPose");
		this.PhoneCamera.active = true;
		this.PhoneCamera.enabled = true;
		this.PhoneCamera.rect = new Rect(0.5f, 0.5f, (float)0, (float)0);
		this.CameraOptions.active = false;
		this.Viewfinder.active = false;
		this.TextMessage.active = false;
		this.StudentInfo.active = false;
		this.PhonePanel.active = false;
	}

	public virtual void Update()
	{
		if (!this.TextingMode)
		{
			this.CellPhoneGroup.animation.CrossFade("cameraPose");
			float y = this.MainCamera.transform.eulerAngles.y;
			Vector3 eulerAngles = this.transform.eulerAngles;
			float num = eulerAngles.y = y;
			Vector3 vector = this.transform.eulerAngles = eulerAngles;
			if (this.TookPhoto)
			{
				this.ResumeGameplay();
			}
			if (this.TakePhoto)
			{
				if (PlayerPrefs.GetInt("PhotographsTaken") < 10)
				{
					PlayerPrefs.SetInt("PhotographsTaken", PlayerPrefs.GetInt("PhotographsTaken") + 1);
					Application.CaptureScreenshot(Application.streamingAssetsPath + "/" + "Photograph_" + PlayerPrefs.GetInt("PhotographsTaken") + ".png");
				}
				this.TookPhoto = true;
				this.TakePhoto = false;
			}
			if (Time.timeScale > (float)0)
			{
				if ((PlayerPrefs.GetInt("UsingController") == 1 && Input.GetAxis("LT") < (float)1) || (PlayerPrefs.GetInt("UsingController") == 0 && Input.GetMouseButtonUp(1)))
				{
					this.active = false;
					this.CellPhoneGroup.active = false;
					this.Yandere.active = true;
					this.MainCamera.active = true;
					this.Yandere.transform.position = this.transform.position;
					this.Yandere.transform.eulerAngles = this.transform.eulerAngles;
					this.Yandere.Crouching = this.Crouching;
					if (!this.Crouching)
					{
						this.Yandere.Character.animation.Play("f02_idle_00");
						this.Yandere.StandUp();
					}
					else
					{
						this.Yandere.Character.animation.Play("crouchidle_10");
						this.Yandere.Crouch();
					}
					this.MainCamera.distanceMin = (float)2;
					this.MainCamera.distanceMax = (float)2;
					this.MainCamera.cameraPivot = this.Yandere.CameraPivot;
					float y2 = this.MainCamera.transform.eulerAngles.y;
					Vector3 eulerAngles2 = this.Yandere.transform.eulerAngles;
					float num2 = eulerAngles2.y = y2;
					Vector3 vector2 = this.Yandere.transform.eulerAngles = eulerAngles2;
					this.Timer = (float)0;
					this.PhoneCamera.rect = new Rect(0.5f, 0.5f, (float)0, (float)0);
				}
				this.Timer += Time.deltaTime;
				if (this.Timer > 0.5f)
				{
					this.Viewfinder.active = true;
					float y3 = Mathf.Lerp(this.PhoneCamera.rect.y, 0.25f, Time.deltaTime * (float)10);
					Rect rect = this.PhoneCamera.rect;
					float num3 = rect.y = y3;
					Rect rect2 = this.PhoneCamera.rect = rect;
					float x = Mathf.Lerp(this.PhoneCamera.rect.x, 0.25f, Time.deltaTime * (float)10);
					Rect rect3 = this.PhoneCamera.rect;
					float num4 = rect3.x = x;
					Rect rect4 = this.PhoneCamera.rect = rect3;
					float width = Mathf.Lerp(this.PhoneCamera.rect.width, 0.5f, Time.deltaTime * (float)10);
					Rect rect5 = this.PhoneCamera.rect;
					float num5 = rect5.width = width;
					Rect rect6 = this.PhoneCamera.rect = rect5;
					float height = Mathf.Lerp(this.PhoneCamera.rect.height, 0.5f, Time.deltaTime * (float)10);
					Rect rect7 = this.PhoneCamera.rect;
					float num6 = rect7.height = height;
					Rect rect8 = this.PhoneCamera.rect = rect7;
				}
				else
				{
					this.Viewfinder.active = false;
				}
			}
			else
			{
				if (Input.GetButtonDown("A"))
				{
					if (!this.SenpaiX.active)
					{
						this.SenpaiPhotos.Photos = this.SenpaiPhotos.Photos + 1;
						this.SenpaiPhotos.UpdatePhotos();
					}
					this.CameraOptions.active = false;
					this.TakePhoto = true;
				}
				if (Input.GetButtonDown("X"))
				{
					if (!this.InfoX.active)
					{
						this.StudentInfo.active = true;
						this.StudentInfo.UpdateInfo();
						this.TargetStudent.MyRenderer.gameObject.layer = 9;
						this.TextMessage.active = true;
						this.TextMessageLabel.text = "I recognize that student. Here's some information about them." + "\n" + "\n" + "Good luck.";
					}
					else if (!this.PantiesX.active)
					{
						this.TextMessage.active = true;
						if (PlayerPrefs.GetInt(this.TargetStudent.StudentName + "PantyShot") == 0)
						{
							this.TextMessageLabel.text = "Excellent! Now I have a picture of " + this.TargetStudent.StudentName + "'s panties. I owe you a favor for this one.";
							PlayerPrefs.SetInt(this.TargetStudent.StudentName + "PantyShot", 1);
						}
						else
						{
							this.TextMessageLabel.text = "I already have a picture of " + this.TargetStudent.StudentName + "'s panties. I don't need this.";
						}
					}
					else if (!this.EvidenceX.active)
					{
						this.TextMessage.active = true;
						this.TextMessageLabel.text = "Good work, but don't send me this stuff. It leaves a trail of evidence.";
					}
					else if (!this.SenpaiX.active)
					{
						this.TextMessage.active = true;
						if (PlayerPrefs.GetInt("SenpaiShots") == 0)
						{
							this.TextMessageLabel.text = "I know how you feel about this guy, but I don't need any pictures of him.";
						}
						else if (PlayerPrefs.GetInt("SenpaiShots") == 1)
						{
							this.TextMessageLabel.text = "Like I said, I don't need any pictures of this guy.";
						}
						else if (PlayerPrefs.GetInt("SenpaiShots") == 2)
						{
							this.TextMessageLabel.text = "Okay, I get it, you love him and you love taking pictures of him. I still don't need these pictures.";
						}
						else if (PlayerPrefs.GetInt("SenpaiShots") == 3)
						{
							this.TextMessageLabel.text = "You're starting to spam my inbox. Please cut it out.";
						}
						else
						{
							this.TextMessageLabel.text = "...";
						}
						PlayerPrefs.SetInt("SenpaiShots", PlayerPrefs.GetInt("SenpaiShots") + 1);
					}
					else if (this.NotFace)
					{
						this.TextMessage.active = true;
						this.TextMessageLabel.text = "Do you want me to identify this student? Please get me a clear shot of their face.";
					}
					else if (this.Skirt)
					{
						this.TextMessage.active = true;
						this.TextMessageLabel.text = "Is this supposed to be a panty shot? The panties need to be in the EXACT center of the shot.";
					}
					else
					{
						this.TextMessage.active = true;
						this.TextMessageLabel.text = "I don't get it. What are you trying to show me? Make sure the subject is in the EXACT center of the photo.";
					}
					this.ResumeGameplay();
					this.PhonePanel.active = true;
					this.PhoneCamera.enabled = false;
					this.Viewfinder.active = false;
					this.TextingMode = true;
					this.CellPhone.transform.localPosition = new Vector3(0.005f, (float)0, 0.02f);
					this.CellPhone.transform.localEulerAngles = new Vector3(71.6406f, -93.3125f, -102.5f);
				}
				if (Input.GetButtonDown("B"))
				{
					this.ResumeGameplay();
				}
			}
			if (Input.GetButtonDown("RS"))
			{
				if (!this.Crouching)
				{
					this.Crouching = true;
					this.EyeHeight = this.CrouchingHeight;
				}
				else
				{
					this.Crouching = false;
					this.EyeHeight = this.StandingHeight;
				}
			}
			float y4 = Mathf.Lerp(this.Eyes.localPosition.y, this.EyeHeight, Time.deltaTime * (float)10);
			Vector3 localPosition = this.Eyes.localPosition;
			float num7 = localPosition.y = y4;
			Vector3 vector3 = this.Eyes.localPosition = localPosition;
			if (Input.GetButtonDown("RB") && this.Timer > (float)1 && Time.timeScale > (float)0)
			{
				this.Shutter.Animate = true;
			}
			Debug.DrawRay(this.PhoneCamera.transform.position, this.PhoneCamera.transform.TransformDirection(Vector3.forward * (float)10), Color.red);
		}
		else
		{
			this.CellPhoneGroup.animation.CrossFade("textingPose");
			if (Input.GetButtonDown("B"))
			{
				this.CellPhoneGroup.animation.Play("tPose");
				this.CellPhone.transform.localPosition = this.OriginalPosition;
				this.CellPhone.transform.localEulerAngles = this.OriginalRotation;
				this.PhoneCamera.rect = new Rect(0.5f, 0.5f, (float)0, (float)0);
				this.Timer = (float)0;
				this.TextMessage.active = false;
				this.StudentInfo.active = false;
				this.PhonePanel.active = false;
				this.PhoneCamera.enabled = true;
				this.TextingMode = false;
			}
		}
	}

	public virtual void CheckPhoto()
	{
		int layerMask = 1;
		int layerMask2 = 1024;
		int layerMask3 = 2048;
		int layerMask4 = 4096;
		int layerMask5 = 8192;
		RaycastHit raycastHit = default(RaycastHit);
		this.SenpaiX.active = true;
		this.PantiesX.active = true;
		this.InfoX.active = true;
		this.EvidenceX.active = true;
		this.NotFace = false;
		this.Skirt = false;
		if (Physics.Raycast(this.PhoneCamera.transform.position, this.PhoneCamera.transform.TransformDirection(Vector3.forward), out raycastHit, float.PositiveInfinity, layerMask))
		{
			if (raycastHit.collider.gameObject.name == "Panties")
			{
				this.PantiesX.active = false;
				this.TargetStudent = (StudentScript)raycastHit.collider.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript));
			}
			else if (raycastHit.collider.gameObject.name == "Face")
			{
				this.InfoX.active = false;
				this.TargetStudent = (StudentScript)raycastHit.collider.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript));
			}
			else if (raycastHit.collider.gameObject.name == "NotFace")
			{
				this.NotFace = true;
			}
			else if (raycastHit.collider.gameObject.name == "Skirt")
			{
				this.Skirt = true;
			}
		}
		if (Physics.Raycast(this.PhoneCamera.transform.position, this.PhoneCamera.transform.TransformDirection(Vector3.forward), out raycastHit, float.PositiveInfinity, layerMask2) && (raycastHit.collider.gameObject.tag == "Corpse" || raycastHit.collider.gameObject.tag == "BloodSpawner"))
		{
			this.EvidenceX.active = false;
		}
		if (Physics.Raycast(this.PhoneCamera.transform.position, this.PhoneCamera.transform.TransformDirection(Vector3.forward), out raycastHit, float.PositiveInfinity, layerMask3) && raycastHit.collider.gameObject.tag == "Blood")
		{
			this.EvidenceX.active = false;
		}
		if (Physics.Raycast(this.PhoneCamera.transform.position, this.PhoneCamera.transform.TransformDirection(Vector3.forward), out raycastHit, float.PositiveInfinity, layerMask4) && raycastHit.collider.gameObject.name == "SenpaiFace")
		{
			this.SenpaiX.active = false;
		}
		if (Physics.Raycast(this.PhoneCamera.transform.position, this.PhoneCamera.transform.TransformDirection(Vector3.forward), out raycastHit, float.PositiveInfinity, layerMask5) && raycastHit.collider.gameObject.name == "Face")
		{
			this.InfoX.active = false;
			this.TargetStudent = (StudentScript)raycastHit.collider.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript));
		}
	}

	public virtual void ResumeGameplay()
	{
		this.StudentManager.GhostChan.active = false;
		Time.timeScale = (float)1;
		this.Viewfinder.active = true;
		float y = 0.25f;
		Rect rect = this.PhoneCamera.rect;
		float num = rect.y = y;
		Rect rect2 = this.PhoneCamera.rect = rect;
		float x = 0.25f;
		Rect rect3 = this.PhoneCamera.rect;
		float num2 = rect3.x = x;
		Rect rect4 = this.PhoneCamera.rect = rect3;
		float width = 0.5f;
		Rect rect5 = this.PhoneCamera.rect;
		float num3 = rect5.width = width;
		Rect rect6 = this.PhoneCamera.rect = rect5;
		float height = 0.5f;
		Rect rect7 = this.PhoneCamera.rect;
		float num4 = rect7.height = height;
		Rect rect8 = this.PhoneCamera.rect = rect7;
		this.CameraOptions.active = false;
		this.TookPhoto = false;
	}

	public virtual void SnapPhoto()
	{
		this.StudentManager.GhostChan.active = true;
		Time.timeScale = (float)0;
		this.CameraOptions.active = true;
		this.Viewfinder.active = false;
		int num = 0;
		Rect rect = this.PhoneCamera.rect;
		float num2 = rect.y = (float)num;
		Rect rect2 = this.PhoneCamera.rect = rect;
		int num3 = 0;
		Rect rect3 = this.PhoneCamera.rect;
		float num4 = rect3.x = (float)num3;
		Rect rect4 = this.PhoneCamera.rect = rect3;
		int num5 = 1;
		Rect rect5 = this.PhoneCamera.rect;
		float num6 = rect5.width = (float)num5;
		Rect rect6 = this.PhoneCamera.rect = rect5;
		int num7 = 1;
		Rect rect7 = this.PhoneCamera.rect;
		float num8 = rect7.height = (float)num7;
		Rect rect8 = this.PhoneCamera.rect = rect7;
		this.CheckPhoto();
	}

	public virtual void Main()
	{
	}
}
