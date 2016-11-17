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

	public UILabel DifficultyLabel;

	public UILabel PopulationLabel;

	public UILabel Header;

	public UISprite Highlight;

	public UISprite Darkness;

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

	public Texture[] ConditionIcons;

	public Transform[] Objectives;

	public Transform[] Option;

	public UITexture[] Icons;

	public UILabel[] Descs;

	public Texture BlankPortrait;

	public string TargetName;

	public int Difficulty;

	public int InfoSpoke;

	public int Selected;

	public int TargetID;

	public int Phase;

	public float Rotation;

	public float Speed;

	public float Timer;

	public AudioSource Jukebox;

	public AudioClip InfoWelcome;

	public AudioClip InfoReady;

	public AudioClip InfoBack;

	public AudioClip InfoLuck;

	public MissionModeMenuScript()
	{
		this.TargetName = string.Empty;
		this.Difficulty = 1;
		this.Selected = 1;
	}

	public virtual void Start()
	{
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
		if (PlayerPrefs.GetInt("HighPopulation") == 0)
		{
			this.PopulationLabel.text = "High School Population: Off";
		}
		else
		{
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
					if (this.InfoSpoke == 0)
					{
						this.audio.PlayOneShot(this.InfoWelcome);
						this.InfoSpoke++;
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
				if (this.InfoSpoke == 0)
				{
					this.audio.PlayOneShot(this.InfoWelcome);
					this.InfoSpoke++;
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
				if (this.Selected == 1)
				{
					if (this.InfoSpoke == 1)
					{
						this.audio.PlayOneShot(this.InfoReady);
						this.InfoSpoke++;
					}
					if (this.TargetID == 0)
					{
						this.ChooseTarget();
					}
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Accept";
					this.PromptBar.Label[1].text = "Back";
					this.PromptBar.Label[2].text = "Generate";
					this.PromptBar.Label[3].text = "Population";
					this.PromptBar.Label[5].text = "Change Difficulty";
					this.PromptBar.UpdateButtons();
					this.Phase++;
				}
				else if (this.Selected == 5)
				{
					this.audio.PlayOneShot(this.InfoBack);
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
			for (int i = 1; i < Extensions.get_length(this.Objectives); i++)
			{
				if (i > this.Difficulty)
				{
					this.Objectives[i].localScale = Vector3.Lerp(this.Objectives[i].transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				}
				else
				{
					this.Objectives[i].localScale = Vector3.Lerp(this.Objectives[i].transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				}
			}
			if (Input.GetButtonDown("A"))
			{
				this.audio.PlayOneShot(this.InfoLuck);
				int @int = PlayerPrefs.GetInt("HighPopulation");
				PlayerPrefs.DeleteAll();
				PlayerPrefs.SetInt("HighPopulation", @int);
				PlayerPrefs.SetInt("MissionTarget", this.TargetID);
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
				this.Phase++;
			}
			else if (Input.GetButtonDown("B"))
			{
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[1].text = "Accept";
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
				if (PlayerPrefs.GetInt("HighPopulation") == 0)
				{
					this.PopulationLabel.text = "High School Population: On";
					PlayerPrefs.SetInt("HighPopulation", 1);
				}
				else
				{
					this.PopulationLabel.text = "High School Population: Off";
					PlayerPrefs.SetInt("HighPopulation", 0);
					if (this.TargetID > 32)
					{
						this.ChooseTarget();
					}
				}
			}
		}
		else if (this.Phase == 4)
		{
			this.Speed += Time.deltaTime;
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
					PlayerPrefs.SetFloat("SchoolAtmosphere", (float)100 - (float)this.Difficulty * 1f / 10f * (float)100);
					PlayerPrefs.SetString("MissionTargetName", this.TargetName);
					PlayerPrefs.SetInt("MissionDifficulty", this.Difficulty);
					PlayerPrefs.SetInt("SchoolAtmosphereSet", 1);
					PlayerPrefs.SetInt("MissionMode", 1);
					Application.LoadLevel("SchoolScene");
				}
			}
		}
		if (Input.GetKeyDown("m"))
		{
			this.Difficulty = 3;
			this.TargetID = 32;
			this.Conditions[2] = 1;
			this.Conditions[3] = 2;
			this.RequiredClothingID = 2;
			this.RequiredWeaponID = 4;
		}
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
		if (PlayerPrefs.GetInt("HighPopulation") == 0)
		{
			this.TargetID = UnityEngine.Random.Range(2, 33);
		}
		else
		{
			this.TargetID = UnityEngine.Random.Range(2, 90);
		}
		string url = "file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + this.TargetID + ".png";
		WWW www = new WWW(url);
		if (this.TargetID < 33)
		{
			this.Icons[1].mainTexture = www.texture;
		}
		else
		{
			this.Icons[1].mainTexture = this.BlankPortrait;
		}
		if (this.JSON.StudentNames[this.TargetID] == "Random" || this.JSON.StudentNames[this.TargetID] == "Unknown")
		{
			this.TargetName = string.Empty + this.StudentManager.FirstNames[UnityEngine.Random.Range(0, Extensions.get_length(this.StudentManager.FirstNames))] + " " + this.StudentManager.LastNames[UnityEngine.Random.Range(0, Extensions.get_length(this.StudentManager.LastNames))];
		}
		else
		{
			this.TargetName = this.JSON.StudentNames[this.TargetID];
		}
		this.Descs[1].text = "Kill " + this.TargetName + ".";
		if (this.TargetID == 33)
		{
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
		else if (this.InputManager.TappedRight)
		{
			this.PickNewCondition();
		}
		this.DifficultyLabel.text = "Difficulty Level - " + this.Difficulty;
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
			while (this.RequiredWeaponID == 11 || this.RequiredWeaponID == 3)
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
			this.Icons[1].mainTexture = this.BlankPortrait;
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

	public virtual void Main()
	{
	}
}
