using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class DialogueWheelScript : MonoBehaviour
{
	public ClubManagerScript ClubManager;

	public PauseScreenScript PauseScreen;

	public ReputationScript Reputation;

	public ClubWindowScript ClubWindow;

	public TaskWindowScript TaskWindow;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public ClockScript Clock;

	public Transform Interaction;

	public Transform Favors;

	public Transform Club;

	public UISprite Impatience;

	public UILabel CenterLabel;

	public UISprite[] Segment;

	public UISprite[] Shadow;

	public string[] Text;

	public UISprite[] FavorSegment;

	public UISprite[] FavorShadow;

	public string[] FavorText;

	public UISprite[] ClubSegment;

	public UISprite[] ClubShadow;

	public string[] ClubText;

	public int Selected;

	public int Victim;

	public bool AskingFavor;

	public bool ClubLeader;

	public bool Show;

	public Vector3 PreviousPosition;

	public Vector2 MouseDelta;

	public virtual void Start()
	{
		this.Interaction.localScale = new Vector3((float)1, (float)1, (float)1);
		this.Favors.localScale = new Vector3((float)0, (float)0, (float)0);
		this.transform.localScale = new Vector3((float)0, (float)0, (float)0);
	}

	public virtual void Update()
	{
		if (!this.Show)
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
		}
		else
		{
			if (this.ClubLeader)
			{
				this.Interaction.localScale = Vector3.Lerp(this.Interaction.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.Favors.localScale = Vector3.Lerp(this.Favors.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.Club.localScale = Vector3.Lerp(this.Club.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			}
			else if (!this.AskingFavor)
			{
				this.Interaction.localScale = Vector3.Lerp(this.Interaction.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				this.Favors.localScale = Vector3.Lerp(this.Favors.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.Club.localScale = Vector3.Lerp(this.Club.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			}
			else
			{
				this.Interaction.localScale = Vector3.Lerp(this.Interaction.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.Favors.localScale = Vector3.Lerp(this.Favors.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				this.Club.localScale = Vector3.Lerp(this.Club.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			}
			this.MouseDelta.x = this.MouseDelta.x + Input.GetAxis("Mouse X");
			this.MouseDelta.y = this.MouseDelta.y + Input.GetAxis("Mouse Y");
			if (this.MouseDelta.x > (float)11)
			{
				this.MouseDelta.x = (float)11;
			}
			else if (this.MouseDelta.x < (float)-11)
			{
				this.MouseDelta.x = (float)-11;
			}
			if (this.MouseDelta.y > (float)11)
			{
				this.MouseDelta.y = (float)11;
			}
			else if (this.MouseDelta.y < (float)-11)
			{
				this.MouseDelta.y = (float)-11;
			}
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			if (!this.AskingFavor)
			{
				if (Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f)
				{
					this.Selected = 0;
				}
				if ((Input.GetAxis("Vertical") > 0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (this.MouseDelta.y > (float)10 && this.MouseDelta.x < (float)10 && this.MouseDelta.x > (float)-10))
				{
					this.Selected = 1;
				}
				if ((Input.GetAxis("Vertical") > (float)0 && Input.GetAxis("Horizontal") > 0.5f) || (this.MouseDelta.y > (float)0 && this.MouseDelta.x > (float)10))
				{
					this.Selected = 2;
				}
				if ((Input.GetAxis("Vertical") < (float)0 && Input.GetAxis("Horizontal") > 0.5f) || (this.MouseDelta.y < (float)0 && this.MouseDelta.x > (float)10))
				{
					this.Selected = 3;
				}
				if ((Input.GetAxis("Vertical") < -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (this.MouseDelta.y < (float)-10 && this.MouseDelta.x < (float)10 && this.MouseDelta.x > (float)-10))
				{
					this.Selected = 4;
				}
				if ((Input.GetAxis("Vertical") < (float)0 && Input.GetAxis("Horizontal") < -0.5f) || (this.MouseDelta.y < (float)0 && this.MouseDelta.x < (float)-10))
				{
					this.Selected = 5;
				}
				if ((Input.GetAxis("Vertical") > (float)0 && Input.GetAxis("Horizontal") < -0.5f) || (this.MouseDelta.y > (float)0 && this.MouseDelta.x < (float)-10))
				{
					this.Selected = 6;
				}
				if (!this.ClubLeader)
				{
					this.CenterLabel.text = this.Text[this.Selected];
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
				if ((Input.GetAxis("Vertical") > 0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (this.MouseDelta.y > (float)10 && this.MouseDelta.x < (float)10 && this.MouseDelta.x > (float)-10))
				{
					this.Selected = 1;
				}
				if ((Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") > 0.5f) || (this.MouseDelta.y < (float)10 && this.MouseDelta.y > (float)-10 && this.MouseDelta.x > (float)10))
				{
					this.Selected = 2;
				}
				if ((Input.GetAxis("Vertical") < -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (this.MouseDelta.y < (float)-10 && this.MouseDelta.x < (float)10 && this.MouseDelta.x > (float)-10))
				{
					this.Selected = 3;
				}
				if ((Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") < -0.5f) || (this.MouseDelta.y < (float)10 && this.MouseDelta.y > (float)-10 && this.MouseDelta.x < (float)-10))
				{
					this.Selected = 4;
				}
				if (this.Selected < this.FavorText.Length)
				{
					this.CenterLabel.text = this.FavorText[this.Selected];
				}
			}
			if (!this.ClubLeader)
			{
				for (int i = 1; i < 7; i++)
				{
					if (this.Selected == i)
					{
						this.Segment[i].transform.localScale = Vector3.Lerp(this.Segment[i].transform.localScale, new Vector3(1.3f, 1.3f, (float)1), Time.deltaTime * (float)10);
					}
					else
					{
						this.Segment[i].transform.localScale = Vector3.Lerp(this.Segment[i].transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
					}
				}
			}
			else
			{
				for (int i = 1; i < 7; i++)
				{
					if (this.Selected == i)
					{
						this.ClubSegment[i].transform.localScale = Vector3.Lerp(this.ClubSegment[i].transform.localScale, new Vector3(1.3f, 1.3f, (float)1), Time.deltaTime * (float)10);
					}
					else
					{
						this.ClubSegment[i].transform.localScale = Vector3.Lerp(this.ClubSegment[i].transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
					}
				}
			}
			for (int i = 1; i < 5; i++)
			{
				if (this.Selected == i)
				{
					this.FavorSegment[i].transform.localScale = Vector3.Lerp(this.FavorSegment[i].transform.localScale, new Vector3(1.3f, 1.3f, (float)1), Time.deltaTime * (float)10);
				}
				else
				{
					this.FavorSegment[i].transform.localScale = Vector3.Lerp(this.FavorSegment[i].transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				}
			}
			if (Input.GetButtonDown("A"))
			{
				if (this.ClubLeader)
				{
					if (this.Selected != 0 && this.ClubShadow[this.Selected].color.a == (float)0)
					{
						if (this.Selected == 1)
						{
							this.Impatience.fillAmount = (float)0;
							this.Yandere.TargetStudent.Interaction = 10;
							this.Yandere.TargetStudent.TalkTimer = (float)100;
							this.Yandere.TargetStudent.ClubPhase = 1;
							this.Show = false;
						}
						if (this.Selected == 2)
						{
							this.Impatience.fillAmount = (float)0;
							this.Yandere.TargetStudent.Interaction = 11;
							this.Yandere.TargetStudent.TalkTimer = (float)100;
							this.Show = false;
							this.ClubManager.CheckGrudge(this.Yandere.TargetStudent.Club);
							if (PlayerPrefs.GetInt("QuitClub_" + this.Yandere.TargetStudent.Club) == 1)
							{
								this.Yandere.TargetStudent.ClubPhase = 4;
							}
							else if (PlayerPrefs.GetInt("Club") != 0)
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
							this.Impatience.fillAmount = (float)0;
							this.Yandere.TargetStudent.Interaction = 12;
							this.Yandere.TargetStudent.TalkTimer = (float)100;
							this.Yandere.TargetStudent.ClubPhase = 1;
							this.Show = false;
						}
						if (this.Selected == 4)
						{
							this.Impatience.fillAmount = (float)0;
							this.Yandere.TargetStudent.Interaction = 13;
							this.Yandere.TargetStudent.TalkTimer = this.Yandere.Subtitle.ClubFarewellClips[this.Yandere.TargetStudent.Club].length;
							this.Show = false;
						}
						if (this.Selected == 5)
						{
							this.Impatience.fillAmount = (float)0;
							this.Yandere.TargetStudent.Interaction = 14;
							this.Yandere.TargetStudent.TalkTimer = (float)100;
							if (this.Clock.HourTime < (float)17)
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
				else if (!this.AskingFavor)
				{
					if (this.Selected != 0 && this.Shadow[this.Selected].color.a == (float)0)
					{
						if (this.Selected == 1)
						{
							this.Impatience.fillAmount = (float)0;
							this.Yandere.Interaction = 1;
							this.Yandere.TalkTimer = (float)3;
							this.Show = false;
						}
						if (this.Selected == 2)
						{
							this.Impatience.fillAmount = (float)0;
							this.Yandere.Interaction = 2;
							this.Yandere.TalkTimer = (float)3;
							this.Show = false;
						}
						if (this.Selected == 3)
						{
							this.PauseScreen.StudentInfoMenu.Gossiping = true;
							this.PauseScreen.StudentInfoMenu.gameObject.active = true;
							this.PauseScreen.StudentInfoMenu.Column = 0;
							this.PauseScreen.StudentInfoMenu.Row = 0;
							this.PauseScreen.StudentInfoMenu.UpdateHighlight();
							this.StartCoroutine_Auto(this.PauseScreen.StudentInfoMenu.UpdatePortraits());
							this.PauseScreen.MainMenu.active = false;
							this.PauseScreen.Sideways = true;
							this.PauseScreen.Show = true;
							Time.timeScale = (float)0;
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "View Info";
							this.PromptBar.Label[1].text = "Cancel";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
							this.Impatience.fillAmount = (float)0;
							this.Yandere.Interaction = 3;
							this.Yandere.TalkTimer = (float)3;
							this.Show = false;
						}
						if (this.Selected == 4)
						{
							this.Impatience.fillAmount = (float)0;
							this.Yandere.Interaction = 4;
							this.Yandere.TalkTimer = (float)2;
							this.Show = false;
						}
						if (this.Selected == 5)
						{
							this.CheckTaskCompletion();
							if (this.Yandere.TargetStudent.TaskPhase == 0)
							{
								this.Impatience.fillAmount = (float)0;
								this.Yandere.TargetStudent.Interaction = 5;
								this.Yandere.TargetStudent.TalkTimer = (float)100;
								this.Yandere.TargetStudent.TaskPhase = 1;
								this.Show = false;
							}
							else
							{
								this.Impatience.fillAmount = (float)0;
								this.Yandere.TargetStudent.Interaction = 5;
								this.Yandere.TargetStudent.TalkTimer = (float)100;
								this.Show = false;
							}
						}
						if (this.Selected == 6)
						{
							this.AskingFavor = true;
						}
					}
				}
				else if (this.Selected != 0)
				{
					if (this.Selected < Extensions.get_length(this.FavorShadow) && this.FavorShadow[this.Selected] != null && this.FavorShadow[this.Selected].color.a == (float)0)
					{
						if (this.Selected == 1)
						{
							this.Impatience.fillAmount = (float)0;
							this.Yandere.Interaction = 6;
							this.Yandere.TalkTimer = (float)3;
							this.Show = false;
						}
						if (this.Selected == 2)
						{
							this.Impatience.fillAmount = (float)0;
							this.Yandere.Interaction = 7;
							this.Yandere.TalkTimer = (float)3;
							this.Show = false;
						}
						if (this.Selected == 4)
						{
							this.PauseScreen.StudentInfoMenu.Distracting = true;
							this.PauseScreen.StudentInfoMenu.gameObject.active = true;
							this.PauseScreen.StudentInfoMenu.Column = 0;
							this.PauseScreen.StudentInfoMenu.Row = 0;
							this.PauseScreen.StudentInfoMenu.UpdateHighlight();
							this.StartCoroutine_Auto(this.PauseScreen.StudentInfoMenu.UpdatePortraits());
							this.PauseScreen.MainMenu.active = false;
							this.PauseScreen.Sideways = true;
							this.PauseScreen.Show = true;
							Time.timeScale = (float)0;
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[1].text = "Cancel";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
							this.Impatience.fillAmount = (float)0;
							this.Yandere.Interaction = 8;
							this.Yandere.TalkTimer = (float)3;
							this.Show = false;
						}
					}
					if (this.Selected == 3)
					{
						this.AskingFavor = false;
					}
				}
			}
		}
		this.PreviousPosition = Input.mousePosition;
	}

	public virtual void HideShadows()
	{
		this.Impatience.fillAmount = (float)0;
		for (int i = 1; i < 7; i++)
		{
			int num = 0;
			Color color = this.Shadow[i].color;
			float num2 = color.a = (float)num;
			Color color2 = this.Shadow[i].color = color;
		}
		for (int i = 1; i < 5; i++)
		{
			int num3 = 0;
			Color color3 = this.FavorShadow[i].color;
			float num4 = color3.a = (float)num3;
			Color color4 = this.FavorShadow[i].color = color3;
		}
		for (int i = 1; i < 7; i++)
		{
			int num5 = 0;
			Color color5 = this.ClubShadow[i].color;
			float num6 = color5.a = (float)num5;
			Color color6 = this.ClubShadow[i].color = color5;
		}
		if (!this.Yandere.TargetStudent.Witness || this.Yandere.TargetStudent.Forgave)
		{
			float a = 0.75f;
			Color color7 = this.Shadow[1].color;
			float num7 = color7.a = a;
			Color color8 = this.Shadow[1].color = color7;
		}
		if (this.Yandere.TargetStudent.Complimented)
		{
			float a2 = 0.75f;
			Color color9 = this.Shadow[2].color;
			float num8 = color9.a = a2;
			Color color10 = this.Shadow[2].color = color9;
		}
		if (this.Yandere.Bloodiness > (float)0 || this.Yandere.Sanity < 33.33333f)
		{
			float a3 = 0.75f;
			Color color11 = this.Shadow[3].color;
			float num9 = color11.a = a3;
			Color color12 = this.Shadow[3].color = color11;
			float a4 = 0.75f;
			Color color13 = this.Shadow[5].color;
			float num10 = color13.a = a4;
			Color color14 = this.Shadow[5].color = color13;
			float a5 = 0.75f;
			Color color15 = this.Shadow[6].color;
			float num11 = color15.a = a5;
			Color color16 = this.Shadow[6].color = color15;
		}
		else if (this.Reputation.Reputation < -33.33333f)
		{
			float a6 = 0.75f;
			Color color17 = this.Shadow[3].color;
			float num12 = color17.a = a6;
			Color color18 = this.Shadow[3].color = color17;
		}
		if (this.Yandere.TargetStudent.StudentID != 6 && this.Yandere.TargetStudent.StudentID != 7 && this.Yandere.TargetStudent.StudentID != 32)
		{
			float a7 = 0.75f;
			Color color19 = this.Shadow[5].color;
			float num13 = color19.a = a7;
			Color color20 = this.Shadow[5].color = color19;
		}
		else
		{
			if (PlayerPrefs.GetInt("Task_" + this.Yandere.TargetStudent.StudentID + "_Status") != 0 && PlayerPrefs.GetInt("Task_" + this.Yandere.TargetStudent.StudentID + "_Status") != 2)
			{
				float a8 = 0.75f;
				Color color21 = this.Shadow[5].color;
				float num14 = color21.a = a8;
				Color color22 = this.Shadow[5].color = color21;
			}
			if (this.Yandere.TargetStudent.StudentID == 32)
			{
				if (this.Clock.Period != 3)
				{
					float a9 = 0.75f;
					Color color23 = this.Shadow[5].color;
					float num15 = color23.a = a9;
					Color color24 = this.Shadow[5].color = color23;
				}
				else if (PlayerPrefs.GetInt("Task_32_Status") == 1 && this.Yandere.Inventory.Cigs)
				{
					int num16 = 0;
					Color color25 = this.Shadow[5].color;
					float num17 = color25.a = (float)num16;
					Color color26 = this.Shadow[5].color = color25;
				}
			}
		}
		if (PlayerPrefs.GetInt("Task_" + this.Yandere.TargetStudent.StudentID + "_Status") < 3)
		{
			float a10 = 0.75f;
			Color color27 = this.Shadow[6].color;
			float num18 = color27.a = a10;
			Color color28 = this.Shadow[6].color = color27;
		}
		if ((this.Yandere.TargetStudent.Male && PlayerPrefs.GetInt("Seduction") + PlayerPrefs.GetInt("SeductionBonus") > 3) || PlayerPrefs.GetInt("Seduction") + PlayerPrefs.GetInt("SeductionBonus") > 4)
		{
			int num19 = 0;
			Color color29 = this.Shadow[6].color;
			float num20 = color29.a = (float)num19;
			Color color30 = this.Shadow[6].color = color29;
		}
		float a11 = 0.75f;
		Color color31 = this.ClubShadow[6].color;
		float num21 = color31.a = a11;
		Color color32 = this.ClubShadow[6].color = color31;
		if (PlayerPrefs.GetInt("Club") == this.Yandere.TargetStudent.Club)
		{
			float a12 = 0.75f;
			Color color33 = this.ClubShadow[1].color;
			float num22 = color33.a = a12;
			Color color34 = this.ClubShadow[1].color = color33;
			float a13 = 0.75f;
			Color color35 = this.ClubShadow[2].color;
			float num23 = color35.a = a13;
			Color color36 = this.ClubShadow[2].color = color35;
		}
		if (this.Yandere.ClubAttire || this.Yandere.Mask != null || this.Yandere.Gloves != null || this.Yandere.Container != null)
		{
			float a14 = 0.75f;
			Color color37 = this.ClubShadow[3].color;
			float num24 = color37.a = a14;
			Color color38 = this.ClubShadow[3].color = color37;
		}
		if (PlayerPrefs.GetInt("Club") != this.Yandere.TargetStudent.Club)
		{
			float a15 = 0.75f;
			Color color39 = this.ClubShadow[3].color;
			float num25 = color39.a = a15;
			Color color40 = this.ClubShadow[3].color = color39;
			float a16 = 0.75f;
			Color color41 = this.ClubShadow[5].color;
			float num26 = color41.a = a16;
			Color color42 = this.ClubShadow[5].color = color41;
		}
		if (this.Yandere.Followers > 0)
		{
			float a17 = 0.75f;
			Color color43 = this.FavorShadow[1].color;
			float num27 = color43.a = a17;
			Color color44 = this.FavorShadow[1].color = color43;
		}
		if (this.Yandere.TargetStudent.DistanceToDestination > 0.5f)
		{
			float a18 = 0.75f;
			Color color45 = this.FavorShadow[2].color;
			float num28 = color45.a = a18;
			Color color46 = this.FavorShadow[2].color = color45;
		}
	}

	public virtual void CheckTaskCompletion()
	{
		if (PlayerPrefs.GetInt("Task_" + this.Yandere.TargetStudent.StudentID + "_Satus") == 2 && this.Yandere.TargetStudent.StudentID == 32)
		{
			this.Yandere.TargetStudent.TaskPhase = this.Yandere.TargetStudent.TaskPhase + 1;
			this.Yandere.Inventory.Cigs = false;
		}
	}

	public virtual void End()
	{
		if (this.Yandere.TargetStudent != null)
		{
			this.Yandere.TargetStudent.Interaction = 0;
			this.Yandere.TargetStudent.WaitTimer = (float)1;
			this.Yandere.TargetStudent.ShoulderCamera.OverShoulder = false;
			this.Yandere.TargetStudent.Waiting = true;
			this.Yandere.TargetStudent = null;
		}
		this.Yandere.Subtitle.Label.text = string.Empty;
		this.AskingFavor = false;
		this.ClubLeader = false;
		this.Show = false;
	}

	public virtual void Main()
	{
	}
}
