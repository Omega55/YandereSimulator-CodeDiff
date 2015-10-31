using System;
using UnityEngine;

[Serializable]
public class HomeMangaScript : MonoBehaviour
{
	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public HomeWindowScript HomeWindow;

	public virtual void Update()
	{
		if (!this.HomeYandere.CanMove && Input.GetButtonDown("B"))
		{
			this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
			this.HomeCamera.Target = this.HomeCamera.Targets[0];
			this.HomeYandere.CanMove = true;
			this.HomeYandere.active = true;
			this.HomeWindow.Show = false;
			this.enabled = false;
		}
	}

	public virtual void Main()
	{
	}
}
