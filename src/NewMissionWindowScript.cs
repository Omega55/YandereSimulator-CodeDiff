using System;
using UnityEngine;

public class NewMissionWindowScript : MonoBehaviour
{
	public MissionModeMenuScript MissionModeMenu;

	public InputManagerScript InputManager;

	public JsonScript JSON;

	public GameObject[] DeathSkulls;

	public GameObject[] Button;

	public UILabel[] MethodLabel;

	public UILabel[] NameLabel;

	public UITexture[] Portrait;

	public int[] UnsafeNumbers;

	public int[] Target;

	public int[] Method;

	public string[] MethodNames;

	public int Selected;

	public int Column;

	public int Row;

	public Transform Highlight;

	public Texture BlankPortrait;

	private void Start()
	{
		this.UpdateHighlight();
		for (int i = 1; i < 11; i++)
		{
			this.Portrait[i].mainTexture = this.BlankPortrait;
			this.NameLabel[i].text = "Kill: (Nobody)";
			this.MethodLabel[i].text = "By: Attacking";
			this.DeathSkulls[i].SetActive(false);
		}
	}

	private void Update()
	{
		if (this.InputManager.TappedDown)
		{
			this.Row++;
			this.UpdateHighlight();
		}
		if (this.InputManager.TappedUp)
		{
			this.Row--;
			this.UpdateHighlight();
		}
		if (this.InputManager.TappedRight)
		{
			this.Column++;
			this.UpdateHighlight();
		}
		if (this.InputManager.TappedLeft)
		{
			this.Column--;
			this.UpdateHighlight();
		}
		if (Input.GetButtonDown("A"))
		{
			int num = 0;
			for (int i = 0; i < 11; i++)
			{
				if (this.Target[i] > 0)
				{
					num++;
				}
			}
			if (this.Row == 5)
			{
				if (this.Column == 1)
				{
					if (num > 0)
					{
						Globals.DeleteAll();
						this.SaveInfo();
						this.MissionModeMenu.GetComponent<AudioSource>().PlayOneShot(this.MissionModeMenu.InfoLines[6]);
						SchoolGlobals.SchoolAtmosphere = 1f - (float)num * 0.1f;
						SchoolGlobals.SchoolAtmosphereSet = true;
						MissionModeGlobals.MissionMode = true;
						MissionModeGlobals.MultiMission = true;
						MissionModeGlobals.MissionDifficulty = num;
						ClassGlobals.BiologyGrade = 1;
						ClassGlobals.ChemistryGrade = 1;
						ClassGlobals.LanguageGrade = 1;
						ClassGlobals.PhysicalGrade = 1;
						ClassGlobals.PsychologyGrade = 1;
						this.MissionModeMenu.PromptBar.Show = false;
						this.MissionModeMenu.Speed = 0f;
						this.MissionModeMenu.Phase = 4;
						base.enabled = false;
					}
				}
				else if (this.Column == 2)
				{
					this.Randomize();
				}
			}
		}
		if (Input.GetButtonDown("B"))
		{
			this.MissionModeMenu.PromptBar.ClearButtons();
			this.MissionModeMenu.PromptBar.Label[0].text = "Accept";
			this.MissionModeMenu.PromptBar.Label[4].text = "Choose";
			this.MissionModeMenu.PromptBar.UpdateButtons();
			this.MissionModeMenu.PromptBar.Show = true;
			this.MissionModeMenu.TargetID = 0;
			this.MissionModeMenu.Phase = 2;
		}
		if (Input.GetButtonDown("X"))
		{
			if (this.Row == 1)
			{
				for (int j = 1; j < 11; j++)
				{
					this.UnsafeNumbers[j] = this.Target[j];
				}
				this.Increment(0);
				if (this.Target[this.Column] != 0)
				{
					while (this.Target[this.Column] == this.UnsafeNumbers[1] || this.Target[this.Column] == this.UnsafeNumbers[2] || this.Target[this.Column] == this.UnsafeNumbers[3] || this.Target[this.Column] == this.UnsafeNumbers[4] || this.Target[this.Column] == this.UnsafeNumbers[5] || this.Target[this.Column] == this.UnsafeNumbers[6] || this.Target[this.Column] == this.UnsafeNumbers[7] || this.Target[this.Column] == this.UnsafeNumbers[8] || this.Target[this.Column] == this.UnsafeNumbers[9] || this.Target[this.Column] == this.UnsafeNumbers[10])
					{
						this.Increment(0);
					}
				}
			}
			else if (this.Row == 2)
			{
				this.Method[this.Column]++;
				if (this.Method[this.Column] == this.MethodNames.Length)
				{
					this.Method[this.Column] = 0;
				}
				this.MethodLabel[this.Column].text = "By: " + this.MethodNames[this.Method[this.Column]];
			}
			else if (this.Row == 3)
			{
				for (int k = 1; k < 11; k++)
				{
					this.UnsafeNumbers[k] = this.Target[k];
				}
				this.Increment(5);
				if (this.Target[this.Column] != 0)
				{
					while (this.Target[this.Column + 5] == this.UnsafeNumbers[1] || this.Target[this.Column + 5] == this.UnsafeNumbers[2] || this.Target[this.Column + 5] == this.UnsafeNumbers[3] || this.Target[this.Column + 5] == this.UnsafeNumbers[4] || this.Target[this.Column + 5] == this.UnsafeNumbers[5] || this.Target[this.Column + 5] == this.UnsafeNumbers[6] || this.Target[this.Column + 5] == this.UnsafeNumbers[7] || this.Target[this.Column + 5] == this.UnsafeNumbers[8] || this.Target[this.Column + 5] == this.UnsafeNumbers[9] || this.Target[this.Column + 5] == this.UnsafeNumbers[10])
					{
						this.Increment(5);
					}
				}
			}
			else if (this.Row == 4)
			{
				this.Method[this.Column + 5]++;
				if (this.Method[this.Column + 5] == this.MethodNames.Length)
				{
					this.Method[this.Column + 5] = 0;
				}
				this.MethodLabel[this.Column + 5].text = "By: " + this.MethodNames[this.Method[this.Column + 5]];
			}
		}
		if (Input.GetButtonDown("Y"))
		{
			if (this.Row == 1)
			{
				for (int l = 1; l < 11; l++)
				{
					this.UnsafeNumbers[l] = this.Target[l];
				}
				this.Decrement(0);
				if (this.Target[this.Column] != 0)
				{
					while (this.Target[this.Column] == this.UnsafeNumbers[1] || this.Target[this.Column] == this.UnsafeNumbers[2] || this.Target[this.Column] == this.UnsafeNumbers[3] || this.Target[this.Column] == this.UnsafeNumbers[4] || this.Target[this.Column] == this.UnsafeNumbers[5] || this.Target[this.Column] == this.UnsafeNumbers[6] || this.Target[this.Column] == this.UnsafeNumbers[7] || this.Target[this.Column] == this.UnsafeNumbers[8] || this.Target[this.Column] == this.UnsafeNumbers[9] || this.Target[this.Column] == this.UnsafeNumbers[10])
					{
						this.Decrement(0);
					}
				}
			}
			else if (this.Row == 2)
			{
				this.Method[this.Column]--;
				if (this.Method[this.Column] < 0)
				{
					this.Method[this.Column] = this.MethodNames.Length - 1;
				}
				this.MethodLabel[this.Column].text = "By: " + this.MethodNames[this.Method[this.Column]];
			}
			else if (this.Row == 3)
			{
				for (int m = 1; m < 11; m++)
				{
					this.UnsafeNumbers[m] = this.Target[m];
				}
				this.Decrement(5);
				if (this.Target[this.Column] != 0)
				{
					while (this.Target[this.Column + 5] == this.UnsafeNumbers[1] || this.Target[this.Column + 5] == this.UnsafeNumbers[2] || this.Target[this.Column + 5] == this.UnsafeNumbers[3] || this.Target[this.Column + 5] == this.UnsafeNumbers[4] || this.Target[this.Column + 5] == this.UnsafeNumbers[5] || this.Target[this.Column + 5] == this.UnsafeNumbers[6] || this.Target[this.Column + 5] == this.UnsafeNumbers[7] || this.Target[this.Column + 5] == this.UnsafeNumbers[8] || this.Target[this.Column + 5] == this.UnsafeNumbers[9] || this.Target[this.Column + 5] == this.UnsafeNumbers[10])
					{
						this.Decrement(5);
					}
				}
			}
			else if (this.Row == 4)
			{
				this.Method[this.Column + 5]--;
				if (this.Method[this.Column + 5] < 0)
				{
					this.Method[this.Column + 5] = this.MethodNames.Length - 1;
				}
				this.MethodLabel[this.Column + 5].text = "By: " + this.MethodNames[this.Method[this.Column + 5]];
			}
		}
		if (Input.GetKeyDown("space"))
		{
			this.FillOutInfo();
		}
	}

