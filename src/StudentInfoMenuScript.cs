using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StudentInfoMenuScript : MonoBehaviour
{
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

	public Transform Scrollbar;

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

	public bool Targeting;

	public int[] SetSizes;

	public int StudentID;

	public int Column;

	public int Row;

	public int Set;

	public int Columns;

	public int Rows;

	private void Start()
	{
		for (int i = 1; i < 101; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.StudentPortrait, base.transform.position, Quaternion.identity);
			gameObject.transform.parent = this.PortraitGrid;
			gameObject.transform.localPosition = new Vector3(-300f + (float)this.Column * 150f, 80f - (float)this.Row * 160f, 0f);
			gameObject.transform.localEulerAngles = Vector3.zero;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			this.StudentPortraits[i] = gameObject.GetComponent<StudentPortraitScript>();
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

	private void Update()
	{
		if (Input.GetButtonDown("A") && this.PromptBar.Label[0].text != string.Empty && StudentGlobals.GetStudentPhotographed(this.StudentID))
		{
			this.StudentInfo.gameObject.SetActive(true);
			this.StudentInfo.UpdateInfo(this.StudentID);
			this.StudentInfo.Topics.SetActive(false);
			base.gameObject.SetActive(false);
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
			if (this.Targeting)
			{
				this.PromptBar.Label[0].text = "Kill";
			}
			this.PromptBar.Label[1].text = "Back";
			this.PromptBar.Label[3].text = "Interests";
			this.PromptBar.UpdateButtons();
		}
		if (Input.GetButtonDown("B"))
		{
			if (this.Gossiping || this.Distracting || this.MatchMaking || this.Targeting)
			{
				this.PauseScreen.Yandere.Interaction = YandereInteractionType.Bye;
				this.PauseScreen.Yandere.TalkTimer = 2f;
				this.PauseScreen.MainMenu.SetActive(true);
				this.PauseScreen.Sideways = false;
				this.PauseScreen.Show = false;
				base.gameObject.SetActive(false);
				Time.timeScale = 1f;
				this.Distracting = false;
				this.MatchMaking = false;
				this.Gossiping = false;
				this.Targeting = false;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
			}
			else if (this.CyberBullying)
			{
				this.PauseScreen.MainMenu.SetActive(true);
				this.PauseScreen.Sideways = false;
				this.PauseScreen.Show = false;
				base.gameObject.SetActive(false);
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
			}
			else
			{
				this.PauseScreen.MainMenu.SetActive(true);
				this.PauseScreen.Sideways = false;
				this.PauseScreen.PressedB = true;
				base.gameObject.SetActive(false);
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "Accept";
				this.PromptBar.Label[1].text = "Exit";
				this.PromptBar.Label[4].text = "Choose";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
			}
		}
		float t = Time.unscaledDeltaTime * 10f;
		float num = (float)((this.Row % 2 != 0) ? ((this.Row - 1) / 2) : (this.Row / 2));
		float b = 320f * num;
		this.PortraitGrid.localPosition = new Vector3(this.PortraitGrid.localPosition.x, Mathf.Lerp(this.PortraitGrid.localPosition.y, b, t), this.PortraitGrid.localPosition.z);
		this.Scrollbar.localPosition = new Vector3(this.Scrollbar.localPosition.x, Mathf.Lerp(this.Scrollbar.localPosition.y, 175f - 350f * (this.PortraitGrid.localPosition.y / 2880f), t), this.Scrollbar.localPosition.z);
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

	public void UpdateHighlight()
	{
		this.StudentID = 1 + (this.Column + this.Row * this.Columns);
		if (StudentGlobals.GetStudentPhotographed(this.StudentID))
		{
			this.PromptBar.Label[0].text = "View Info";
			this.PromptBar.UpdateButtons();
		}
		else
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		if (this.Gossiping && (this.StudentID == 1 || this.StudentID == this.PauseScreen.Yandere.TargetStudent.StudentID || this.JSON.Students[this.StudentID].Club == ClubType.Sports || StudentGlobals.GetStudentDead(this.StudentID)))
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		if (this.CyberBullying && (this.JSON.Students[this.StudentID].Gender == 1 || StudentGlobals.GetStudentDead(this.StudentID)))
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		if (this.Distracting && (this.StudentID == 0 || this.StudentID == this.PauseScreen.Yandere.TargetStudent.StudentID || StudentGlobals.GetStudentDead(this.StudentID)))
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		if (this.MatchMaking && (this.StudentID == this.PauseScreen.Yandere.TargetStudent.StudentID || StudentGlobals.GetStudentDead(this.StudentID)))
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		if (this.Targeting && (this.StudentID == 1 || StudentGlobals.GetStudentDead(this.StudentID)))
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		this.Highlight.localPosition = new Vector3(-300f + (float)this.Column * 150f, 80f - (float)this.Row * 160f, this.Highlight.localPosition.z);
		this.UpdateNameLabel();
	}

	private void UpdateNameLabel()
	{
		if (StudentGlobals.GetStudentPhotographed(this.StudentID))
		{
			this.NameLabel.text = this.JSON.Students[this.StudentID].Name;
		}
		else
		{
			this.NameLabel.text = "Unknown";
		}
	}

	public IEnumerator UpdatePortraits()
	{
		for (int ID = 1; ID < 101; ID++)
		{
			if (ID == 0)
			{
				this.StudentPortraits[ID].Portrait.mainTexture = this.InfoChan;
			}
			else if (!this.PortraitLoaded[ID])
			{
				if (StudentGlobals.GetStudentPhotographed(ID))
				{
					string path = string.Concat(new string[]
					{
						"file:///",
						Application.streamingAssetsPath,
						"/Portraits/Student_",
						ID.ToString(),
						".png"
					});
					WWW www = new WWW(path);
					yield return www;
					if (www.error == null)
					{
						if (!StudentGlobals.GetStudentReplaced(ID))
						{
							if (!this.CustomPortraits)
							{
								this.StudentPortraits[ID].Portrait.mainTexture = ((ID >= 33 && ID <= 93) ? this.BlankPortrait : www.texture);
							}
							else
							{
								this.StudentPortraits[ID].Portrait.mainTexture = www.texture;
							}
						}
						else
						{
							this.StudentPortraits[ID].Portrait.mainTexture = this.BlankPortrait;
						}
					}
					else
					{
						this.StudentPortraits[ID].Portrait.mainTexture = this.UnknownPortrait;
					}
					this.PortraitLoaded[ID] = true;
				}
				else
				{
					this.StudentPortraits[ID].Portrait.mainTexture = this.UnknownPortrait;
				}
			}
			if (PlayerGlobals.GetStudentPantyShot(this.JSON.Students[ID].Name))
			{
				this.StudentPortraits[ID].Panties.SetActive(true);
			}
			this.StudentPortraits[ID].Friend.SetActive(PlayerGlobals.GetStudentFriend(ID));
			if (StudentGlobals.GetStudentDying(ID) || StudentGlobals.GetStudentDead(ID))
			{
				this.StudentPortraits[ID].DeathShadow.SetActive(true);
			}
			if (SceneManager.GetActiveScene().name == "SchoolScene" && this.StudentManager.Students[ID] != null && this.StudentManager.Students[ID].Tranquil)
			{
				this.StudentPortraits[ID].DeathShadow.SetActive(true);
			}
			if (StudentGlobals.GetStudentArrested(ID))
			{
				this.StudentPortraits[ID].PrisonBars.SetActive(true);
				this.StudentPortraits[ID].DeathShadow.SetActive(true);
			}
		}
		yield break;
	}
}
