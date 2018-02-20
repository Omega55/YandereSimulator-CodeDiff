using System;
using UnityEngine;

public class NoteWindowScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public NoteLockerScript NoteLocker;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public ClockScript Clock;

	public Transform SubHighlight;

	public Transform SubMenu;

	public UISprite[] SlotHighlights;

	public UILabel[] SlotLabels;

	public UILabel[] SubLabels;

	public string[] OriginalText;

	public string[] Subjects;

	public string[] Locations;

	public string[] Times;

	public float[] Hours;

	public bool[] SlotsFilled;

	public int SubSlot;

	public int MeetID;

	public int Slot = 1;

	public float Rotation;

	public float TimeID;

	public int ID;

	public bool Selecting;

	public bool Fade;

	public bool Show;

	private void Start()
	{
		this.SubMenu.transform.localScale = Vector3.zero;
		base.transform.localPosition = new Vector3(455f, -965f, 0f);
		base.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
		this.OriginalText[1] = this.SlotLabels[1].text;
		this.OriginalText[2] = this.SlotLabels[2].text;
		this.OriginalText[3] = this.SlotLabels[3].text;
		this.UpdateHighlights();
		this.UpdateSubLabels();
	}

	private void Update()
	{
		float t = Time.unscaledDeltaTime * 10f;
		if (!this.Show)
		{
			if (this.Rotation > -90f)
			{
				base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(455f, -965f, 0f), t);
				this.Rotation = Mathf.Lerp(this.Rotation, -91f, t);
				base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, this.Rotation);
			}
			else
			{
				base.gameObject.SetActive(false);
			}
		}
		else
		{
			base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, Vector3.zero, t);
			this.Rotation = Mathf.Lerp(this.Rotation, 0f, t);
			base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, this.Rotation);
			if (!this.Selecting)
			{
				if (this.SubMenu.transform.localScale.x > 0.1f)
				{
					this.SubMenu.transform.localScale = Vector3.Lerp(this.SubMenu.transform.localScale, Vector3.zero, t);
				}
				else
				{
					this.SubMenu.transform.localScale = Vector3.zero;
				}
				if (this.InputManager.TappedDown)
				{
					this.Slot++;
					if (this.Slot > 3)
					{
						this.Slot = 1;
					}
					this.UpdateHighlights();
				}
				if (this.InputManager.TappedUp)
				{
					this.Slot--;
					if (this.Slot < 1)
					{
						this.Slot = 3;
					}
					this.UpdateHighlights();
				}
				if (Input.GetButtonDown("A"))
				{
					this.PromptBar.Label[2].text = string.Empty;
					this.PromptBar.UpdateButtons();
					this.Selecting = true;
					this.UpdateSubLabels();
				}
				if (Input.GetButtonDown("B"))
				{
					this.Slot = 1;
					this.UpdateHighlights();
					this.SlotLabels[1].text = this.OriginalText[1];
					this.SlotLabels[2].text = this.OriginalText[2];
					this.SlotLabels[3].text = this.OriginalText[3];
					this.SlotsFilled[1] = false;
					this.SlotsFilled[2] = false;
					this.SlotsFilled[3] = false;
					this.Exit();
				}
				if (Input.GetButtonDown("X") && this.SlotsFilled[1] && this.SlotsFilled[2] && this.SlotsFilled[3])
				{
					this.NoteLocker.MeetID = this.MeetID;
					this.NoteLocker.MeetTime = this.TimeID;
					this.NoteLocker.Prompt.enabled = false;
					this.NoteLocker.CanLeaveNote = false;
					this.NoteLocker.NoteLeft = true;
					if (this.NoteLocker.Student.StudentID == 7 && this.SlotLabels[1].text == this.Subjects[10])
					{
						this.NoteLocker.Success = true;
					}
					if (this.NoteLocker.Student.StudentID == 32 && this.NoteLocker.Student.Bullied && this.SlotLabels[1].text == this.Subjects[6])
					{
						this.NoteLocker.Success = true;
					}
					this.Exit();
				}
			}
			else
			{
				this.SubMenu.transform.localScale = Vector3.Lerp(this.SubMenu.transform.localScale, new Vector3(1f, 1f, 1f), t);
				if (this.InputManager.TappedDown)
				{
					this.SubSlot++;
					if (this.SubSlot > 10)
					{
						this.SubSlot = 1;
					}
					this.SubHighlight.localPosition = new Vector3(this.SubHighlight.localPosition.x, 550f - 100f * (float)this.SubSlot, this.SubHighlight.localPosition.z);
				}
				if (this.InputManager.TappedUp)
				{
					this.SubSlot--;
					if (this.SubSlot < 1)
					{
						this.SubSlot = 10;
					}
					this.SubHighlight.localPosition = new Vector3(this.SubHighlight.localPosition.x, 550f - 100f * (float)this.SubSlot, this.SubHighlight.localPosition.z);
				}
				if (Input.GetButtonDown("A") && this.SubLabels[this.SubSlot].color.a > 0.5f && this.SubLabels[this.SubSlot].text != string.Empty && this.SubLabels[this.SubSlot].text != "??????????")
				{
					this.SlotLabels[this.Slot].text = this.SubLabels[this.SubSlot].text;
					this.SlotsFilled[this.Slot] = true;
					if (this.Slot == 2)
					{
						this.MeetID = this.SubSlot;
					}
					if (this.Slot == 3)
					{
						this.TimeID = this.Hours[this.SubSlot];
					}
					this.CheckForCompletion();
					this.Selecting = false;
					this.SubSlot = 1;
					this.SubHighlight.localPosition = new Vector3(this.SubHighlight.localPosition.x, 450f, this.SubHighlight.localPosition.z);
				}
				if (Input.GetButtonDown("B"))
				{
					this.CheckForCompletion();
					this.Selecting = false;
					this.SubSlot = 1;
					this.SubHighlight.localPosition = new Vector3(this.SubHighlight.localPosition.x, 450f, this.SubHighlight.localPosition.z);
				}
			}
			UISprite uisprite = this.SlotHighlights[this.Slot];
			if (!this.Fade)
			{
				uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, uisprite.color.a + 0.0166666675f);
				if (uisprite.color.a >= 0.5f)
				{
					this.Fade = true;
				}
			}
			else
			{
				uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, uisprite.color.a - 0.0166666675f);
				if (uisprite.color.a <= 0f)
				{
					this.Fade = false;
				}
			}
		}
	}

	private void UpdateHighlights()
	{
		for (int i = 1; i < this.SlotHighlights.Length; i++)
		{
			UISprite uisprite = this.SlotHighlights[i];
			uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 0f);
		}
	}

	private void UpdateSubLabels()
	{
		if (this.Slot == 1)
		{
			this.ID = 1;
			while (this.ID < this.SubLabels.Length)
			{
				UILabel uilabel = this.SubLabels[this.ID];
				uilabel.text = this.Subjects[this.ID];
				uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 1f);
				this.ID++;
			}
			if (!EventGlobals.Event1)
			{
				this.SubLabels[10].text = "??????????";
			}
		}
		else if (this.Slot == 2)
		{
			this.ID = 1;
			while (this.ID < this.SubLabels.Length)
			{
				UILabel uilabel2 = this.SubLabels[this.ID];
				uilabel2.text = this.Locations[this.ID];
				uilabel2.color = new Color(uilabel2.color.r, uilabel2.color.g, uilabel2.color.b, 1f);
				this.ID++;
			}
		}
		else if (this.Slot == 3)
		{
			this.ID = 1;
			while (this.ID < this.SubLabels.Length)
			{
				UILabel uilabel3 = this.SubLabels[this.ID];
				uilabel3.text = this.Times[this.ID];
				uilabel3.color = new Color(uilabel3.color.r, uilabel3.color.g, uilabel3.color.b, 1f);
				this.ID++;
			}
			this.DisableOptions();
		}
	}

	private void CheckForCompletion()
	{
		if (this.SlotsFilled[1] && this.SlotsFilled[2] && this.SlotsFilled[3])
		{
			this.PromptBar.Label[2].text = "Finish";
			this.PromptBar.UpdateButtons();
		}
	}

	private void Exit()
	{
		this.Yandere.Blur.enabled = false;
		this.Yandere.CanMove = true;
		this.Show = false;
		this.Yandere.HUD.alpha = 1f;
		Time.timeScale = 1f;
		this.PromptBar.Label[0].text = string.Empty;
		this.PromptBar.Label[1].text = string.Empty;
		this.PromptBar.Label[2].text = string.Empty;
		this.PromptBar.Label[4].text = string.Empty;
		this.PromptBar.Show = false;
		this.PromptBar.UpdateButtons();
	}

	private void DisableOptions()
	{
		if (this.Clock.HourTime >= 7.25f)
		{
			UILabel uilabel = this.SubLabels[1];
			uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
		}
		if (this.Clock.HourTime >= 7.5f)
		{
			UILabel uilabel2 = this.SubLabels[2];
			uilabel2.color = new Color(uilabel2.color.r, uilabel2.color.g, uilabel2.color.b, 0.5f);
		}
		if (this.Clock.HourTime >= 7.75f)
		{
			UILabel uilabel3 = this.SubLabels[3];
			uilabel3.color = new Color(uilabel3.color.r, uilabel3.color.g, uilabel3.color.b, 0.5f);
		}
		if (this.Clock.HourTime >= 8f)
		{
			UILabel uilabel4 = this.SubLabels[4];
			uilabel4.color = new Color(uilabel4.color.r, uilabel4.color.g, uilabel4.color.b, 0.5f);
		}
		if (this.Clock.HourTime >= 8.25f)
		{
			UILabel uilabel5 = this.SubLabels[5];
			uilabel5.color = new Color(uilabel5.color.r, uilabel5.color.g, uilabel5.color.b, 0.5f);
		}
		if (this.Clock.HourTime >= 15.5f)
		{
			UILabel uilabel6 = this.SubLabels[6];
			uilabel6.color = new Color(uilabel6.color.r, uilabel6.color.g, uilabel6.color.b, 0.5f);
		}
		if (this.Clock.HourTime >= 16f)
		{
			UILabel uilabel7 = this.SubLabels[7];
			uilabel7.color = new Color(uilabel7.color.r, uilabel7.color.g, uilabel7.color.b, 0.5f);
		}
		if (this.Clock.HourTime >= 16.5f)
		{
			UILabel uilabel8 = this.SubLabels[8];
			uilabel8.color = new Color(uilabel8.color.r, uilabel8.color.g, uilabel8.color.b, 0.5f);
		}
		if (this.Clock.HourTime >= 17f)
		{
			UILabel uilabel9 = this.SubLabels[9];
			uilabel9.color = new Color(uilabel9.color.r, uilabel9.color.g, uilabel9.color.b, 0.5f);
		}
		if (this.Clock.HourTime >= 17.5f)
		{
			UILabel uilabel10 = this.SubLabels[10];
			uilabel10.color = new Color(uilabel10.color.r, uilabel10.color.g, uilabel10.color.b, 0.5f);
		}
	}
}
