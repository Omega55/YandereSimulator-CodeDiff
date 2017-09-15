using System;
using UnityEngine;

public class HomeExitScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public HomeDarknessScript HomeDarkness;

	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public HomeWindowScript HomeWindow;

	public Transform Highlight;

	public UILabel[] Labels;

	public int ID = 1;

	private void Start()
	{
		UILabel uilabel = this.Labels[2];
		uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
		if (HomeGlobals.Night)
		{
			UILabel uilabel2 = this.Labels[1];
			uilabel2.color = new Color(uilabel2.color.r, uilabel2.color.g, uilabel2.color.b, 0.5f);
			uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
		}
	}

	private void Update()
	{
		if (!this.HomeYandere.CanMove && !this.HomeDarkness.FadeOut)
		{
			if (this.InputManager.TappedDown)
			{
				this.ID++;
				if (this.ID > 3)
				{
					this.ID = 1;
				}
				this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 50f - (float)this.ID * 50f, this.Highlight.localPosition.z);
			}
			if (this.InputManager.TappedUp)
			{
				this.ID--;
				if (this.ID < 1)
				{
					this.ID = 3;
				}
				this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 50f - (float)this.ID * 50f, this.Highlight.localPosition.z);
			}
			if (Input.GetButtonDown("A") && this.ID != 2 && (!HomeGlobals.Night || (HomeGlobals.Night && this.ID == 3)))
			{
				if (this.ID < 3 && SchoolGlobals.SchoolAtmosphere >= 50f)
				{
					this.HomeDarkness.Sprite.color = new Color(1f, 1f, 1f, 0f);
				}
				this.HomeDarkness.FadeOut = true;
				this.HomeWindow.Show = false;
				base.enabled = false;
			}
			if (Input.GetButtonDown("B"))
			{
				this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
				this.HomeCamera.Target = this.HomeCamera.Targets[0];
				this.HomeYandere.CanMove = true;
				this.HomeWindow.Show = false;
				base.enabled = false;
			}
		}
	}
}
