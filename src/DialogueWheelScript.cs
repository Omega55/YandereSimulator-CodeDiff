﻿using System;
using UnityEngine;

public class DialogueWheelScript : MonoBehaviour
{
	public AppearanceWindowScript AppearanceWindow;

	public PracticeWindowScript PracticeWindow;

	public ClubManagerScript ClubManager;

	public LoveManagerScript LoveManager;

	public PauseScreenScript PauseScreen;

	public TaskManagerScript TaskManager;

	public ClubWindowScript ClubWindow;

	public NoteLockerScript NoteLocker;

	public ReputationScript Reputation;

	public TaskWindowScript TaskWindow;

	public PromptBarScript PromptBar;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public ClockScript Clock;

	public UIPanel Panel;

	public GameObject SwitchTopicsWindow;

	public GameObject TaskDialogueWindow;

	public GameObject ClubLeaderWindow;

	public GameObject DatingMinigame;

	public GameObject LockerWindow;

	public Transform Interaction;

	public Transform Favors;

	public Transform Club;

	public Transform Love;

	public UISprite TaskIcon;

	public UISprite Impatience;

	public UILabel CenterLabel;

	public UISprite[] Segment;

	public UISprite[] Shadow;

	public string[] Text;

	public UISprite[] FavorSegment;

	public UISprite[] FavorShadow;

	public UISprite[] ClubSegment;

	public UISprite[] ClubShadow;

	public UISprite[] LoveSegment;

	public UISprite[] LoveShadow;

	public string[] FavorText;

	public string[] ClubText;

	public string[] LoveText;

	public int Selected;

	public int Victim;

	public bool AskingFavor;

	public bool Matchmaking;

	public bool ClubLeader;

	public bool Pestered;

	public bool Show;

	public Vector3 PreviousPosition;

	public Vector2 MouseDelta;

	public Color OriginalColor;

	private void Start()
	{
		this.Interaction.localScale = new Vector3(1f, 1f, 1f);
		this.Favors.localScale = Vector3.zero;
		this.Club.localScale = Vector3.zero;
		this.Love.localScale = Vector3.zero;
		base.transform.localScale = Vector3.zero;
		this.OriginalColor = this.CenterLabel.color;
	}

