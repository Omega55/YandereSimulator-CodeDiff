using System;
using UnityEngine;

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

	private void Start()
	{
		this.GradeUpWindow.localScale = Vector3.zero;
		this.Subject[1] = PlayerPrefs.GetInt("Biology");
		this.Subject[2] = PlayerPrefs.GetInt("Chemistry");
		this.Subject[3] = PlayerPrefs.GetInt("Language");
		this.Subject[4] = PlayerPrefs.GetInt("Physical");
		this.Subject[5] = PlayerPrefs.GetInt("Psychology");
		this.DescLabel.text = this.Desc[this.Selected];
		this.UpdateSubjectLabels();
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
		this.UpdateBars();
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
				if (Input.GetKeyDown("p"))
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
					PlayerPrefs.SetInt("Biology", this.Subject[1] + this.SubjectTemp[1]);
					PlayerPrefs.SetInt("Chemistry", this.Subject[2] + this.SubjectTemp[2]);
					PlayerPrefs.SetInt("Language", this.Subject[3] + this.SubjectTemp[3]);
					PlayerPrefs.SetInt("Physical", this.Subject[4] + this.SubjectTemp[4]);
					PlayerPrefs.SetInt("Psychology", this.Subject[5] + this.SubjectTemp[5]);
					for (int i = 0; i < 6; i++)
					{
						this.Subject[i] += this.SubjectTemp[i];
						this.SubjectTemp[i] = 0;
					}
					this.CheckForGradeUp();
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
							if (PlayerPrefs.GetInt("ChemistryGrade") > 0 && this.Poison != null)
							{
								this.Poison.SetActive(true);
							}
							if (PlayerPrefs.GetInt("Scheme_5_Stage") == 7)
							{
								PlayerPrefs.SetInt("Scheme_5_Stage", 100);
								this.PromptBar.ClearButtons();
								this.PromptBar.Label[0].text = "Continue";
								this.PromptBar.UpdateButtons();
								this.CutsceneManager.gameObject.SetActive(true);
								this.Schemes.UpdateInstructions();
								base.gameObject.SetActive(false);
							}
							else
							{
								this.PromptBar.Show = false;
								this.Portal.Proceed = true;
								base.gameObject.SetActive(false);
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
		}
		else
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
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
		if (PlayerPrefs.GetInt("Biology") >= 20 && PlayerPrefs.GetInt("BiologyGrade") < 1)
		{
			PlayerPrefs.SetInt("BiologyGrade", 1);
			this.GradeUpSubject = 1;
			this.GradeUp = true;
			this.Grade = 1;
		}
		else if (PlayerPrefs.GetInt("Chemistry") >= 20 && PlayerPrefs.GetInt("ChemistryGrade") < 1)
		{
			PlayerPrefs.SetInt("ChemistryGrade", 1);
			this.GradeUpSubject = 2;
			this.GradeUp = true;
			this.Grade = 1;
		}
		else if (PlayerPrefs.GetInt("Language") >= 20 && PlayerPrefs.GetInt("LanguageGrade") < 1)
		{
			PlayerPrefs.SetInt("LanguageGrade", 1);
			this.GradeUpSubject = 3;
			this.GradeUp = true;
			this.Grade = 1;
		}
		else if (PlayerPrefs.GetInt("Physical") >= 20 && PlayerPrefs.GetInt("PhysicalGrade") < 1)
		{
			PlayerPrefs.SetInt("PhysicalGrade", 1);
			this.GradeUpSubject = 4;
			this.GradeUp = true;
			this.Grade = 1;
		}
		else if (PlayerPrefs.GetInt("Physical") >= 40 && PlayerPrefs.GetInt("PhysicalGrade") < 2)
		{
			PlayerPrefs.SetInt("PhysicalGrade", 2);
			this.GradeUpSubject = 4;
			this.GradeUp = true;
			this.Grade = 2;
		}
		else if (PlayerPrefs.GetInt("Physical") >= 60 && PlayerPrefs.GetInt("PhysicalGrade") < 3)
		{
			PlayerPrefs.SetInt("PhysicalGrade", 3);
			this.GradeUpSubject = 4;
			this.GradeUp = true;
			this.Grade = 3;
		}
		else if (PlayerPrefs.GetInt("Physical") >= 80 && PlayerPrefs.GetInt("PhysicalGrade") < 4)
		{
			PlayerPrefs.SetInt("PhysicalGrade", 4);
			this.GradeUpSubject = 4;
			this.GradeUp = true;
			this.Grade = 4;
		}
		else if (PlayerPrefs.GetInt("Physical") == 100 && PlayerPrefs.GetInt("PhysicalGrade") < 5)
		{
			PlayerPrefs.SetInt("PhysicalGrade", 5);
			this.GradeUpSubject = 4;
			this.GradeUp = true;
			this.Grade = 5;
		}
		else if (PlayerPrefs.GetInt("Psychology") >= 20 && PlayerPrefs.GetInt("PsychologyGrade") < 1)
		{
			PlayerPrefs.SetInt("PsychologyGrade", 1);
			this.GradeUpSubject = 5;
			this.GradeUp = true;
			this.Grade = 1;
		}
	}

	private void GivePoints()
	{
		PlayerPrefs.SetInt("BiologyGrade", 0);
		PlayerPrefs.SetInt("ChemistryGrade", 0);
		PlayerPrefs.SetInt("LanguageGrade", 0);
		PlayerPrefs.SetInt("PhysicalGrade", 0);
		PlayerPrefs.SetInt("PsychologyGrade", 0);
		PlayerPrefs.SetInt("Biology", 19);
		PlayerPrefs.SetInt("Chemistry", 19);
		PlayerPrefs.SetInt("Language", 19);
		PlayerPrefs.SetInt("Physical", 19);
		PlayerPrefs.SetInt("Psychology", 19);
		this.Subject[1] = PlayerPrefs.GetInt("Biology");
		this.Subject[2] = PlayerPrefs.GetInt("Chemistry");
		this.Subject[3] = PlayerPrefs.GetInt("Language");
		this.Subject[4] = PlayerPrefs.GetInt("Physical");
		this.Subject[5] = PlayerPrefs.GetInt("Psychology");
		this.UpdateBars();
	}

	private void MaxPhysical()
	{
		PlayerPrefs.SetInt("PhysicalGrade", 0);
		PlayerPrefs.SetInt("Physical", 99);
		this.Subject[4] = PlayerPrefs.GetInt("Physical");
		this.UpdateBars();
	}
}