	private void Increment(int Number)
	{
		this.Target[this.Column + Number]++;
		if (this.Target[this.Column + Number] == 1)
		{
			this.Target[this.Column + Number] = 2;
		}
		else if (this.Target[this.Column + Number] == 10)
		{
			this.Target[this.Column + Number] = 21;
		}
		else if (this.Target[this.Column + Number] > 89)
		{
			this.Target[this.Column + Number] = 0;
		}
		if (this.Target[this.Column + Number] == 0)
		{
			this.NameLabel[this.Column + Number].text = "Kill: Nobody";
		}
		else
		{
			this.NameLabel[this.Column + Number].text = "Kill: " + this.JSON.Students[this.Target[this.Column + Number]].Name;
		}
		string url = string.Concat(new object[]
		{
			"file:///",
			Application.streamingAssetsPath,
			"/Portraits/Student_",
			this.Target[this.Column + Number],
			".png"
		});
		WWW www = new WWW(url);
		this.Portrait[this.Column + Number].mainTexture = www.texture;
	}

	private void Decrement(int Number)
	{
		this.Target[this.Column + Number]--;
		if (this.Target[this.Column + Number] == 1)
		{
			this.Target[this.Column + Number] = 0;
		}
		else if (this.Target[this.Column + Number] == 20)
		{
			this.Target[this.Column + Number] = 9;
		}
		else if (this.Target[this.Column + Number] == -1)
		{
			this.Target[this.Column + Number] = 89;
		}
		if (this.Target[this.Column + Number] == 0)
		{
			this.NameLabel[this.Column + Number].text = "Kill: Nobody";
		}
		else
		{
			this.NameLabel[this.Column + Number].text = "Kill: " + this.JSON.Students[this.Target[this.Column + Number]].Name;
		}
		string url = string.Concat(new object[]
		{
			"file:///",
			Application.streamingAssetsPath,
			"/Portraits/Student_",
			this.Target[this.Column + Number],
			".png"
		});
		WWW www = new WWW(url);
		this.Portrait[this.Column + Number].mainTexture = www.texture;
	}

