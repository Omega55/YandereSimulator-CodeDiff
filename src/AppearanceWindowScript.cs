using System;
using UnityEngine;

public class AppearanceWindowScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public Transform Highlight;

	public Transform Window;

	public GameObject[] Checks;

	public int Selected;

	public bool Ready;

	public bool Show;

	private void Start()
	{
		this.Window.localScale = Vector3.zero;
		for (int i = 1; i < 10; i++)
		{
			this.Checks[i].SetActive(PlayerPrefs.GetInt("SuitorCheck" + i.ToString()) == 1);
		}
	}

	private void Update()
	{
		if (!this.Show)
		{
			if (this.Window.gameObject.activeInHierarchy)
			{
				if (this.Window.localScale.x > 0.1f)
				{
					this.Window.localScale = Vector3.Lerp(this.Window.localScale, Vector3.zero, Time.deltaTime * 10f);
				}
				else
				{
					this.Window.localScale = Vector3.zero;
					this.Window.gameObject.SetActive(false);
				}
			}
		}
		else
		{
			this.Window.localScale = Vector3.Lerp(this.Window.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (this.Ready)
			{
				if (this.InputManager.TappedUp)
				{
					this.Selected--;
					if (this.Selected == 10)
					{
						this.Selected = 9;
					}
					this.UpdateHighlight();
				}
				if (this.InputManager.TappedDown)
				{
					this.Selected++;
					if (this.Selected == 10)
					{
						this.Selected = 11;
					}
					this.UpdateHighlight();
				}
				if (Input.GetButtonDown("A"))
				{
					if (this.Selected == 1)
					{
						if (!this.Checks[1].activeInHierarchy)
						{
							PlayerPrefs.SetInt("CustomSuitorHair", 22);
							PlayerPrefs.SetInt("SuitorCheck1", 1);
							PlayerPrefs.SetInt("SuitorCheck2", 0);
							this.Checks[1].SetActive(true);
							this.Checks[2].SetActive(false);
						}
						else
						{
							PlayerPrefs.SetInt("CustomSuitorHair", 0);
							PlayerPrefs.SetInt("SuitorCheck1", 0);
							this.Checks[1].SetActive(false);
						}
					}
					else if (this.Selected == 2)
					{
						if (!this.Checks[2].activeInHierarchy)
						{
							PlayerPrefs.SetInt("CustomSuitorHair", 21);
							PlayerPrefs.SetInt("SuitorCheck1", 0);
							PlayerPrefs.SetInt("SuitorCheck2", 1);
							this.Checks[1].SetActive(false);
							this.Checks[2].SetActive(true);
						}
						else
						{
							PlayerPrefs.SetInt("CustomSuitorHair", 0);
							PlayerPrefs.SetInt("SuitorCheck2", 0);
							this.Checks[2].SetActive(false);
						}
					}
					else if (this.Selected == 3)
					{
						if (!this.Checks[3].activeInHierarchy)
						{
							PlayerPrefs.SetInt("CustomSuitorAccessory", 3);
							PlayerPrefs.SetInt("SuitorCheck3", 1);
							PlayerPrefs.SetInt("SuitorCheck4", 0);
							this.Checks[3].SetActive(true);
							this.Checks[4].SetActive(false);
						}
						else
						{
							PlayerPrefs.SetInt("CustomSuitorAccessory", 0);
							PlayerPrefs.SetInt("SuitorCheck3", 0);
							this.Checks[3].SetActive(false);
						}
					}
					else if (this.Selected == 4)
					{
						if (!this.Checks[4].activeInHierarchy)
						{
							PlayerPrefs.SetInt("CustomSuitorAccessory", 1);
							PlayerPrefs.SetInt("SuitorCheck3", 0);
							PlayerPrefs.SetInt("SuitorCheck4", 1);
							this.Checks[3].SetActive(false);
							this.Checks[4].SetActive(true);
						}
						else
						{
							PlayerPrefs.SetInt("CustomSuitorAccessory", 0);
							PlayerPrefs.SetInt("SuitorCheck4", 0);
							this.Checks[4].SetActive(false);
						}
					}
					else if (this.Selected == 5)
					{
						if (!this.Checks[5].activeInHierarchy)
						{
							PlayerPrefs.SetInt("CustomSuitorBlonde", 1);
							PlayerPrefs.SetInt("SuitorCheck5", 1);
							this.Checks[5].SetActive(true);
						}
						else
						{
							PlayerPrefs.SetInt("CustomSuitorBlonde", 0);
							PlayerPrefs.SetInt("SuitorCheck5", 0);
							this.Checks[5].SetActive(false);
						}
					}
					else if (this.Selected == 6)
					{
						if (!this.Checks[6].activeInHierarchy)
						{
							PlayerPrefs.SetInt("CustomSuitorEyewear", 6);
							PlayerPrefs.SetInt("SuitorCheck6", 1);
							PlayerPrefs.SetInt("SuitorCheck8", 0);
							this.Checks[6].SetActive(true);
							this.Checks[8].SetActive(false);
						}
						else
						{
							PlayerPrefs.SetInt("CustomSuitorEyewear", 0);
							PlayerPrefs.SetInt("SuitorCheck6", 0);
							this.Checks[6].SetActive(false);
						}
					}
					else if (this.Selected == 7)
					{
						if (!this.Checks[7].activeInHierarchy)
						{
							PlayerPrefs.SetInt("CustomSuitorJewelry", 1);
							PlayerPrefs.SetInt("SuitorCheck7", 1);
							this.Checks[7].SetActive(true);
						}
						else
						{
							PlayerPrefs.SetInt("CustomSuitorJewelry", 0);
							PlayerPrefs.SetInt("SuitorCheck7", 0);
							this.Checks[7].SetActive(false);
						}
					}
					else if (this.Selected == 8)
					{
						if (!this.Checks[8].activeInHierarchy)
						{
							PlayerPrefs.SetInt("CustomSuitorEyewear", 7);
							PlayerPrefs.SetInt("SuitorCheck6", 0);
							PlayerPrefs.SetInt("SuitorCheck8", 1);
							this.Checks[6].SetActive(false);
							this.Checks[8].SetActive(true);
						}
						else
						{
							PlayerPrefs.SetInt("CustomSuitorEyewear", 0);
							PlayerPrefs.SetInt("SuitorCheck8", 0);
							this.Checks[8].SetActive(false);
						}
					}
					else if (this.Selected == 9)
					{
						if (!this.Checks[9].activeInHierarchy)
						{
							PlayerPrefs.SetInt("CustomSuitorTan", 1);
							PlayerPrefs.SetInt("SuitorCheck9", 1);
							this.Checks[9].SetActive(true);
						}
						else
						{
							PlayerPrefs.SetInt("CustomSuitorTan", 0);
							PlayerPrefs.SetInt("SuitorCheck9", 0);
							this.Checks[9].SetActive(false);
						}
					}
					else if (this.Selected == 11)
					{
						PlayerPrefs.SetInt("CustomSuitor", 1);
						this.PromptBar.ClearButtons();
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = false;
						this.Yandere.Interaction = YandereInteractionType.ChangingAppearance;
						this.Yandere.TalkTimer = 3f;
						this.Ready = false;
						this.Show = false;
					}
				}
			}
			if (Input.GetButtonUp("A"))
			{
				this.Ready = true;
			}
		}
	}

	private void UpdateHighlight()
	{
		if (this.Selected < 1)
		{
			this.Selected = 11;
		}
		else if (this.Selected > 11)
		{
			this.Selected = 1;
		}
		this.Highlight.transform.localPosition = new Vector3(this.Highlight.transform.localPosition.x, 300f - 50f * (float)this.Selected, this.Highlight.transform.localPosition.z);
	}

	private void Exit()
	{
		this.Selected = 1;
		this.UpdateHighlight();
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
		this.Show = false;
	}
}
