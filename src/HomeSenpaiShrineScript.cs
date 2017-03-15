using System;
using UnityEngine;

[Serializable]
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

	public int Selected;

	public int ID;

	public HomeSenpaiShrineScript()
	{
		this.Selected = 1;
	}

	public virtual void Start()
	{
		this.UpdateText();
	}

	public virtual void Update()
	{
		if (!this.HomeYandere.CanMove && !this.PauseScreen.Show)
		{
			if (this.HomeCamera.ID == 6)
			{
				this.Rotation = Mathf.Lerp(this.Rotation, (float)135, Time.deltaTime * (float)10);
				float rotation = this.Rotation;
				Vector3 localEulerAngles = this.RightDoor.localEulerAngles;
				float num = localEulerAngles.y = rotation;
				Vector3 vector = this.RightDoor.localEulerAngles = localEulerAngles;
				float y = this.Rotation * (float)-1;
				Vector3 localEulerAngles2 = this.LeftDoor.localEulerAngles;
				float num2 = localEulerAngles2.y = y;
				Vector3 vector2 = this.LeftDoor.localEulerAngles = localEulerAngles2;
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
					this.HomeYandere.active = true;
					this.HomeWindow.Show = false;
				}
			}
		}
		else
		{
			this.Rotation = Mathf.Lerp(this.Rotation, (float)0, Time.deltaTime * (float)10);
			float rotation2 = this.Rotation;
			Vector3 localEulerAngles3 = this.RightDoor.localEulerAngles;
			float num3 = localEulerAngles3.y = rotation2;
			Vector3 vector3 = this.RightDoor.localEulerAngles = localEulerAngles3;
			float rotation3 = this.Rotation;
			Vector3 localEulerAngles4 = this.LeftDoor.localEulerAngles;
			float num4 = localEulerAngles4.y = rotation3;
			Vector3 vector4 = this.LeftDoor.localEulerAngles = localEulerAngles4;
		}
	}

	public virtual void UpdateText()
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

	public virtual void Main()
	{
	}
}
