using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class DatingMinigameScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public LoveManagerScript LoveManager;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public StudentScript Suitor;

	public StudentScript Rival;

	public PromptScript Prompt;

	public JsonScript JSON;

	public Transform AffectionSet;

	public Transform OptionSet;

	public GameObject HeartbeatCamera;

	public GameObject SeductionIcon;

	public GameObject PantyIcon;

	public Transform TopicHighlight;

	public Transform ComplimentSet;

	public Transform AffectionBar;

	public Transform Highlight;

	public Transform GiveGift;

	public Transform PeekSpot;

	public Transform[] Options;

	public Transform ShowOff;

	public Transform Topics;

	public Texture X;

	public UITexture[] MultiplierIcons;

	public UILabel[] ComplimentLabels;

	public UISprite[] ComplimentBGs;

	public UILabel MultiplierLabel;

	public UILabel SeductionLabel;

	public UILabel TopicNameLabel;

	public UILabel DialogueLabel;

	public UISprite[] TopicIcons;

	public UIPanel DatingSimHUD;

	public UILabel WisdomLabel;

	public UISprite[] TraitBGs;

	public UISprite[] GiftBGs;

	public UITexture RoseIcon;

	public UILabel[] Labels;

	public UIPanel Panel;

	public string[] Compliments;

	public string[] TopicNames;

	public string[] GiveGifts;

	public string[] Greetings;

	public string[] Farewells;

	public string[] Negatives;

	public string[] Positives;

	public string[] ShowOffs;

	public bool SelectingTopic;

	public bool AffectionGrow;

	public bool Complimenting;

	public bool Matchmaking;

	public bool GivingGift;

	public bool ShowingOff;

	public bool Negative;

	public bool SlideOut;

	public bool Testing;

	public float HighlightTarget;

	public float Affection;

	public float Rotation;

	public float Speed;

	public float Timer;

	public int ComplimentSelected;

	public int TraitSelected;

	public int TopicSelected;

	public int GiftSelected;

	public int Selected;

	public int AffectionLevel;

	public int Multiplier;

	public int Opinion;

	public int Phase;

	public int GiftColumn;

	public int GiftRow;

	public int Column;

	public int Row;

	public int Side;

	public int Line;

	public string CurrentAnim;

	public Color OriginalColor;

	public DatingMinigameScript()
	{
		this.ComplimentSelected = 1;
		this.TraitSelected = 1;
		this.TopicSelected = 1;
		this.GiftSelected = 1;
		this.Selected = 1;
		this.Phase = 1;
		this.GiftColumn = 1;
		this.GiftRow = 1;
		this.Column = 1;
		this.Row = 1;
		this.Side = 1;
		this.Line = 1;
		this.CurrentAnim = string.Empty;
	}

	public virtual void Start()
	{
		this.Affection = PlayerPrefs.GetFloat("Affection");
		float x = this.Affection / 100f;
		Vector3 localScale = this.AffectionBar.localScale;
		float num = localScale.x = x;
		Vector3 vector = this.AffectionBar.localScale = localScale;
		this.CalculateAffection();
		this.OriginalColor = this.ComplimentBGs[1].color;
		this.ComplimentSet.localScale = new Vector3((float)0, (float)0, (float)0);
		this.GiveGift.localScale = new Vector3((float)0, (float)0, (float)0);
		this.ShowOff.localScale = new Vector3((float)0, (float)0, (float)0);
		this.Topics.localScale = new Vector3((float)0, (float)0, (float)0);
		this.DatingSimHUD.active = false;
		this.DatingSimHUD.alpha = (float)0;
		this.Panel.alpha = (float)1;
		for (int i = 1; i < 26; i++)
		{
			if (PlayerPrefs.GetInt("Topic_" + i + "_Discussed") == 1)
			{
				float a = 0.5f;
				Color color = this.TopicIcons[i].color;
				float num2 = color.a = a;
				Color color2 = this.TopicIcons[i].color = color;
			}
		}
		for (int i = 1; i < 11; i++)
		{
			if (PlayerPrefs.GetInt("Compliment_" + i + "_Given") == 1)
			{
				float a2 = 0.5f;
				Color color3 = this.ComplimentLabels[i].color;
				float num3 = color3.a = a2;
				Color color4 = this.ComplimentLabels[i].color = color3;
			}
		}
		this.UpdateComplimentHighlight();
		this.UpdateTraitHighlight();
		this.UpdateGiftHighlight();
	}

	public virtual void CalculateAffection()
	{
		if (this.Affection == (float)0)
		{
			this.AffectionLevel = 0;
		}
		else if (this.Affection < (float)25)
		{
			this.AffectionLevel = 1;
		}
		else if (this.Affection < (float)50)
		{
			this.AffectionLevel = 2;
		}
		else if (this.Affection < (float)75)
		{
			this.AffectionLevel = 3;
		}
		else if (this.Affection < (float)100)
		{
			this.AffectionLevel = 4;
		}
		else
		{
			this.AffectionLevel = 5;
		}
	}

	public virtual void Update()
	{
		if (this.Testing)
		{
			this.Prompt.enabled = true;
		}
		else if (this.LoveManager.RivalWaiting)
		{
			if (this.Rival == null)
			{
				this.Suitor = this.StudentManager.Students[13];
				this.Rival = this.StudentManager.Students[7];
			}
			if (this.Rival.MeetTimer > (float)0 && this.Suitor.MeetTimer > (float)0)
			{
				this.Prompt.enabled = true;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Suitor.enabled = false;
			this.Rival.enabled = false;
			this.Rival.Character.animation["f02_smile_00"].layer = 1;
			this.Rival.Character.animation.Play("f02_smile_00");
			this.Rival.Character.animation["f02_smile_00"].weight = (float)0;
			this.StudentManager.Clock.StopTime = true;
			this.Yandere.RPGCamera.enabled = false;
			this.HeartbeatCamera.active = false;
			this.Yandere.Headset.active = true;
			this.Yandere.CanMove = false;
			this.Yandere.transform.position = this.PeekSpot.position;
			this.Yandere.transform.eulerAngles = this.PeekSpot.eulerAngles;
			this.Yandere.Character.animation.Play("f02_treePeeking_00");
			Camera.main.transform.position = new Vector3((float)48, (float)3, (float)-44);
			Camera.main.transform.eulerAngles = new Vector3((float)15, (float)90, (float)0);
			this.WisdomLabel.text = "Wisdom: " + PlayerPrefs.GetInt("SuitorTrait2");
			if (!this.Suitor.Rose)
			{
				this.RoseIcon.enabled = false;
			}
			this.Matchmaking = true;
			this.UpdateTopics();
		}
		if (this.Matchmaking)
		{
			if (this.CurrentAnim != string.Empty && this.Rival.Character.animation[this.CurrentAnim].time >= this.Rival.Character.animation[this.CurrentAnim].length)
			{
				this.Rival.Character.animation.Play(this.Rival.IdleAnim);
			}
			if (this.Phase == 1)
			{
				this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, (float)0, Time.deltaTime);
				this.Timer += Time.deltaTime;
				Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3((float)54, 1.25f, -45.25f), this.Timer * 0.02f);
				Camera.main.transform.eulerAngles = Vector3.Lerp(Camera.main.transform.eulerAngles, new Vector3((float)0, (float)45, (float)0), this.Timer * 0.02f);
				if (this.Timer > (float)5)
				{
					this.Suitor.Character.animation.Play("insertEarpiece_00");
					this.Suitor.Character.animation["insertEarpiece_00"].time = (float)0;
					this.Suitor.Character.animation.Play("insertEarpiece_00");
					this.Suitor.Earpiece.active = true;
					Camera.main.transform.position = new Vector3(45.5f, 1.25f, -44.5f);
					Camera.main.transform.eulerAngles = new Vector3((float)0, (float)-45, (float)0);
					this.Rotation = (float)-45;
					this.Timer = (float)0;
					this.Phase++;
				}
			}
			else if (this.Phase == 2)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)4)
				{
					this.Suitor.Earpiece.transform.parent = this.Suitor.Head;
					this.Suitor.Earpiece.transform.localPosition = new Vector3((float)0, -1.12f, 1.14f);
					this.Suitor.Earpiece.transform.localEulerAngles = new Vector3((float)45, (float)-180, (float)0);
					Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(45.11f, 1.375f, (float)-44), (this.Timer - (float)4) * 0.02f);
					this.Rotation = Mathf.Lerp(this.Rotation, (float)90, (this.Timer - (float)4) * 0.02f);
					float rotation = this.Rotation;
					Vector3 eulerAngles = Camera.main.transform.eulerAngles;
					float num = eulerAngles.y = rotation;
					Vector3 vector = Camera.main.transform.eulerAngles = eulerAngles;
					if (this.Rotation > 89.9f)
					{
						this.Rival.Character.animation["f02_turnAround_00"].time = (float)0;
						this.Rival.Character.animation.CrossFade("f02_turnAround_00");
						float x = this.Affection / (float)100;
						Vector3 localScale = this.AffectionBar.localScale;
						float num2 = localScale.x = x;
						Vector3 vector2 = this.AffectionBar.localScale = localScale;
						this.DialogueLabel.text = this.Greetings[this.AffectionLevel];
						this.CalculateMultiplier();
						this.DatingSimHUD.active = true;
						this.Timer = (float)0;
						this.Phase++;
					}
				}
			}
			else if (this.Phase == 3)
			{
				this.DatingSimHUD.alpha = Mathf.MoveTowards(this.DatingSimHUD.alpha, (float)1, Time.deltaTime);
				if (this.Rival.Character.animation["f02_turnAround_00"].time >= this.Rival.Character.animation["f02_turnAround_00"].length)
				{
					int num3 = -90;
					Vector3 eulerAngles2 = this.Rival.transform.eulerAngles;
					float num4 = eulerAngles2.y = (float)num3;
					Vector3 vector3 = this.Rival.transform.eulerAngles = eulerAngles2;
					this.Rival.Character.animation.Play("f02_turnAround_00");
					this.Rival.Character.animation["f02_turnAround_00"].time = (float)0;
					this.Rival.Character.animation["f02_turnAround_00"].speed = (float)0;
					this.Rival.Character.animation.Play("f02_turnAround_00");
					this.Rival.Character.animation.CrossFade(this.Rival.IdleAnim);
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Confirm";
					this.PromptBar.Label[1].text = "Back";
					this.PromptBar.Label[4].text = "Select";
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				if (this.AffectionGrow)
				{
					this.Affection = Mathf.MoveTowards(this.Affection, (float)100, Time.deltaTime * (float)10);
					this.CalculateAffection();
				}
				this.Rival.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", this.Affection * 0.01f);
				this.Rival.CharacterAnimation["f02_smile_00"].weight = this.Affection * 0.01f;
				float y = Mathf.Lerp(this.Highlight.localPosition.y, this.HighlightTarget, Time.deltaTime * (float)10);
				Vector3 localPosition = this.Highlight.localPosition;
				float num5 = localPosition.y = y;
				Vector3 vector4 = this.Highlight.localPosition = localPosition;
				for (int i = 1; i < Extensions.get_length(this.Options); i++)
				{
					if (i == this.Selected)
					{
						float x2 = Mathf.Lerp(this.Options[i].localPosition.x, (float)750, Time.deltaTime * (float)10);
						Vector3 localPosition2 = this.Options[i].localPosition;
						float num6 = localPosition2.x = x2;
						Vector3 vector5 = this.Options[i].localPosition = localPosition2;
					}
					else
					{
						float x3 = Mathf.Lerp(this.Options[i].localPosition.x, (float)800, Time.deltaTime * (float)10);
						Vector3 localPosition3 = this.Options[i].localPosition;
						float num7 = localPosition3.x = x3;
						Vector3 vector6 = this.Options[i].localPosition = localPosition3;
					}
				}
				float x4 = Mathf.Lerp(this.AffectionBar.localScale.x, this.Affection / 100f, Time.deltaTime * (float)10);
				Vector3 localScale2 = this.AffectionBar.localScale;
				float num8 = localScale2.x = x4;
				Vector3 vector7 = this.AffectionBar.localScale = localScale2;
				if (!this.SelectingTopic && !this.Complimenting && !this.ShowingOff && !this.GivingGift)
				{
					this.Topics.localScale = Vector3.Lerp(this.Topics.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
					this.ComplimentSet.localScale = Vector3.Lerp(this.ComplimentSet.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
					this.ShowOff.localScale = Vector3.Lerp(this.ShowOff.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
					this.GiveGift.localScale = Vector3.Lerp(this.GiveGift.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
					if (this.InputManager.TappedUp)
					{
						this.Selected--;
						this.UpdateHighlight();
					}
					if (this.InputManager.TappedDown)
					{
						this.Selected++;
						this.UpdateHighlight();
					}
					if (Input.GetButtonDown("A") && this.Labels[this.Selected].color.a == (float)1)
					{
						if (this.Selected == 1)
						{
							this.SelectingTopic = true;
							this.Negative = true;
						}
						else if (this.Selected == 2)
						{
							this.SelectingTopic = true;
							this.Negative = false;
						}
						else if (this.Selected == 3)
						{
							this.Complimenting = true;
						}
						else if (this.Selected == 4)
						{
							this.ShowingOff = true;
						}
						else if (this.Selected == 5)
						{
							this.GivingGift = true;
						}
						else if (this.Selected == 6)
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Confirm";
							this.PromptBar.UpdateButtons();
							this.CalculateAffection();
							this.DialogueLabel.text = this.Farewells[this.AffectionLevel];
							this.Phase++;
						}
					}
				}
				else if (this.SelectingTopic)
				{
					this.Topics.localScale = Vector3.Lerp(this.Topics.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
					if (this.InputManager.TappedUp)
					{
						this.Row--;
						this.UpdateTopicHighlight();
					}
					else if (this.InputManager.TappedDown)
					{
						this.Row++;
						this.UpdateTopicHighlight();
					}
					if (this.InputManager.TappedLeft)
					{
						this.Column--;
						this.UpdateTopicHighlight();
					}
					else if (this.InputManager.TappedRight)
					{
						this.Column++;
						this.UpdateTopicHighlight();
					}
					if (Input.GetButtonDown("A") && this.TopicIcons[this.TopicSelected].color.a == (float)1)
					{
						this.SelectingTopic = false;
						float a = 0.5f;
						Color color = this.TopicIcons[this.TopicSelected].color;
						float num9 = color.a = a;
						Color color2 = this.TopicIcons[this.TopicSelected].color = color;
						PlayerPrefs.SetInt("Topic_" + this.TopicSelected + "_Discussed", 1);
						this.DetermineOpinion();
						if (PlayerPrefs.GetInt("Topic_" + this.Opinion + "_Student_7_Learned") == 0)
						{
							PlayerPrefs.SetInt("Topic_" + this.Opinion + "_Student_7_Learned", 1);
						}
						if (this.Negative)
						{
							float a2 = 0.5f;
							Color color3 = this.Labels[1].color;
							float num10 = color3.a = a2;
							Color color4 = this.Labels[1].color = color3;
							if (this.Opinion == 2)
							{
								this.DialogueLabel.text = "Hey! Just so you know, I take offense to that...";
								this.Rival.Character.animation.CrossFade("f02_refuse_00");
								this.CurrentAnim = "f02_refuse_00";
								this.Affection -= (float)1;
								this.CalculateAffection();
							}
							else if (this.Opinion == 1)
							{
								this.DialogueLabel.text = this.Negatives[this.AffectionLevel];
								this.Rival.Character.animation.CrossFade("f02_lookdown_00");
								this.CurrentAnim = "f02_lookdown_00";
								this.Affection += (float)this.Multiplier;
								this.CalculateAffection();
							}
							else if (this.Opinion == 0)
							{
								this.DialogueLabel.text = "Um...okay.";
							}
						}
						else
						{
							float a3 = 0.5f;
							Color color5 = this.Labels[2].color;
							float num11 = color5.a = a3;
							Color color6 = this.Labels[2].color = color5;
							if (this.Opinion == 2)
							{
								this.DialogueLabel.text = this.Positives[this.AffectionLevel];
								this.Rival.Character.animation.CrossFade("f02_lookdown_00");
								this.CurrentAnim = "f02_lookdown_00";
								this.Affection += (float)this.Multiplier;
								this.CalculateAffection();
							}
							else if (this.Opinion == 1)
							{
								this.DialogueLabel.text = "To be honest with you, I strongly disagree...";
								this.Rival.Character.animation.CrossFade("f02_refuse_00");
								this.CurrentAnim = "f02_refuse_00";
								this.Affection -= (float)1;
								this.CalculateAffection();
							}
							else if (this.Opinion == 0)
							{
								this.DialogueLabel.text = "Um...all right.";
							}
						}
						if (this.Affection > (float)100)
						{
							this.Affection = (float)100;
						}
						else if (this.Affection < (float)0)
						{
							this.Affection = (float)0;
						}
					}
					if (Input.GetButtonDown("B"))
					{
						this.SelectingTopic = false;
					}
				}
				else if (this.Complimenting)
				{
					this.ComplimentSet.localScale = Vector3.Lerp(this.ComplimentSet.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
					if (this.InputManager.TappedUp)
					{
						this.Line--;
						this.UpdateComplimentHighlight();
					}
					else if (this.InputManager.TappedDown)
					{
						this.Line++;
						this.UpdateComplimentHighlight();
					}
					if (this.InputManager.TappedLeft)
					{
						this.Side--;
						this.UpdateComplimentHighlight();
					}
					else if (this.InputManager.TappedRight)
					{
						this.Side++;
						this.UpdateComplimentHighlight();
					}
					if (Input.GetButtonDown("A") && this.ComplimentLabels[this.ComplimentSelected].color.a == (float)1)
					{
						float a4 = 0.5f;
						Color color7 = this.Labels[3].color;
						float num12 = color7.a = a4;
						Color color8 = this.Labels[3].color = color7;
						this.Complimenting = false;
						this.DialogueLabel.text = this.Compliments[this.ComplimentSelected];
						PlayerPrefs.SetInt("Compliment_" + this.ComplimentSelected + "_Given", 1);
						if (this.ComplimentSelected == 1 || this.ComplimentSelected == 4 || this.ComplimentSelected == 5 || this.ComplimentSelected == 8 || this.ComplimentSelected == 9)
						{
							this.Rival.Character.animation.CrossFade("f02_lookdown_00");
							this.CurrentAnim = "f02_lookdown_00";
							this.Affection += (float)this.Multiplier;
							this.CalculateAffection();
						}
						else
						{
							this.Rival.Character.animation.CrossFade("f02_refuse_00");
							this.CurrentAnim = "f02_refuse_00";
							this.Affection -= (float)1;
							this.CalculateAffection();
						}
						if (this.Affection > (float)100)
						{
							this.Affection = (float)100;
						}
						else if (this.Affection < (float)0)
						{
							this.Affection = (float)0;
						}
					}
					if (Input.GetButtonDown("B"))
					{
						this.Complimenting = false;
					}
				}
				else if (this.ShowingOff)
				{
					this.ShowOff.localScale = Vector3.Lerp(this.ShowOff.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
					if (this.InputManager.TappedUp)
					{
						this.TraitSelected--;
						this.UpdateTraitHighlight();
					}
					else if (this.InputManager.TappedDown)
					{
						this.TraitSelected++;
						this.UpdateTraitHighlight();
					}
					if (Input.GetButtonDown("A"))
					{
						float a5 = 0.5f;
						Color color9 = this.Labels[4].color;
						float num13 = color9.a = a5;
						Color color10 = this.Labels[4].color = color9;
						this.ShowingOff = false;
						if (this.TraitSelected == 2)
						{
							if (PlayerPrefs.GetInt("SuitorTrait2") > PlayerPrefs.GetInt("Trait_2_Demonstrated"))
							{
								PlayerPrefs.SetInt("Trait_2_Demonstrated", PlayerPrefs.GetInt("Trait_2_Demonstrated") + 1);
								this.DialogueLabel.text = this.ShowOffs[this.AffectionLevel];
								this.Rival.Character.animation.CrossFade("f02_lookdown_00");
								this.CurrentAnim = "f02_lookdown_00";
								this.Affection += (float)this.Multiplier;
								this.CalculateAffection();
							}
							else
							{
								this.DialogueLabel.text = "Uh...you already told me about that...";
							}
						}
						else
						{
							this.DialogueLabel.text = "Um...well...that sort of thing doesn't really matter to me...";
						}
						if (this.Affection > (float)100)
						{
							this.Affection = (float)100;
						}
						else if (this.Affection < (float)0)
						{
							this.Affection = (float)0;
						}
					}
					if (Input.GetButtonDown("B"))
					{
						this.ShowingOff = false;
					}
				}
				else if (this.GivingGift)
				{
					this.GiveGift.localScale = Vector3.Lerp(this.GiveGift.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
					if (this.InputManager.TappedUp)
					{
						this.GiftRow--;
						this.UpdateGiftHighlight();
					}
					else if (this.InputManager.TappedDown)
					{
						this.GiftRow++;
						this.UpdateGiftHighlight();
					}
					if (this.InputManager.TappedLeft)
					{
						this.GiftColumn--;
						this.UpdateGiftHighlight();
					}
					else if (this.InputManager.TappedRight)
					{
						this.GiftColumn++;
						this.UpdateGiftHighlight();
					}
					if (Input.GetButtonDown("A"))
					{
						if (this.GiftSelected == 1 && this.RoseIcon.enabled)
						{
							float a6 = 0.5f;
							Color color11 = this.Labels[5].color;
							float num14 = color11.a = a6;
							Color color12 = this.Labels[5].color = color11;
							this.GivingGift = false;
							this.DialogueLabel.text = this.GiveGifts[this.AffectionLevel];
							this.Rival.Character.animation.CrossFade("f02_lookdown_00");
							this.CurrentAnim = "f02_lookdown_00";
							this.Affection += (float)this.Multiplier;
							this.CalculateAffection();
						}
						if (this.Affection > (float)100)
						{
							this.Affection = (float)100;
						}
						else if (this.Affection < (float)0)
						{
							this.Affection = (float)0;
						}
					}
					if (Input.GetButtonDown("B"))
					{
						this.GivingGift = false;
					}
				}
			}
			else if (this.Phase == 5)
			{
				this.Speed += Time.deltaTime * (float)100;
				float y2 = this.AffectionSet.localPosition.y + this.Speed;
				Vector3 localPosition4 = this.AffectionSet.localPosition;
				float num15 = localPosition4.y = y2;
				Vector3 vector8 = this.AffectionSet.localPosition = localPosition4;
				float x5 = this.OptionSet.localPosition.x + this.Speed;
				Vector3 localPosition5 = this.OptionSet.localPosition;
				float num16 = localPosition5.x = x5;
				Vector3 vector9 = this.OptionSet.localPosition = localPosition5;
				if (this.Speed > (float)100 && Input.GetButtonDown("A"))
				{
					this.Phase++;
				}
			}
			else if (this.Phase == 6)
			{
				this.DatingSimHUD.alpha = Mathf.MoveTowards(this.DatingSimHUD.alpha, (float)0, Time.deltaTime);
				if (this.DatingSimHUD.alpha == (float)0)
				{
					this.DatingSimHUD.active = false;
					this.Phase++;
				}
			}
			else if (this.Phase == 7)
			{
				if (this.Panel.alpha == (float)0)
				{
					this.LoveManager.RivalWaiting = false;
					this.LoveManager.Courted = true;
					this.Suitor.enabled = true;
					this.Rival.enabled = true;
					this.Suitor.CurrentDestination = this.Suitor.Destinations[this.Suitor.Phase];
					this.Suitor.Pathfinding.target = this.Suitor.Destinations[this.Suitor.Phase];
					this.Suitor.Prompt.Label[0].text = "     Talk";
					this.Suitor.Pathfinding.canSearch = true;
					this.Suitor.Pathfinding.canMove = true;
					this.Suitor.Pushable = false;
					this.Suitor.Meeting = false;
					this.Suitor.Routine = true;
					this.Suitor.MeetTimer = (float)0;
					this.Rival.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", (float)0);
					this.Rival.CurrentDestination = this.Rival.Destinations[this.Rival.Phase];
					this.Rival.Pathfinding.target = this.Rival.Destinations[this.Rival.Phase];
					this.Rival.CharacterAnimation["f02_smile_00"].weight = (float)0;
					this.Rival.Prompt.Label[0].text = "     Talk";
					this.Rival.Pathfinding.canSearch = true;
					this.Rival.Pathfinding.canMove = true;
					this.Rival.Pushable = false;
					this.Rival.Meeting = false;
					this.Rival.Routine = true;
					this.Rival.MeetTimer = (float)0;
					this.StudentManager.Clock.StopTime = false;
					this.Yandere.RPGCamera.enabled = true;
					this.Suitor.Earpiece.active = false;
					this.HeartbeatCamera.active = true;
					this.Yandere.Headset.active = false;
					PlayerPrefs.SetFloat("Affection", this.Affection);
					this.PromptBar.ClearButtons();
					this.PromptBar.Show = false;
				}
				else if (this.Panel.alpha == (float)1)
				{
					this.Matchmaking = false;
					this.Yandere.CanMove = true;
					this.gameObject.active = false;
				}
				this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, (float)1, Time.deltaTime);
			}
		}
	}

	public virtual void LateUpdate()
	{
		if (this.Phase == 4)
		{
		}
	}

	public virtual void CalculateMultiplier()
	{
		this.Multiplier = 5;
		if (!this.Suitor.Cosmetic.Eyewear[6].active)
		{
			this.MultiplierIcons[1].mainTexture = this.X;
			this.Multiplier--;
		}
		if (!this.Suitor.Cosmetic.MaleAccessories[3].active)
		{
			this.MultiplierIcons[2].mainTexture = this.X;
			this.Multiplier--;
		}
		if (!this.Suitor.Cosmetic.MaleHair[22].active)
		{
			this.MultiplierIcons[3].mainTexture = this.X;
			this.Multiplier--;
		}
		if (this.Suitor.Cosmetic.HairColor != "Purple")
		{
			this.MultiplierIcons[4].mainTexture = this.X;
			this.Multiplier--;
		}
		if (PlayerPrefs.GetInt("PantiesEquipped") == 2)
		{
			this.PantyIcon.active = true;
			this.Multiplier++;
		}
		else
		{
			this.PantyIcon.active = false;
		}
		if (PlayerPrefs.GetInt("Seduction") + PlayerPrefs.GetInt("SeductionBonus") > 0)
		{
			this.SeductionLabel.text = string.Empty + (PlayerPrefs.GetInt("Seduction") + PlayerPrefs.GetInt("SeductionBonus"));
			this.Multiplier += PlayerPrefs.GetInt("Seduction") + PlayerPrefs.GetInt("SeductionBonus");
			this.SeductionIcon.active = true;
		}
		else
		{
			this.SeductionIcon.active = false;
		}
		this.MultiplierLabel.text = "Multiplier: " + this.Multiplier + "x";
	}

	public virtual void UpdateHighlight()
	{
		if (this.Selected < 1)
		{
			this.Selected = 6;
		}
		else if (this.Selected > 6)
		{
			this.Selected = 1;
		}
		this.HighlightTarget = (float)(450 - 100 * this.Selected);
	}

	public virtual void UpdateTopicHighlight()
	{
		if (this.Row < 1)
		{
			this.Row = 5;
		}
		else if (this.Row > 5)
		{
			this.Row = 1;
		}
		if (this.Column < 1)
		{
			this.Column = 5;
		}
		else if (this.Column > 5)
		{
			this.Column = 1;
		}
		int num = 375 - 125 * this.Row;
		Vector3 localPosition = this.TopicHighlight.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.TopicHighlight.localPosition = localPosition;
		int num3 = -375 + 125 * this.Column;
		Vector3 localPosition2 = this.TopicHighlight.localPosition;
		float num4 = localPosition2.x = (float)num3;
		Vector3 vector2 = this.TopicHighlight.localPosition = localPosition2;
		this.TopicSelected = (this.Row - 1) * 5 + this.Column;
		if (PlayerPrefs.GetInt("Topic_" + this.TopicSelected + "_Discovered") == 1)
		{
			this.TopicNameLabel.text = this.TopicNames[this.TopicSelected];
		}
		else
		{
			this.TopicNameLabel.text = "??????????";
		}
	}

	public virtual void DetermineOpinion()
	{
		if (this.TopicSelected == 1)
		{
			this.Opinion = this.JSON.Topic1[7];
		}
		else if (this.TopicSelected == 2)
		{
			this.Opinion = this.JSON.Topic2[7];
		}
		else if (this.TopicSelected == 3)
		{
			this.Opinion = this.JSON.Topic3[7];
		}
		else if (this.TopicSelected == 4)
		{
			this.Opinion = this.JSON.Topic4[7];
		}
		else if (this.TopicSelected == 5)
		{
			this.Opinion = this.JSON.Topic5[7];
		}
		else if (this.TopicSelected == 6)
		{
			this.Opinion = this.JSON.Topic6[7];
		}
		else if (this.TopicSelected == 7)
		{
			this.Opinion = this.JSON.Topic7[7];
		}
		else if (this.TopicSelected == 8)
		{
			this.Opinion = this.JSON.Topic8[7];
		}
		else if (this.TopicSelected == 9)
		{
			this.Opinion = this.JSON.Topic9[7];
		}
		else if (this.TopicSelected == 10)
		{
			this.Opinion = this.JSON.Topic10[7];
		}
		else if (this.TopicSelected == 11)
		{
			this.Opinion = this.JSON.Topic11[7];
		}
		else if (this.TopicSelected == 12)
		{
			this.Opinion = this.JSON.Topic12[7];
		}
		else if (this.TopicSelected == 13)
		{
			this.Opinion = this.JSON.Topic13[7];
		}
		else if (this.TopicSelected == 14)
		{
			this.Opinion = this.JSON.Topic14[7];
		}
		else if (this.TopicSelected == 15)
		{
			this.Opinion = this.JSON.Topic15[7];
		}
		else if (this.TopicSelected == 16)
		{
			this.Opinion = this.JSON.Topic16[7];
		}
		else if (this.TopicSelected == 17)
		{
			this.Opinion = this.JSON.Topic17[7];
		}
		else if (this.TopicSelected == 18)
		{
			this.Opinion = this.JSON.Topic18[7];
		}
		else if (this.TopicSelected == 19)
		{
			this.Opinion = this.JSON.Topic19[7];
		}
		else if (this.TopicSelected == 20)
		{
			this.Opinion = this.JSON.Topic20[7];
		}
		else if (this.TopicSelected == 21)
		{
			this.Opinion = this.JSON.Topic21[7];
		}
		else if (this.TopicSelected == 22)
		{
			this.Opinion = this.JSON.Topic22[7];
		}
		else if (this.TopicSelected == 23)
		{
			this.Opinion = this.JSON.Topic23[7];
		}
		else if (this.TopicSelected == 24)
		{
			this.Opinion = this.JSON.Topic24[7];
		}
		else if (this.TopicSelected == 25)
		{
			this.Opinion = this.JSON.Topic25[7];
		}
	}

	public virtual void UpdateTopics()
	{
		for (int i = 1; i < Extensions.get_length(this.TopicIcons); i++)
		{
			if (PlayerPrefs.GetInt("Topic_" + i + "_Discovered") == 0)
			{
				this.TopicIcons[i].spriteName = string.Empty + 0;
				float a = 0.5f;
				Color color = this.TopicIcons[i].color;
				float num = color.a = a;
				Color color2 = this.TopicIcons[i].color = color;
			}
			else
			{
				this.TopicIcons[i].spriteName = string.Empty + i;
			}
		}
	}

	public virtual void UpdateComplimentHighlight()
	{
		for (int i = 1; i < Extensions.get_length(this.TopicIcons); i++)
		{
			this.ComplimentBGs[this.ComplimentSelected].color = this.OriginalColor;
		}
		if (this.Line < 1)
		{
			this.Line = 5;
		}
		else if (this.Line > 5)
		{
			this.Line = 1;
		}
		if (this.Side < 1)
		{
			this.Side = 2;
		}
		else if (this.Side > 2)
		{
			this.Side = 1;
		}
		this.ComplimentSelected = (this.Line - 1) * 2 + this.Side;
		this.ComplimentBGs[this.ComplimentSelected].color = Color.white;
	}

	public virtual void UpdateTraitHighlight()
	{
		if (this.TraitSelected < 1)
		{
			this.TraitSelected = 3;
		}
		else if (this.TraitSelected > 3)
		{
			this.TraitSelected = 1;
		}
		for (int i = 1; i < Extensions.get_length(this.TraitBGs); i++)
		{
			this.TraitBGs[i].color = this.OriginalColor;
		}
		this.TraitBGs[this.TraitSelected].color = Color.white;
	}

	public virtual void UpdateGiftHighlight()
	{
		for (int i = 1; i < Extensions.get_length(this.GiftBGs); i++)
		{
			this.GiftBGs[i].color = this.OriginalColor;
		}
		if (this.GiftRow < 1)
		{
			this.GiftRow = 2;
		}
		else if (this.GiftRow > 2)
		{
			this.GiftRow = 1;
		}
		if (this.GiftColumn < 1)
		{
			this.GiftColumn = 2;
		}
		else if (this.GiftColumn > 2)
		{
			this.GiftColumn = 1;
		}
		this.GiftSelected = (this.GiftRow - 1) * 2 + this.GiftColumn;
		this.GiftBGs[this.GiftSelected].color = Color.white;
	}

	public virtual void Main()
	{
	}
}
