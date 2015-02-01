using System;
using UnityEngine;

[Serializable]
public class PauseScreenScript : MonoBehaviour
{
	public PassTimeScript PassTime;

	public YandereScript Yandere;

	public RPG_Camera RPGCamera;

	public ClockScript Clock;

	public Blur ScreenBlur;

	public UILabel PassTimeLabel;

	public GameObject PromptParent;

	public GameObject MainMenu;

	public Transform Highlight;

	public int Selected;

	public bool CorrectingTime;

	public bool PressedA;

	public bool Show;

	public PauseScreenScript()
	{
		this.Selected = 1;
	}

	public virtual void Start()
	{
		this.transform.localPosition = new Vector3((float)1250, (float)0, (float)0);
		this.transform.localScale = new Vector3(0.585f, 0.585f, 0.585f);
	}

	public virtual void Update()
	{
		if (!this.Show)
		{
			this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3((float)1250, (float)0, (float)0), 0.166666672f);
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(0.585f, 0.585f, 0.585f), 0.166666672f);
			if (this.CorrectingTime && Time.timeScale < 0.9f)
			{
				Time.timeScale = Mathf.Lerp(Time.timeScale, (float)1, 0.166666672f);
				if (Time.timeScale > 0.9f)
				{
					this.CorrectingTime = false;
					Time.timeScale = (float)1;
				}
			}
			if (Input.GetButtonDown("Start") && !this.Yandere.TimeSkipping)
			{
				this.PromptParent.active = false;
				this.ScreenBlur.enabled = true;
				this.RPGCamera.enabled = false;
				this.Show = true;
				if (!this.Yandere.CanMove || this.Yandere.Dragging)
				{
					float a = 0.5f;
					Color color = this.PassTimeLabel.color;
					float num = color.a = a;
					Color color2 = this.PassTimeLabel.color = color;
				}
				else
				{
					int num2 = 1;
					Color color3 = this.PassTimeLabel.color;
					float num3 = color3.a = (float)num2;
					Color color4 = this.PassTimeLabel.color = color3;
				}
			}
		}
		else
		{
			this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3((float)0, (float)0, (float)0), 0.166666672f);
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), 0.166666672f);
			Time.timeScale = Mathf.Lerp(Time.timeScale, (float)0, 0.166666672f);
			if (this.MainMenu.active)
			{
				if (Input.GetKeyDown("up"))
				{
					float y = this.Highlight.localPosition.y + (float)75;
					Vector3 localPosition = this.Highlight.localPosition;
					float num4 = localPosition.y = y;
					Vector3 vector = this.Highlight.localPosition = localPosition;
					this.Selected--;
					if (this.Selected < 1)
					{
						int num5 = -225;
						Vector3 localPosition2 = this.Highlight.localPosition;
						float num6 = localPosition2.y = (float)num5;
						Vector3 vector2 = this.Highlight.localPosition = localPosition2;
						this.Selected = 7;
					}
				}
				if (Input.GetKeyDown("down"))
				{
					float y2 = this.Highlight.localPosition.y - (float)75;
					Vector3 localPosition3 = this.Highlight.localPosition;
					float num7 = localPosition3.y = y2;
					Vector3 vector3 = this.Highlight.localPosition = localPosition3;
					this.Selected++;
					if (this.Selected > 7)
					{
						int num8 = 225;
						Vector3 localPosition4 = this.Highlight.localPosition;
						float num9 = localPosition4.y = (float)num8;
						Vector3 vector4 = this.Highlight.localPosition = localPosition4;
						this.Selected = 1;
					}
				}
				if (Input.GetButtonDown("A"))
				{
					this.PressedA = true;
					if (this.Selected == 1)
					{
						this.ScreenBlur.enabled = false;
						this.RPGCamera.enabled = true;
						this.CorrectingTime = true;
						this.Show = false;
					}
					else if (this.Selected == 2)
					{
						if (this.Yandere.CanMove && !this.Yandere.Dragging)
						{
							this.MainMenu.active = false;
							this.PassTime.active = true;
							this.PassTime.GetCurrentTime();
						}
					}
					else if (this.Selected == 7)
					{
						Application.Quit();
					}
				}
				if (Input.GetButtonDown("Start"))
				{
					this.PromptParent.active = true;
					this.ScreenBlur.enabled = false;
					this.RPGCamera.enabled = true;
					this.CorrectingTime = true;
					this.Show = false;
				}
			}
			if (!this.PressedA && this.PassTime.active)
			{
				if (Input.GetButtonDown("A"))
				{
					this.PromptParent.active = true;
					this.ScreenBlur.enabled = false;
					this.RPGCamera.enabled = true;
					this.PassTime.active = false;
					this.MainMenu.active = true;
					this.Show = false;
					this.Clock.TargetTime = (float)this.PassTime.TargetTime;
					this.Clock.TimeSkip = true;
					Time.timeScale = (float)1;
				}
				if (Input.GetButtonDown("B"))
				{
					this.MainMenu.active = true;
					this.PassTime.active = false;
				}
			}
			if (Input.GetButtonUp("A"))
			{
				this.PressedA = false;
			}
		}
	}

	public virtual void Main()
	{
	}
}
