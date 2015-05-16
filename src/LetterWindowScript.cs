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
					this.UpdateSubLabels();
					this.Selecting = true;
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
				if (Input.GetButtonDown("A"))
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
		int i = 1;
		if (this.Slot == 1)
		{
			while (i < Extensions.get_length(this.SubLabels))
			{
				this.SubLabels[i].text = this.Subjects[i];
				i++;
			}
		}
		else if (this.Slot == 2)
		{
			while (i < Extensions.get_length(this.SubLabels))
			{
				this.SubLabels[i].text = this.Locations[i];
				i++;
			}
		}
		else if (this.Slot == 3)
		{
			while (i < Extensions.get_length(this.SubLabels))
			{
				this.SubLabels[i].text = this.Times[i];
				i++;
			}
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

	public virtual void Main()
	{
	}
}
