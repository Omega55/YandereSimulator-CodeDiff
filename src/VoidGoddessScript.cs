using System;
using UnityEngine;

public class VoidGoddessScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public PromptScript Prompt;

	public GameObject NewPortrait;

	public GameObject Portrait;

	public GameObject Goddess;

	public Transform Highlight;

	public Transform Window;

	public Transform Head;

	public UITexture[] Portraits;

	public Animation[] Legs;

	public bool PassingJudgement;

	public bool Follow;

	public int Selected;

	public int Column;

	public int Row;

	public int ID;

	private void Start()
	{
		this.Legs[1]["SpiderLegWiggle"].speed = 1f;
		this.Legs[2]["SpiderLegWiggle"].speed = 0.95f;
		this.Legs[3]["SpiderLegWiggle"].speed = 0.9f;
		this.Legs[4]["SpiderLegWiggle"].speed = 0.85f;
		this.Legs[5]["SpiderLegWiggle"].speed = 0.8f;
		this.Legs[6]["SpiderLegWiggle"].speed = 0.75f;
		this.Legs[7]["SpiderLegWiggle"].speed = 0.7f;
		this.Legs[8]["SpiderLegWiggle"].speed = 0.65f;
		this.ID = 1;
		while (this.ID < 101)
		{
			this.NewPortrait = UnityEngine.Object.Instantiate<GameObject>(this.Portrait, base.transform.position, Quaternion.identity);
			this.NewPortrait.transform.parent = this.Window;
			this.NewPortrait.transform.localScale = new Vector3(1f, 1f, 1f);
			this.NewPortrait.transform.localPosition = new Vector3((float)(-450 + this.Column * 100), (float)(450 - this.Row * 100), 0f);
			this.Portraits[this.ID] = this.NewPortrait.GetComponent<UITexture>();
			if ((this.ID <= 32 || this.ID >= 56) && (this.ID <= 60 || this.ID >= 76) && this.ID <= 97)
			{
				string url = string.Concat(new string[]
				{
					"file:///",
					Application.streamingAssetsPath,
					"/Portraits/Student_",
					this.ID.ToString(),
					".png"
				});
				WWW www = new WWW(url);
				this.NewPortrait.GetComponent<UITexture>().mainTexture = www.texture;
			}
			this.Column++;
			if (this.Column == 10)
			{
				this.Column = 0;
				this.Row++;
			}
			this.ID++;
		}
		this.Window.parent.gameObject.SetActive(false);
		this.Selected = 1;
		this.Column = 0;
		this.Row = 0;
		this.UpdatePortraits();
	}

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Goddess.activeInHierarchy)
			{
				this.Prompt.Label[0].text = "     Pass Judgement";
				this.Prompt.Label[1].text = "     Dismiss";
				this.Prompt.Label[2].text = "     Follow";
				this.Prompt.HideButton[1] = false;
				this.Prompt.HideButton[2] = false;
				this.Prompt.OffsetX[0] = -1f;
				this.Goddess.SetActive(true);
			}
			else
			{
				this.Window.parent.gameObject.SetActive(true);
				this.Prompt.Yandere.CanMove = false;
				this.PassingJudgement = true;
			}
		}
		if (this.Prompt.Circle[1].fillAmount == 0f)
		{
			this.Prompt.Circle[1].fillAmount = 1f;
			this.Prompt.Label[0].text = "     Summon An Ancient Evil";
			this.Prompt.Label[1].text = string.Empty;
			this.Prompt.Label[2].text = string.Empty;
			this.Prompt.HideButton[1] = true;
			this.Prompt.HideButton[2] = true;
			this.Prompt.OffsetX[0] = 0f;
			base.transform.position = new Vector3(-9.5f, 1f, -75f);
			this.Goddess.SetActive(false);
			this.Follow = false;
		}
		if (this.Prompt.Circle[2].fillAmount == 0f)
		{
			this.Prompt.Circle[2].fillAmount = 1f;
			this.Follow = !this.Follow;
		}
		if (this.Follow && Vector3.Distance(this.Prompt.Yandere.transform.position + new Vector3(0f, 1f, 0f), base.transform.position) > 1f)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, this.Prompt.Yandere.transform.position + new Vector3(0f, 1f, 0f), Time.deltaTime);
		}
		if (this.PassingJudgement)
		{
			if (this.InputManager.TappedUp)
			{
				this.Row--;
				this.UpdateHighlight();
			}
			else if (this.InputManager.TappedDown)
			{
				this.Row++;
				this.UpdateHighlight();
			}
			if (this.InputManager.TappedLeft)
			{
				this.Column--;
				this.UpdateHighlight();
			}
			else if (this.InputManager.TappedRight)
			{
				this.Column++;
				this.UpdateHighlight();
			}
			if (Input.GetButtonDown("A"))
			{
				this.StudentManager.DisableStudent(this.Selected);
				this.UpdatePortraits();
			}
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				this.ID = 1;
				while (this.ID < 101)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				this.ID = 1;
				while (this.ID < 21)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.StudentManager.DisableStudent(32);
				this.StudentManager.DisableStudent(33);
				this.StudentManager.DisableStudent(34);
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				this.ID = 21;
				while (this.ID < 26)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				this.ID = 26;
				while (this.ID < 32)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha5))
			{
				this.ID = 56;
				while (this.ID < 61)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha6))
			{
				this.ID = 76;
				while (this.ID < 81)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha7))
			{
				this.ID = 81;
				while (this.ID < 86)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha8))
			{
				this.ID = 86;
				while (this.ID < 90)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha9))
			{
				this.ID = 90;
				while (this.ID < 98)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			if (Input.GetButtonDown("B"))
			{
				this.Window.parent.gameObject.SetActive(false);
				this.Prompt.Yandere.CanMove = true;
				this.PassingJudgement = false;
			}
		}
	}

	private void UpdateHighlight()
	{
		if (this.Row < 0)
		{
			this.Row = 9;
		}
		else if (this.Row > 9)
		{
			this.Row = 0;
		}
		if (this.Column < 0)
		{
			this.Column = 9;
		}
		else if (this.Column > 9)
		{
			this.Column = 0;
		}
		this.Highlight.localPosition = new Vector3((float)(-450 + 100 * this.Column), (float)(450 - 100 * this.Row), this.Highlight.localPosition.z);
		this.Selected = 1 + this.Row * 10 + this.Column;
	}

	private void UpdatePortraits()
	{
		this.ID = 1;
		while (this.ID < 101)
		{
			if (this.StudentManager.Students[this.ID] != null)
			{
				if (this.StudentManager.Students[this.ID].gameObject.activeInHierarchy)
				{
					this.Portraits[this.ID].color = new Color(1f, 1f, 1f, 1f);
				}
				else
				{
					this.Portraits[this.ID].color = new Color(1f, 1f, 1f, 0.5f);
				}
			}
			else
			{
				this.Portraits[this.ID].color = new Color(1f, 1f, 1f, 0.5f);
			}
			this.ID++;
		}
	}
}
