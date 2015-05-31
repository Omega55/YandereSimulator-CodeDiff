using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class LetterWindowScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public LeaveNoteScript Origin;

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

	public int Slot;

	public float Rotation;

	public float TimeID;

	public int ID;

	public bool Selecting;

	public bool Fade;

	public bool Show;

	public LetterWindowScript()
	{
		this.Slot = 1;
	}

	public virtual void Start()
	{
		this.SubMenu.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		this.transform.localPosition = new Vector3((float)455, (float)-960, (float)0);
		this.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)-90);
		this.OriginalText[1] = this.SlotLabels[1].text;
		this.OriginalText[2] = this.SlotLabels[2].text;
		this.OriginalText[3] = this.SlotLabels[3].text;
		this.UpdateHighlights();
	}

	public virtual void Update()
	{
		if (!this.Show)
		{
			this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3((float)455, (float)-960, (float)0), 0.166666672f);
			this.Rotation = Mathf.Lerp(this.Rotation, (float)-90, 0.166666672f);
			float rotation = this.Rotation;
			Vector3 localEulerAngles = this.transform.localEulerAngles;
			float num = localEulerAngles.z = rotation;
			Vector3 vector = this.transform.localEulerAngles = localEulerAngles;
		}
		else
		{
			this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3((float)0, (float)0, (float)0), 0.166666672f);
			this.Rotation = Mathf.Lerp(this.Rotation, (float)0, 0.166666672f);
			float rotation2 = this.Rotation;
			Vector3 localEulerAngles2 = this.transform.localEulerAngles;
			float num2 = localEulerAngles2.z = rotation2;
			Vector3 vector2 = this.transform.localEulerAngles = localEulerAngles2;
			if (!this.Selecting)
			{
				this.SubMenu.transform.localScale = Vector3.Lerp(this.SubMenu.transform.localScale, new Vector3((float)0, (float)0, (float)0), 0.166666672f);
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
					this.Origin.MeetID = this.MeetID;
					this.Origin.MeetTime = this.TimeID;
					this.Origin.Prompt.enabled = false;
					this.Origin.CanLeaveNote = false;
					this.Origin.NoteLeft = true;
					if (this.SlotLabels[1].text == this.Subjects[10])
					{
						this.Origin.Success = true;
					}
					this.Exit();
				}
			}
			else
			{
				this.SubMenu.transform.localScale = Vector3.Lerp(this.SubMenu.transform.localScale, new Vector3((float)1, (float)1, (float)1), 0.166666672f);
				if (this.InputManager.TappedDown)
				{
					this.SubSlot++;
					if (this.SubSlot > 10)
					{
						this.SubSlot = 1;
					}
					int num3 = 550 - 100 * this.SubSlot;
					Vector3 localPosition = this.SubHighlight.localPosition;
					float num4 = localPosition.y = (float)num3;
					Vector3 vector3 = this.SubHighlight.localPosition = localPosition;
				}
				if (this.InputManager.TappedUp)
				{
					this.SubSlot--;
					if (this.SubSlot < 1)
					{
						this.SubSlot = 10;
					}
					int num5 = 550 - 100 * this.SubSlot;
					Vector3 localPosition2 = this.SubHighlight.localPosition;
					float num6 = localPosition2.y = (float)num5;
					Vector3 vector4 = this.SubHighlight.localPosition = localPosition2;
				}
				if (Input.GetButtonDown("A") && this.SubLabels[this.SubSlot].color.a > 0.5f)
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
					int num7 = 450;
					Vector3 localPosition3 = this.SubHighlight.localPosition;
					float num8 = localPosition3.y = (float)num7;
					Vector3 vector5 = this.SubHighlight.localPosition = localPosition3;
				}
				if (Input.GetButtonDown("B"))
				{
					this.CheckForCompletion();
					this.Selecting = false;
					this.SubSlot = 1;
					int num9 = 450;
					Vector3 localPosition4 = this.SubHighlight.localPosition;
					float num10 = localPosition4.y = (float)num9;
					Vector3 vector6 = this.SubHighlight.localPosition = localPosition4;
				}
			}
			if (!this.Fade)
			{
				float a = this.SlotHighlights[this.Slot].color.a + 0.0166666675f;
				Color color = this.SlotHighlights[this.Slot].color;
				float num11 = color.a = a;
				Color color2 = this.SlotHighlights[this.Slot].color = color;
				if (this.SlotHighlights[this.Slot].color.a >= 0.5f)
				{
					this.Fade = true;
				}
			}
			else
			{
				float a2 = this.SlotHighlights[this.Slot].color.a - 0.0166666675f;
				Color color3 = this.SlotHighlights[this.Slot].color;
				float num12 = color3.a = a2;
				Color color4 = this.SlotHighlights[this.Slot].color = color3;
				if (this.SlotHighlights[this.Slot].color.a <= (float)0)
				{
					this.Fade = false;
				}
			}
		}
	}

	public virtual void UpdateHighlights()
	{
		for (int i = 1; i < Extensions.get_length(this.SlotHighlights); i++)
		{
			int num = 0;
			Color color = this.SlotHighlights[i].color;
			float num2 = color.a = (float)num;
			Color color2 = this.SlotHighlights[i].color = color;
		}
	}

	public virtual void UpdateSubLabels()
	{
		this.ID = 1;
		if (this.Slot == 1)
		{
			while (this.ID < Extensions.get_length(this.SubLabels))
			{
				this.SubLabels[this.ID].text = this.Subjects[this.ID];
				int num = 1;
				Color color = this.SubLabels[this.ID].color;
				float num2 = color.a = (float)num;
				Color color2 = this.SubLabels[this.ID].color = color;
				this.ID++;
			}
		}
		else if (this.Slot == 2)
		{
			while (this.ID < Extensions.get_length(this.SubLabels))
			{
				this.SubLabels[this.ID].text = this.Locations[this.ID];
				int num3 = 1;
				Color color3 = this.SubLabels[this.ID].color;
				float num4 = color3.a = (float)num3;
				Color color4 = this.SubLabels[this.ID].color = color3;
				this.ID++;
			}
		}
		else if (this.Slot == 3)
		{
			while (this.ID < Extensions.get_length(this.SubLabels))
			{
				this.SubLabels[this.ID].text = this.Times[this.ID];
				int num5 = 1;
				Color color5 = this.SubLabels[this.ID].color;
				float num6 = color5.a = (float)num5;
				Color color6 = this.SubLabels[this.ID].color = color5;
				this.ID++;
			}
			this.DisableOptions();
		}
	}

	public virtual void CheckForCompletion()
	{
		if (this.SlotsFilled[1] && this.SlotsFilled[2] && this.SlotsFilled[3])
		{
			this.PromptBar.Label[2].text = "Finish";
			this.PromptBar.UpdateButtons();
		}
	}

	public virtual void Exit()
	{
		this.Yandere.Blur.enabled = false;
		this.Yandere.CanMove = true;
		this.Show = false;
		this.Yandere.HUD.alpha = (float)1;
		Time.timeScale = (float)1;
		this.PromptBar.Label[0].text = string.Empty;
		this.PromptBar.Label[1].text = string.Empty;
		this.PromptBar.Label[2].text = string.Empty;
		this.PromptBar.Label[4].text = string.Empty;
		this.PromptBar.Show = false;
		this.PromptBar.UpdateButtons();
	}

	public virtual void DisableOptions()
	{
		if (this.Clock.HourTime >= 7.25f)
		{
			float a = 0.5f;
			Color color = this.SubLabels[1].color;
			float num = color.a = a;
			Color color2 = this.SubLabels[1].color = color;
		}
		if (this.Clock.HourTime >= 7.5f)
		{
			float a2 = 0.5f;
			Color color3 = this.SubLabels[2].color;
			float num2 = color3.a = a2;
			Color color4 = this.SubLabels[2].color = color3;
		}
		if (this.Clock.HourTime >= 7.75f)
		{
			float a3 = 0.5f;
			Color color5 = this.SubLabels[3].color;
			float num3 = color5.a = a3;
			Color color6 = this.SubLabels[3].color = color5;
		}
		if (this.Clock.HourTime >= 8f)
		{
			float a4 = 0.5f;
			Color color7 = this.SubLabels[4].color;
			float num4 = color7.a = a4;
			Color color8 = this.SubLabels[4].color = color7;
		}
		if (this.Clock.HourTime >= 8.25f)
		{
			float a5 = 0.5f;
			Color color9 = this.SubLabels[5].color;
			float num5 = color9.a = a5;
			Color color10 = this.SubLabels[5].color = color9;
		}
		if (this.Clock.HourTime >= 15.5f)
		{
			float a6 = 0.5f;
			Color color11 = this.SubLabels[6].color;
			float num6 = color11.a = a6;
			Color color12 = this.SubLabels[6].color = color11;
		}
		if (this.Clock.HourTime >= 16f)
		{
			float a7 = 0.5f;
			Color color13 = this.SubLabels[7].color;
			float num7 = color13.a = a7;
			Color color14 = this.SubLabels[7].color = color13;
		}
		if (this.Clock.HourTime >= 16.5f)
		{
			float a8 = 0.5f;
			Color color15 = this.SubLabels[8].color;
			float num8 = color15.a = a8;
			Color color16 = this.SubLabels[8].color = color15;
		}
		if (this.Clock.HourTime >= 17f)
		{
			float a9 = 0.5f;
			Color color17 = this.SubLabels[9].color;
			float num9 = color17.a = a9;
			Color color18 = this.SubLabels[9].color = color17;
		}
		if (this.Clock.HourTime >= 17.5f)
		{
			float a10 = 0.5f;
			Color color19 = this.SubLabels[10].color;
			float num10 = color19.a = a10;
			Color color20 = this.SubLabels[10].color = color19;
		}
	}

	public virtual void Main()
	{
	}
}
