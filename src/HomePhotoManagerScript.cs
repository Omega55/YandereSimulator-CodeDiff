using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class HomePhotoManagerScript : MonoBehaviour
{
	[CompilerGenerated]
	[Serializable]
	internal sealed class $UpdatePhotos$1080 : GenericGenerator<WWW>
	{
		internal HomePhotoManagerScript $self_$1086;

		public $UpdatePhotos$1080(HomePhotoManagerScript self_)
		{
			this.$self_$1086 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new HomePhotoManagerScript.$UpdatePhotos$1080.$(this.$self_$1086);
		}
	}

	public UITexture[] CorkboardPhotographs;

	public UITexture[] Photographs;

	public Transform CorkboardPanel;

	public UITexture CurrentPhoto;

	public UILabel ButtonLabel;

	public GameObject Highlight;

	public int HighlightPosition;

	public int TotalPhotographs;

	public int Selected;

	public int Offset;

	public bool PlacingPhoto;

	public bool ViewingPhoto;

	public bool DPadTapped;

	public bool ReleasedB;

	public bool Tapped;

	public int ID;

	public HomePhotoManagerScript()
	{
		this.ReleasedB = true;
	}

	public virtual void Start()
	{
		PlayerPrefs.SetInt("PlacedPhotographs", 0);
		this.ID = 1;
		while (this.ID < this.TotalPhotographs + 1)
		{
			PlayerPrefs.SetInt("Photograph_" + this.ID + "_Dark", 0);
			this.ID++;
		}
		this.StartCoroutine_Auto(this.UpdatePhotos());
	}

	public virtual void Update()
	{
		if (this.PlacingPhoto)
		{
			if (this.CurrentPhoto.transform.localScale.x > 1.1f)
			{
				this.CurrentPhoto.transform.position = Vector3.Lerp(this.CurrentPhoto.transform.position, this.CorkboardPanel.position, Time.deltaTime * (float)10);
				this.CurrentPhoto.transform.localScale = Vector3.Lerp(this.CurrentPhoto.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			}
			else
			{
				this.CorkboardPhotographs[PlayerPrefs.GetInt("PlacedPhotographs")].transform.localScale = new Vector3((float)1, (float)1, (float)1);
				float x = this.CurrentPhoto.transform.localPosition.x + Input.GetAxis("Horizontal") * Time.deltaTime * (float)1000;
				Vector3 localPosition = this.CurrentPhoto.transform.localPosition;
				float num = localPosition.x = x;
				Vector3 vector = this.CurrentPhoto.transform.localPosition = localPosition;
				float y = this.CurrentPhoto.transform.localPosition.y + Input.GetAxis("Vertical") * Time.deltaTime * (float)1000;
				Vector3 localPosition2 = this.CurrentPhoto.transform.localPosition;
				float num2 = localPosition2.y = y;
				Vector3 vector2 = this.CurrentPhoto.transform.localPosition = localPosition2;
				if (Input.GetButton("LB"))
				{
					float z = this.CurrentPhoto.transform.localEulerAngles.z + Time.deltaTime * (float)100;
					Vector3 localEulerAngles = this.CurrentPhoto.transform.localEulerAngles;
					float num3 = localEulerAngles.z = z;
					Vector3 vector3 = this.CurrentPhoto.transform.localEulerAngles = localEulerAngles;
				}
				if (Input.GetButton("RB"))
				{
					float z2 = this.CurrentPhoto.transform.localEulerAngles.z - Time.deltaTime * (float)100;
					Vector3 localEulerAngles2 = this.CurrentPhoto.transform.localEulerAngles;
					float num4 = localEulerAngles2.z = z2;
					Vector3 vector4 = this.CurrentPhoto.transform.localEulerAngles = localEulerAngles2;
				}
				if (this.CurrentPhoto.transform.localPosition.x > (float)430)
				{
					int num5 = 430;
					Vector3 localPosition3 = this.CurrentPhoto.transform.localPosition;
					float num6 = localPosition3.x = (float)num5;
					Vector3 vector5 = this.CurrentPhoto.transform.localPosition = localPosition3;
				}
				else if (this.CurrentPhoto.transform.localPosition.x < (float)-430)
				{
					int num7 = -430;
					Vector3 localPosition4 = this.CurrentPhoto.transform.localPosition;
					float num8 = localPosition4.x = (float)num7;
					Vector3 vector6 = this.CurrentPhoto.transform.localPosition = localPosition4;
				}
				if (this.CurrentPhoto.transform.localPosition.y > (float)450)
				{
					int num9 = 450;
					Vector3 localPosition5 = this.CurrentPhoto.transform.localPosition;
					float num10 = localPosition5.y = (float)num9;
					Vector3 vector7 = this.CurrentPhoto.transform.localPosition = localPosition5;
				}
				else if (this.CurrentPhoto.transform.localPosition.y < (float)-450)
				{
					int num11 = -450;
					Vector3 localPosition6 = this.CurrentPhoto.transform.localPosition;
					float num12 = localPosition6.y = (float)num11;
					Vector3 vector8 = this.CurrentPhoto.transform.localPosition = localPosition6;
				}
			}
			if (Input.GetButtonDown("A"))
			{
				PlayerPrefs.SetInt("PlacedPhotographs", PlayerPrefs.GetInt("PlacedPhotographs") + 1);
				PlayerPrefs.SetInt("Photograph_" + this.Selected + "_Dark", 1);
				this.ButtonLabel.text = "View";
				this.Highlight.active = true;
				this.PlacingPhoto = false;
				this.ViewingPhoto = false;
				this.StartCoroutine_Auto(this.UpdatePhotos());
			}
			if (Input.GetButtonDown("B"))
			{
				this.Photographs[this.HighlightPosition - 1].transform.position = this.CurrentPhoto.transform.position;
				this.CurrentPhoto.active = false;
				this.ButtonLabel.text = "Place";
				this.PlacingPhoto = false;
				this.ViewingPhoto = true;
				this.ReleasedB = false;
			}
		}
		else if (this.ViewingPhoto)
		{
			this.Photographs[this.HighlightPosition - 1].transform.localScale = Vector3.Lerp(this.Photographs[this.HighlightPosition - 1].transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			this.Photographs[this.HighlightPosition - 1].transform.localPosition = Vector3.Lerp(this.Photographs[this.HighlightPosition - 1].transform.localPosition, new Vector3((float)0, (float)575, (float)0), Time.deltaTime * (float)10);
			if (Input.GetButtonDown("A"))
			{
				this.CurrentPhoto = this.CorkboardPhotographs[PlayerPrefs.GetInt("PlacedPhotographs")];
				this.CurrentPhoto.active = true;
				this.CurrentPhoto.transform.localScale = new Vector3(5.5f, 5.5f, 5.5f);
				this.CurrentPhoto.mainTexture = this.Photographs[this.HighlightPosition - 1].mainTexture;
				this.CurrentPhoto.transform.position = this.Photographs[this.HighlightPosition - 1].transform.position;
				this.Photographs[this.HighlightPosition - 1].transform.localScale = new Vector3(0.1333333f, 0.1333333f, 0.1333333f);
				this.Photographs[this.HighlightPosition - 1].transform.localPosition = new Vector3((float)(-525 + 175 * this.HighlightPosition), (float)0, (float)0);
				this.ButtonLabel.text = "Pin";
				this.ViewingPhoto = false;
				this.PlacingPhoto = true;
			}
			if (Input.GetButtonDown("B"))
			{
				this.ButtonLabel.text = "View";
				this.Highlight.active = true;
				this.ViewingPhoto = false;
				this.ReleasedB = false;
			}
		}
		else
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
					this.HighlightPosition++;
					this.UpdateHighlight();
					this.Selected++;
					if (this.Selected > this.TotalPhotographs)
					{
						this.Selected = this.TotalPhotographs;
					}
				}
				if (Input.GetAxis("DpadX") < -0.5f || Input.GetAxis("Horizontal") < -0.5f)
				{
					if (Input.GetAxis("DpadX") < -0.5f)
					{
						this.DPadTapped = true;
					}
					this.Tapped = true;
					this.HighlightPosition--;
					this.UpdateHighlight();
					this.Selected--;
					if (this.Selected < 1)
					{
						this.Selected = 1;
					}
				}
				if (Input.GetButtonDown("A") && PlayerPrefs.GetInt("PlacedPhotographs") < this.TotalPhotographs && PlayerPrefs.GetInt("Photograph_" + this.Selected + "_Dark") == 0)
				{
					this.ButtonLabel.text = "Place";
					this.Highlight.active = false;
					this.ViewingPhoto = true;
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
			this.ID = 0;
			while (this.ID < 5)
			{
				this.Photographs[this.ID].transform.localScale = Vector3.Lerp(this.Photographs[this.ID].transform.localScale, new Vector3(0.1333333f, 0.1333333f, 0.1333333f), Time.deltaTime * (float)10);
				this.Photographs[this.HighlightPosition - 1].transform.localPosition = Vector3.Lerp(this.Photographs[this.HighlightPosition - 1].transform.localPosition, new Vector3((float)(-525 + 175 * this.HighlightPosition), (float)0, (float)0), Time.deltaTime * (float)10);
				this.ID++;
			}
		}
		if (Input.GetButtonUp("B"))
		{
			this.ReleasedB = true;
		}
		this.Photographs[0].material.color = new Color(0.5f, 0.5f, 0.5f, (float)1);
	}

	public virtual void UpdateHighlight()
	{
		if (this.HighlightPosition < 1)
		{
			this.HighlightPosition = 1;
			if (this.Selected > 1)
			{
				this.Offset--;
				this.StartCoroutine_Auto(this.UpdatePhotos());
			}
		}
		if (this.HighlightPosition > 5)
		{
			this.HighlightPosition = 5;
			if (this.Selected < this.TotalPhotographs)
			{
				this.Offset++;
				this.StartCoroutine_Auto(this.UpdatePhotos());
			}
		}
		int num = -525 + 175 * this.HighlightPosition;
		Vector3 localPosition = this.Highlight.transform.localPosition;
		float num2 = localPosition.x = (float)num;
		Vector3 vector = this.Highlight.transform.localPosition = localPosition;
	}

	public virtual IEnumerator UpdatePhotos()
	{
		return new HomePhotoManagerScript.$UpdatePhotos$1080(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
