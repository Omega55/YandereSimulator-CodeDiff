﻿using System;
using UnityEngine;

[Serializable]
public class HomeExitScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public HomeDarknessScript HomeDarkness;

	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public HomeWindowScript HomeWindow;

	public Transform Highlight;

	public int ID;

	public HomeExitScript()
	{
		this.ID = 1;
	}

	public virtual void Update()
	{
		if (!this.HomeYandere.CanMove && !this.HomeDarkness.FadeOut)
		{
			if (this.InputManager.TappedUp || this.InputManager.TappedDown)
			{
				if (this.ID == 1)
				{
					int num = -75;
					Vector3 localPosition = this.Highlight.localPosition;
					float num2 = localPosition.y = (float)num;
					Vector3 vector = this.Highlight.localPosition = localPosition;
					this.ID = 2;
				}
				else
				{
					int num3 = -25;
					Vector3 localPosition2 = this.Highlight.localPosition;
					float num4 = localPosition2.y = (float)num3;
					Vector3 vector2 = this.Highlight.localPosition = localPosition2;
					this.ID = 1;
				}
			}
			if (Input.GetButtonDown("A"))
			{
				if (this.ID == 1)
				{
					this.HomeDarkness.Sprite.color = new Color((float)1, (float)1, (float)1, (float)0);
				}
				this.HomeDarkness.FadeOut = true;
				this.HomeWindow.Show = false;
				this.enabled = false;
			}
			if (Input.GetButtonDown("B"))
			{
				this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
				this.HomeCamera.Target = this.HomeCamera.Targets[0];
				this.HomeYandere.CanMove = true;
				this.HomeWindow.Show = false;
				this.enabled = false;
			}
		}
	}

	public virtual void Main()
	{
	}
}