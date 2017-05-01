using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class StudentInfoMenuScript : MonoBehaviour
{
	[CompilerGenerated]
	[Serializable]
	internal sealed class $UpdatePortraits$3127 : GenericGenerator<WWW>
	{
		internal StudentInfoMenuScript $self_$3132;

		public $UpdatePortraits$3127(StudentInfoMenuScript self_)
		{
			this.$self_$3132 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new StudentInfoMenuScript.$UpdatePortraits$3127.$(this.$self_$3132);
		}
	}

	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public StudentInfoScript StudentInfo;

	public PromptBarScript PromptBar;

	public JsonScript JSON;

	public GameObject StudentPortrait;

	public Texture UnknownPortrait;

	public Texture BlankPortrait;

	public Texture InfoChan;

	public Transform PortraitGrid;

	public Transform Highlight;

	public Transform Scollbar;

	public StudentPortraitScript[] StudentPortraits;

	public bool[] PortraitLoaded;

	public UISprite[] DeathShadows;

	public UISprite[] Friends;

	public UISprite[] Panties;

	public UITexture[] PrisonBars;

	public UITexture[] Portraits;

	public UILabel NameLabel;

	public bool CustomPortraits;

	public bool CyberBullying;

	public bool MatchMaking;

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
		for (int i = 1; i < 101; i++)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.StudentPortrait, this.transform.position, Quaternion.identity);
			gameObject.transform.parent = this.PortraitGrid;
			gameObject.transform.localPosition = new Vector3((float)(-300 + this.Column * 150), (float)(80 - this.Row * 160), (float)0);
			gameObject.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
			gameObject.transform.localScale = new Vector3((float)1, (float)1, (float)1);
			this.StudentPortraits[i] = (StudentPortraitScript)gameObject.GetComponent(typeof(StudentPortraitScript));
			this.Column++;
			if (this.Column > 4)
			{
				this.Column = 0;
				this.Row++;
			}
		}
		this.Column = 0;
		this.Row = 0;
		if (File.Exists(Application.streamingAssetsPath + "/CustomPortraits.txt"))
		{
			string a = File.ReadAllText(Application.streamingAssetsPath + "/CustomPortraits.txt");
			if (a == "1")
			{
				this.CustomPortraits = true;
			}
		}
	}

	public virtual void Update()
	{
		if (Input.GetButtonDown("A") && this.PromptBar.Label[0].text != string.Empty && PlayerPrefs.GetInt("Student_" + this.StudentID + "_Photographed") == 1)
		{
			this.StudentInfo.gameObject.active = true;
			this.StudentInfo.UpdateInfo(this.StudentID);
			this.StudentInfo.Topics.active = false;
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
			if (this.MatchMaking)
			{
				this.PromptBar.Label[0].text = "Match";
			}
			this.PromptBar.Label[1].text = "Back";
			this.PromptBar.Label[3].text = "Interests";
			this.PromptBar.UpdateButtons();
		}
		if (Input.GetButtonDown("B"))
		{
			if (this.Gossiping || this.Distracting || this.MatchMaking)
			{
				this.PauseScreen.Yandere.Interaction = 4;
				this.PauseScreen.Yandere.TalkTimer = (float)2;
				this.PauseScreen.MainMenu.active = true;
				this.PauseScreen.Sideways = false;
				this.PauseScreen.Show = false;
				this.gameObject.active = false;
				Time.timeScale = (float)1;
				this.Distracting = false;
				this.MatchMaking = false;
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
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
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
		}
		else if (this.Row == 2 || this.Row == 3)
		{
			float y2 = Mathf.Lerp(this.PortraitGrid.localPosition.y, (float)320, 0.166666672f);
			Vector3 localPosition2 = this.PortraitGrid.localPosition;
			float num2 = localPosition2.y = y2;
			Vector3 vector2 = this.PortraitGrid.localPosition = localPosition2;
		}
		else if (this.Row == 4 || this.Row == 5)
		{
			float y3 = Mathf.Lerp(this.PortraitGrid.localPosition.y, (float)640, 0.166666672f);
			Vector3 localPosition3 = this.PortraitGrid.localPosition;
			float num3 = localPosition3.y = y3;
			Vector3 vector3 = this.PortraitGrid.localPosition = localPosition3;
		}
		else if (this.Row == 6 || this.Row == 7)
		{
			float y4 = Mathf.Lerp(this.PortraitGrid.localPosition.y, (float)960, 0.166666672f);
			Vector3 localPosition4 = this.PortraitGrid.localPosition;
			float num4 = localPosition4.y = y4;
			Vector3 vector4 = this.PortraitGrid.localPosition = localPosition4;
		}
		else if (this.Row == 8 || this.Row == 9)
		{
			float y5 = Mathf.Lerp(this.PortraitGrid.localPosition.y, (float)1280, 0.166666672f);
			Vector3 localPosition5 = this.PortraitGrid.localPosition;
			float num5 = localPosition5.y = y5;
			Vector3 vector5 = this.PortraitGrid.localPosition = localPosition5;
		}
		else if (this.Row == 10 || this.Row == 11)
		{
			float y6 = Mathf.Lerp(this.PortraitGrid.localPosition.y, (float)1600, 0.166666672f);
			Vector3 localPosition6 = this.PortraitGrid.localPosition;
			float num6 = localPosition6.y = y6;
			Vector3 vector6 = this.PortraitGrid.localPosition = localPosition6;
		}
		else if (this.Row == 12 || this.Row == 13)
		{
			float y7 = Mathf.Lerp(this.PortraitGrid.localPosition.y, (float)1920, 0.166666672f);
			Vector3 localPosition7 = this.PortraitGrid.localPosition;
			float num7 = localPosition7.y = y7;
			Vector3 vector7 = this.PortraitGrid.localPosition = localPosition7;
		}
		else if (this.Row == 14 || this.Row == 15)
		{
			float y8 = Mathf.Lerp(this.PortraitGrid.localPosition.y, (float)2240, 0.166666672f);
			Vector3 localPosition8 = this.PortraitGrid.localPosition;
			float num8 = localPosition8.y = y8;
			Vector3 vector8 = this.PortraitGrid.localPosition = localPosition8;
		}
		else if (this.Row == 16 || this.Row == 17)
		{
			float y9 = Mathf.Lerp(this.PortraitGrid.localPosition.y, (float)2560, 0.166666672f);
			Vector3 localPosition9 = this.PortraitGrid.localPosition;
			float num9 = localPosition9.y = y9;
			Vector3 vector9 = this.PortraitGrid.localPosition = localPosition9;
		}
		else if (this.Row == 18 || this.Row == 19)
		{
			float y10 = Mathf.Lerp(this.PortraitGrid.localPosition.y, (float)2880, 0.166666672f);
			Vector3 localPosition10 = this.PortraitGrid.localPosition;
			float num10 = localPosition10.y = y10;
			Vector3 vector10 = this.PortraitGrid.localPosition = localPosition10;
		}
		float y11 = Mathf.Lerp(this.Scollbar.localPosition.y, (float)175 - (float)350 * (this.PortraitGrid.localPosition.y / (float)2880), 0.166666672f);
		Vector3 localPosition11 = this.Scollbar.localPosition;
		float num11 = localPosition11.y = y11;
		Vector3 vector11 = this.Scollbar.localPosition = localPosition11;
		if (this.InputManager.TappedUp)
		{
			this.Row--;
			if (this.Row < 0)
			{
				this.Row = this.Rows - 1;
			}
			this.UpdateHighlight();
		}
		if (this.InputManager.TappedDown)
		{
			this.Row++;
			if (this.Row > this.Rows - 1)
			{
				this.Row = 0;
			}
			this.UpdateHighlight();
		}
		if (this.InputManager.TappedRight)
		{
			this.Column++;
			if (this.Column > this.Columns - 1)
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
				this.Column = this.Columns - 1;
			}
			this.UpdateHighlight();
		}
	}

	public virtual void UpdateHighlight()
	{
		this.StudentID = 1 + (this.Column + this.Row * this.Columns);
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
		if (this.Distracting)
		{
			bool flag = false;
			if (this.StudentManager.Students[this.StudentID] != null && this.StudentManager.Students[this.StudentID].Dead)
			{
				flag = true;
			}
			if (this.StudentID == 0 || this.StudentID == this.PauseScreen.Yandere.TargetStudent.StudentID || flag)
			{
				this.PromptBar.Label[0].text = string.Empty;
				this.PromptBar.UpdateButtons();
			}
		}
		int num = -300 + this.Column * 150;
		Vector3 localPosition = this.Highlight.localPosition;
		float num2 = localPosition.x = (float)num;
		Vector3 vector = this.Highlight.localPosition = localPosition;
		int num3 = 80 - this.Row * 160;
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
		return new StudentInfoMenuScript.$UpdatePortraits$3127(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
