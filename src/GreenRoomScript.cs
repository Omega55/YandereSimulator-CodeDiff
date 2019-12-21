using System;
using UnityEngine;

public class GreenRoomScript : MonoBehaviour
{
	public QualityManagerScript QualityManager;

	public Color[] Colors;

	public Renderer[] Renderers;

	public int ID;

	private void Start()
	{
		this.QualityManager.Obscurance.enabled = false;
		this.UpdateColor();
	}

	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.UpdateColor();
		}
	}

	private void UpdateColor()
	{
		this.ID++;
		if (this.ID > 7)
		{
			this.ID = 0;
		}
		this.Renderers[0].material.color = this.Colors[this.ID];
		this.Renderers[1].material.color = this.Colors[this.ID];
	}
}
