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
	internal sealed class $UpdatePortraits$2648 : GenericGenerator<WWW>
	{
		internal StudentInfoMenuScript $self_$2653;

		public $UpdatePortraits$2648(StudentInfoMenuScript self_)
		{
			this.$self_$2653 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new StudentInfoMenuScript.$UpdatePortraits$2648.$(this.$self_$2653);
		}
	}

	public StudentManagerScript StudentManager;

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

	public UISprite[] Friends;

	public UISprite[] Panties;

	public UITexture[] PrisonBars;

	public UITexture[] Portraits;

	public UILabel NameLabel;

	public bool CyberBullying;

	public bool Distracting;

	public bool Gossiping;

	public int[] SetSizes;

	public int StudentID;

	public int Column;

	public int Row;

	public int Set;

	public int Columns;

	public int Rows;

	public virtual void Start()
	{
		for (int i = 0; i < Extensions.get_length(this.Portraits); i++)
		{
			this.Portraits[i].mainTexture = null;
			this.DeathShadows[i].enabled = false;
			this.PrisonBars[i].enabled = false;
			this.Panties[i].enabled = false;
			this.Friends[i].enabled = false;
		}
		this.Portraits[0].mainTexture = this.InfoChan;
	}

	public virtual void Update()
	{
		if (Input.GetButtonDown("A") && this.PromptBar.Label[0].text != string.Empty && PlayerPrefs.GetInt("Student_" + this.StudentID + "_Photographed") == 1)
		{
			this.StudentInfo.UpdateInfo(this.StudentID);
			this.StudentInfo.active = true;
			this.gameObject.active = false;
			this.PromptBar.ClearButtons();
			if (this.Gossiping)
			{
				this.PromptBar.Label[0].text = "Gossip";
			}
			if (this.Distracting)
			{
				this.PromptBar.Label[0].text = "Distract";
			}
			if (this.CyberBullying)
			{
				this.PromptBar.Label[0].text = "Accept";
			}
			this.PromptBar.Label[1].text = "Back";
			this.PromptBar.UpdateButtons();
		}
		if (Input.GetButtonDown("B"))
		{
			if (this.Gossiping || this.Distracting)
			{
				this.PauseScreen.Yandere.Interaction = 4;
				this.PauseScreen.Yandere.TalkTimer = (float)2;
				this.PauseScreen.MainMenu.active = true;
				this.PauseScreen.Sideways = false;
				this.PauseScreen.Show = false;
				this.gameObject.active = false;
				Time.timeScale = (float)1;
				this.Distracting = false;
				this.Gossiping = false;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
			}
			else if (this.CyberBullying)
			{
				this.PauseScreen.MainMenu.active = true;
				this.PauseScreen.Sideways = false;
				this.PauseScreen.Show = false;
				this.gameObject.active = false;
			}
			else
			{
				this.PauseScreen.MainMenu.active = true;
				this.PauseScreen.Sideways = false;
				this.PauseScreen.PressedB = true;
				this.gameObject.active = false;
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "Accept";
				this.PromptBar.Label[1].text = "Exit";
				this.PromptBar.Label[4].text = "Choose";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
			}
		}
		if (this.Row == 0 || this.Row == 1)
		{
			float y = Mathf.Lerp(this.PortraitGrid.localPosition.y, (float)0, 0.166666672f);
			Vector3 localPosition = this.PortraitGrid.localPosition;
			float num = localPosition.y = y;
			Vector3 vector = this.PortraitGrid.localPosition = localPosition;
			float y2 = Mathf.Lerp(this.Scollbar.localPosition.y, (float)115, 0.166666672f);
			Vector3 localPosition2 = this.Scollbar.localPosition;
			float num2 = localPosition2.y = y2;
			Vector3 vector2 = this.Scollbar.localPosition = localPosition2;
		}
		if (this.Row == 2 || this.Row == 3)
		{
			float y3 = Mathf.Lerp(this.PortraitGrid.localPosition.y, (float)221, 0.166666672f);
			Vector3 localPosition3 = this.PortraitGrid.localPosition;
			float num3 = localPosition3.y = y3;
			Vector3 vector3 = this.PortraitGrid.localPosition = localPosition3;
			float y4 = Mathf.Lerp(this.Scollbar.localPosition.y, (float)-115, 0.166666672f);
			Vector3 localPosition4 = this.Scollbar.localPosition;
			float num4 = localPosition4.y = y4;
			Vector3 vector4 = this.Scollbar.localPosition = localPosition4;
		}
		else if (this.Row == 4 || this.Row == 5)
		{
			float y5 = Mathf.Lerp(this.PortraitGrid.localPosition.y, (float)441, 0.166666672f);
			Vector3 localPosition5 = this.PortraitGrid.localPosition;
			float num5 = localPosition5.y = y5;
			Vector3 vector5 = this.PortraitGrid.localPosition = localPosition5;
			float y6 = Mathf.Lerp(this.Scollbar.localPosition.y, (float)-115, 0.166666672f);
			Vector3 localPosition6 = this.Scollbar.localPosition;
			float num6 = localPosition6.y = y6;
			Vector3 vector6 = this.Scollbar.localPosition = localPosition6;
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
		if (this.Gossiping && (this.StudentID == 1 || this.StudentID == this.PauseScreen.Yandere.TargetStudent.StudentID || this.JSON.StudentClubs[this.StudentID] == 9 || PlayerPrefs.GetInt("Student_" + this.StudentID + "_Dead") == 1))
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		if (this.CyberBullying && (this.JSON.StudentGenders[this.StudentID] == 1 || PlayerPrefs.GetInt("Student_" + this.StudentID + "_Dead") == 1))
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		if (this.Distracting && (this.StudentID == 0 || this.StudentID == this.PauseScreen.Yandere.TargetStudent.StudentID || this.DeathShadows[this.StudentID].enabled))
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
		return new StudentInfoMenuScript.$UpdatePortraits$2648(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