	private void Randomize()
	{
		int i;
		for (i = 1; i < 11; i++)
		{
			this.Target[i] = UnityEngine.Random.Range(2, 89);
			this.Method[i] = UnityEngine.Random.Range(0, 7);
			this.MethodLabel[i].text = "By: " + this.MethodNames[this.Method[i]];
		}
		i = 1;
		this.Column = 0;
		while (i < 11)
		{
			for (int j = 1; j < 11; j++)
			{
				this.UnsafeNumbers[j] = this.Target[j];
			}
			while (this.Target[i] == this.UnsafeNumbers[1] || this.Target[i] == this.UnsafeNumbers[2] || this.Target[i] == this.UnsafeNumbers[3] || this.Target[i] == this.UnsafeNumbers[4] || this.Target[i] == this.UnsafeNumbers[5] || this.Target[i] == this.UnsafeNumbers[6] || this.Target[i] == this.UnsafeNumbers[7] || this.Target[i] == this.UnsafeNumbers[8] || this.Target[i] == this.UnsafeNumbers[9] || this.Target[i] == this.UnsafeNumbers[10] || this.Target[i] == 0 || (this.Target[i] > 9 && this.Target[i] < 21))
			{
				this.Increment(i);
			}
			i++;
		}
		this.Column = 2;
	}

