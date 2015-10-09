using System;
using UnityEngine;

[Serializable]
public class HomeVideoGamesScript : MonoBehaviour
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
			if (this.HomeYandere.transform.position.x < (float)0)
			{
				this.HomeCamera.ID = 7;
			}
		}
	}

	public virtual void Main()
	{
	}
}
