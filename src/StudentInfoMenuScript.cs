using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class StudentInfoMenuScript : MonoBehaviour
{
	[CompilerGenerated]
	[Serializable]
	internal sealed class $UpdatePortraits$1636 : GenericGenerator<WWW>
	{
		internal StudentInfoMenuScript $self_$1641;

		public $UpdatePortraits$1636(StudentInfoMenuScript self_)
		{
			this.$self_$1641 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new StudentInfoMenuScript.$UpdatePortraits$1636.$(this.$self_$1641);
		}
	}

	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public StudentInfoScript StudentInfo;

	public PromptBarScript PromptBar;

	public JsonScript JSON;

	public Texture UnknownPortrait;

	public Texture InfoChan;

	public Transform PortraitGrid;

	public Transform Highlight;

	public Transform Scollbar;

	public UISprite[] DeathShadows;

	public UITexture[] Portraits;

	public UITexture[] Panties;

	public UILabel NameLabel;

	public int StudentID;

	public int Column;

	public int Row;

	public int Set;

	public int Columns;

	public int Rows;

	public int[] SetSizes;

	public virtual void Start()
	{
		for (int i = 0; i < Extensions.get_length(this.Portraits); i++)
		{
			this.Portraits[i].mainTexture = null;
			this.DeathShadows[i].enabled = false;
			this.Panties[i].enabled = false;
		}
		this.Portraits[0].mainTexture = this.InfoChan;
	}

	public virtual void Update()
	{
		if (Input.GetButtonDown("A") && PlayerPrefs.GetInt("Student_" + this.StudentID + "_Photographed") == 1)
		{
			this.StudentInfo.UpdateInfo(this.StudentID);
			this.StudentInfo.active = true;
			this.gameObject.active = false;
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[1].text = "Back";
			this.PromptBar.UpdateButtons();
		}
		if (Input.GetButtonDown("B"))
		{
			this.PauseScreen.MainMenu.active = true;
			this.PauseScreen.Sideways = false;
			this.gameObject.active = false;
			this.PromptBar.ClearButtons();
			this.PromptBar.Show = false;
		}
		if (this.Row > 1)
		{
			float y = Mathf.Lerp(this.PortraitGrid.localPosition.y, (float)221, 0.166666672f);
			Vector3 localPosition = this.PortraitGrid.localPosition;
			float num = localPosition.y = y;
			Vector3 vector = this.PortraitGrid.localPosition = localPosition;
			float y2 = Mathf.Lerp(this.Scollbar.localPosition.y, (float)-115, 0.166666672f);
			Vector3 localPosition2 = this.Scollbar.localPosition;
			float num2 = localPosition2.y = y2;
			Vector3 vector2 = this.Scollbar.localPosition = localPosition2;
		}
		else
		{
			float y3 = Mathf.Lerp(this.PortraitGrid.localPosition.y, (float)0, 0.166666672f);
			Vector3 localPosition3 = this.PortraitGrid.localPosition;
			float num3 = localPosition3.y = y3;
			Vector3 vector3 = this.PortraitGrid.localPosition = localPosition3;
			float y4 = Mathf.Lerp(this.Scollbar.localPosition.y, (float)115, 0.166666672f);
			Vector3 localPosition4 = this.Scollbar.localPosition;
			float num4 = localPosition4.y = y4;
			Vector3 vector4 = this.Scollbar.localPosition = localPosition4;
		}
		if (this.InputManager.TappedUp)
		{
			this.Row--;
			if (this.Row < 0)
			{
				this.Row = this.Rows;
			}
			this.UpdateHighlight();
		}
		if (this.InputManager.TappedDown)
		{
			this.Row++;
			if (this.Row > this.Rows)
			{
				this.Row = 0;
			}
			this.UpdateHighlight();
		}
		if (this.InputManager.TappedRight)
		{
			this.Column++;
			if (this.Column > this.Columns)
			{
				this.Column = 0;
			}
			this.UpdateHighlight();
		}
		if (this.InputManager.TappedLeft)
		{
			this.Column--;
			if (this.Column < 0)
			{
				this.Column = this.Columns;
			}
			this.UpdateHighlight();
		}
	}

	public virtual void UpdateHighlight()
	{
		this.StudentID = this.Column + this.Row * (this.Columns + 1);
		if (PlayerPrefs.GetInt("Student_" + this.StudentID + "_Photographed") == 1)
		{
			this.PromptBar.Label[0].text = "View Info";
			this.PromptBar.UpdateButtons();
		}
		else
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		if (this.StudentID < this.SetSizes[1])
		{
			this.Set = 0;
		}
		else
		{
			this.Set = 1;
		}
		int num = -330 + this.Column * 110;
		Vector3 localPosition = this.Highlight.localPosition;
		float num2 = localPosition.x = (float)num;
		Vector3 vector = this.Highlight.localPosition = localPosition;
		int num3 = 55 - this.Row * 110 - this.Set * 60;
		Vector3 localPosition2 = this.Highlight.localPosition;
		float num4 = localPosition2.y = (float)num3;
		Vector3 vector2 = this.Highlight.localPosition = localPosition2;
		this.UpdateNameLabel();
	}

	public virtual void UpdateNameLabel()
	{
		if (PlayerPrefs.GetInt("Student_" + this.StudentID + "_Photographed") == 1)
		{
			this.NameLabel.text = string.Empty + this.JSON.StudentNames[this.StudentID];
		}
		else
		{
			this.NameLabel.text = "Unknown";
		}
	}

	public virtual IEnumerator UpdatePortraits()
	{
		return new StudentInfoMenuScript.$UpdatePortraits$1636(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
