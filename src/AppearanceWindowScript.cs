using System;
using UnityEngine;

[Serializable]
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

	public virtual void Start()
	{
		this.Window.localScale = new Vector3((float)0, (float)0, (float)0);
		for (int i = 1; i < 10; i++)
		{
			if (PlayerPrefs.GetInt("SuitorCheck" + i) == 1)
			{
				this.Checks[i].active = true;
			}
			else
			{
				this.Checks[i].active = false;
			}
		}
	}

	public virtual void Update()
	{
		if (!this.Show)
		{
			if (this.Window.gameObject.active)
			{
				if (this.Window.localScale.x > 0.1f)
				{
					this.Window.localScale = Vector3.Lerp(this.Window.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				}
				else
				{
					this.Window.localScale = new Vector3((float)0, (float)0, (float)0);
					this.Window.gameObject.active = false;
				}
			}
		}
		else
		{
			this.Window.localScale = Vector3.Lerp(this.Window.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
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
						if (!this.Checks[1].active)
						{
							PlayerPrefs.SetInt("CustomSuitorHair", 22);
							PlayerPrefs.SetInt("SuitorCheck1", 1);
							PlayerPrefs.SetInt("SuitorCheck2", 0);
							this.Checks[1].active = true;
							this.Checks[2].active = false;
						}
						else
						{
							PlayerPrefs.SetInt("CustomSuitorHair", 0);
							PlayerPrefs.SetInt("SuitorCheck1", 0);
							this.Checks[1].active = false;
						}
					}
					else if (this.Selected == 2)
					{
						if (!this.Checks[2].active)
						{
							PlayerPrefs.SetInt("CustomSuitorHair", 21);
							PlayerPrefs.SetInt("SuitorCheck1", 0);
							PlayerPrefs.SetInt("SuitorCheck2", 1);
							this.Checks[1].active = false;
							this.Checks[2].active = true;
						}
						else
						{
							PlayerPrefs.SetInt("CustomSuitorHair", 0);
							PlayerPrefs.SetInt("SuitorCheck2", 0);
							this.Checks[2].active = false;
						}
					}
					else if (this.Selected == 3)
					{
						if (!this.Checks[3].active)
						{
							PlayerPrefs.SetInt("CustomSuitorAccessory", 3);
							PlayerPrefs.SetInt("SuitorCheck3", 1);
							PlayerPrefs.SetInt("SuitorCheck4", 0);
							this.Checks[3].active = true;
							this.Checks[4].active = false;
						}
						else
						{
							PlayerPrefs.SetInt("CustomSuitorAccessory", 0);
							PlayerPrefs.SetInt("SuitorCheck3", 0);
							this.Checks[3].active = false;
						}
					}
					else if (this.Selected == 4)
					{
						if (!this.Checks[4].active)
						{
							PlayerPrefs.SetInt("CustomSuitorAccessory", 1);
							PlayerPrefs.SetInt("SuitorCheck3", 0);
							PlayerPrefs.SetInt("SuitorCheck4", 1);
							this.Checks[3].active = false;
							this.Checks[4].active = true;
						}
						else
						{
							PlayerPrefs.SetInt("CustomSuitorAccessory", 0);
							PlayerPrefs.SetInt("SuitorCheck4", 0);
							this.Checks[4].active = false;
						}
					}
					else if (this.Selected == 5)
					{
						if (!this.Checks[5].active)
						{
							PlayerPrefs.SetInt("CustomSuitorBlonde", 1);
							PlayerPrefs.SetInt("SuitorCheck5", 1);
							this.Checks[5].active = true;
						}
						else
						{
							PlayerPrefs.SetInt("CustomSuitorBlonde", 0);
							PlayerPrefs.SetInt("SuitorCheck5", 0);
							this.Checks[5].active = false;
						}
					}
					else if (this.Selected == 6)
					{
						if (!this.Checks[6].active)
						{
							PlayerPrefs.SetInt("CustomSuitorEyewear", 6);
							PlayerPrefs.SetInt("SuitorCheck6", 1);
							PlayerPrefs.SetInt("SuitorCheck8", 0);
							this.Checks[6].active = true;
							this.Checks[8].active = false;
						}
						else
						{
							PlayerPrefs.SetInt("CustomSuitorEyewear", 0);
							PlayerPrefs.SetInt("SuitorCheck6", 0);
							this.Checks[6].active = false;
						}
					}
					else if (this.Selected == 7)
					{
						if (!this.Checks[7].active)
						{
							PlayerPrefs.SetInt("CustomSuitorJewelry", 1);
							PlayerPrefs.SetInt("SuitorCheck7", 1);
							this.Checks[7].active = true;
						}
						else
						{
							PlayerPrefs.SetInt("CustomSuitorJewelry", 0);
							PlayerPrefs.SetInt("SuitorCheck7", 0);
							this.Checks[7].active = false;
						}
					}
					else if (this.Selected == 8)
					{
						if (!this.Checks[8].active)
						{
							PlayerPrefs.SetInt("CustomSuitorEyewear", 7);
							PlayerPrefs.SetInt("SuitorCheck6", 0);
							PlayerPrefs.SetInt("SuitorCheck8", 1);
							this.Checks[6].active = false;
							this.Checks[8].active = true;
						}
						else
						{
							PlayerPrefs.SetInt("CustomSuitorEyewear", 0);
							PlayerPrefs.SetInt("SuitorCheck8", 0);
							this.Checks[8].active = false;
						}
					}
					else if (this.Selected == 9)
					{
						if (!this.Checks[9].active)
						{
							PlayerPrefs.SetInt("CustomSuitorTan", 1);
							PlayerPrefs.SetInt("SuitorCheck9", 1);
							this.Checks[9].active = true;
						}
						else
						{
							PlayerPrefs.SetInt("CustomSuitorTan", 0);
							PlayerPrefs.SetInt("SuitorCheck9", 0);
							this.Checks[9].active = false;
						}
					}
					else if (this.Selected == 11)
					{
						PlayerPrefs.SetInt("CustomSuitor", 1);
						this.PromptBar.ClearButtons();
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = false;
						this.Yandere.Interaction = 18;
						this.Yandere.TalkTimer = (float)3;
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

	public virtual void UpdateHighlight()
	{
		if (this.Selected < 1)
		{
			this.Selected = 11;
		}
		else if (this.Selected > 11)
		{
			this.Selected = 1;
		}
		int num = 300 - 50 * this.Selected;
		Vector3 localPosition = this.Highlight.transform.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.Highlight.transform.localPosition = localPosition;
	}

	public virtual void Exit()
	{
		this.Selected = 1;
		this.UpdateHighlight();
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
		this.Show = false;
	}

	public virtual void Main()
	{
	}
}
