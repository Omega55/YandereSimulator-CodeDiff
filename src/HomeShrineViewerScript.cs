using System;
using UnityEngine;

[Serializable]
public class HomeShrineViewerScript : MonoBehaviour
{
	public UILabel NameLabel;

	public UILabel DescLabel;

	public bool DPadTapped;

	public bool Tapped;

	public int Selected;

	public int TotalObjects;

	public GameObject[] Objects;

	public string[] Names;

	public string[] Descs;

	public virtual void Start()
	{
		this.HideAll();
		this.enabled = false;
	}

	public virtual void Update()
	{
		if (!this.Tapped)
		{
			if (Input.GetAxis("DpadX") > 0.5f || Input.GetAxis("Horizontal") > 0.5f)
			{
				if (Input.GetAxis("DpadX") > 0.5f)
				{
					this.DPadTapped = true;
				}
				this.Tapped = true;
				this.Selected++;
				if (this.Selected > this.TotalObjects - 1)
				{
					this.Selected = 0;
				}
				this.HideAll();
				this.UpdateHighlight();
			}
			if (Input.GetAxis("DpadX") < -0.5f || Input.GetAxis("Horizontal") < -0.5f)
			{
				if (Input.GetAxis("DpadX") < -0.5f)
				{
					this.DPadTapped = true;
				}
				this.Tapped = true;
				this.Selected--;
				if (this.Selected < 0)
				{
					this.Selected = this.TotalObjects - 1;
				}
				this.HideAll();
				this.UpdateHighlight();
			}
		}
		else if (this.DPadTapped)
		{
			if (Input.GetAxis("DpadX") > -0.5f && Input.GetAxis("DpadX") < 0.5f)
			{
				this.DPadTapped = false;
				this.Tapped = false;
			}
		}
		else if (Input.GetAxis("Horizontal") > -0.5f && Input.GetAxis("Horizontal") < 0.5f)
		{
			this.Tapped = false;
		}
	}

	public virtual void HideAll()
	{
		for (int i = 0; i < this.TotalObjects; i++)
		{
			((HighlightableObject)this.Objects[i].GetComponent(typeof(HighlightableObject))).enabled = false;
		}
	}

	public virtual void UpdateHighlight()
	{
		((HighlightableObject)this.Objects[this.Selected].GetComponent(typeof(HighlightableObject))).enabled = true;
		this.NameLabel.text = this.Names[this.Selected];
		this.DescLabel.text = this.Descs[this.Selected];
	}

	public virtual void Main()
	{
	}
}
