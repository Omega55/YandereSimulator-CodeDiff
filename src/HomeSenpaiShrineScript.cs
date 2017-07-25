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

	private int Rows = 5;

	private int Columns = 3;

	private int X = 1;

	private int Y = 3;

	private void Start()
	{
		this.UpdateText(this.GetCurrentIndex());
	}

	private bool InUpperHalf()
	{
		return this.Y < 2;
	}

	private int GetCurrentIndex()
	{
		if (this.InUpperHalf())
		{
			return this.Y;
		}
		return 2 + (this.X + (this.Y - 2) * this.Columns);
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
				if (this.InputManager.TappedUp)
				{
					this.Y = ((this.Y <= 0) ? (this.Rows - 1) : (this.Y - 1));
				}
				if (this.InputManager.TappedDown)
				{
					this.Y = ((this.Y >= this.Rows - 1) ? 0 : (this.Y + 1));
				}
				if (this.InputManager.TappedRight && !this.InUpperHalf())
				{
					this.X = ((this.X >= this.Columns - 1) ? 0 : (this.X + 1));
				}
				if (this.InputManager.TappedLeft && !this.InUpperHalf())
				{
					this.X = ((this.X <= 0) ? (this.Columns - 1) : (this.X - 1));
				}
				if (this.InUpperHalf())
				{
					this.X = 1;
				}
				int currentIndex = this.GetCurrentIndex();
				this.HomeCamera.Destination = this.Destinations[currentIndex];
				this.HomeCamera.Target = this.Targets[currentIndex];
				bool flag = this.InputManager.TappedUp || this.InputManager.TappedDown || this.InputManager.TappedRight || this.InputManager.TappedLeft;
				if (flag)
				{
					this.UpdateText(currentIndex);
				}
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

	private void UpdateText(int newIndex)
	{
		this.NameLabel.text = this.Names[newIndex];
		this.DescLabel.text = this.Descs[newIndex];
	}
}