	public void UpdateHighlight()
	{
		this.MissionModeMenu.PromptBar.Label[0].text = string.Empty;
		if (this.Row < 1)
		{
			this.Row = 5;
		}
		else if (this.Row > 5)
		{
			this.Row = 1;
		}
		if (this.Row < 5)
		{
			if (this.Column < 1)
			{
				this.Column = 5;
			}
			else if (this.Column > 5)
			{
				this.Column = 1;
			}
			int num = 0;
			if (this.Row == 1)
			{
				num = 225;
			}
			else if (this.Row == 2)
			{
				num = 125;
			}
			else if (this.Row == 3)
			{
				num = -300;
			}
			else if (this.Row == 4)
			{
				num = -400;
			}
			this.Highlight.localPosition = new Vector3((float)(-1200 + 400 * this.Column), (float)num, 0f);
		}
		else
		{
			if (this.Column < 1)
			{
				this.Column = 3;
			}
			else if (this.Column > 3)
			{
				this.Column = 1;
			}
			this.Highlight.localPosition = new Vector3((float)(-1200 + 600 * this.Column), -525f, 0f);
			if (this.Column == 1)
			{
				if (this.Target[1] + this.Target[2] + this.Target[3] + this.Target[4] + this.Target[5] + this.Target[6] + this.Target[7] + this.Target[8] + this.Target[9] + this.Target[10] == 0)
				{
					this.MissionModeMenu.PromptBar.Label[0].text = string.Empty;
				}
				else
				{
					this.MissionModeMenu.PromptBar.Label[0].text = "Confirm";
				}
			}
			else if (this.Column == 2)
			{
				this.MissionModeMenu.PromptBar.Label[0].text = "Confirm";
			}
			else
			{
				this.MissionModeMenu.PromptBar.Label[0].text = string.Empty;
			}
			this.MissionModeMenu.PromptBar.UpdateButtons();
		}
	}

	private void SaveInfo()
	{
		for (int i = 1; i < 11; i++)
		{
			PlayerPrefs.SetInt("MissionModeTarget" + i, this.Target[i]);
			PlayerPrefs.SetInt("MissionModeMethod" + i, this.Method[i]);
		}
	}

	public void FillOutInfo()
	{
		for (int i = 1; i < 11; i++)
		{
			this.Target[i] = PlayerPrefs.GetInt("MissionModeTarget" + i);
			this.Method[i] = PlayerPrefs.GetInt("MissionModeMethod" + i);
			if (this.Target[i] == 0)
			{
				this.NameLabel[i].text = "Kill: Nobody";
			}
			else
			{
				this.NameLabel[i].text = "Kill: " + this.JSON.Students[this.Target[i]].Name;
			}
			string url = string.Concat(new object[]
			{
				"file:///",
				Application.streamingAssetsPath,
				"/Portraits/Student_",
				this.Target[i],
				".png"
			});
			WWW www = new WWW(url);
			this.Portrait[i].mainTexture = www.texture;
			this.MethodLabel[i].text = "By: " + this.MethodNames[this.Method[i]];
			this.DeathSkulls[i].SetActive(false);
		}
	}

	public void HideButtons()
	{
		this.Button[0].SetActive(false);
		this.Button[1].SetActive(false);
		this.Button[2].SetActive(false);
		this.Button[3].SetActive(false);
	}
}
