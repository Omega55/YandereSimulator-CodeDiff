using System;
using UnityEngine;

[Serializable]
public class HomeCameraScript : MonoBehaviour
{
	public HomePantyChangerScript PantyChanger;

	public HomeShrineViewerScript ShrineViewer;

	public HomePhotoManagerScript PhotoManager;

	public HomeYandereScript Yandere;

	public WindowScript CorkboardWindow;

	public WindowScript ShrineWindow;

	public WindowScript PantyWindow;

	public WindowScript ExitWindow;

	public Transform CurrentTarget;

	public Transform[] Vantages;

	public Transform[] Targets;

	public GameObject CorkboardLabel;

	public UISprite ConfirmButton;

	public UISprite Black;

	public bool ShowConfirmButton;

	public bool UsingController;

	public bool HideButton;

	public bool FreeRoam;

	public bool Darken;

	public float Timer;

	public int VantageID;

	public int TargetID;

	public int Room;

	public int ID;

	public HomeCameraScript()
	{
		this.Room = 1;
	}

	public virtual void Start()
	{
		int num = 1;
		Color color = this.Black.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Black.color = color;
		this.ExitWindow.transform.localScale = new Vector3((float)0, (float)0, (float)0);
	}

	public virtual void LateUpdate()
	{
		this.transform.position = Vector3.Lerp(this.transform.position, this.Vantages[this.VantageID].position, Time.deltaTime * (float)10);
		Quaternion to = Quaternion.LookRotation(this.Targets[this.TargetID].position - this.transform.position);
		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, to, Time.deltaTime * (float)10);
		if (!this.Darken)
		{
			if (this.Yandere.CurrentTrigger != null)
			{
				if (!this.HideButton)
				{
					this.ConfirmButton.transform.localScale = Vector3.Lerp(this.ConfirmButton.transform.localScale, new Vector3((float)2, (float)2, (float)2), Time.deltaTime * (float)10);
				}
				else
				{
					this.ConfirmButton.transform.localScale = Vector3.Lerp(this.ConfirmButton.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				}
				if (Input.GetButtonDown("A"))
				{
					this.VantageID = this.Yandere.CurrentTrigger.ID;
					this.TargetID = this.Yandere.CurrentTrigger.ID;
					this.Yandere.CanMove = false;
					this.HideButton = true;
					if (this.Yandere.CurrentTrigger.ID == 1)
					{
						if (!this.CorkboardWindow.Show)
						{
							this.Yandere.active = false;
							this.CorkboardWindow.Show = true;
							this.PhotoManager.enabled = true;
							this.StartCoroutine_Auto(this.PhotoManager.UpdatePhotos());
							this.CorkboardLabel.active = false;
						}
					}
					else if (this.Yandere.CurrentTrigger.ID == 2)
					{
						if (!this.ExitWindow.Show)
						{
							this.ExitWindow.Show = true;
						}
					}
					else if (this.Yandere.CurrentTrigger.ID == 3)
					{
						if (!this.PantyWindow.Show)
						{
							this.PantyChanger.Show = true;
							this.PantyWindow.Show = true;
						}
					}
					else if (this.Yandere.CurrentTrigger.ID == 4 && !this.ShrineWindow.Show)
					{
						this.Yandere.active = false;
						this.ShrineWindow.Show = true;
						this.ShrineViewer.enabled = true;
						this.ShrineViewer.UpdateHighlight();
					}
					this.CurrentTarget.position = this.Targets[this.TargetID].position;
				}
				if (this.CorkboardWindow.transform.localScale.x > 0.9f && Input.GetButtonDown("B") && !this.PhotoManager.ViewingPhoto && !this.PhotoManager.PlacingPhoto && this.PhotoManager.ReleasedB)
				{
					this.CorkboardLabel.active = true;
					this.PhotoManager.enabled = false;
					this.CorkboardWindow.Show = false;
					this.Yandere.CanMove = true;
					this.Yandere.active = true;
					this.HideButton = false;
					this.VantageID = 0;
					this.TargetID = 0;
					this.CurrentTarget.position = this.Targets[this.TargetID].position;
				}
				if (this.ExitWindow.transform.localScale.x > 0.9f)
				{
					if (Input.GetButtonDown("A"))
					{
						this.ExitWindow.Show = false;
						this.Darken = true;
					}
					if (Input.GetButtonDown("B"))
					{
						this.ExitWindow.Show = false;
						this.Yandere.CanMove = true;
						this.HideButton = false;
						this.VantageID = 0;
						this.TargetID = 0;
						this.CurrentTarget.position = this.Targets[this.TargetID].position;
					}
				}
				if (this.PantyWindow.transform.localScale.x > 0.9f && Input.GetButtonDown("B"))
				{
					this.PantyChanger.Show = false;
					this.PantyWindow.Show = false;
					this.Yandere.CanMove = true;
					this.HideButton = false;
					this.VantageID = 0;
					this.TargetID = 0;
					this.CurrentTarget.position = this.Targets[this.TargetID].position;
				}
				if (this.ShrineWindow.transform.localScale.x > 0.9f && Input.GetButtonDown("B"))
				{
					this.ShrineViewer.HideAll();
					this.ShrineViewer.enabled = false;
					this.ShrineWindow.Show = false;
					this.Yandere.CanMove = true;
					this.Yandere.active = true;
					this.HideButton = false;
					this.VantageID = 0;
					this.TargetID = 0;
					this.CurrentTarget.position = this.Targets[this.TargetID].position;
				}
			}
			else
			{
				this.ConfirmButton.transform.localScale = Vector3.Lerp(this.ConfirmButton.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.CurrentTarget.position = this.Targets[this.TargetID].position;
			}
			float a = this.Black.color.a - Time.deltaTime;
			Color color = this.Black.color;
			float num = color.a = a;
			Color color2 = this.Black.color = color;
			if (this.Black.color.a < (float)0)
			{
				int num2 = 0;
				Color color3 = this.Black.color;
				float num3 = color3.a = (float)num2;
				Color color4 = this.Black.color = color3;
			}
		}
		else
		{
			float a2 = this.Black.color.a + Time.deltaTime;
			Color color5 = this.Black.color;
			float num4 = color5.a = a2;
			Color color6 = this.Black.color = color5;
			if (this.Black.color.a >= (float)1)
			{
				Application.LoadLevel("SchoolScene");
			}
		}
		if (Input.anyKey || Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f || Input.GetAxisRaw("Vertical") > 0.1f || Input.GetAxisRaw("Vertical") < -0.1f)
		{
			this.ControllerCheck();
			if (this.UsingController)
			{
				this.ConfirmButton.spriteName = "A";
			}
			else
			{
				this.ConfirmButton.spriteName = "Z";
			}
		}
	}

	public virtual void ControllerCheck()
	{
		this.UsingController = false;
		if (Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Joystick1Button2) || Input.GetKey(KeyCode.Joystick1Button3) || Input.GetKey(KeyCode.Joystick1Button4) || Input.GetKey(KeyCode.Joystick1Button5) || Input.GetKey(KeyCode.Joystick1Button6) || Input.GetKey(KeyCode.Joystick1Button7) || Input.GetKey(KeyCode.Joystick1Button8) || Input.GetKey(KeyCode.Joystick1Button9) || Input.GetKey(KeyCode.Joystick1Button10) || Input.GetKey(KeyCode.Joystick1Button11) || Input.GetKey(KeyCode.Joystick1Button12) || Input.GetKey(KeyCode.Joystick1Button13) || Input.GetKey(KeyCode.Joystick1Button14) || Input.GetKey(KeyCode.Joystick1Button15) || Input.GetKey(KeyCode.Joystick1Button16) || Input.GetKey(KeyCode.Joystick1Button17) || Input.GetKey(KeyCode.Joystick1Button18) || Input.GetKey(KeyCode.Joystick1Button19))
		{
			this.UsingController = true;
		}
		if (Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f || Input.GetAxisRaw("Vertical") > 0.1f || Input.GetAxisRaw("Vertical") < -0.1f)
		{
			if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
			{
				this.UsingController = false;
			}
			else
			{
				this.UsingController = true;
			}
		}
	}

	public virtual void Main()
	{
	}
}
