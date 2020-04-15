﻿using System;
using UnityEngine;

public class HomeInternetScript : MonoBehaviour
{
	public StudentInfoMenuScript StudentInfoMenu;

	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public PromptBarScript PromptBar;

	public HomeClockScript Clock;

	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public HomeWindowScript HomeWindow;

	public UILabel YanderePostLabel;

	public UILabel YancordLabel;

	public UILabel AcceptLabel;

	public UITexture YancordLogo;

	public GameObject InternetPrompts;

	public GameObject NavigationMenu;

	public GameObject OnlineShopping;

	public GameObject SocialMedia;

	public GameObject NewPostText;

	public GameObject ChangeLabel;

	public GameObject ChangeIcon;

	public GameObject WriteLabel;

	public GameObject WriteIcon;

	public GameObject PostLabel;

	public GameObject PostIcon;

	public GameObject BG;

	public Transform MenuHighlight;

	public Transform StudentPost1;

	public Transform StudentPost2;

	public Transform YandereReply;

	public Transform YanderePost;

	public Transform LameReply;

	public Transform NewPost;

	public Transform Menu;

	public Transform[] StudentReplies;

	public UISprite[] Highlights;

	public UILabel[] PostLabels;

	public UILabel[] MenuLabels;

	public string[] Locations;

	public string[] Actions;

	public bool PostSequence;

	public bool WritingPost;

	public bool ShowMenu;

	public bool FadeOut;

	public bool Success;

	public bool Posted;

	public int MenuSelected = 1;

	public int Selected = 1;

	public int ID = 1;

	public int Location;

	public int Student;

	public int Action;

	public float Timer;

	public UITexture StudentPost1Portrait;

	public UITexture StudentPost2Portrait;

	public UITexture LamePostPortrait;

	public Texture CurrentPortrait;

	public UITexture[] Portraits;

	public int Height;

	public Transform Highlight;

	public Transform ItemList;

	public GameObject AreYouSure;

	public AudioSource MyAudio;

	public UILabel MoneyLabel;

	public float Shake;

