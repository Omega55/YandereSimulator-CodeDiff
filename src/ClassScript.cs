using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassScript : MonoBehaviour
{
	public CutsceneManagerScript CutsceneManager;

	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public SchemesScript Schemes;

	public PortalScript Portal;

	public GameObject Poison;

	public UILabel StudyPointsLabel;

	public UILabel[] SubjectLabels;

	public UILabel GradeUpDesc;

	public UILabel GradeUpName;

	public UILabel DescLabel;

	public UISprite Darkness;

	public Transform[] Subject1Bars;

	public Transform[] Subject2Bars;

	public Transform[] Subject3Bars;

	public Transform[] Subject4Bars;

	public Transform[] Subject5Bars;

	public string[] Subject1GradeText;

	public string[] Subject2GradeText;

	public string[] Subject3GradeText;

	public string[] Subject4GradeText;

	public string[] Subject5GradeText;

	public Transform GradeUpWindow;

	public Transform Highlight;

	public int[] SubjectTemp;

	public int[] Subject;

	public string[] Desc;

	public int GradeUpSubject;

	public int StudyPoints;

	public int Selected;

	public int Grade;

	public bool GradeUp;

	public bool Show;

	public int Biology;

	public int Chemistry;

	public int Language;

	public int Physical;

	public int Psychology;

	public int BiologyGrade;

	public int ChemistryGrade;

	public int LanguageGrade;

	public int PhysicalGrade;

	public int PsychologyGrade;

	public int BiologyBonus;

	public int ChemistryBonus;

	public int LanguageBonus;

	public int PhysicalBonus;

	public int PsychologyBonus;

	public int Seduction;

	public int Numbness;

	public int Social;

	public int Stealth;

	public int Speed;

	public int Enlightenment;

	public int SpeedBonus;

	public int SocialBonus;

	public int StealthBonus;

	public int SeductionBonus;

	public int NumbnessBonus;

	public int EnlightenmentBonus;

	private void Start()
	{
		this.GetStats();
		if (SceneManager.GetActiveScene().name != "SchoolScene")
		{
			base.enabled = false;
			return;
		}
		this.GradeUpWindow.localScale = Vector3.zero;
		this.Subject[1] = this.Biology;
		this.Subject[2] = this.Chemistry;
		this.Subject[3] = this.Language;
		this.Subject[4] = this.Physical;
		this.Subject[5] = this.Psychology;
		this.DescLabel.text = this.Desc[this.Selected];
		this.UpdateSubjectLabels();
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
		this.UpdateBars();
	}

	public void GetStats()
	{
		Debug.Log("The Class script just grabbed all the stats.");
		this.Biology = ClassGlobals.Biology;
		this.Chemistry = ClassGlobals.Chemistry;
		this.Language = ClassGlobals.Language;
		this.Physical = ClassGlobals.Physical;
		this.Psychology = ClassGlobals.Psychology;
		this.BiologyGrade = ClassGlobals.BiologyGrade;
		this.ChemistryGrade = ClassGlobals.ChemistryGrade;
		this.LanguageGrade = ClassGlobals.LanguageGrade;
		this.PhysicalGrade = ClassGlobals.PhysicalGrade;
		this.PsychologyGrade = ClassGlobals.PsychologyGrade;
		this.BiologyBonus = ClassGlobals.BiologyBonus;
		this.ChemistryBonus = ClassGlobals.ChemistryBonus;
		this.LanguageBonus = ClassGlobals.LanguageBonus;
		this.PhysicalBonus = ClassGlobals.PhysicalBonus;
		this.PsychologyBonus = ClassGlobals.PsychologyBonus;
		this.Seduction = PlayerGlobals.Seduction;
		this.Numbness = PlayerGlobals.Numbness;
		this.Enlightenment = PlayerGlobals.Enlightenment;
		this.SpeedBonus = PlayerGlobals.SpeedBonus;
		this.SocialBonus = PlayerGlobals.SocialBonus;
		this.StealthBonus = PlayerGlobals.StealthBonus;
		this.SeductionBonus = PlayerGlobals.SeductionBonus;
		this.NumbnessBonus = PlayerGlobals.NumbnessBonus;
		this.EnlightenmentBonus = PlayerGlobals.EnlightenmentBonus;
	}

	private void Update()
	{
		if (this.Show)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a - Time.deltaTime);
			if (this.Darkness.color.a <= 0f)
			{
				if (Input.GetKeyDown(KeyCode.Backslash))
				{
					this.GivePoints();
				}
				if (Input.GetKeyDown(KeyCode.P))
				{
					this.MaxPhysical();
				}
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 0f);
				if (this.InputManager.TappedDown)
				{
					this.Selected++;
					if (this.Selected > 5)
					{
						this.Selected = 1;
					}
					this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 375f - 125f * (float)this.Selected, this.Highlight.localPosition.z);
					this.DescLabel.text = this.Desc[this.Selected];
					this.UpdateSubjectLabels();
				}
				if (this.InputManager.TappedUp)
				{
					this.Selected--;
					if (this.Selected < 1)
					{
						this.Selected = 5;
					}
					this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 375f - 125f * (float)this.Selected, this.Highlight.localPosition.z);
					this.DescLabel.text = this.Desc[this.Selected];
					this.UpdateSubjectLabels();
				}
				if (this.InputManager.TappedRight && this.StudyPoints > 0 && this.Subject[this.Selected] + this.SubjectTemp[this.Selected] < 100)
				{
					this.SubjectTemp[this.Selected]++;
					this.StudyPoints--;
					this.UpdateLabel();
					this.UpdateBars();
				}
				if (this.InputManager.TappedLeft && this.SubjectTemp[this.Selected] > 0)
				{
					this.SubjectTemp[this.Selected]--;
					this.StudyPoints++;
					this.UpdateLabel();
					this.UpdateBars();
				}
				if (Input.GetButtonDown("A") && this.StudyPoints == 0)
				{
					this.Show = false;
					this.PromptBar.ClearButtons();
					this.PromptBar.Show = false;
					this.Biology = this.Subject[1] + this.SubjectTemp[1];
					this.Chemistry = this.Subject[2] + this.SubjectTemp[2];
					this.Language = this.Subject[3] + this.SubjectTemp[3];
					this.Physical = this.Subject[4] + this.SubjectTemp[4];
					this.Psychology = this.Subject[5] + this.SubjectTemp[5];
					for (int i = 0; i < 6; i++)
					{
						this.Subject[i] += this.SubjectTemp[i];
						this.SubjectTemp[i] = 0;
					}
					this.CheckForGradeUp();
					return;
				}
			}
		}
		else
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
			if (this.Darkness.color.a >= 1f)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
				if (!this.GradeUp)
				{
					if (this.GradeUpWindow.localScale.x > 0.1f)
					{
						this.GradeUpWindow.localScale = Vector3.Lerp(this.GradeUpWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
					}
					else
					{
						this.GradeUpWindow.localScale = Vector3.zero;
					}
					if (this.GradeUpWindow.localScale.x < 0.01f)
					{
						this.GradeUpWindow.localScale = Vector3.zero;
						this.CheckForGradeUp();
						if (!this.GradeUp)
						{
							if (this.ChemistryGrade > 0 && this.Poison != null)
							{
								this.Poison.SetActive(true);
							}
							Debug.Log("CutsceneManager.Scheme is: " + this.CutsceneManager.Scheme);
							if (this.CutsceneManager.Scheme > 0)
							{
								SchemeGlobals.SetSchemeStage(this.CutsceneManager.Scheme, 100);
								this.PromptBar.ClearButtons();
								this.PromptBar.Label[0].text = "Continue";
								this.PromptBar.UpdateButtons();
								this.CutsceneManager.gameObject.SetActive(true);
								this.Schemes.UpdateInstructions();
								base.gameObject.SetActive(false);
								return;
							}
							if (!this.Portal.FadeOut)
							{
								this.Portal.Yandere.PhysicalGrade = this.PhysicalGrade;
								this.PromptBar.Show = false;
								this.Portal.Proceed = true;
								base.gameObject.SetActive(false);
								return;
							}
						}
					}
				}
				else
				{
					if (this.GradeUpWindow.localScale.x == 0f)
					{
						if (this.GradeUpSubject == 1)
						{
							this.GradeUpName.text = "BIOLOGY RANK UP";
							this.GradeUpDesc.text = this.Subject1GradeText[this.Grade];
						}
						else if (this.GradeUpSubject == 2)
						{
							this.GradeUpName.text = "CHEMISTRY RANK UP";
							this.GradeUpDesc.text = this.Subject2GradeText[this.Grade];
						}
						else if (this.GradeUpSubject == 3)
						{
							this.GradeUpName.text = "LANGUAGE RANK UP";
							this.GradeUpDesc.text = this.Subject3GradeText[this.Grade];
						}
						else if (this.GradeUpSubject == 4)
						{
							this.GradeUpName.text = "PHYSICAL RANK UP";
							this.GradeUpDesc.text = this.Subject4GradeText[this.Grade];
						}
						else if (this.GradeUpSubject == 5)
						{
							this.GradeUpName.text = "PSYCHOLOGY RANK UP";
							this.GradeUpDesc.text = this.Subject5GradeText[this.Grade];
						}
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[0].text = "Continue";
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = true;
					}
					else if (this.GradeUpWindow.localScale.x > 0.99f && Input.GetButtonDown("A"))
					{
						this.PromptBar.ClearButtons();
						this.GradeUp = false;
					}
					this.GradeUpWindow.localScale = Vector3.Lerp(this.GradeUpWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				}
			}
		}
	}

	private void UpdateSubjectLabels()
	{
		for (int i = 1; i < 6; i++)
		{
			this.SubjectLabels[i].color = new Color(0f, 0f, 0f, 1f);
		}
		this.SubjectLabels[this.Selected].color = new Color(1f, 1f, 1f, 1f);
	}

	public void UpdateLabel()
	{
		this.StudyPointsLabel.text = "STUDY POINTS: " + this.StudyPoints;
		if (this.StudyPoints == 0)
		{
			this.PromptBar.Label[0].text = "Confirm";
			this.PromptBar.UpdateButtons();
			return;
		}
		this.PromptBar.Label[0].text = string.Empty;
		this.PromptBar.UpdateButtons();
	}

	private void UpdateBars()
	{
		for (int i = 1; i < 6; i++)
		{
			Transform transform = this.Subject1Bars[i];
			if (this.Subject[1] + this.SubjectTemp[1] > (i - 1) * 20)
			{
				transform.localScale = new Vector3(-((float)((i - 1) * 20 - (this.Subject[1] + this.SubjectTemp[1])) / 20f), transform.localScale.y, transform.localScale.z);
				if (transform.localScale.x > 1f)
				{
					transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
				}
			}
			else
			{
				transform.localScale = new Vector3(0f, transform.localScale.y, transform.localScale.z);
			}
		}
		for (int j = 1; j < 6; j++)
		{
			Transform transform2 = this.Subject2Bars[j];
			if (this.Subject[2] + this.SubjectTemp[2] > (j - 1) * 20)
			{
				transform2.localScale = new Vector3(-((float)((j - 1) * 20 - (this.Subject[2] + this.SubjectTemp[2])) / 20f), transform2.localScale.y, transform2.localScale.z);
				if (transform2.localScale.x > 1f)
				{
					transform2.localScale = new Vector3(1f, transform2.localScale.y, transform2.localScale.z);
				}
			}
			else
			{
				transform2.localScale = new Vector3(0f, transform2.localScale.y, transform2.localScale.z);
			}
		}
		for (int k = 1; k < 6; k++)
		{
			Transform transform3 = this.Subject3Bars[k];
			if (this.Subject[3] + this.SubjectTemp[3] > (k - 1) * 20)
			{
				transform3.localScale = new Vector3(-((float)((k - 1) * 20 - (this.Subject[3] + this.SubjectTemp[3])) / 20f), transform3.localScale.y, transform3.localScale.z);
				if (transform3.localScale.x > 1f)
				{
					transform3.localScale = new Vector3(1f, transform3.localScale.y, transform3.localScale.z);
				}
			}
			else
			{
				transform3.localScale = new Vector3(0f, transform3.localScale.y, transform3.localScale.z);
			}
		}
		for (int l = 1; l < 6; l++)
		{
			Transform transform4 = this.Subject4Bars[l];
			if (this.Subject[4] + this.SubjectTemp[4] > (l - 1) * 20)
			{
				transform4.localScale = new Vector3(-((float)((l - 1) * 20 - (this.Subject[4] + this.SubjectTemp[4])) / 20f), transform4.localScale.y, transform4.localScale.z);
				if (transform4.localScale.x > 1f)
				{
					transform4.localScale = new Vector3(1f, transform4.localScale.y, transform4.localScale.z);
				}
			}
			else
			{
				transform4.localScale = new Vector3(0f, transform4.localScale.y, transform4.localScale.z);
			}
		}
		for (int m = 1; m < 6; m++)
		{
			Transform transform5 = this.Subject5Bars[m];
			if (this.Subject[5] + this.SubjectTemp[5] > (m - 1) * 20)
			{
				transform5.localScale = new Vector3(-((float)((m - 1) * 20 - (this.Subject[5] + this.SubjectTemp[5])) / 20f), transform5.localScale.y, transform5.localScale.z);
				if (transform5.localScale.x > 1f)
				{
					transform5.localScale = new Vector3(1f, transform5.localScale.y, transform5.localScale.z);
				}
			}
			else
			{
				transform5.localScale = new Vector3(0f, transform5.localScale.y, transform5.localScale.z);
			}
		}
	}

	private void CheckForGradeUp()
	{
		if (this.Biology >= 20 && this.BiologyGrade < 1)
		{
			this.BiologyGrade = 1;
			this.GradeUpSubject = 1;
			this.GradeUp = true;
			this.Grade = 1;
			return;
		}
		if (this.Chemistry >= 20 && this.ChemistryGrade < 1)
		{
			this.ChemistryGrade = 1;
			this.GradeUpSubject = 2;
			this.GradeUp = true;
			this.Grade = 1;
			return;
		}
		if (this.Language >= 20 && this.LanguageGrade < 1)
		{
			this.LanguageGrade = 1;
			this.GradeUpSubject = 3;
			this.GradeUp = true;
			this.Grade = 1;
			return;
		}
		if (this.Physical >= 20 && this.PhysicalGrade < 1)
		{
			this.PhysicalGrade = 1;
			this.GradeUpSubject = 4;
			this.GradeUp = true;
			this.Grade = 1;
			return;
		}
		if (this.Physical >= 40 && this.PhysicalGrade < 2)
		{
			this.PhysicalGrade = 2;
			this.GradeUpSubject = 4;
			this.GradeUp = true;
			this.Grade = 2;
			return;
		}
		if (this.Physical >= 60 && this.PhysicalGrade < 3)
		{
			this.PhysicalGrade = 3;
			this.GradeUpSubject = 4;
			this.GradeUp = true;
			this.Grade = 3;
			return;
		}
		if (this.Physical >= 80 && this.PhysicalGrade < 4)
		{
			this.PhysicalGrade = 4;
			this.GradeUpSubject = 4;
			this.GradeUp = true;
			this.Grade = 4;
			return;
		}
		if (this.Physical == 100 && this.PhysicalGrade < 5)
		{
			this.PhysicalGrade = 5;
			this.GradeUpSubject = 4;
			this.GradeUp = true;
			this.Grade = 5;
			return;
		}
		if (this.Psychology >= 20 && this.PsychologyGrade < 1)
		{
			this.PsychologyGrade = 1;
			this.GradeUpSubject = 5;
			this.GradeUp = true;
			this.Grade = 1;
		}
	}

	private void GivePoints()
	{
		this.BiologyGrade = 0;
		this.ChemistryGrade = 0;
		this.LanguageGrade = 0;
		this.PhysicalGrade = 0;
		this.PsychologyGrade = 0;
		this.Biology = 19;
		this.Chemistry = 19;
		this.Language = 19;
		this.Physical = 19;
		this.Psychology = 19;
		this.Subject[1] = this.Biology;
		this.Subject[2] = this.Chemistry;
		this.Subject[3] = this.Language;
		this.Subject[4] = this.Physical;
		this.Subject[5] = this.Psychology;
		this.UpdateBars();
	}

	private void MaxPhysical()
	{
		this.PhysicalGrade = 0;
		this.Physical = 99;
		this.Subject[4] = this.Physical;
		this.UpdateBars();
	}
}
