using System;
using UnityEngine;

[Serializable]
public class HomeSenpaiShrineScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public HomeWindowScript HomeWindow;

	public OutlineScript[] Highlights;

	public UILabel NameLabel;

	public UILabel DescLabel;

	public string[] Names;

	public string[] Descs;

	public int Selected;

	public int ID;

	public virtual void Start()
	{
		this.DisableHighlights();
		this.enabled = false;
	}

	public virtual void Update()
	{
		if (!this.HomeYandere.CanMove)
		{
			if (this.Selected == 0)
			{
				this.Selected = 1;
				this.UpdateHighlight();
			}
			if (this.InputManager.TappedRight)
			{
				this.Selected++;
				this.UpdateHighlight();
			}
			if (this.InputManager.TappedLeft)
			{
				this.Selected--;
				this.UpdateHighlight();
			}
			if (Input.GetButtonDown("B"))
			{
				this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
				this.HomeCamera.Target = this.HomeCamera.Targets[0];
				this.HomeYandere.CanMove = true;
				this.HomeYandere.active = true;
				this.HomeWindow.Show = false;
				this.enabled = false;
				this.Selected = 0;
				this.DisableHighlights();
			}
		}
	}

	public virtual void UpdateHighlight()
	{
		if (this.Selected > 3)
		{
			this.Selected = 1;
		}
		else if (this.Selected < 1)
		{
			this.Selected = 3;
		}
		this.DisableHighlights();
		this.Highlights[this.Selected].h.enabled = true;
		this.NameLabel.text = this.Names[this.Selected];
		this.DescLabel.text = this.Descs[this.Selected];
	}

	public virtual void DisableHighlights()
	{
		this.ID = 1;
		while (this.ID < 4)
		{
			this.Highlights[this.ID].h.enabled = false;
			this.ID++;
		}
	}

	public virtual void Main()
	{
	}
}