	private void Awake()
	{
		this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, -180f, this.StudentPost1.localPosition.z);
		this.StudentPost2.localPosition = new Vector3(this.StudentPost2.localPosition.x, -365f, this.StudentPost2.localPosition.z);
		this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, -88f, this.YandereReply.localPosition.z);
		this.YanderePost.localPosition = new Vector3(this.YanderePost.localPosition.x, -2f, this.YanderePost.localPosition.z);
		for (int i = 1; i < 6; i++)
		{
			Transform transform = this.StudentReplies[i];
			transform.localPosition = new Vector3(transform.localPosition.x, -40f, transform.localPosition.z);
		}
		this.LameReply.localPosition = new Vector3(this.LameReply.localPosition.x, -40f, this.LameReply.localPosition.z);
		this.Highlights[1].enabled = false;
		this.Highlights[2].enabled = false;
		this.Highlights[3].enabled = false;
		this.YanderePost.gameObject.SetActive(false);
		this.NavigationMenu.SetActive(true);
		this.ChangeLabel.SetActive(false);
		this.ChangeIcon.SetActive(false);
		this.PostLabel.SetActive(false);
		this.PostIcon.SetActive(false);
		this.OnlineShopping.SetActive(false);
		this.NewPostText.SetActive(false);
		this.BG.SetActive(false);
		if (!EventGlobals.Event2 || StudentGlobals.GetStudentExposed(30))
		{
			this.WriteLabel.SetActive(false);
			this.WriteIcon.SetActive(false);
		}
		this.GetPortrait(2);
		this.StudentPost1Portrait.mainTexture = this.CurrentPortrait;
		this.GetPortrait(39);
		this.StudentPost2Portrait.mainTexture = this.CurrentPortrait;
		this.GetPortrait(25);
		this.LamePostPortrait.mainTexture = this.CurrentPortrait;
		this.ID = 1;
		while (this.ID < 6)
		{
			this.GetPortrait(86 - this.ID);
			this.Portraits[this.ID].mainTexture = this.CurrentPortrait;
			this.ID++;
		}
		if (!DateGlobals.DayPassed)
		{
			this.YancordLabel.color = new Color(1f, 1f, 1f, 0.2f);
			this.YancordLogo.color = new Color(1f, 1f, 1f, 0.2f);
		}
	}

	private void Update()
	{
		if (!this.HomeYandere.CanMove && !this.PauseScreen.Show)
		{
			if (this.NavigationMenu.activeInHierarchy && !this.HomeCamera.CyberstalkWindow.activeInHierarchy)
			{
				if (Input.GetButtonDown("A"))
				{
					this.NavigationMenu.SetActive(false);
					this.SocialMedia.SetActive(true);
				}
				else if (Input.GetButtonDown("X"))
				{
					if (DateGlobals.DayPassed)
					{
						this.HomeCamera.HomeDarkness.FadeOut = true;
					}
				}
				else if (Input.GetButtonDown("Y"))
				{
					this.PauseScreen.MainMenu.SetActive(false);
					this.PauseScreen.Panel.enabled = true;
					this.PauseScreen.Sideways = true;
					this.PauseScreen.Show = true;
					this.StudentInfoMenu.gameObject.SetActive(true);
					this.StudentInfoMenu.CyberStalking = true;
					base.StartCoroutine(this.StudentInfoMenu.UpdatePortraits());
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "View Info";
					this.PromptBar.Label[1].text = "Back";
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
				}
				else if (Input.GetButtonDown("LB"))
				{
					this.NavigationMenu.SetActive(false);
					this.OnlineShopping.SetActive(true);
					this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2");
				}
				else if (Input.GetButtonDown("B"))
				{
					this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
					this.HomeCamera.Target = this.HomeCamera.Targets[0];
					this.HomeYandere.CanMove = true;
					this.HomeWindow.Show = false;
					base.enabled = false;
				}
			}
			else if (this.SocialMedia.activeInHierarchy)
			{
				this.Menu.localScale = Vector3.Lerp(this.Menu.localScale, this.ShowMenu ? new Vector3(1f, 1f, 1f) : Vector3.zero, Time.deltaTime * 10f);
				if (this.WritingPost)
				{
					this.NewPost.transform.localPosition = Vector3.Lerp(this.NewPost.transform.localPosition, Vector3.zero, Time.deltaTime * 10f);
					this.NewPost.transform.localScale = Vector3.Lerp(this.NewPost.transform.localScale, new Vector3(2.43f, 2.43f, 2.43f), Time.deltaTime * 10f);
					for (int i = 1; i < this.Highlights.Length; i++)
					{
						UISprite uisprite = this.Highlights[i];
						uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, Mathf.MoveTowards(uisprite.color.a, this.FadeOut ? 0f : 1f, Time.deltaTime));
					}
					if (this.Highlights[this.Selected].color.a == 1f)
					{
						this.FadeOut = true;
					}
					else if (this.Highlights[this.Selected].color.a == 0f)
					{
						this.FadeOut = false;
					}
					if (!this.ShowMenu)
					{
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
					}
					else
					{
						if (this.InputManager.TappedDown)
						{
							this.MenuSelected++;
							this.UpdateMenuHighlight();
						}
						if (this.InputManager.TappedUp)
						{
							this.MenuSelected--;
							this.UpdateMenuHighlight();
						}
					}
				}
				else
				{
					this.NewPost.transform.localPosition = Vector3.Lerp(this.NewPost.transform.localPosition, new Vector3(175f, -10f, 0f), Time.deltaTime * 10f);
					this.NewPost.transform.localScale = Vector3.Lerp(this.NewPost.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				}
				if (!this.PostSequence)
				{
					if (Input.GetButtonDown("A") && this.WriteIcon.activeInHierarchy && !this.Posted)
					{
						if (!this.ShowMenu)
						{
							if (!this.WritingPost)
							{
								this.AcceptLabel.text = "Select";
								this.ChangeLabel.SetActive(true);
								this.ChangeIcon.SetActive(true);
								this.NewPostText.SetActive(true);
								this.BG.SetActive(true);
								this.WritingPost = true;
								this.Selected = 1;
								this.UpdateHighlight();
							}
							else if (this.Selected == 1)
							{
								this.PauseScreen.MainMenu.SetActive(false);
								this.PauseScreen.Panel.enabled = true;
								this.PauseScreen.Sideways = true;
								this.PauseScreen.Show = true;
								this.StudentInfoMenu.gameObject.SetActive(true);
								this.StudentInfoMenu.CyberBullying = true;
								base.StartCoroutine(this.StudentInfoMenu.UpdatePortraits());
								this.PromptBar.ClearButtons();
								this.PromptBar.Label[0].text = "View Info";
								this.PromptBar.Label[1].text = "Back";
								this.PromptBar.UpdateButtons();
								this.PromptBar.Show = true;
							}
							else if (this.Selected == 2)
							{
								this.MenuSelected = 1;
								this.UpdateMenuHighlight();
								this.ShowMenu = true;
								for (int j = 1; j < this.MenuLabels.Length; j++)
								{
									this.MenuLabels[j].text = this.Locations[j];
								}
							}
							else if (this.Selected == 3)
							{
								this.MenuSelected = 1;
								this.UpdateMenuHighlight();
								this.ShowMenu = true;
								for (int k = 1; k < this.MenuLabels.Length; k++)
								{
									this.MenuLabels[k].text = this.Actions[k];
								}
							}
						}
						else
						{
							if (this.Selected == 2)
							{
								this.Location = this.MenuSelected;
								this.PostLabels[2].text = this.Locations[this.MenuSelected];
								this.ShowMenu = false;
							}
							else if (this.Selected == 3)
							{
								this.Action = this.MenuSelected;
								this.PostLabels[3].text = this.Actions[this.MenuSelected];
								this.ShowMenu = false;
							}
							this.CheckForCompletion();
						}
					}
					if (Input.GetButtonDown("B"))
					{
						if (!this.ShowMenu)
						{
							if (!this.WritingPost)
							{
								this.NavigationMenu.SetActive(true);
								this.SocialMedia.SetActive(false);
							}
							else
							{
								this.AcceptLabel.text = "Write";
								this.ChangeLabel.SetActive(false);
								this.ChangeIcon.SetActive(false);
								this.PostLabel.SetActive(false);
								this.PostIcon.SetActive(false);
								this.ExitPost();
							}
						}
						else
						{
							this.ShowMenu = false;
						}
					}
					if (Input.GetButtonDown("X") && this.PostIcon.activeInHierarchy)
					{
						this.YanderePostLabel.text = string.Concat(new string[]
						{
							"Today, I saw ",
							this.PostLabels[1].text,
							" in ",
							this.PostLabels[2].text,
							". She was ",
							this.PostLabels[3].text,
							"."
						});
						this.ExitPost();
						this.InternetPrompts.SetActive(false);
						this.ChangeLabel.SetActive(false);
						this.ChangeIcon.SetActive(false);
						this.WriteLabel.SetActive(false);
						this.WriteIcon.SetActive(false);
						this.PostLabel.SetActive(false);
						this.PostIcon.SetActive(false);
						this.PostSequence = true;
						this.Posted = true;
						if (this.Student == 30 && this.Location == 7 && this.Action == 9)
						{
							this.Success = true;
						}
					}
					if (Input.GetKeyDown("space"))
					{
						this.WriteLabel.SetActive(true);
						this.WriteIcon.SetActive(true);
					}
				}
				if (this.PostSequence)
				{
					if (Input.GetButtonDown("A"))
					{
						this.Timer += 2f;
					}
					this.Timer += Time.deltaTime;
					if (this.Timer > 1f && this.Timer < 3f)
					{
						this.YanderePost.gameObject.SetActive(true);
						this.YanderePost.transform.localPosition = new Vector3(this.YanderePost.transform.localPosition.x, Mathf.Lerp(this.YanderePost.transform.localPosition.y, -155f, Time.deltaTime * 10f), this.YanderePost.transform.localPosition.z);
						this.StudentPost1.transform.localPosition = new Vector3(this.StudentPost1.transform.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -365f, Time.deltaTime * 10f), this.StudentPost1.transform.localPosition.z);
						this.StudentPost2.transform.localPosition = new Vector3(this.StudentPost2.transform.localPosition.x, Mathf.Lerp(this.StudentPost2.transform.localPosition.y, -550f, Time.deltaTime * 10f), this.StudentPost2.transform.localPosition.z);
					}
					if (!this.Success)
					{
						if (this.Timer > 3f && this.Timer < 5f)
						{
							this.LameReply.localPosition = new Vector3(this.LameReply.localPosition.x, Mathf.Lerp(this.LameReply.transform.localPosition.y, -88f, Time.deltaTime * 10f), this.LameReply.localPosition.z);
							this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -137f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
							this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -415f, Time.deltaTime * 10f), this.StudentPost1.localPosition.z);
						}
						if (this.Timer > 5f)
						{
							PlayerGlobals.Reputation -= 5f;
							this.InternetPrompts.SetActive(true);
							this.PostSequence = false;
						}
					}
					else
					{
						if (this.Timer > 3f && this.Timer < 5f)
						{
							Transform transform = this.StudentReplies[1];
							transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.transform.localPosition.y, -88f, Time.deltaTime * 10f), transform.localPosition.z);
							this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -137f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
							this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -415f, Time.deltaTime * 10f), this.StudentPost1.localPosition.z);
						}
						if (this.Timer > 5f && this.Timer < 7f)
						{
							Transform transform2 = this.StudentReplies[2];
							transform2.localPosition = new Vector3(transform2.localPosition.x, Mathf.Lerp(transform2.transform.localPosition.y, -88f, Time.deltaTime * 10f), transform2.localPosition.z);
							Transform transform3 = this.StudentReplies[1];
							transform3.localPosition = new Vector3(transform3.localPosition.x, Mathf.Lerp(transform3.transform.localPosition.y, -136f, Time.deltaTime * 10f), transform3.localPosition.z);
							this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -185f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
							this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -465f, Time.deltaTime * 10f), this.StudentPost1.localPosition.z);
						}
						if (this.Timer > 7f && this.Timer < 9f)
						{
							Transform transform4 = this.StudentReplies[3];
							transform4.localPosition = new Vector3(transform4.localPosition.x, Mathf.Lerp(transform4.transform.localPosition.y, -88f, Time.deltaTime * 10f), transform4.localPosition.z);
							Transform transform5 = this.StudentReplies[2];
							transform5.localPosition = new Vector3(transform5.localPosition.x, Mathf.Lerp(transform5.transform.localPosition.y, -136f, Time.deltaTime * 10f), transform5.localPosition.z);
							Transform transform6 = this.StudentReplies[1];
							transform6.localPosition = new Vector3(transform6.localPosition.x, Mathf.Lerp(transform6.transform.localPosition.y, -184f, Time.deltaTime * 10f), transform6.localPosition.z);
							this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -233f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
							this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -510f, Time.deltaTime * 10f), this.StudentPost1.localPosition.z);
						}
						if (this.Timer > 9f && this.Timer < 11f)
						{
							Transform transform7 = this.StudentReplies[4];
							transform7.localPosition = new Vector3(transform7.localPosition.x, Mathf.Lerp(transform7.transform.localPosition.y, -88f, Time.deltaTime * 10f), transform7.localPosition.z);
							Transform transform8 = this.StudentReplies[3];
							transform8.localPosition = new Vector3(transform8.localPosition.x, Mathf.Lerp(transform8.transform.localPosition.y, -136f, Time.deltaTime * 10f), transform8.localPosition.z);
							Transform transform9 = this.StudentReplies[2];
							transform9.localPosition = new Vector3(transform9.localPosition.x, Mathf.Lerp(transform9.transform.localPosition.y, -184f, Time.deltaTime * 10f), transform9.localPosition.z);
							Transform transform10 = this.StudentReplies[1];
							transform10.localPosition = new Vector3(transform10.localPosition.x, Mathf.Lerp(transform10.transform.localPosition.y, -232f, Time.deltaTime * 10f), transform10.localPosition.z);
							this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -281f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
							this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -560f, Time.deltaTime * 10f), this.StudentPost1.localPosition.z);
						}
						if (this.Timer > 11f && this.Timer < 13f)
						{
							Transform transform11 = this.StudentReplies[5];
							transform11.localPosition = new Vector3(transform11.localPosition.x, Mathf.Lerp(transform11.transform.localPosition.y, -88f, Time.deltaTime * 10f), transform11.localPosition.z);
							Transform transform12 = this.StudentReplies[4];
							transform12.localPosition = new Vector3(transform12.localPosition.x, Mathf.Lerp(transform12.transform.localPosition.y, -136f, Time.deltaTime * 10f), transform12.localPosition.z);
							Transform transform13 = this.StudentReplies[3];
							transform13.localPosition = new Vector3(transform13.localPosition.x, Mathf.Lerp(transform13.transform.localPosition.y, -184f, Time.deltaTime * 10f), transform13.localPosition.z);
							Transform transform14 = this.StudentReplies[2];
							transform14.localPosition = new Vector3(transform14.localPosition.x, Mathf.Lerp(transform14.transform.localPosition.y, -232f, Time.deltaTime * 10f), transform14.localPosition.z);
							Transform transform15 = this.StudentReplies[1];
							transform15.localPosition = new Vector3(transform15.localPosition.x, Mathf.Lerp(transform15.transform.localPosition.y, -280f, Time.deltaTime * 10f), transform15.localPosition.z);
							this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -329f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
						}
						if (this.Timer > 13f)
						{
							StudentGlobals.SetStudentExposed(30, true);
							StudentGlobals.SetStudentReputation(30, StudentGlobals.GetStudentReputation(30) - 50);
							this.InternetPrompts.SetActive(true);
							this.PostSequence = false;
						}
					}
				}
			}
			else if (this.OnlineShopping.activeInHierarchy)
			{
				if (Input.GetKeyDown("m"))
				{
					PlayerGlobals.Money = 100f;
				}
				if (Input.GetButtonDown("A"))
				{
					if (this.Height == 0 || this.Height > 1)
					{
						if (PlayerGlobals.Money > 33.33f)
						{
							if (!this.AreYouSure.activeInHierarchy)
							{
								this.AreYouSure.SetActive(true);
							}
							else
							{
								this.AreYouSure.SetActive(false);
								GameGlobals.SpareUniform = true;
								PlayerGlobals.Money -= 33.33f;
								this.MyAudio.Play();
								this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2");
								this.Clock.UpdateMoneyLabel();
							}
						}
						else
						{
							this.Shake = 10f;
						}
					}
					else if (this.Height == 1)
					{
						if (PlayerGlobals.Money > 8.49f)
						{
							if (!this.AreYouSure.activeInHierarchy)
							{
								this.AreYouSure.SetActive(true);
							}
							else
							{
								this.AreYouSure.SetActive(false);
								GameGlobals.BlondeHair = true;
								PlayerGlobals.Money -= 8.49f;
								this.MyAudio.Play();
								this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2");
								this.Clock.UpdateMoneyLabel();
							}
						}
						else
						{
							this.Shake = 10f;
						}
					}
				}
				this.Shake = Mathf.MoveTowards(this.Shake, 0f, Time.deltaTime * 10f);
				this.MoneyLabel.transform.localPosition = new Vector3(445f + UnityEngine.Random.Range(this.Shake * -1f, this.Shake * 1f), 410f + UnityEngine.Random.Range(this.Shake * -1f, this.Shake * 1f), 0f);
				if (Input.GetButtonDown("B"))
				{
					if (!this.AreYouSure.activeInHierarchy)
					{
						this.NavigationMenu.SetActive(true);
						this.OnlineShopping.SetActive(false);
					}
					else
					{
						this.AreYouSure.SetActive(false);
					}
				}
				if (this.InputManager.TappedDown)
				{
					this.Height++;
				}
				if (this.InputManager.TappedUp)
				{
					this.Height--;
				}
				if (this.Height < 0)
				{
					this.Height = 0;
				}
				if (this.Height > 4)
				{
					this.Height = 4;
				}
				if (this.Height == 0)
				{
					this.Highlight.localPosition = Vector3.Lerp(this.Highlight.localPosition, new Vector3(this.Highlight.localPosition.x, 130f, this.Highlight.localPosition.z), Time.deltaTime * 10f);
				}
				else if (this.Height > 0)
				{
					this.Highlight.localPosition = Vector3.Lerp(this.Highlight.localPosition, new Vector3(this.Highlight.localPosition.x, -85f, this.Highlight.localPosition.z), Time.deltaTime * 10f);
				}
				if (this.Height < 2)
				{
					this.ItemList.localPosition = Vector3.Lerp(this.ItemList.localPosition, new Vector3(this.ItemList.localPosition.x, 130f, this.ItemList.localPosition.z), Time.deltaTime * 10f);
				}
				else
				{
					this.ItemList.localPosition = Vector3.Lerp(this.ItemList.localPosition, new Vector3(this.ItemList.localPosition.x, (float)(130 + 215 * (this.Height - 1)), this.ItemList.localPosition.z), Time.deltaTime * 10f);
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			StudentGlobals.SetStudentExposed(7, false);
		}
	}

	private void ExitPost()
	{
		this.Highlights[1].enabled = false;
		this.Highlights[2].enabled = false;
		this.Highlights[3].enabled = false;
		this.NewPostText.SetActive(false);
		this.BG.SetActive(false);
		this.PostLabels[1].text = string.Empty;
		this.PostLabels[2].text = string.Empty;
		this.PostLabels[3].text = string.Empty;
		this.WritingPost = false;
	}

	private void UpdateHighlight()
	{
		if (this.Selected > 3)
		{
			this.Selected = 1;
		}
		if (this.Selected < 1)
		{
			this.Selected = 3;
		}
		this.Highlights[1].enabled = false;
		this.Highlights[2].enabled = false;
		this.Highlights[3].enabled = false;
		this.Highlights[this.Selected].enabled = true;
	}

	private void UpdateMenuHighlight()
	{
		if (this.MenuSelected > 10)
		{
			this.MenuSelected = 1;
		}
		if (this.MenuSelected < 1)
		{
			this.MenuSelected = 10;
		}
		this.MenuHighlight.transform.localPosition = new Vector3(this.MenuHighlight.transform.localPosition.x, 220f - 40f * (float)this.MenuSelected, this.MenuHighlight.transform.localPosition.z);
	}

	private void CheckForCompletion()
	{
		if (this.PostLabels[1].text != string.Empty && this.PostLabels[2].text != string.Empty && this.PostLabels[3].text != string.Empty)
		{
			this.PostLabel.SetActive(true);
			this.PostIcon.SetActive(true);
		}
	}

	private void GetPortrait(int ID)
	{
		WWW www = new WWW(string.Concat(new string[]
		{
			"file:///",
			Application.streamingAssetsPath,
			"/Portraits/Student_",
			ID.ToString(),
			".png"
		}));
		this.CurrentPortrait = www.texture;
	}
}
