using System;
using UnityEngine;

[Serializable]
public class HomeCorkboardScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public PhotoGalleryScript PhotoGallery;

	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public HomeWindowScript HomeWindow;

	public bool Loaded;

	public virtual void Update()
	{
		if (!this.HomeYandere.CanMove)
		{
			if (!this.Loaded)
			{
				this.StartCoroutine_Auto(this.PhotoGallery.GetPhotos());
				this.Loaded = true;
			}
			if (!this.PhotoGallery.Adjusting && !this.PhotoGallery.Viewing && Input.GetButtonDown("B"))
			{
				this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
				this.HomeCamera.Target = this.HomeCamera.Targets[0];
				this.HomeCamera.CorkboardLabel.active = true;
				this.PhotoGallery.enabled = false;
				this.HomeYandere.CanMove = true;
				this.HomeYandere.active = true;
				this.HomeWindow.Show = false;
				this.enabled = false;
				this.Loaded = false;
				if (!this.HomeCamera.DisablePost)
				{
					this.HomeCamera.EnableEffects();
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
