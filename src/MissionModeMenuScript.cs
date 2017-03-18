using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class MissionModeMenuScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public JsonScript JSON;

	public UITexture CustomTargetPortrait;

	public UILabel CustomDifficultyLabel;

	public UILabel CustomPopulationLabel;

	public UILabel CustomNemesisLabel;

	public UITexture NemesisPortrait;

	public UITexture TargetPortrait;

	public UILabel LoadMissionLabel;

	public UILabel DescriptionLabel;

	public UILabel DifficultyLabel;

	public UILabel PopulationLabel;

	public UILabel NemesisLabel;

	public UILabel ErrorLabel;

	public UILabel Header;

	public UISprite Highlight;

	public UISprite Darkness;

	public Transform CustomMissionWindow;

	public Transform ObjectiveHighlight;

	public Transform LoadMissionWindow;

	public Transform MissionWindow;

	public Transform InfoChan;

	public Transform Options;

	public Transform Neck;

	public GameObject NowLoading;

	public string[] ConditionDescs;

	public int[] Conditions;

	public string[] ClothingNames;

	public string[] DisposalNames;

	public string[] WeaponNames;

	public int RequiredClothingID;

	public int RequiredDisposalID;

	public int RequiredWeaponID;

	public Transform[] CustomNemesisObjectives;

	public Transform[] NemesisObjectives;

	public UIPanel[] CustomObjectives;

	public Texture[] ConditionIcons;

	public Transform[] Objectives;

	public Transform[] Option;

	public UITexture[] Icons;

	public UILabel[] CustomDescs;

	public UILabel[] Descs;

	public Texture NemesisGraphic;

	public Texture BlankPortrait;

	public string MissionIDString;

	public string TargetName;

	public int NemesisDifficulty;

	public int CustomSelected;

	public int Difficulty;

	public int Selected;

	public int TargetID;

	public int Phase;

	public int Column;

	public int Row;

	public float Rotation;

	public float Speed;

	public float Timer;

	public AudioSource Jukebox;

	public AudioClip[] InfoLines;

	public bool[] InfoSpoke;

	public int TargetNumber;

	public int WeaponNumber;

	public int ClothingNumber;

	public int DisposalNumber;

	public int NemesisNumber;

	public int PopulationNumber;

	public int Condition5Number;

	public int Condition6Number;

	public int Condition7Number;

	public int Condition8Number;

	public int Condition9Number;

	public int Condition10Number;

	public int Condition11Number;

	public int Condition12Number;

	public int Condition13Number;

	public int Condition14Number;

	public int Condition15Number;

	public string TargetString;

	public string WeaponString;

	public string ClothingString;

	public string DisposalString;

	public string MissionID;

	public string[] ConditionString;

	public UILabel MissionIDLabel;

	public MissionModeMenuScript()
	{
		this.MissionIDString = string.Empty;
		this.TargetName = string.Empty;
		this.CustomSelected = 1;
		this.Difficulty = 1;
		this.Selected = 1;
		this.Column = 1;
		this.Row = 1;
		this.TargetString = string.Empty;
		this.WeaponString = string.Empty;
		this.ClothingString = string.Empty;
		this.DisposalString = string.Empty;
		this.MissionID = string.Empty;
	}

	public virtual void Start()
	{
		this.NemesisPortrait.transform.parent.localScale = new Vector3((float)0, (float)0, (float)0);
		this.CustomMissionWindow.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		this.LoadMissionWindow.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		this.MissionWindow.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		int num = -700;
		Vector3 localPosition = this.Options.transform.localPosition;
		float num2 = localPosition.x = (float)num;
		Vector3 vector = this.Options.transform.localPosition = localPosition;
		int num3 = 0;
		Color color = this.Highlight.color;
		float num4 = color.a = (float)num3;
		Color color2 = this.Highlight.color = color;
		int num5 = 1;
		Color color3 = this.Darkness.color;
		float num6 = color3.a = (float)num5;
		Color color4 = this.Darkness.color = color3;
		int num7 = 0;
		Color color5 = this.Header.color;
		float num8 = color5.a = (float)num7;
		Color color6 = this.Header.color = color5;
		Time.timeScale = (float)1;
		this.CustomDescs[2].text = this.ConditionDescs[1] + " " + this.WeaponNames[1];
		this.CustomDescs[3].text = this.ConditionDescs[2] + " " + this.ClothingNames[1];
		this.CustomDescs[4].text = this.ConditionDescs[3] + " " + this.DisposalNames[1];
		int num9 = -800;
		Vector3 localPosition2 = this.Option[1].transform.localPosition;
		float num10 = localPosition2.x = (float)num9;
		Vector3 vector2 = this.Option[1].transform.localPosition = localPosition2;
		int num11 = -800;
		Vector3 localPosition3 = this.Option[2].transform.localPosition;
		float num12 = localPosition3.x = (float)num11;
		Vector3 vector3 = this.Option[2].transform.localPosition = localPosition3;
		int num13 = -800;
		Vector3 localPosition4 = this.Option[3].transform.localPosition;
		float num14 = localPosition4.x = (float)num13;
		Vector3 vector4 = this.Option[3].transform.localPosition = localPosition4;
		int num15 = -800;
		Vector3 localPosition5 = this.Option[4].transform.localPosition;
		float num16 = localPosition5.x = (float)num15;
		Vector3 vector5 = this.Option[4].transform.localPosition = localPosition5;
		int num17 = -800;
		Vector3 localPosition6 = this.Option[5].transform.localPosition;
		float num18 = localPosition6.x = (float)num17;
		Vector3 vector6 = this.Option[5].transform.localPosition = localPosition6;
		for (int i = 1; i < Extensions.get_length(this.Objectives); i++)
		{
			this.Objectives[i].localScale = new Vector3((float)0, (float)0, (float)0);
		}
		for (int i = 1; i < Extensions.get_length(this.NemesisObjectives); i++)
		{
			this.NemesisObjectives[i].localScale = new Vector3((float)0, (float)0, (float)0);
		}
		for (int i = 1; i < Extensions.get_length(this.CustomObjectives); i++)
		{
			if (this.CustomObjectives[i] != null)
			{
				this.CustomObjectives[i].alpha = 0.5f;
			}
		}
		if (PlayerPrefs.GetInt("HighPopulation") == 0)
		{
			this.CustomPopulationLabel.text = "High School Population: Off";
			this.PopulationLabel.text = "High School Population: Off";
		}
		else
		{
			this.CustomPopulationLabel.text = "High School Population: On";
			this.PopulationLabel.text = "High School Population: On";
		}
	}

	public virtual void Update()
	{
		if (this.Phase == 1)
		{
			this.Speed += Time.deltaTime;
			float z = Mathf.Lerp(this.transform.position.z, (float)2, this.Speed * Time.deltaTime * 0.25f);
			Vector3 position = this.transform.position;
			float num = position.z = z;
			Vector3 vector = this.transform.position = position;
			float a = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime * (float)1 / (float)3);
			Color color = this.Darkness.color;
			float num2 = color.a = a;
			Color color2 = this.Darkness.color = color;
			if (this.Speed > (float)1)
			{
				float a2 = Mathf.MoveTowards(this.Header.color.a, (float)1, Time.deltaTime);
				Color color3 = this.Header.color;
				float num3 = color3.a = a2;
				Color color4 = this.Header.color = color3;
				if (this.Speed > (float)3)
				{
					if (!this.InfoSpoke[0])
					{
						this.audio.PlayOneShot(this.InfoLines[0]);
						this.InfoSpoke[0] = true;
					}
					float y = Mathf.Lerp(this.InfoChan.localEulerAngles.y, (float)180, Time.deltaTime * (this.Speed - (float)3));
					Vector3 localEulerAngles = this.InfoChan.localEulerAngles;
					float num4 = localEulerAngles.y = y;
					Vector3 vector2 = this.InfoChan.localEulerAngles = localEulerAngles;
					float x = Mathf.Lerp(this.Option[1].localPosition.x, (float)0, Time.deltaTime * (float)10);
					Vector3 localPosition = this.Option[1].localPosition;
					float num5 = localPosition.x = x;
					Vector3 vector3 = this.Option[1].localPosition = localPosition;
					if (this.Speed > 3.25f)
					{
						float x2 = Mathf.Lerp(this.Option[2].localPosition.x, (float)0, Time.deltaTime * (float)10);
						Vector3 localPosition2 = this.Option[2].localPosition;
						float num6 = localPosition2.x = x2;
						Vector3 vector4 = this.Option[2].localPosition = localPosition2;
						if (this.Speed > 3.5f)
						{
							float x3 = Mathf.Lerp(this.Option[3].localPosition.x, (float)0, Time.deltaTime * (float)10);
							Vector3 localPosition3 = this.Option[3].localPosition;
							float num7 = localPosition3.x = x3;
							Vector3 vector5 = this.Option[3].localPosition = localPosition3;
							if (this.Speed > 3.75f)
							{
								float x4 = Mathf.Lerp(this.Option[4].localPosition.x, (float)0, Time.deltaTime * (float)10);
								Vector3 localPosition4 = this.Option[4].localPosition;
								float num8 = localPosition4.x = x4;
								Vector3 vector6 = this.Option[4].localPosition = localPosition4;
								if (this.Speed > (float)4)
								{
									float x5 = Mathf.Lerp(this.Option[5].localPosition.x, (float)0, Time.deltaTime * (float)10);
									Vector3 localPosition5 = this.Option[5].localPosition;
									float num9 = localPosition5.x = x5;
									Vector3 vector7 = this.Option[5].localPosition = localPosition5;
									if (this.Speed > (float)5)
									{
										this.PromptBar.Label[0].text = "Accept";
										this.PromptBar.Label[4].text = "Choose";
										this.PromptBar.UpdateButtons();
										this.PromptBar.Show = true;
										this.Phase++;
									}
								}
							}
						}
					}
				}
			}
			if (Input.GetButtonDown("A"))
			{
				if (!this.InfoSpoke[0])
				{
					this.audio.PlayOneShot(this.InfoLines[0]);
					this.InfoSpoke[0] = true;
				}
				int num10 = 180;
				Vector3 localEulerAngles2 = this.InfoChan.localEulerAngles;
				float num11 = localEulerAngles2.y = (float)num10;
				Vector3 vector8 = this.InfoChan.localEulerAngles = localEulerAngles2;
				int num12 = 2;
				Vector3 position2 = this.transform.position;
				float num13 = position2.z = (float)num12;
				Vector3 vector9 = this.transform.position = position2;
				int num14 = 0;
				Color color5 = this.Darkness.color;
				float num15 = color5.a = (float)num14;
				Color color6 = this.Darkness.color = color5;
				int num16 = 1;
				Color color7 = this.Header.color;
				float num17 = color7.a = (float)num16;
				Color color8 = this.Header.color = color7;
				this.Rotation = (float)0;
				int num18 = 0;
				Vector3 localPosition6 = this.Option[1].localPosition;
				float num19 = localPosition6.x = (float)num18;
				Vector3 vector10 = this.Option[1].localPosition = localPosition6;
				int num20 = 0;
				Vector3 localPosition7 = this.Option[2].localPosition;
				float num21 = localPosition7.x = (float)num20;
				Vector3 vector11 = this.Option[2].localPosition = localPosition7;
				int num22 = 0;
				Vector3 localPosition8 = this.Option[3].localPosition;
				float num23 = localPosition8.x = (float)num22;
				Vector3 vector12 = this.Option[3].localPosition = localPosition8;
				int num24 = 0;
				Vector3 localPosition9 = this.Option[4].localPosition;
				float num25 = localPosition9.x = (float)num24;
				Vector3 vector13 = this.Option[4].localPosition = localPosition9;
				int num26 = 0;
				Vector3 localPosition10 = this.Option[5].localPosition;
				float num27 = localPosition10.x = (float)num26;
				Vector3 vector14 = this.Option[5].localPosition = localPosition10;
				this.PromptBar.Label[0].text = "Accept";
				this.PromptBar.Label[4].text = "Choose";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			float y2 = Mathf.Lerp(this.InfoChan.localEulerAngles.y, (float)180, Time.deltaTime * (this.Speed - (float)3));
			Vector3 localEulerAngles3 = this.InfoChan.localEulerAngles;
			float num28 = localEulerAngles3.y = y2;
			Vector3 vector15 = this.InfoChan.localEulerAngles = localEulerAngles3;
			float z2 = Mathf.Lerp(this.transform.position.z, (float)2, this.Speed * Time.deltaTime * 0.25f);
			Vector3 position3 = this.transform.position;
			float num29 = position3.z = z2;
			Vector3 vector16 = this.transform.position = position3;
			this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			float x6 = Mathf.Lerp(this.Options.localPosition.x, (float)-700, Time.deltaTime * (float)10);
			Vector3 localPosition11 = this.Options.localPosition;
			float num30 = localPosition11.x = x6;
			Vector3 vector17 = this.Options.localPosition = localPosition11;
			float z3 = Mathf.Lerp(this.transform.position.z, (float)2, this.Speed * Time.deltaTime * 0.25f);
			Vector3 position4 = this.transform.position;
			float num31 = position4.z = z3;
			Vector3 vector18 = this.transform.position = position4;
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
			float y3 = Mathf.Lerp(this.Highlight.transform.localPosition.y, (float)(150 - 50 * this.Selected), Time.deltaTime * (float)10);
			Vector3 localPosition12 = this.Highlight.transform.localPosition;
			float num32 = localPosition12.y = y3;
			Vector3 vector19 = this.Highlight.transform.localPosition = localPosition12;
			float a3 = Mathf.MoveTowards(this.Highlight.color.a, (float)1, Time.deltaTime);
			Color color9 = this.Highlight.color;
			float num33 = color9.a = a3;
			Color color10 = this.Highlight.color = color9;
			for (int i = 1; i < 6; i++)
			{
				if (i != this.Selected)
				{
					float x7 = Mathf.Lerp(this.Option[i].transform.localPosition.x, (float)0, Time.deltaTime * (float)10);
					Vector3 localPosition13 = this.Option[i].localPosition;
					float num34 = localPosition13.x = x7;
					Vector3 vector20 = this.Option[i].localPosition = localPosition13;
				}
			}
			float x8 = Mathf.Lerp(this.Option[this.Selected].transform.localPosition.x, (float)50, Time.deltaTime * (float)10);
			Vector3 localPosition14 = this.Option[this.Selected].localPosition;
			float num35 = localPosition14.x = x8;
			Vector3 vector21 = this.Option[this.Selected].localPosition = localPosition14;
			if (Input.GetButtonDown("A"))
			{
				if (!this.InfoSpoke[this.Selected])
				{
					this.audio.PlayOneShot(this.InfoLines[this.Selected]);
					this.InfoSpoke[this.Selected] = true;
				}
				if (this.Selected == 1)
				{
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Accept";
					this.PromptBar.Label[1].text = "Return";
					this.PromptBar.Label[2].text = "Generate";
					this.PromptBar.Label[3].text = "Population";
					this.PromptBar.Label[4].text = "Nemesis";
					this.PromptBar.Label[5].text = "Change Difficulty";
					this.PromptBar.UpdateButtons();
					for (int i = 1; i < Extensions.get_length(this.Conditions); i++)
					{
						this.Conditions[i] = 0;
					}
					if (this.TargetID == 0)
					{
						this.ChooseTarget();
					}
					this.RequiredClothingID = 0;
					this.RequiredDisposalID = 0;
					this.RequiredWeaponID = 0;
					this.NemesisDifficulty = 0;
					this.Difficulty = 1;
					this.UpdateNemesisDifficulty();
					this.UpdateDifficultyLabel();
					this.Phase++;
				}
				else if (this.Selected == 2)
				{
					this.Difficulty = 1;
					this.Phase = 5;
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Toggle";
					this.PromptBar.Label[1].text = "Return";
					this.PromptBar.Label[2].text = "Change";
					this.PromptBar.Label[3].text = "Population";
					this.PromptBar.Label[4].text = "Selection";
					this.PromptBar.Label[5].text = "Selection";
					this.PromptBar.UpdateButtons();
					this.CustomDescs[2].text = this.ConditionDescs[1] + " " + this.WeaponNames[1];
					this.CustomDescs[3].text = this.ConditionDescs[2] + " " + this.ClothingNames[1];
					this.CustomDescs[4].text = this.ConditionDescs[3] + " " + this.DisposalNames[1];
					this.UpdateObjectiveHighlight();
					this.UpdateDifficultyLabel();
					this.RequiredClothingID = 1;
					this.RequiredDisposalID = 1;
					this.RequiredWeaponID = 1;
					this.TargetID = 2;
					this.ChooseTarget();
					this.CalculateMissionID();
				}
				else if (this.Selected == 3)
				{
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Confirm";
					this.PromptBar.Label[1].text = "Back";
					this.PromptBar.UpdateButtons();
					this.Phase = 6;
				}
				else if (this.Selected == 5)
				{
					this.PromptBar.Show = false;
					this.Phase = 4;
					this.Speed = (float)0;
				}
			}
		}
		else if (this.Phase == 3)
		{
			float y4 = Mathf.Lerp(this.InfoChan.localEulerAngles.y, (float)180, Time.deltaTime * (this.Speed - (float)3));
			Vector3 localEulerAngles4 = this.InfoChan.localEulerAngles;
			float num36 = localEulerAngles4.y = y4;
			Vector3 vector22 = this.InfoChan.localEulerAngles = localEulerAngles4;
			float z4 = Mathf.Lerp(this.transform.position.z, (float)2, this.Speed * Time.deltaTime * 0.25f);
			Vector3 position5 = this.transform.position;
			float num37 = position5.z = z4;
			Vector3 vector23 = this.transform.position = position5;
			this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			float x9 = Mathf.Lerp(this.Options.localPosition.x, (float)-1550, Time.deltaTime * (float)10);
			Vector3 localPosition15 = this.Options.localPosition;
			float num38 = localPosition15.x = x9;
			Vector3 vector24 = this.Options.localPosition = localPosition15;
			if (this.InputManager.TappedLeft)
			{
				this.Difficulty--;
				this.UpdateDifficulty();
			}
			if (this.InputManager.TappedRight)
			{
				this.Difficulty++;
				this.UpdateDifficulty();
			}
			if (this.InputManager.TappedUp)
			{
				this.NemesisDifficulty--;
				this.UpdateNemesisDifficulty();
			}
			if (this.InputManager.TappedDown)
			{
				this.NemesisDifficulty++;
				this.UpdateNemesisDifficulty();
			}
			for (int i = 1; i < Extensions.get_length(this.Objectives); i++)
			{
				if (i > this.Difficulty)
				{
					this.Objectives[i].localScale = Vector3.Lerp(this.Objectives[i].localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				}
				else
				{
					this.Objectives[i].localScale = Vector3.Lerp(this.Objectives[i].localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				}
			}
			if (this.NemesisDifficulty == 0)
			{
				this.NemesisPortrait.transform.parent.localScale = Vector3.Lerp(this.NemesisPortrait.transform.parent.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			}
			else
			{
				this.NemesisPortrait.transform.parent.localScale = Vector3.Lerp(this.NemesisPortrait.transform.parent.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			}
			if (this.NemesisDifficulty == 1)
			{
				this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			}
			else if (this.NemesisDifficulty == 2)
			{
				this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			}
			else if (this.NemesisDifficulty == 3)
			{
				this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			}
			else if (this.NemesisDifficulty == 4)
			{
				this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			}
			if (Input.GetButtonDown("A"))
			{
				this.StartMission();
			}
			else if (Input.GetButtonDown("B"))
			{
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "Accept";
				this.PromptBar.Label[4].text = "Choose";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
				this.TargetID = 0;
				this.Phase--;
			}
			else if (Input.GetButtonDown("X"))
			{
				this.ChooseTarget();
				if (this.Difficulty > 1)
				{
					int difficulty = this.Difficulty;
					this.Difficulty = 1;
					while (this.Difficulty < difficulty)
					{
						this.Difficulty++;
						this.PickNewCondition();
					}
				}
			}
			else if (Input.GetButtonDown("Y"))
			{
				this.UpdatePopulation();
			}
		}
		else if (this.Phase == 4)
		{
			this.Speed += Time.deltaTime;
			this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			float y5 = Mathf.Lerp(this.InfoChan.localEulerAngles.y, (float)0, Time.deltaTime * this.Speed);
			Vector3 localEulerAngles5 = this.InfoChan.localEulerAngles;
			float num39 = localEulerAngles5.y = y5;
			Vector3 vector25 = this.InfoChan.localEulerAngles = localEulerAngles5;
			float a4 = Mathf.MoveTowards(this.Darkness.color.a, (float)1, Time.deltaTime * 0.5f);
			Color color11 = this.Darkness.color;
			float num40 = color11.a = a4;
			Color color12 = this.Darkness.color = color11;
			float x10 = this.Option[1].parent.localPosition.x - this.Speed * (float)1000 * Time.deltaTime;
			Vector3 localPosition16 = this.Option[1].parent.localPosition;
			float num41 = localPosition16.x = x10;
			Vector3 vector26 = this.Option[1].parent.localPosition = localPosition16;
			float z5 = this.transform.position.z - this.Speed * Time.deltaTime;
			Vector3 position6 = this.transform.position;
			float num42 = position6.z = z5;
			Vector3 vector27 = this.transform.position = position6;
			this.Jukebox.audio.volume = this.Jukebox.audio.volume - Time.deltaTime;
			float a5 = this.Header.color.a - Time.deltaTime;
			Color color13 = this.Header.color;
			float num43 = color13.a = a5;
			Color color14 = this.Header.color = color13;
			if (this.Darkness.color.a == (float)1)
			{
				if (this.TargetID == 0)
				{
					Application.LoadLevel("TitleScene");
				}
				else
				{
					this.NowLoading.active = true;
					Application.LoadLevel("SchoolScene");
				}
			}
		}
		else if (this.Phase == 5)
		{
			float y6 = Mathf.Lerp(this.InfoChan.localEulerAngles.y, (float)180, Time.deltaTime * (this.Speed - (float)3));
			Vector3 localEulerAngles6 = this.InfoChan.localEulerAngles;
			float num44 = localEulerAngles6.y = y6;
			Vector3 vector28 = this.InfoChan.localEulerAngles = localEulerAngles6;
			float z6 = Mathf.Lerp(this.transform.position.z, (float)2, this.Speed * Time.deltaTime * 0.25f);
			Vector3 position7 = this.transform.position;
			float num45 = position7.z = z6;
			Vector3 vector29 = this.transform.position = position7;
			this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			float x11 = Mathf.Lerp(this.Options.localPosition.x, (float)-1550, Time.deltaTime * (float)10);
			Vector3 localPosition17 = this.Options.localPosition;
			float num46 = localPosition17.x = x11;
			Vector3 vector30 = this.Options.localPosition = localPosition17;
			if (this.InputManager.TappedUp)
			{
				this.Row--;
				this.UpdateObjectiveHighlight();
			}
			if (this.InputManager.TappedDown)
			{
				this.Row++;
				this.UpdateObjectiveHighlight();
			}
			if (this.InputManager.TappedRight)
			{
				this.Column++;
				this.UpdateObjectiveHighlight();
			}
			if (this.InputManager.TappedLeft)
			{
				this.Column--;
				this.UpdateObjectiveHighlight();
			}
			if (Input.GetButtonDown("A"))
			{
				if (this.CustomSelected == 1)
				{
					this.TargetID++;
					this.ChooseTarget();
				}
				else if (this.CustomSelected == 6)
				{
					int i;
					for (i = 1; i < Extensions.get_length(this.Conditions); i++)
					{
						this.Conditions[i] = 0;
					}
					i = 2;
					int num47 = 2;
					while (i < Extensions.get_length(this.CustomObjectives))
					{
						if (this.CustomObjectives[i] != null && this.CustomObjectives[i].alpha == (float)1)
						{
							if (i < 6)
							{
								this.Conditions[num47] = i - 1;
							}
							else if (i < 12)
							{
								this.Conditions[num47] = i - 2;
							}
							else
							{
								this.Conditions[num47] = i - 3;
							}
							num47++;
						}
						i++;
					}
					this.StartMission();
				}
				else if (this.CustomSelected == 12)
				{
					this.NemesisDifficulty++;
					this.UpdateNemesisDifficulty();
				}
				if (this.PromptBar.Label[0].text == "Toggle")
				{
					if (this.CustomObjectives[this.CustomSelected].alpha == 0.5f)
					{
						if (this.Difficulty < 10)
						{
							this.Difficulty++;
							this.UpdateDifficultyLabel();
							this.CustomObjectives[this.CustomSelected].alpha = (float)1;
						}
					}
					else
					{
						this.Difficulty--;
						this.UpdateDifficultyLabel();
						this.CustomObjectives[this.CustomSelected].alpha = 0.5f;
					}
				}
				this.CalculateMissionID();
			}
			else if (Input.GetButtonDown("B"))
			{
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "Accept";
				this.PromptBar.Label[4].text = "Choose";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
				for (int i = 1; i < Extensions.get_length(this.CustomObjectives); i++)
				{
					if (this.CustomObjectives[i] != null)
					{
						this.CustomObjectives[i].alpha = 0.5f;
					}
				}
				this.NemesisDifficulty = 0;
				this.UpdateNemesisDifficulty();
				this.Difficulty = 1;
				this.TargetID = 0;
				this.Phase = 2;
			}
			else if (Input.GetButtonDown("X"))
			{
				if (this.CustomSelected == 1)
				{
					this.TargetID--;
					this.ChooseTarget();
					this.CalculateMissionID();
				}
				else if (this.CustomSelected == 2)
				{
					this.RequiredWeaponID++;
					if (this.RequiredWeaponID == 11)
					{
						this.RequiredWeaponID++;
					}
					if (this.RequiredWeaponID > Extensions.get_length(this.WeaponNames) - 1)
					{
						this.RequiredWeaponID = 1;
					}
					this.CustomDescs[2].text = this.ConditionDescs[1] + " " + this.WeaponNames[this.RequiredWeaponID];
				}
				else if (this.CustomSelected == 3)
				{
					this.RequiredClothingID++;
					if (this.RequiredClothingID > Extensions.get_length(this.ClothingNames) - 1)
					{
						this.RequiredClothingID = 1;
					}
					this.CustomDescs[3].text = this.ConditionDescs[2] + " " + this.ClothingNames[this.RequiredClothingID];
				}
				else if (this.CustomSelected == 4)
				{
					this.RequiredDisposalID++;
					if (this.RequiredDisposalID > Extensions.get_length(this.DisposalNames) - 1)
					{
						this.RequiredDisposalID = 1;
					}
					this.CustomDescs[4].text = this.ConditionDescs[3] + " " + this.DisposalNames[this.RequiredDisposalID];
				}
				else if (this.CustomSelected == 12)
				{
					this.NemesisDifficulty--;
					this.UpdateNemesisDifficulty();
				}
				this.CalculateMissionID();
			}
			else if (Input.GetButtonDown("Y"))
			{
				this.UpdatePopulation();
				this.CalculateMissionID();
			}
			if (this.NemesisDifficulty == 0)
			{
				this.CustomNemesisObjectives[1].localScale = Vector3.Lerp(this.CustomNemesisObjectives[1].localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.CustomNemesisObjectives[2].localScale = Vector3.Lerp(this.CustomNemesisObjectives[2].localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.CustomNemesisObjectives[3].localScale = Vector3.Lerp(this.CustomNemesisObjectives[3].localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			}
			else if (this.NemesisDifficulty == 1)
			{
				this.CustomNemesisObjectives[1].localScale = Vector3.Lerp(this.CustomNemesisObjectives[1].localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				this.CustomNemesisObjectives[2].localScale = Vector3.Lerp(this.CustomNemesisObjectives[2].localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.CustomNemesisObjectives[3].localScale = Vector3.Lerp(this.CustomNemesisObjectives[3].localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			}
			else if (this.NemesisDifficulty == 2)
			{
				this.CustomNemesisObjectives[1].localScale = Vector3.Lerp(this.CustomNemesisObjectives[1].localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				this.CustomNemesisObjectives[2].localScale = Vector3.Lerp(this.CustomNemesisObjectives[2].localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				this.CustomNemesisObjectives[3].localScale = Vector3.Lerp(this.CustomNemesisObjectives[3].localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			}
			else if (this.NemesisDifficulty == 3)
			{
				this.CustomNemesisObjectives[1].localScale = Vector3.Lerp(this.CustomNemesisObjectives[1].localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				this.CustomNemesisObjectives[2].localScale = Vector3.Lerp(this.CustomNemesisObjectives[2].localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.CustomNemesisObjectives[3].localScale = Vector3.Lerp(this.CustomNemesisObjectives[3].localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			}
			else if (this.NemesisDifficulty == 4)
			{
				this.CustomNemesisObjectives[1].localScale = Vector3.Lerp(this.CustomNemesisObjectives[1].localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				this.CustomNemesisObjectives[2].localScale = Vector3.Lerp(this.CustomNemesisObjectives[2].localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				this.CustomNemesisObjectives[3].localScale = Vector3.Lerp(this.CustomNemesisObjectives[3].localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			}
			((UIInput)this.MissionIDLabel.gameObject.GetComponent(typeof(UIInput))).text = this.MissionID;
		}
		else if (this.Phase == 6)
		{
			float y7 = Mathf.Lerp(this.InfoChan.localEulerAngles.y, (float)180, Time.deltaTime * (this.Speed - (float)3));
			Vector3 localEulerAngles7 = this.InfoChan.localEulerAngles;
			float num48 = localEulerAngles7.y = y7;
			Vector3 vector31 = this.InfoChan.localEulerAngles = localEulerAngles7;
			float z7 = Mathf.Lerp(this.transform.position.z, (float)2, this.Speed * Time.deltaTime * 0.25f);
			Vector3 position8 = this.transform.position;
			float num49 = position8.z = z7;
			Vector3 vector32 = this.transform.position = position8;
			this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			float x12 = Mathf.Lerp(this.Options.localPosition.x, (float)-1550, Time.deltaTime * (float)10);
			Vector3 localPosition18 = this.Options.localPosition;
			float num50 = localPosition18.x = x12;
			Vector3 vector33 = this.Options.localPosition = localPosition18;
			if (!Input.anyKey)
			{
				this.MissionIDString = this.LoadMissionLabel.text;
				if (this.MissionIDString.Length < 19)
				{
					this.ErrorLabel.text = "A Mission ID must be 19 numbers long.";
				}
				else if (this.MissionIDString[0] != "-")
				{
					this.GetNumbers();
					if (this.TargetNumber == 0)
					{
						this.ErrorLabel.text = "Invalid Mission ID (No target specified)";
					}
					else if (this.TargetNumber == 1)
					{
						this.ErrorLabel.text = "Invalid Mission ID (Target cannot be Senpai)";
					}
					else if (this.TargetNumber == 33)
					{
						this.ErrorLabel.text = "Invalid Mission ID (Target cannot be Osana...yet.)";
					}
					else if (this.PopulationNumber == 0 && this.TargetNumber > 32)
					{
						this.ErrorLabel.text = "Invalid Mission ID (Population too low)";
					}
					else if (this.WeaponNumber == 11)
					{
						this.ErrorLabel.text = "Invalid Mission ID (Weapon does not apply to Mission Mode)";
					}
					else if (this.WeaponNumber > 14)
					{
						this.ErrorLabel.text = "Invalid Mission ID (Weapon does not exist)";
					}
					else if (this.ClothingNumber > 5)
					{
						this.ErrorLabel.text = "Invalid Mission ID (Clothing does not exist)";
					}
					else if (this.DisposalNumber > 3)
					{
						this.ErrorLabel.text = "Invalid Mission ID (Disposal method does not exist)";
					}
					else if (this.NemesisNumber > 4)
					{
						this.ErrorLabel.text = "Invalid Mission ID (Nemesis level too high)";
					}
					else if (this.Condition5Number > 1 || this.Condition6Number > 1 || this.Condition7Number > 1 || this.Condition8Number > 1 || this.Condition9Number > 1 || this.Condition10Number > 1 || this.Condition11Number > 1 || this.Condition12Number > 1 || this.Condition13Number > 1 || this.Condition14Number > 1 || this.Condition15Number > 1)
					{
						this.ErrorLabel.text = "Invalid Mission ID (One of those conditions should be 1 or 0)";
					}
					else
					{
						this.ErrorLabel.text = "Valid Mission ID!";
					}
				}
				else
				{
					this.ErrorLabel.text = "Invalid Mission ID (Cannot be negative number)";
				}
			}
			else if (Input.GetButtonDown("A"))
			{
				if (this.ErrorLabel.text == "Valid Mission ID!")
				{
					Debug.Log("Target ID is: " + this.TargetNumber + " and Weapon ID is: " + this.WeaponNumber);
					this.TargetID = this.TargetNumber;
					this.Difficulty = 1;
					if (this.WeaponNumber > 0)
					{
						this.Difficulty++;
						this.Conditions[this.Difficulty] = 2;
						this.CustomObjectives[2].alpha = (float)1;
						this.RequiredWeaponID = this.WeaponNumber;
						this.CustomDescs[2].text = this.ConditionDescs[1] + " " + this.WeaponNames[this.RequiredWeaponID];
					}
					else
					{
						this.CustomObjectives[2].alpha = 0.5f;
						this.CustomDescs[2].text = this.ConditionDescs[1] + " " + this.WeaponNames[1];
					}
					if (this.ClothingNumber > 0)
					{
						this.Difficulty++;
						this.Conditions[this.Difficulty] = 3;
						this.CustomObjectives[3].alpha = (float)1;
						this.RequiredClothingID = this.ClothingNumber;
						this.CustomDescs[3].text = this.ConditionDescs[2] + " " + this.ClothingNames[this.RequiredClothingID];
					}
					else
					{
						this.CustomObjectives[3].alpha = 0.5f;
						this.CustomDescs[3].text = this.ConditionDescs[2] + " " + this.ClothingNames[1];
					}
					if (this.DisposalNumber > 0)
					{
						this.Difficulty++;
						this.Conditions[this.Difficulty] = 4;
						this.CustomObjectives[4].alpha = (float)1;
						this.RequiredDisposalID = this.DisposalNumber;
						this.CustomDescs[4].text = this.ConditionDescs[3] + " " + this.DisposalNames[this.RequiredDisposalID];
					}
					else
					{
						this.CustomObjectives[4].alpha = 0.5f;
						this.CustomDescs[4].text = this.ConditionDescs[3] + " " + this.DisposalNames[1];
					}
					if (this.Difficulty < 10 && this.Condition5Number == 1)
					{
						this.Difficulty++;
						this.Conditions[this.Difficulty] = 5;
						this.CustomObjectives[5].alpha = (float)1;
					}
					if (this.Difficulty < 10 && this.Condition6Number == 1)
					{
						this.Difficulty++;
						this.Conditions[this.Difficulty] = 6;
						this.CustomObjectives[7].alpha = (float)1;
					}
					if (this.Difficulty < 10 && this.Condition7Number == 1)
					{
						this.Difficulty++;
						this.Conditions[this.Difficulty] = 7;
						this.CustomObjectives[8].alpha = (float)1;
					}
					if (this.Difficulty < 10 && this.Condition8Number == 1)
					{
						this.Difficulty++;
						this.Conditions[this.Difficulty] = 8;
						this.CustomObjectives[9].alpha = (float)1;
					}
					if (this.Difficulty < 10 && this.Condition9Number == 1)
					{
						this.Difficulty++;
						this.Conditions[this.Difficulty] = 9;
						this.CustomObjectives[10].alpha = (float)1;
					}
					if (this.Difficulty < 10 && this.Condition10Number == 1)
					{
						this.Difficulty++;
						this.Conditions[this.Difficulty] = 10;
						this.CustomObjectives[11].alpha = (float)1;
					}
					if (this.Difficulty < 10 && this.Condition11Number == 1)
					{
						this.Difficulty++;
						this.Conditions[this.Difficulty] = 11;
						this.CustomObjectives[13].alpha = (float)1;
					}
					if (this.Difficulty < 10 && this.Condition12Number == 1)
					{
						this.Difficulty++;
						this.Conditions[this.Difficulty] = 12;
						this.CustomObjectives[14].alpha = (float)1;
					}
					if (this.Difficulty < 10 && this.Condition13Number == 1)
					{
						this.Difficulty++;
						this.Conditions[this.Difficulty] = 13;
						this.CustomObjectives[15].alpha = (float)1;
					}
					if (this.Difficulty < 10 && this.Condition14Number == 1)
					{
						this.Difficulty++;
						this.Conditions[this.Difficulty] = 14;
						this.CustomObjectives[16].alpha = (float)1;
					}
					if (this.Difficulty < 10 && this.Condition15Number == 1)
					{
						this.Difficulty++;
						this.Conditions[this.Difficulty] = 15;
						this.CustomObjectives[17].alpha = (float)1;
					}
					this.NemesisDifficulty = this.NemesisNumber;
					PlayerPrefs.SetInt("Population", this.PopulationNumber);
					this.Phase = 5;
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Toggle";
					this.PromptBar.Label[1].text = "Return";
					this.PromptBar.Label[2].text = "Change";
					this.PromptBar.Label[3].text = "Population";
					this.PromptBar.Label[4].text = "Selection";
					this.PromptBar.Label[5].text = "Selection";
					this.PromptBar.UpdateButtons();
					this.UpdateObjectiveHighlight();
					this.UpdateNemesisDifficulty();
					this.UpdateDifficultyLabel();
					this.CalculateMissionID();
					this.ChooseTarget();
				}
			}
			else if (Input.GetButtonDown("B"))
			{
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "Accept";
				this.PromptBar.Label[4].text = "Choose";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
				this.TargetID = 0;
				this.Phase = 2;
			}
		}
	}

	public virtual void GetNumbers()
	{
		this.TargetNumber = UnityBuiltins.parseInt(string.Empty + this.MissionIDString[0]) * 10 + UnityBuiltins.parseInt(string.Empty + this.MissionIDString[1]);
		this.WeaponNumber = UnityBuiltins.parseInt(string.Empty + this.MissionIDString[2]) * 10 + UnityBuiltins.parseInt(string.Empty + this.MissionIDString[3]);
		this.ClothingNumber = UnityBuiltins.parseInt(string.Empty + this.MissionIDString[4]);
		this.DisposalNumber = UnityBuiltins.parseInt(string.Empty + this.MissionIDString[5]);
		this.Condition5Number = UnityBuiltins.parseInt(string.Empty + this.MissionIDString[6]);
		this.Condition6Number = UnityBuiltins.parseInt(string.Empty + this.MissionIDString[7]);
		this.Condition7Number = UnityBuiltins.parseInt(string.Empty + this.MissionIDString[8]);
		this.Condition8Number = UnityBuiltins.parseInt(string.Empty + this.MissionIDString[9]);
		this.Condition9Number = UnityBuiltins.parseInt(string.Empty + this.MissionIDString[10]);
		this.Condition10Number = UnityBuiltins.parseInt(string.Empty + this.MissionIDString[11]);
		this.Condition11Number = UnityBuiltins.parseInt(string.Empty + this.MissionIDString[12]);
		this.Condition12Number = UnityBuiltins.parseInt(string.Empty + this.MissionIDString[13]);
		this.Condition13Number = UnityBuiltins.parseInt(string.Empty + this.MissionIDString[14]);
		this.Condition14Number = UnityBuiltins.parseInt(string.Empty + this.MissionIDString[15]);
		this.Condition15Number = UnityBuiltins.parseInt(string.Empty + this.MissionIDString[16]);
		this.NemesisNumber = UnityBuiltins.parseInt(string.Empty + this.MissionIDString[17]);
		this.PopulationNumber = UnityBuiltins.parseInt(string.Empty + this.MissionIDString[18]);
	}

	public virtual void LateUpdate()
	{
		if (this.Speed > (float)3)
		{
			this.Rotation = Mathf.Lerp(this.Rotation, (float)0, Time.deltaTime * (this.Speed - (float)3));
		}
		float x = this.Neck.transform.localEulerAngles.x + this.Rotation;
		Vector3 localEulerAngles = this.Neck.transform.localEulerAngles;
		float num = localEulerAngles.x = x;
		Vector3 vector = this.Neck.transform.localEulerAngles = localEulerAngles;
	}

	public virtual void UpdateHighlight()
	{
		if (this.Selected == 0)
		{
			this.Selected = 5;
		}
		else if (this.Selected == 6)
		{
			this.Selected = 1;
		}
	}

	public virtual void ChooseTarget()
	{
		if (this.Phase != 5)
		{
			if (PlayerPrefs.GetInt("HighPopulation") == 0)
			{
				this.TargetID = UnityEngine.Random.Range(2, 33);
			}
			else
			{
				this.TargetID = UnityEngine.Random.Range(2, 90);
			}
		}
		else if (PlayerPrefs.GetInt("HighPopulation") == 0)
		{
			if (this.TargetID > 32)
			{
				this.TargetID = 2;
			}
			else if (this.TargetID < 2)
			{
				this.TargetID = 32;
			}
		}
		else if (this.TargetID > 89)
		{
			this.TargetID = 2;
		}
		else if (this.TargetID < 2)
		{
			this.TargetID = 89;
		}
		string url = "file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + this.TargetID + ".png";
		WWW www = new WWW(url);
		if (this.TargetID < 33)
		{
			this.TargetPortrait.mainTexture = www.texture;
		}
		else
		{
			this.TargetPortrait.mainTexture = this.BlankPortrait;
		}
		this.CustomTargetPortrait.mainTexture = this.TargetPortrait.mainTexture;
		if (this.JSON.StudentNames[this.TargetID] == "Random" || this.JSON.StudentNames[this.TargetID] == "Unknown")
		{
			this.TargetName = string.Empty + this.StudentManager.FirstNames[UnityEngine.Random.Range(0, Extensions.get_length(this.StudentManager.FirstNames))] + " " + this.StudentManager.LastNames[UnityEngine.Random.Range(0, Extensions.get_length(this.StudentManager.LastNames))];
		}
		else
		{
			this.TargetName = this.JSON.StudentNames[this.TargetID];
		}
		this.CustomDescs[1].text = "Kill " + this.TargetName + ".";
		this.Descs[1].text = "Kill " + this.TargetName + ".";
		if (this.TargetID == 33)
		{
			if (this.Phase == 5)
			{
				if (Input.GetButtonDown("A"))
				{
					this.TargetID++;
				}
				else
				{
					this.TargetID--;
				}
			}
			this.ChooseTarget();
		}
	}

	public virtual void UpdateDifficulty()
	{
		if (this.Difficulty < 1)
		{
			this.Difficulty = 1;
		}
		else if (this.Difficulty > 10)
		{
			this.Difficulty = 10;
		}
		if (this.InputManager.TappedRight)
		{
			this.PickNewCondition();
		}
		else
		{
			this.ErasePreviousCondition();
		}
	}

	public virtual void UpdateDifficultyLabel()
	{
		this.CustomDifficultyLabel.text = "Difficulty Level - " + this.Difficulty;
		this.DifficultyLabel.text = "Difficulty Level - " + this.Difficulty;
		string lhs = "Kill " + this.TargetName + ".";
		string rhs;
		if (this.RequiredWeaponID == 0)
		{
			rhs = "You can kill the target with any weapon.";
		}
		else
		{
			rhs = "You must kill the target with a " + this.WeaponNames[this.RequiredWeaponID];
		}
		string rhs2;
		if (this.RequiredClothingID == 0)
		{
			rhs2 = "You can kill the target wearing any clothing.";
		}
		else
		{
			rhs2 = "You must kill the target while wearing " + this.ClothingNames[this.RequiredClothingID];
		}
		string rhs3;
		if (this.RequiredDisposalID == 0)
		{
			rhs3 = "It is not necessary to dispose of the target's corpse.";
		}
		else
		{
			rhs3 = "You must dispose of the target's corpse by " + this.DisposalNames[this.RequiredDisposalID];
		}
		this.DescriptionLabel.text = lhs + "\n" + "\n" + rhs + "\n" + "\n" + rhs2 + "\n" + "\n" + rhs3;
	}

	public virtual void UpdateNemesisDifficulty()
	{
		if (this.NemesisDifficulty < 0)
		{
			this.NemesisDifficulty = 4;
		}
		else if (this.NemesisDifficulty > 4)
		{
			this.NemesisDifficulty = 0;
		}
		if (this.NemesisDifficulty == 0)
		{
			this.CustomNemesisLabel.text = "Nemesis: Off";
			this.NemesisLabel.text = "Nemesis: Off";
		}
		else
		{
			this.CustomNemesisLabel.text = "Nemesis: On";
			this.NemesisLabel.text = "Nemesis: On";
			if (this.NemesisDifficulty > 2)
			{
				this.NemesisPortrait.mainTexture = this.BlankPortrait;
			}
			else
			{
				this.NemesisPortrait.mainTexture = this.NemesisGraphic;
			}
		}
	}

	public virtual void PickNewCondition()
	{
		int num = UnityEngine.Random.Range(1, Extensions.get_length(this.ConditionDescs));
		this.Conditions[this.Difficulty] = num;
		this.Descs[this.Difficulty].text = this.ConditionDescs[num];
		this.Icons[this.Difficulty].mainTexture = this.ConditionIcons[num];
		bool flag = false;
		for (int i = 2; i < this.Difficulty; i++)
		{
			if (num == this.Conditions[i])
			{
				flag = true;
			}
		}
		if (flag)
		{
			this.PickNewCondition();
		}
		else if (num > 3)
		{
			this.Descs[this.Difficulty].text = this.ConditionDescs[num];
		}
		else if (num == 1)
		{
			this.RequiredWeaponID = 11;
			while (this.RequiredWeaponID == 11)
			{
				this.RequiredWeaponID = UnityEngine.Random.Range(1, Extensions.get_length(this.WeaponNames));
			}
			this.Descs[this.Difficulty].text = this.ConditionDescs[num] + " " + this.WeaponNames[this.RequiredWeaponID];
		}
		else if (num == 2)
		{
			this.RequiredClothingID = UnityEngine.Random.Range(1, Extensions.get_length(this.ClothingNames));
			this.Descs[this.Difficulty].text = this.ConditionDescs[num] + " " + this.ClothingNames[this.RequiredClothingID];
		}
		else if (num == 3)
		{
			this.RequiredDisposalID = UnityEngine.Random.Range(1, Extensions.get_length(this.DisposalNames));
			this.Descs[this.Difficulty].text = this.ConditionDescs[num] + " " + this.DisposalNames[this.RequiredDisposalID];
		}
		this.UpdateDifficultyLabel();
	}

	public virtual void ErasePreviousCondition()
	{
		if (this.Conditions[this.Difficulty + 1] == 1)
		{
			this.RequiredWeaponID = 0;
		}
		else if (this.Conditions[this.Difficulty + 1] == 2)
		{
			this.RequiredClothingID = 0;
		}
		else if (this.Conditions[this.Difficulty + 1] == 3)
		{
			this.RequiredDisposalID = 0;
		}
		this.Conditions[this.Difficulty + 1] = 0;
		this.UpdateDifficultyLabel();
	}

	public virtual void UpdateGraphics()
	{
		if (PlayerPrefs.GetInt("MissionTarget") < 33)
		{
			string url = "file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + PlayerPrefs.GetInt("MissionTarget") + ".png";
			WWW www = new WWW(url);
			this.Icons[1].mainTexture = www.texture;
			this.TargetName = this.JSON.StudentNames[PlayerPrefs.GetInt("MissionTarget")];
		}
		else
		{
			this.TargetPortrait.mainTexture = this.BlankPortrait;
			this.TargetName = PlayerPrefs.GetString("MissionTargetName");
		}
		this.Descs[1].text = "Kill " + this.TargetName + ".";
		for (int i = 2; i < Extensions.get_length(this.Objectives); i++)
		{
			this.Objectives[i].gameObject.active = false;
		}
		if (PlayerPrefs.GetInt("MissionDifficulty") > 1)
		{
			for (int i = 2; i < PlayerPrefs.GetInt("MissionDifficulty") + 1; i++)
			{
				this.Objectives[i].gameObject.active = true;
				this.Icons[i].mainTexture = this.ConditionIcons[PlayerPrefs.GetInt("MissionCondition_" + i)];
				if (PlayerPrefs.GetInt("MissionCondition_" + i) > 3)
				{
					this.Descs[i].text = this.ConditionDescs[PlayerPrefs.GetInt("MissionCondition_" + i)];
				}
				else if (PlayerPrefs.GetInt("MissionCondition_" + i) == 1)
				{
					this.RequiredWeaponID = 11;
					while (this.RequiredWeaponID == 11)
					{
						this.RequiredWeaponID = UnityEngine.Random.Range(1, Extensions.get_length(this.WeaponNames));
					}
					this.Descs[i].text = this.ConditionDescs[PlayerPrefs.GetInt("MissionCondition_" + i)] + " " + this.WeaponNames[PlayerPrefs.GetInt("MissionRequiredWeapon")];
				}
				else if (PlayerPrefs.GetInt("MissionCondition_" + i) == 2)
				{
					this.RequiredClothingID = UnityEngine.Random.Range(0, Extensions.get_length(this.ClothingNames));
					this.Descs[i].text = this.ConditionDescs[PlayerPrefs.GetInt("MissionCondition_" + i)] + " " + this.ClothingNames[PlayerPrefs.GetInt("MissionRequiredClothing")];
				}
				else if (PlayerPrefs.GetInt("MissionCondition_" + i) == 3)
				{
					this.RequiredDisposalID = UnityEngine.Random.Range(1, Extensions.get_length(this.DisposalNames));
					this.Descs[i].text = this.ConditionDescs[PlayerPrefs.GetInt("MissionCondition_" + i)] + " " + this.DisposalNames[PlayerPrefs.GetInt("MissionRequiredDisposal")];
				}
			}
		}
	}

	public virtual void UpdatePopulation()
	{
		if (PlayerPrefs.GetInt("HighPopulation") == 0)
		{
			this.CustomPopulationLabel.text = "High School Population: On";
			this.PopulationLabel.text = "High School Population: On";
			PlayerPrefs.SetInt("HighPopulation", 1);
		}
		else
		{
			this.CustomPopulationLabel.text = "High School Population: Off";
			this.PopulationLabel.text = "High School Population: Off";
			PlayerPrefs.SetInt("HighPopulation", 0);
			if (this.TargetID > 32)
			{
				this.ChooseTarget();
			}
		}
	}

	public virtual void UpdateObjectiveHighlight()
	{
		int num = 0;
		if (this.Row < 1)
		{
			this.Row = 6;
		}
		else if (this.Row > 6)
		{
			this.Row = 1;
		}
		else if (this.Column < 1)
		{
			this.Column = 3;
		}
		else if (this.Column > 3)
		{
			this.Column = 1;
		}
		if (this.Row == 6 && this.Column == 3)
		{
			this.Column = 1;
		}
		if (this.Row == 6)
		{
			num = 75;
		}
		if ((this.Column == 1 && this.Row < 5) || (this.Column == 2 && this.Row == 6))
		{
			this.PromptBar.Label[2].text = "Change";
		}
		else
		{
			this.PromptBar.Label[2].text = string.Empty;
		}
		int num2 = -1050 + 650 * this.Column;
		Vector3 localPosition = this.ObjectiveHighlight.localPosition;
		float num3 = localPosition.x = (float)num2;
		Vector3 vector = this.ObjectiveHighlight.localPosition = localPosition;
		int num4 = 450 - 150 * this.Row - num;
		Vector3 localPosition2 = this.ObjectiveHighlight.localPosition;
		float num5 = localPosition2.y = (float)num4;
		Vector3 vector2 = this.ObjectiveHighlight.localPosition = localPosition2;
		this.CustomSelected = this.Row + (this.Column - 1) * 6;
		if (this.CustomSelected == 1 || this.CustomSelected == 12)
		{
			this.PromptBar.Label[0].text = "Forward";
		}
		else if (this.CustomSelected == 6)
		{
			this.PromptBar.Label[0].text = "Start";
		}
		else
		{
			this.PromptBar.Label[0].text = "Toggle";
		}
		if (this.CustomSelected == 1 || this.CustomSelected == 12)
		{
			this.PromptBar.Label[2].text = "Backward";
		}
		else if (this.CustomSelected > 4)
		{
			this.PromptBar.Label[2].text = string.Empty;
		}
		else
		{
			this.PromptBar.Label[2].text = "Change";
		}
		this.PromptBar.UpdateButtons();
	}

	public virtual void CalculateMissionID()
	{
		if (this.TargetID < 10)
		{
			this.TargetString = "0" + this.TargetID;
		}
		else
		{
			this.TargetString = string.Empty + this.TargetID;
		}
		if (this.CustomObjectives[2].alpha == (float)1)
		{
			if (this.RequiredWeaponID < 10)
			{
				this.WeaponString = "0" + this.RequiredWeaponID;
			}
			else
			{
				this.WeaponString = string.Empty + this.RequiredWeaponID;
			}
		}
		else
		{
			this.WeaponString = "00";
		}
		if (this.CustomObjectives[3].alpha == (float)1)
		{
			this.ClothingString = string.Empty + this.RequiredClothingID;
		}
		else
		{
			this.ClothingString = "0";
		}
		if (this.CustomObjectives[4].alpha == (float)1)
		{
			this.DisposalString = string.Empty + this.RequiredDisposalID;
		}
		else
		{
			this.DisposalString = "0";
		}
		for (int i = 1; i < Extensions.get_length(this.CustomObjectives); i++)
		{
			if (this.CustomObjectives[i] != null)
			{
				if (this.CustomObjectives[i].alpha == (float)1)
				{
					this.ConditionString[i] = "1";
				}
				else
				{
					this.ConditionString[i] = "0";
				}
			}
		}
		this.MissionID = this.TargetString + this.WeaponString + this.ClothingString + this.DisposalString + this.ConditionString[5] + this.ConditionString[6] + this.ConditionString[7] + this.ConditionString[8] + this.ConditionString[9] + this.ConditionString[10] + this.ConditionString[11] + this.ConditionString[12] + this.ConditionString[13] + this.ConditionString[14] + this.ConditionString[15] + this.ConditionString[16] + this.ConditionString[17] + this.NemesisDifficulty + PlayerPrefs.GetInt("HighPopulation");
		this.MissionIDLabel.text = this.MissionID;
	}

	public virtual void StartMission()
	{
		this.audio.PlayOneShot(this.InfoLines[6]);
		int @int = PlayerPrefs.GetInt("HighPopulation");
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetFloat("SchoolAtmosphere", (float)100 - (float)this.Difficulty * 1f / 10f * (float)100);
		PlayerPrefs.SetInt("NemesisDifficulty", this.NemesisDifficulty);
		PlayerPrefs.SetString("MissionTargetName", this.TargetName);
		PlayerPrefs.SetInt("MissionDifficulty", this.Difficulty);
		PlayerPrefs.SetInt("HighPopulation", @int);
		PlayerPrefs.SetInt("MissionTarget", this.TargetID);
		PlayerPrefs.SetInt("SchoolAtmosphereSet", 1);
		PlayerPrefs.SetInt("MissionMode", 1);
		PlayerPrefs.SetInt("BiologyGrade", 1);
		PlayerPrefs.SetInt("ChemistryGrade", 1);
		PlayerPrefs.SetInt("LanguageGrade", 1);
		PlayerPrefs.SetInt("PhysicalGrade", 1);
		PlayerPrefs.SetInt("PsychologyGrade", 1);
		if (this.Difficulty > 1)
		{
			for (int i = 2; i < this.Difficulty + 1; i++)
			{
				if (this.Conditions[i] == 1)
				{
					PlayerPrefs.SetInt("MissionRequiredWeapon", this.RequiredWeaponID);
				}
				else if (this.Conditions[i] == 2)
				{
					PlayerPrefs.SetInt("MissionRequiredClothing", this.RequiredClothingID);
				}
				else if (this.Conditions[i] == 3)
				{
					PlayerPrefs.SetInt("MissionRequiredDisposal", this.RequiredDisposalID);
				}
				PlayerPrefs.SetInt("MissionCondition_" + i, this.Conditions[i]);
			}
		}
		this.PromptBar.Show = false;
		this.Speed = (float)0;
		this.Phase = 4;
	}

	public virtual void Main()
	{
	}
}
