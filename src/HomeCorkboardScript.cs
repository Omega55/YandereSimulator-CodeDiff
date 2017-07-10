﻿using System;
using UnityEngine;

public class HomeCorkboardScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public PhotoGalleryScript PhotoGallery;

	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public HomeWindowScript HomeWindow;

	public bool Loaded;

	private void Update()
	{
		if (!this.HomeYandere.CanMove)
		{
			if (!this.Loaded)
			{
				base.StartCoroutine(this.PhotoGallery.GetPhotos());
				this.Loaded = true;
			}
			if (!this.PhotoGallery.Adjusting && !this.PhotoGallery.Viewing && !this.PhotoGallery.LoadingScreen.activeInHierarchy && Input.GetButtonDown("B"))
			{
				this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
				this.HomeCamera.Target = this.HomeCamera.Targets[0];
				this.HomeCamera.CorkboardLabel.SetActive(true);
				this.PhotoGallery.enabled = false;
				this.HomeYandere.CanMove = true;
				this.HomeYandere.gameObject.SetActive(true);
				this.HomeWindow.Show = false;
				base.enabled = false;
				this.Loaded = false;
			}
		}
	}
}
