using System;
using UnityEngine;

[Serializable]
public class HomeSleepScript : MonoBehaviour
{
	public HomeDarknessScript HomeDarkness;

	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public HomeWindowScript HomeWindow;

	public virtual void Update()
	{
		if (!this.HomeYandere.CanMove && !this.HomeDarkness.FadeOut)
		{
			if (Input.GetButtonDown("A"))
			{
				this.HomeDarkness.Sprite.color = new Color((float)0, (float)0, (float)0, (float)0);
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
				Debug.Log("Yo?");
			}
		}
	}

	public virtual void Main()
	{
	}
}
