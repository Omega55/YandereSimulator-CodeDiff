using System;
using UnityEngine;

public class HomeSenpaiShrineScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public HomeWindowScript HomeWindow;

	public Transform[] Destinations;

	public Transform[] Targets;

	public Transform RightDoor;

	public Transform LeftDoor;

	public UILabel NameLabel;

	public UILabel DescLabel;

	public string[] Names;

	public string[] Descs;

	public float Rotation;

	public int Selected = 1;

	public int ID;

	private void Start()
	{
		this.UpdateText();
	}

	private void Update()
	{
		if (!this.HomeYandere.CanMove && !this.PauseScreen.Show)
		{
			if (this.HomeCamera.ID == 6)
			{
				this.Rotation = Mathf.Lerp(this.Rotation, 135f, Time.deltaTime * 10f);
				this.RightDoor.localEulerAngles = new Vector3(this.RightDoor.localEulerAngles.x, this.Rotation, this.RightDoor.localEulerAngles.z);
				this.LeftDoor.localEulerAngles = new Vector3(this.LeftDoor.localEulerAngles.x, -this.Rotation, this.LeftDoor.localEulerAngles.z);
				if (this.InputManager.TappedRight)
				{
					this.Selected++;
					this.UpdateText();
				}
				if (this.InputManager.TappedLeft)
				{
					this.Selected--;
					this.UpdateText();
				}
				this.HomeCamera.Destination = this.Destinations[this.Selected];
				this.HomeCamera.Target = this.Targets[this.Selected];
				if (Input.GetButtonDown("B"))
				{
					this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
					this.HomeCamera.Target = this.HomeCamera.Targets[0];
					this.HomeYandere.CanMove = true;
					this.HomeYandere.gameObject.SetActive(true);
					this.HomeWindow.Show = false;
				}
			}
		}
		else
		{
			this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 10f);
			this.RightDoor.localEulerAngles = new Vector3(this.RightDoor.localEulerAngles.x, this.Rotation, this.RightDoor.localEulerAngles.z);
			this.LeftDoor.localEulerAngles = new Vector3(this.LeftDoor.localEulerAngles.x, this.Rotation, this.LeftDoor.localEulerAngles.z);
		}
	}

	private void UpdateText()
	{
		if (this.Selected > 11)
		{
			this.Selected = 1;
		}
		else if (this.Selected < 1)
		{
			this.Selected = 11;
		}
		this.NameLabel.text = this.Names[this.Selected];
		this.DescLabel.text = this.Descs[this.Selected];
	}
}