	private void Update()
	{
		if (!this.Show)
		{
			if (base.transform.localScale.x > 0.1f)
			{
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			else if (this.Panel.enabled)
			{
				base.transform.localScale = Vector3.zero;
				this.Panel.enabled = false;
			}
		}
		else
		{
			if (this.Yandere.PauseScreen.Show)
			{
				this.Yandere.PauseScreen.ExitPhone();
			}
			if (this.ClubLeader)
			{
				this.Interaction.localScale = Vector3.Lerp(this.Interaction.localScale, Vector3.zero, Time.deltaTime * 10f);
				this.Favors.localScale = Vector3.Lerp(this.Favors.localScale, Vector3.zero, Time.deltaTime * 10f);
				this.Club.localScale = Vector3.Lerp(this.Club.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				this.Love.localScale = Vector3.Lerp(this.Love.localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			else if (this.AskingFavor)
			{
				this.Interaction.localScale = Vector3.Lerp(this.Interaction.localScale, Vector3.zero, Time.deltaTime * 10f);
				this.Favors.localScale = Vector3.Lerp(this.Favors.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				this.Club.localScale = Vector3.Lerp(this.Club.localScale, Vector3.zero, Time.deltaTime * 10f);
				this.Love.localScale = Vector3.Lerp(this.Love.localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			else if (this.Matchmaking)
			{
				this.Interaction.localScale = Vector3.Lerp(this.Interaction.localScale, Vector3.zero, Time.deltaTime * 10f);
				this.Favors.localScale = Vector3.Lerp(this.Favors.localScale, Vector3.zero, Time.deltaTime * 10f);
				this.Club.localScale = Vector3.Lerp(this.Club.localScale, Vector3.zero, Time.deltaTime * 10f);
				this.Love.localScale = Vector3.Lerp(this.Love.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			}
			else
			{
				this.Interaction.localScale = Vector3.Lerp(this.Interaction.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				this.Favors.localScale = Vector3.Lerp(this.Favors.localScale, Vector3.zero, Time.deltaTime * 10f);
				this.Club.localScale = Vector3.Lerp(this.Club.localScale, Vector3.zero, Time.deltaTime * 10f);
				this.Love.localScale = Vector3.Lerp(this.Love.localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			this.MouseDelta.x = this.MouseDelta.x + Input.GetAxis("Mouse X");
			this.MouseDelta.y = this.MouseDelta.y + Input.GetAxis("Mouse Y");
			if (this.MouseDelta.x > 11f)
			{
				this.MouseDelta.x = 11f;
			}
			else if (this.MouseDelta.x < -11f)
			{
				this.MouseDelta.x = -11f;
			}
			if (this.MouseDelta.y > 11f)
			{
				this.MouseDelta.y = 11f;
			}
			else if (this.MouseDelta.y < -11f)
			{
				this.MouseDelta.y = -11f;
			}
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (!this.AskingFavor && !this.Matchmaking)
			{
				if (Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f)
				{
					this.Selected = 0;
				}
				if ((Input.GetAxis("Vertical") > 0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (this.MouseDelta.y > 10f && this.MouseDelta.x < 10f && this.MouseDelta.x > -10f))
				{
					this.Selected = 1;
				}
				if ((Input.GetAxis("Vertical") > 0f && Input.GetAxis("Horizontal") > 0.5f) || (this.MouseDelta.y > 0f && this.MouseDelta.x > 10f))
				{
					this.Selected = 2;
				}
				if ((Input.GetAxis("Vertical") < 0f && Input.GetAxis("Horizontal") > 0.5f) || (this.MouseDelta.y < 0f && this.MouseDelta.x > 10f))
				{
					this.Selected = 3;
				}
				if ((Input.GetAxis("Vertical") < -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (this.MouseDelta.y < -10f && this.MouseDelta.x < 10f && this.MouseDelta.x > -10f))
				{
					this.Selected = 4;
				}
				if ((Input.GetAxis("Vertical") < 0f && Input.GetAxis("Horizontal") < -0.5f) || (this.MouseDelta.y < 0f && this.MouseDelta.x < -10f))
				{
					this.Selected = 5;
				}
				if ((Input.GetAxis("Vertical") > 0f && Input.GetAxis("Horizontal") < -0.5f) || (this.MouseDelta.y > 0f && this.MouseDelta.x < -10f))
				{
					this.Selected = 6;
				}
				this.CenterLabel.text = this.Text[this.Selected];
				this.CenterLabel.color = this.OriginalColor;
				if (!this.ClubLeader)
				{
					if (this.Selected == 5)
					{
						if (PlayerGlobals.GetStudentFriend(this.Yandere.TargetStudent.StudentID))
						{
							this.CenterLabel.text = "Love";
						}
					}
					else if (this.Selected == 6 && this.Yandere.Club == ClubType.Delinquent)
					{
						this.CenterLabel.text = "Intimidate";
						this.CenterLabel.color = new Color(1f, 0f, 0f, 1f);
					}
				}
				else
				{
					this.CenterLabel.text = this.ClubText[this.Selected];
				}
			}
			else
			{
				if (Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f)
				{
					this.Selected = 0;
				}
				if ((Input.GetAxis("Vertical") > 0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (this.MouseDelta.y > 10f && this.MouseDelta.x < 10f && this.MouseDelta.x > -10f))
				{
					this.Selected = 1;
				}
				if ((Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") > 0.5f) || (this.MouseDelta.y < 10f && this.MouseDelta.y > -10f && this.MouseDelta.x > 10f))
				{
					this.Selected = 2;
				}
				if ((Input.GetAxis("Vertical") < -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (this.MouseDelta.y < -10f && this.MouseDelta.x < 10f && this.MouseDelta.x > -10f))
				{
					this.Selected = 3;
				}
				if ((Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") < -0.5f) || (this.MouseDelta.y < 10f && this.MouseDelta.y > -10f && this.MouseDelta.x < -10f))
				{
					this.Selected = 4;
				}
				if (this.Selected < this.FavorText.Length)
				{
					this.CenterLabel.text = (this.AskingFavor ? this.FavorText[this.Selected] : this.LoveText[this.Selected]);
				}
			}
			if (!this.ClubLeader)
			{
				for (int i = 1; i < 7; i++)
				{
					Transform transform = this.Segment[i].transform;
					transform.localScale = Vector3.Lerp(transform.localScale, (this.Selected == i) ? new Vector3(1.3f, 1.3f, 1f) : new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				}
			}
			else
			{
				for (int j = 1; j < 7; j++)
				{
					Transform transform2 = this.ClubSegment[j].transform;
					transform2.localScale = Vector3.Lerp(transform2.localScale, (this.Selected == j) ? new Vector3(1.3f, 1.3f, 1f) : new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				}
			}
			if (!this.Matchmaking)
			{
				for (int k = 1; k < 5; k++)
				{
					Transform transform3 = this.FavorSegment[k].transform;
					transform3.localScale = Vector3.Lerp(transform3.localScale, (this.Selected == k) ? new Vector3(1.3f, 1.3f, 1f) : new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				}
			}
			else
			{
				for (int l = 1; l < 5; l++)
				{
					Transform transform4 = this.LoveSegment[l].transform;
					transform4.localScale = Vector3.Lerp(transform4.localScale, (this.Selected == l) ? new Vector3(1.3f, 1.3f, 1f) : new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				}
			}
			if (Input.GetButtonDown("A"))
			{
				if (this.ClubLeader)
				{
					if (this.Selected != 0 && this.ClubShadow[this.Selected].color.a == 0f)
					{
						int num = 0;
						if (this.Yandere.TargetStudent.Sleuthing)
						{
							num = 5;
						}
						if (this.Selected == 1)
						{
							this.Impatience.fillAmount = 0f;
							this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubInfo;
							this.Yandere.TargetStudent.TalkTimer = 100f;
							this.Yandere.TargetStudent.ClubPhase = 1;
							this.Show = false;
						}
						else if (this.Selected == 2)
						{
							this.Impatience.fillAmount = 0f;
							this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubJoin;
							this.Yandere.TargetStudent.TalkTimer = 100f;
							this.Show = false;
							this.ClubManager.CheckGrudge(this.Yandere.TargetStudent.Club);
							if (ClubGlobals.GetQuitClub(this.Yandere.TargetStudent.Club))
							{
								this.Yandere.TargetStudent.ClubPhase = 4;
							}
							else if (this.Yandere.Club != ClubType.None)
							{
								this.Yandere.TargetStudent.ClubPhase = 5;
							}
							else if (this.ClubManager.ClubGrudge)
							{
								this.Yandere.TargetStudent.ClubPhase = 6;
							}
							else
							{
								this.Yandere.TargetStudent.ClubPhase = 1;
							}
						}
						else if (this.Selected == 3)
						{
							this.Impatience.fillAmount = 0f;
							this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubQuit;
							this.Yandere.TargetStudent.TalkTimer = 100f;
							this.Yandere.TargetStudent.ClubPhase = 1;
							this.Show = false;
						}
						else if (this.Selected == 4)
						{
							this.Impatience.fillAmount = 0f;
							this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubBye;
							this.Yandere.TargetStudent.TalkTimer = this.Yandere.Subtitle.ClubFarewellClips[(int)(this.Yandere.TargetStudent.Club + num)].length;
							this.Show = false;
							Debug.Log("This club leader exchange is over.");
						}
						else if (this.Selected == 5)
						{
							this.Impatience.fillAmount = 0f;
							this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubActivity;
							this.Yandere.TargetStudent.TalkTimer = 100f;
							if (this.Clock.HourTime < 17f)
							{
								this.Yandere.TargetStudent.ClubPhase = 4;
							}
							else if (this.Clock.HourTime > 17.5f)
							{
								this.Yandere.TargetStudent.ClubPhase = 5;
							}
							else
							{
								this.Yandere.TargetStudent.ClubPhase = 1;
							}
							this.Show = false;
						}
						else if (this.Selected == 6)
						{
							this.Impatience.fillAmount = 0f;
							this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubPractice;
							this.Yandere.TargetStudent.TalkTimer = 100f;
							this.Yandere.TargetStudent.ClubPhase = 1;
							this.Show = false;
						}
					}
				}
				else if (this.AskingFavor)
				{
					if (this.Selected != 0)
					{
						if (this.Selected < this.FavorShadow.Length && this.FavorShadow[this.Selected] != null && this.FavorShadow[this.Selected].color.a == 0f)
						{
							if (this.Selected == 1)
							{
								this.Impatience.fillAmount = 0f;
								this.Yandere.Interaction = YandereInteractionType.FollowMe;
								this.Yandere.TalkTimer = 3f;
								this.Show = false;
							}
							else if (this.Selected == 2)
							{
								this.Impatience.fillAmount = 0f;
								this.Yandere.Interaction = YandereInteractionType.GoAway;
								this.Yandere.TalkTimer = 3f;
								this.Show = false;
							}
							else if (this.Selected == 4)
							{
								this.PauseScreen.StudentInfoMenu.Distracting = true;
								this.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
								this.PauseScreen.StudentInfoMenu.Column = 0;
								this.PauseScreen.StudentInfoMenu.Row = 0;
								this.PauseScreen.StudentInfoMenu.UpdateHighlight();
								base.StartCoroutine(this.PauseScreen.StudentInfoMenu.UpdatePortraits());
								this.PauseScreen.MainMenu.SetActive(false);
								this.PauseScreen.Panel.enabled = true;
								this.PauseScreen.Sideways = true;
								this.PauseScreen.Show = true;
								Time.timeScale = 0.0001f;
								this.PromptBar.ClearButtons();
								this.PromptBar.Label[1].text = "Cancel";
								this.PromptBar.UpdateButtons();
								this.PromptBar.Show = true;
								this.Impatience.fillAmount = 0f;
								this.Yandere.Interaction = YandereInteractionType.DistractThem;
								this.Yandere.TalkTimer = 3f;
								this.Show = false;
							}
						}
						if (this.Selected == 3)
						{
							this.AskingFavor = false;
						}
					}
				}
				else if (this.Matchmaking)
				{
					if (this.Selected != 0)
					{
						if (this.Selected < this.LoveShadow.Length && this.LoveShadow[this.Selected] != null && this.LoveShadow[this.Selected].color.a == 0f)
						{
							if (this.Selected == 1)
							{
								this.PromptBar.ClearButtons();
								this.PromptBar.Label[0].text = "Select";
								this.PromptBar.Label[4].text = "Change";
								this.PromptBar.UpdateButtons();
								this.PromptBar.Show = true;
								this.AppearanceWindow.gameObject.SetActive(true);
								this.AppearanceWindow.Show = true;
								this.Show = false;
							}
							else if (this.Selected == 2)
							{
								this.Impatience.fillAmount = 0f;
								this.Yandere.Interaction = YandereInteractionType.Court;
								this.Yandere.TalkTimer = 5f;
								this.Show = false;
							}
							else if (this.Selected == 4)
							{
								this.Impatience.fillAmount = 0f;
								this.Yandere.Interaction = YandereInteractionType.Confess;
								this.Yandere.TalkTimer = 5f;
								this.Show = false;
							}
						}
						if (this.Selected == 3)
						{
							this.Matchmaking = false;
						}
					}
				}
				else if (this.Selected != 0 && this.Shadow[this.Selected].color.a == 0f)
				{
					if (this.Selected == 1)
					{
						this.Impatience.fillAmount = 0f;
						this.Yandere.Interaction = YandereInteractionType.Apologizing;
						this.Yandere.TalkTimer = 3f;
						this.Show = false;
					}
					else if (this.Selected == 2)
					{
						this.Impatience.fillAmount = 0f;
						this.Yandere.Interaction = YandereInteractionType.Compliment;
						this.Yandere.TalkTimer = 3f;
						this.Show = false;
					}
					else if (this.Selected == 3)
					{
						this.PauseScreen.StudentInfoMenu.Gossiping = true;
						this.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
						this.PauseScreen.StudentInfoMenu.Column = 0;
						this.PauseScreen.StudentInfoMenu.Row = 0;
						this.PauseScreen.StudentInfoMenu.UpdateHighlight();
						base.StartCoroutine(this.PauseScreen.StudentInfoMenu.UpdatePortraits());
						this.PauseScreen.MainMenu.SetActive(false);
						this.PauseScreen.Panel.enabled = true;
						this.PauseScreen.Sideways = true;
						this.PauseScreen.Show = true;
						Time.timeScale = 0.0001f;
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[0].text = string.Empty;
						this.PromptBar.Label[1].text = "Cancel";
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = true;
						this.Impatience.fillAmount = 0f;
						this.Yandere.Interaction = YandereInteractionType.Gossip;
						this.Yandere.TalkTimer = 3f;
						this.Show = false;
					}
					else if (this.Selected == 4)
					{
						this.Impatience.fillAmount = 0f;
						this.Yandere.Interaction = YandereInteractionType.Bye;
						this.Yandere.TalkTimer = 2f;
						this.Show = false;
						Debug.Log("This exchange is over.");
					}
					else if (this.Selected == 5)
					{
						if (!PlayerGlobals.GetStudentFriend(this.Yandere.TargetStudent.StudentID))
						{
							this.CheckTaskCompletion();
							if (this.Yandere.TargetStudent.TaskPhase == 0)
							{
								this.Impatience.fillAmount = 0f;
								this.Yandere.TargetStudent.Interaction = StudentInteractionType.GivingTask;
								this.Yandere.TargetStudent.TalkTimer = 100f;
								this.Yandere.TargetStudent.TaskPhase = 1;
							}
							else
							{
								this.Impatience.fillAmount = 0f;
								this.Yandere.TargetStudent.Interaction = StudentInteractionType.GivingTask;
								this.Yandere.TargetStudent.TalkTimer = 100f;
							}
							this.Show = false;
						}
						else if (this.Yandere.LoveManager.SuitorProgress == 0)
						{
							this.PauseScreen.StudentInfoMenu.MatchMaking = true;
							this.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
							this.PauseScreen.StudentInfoMenu.Column = 0;
							this.PauseScreen.StudentInfoMenu.Row = 0;
							this.PauseScreen.StudentInfoMenu.UpdateHighlight();
							base.StartCoroutine(this.PauseScreen.StudentInfoMenu.UpdatePortraits());
							this.PauseScreen.MainMenu.SetActive(false);
							this.PauseScreen.Panel.enabled = true;
							this.PauseScreen.Sideways = true;
							this.PauseScreen.Show = true;
							Time.timeScale = 0.0001f;
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "View Info";
							this.PromptBar.Label[1].text = "Cancel";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
							this.Impatience.fillAmount = 0f;
							this.Yandere.Interaction = YandereInteractionType.NamingCrush;
							this.Yandere.TalkTimer = 3f;
							this.Show = false;
						}
					}
					else if (this.Selected == 6)
					{
						this.AskingFavor = true;
					}
				}
			}
			else if (Input.GetButtonDown("X"))
			{
				if (this.TaskDialogueWindow.activeInHierarchy)
				{
					this.Impatience.fillAmount = 0f;
					this.Yandere.Interaction = YandereInteractionType.TaskInquiry;
					this.Yandere.TalkTimer = 3f;
					this.Show = false;
				}
				else if (this.SwitchTopicsWindow.activeInHierarchy)
				{
					this.ClubLeader = !this.ClubLeader;
					this.HideShadows();
				}
			}
			else if (Input.GetButtonDown("B") && this.LockerWindow.activeInHierarchy)
			{
				this.Impatience.fillAmount = 0f;
				this.Yandere.Interaction = YandereInteractionType.SendingToLocker;
				this.Yandere.TalkTimer = 5f;
				this.Show = false;
			}
		}
		this.PreviousPosition = Input.mousePosition;
	}

	public void HideShadows()
	{
		this.Jukebox.Dip = 0.5f;
		this.TaskDialogueWindow.SetActive(false);
		this.ClubLeaderWindow.SetActive(false);
		this.LockerWindow.SetActive(false);
		if (this.ClubLeader && !this.Yandere.TargetStudent.Talk.Fake)
		{
			this.SwitchTopicsWindow.SetActive(true);
		}
		else
		{
			this.SwitchTopicsWindow.SetActive(false);
		}
		if (this.Yandere.TargetStudent.Armband.activeInHierarchy && !this.ClubLeader && this.Yandere.TargetStudent.Club != ClubType.Council)
		{
			this.ClubLeaderWindow.SetActive(true);
		}
		if (this.NoteLocker.NoteLeft && this.NoteLocker.Student == this.Yandere.TargetStudent)
		{
			this.LockerWindow.SetActive(true);
		}
		if (this.Yandere.TargetStudent.Club == ClubType.Bully && TaskGlobals.GetTaskStatus(36) == 1)
		{
			this.TaskDialogueWindow.SetActive(true);
		}
		if (this.Yandere.TargetStudent.StudentID == 10 && TaskGlobals.GetTaskStatus(46) == 1)
		{
			this.TaskDialogueWindow.SetActive(true);
		}
		this.TaskIcon.spriteName = (PlayerGlobals.GetStudentFriend(this.Yandere.TargetStudent.StudentID) ? "Heart" : "Task");
		this.Impatience.fillAmount = 0f;
		for (int i = 1; i < 7; i++)
		{
			UISprite uisprite = this.Shadow[i];
			uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 0f);
		}
		for (int j = 1; j < 5; j++)
		{
			UISprite uisprite2 = this.FavorShadow[j];
			uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 0f);
		}
		for (int k = 1; k < 7; k++)
		{
			UISprite uisprite3 = this.ClubShadow[k];
			uisprite3.color = new Color(uisprite3.color.r, uisprite3.color.g, uisprite3.color.b, 0f);
		}
		for (int l = 1; l < 5; l++)
		{
			UISprite uisprite4 = this.LoveShadow[l];
			uisprite4.color = new Color(uisprite4.color.r, uisprite4.color.g, uisprite4.color.b, 0f);
		}
		if (!this.Yandere.TargetStudent.Witness || this.Yandere.TargetStudent.Forgave || this.Yandere.TargetStudent.Club == ClubType.Council)
		{
			UISprite uisprite5 = this.Shadow[1];
			uisprite5.color = new Color(uisprite5.color.r, uisprite5.color.g, uisprite5.color.b, 0.75f);
		}
		if (this.Yandere.TargetStudent.Complimented || this.Yandere.TargetStudent.Club == ClubType.Council)
		{
			UISprite uisprite6 = this.Shadow[2];
			uisprite6.color = new Color(uisprite6.color.r, uisprite6.color.g, uisprite6.color.b, 0.75f);
		}
		if (this.Yandere.TargetStudent.Gossiped || this.Yandere.TargetStudent.Club == ClubType.Council)
		{
			UISprite uisprite7 = this.Shadow[3];
			uisprite7.color = new Color(uisprite7.color.r, uisprite7.color.g, uisprite7.color.b, 0.75f);
		}
		if (this.Yandere.Bloodiness > 0f || this.Yandere.Sanity < 33.33333f || this.Yandere.TargetStudent.Club == ClubType.Council)
		{
			UISprite uisprite8 = this.Shadow[3];
			uisprite8.color = new Color(uisprite8.color.r, uisprite8.color.g, uisprite8.color.b, 0.75f);
			this.Shadow[5].color = new Color(0f, 0f, 0f, 0.75f);
			UISprite uisprite9 = this.Shadow[6];
			uisprite9.color = new Color(uisprite9.color.r, uisprite9.color.g, uisprite9.color.b, 0.75f);
		}
		else if (this.Reputation.Reputation < -33.33333f)
		{
			UISprite uisprite10 = this.Shadow[3];
			uisprite10.color = new Color(uisprite10.color.r, uisprite10.color.g, uisprite10.color.b, 0.75f);
		}
		if (!this.Yandere.TargetStudent.Indoors || this.Yandere.TargetStudent.Club == ClubType.Council)
		{
			this.Shadow[5].color = new Color(0f, 0f, 0f, 0.75f);
		}
		else if (!PlayerGlobals.GetStudentFriend(this.Yandere.TargetStudent.StudentID))
		{
			Debug.Log("Yandere.TargetStudent.TaskPhase is: " + this.Yandere.TargetStudent.TaskPhase + ".");
			Debug.Log("TaskGlobals.GetTaskStatus of current student is: " + TaskGlobals.GetTaskStatus(this.Yandere.TargetStudent.StudentID));
			bool flag = false;
			if (this.Yandere.TargetStudent.StudentID != 8 && this.Yandere.TargetStudent.StudentID != 11 && this.Yandere.TargetStudent.StudentID != 25 && this.Yandere.TargetStudent.StudentID != 28 && this.Yandere.TargetStudent.StudentID != 30 && this.Yandere.TargetStudent.StudentID != 36 && this.Yandere.TargetStudent.StudentID != 37 && this.Yandere.TargetStudent.StudentID != 38 && this.Yandere.TargetStudent.StudentID != 52 && this.Yandere.TargetStudent.StudentID != 76 && this.Yandere.TargetStudent.StudentID != 77 && this.Yandere.TargetStudent.StudentID != 78 && this.Yandere.TargetStudent.StudentID != 79 && this.Yandere.TargetStudent.StudentID != 80 && this.Yandere.TargetStudent.StudentID != 81)
			{
				flag = true;
			}
			if (this.Yandere.TargetStudent.StudentID == 1 || this.Yandere.TargetStudent.StudentID == 41)
			{
				this.Shadow[5].color = new Color(0f, 0f, 0f, 0.75f);
			}
			else
			{
				this.TaskManager.UpdateTaskStatus();
				if ((this.Yandere.TargetStudent.TaskPhase > 0 && this.Yandere.TargetStudent.TaskPhase < 5) || (TaskGlobals.GetTaskStatus(this.Yandere.TargetStudent.StudentID) > 0 && TaskGlobals.GetTaskStatus(this.Yandere.TargetStudent.StudentID) < 5 && TaskGlobals.GetTaskStatus(this.Yandere.TargetStudent.StudentID) != 2) || this.Yandere.TargetStudent.TaskPhase == 100)
				{
					Debug.Log("Hiding task button.");
					this.Shadow[5].color = new Color(0f, 0f, 0f, 0.75f);
				}
				if (this.Yandere.TargetStudent.TaskPhase == 5)
				{
					Debug.Log("Unhiding task button.");
					this.Shadow[5].color = new Color(0f, 0f, 0f, 0f);
				}
				if (this.Yandere.TargetStudent.StudentID == 6)
				{
					Debug.Log("The status of Task #6 is:" + TaskGlobals.GetTaskStatus(6));
					if (TaskGlobals.GetTaskStatus(6) == 1 && this.Yandere.Inventory.Headset)
					{
						this.Shadow[5].color = new Color(0f, 0f, 0f, 0f);
						Debug.Log("Player has a headset.");
					}
				}
				else if (this.Yandere.TargetStudent.StudentID == 36)
				{
					if (TaskGlobals.GetTaskStatus(36) == 0 && (StudentGlobals.GetStudentDead(81) || StudentGlobals.GetStudentDead(82) || StudentGlobals.GetStudentDead(83) || StudentGlobals.GetStudentDead(84) || StudentGlobals.GetStudentDead(85)))
					{
						this.Shadow[5].color = new Color(0f, 0f, 0f, 0.75f);
					}
				}
				else if (this.Yandere.TargetStudent.StudentID == 81)
				{
					if (TaskGlobals.GetTaskStatus(81) == 0 && StudentGlobals.GetStudentDead(5))
					{
						this.Shadow[5].color = new Color(0f, 0f, 0f, 0.75f);
					}
				}
				else if (this.Yandere.TargetStudent.StudentID == 76)
				{
					Debug.Log("The status of Task #76 is:" + TaskGlobals.GetTaskStatus(76));
					if (TaskGlobals.GetTaskStatus(76) == 1 && this.Yandere.Inventory.Money >= 100f)
					{
						this.Shadow[5].color = new Color(0f, 0f, 0f, 0f);
						Debug.Log("Player has over $100.");
					}
				}
				else if (this.Yandere.TargetStudent.StudentID == 77)
				{
					if (TaskGlobals.GetTaskStatus(77) == 1 && ((this.Yandere.Weapon[1] != null && this.Yandere.Weapon[1].WeaponID == 1) || (this.Yandere.Weapon[1] != null && this.Yandere.Weapon[1].WeaponID == 8) || (this.Yandere.Weapon[2] != null && this.Yandere.Weapon[2].WeaponID == 1) || (this.Yandere.Weapon[2] != null && this.Yandere.Weapon[2].WeaponID == 8)))
					{
						this.Shadow[5].color = new Color(0f, 0f, 0f, 0f);
						Debug.Log("Player has a knife.");
					}
				}
				else if (this.Yandere.TargetStudent.StudentID == 78)
				{
					if (TaskGlobals.GetTaskStatus(78) == 1 && this.Yandere.Inventory.Sake)
					{
						this.Shadow[5].color = new Color(0f, 0f, 0f, 0f);
						Debug.Log("Player has sake.");
					}
				}
				else if (this.Yandere.TargetStudent.StudentID == 79)
				{
					if (TaskGlobals.GetTaskStatus(79) == 1 && this.Yandere.Inventory.Cigs)
					{
						this.Shadow[5].color = new Color(0f, 0f, 0f, 0f);
						Debug.Log("Player has ciggies.");
					}
				}
				else if (this.Yandere.TargetStudent.StudentID == 80 && TaskGlobals.GetTaskStatus(80) == 1 && this.Yandere.Inventory.AnswerSheet)
				{
					this.Shadow[5].color = new Color(0f, 0f, 0f, 0f);
					Debug.Log("Player has the answer sheet.");
				}
				if (flag && TaskGlobals.GetTaskStatus(this.Yandere.TargetStudent.StudentID) == 1 && this.Yandere.Inventory.Book)
				{
					this.Shadow[5].color = new Color(0f, 0f, 0f, 0f);
					Debug.Log("The player has a library book.");
				}
			}
		}
		else if (this.Yandere.TargetStudent.StudentID != this.LoveManager.RivalID && this.Yandere.TargetStudent.StudentID != this.LoveManager.SuitorID)
		{
			this.Shadow[5].color = new Color(0f, 0f, 0f, 0.75f);
		}
		else if (!this.Yandere.TargetStudent.Male && this.LoveManager.SuitorProgress == 0)
		{
			this.Shadow[5].color = new Color(0f, 0f, 0f, 0.75f);
		}
		if (!this.Yandere.TargetStudent.Indoors || this.Yandere.TargetStudent.Club == ClubType.Council)
		{
			UISprite uisprite11 = this.Shadow[6];
			uisprite11.color = new Color(uisprite11.color.r, uisprite11.color.g, uisprite11.color.b, 0.75f);
		}
		else
		{
			if (!PlayerGlobals.GetStudentFriend(this.Yandere.TargetStudent.StudentID))
			{
				this.Shadow[6].color = new Color(0f, 0f, 0f, 0.75f);
			}
			if ((this.Yandere.TargetStudent.Male && this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus > 3) || this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus > 4 || this.Yandere.Club == ClubType.Delinquent)
			{
				this.Shadow[6].color = new Color(0f, 0f, 0f, 0f);
			}
			if (this.Yandere.TargetStudent.Club == ClubType.Delinquent)
			{
				this.Shadow[6].color = new Color(0f, 0f, 0f, 0.75f);
			}
			if (this.Yandere.TargetStudent.CurrentAction == StudentActionType.Sunbathe)
			{
				this.Shadow[6].color = new Color(0f, 0f, 0f, 0.75f);
			}
		}
		if (this.Yandere.Club == this.Yandere.TargetStudent.Club)
		{
			UISprite uisprite12 = this.ClubShadow[1];
			uisprite12.color = new Color(uisprite12.color.r, uisprite12.color.g, uisprite12.color.b, 0.75f);
			UISprite uisprite13 = this.ClubShadow[2];
			uisprite13.color = new Color(uisprite13.color.r, uisprite13.color.g, uisprite13.color.b, 0.75f);
		}
		if (this.Yandere.ClubAttire || this.Yandere.Mask != null || this.Yandere.Gloves != null || this.Yandere.Container != null)
		{
			UISprite uisprite14 = this.ClubShadow[3];
			uisprite14.color = new Color(uisprite14.color.r, uisprite14.color.g, uisprite14.color.b, 0.75f);
		}
		if (this.Yandere.Club != this.Yandere.TargetStudent.Club)
		{
			UISprite uisprite15 = this.ClubShadow[2];
			uisprite15.color = new Color(uisprite15.color.r, uisprite15.color.g, uisprite15.color.b, 0f);
			UISprite uisprite16 = this.ClubShadow[3];
			uisprite16.color = new Color(uisprite16.color.r, uisprite16.color.g, uisprite16.color.b, 0.75f);
			this.ClubShadow[5].color = new Color(0f, 0f, 0f, 0.75f);
		}
		if (this.Yandere.StudentManager.MurderTakingPlace)
		{
			this.ClubShadow[5].color = new Color(0f, 0f, 0f, 0.75f);
		}
		if ((this.Yandere.TargetStudent.StudentID != 46 && this.Yandere.TargetStudent.StudentID != 51) || this.Yandere.Police.Show || this.Clock.Period == 3 || this.Clock.Period == 5)
		{
			UISprite uisprite17 = this.ClubShadow[6];
			uisprite17.color = new Color(uisprite17.color.r, uisprite17.color.g, uisprite17.color.b, 0.75f);
		}
		if (this.Yandere.TargetStudent.StudentID == 51)
		{
			int num = 4;
			if (this.Yandere.Club != ClubType.LightMusic || this.PracticeWindow.PlayedRhythmMinigame)
			{
				num = 0;
			}
			for (int m = 52; m < 56; m++)
			{
				if (this.Yandere.StudentManager.Students[m] == null)
				{
					num--;
				}
				else if (!this.Yandere.StudentManager.Students[m].gameObject.activeInHierarchy || this.Yandere.StudentManager.Students[m].Investigating || this.Yandere.StudentManager.Students[m].Distracting || this.Yandere.StudentManager.Students[m].Distracted || this.Yandere.StudentManager.Students[m].SentHome || this.Yandere.StudentManager.Students[m].Tranquil || this.Yandere.StudentManager.Students[m].GoAway || !this.Yandere.StudentManager.Students[m].Routine || !this.Yandere.StudentManager.Students[m].Alive)
				{
					num--;
				}
			}
			if (num < 4)
			{
				UISprite uisprite18 = this.ClubShadow[6];
				uisprite18.color = new Color(uisprite18.color.r, uisprite18.color.g, uisprite18.color.b, 0.75f);
			}
		}
		if (this.Yandere.Followers > 0)
		{
			Debug.Log("Can't do task because of follower.");
			UISprite uisprite19 = this.FavorShadow[1];
			uisprite19.color = new Color(uisprite19.color.r, uisprite19.color.g, uisprite19.color.b, 0.75f);
		}
		if (this.Yandere.TargetStudent.DistanceToDestination > 0.5f)
		{
			UISprite uisprite20 = this.FavorShadow[2];
			uisprite20.color = new Color(uisprite20.color.r, uisprite20.color.g, uisprite20.color.b, 0.75f);
		}
		if (!this.Yandere.TargetStudent.Male)
		{
			UISprite uisprite21 = this.LoveShadow[1];
			uisprite21.color = new Color(uisprite21.color.r, uisprite21.color.g, uisprite21.color.b, 0.75f);
		}
		if (this.DatingMinigame == null || (this.Yandere.TargetStudent.Male && !this.LoveManager.RivalWaiting) || this.LoveManager.Courted)
		{
			UISprite uisprite22 = this.LoveShadow[2];
			uisprite22.color = new Color(uisprite22.color.r, uisprite22.color.g, uisprite22.color.b, 0.75f);
		}
		if (!this.Yandere.TargetStudent.Male || !this.Yandere.Inventory.Rose || this.Yandere.TargetStudent.Rose)
		{
			UISprite uisprite23 = this.LoveShadow[4];
			uisprite23.color = new Color(uisprite23.color.r, uisprite23.color.g, uisprite23.color.b, 0.75f);
		}
	}

	private void CheckTaskCompletion()
	{
		Debug.Log("This student's Task Status is: " + TaskGlobals.GetTaskStatus(this.Yandere.TargetStudent.StudentID));
		Debug.Log("Checking for task completion.");
		if (this.Yandere.TargetStudent.StudentID == 6 && TaskGlobals.GetTaskStatus(6) == 1 && this.Yandere.Inventory.Headset)
		{
			this.Yandere.TargetStudent.TaskPhase = 5;
			this.Yandere.LoveManager.SuitorProgress = 1;
			DatingGlobals.SuitorProgress = 1;
		}
		if (this.Yandere.TargetStudent.StudentID == 76 && TaskGlobals.GetTaskStatus(76) == 1)
		{
			this.Yandere.TargetStudent.RespectEarned = true;
			this.Yandere.TargetStudent.TaskPhase = 5;
			this.Yandere.Inventory.Money -= 100f;
			this.Yandere.Inventory.UpdateMoney();
		}
		else if (this.Yandere.TargetStudent.StudentID == 77 && TaskGlobals.GetTaskStatus(77) == 1)
		{
			this.Yandere.TargetStudent.RespectEarned = true;
			this.Yandere.TargetStudent.TaskPhase = 5;
			WeaponScript weaponScript;
			if ((this.Yandere.Weapon[1] != null && this.Yandere.Weapon[1].WeaponID == 1) || (this.Yandere.Weapon[1] != null && this.Yandere.Weapon[1].WeaponID == 8))
			{
				weaponScript = this.Yandere.Weapon[1];
				this.Yandere.Weapon[1] = null;
			}
			else
			{
				weaponScript = this.Yandere.Weapon[2];
				this.Yandere.Weapon[2] = null;
			}
			weaponScript.Drop();
			weaponScript.FingerprintID = 77;
			weaponScript.gameObject.SetActive(false);
			this.Yandere.WeaponManager.UpdateLabels();
			this.Yandere.WeaponMenu.UpdateSprites();
		}
		else if (this.Yandere.TargetStudent.StudentID == 78 && TaskGlobals.GetTaskStatus(78) == 1)
		{
			this.Yandere.TargetStudent.RespectEarned = true;
			this.Yandere.TargetStudent.TaskPhase = 5;
			this.Yandere.Inventory.Sake = false;
		}
		else if (this.Yandere.TargetStudent.StudentID == 79 && TaskGlobals.GetTaskStatus(79) == 1)
		{
			this.Yandere.TargetStudent.RespectEarned = true;
			this.Yandere.TargetStudent.TaskPhase = 5;
			this.Yandere.Inventory.Cigs = false;
		}
		else if (this.Yandere.TargetStudent.StudentID == 80 && TaskGlobals.GetTaskStatus(80) == 1)
		{
			this.Yandere.TargetStudent.RespectEarned = true;
			this.Yandere.TargetStudent.TaskPhase = 5;
			this.Yandere.Inventory.AnswerSheet = false;
		}
		bool flag = false;
		if (this.Yandere.TargetStudent.StudentID != 8 && this.Yandere.TargetStudent.StudentID != 11 && this.Yandere.TargetStudent.StudentID != 25 && this.Yandere.TargetStudent.StudentID != 28 && this.Yandere.TargetStudent.StudentID != 30 && this.Yandere.TargetStudent.StudentID != 36 && this.Yandere.TargetStudent.StudentID != 37 && this.Yandere.TargetStudent.StudentID != 38 && this.Yandere.TargetStudent.StudentID != 52 && this.Yandere.TargetStudent.StudentID != 76 && this.Yandere.TargetStudent.StudentID != 77 && this.Yandere.TargetStudent.StudentID != 78 && this.Yandere.TargetStudent.StudentID != 79 && this.Yandere.TargetStudent.StudentID != 80 && this.Yandere.TargetStudent.StudentID != 81)
		{
			flag = true;
		}
		if (flag && TaskGlobals.GetTaskStatus(this.Yandere.TargetStudent.StudentID) == 1 && this.Yandere.Inventory.Book)
		{
			this.Yandere.TargetStudent.TaskPhase = 5;
		}
		if (this.Yandere.Club == ClubType.Delinquent)
		{
			this.Text[6] = "Intimidate";
			return;
		}
		this.Text[6] = "Ask Favor";
	}

	public void End()
	{
		if (this.Yandere.TargetStudent != null)
		{
			if (this.Yandere.TargetStudent.Pestered >= 10)
			{
				this.Yandere.TargetStudent.Ignoring = true;
			}
			if (!this.Pestered)
			{
				this.Yandere.Subtitle.Label.text = string.Empty;
			}
			this.Yandere.TargetStudent.Interaction = StudentInteractionType.Idle;
			this.Yandere.TargetStudent.WaitTimer = 1f;
			if (this.Yandere.TargetStudent.enabled)
			{
				this.Yandere.TargetStudent.CurrentDestination = this.Yandere.TargetStudent.Destinations[this.Yandere.TargetStudent.Phase];
				this.Yandere.TargetStudent.Pathfinding.target = this.Yandere.TargetStudent.Destinations[this.Yandere.TargetStudent.Phase];
				if (this.Yandere.TargetStudent.Actions[this.Yandere.TargetStudent.Phase] == StudentActionType.Clean)
				{
					this.Yandere.TargetStudent.EquipCleaningItems();
				}
				if (this.Yandere.TargetStudent.Actions[this.Yandere.TargetStudent.Phase] == StudentActionType.Patrol)
				{
					this.Yandere.TargetStudent.CurrentDestination = this.Yandere.TargetStudent.StudentManager.Patrols.List[this.Yandere.TargetStudent.StudentID].GetChild(this.Yandere.TargetStudent.PatrolID);
					this.Yandere.TargetStudent.Pathfinding.target = this.Yandere.TargetStudent.CurrentDestination;
				}
				if (this.Yandere.TargetStudent.Actions[this.Yandere.TargetStudent.Phase] == StudentActionType.Sleuth)
				{
					this.Yandere.TargetStudent.CurrentDestination = this.Yandere.TargetStudent.SleuthTarget;
					this.Yandere.TargetStudent.Pathfinding.target = this.Yandere.TargetStudent.SleuthTarget;
				}
				if (this.Yandere.TargetStudent.Actions[this.Yandere.TargetStudent.Phase] == StudentActionType.Sunbathe && this.Yandere.TargetStudent.SunbathePhase > 1)
				{
					this.Yandere.TargetStudent.CurrentDestination = this.Yandere.StudentManager.SunbatheSpots[this.Yandere.TargetStudent.StudentID];
					this.Yandere.TargetStudent.Pathfinding.target = this.Yandere.StudentManager.SunbatheSpots[this.Yandere.TargetStudent.StudentID];
				}
			}
			if (this.Yandere.TargetStudent.Persona == PersonaType.PhoneAddict)
			{
				bool flag = false;
				if (this.Yandere.TargetStudent.CurrentAction == StudentActionType.Sunbathe && this.Yandere.TargetStudent.SunbathePhase > 2)
				{
					flag = true;
				}
				if (!this.Yandere.TargetStudent.Scrubber.activeInHierarchy && !flag && !this.Yandere.TargetStudent.Phoneless)
				{
					this.Yandere.TargetStudent.SmartPhone.SetActive(true);
					this.Yandere.TargetStudent.WalkAnim = this.Yandere.TargetStudent.PhoneAnims[1];
				}
				else
				{
					this.Yandere.TargetStudent.SmartPhone.SetActive(false);
				}
			}
			if (this.Yandere.TargetStudent.LostTeacherTrust)
			{
				this.Yandere.TargetStudent.WalkAnim = this.Yandere.TargetStudent.BulliedWalkAnim;
				this.Yandere.TargetStudent.SmartPhone.SetActive(false);
			}
			if (this.Yandere.TargetStudent.EatingSnack)
			{
				this.Yandere.TargetStudent.Scrubber.SetActive(false);
				this.Yandere.TargetStudent.Eraser.SetActive(false);
			}
			if (this.Yandere.TargetStudent.SentToLocker)
			{
				this.Yandere.TargetStudent.CurrentDestination = this.Yandere.TargetStudent.MyLocker;
				this.Yandere.TargetStudent.Pathfinding.target = this.Yandere.TargetStudent.MyLocker;
			}
			this.Yandere.TargetStudent.Talk.NegativeResponse = false;
			this.Yandere.ShoulderCamera.OverShoulder = false;
			this.Yandere.TargetStudent.Waiting = true;
			this.Yandere.TargetStudent = null;
		}
		this.Yandere.StudentManager.VolumeUp();
		this.Jukebox.Dip = 1f;
		this.AskingFavor = false;
		this.Matchmaking = false;
		this.ClubLeader = false;
		this.Pestered = false;
		this.Show = false;
	}
}
