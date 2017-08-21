using System;
using UnityEngine;

public class DialogueWheelScript : MonoBehaviour
{
	public AppearanceWindowScript AppearanceWindow;

	public ClubManagerScript ClubManager;

	public PauseScreenScript PauseScreen;

	public LoveManagerScript LoveManager;

	public ReputationScript Reputation;

	public ClubWindowScript ClubWindow;

	public TaskWindowScript TaskWindow;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public ClockScript Clock;

	public UIPanel Panel;

	public GameObject DatingMinigame;

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

	public bool Show;

	public Vector3 PreviousPosition;

	public Vector2 MouseDelta;

	private void Start()
	{
		this.Interaction.localScale = new Vector3(1f, 1f, 1f);
		this.Favors.localScale = Vector3.zero;
		this.Club.localScale = Vector3.zero;
		this.Love.localScale = Vector3.zero;
		base.transform.localScale = Vector3.zero;
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
				if (!this.ClubLeader)
				{
					if (this.Selected == 5)
					{
						this.CenterLabel.text = (Globals.GetStudentFriend(this.Yandere.TargetStudent.StudentID) ? "Love" : this.Text[this.Selected]);
					}
					else
					{
						this.CenterLabel.text = this.Text[this.Selected];
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
					this.CenterLabel.text = ((!this.AskingFavor) ? this.LoveText[this.Selected] : this.FavorText[this.Selected]);
				}
			}
			if (!this.ClubLeader)
			{
				for (int i = 1; i < 7; i++)
				{
					Transform transform = this.Segment[i].transform;
					transform.localScale = Vector3.Lerp(transform.localScale, (this.Selected != i) ? new Vector3(1f, 1f, 1f) : new Vector3(1.3f, 1.3f, 1f), Time.deltaTime * 10f);
				}
			}
			else
			{
				for (int j = 1; j < 7; j++)
				{
					Transform transform2 = this.ClubSegment[j].transform;
					transform2.localScale = Vector3.Lerp(transform2.localScale, (this.Selected != j) ? new Vector3(1f, 1f, 1f) : new Vector3(1.3f, 1.3f, 1f), Time.deltaTime * 10f);
				}
			}
			if (!this.Matchmaking)
			{
				for (int k = 1; k < 5; k++)
				{
					Transform transform3 = this.FavorSegment[k].transform;
					transform3.localScale = Vector3.Lerp(transform3.localScale, (this.Selected != k) ? new Vector3(1f, 1f, 1f) : new Vector3(1.3f, 1.3f, 1f), Time.deltaTime * 10f);
				}
			}
			else
			{
				for (int l = 1; l < 5; l++)
				{
					Transform transform4 = this.LoveSegment[l].transform;
					transform4.localScale = Vector3.Lerp(transform4.localScale, (this.Selected != l) ? new Vector3(1f, 1f, 1f) : new Vector3(1.3f, 1.3f, 1f), Time.deltaTime * 10f);
				}
			}
			if (Input.GetButtonDown("A"))
			{
				if (this.ClubLeader)
				{
					if (this.Selected != 0 && this.ClubShadow[this.Selected].color.a == 0f)
					{
						if (this.Selected == 1)
						{
							this.Impatience.fillAmount = 0f;
							this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubInfo;
							this.Yandere.TargetStudent.TalkTimer = 100f;
							this.Yandere.TargetStudent.ClubPhase = 1;
							this.Show = false;
						}
						if (this.Selected == 2)
						{
							this.Impatience.fillAmount = 0f;
							this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubJoin;
							this.Yandere.TargetStudent.TalkTimer = 100f;
							this.Show = false;
							this.ClubManager.CheckGrudge(this.Yandere.TargetStudent.Club);
							if (Globals.GetQuitClub(this.Yandere.TargetStudent.Club))
							{
								this.Yandere.TargetStudent.ClubPhase = 4;
							}
							else if (Globals.Club != 0)
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
						if (this.Selected == 3)
						{
							this.Impatience.fillAmount = 0f;
							this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubQuit;
							this.Yandere.TargetStudent.TalkTimer = 100f;
							this.Yandere.TargetStudent.ClubPhase = 1;
							this.Show = false;
						}
						if (this.Selected == 4)
						{
							this.Impatience.fillAmount = 0f;
							this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubBye;
							this.Yandere.TargetStudent.TalkTimer = this.Yandere.Subtitle.ClubFarewellClips[this.Yandere.TargetStudent.Club].length;
							this.Show = false;
						}
						if (this.Selected == 5)
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
						if (this.Selected == 6)
						{
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
							if (this.Selected == 2)
							{
								this.Impatience.fillAmount = 0f;
								this.Yandere.Interaction = YandereInteractionType.GoAway;
								this.Yandere.TalkTimer = 3f;
								this.Show = false;
							}
							if (this.Selected == 4)
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
								Time.timeScale = 0f;
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
							if (this.Selected == 2)
							{
								this.Impatience.fillAmount = 0f;
								this.Yandere.Interaction = YandereInteractionType.Court;
								this.Yandere.TalkTimer = 5f;
								this.Show = false;
							}
							if (this.Selected == 4)
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
					if (this.Selected == 2)
					{
						this.Impatience.fillAmount = 0f;
						this.Yandere.Interaction = YandereInteractionType.Compliment;
						this.Yandere.TalkTimer = 3f;
						this.Show = false;
					}
					if (this.Selected == 3)
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
						Time.timeScale = 0f;
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
					if (this.Selected == 4)
					{
						this.Impatience.fillAmount = 0f;
						this.Yandere.Interaction = YandereInteractionType.Bye;
						this.Yandere.TalkTimer = 2f;
						this.Show = false;
					}
					if (this.Selected == 5)
					{
						if (!Globals.GetStudentFriend(this.Yandere.TargetStudent.StudentID))
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
							Time.timeScale = 0f;
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
						else
						{
							this.Matchmaking = true;
						}
					}
					if (this.Selected == 6)
					{
						this.AskingFavor = true;
					}
				}
			}
		}
		this.PreviousPosition = Input.mousePosition;
	}

	public void HideShadows()
	{
		this.TaskIcon.spriteName = ((!Globals.GetStudentFriend(this.Yandere.TargetStudent.StudentID)) ? "Task" : "Heart");
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
		if (!this.Yandere.TargetStudent.Witness || this.Yandere.TargetStudent.Forgave)
		{
			UISprite uisprite5 = this.Shadow[1];
			uisprite5.color = new Color(uisprite5.color.r, uisprite5.color.g, uisprite5.color.b, 0.75f);
		}
		if (this.Yandere.TargetStudent.Complimented)
		{
			UISprite uisprite6 = this.Shadow[2];
			uisprite6.color = new Color(uisprite6.color.r, uisprite6.color.g, uisprite6.color.b, 0.75f);
		}
		if (this.Yandere.TargetStudent.Gossiped)
		{
			UISprite uisprite7 = this.Shadow[3];
			uisprite7.color = new Color(uisprite7.color.r, uisprite7.color.g, uisprite7.color.b, 0.75f);
		}
		if (this.Yandere.Bloodiness > 0f || this.Yandere.Sanity < 33.33333f)
		{
			UISprite uisprite8 = this.Shadow[3];
			uisprite8.color = new Color(uisprite8.color.r, uisprite8.color.g, uisprite8.color.b, 0.75f);
			UISprite uisprite9 = this.Shadow[5];
			uisprite9.color = new Color(uisprite9.color.r, uisprite9.color.g, uisprite9.color.b, 0.75f);
			UISprite uisprite10 = this.Shadow[6];
			uisprite10.color = new Color(uisprite10.color.r, uisprite10.color.g, uisprite10.color.b, 0.75f);
		}
		else if (this.Reputation.Reputation < -33.33333f)
		{
			UISprite uisprite11 = this.Shadow[3];
			uisprite11.color = new Color(uisprite11.color.r, uisprite11.color.g, uisprite11.color.b, 0.75f);
		}
		if (!Globals.GetStudentFriend(this.Yandere.TargetStudent.StudentID))
		{
			if (this.Yandere.TargetStudent.StudentID != 6 && this.Yandere.TargetStudent.StudentID != 7 && this.Yandere.TargetStudent.StudentID != 13 && this.Yandere.TargetStudent.StudentID != 14 && this.Yandere.TargetStudent.StudentID != 15 && this.Yandere.TargetStudent.StudentID != 32 && this.Yandere.TargetStudent.StudentID != 33)
			{
				UISprite uisprite12 = this.Shadow[5];
				uisprite12.color = new Color(uisprite12.color.r, uisprite12.color.g, uisprite12.color.b, 0.75f);
			}
			else
			{
				if (this.Yandere.TargetStudent.TaskPhase > 0 && this.Yandere.TargetStudent.TaskPhase < 5)
				{
					UISprite uisprite13 = this.Shadow[5];
					uisprite13.color = new Color(uisprite13.color.r, uisprite13.color.g, uisprite13.color.b, 0.75f);
				}
				if (this.Yandere.TargetStudent.StudentID == 32)
				{
					if (this.Clock.Period != 3)
					{
						UISprite uisprite14 = this.Shadow[5];
						uisprite14.color = new Color(uisprite14.color.r, uisprite14.color.g, uisprite14.color.b, 0.75f);
					}
					else if (Globals.GetTaskStatus(32) == 1 && this.Yandere.Inventory.Cigs)
					{
						UISprite uisprite15 = this.Shadow[5];
						uisprite15.color = new Color(uisprite15.color.r, uisprite15.color.g, uisprite15.color.b, 0f);
					}
				}
			}
		}
		else if (this.Yandere.TargetStudent.StudentID != 7 && this.Yandere.TargetStudent.StudentID != 13)
		{
			UISprite uisprite16 = this.Shadow[5];
			uisprite16.color = new Color(uisprite16.color.r, uisprite16.color.g, uisprite16.color.b, 0.75f);
		}
		else if (!this.Yandere.TargetStudent.Male && this.LoveManager.SuitorProgress == 0)
		{
			UISprite uisprite17 = this.Shadow[5];
			uisprite17.color = new Color(uisprite17.color.r, uisprite17.color.g, uisprite17.color.b, 0.75f);
		}
		if (!Globals.GetStudentFriend(this.Yandere.TargetStudent.StudentID))
		{
			UISprite uisprite18 = this.Shadow[6];
			uisprite18.color = new Color(uisprite18.color.r, uisprite18.color.g, uisprite18.color.b, 0.75f);
		}
		if ((this.Yandere.TargetStudent.Male && Globals.Seduction + Globals.SeductionBonus > 3) || Globals.Seduction + Globals.SeductionBonus > 4)
		{
			UISprite uisprite19 = this.Shadow[6];
			uisprite19.color = new Color(uisprite19.color.r, uisprite19.color.g, uisprite19.color.b, 0f);
		}
		if (Globals.Club == this.Yandere.TargetStudent.Club)
		{
			UISprite uisprite20 = this.ClubShadow[1];
			uisprite20.color = new Color(uisprite20.color.r, uisprite20.color.g, uisprite20.color.b, 0.75f);
			UISprite uisprite21 = this.ClubShadow[2];
			uisprite21.color = new Color(uisprite21.color.r, uisprite21.color.g, uisprite21.color.b, 0.75f);
		}
		if (this.Yandere.ClubAttire || this.Yandere.Mask != null || this.Yandere.Gloves != null || this.Yandere.Container != null)
		{
			UISprite uisprite22 = this.ClubShadow[3];
			uisprite22.color = new Color(uisprite22.color.r, uisprite22.color.g, uisprite22.color.b, 0.75f);
		}
		if (Globals.Club != this.Yandere.TargetStudent.Club)
		{
			UISprite uisprite23 = this.ClubShadow[2];
			uisprite23.color = new Color(uisprite23.color.r, uisprite23.color.g, uisprite23.color.b, 0f);
			UISprite uisprite24 = this.ClubShadow[3];
			uisprite24.color = new Color(uisprite24.color.r, uisprite24.color.g, uisprite24.color.b, 0.75f);
			UISprite uisprite25 = this.ClubShadow[5];
			uisprite25.color = new Color(uisprite25.color.r, uisprite25.color.g, uisprite25.color.b, 0.75f);
		}
		UISprite uisprite26 = this.ClubShadow[6];
		uisprite26.color = new Color(uisprite26.color.r, uisprite26.color.g, uisprite26.color.b, 0.75f);
		if (this.Yandere.Followers > 0)
		{
			UISprite uisprite27 = this.FavorShadow[1];
			uisprite27.color = new Color(uisprite27.color.r, uisprite27.color.g, uisprite27.color.b, 0.75f);
		}
		if (this.Yandere.TargetStudent.DistanceToDestination > 0.5f)
		{
			UISprite uisprite28 = this.FavorShadow[2];
			uisprite28.color = new Color(uisprite28.color.r, uisprite28.color.g, uisprite28.color.b, 0.75f);
		}
		if (!this.Yandere.TargetStudent.Male)
		{
			UISprite uisprite29 = this.LoveShadow[1];
			uisprite29.color = new Color(uisprite29.color.r, uisprite29.color.g, uisprite29.color.b, 0.75f);
		}
		if (this.DatingMinigame == null || !this.Yandere.Inventory.Headset || (this.Yandere.TargetStudent.Male && !this.LoveManager.RivalWaiting) || this.LoveManager.Courted)
		{
			UISprite uisprite30 = this.LoveShadow[2];
			uisprite30.color = new Color(uisprite30.color.r, uisprite30.color.g, uisprite30.color.b, 0.75f);
		}
		if (!this.Yandere.TargetStudent.Male || !this.Yandere.Inventory.Rose || this.Yandere.TargetStudent.Rose)
		{
			UISprite uisprite31 = this.LoveShadow[4];
			uisprite31.color = new Color(uisprite31.color.r, uisprite31.color.g, uisprite31.color.b, 0.75f);
		}
	}

	private void CheckTaskCompletion()
	{
		if (Globals.GetTaskStatus(this.Yandere.TargetStudent.StudentID) == 2 && this.Yandere.TargetStudent.StudentID == 32)
		{
			this.Yandere.Inventory.Cigs = false;
		}
	}

	public void End()
	{
		if (this.Yandere.TargetStudent != null)
		{
			this.Yandere.TargetStudent.Interaction = StudentInteractionType.Idle;
			this.Yandere.TargetStudent.WaitTimer = 1f;
			if (this.Yandere.TargetStudent.enabled)
			{
				this.Yandere.TargetStudent.CurrentDestination = this.Yandere.TargetStudent.Destinations[this.Yandere.TargetStudent.Phase];
				this.Yandere.TargetStudent.Pathfinding.target = this.Yandere.TargetStudent.Destinations[this.Yandere.TargetStudent.Phase];
			}
			this.Yandere.TargetStudent.ShoulderCamera.OverShoulder = false;
			this.Yandere.TargetStudent.Waiting = true;
			this.Yandere.TargetStudent = null;
		}
		this.Yandere.Subtitle.Label.text = string.Empty;
		this.AskingFavor = false;
		this.Matchmaking = false;
		this.ClubLeader = false;
		this.Show = false;
	}
}
