using System;
using UnityEngine;

[Serializable]
public class PassTimeScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public ClockScript Clock;

	public UILabel TimeDisplay;

	public Transform Highlight;

	public float[] MinimumDigits;

	public float[] Digits;

	public int TargetTime;

	public int Selected;

	public string AMPM;

	public PassTimeScript()
	{
		this.Selected = 1;
		this.AMPM = "AM";
	}

	public virtual void Update()
	{
		if (this.InputManager.TappedLeft || Input.GetKeyDown("left"))
		{
			this.Selected--;
			if (this.Selected < 1)
			{
				this.Selected = 3;
			}
			this.UpdateHighlightPosition();
		}
		if (this.InputManager.TappedRight || Input.GetKeyDown("right"))
		{
			this.Selected++;
			if (this.Selected > 3)
			{
				this.Selected = 1;
			}
			this.UpdateHighlightPosition();
		}
		if (this.InputManager.TappedUp || Input.GetKeyDown("up"))
		{
			this.UpdateTime(1);
		}
		if (this.InputManager.TappedDown || Input.GetKeyDown("down"))
		{
			this.UpdateTime(-1);
		}
	}

	public virtual void UpdateHighlightPosition()
	{
		if (this.Selected == 1)
		{
			int num = -130;
			Vector3 localPosition = this.Highlight.localPosition;
			float num2 = localPosition.x = (float)num;
			Vector3 vector = this.Highlight.localPosition = localPosition;
		}
		else if (this.Selected == 2)
		{
			int num3 = -40;
			Vector3 localPosition2 = this.Highlight.localPosition;
			float num4 = localPosition2.x = (float)num3;
			Vector3 vector2 = this.Highlight.localPosition = localPosition2;
		}
		else if (this.Selected == 3)
		{
			int num5 = 15;
			Vector3 localPosition3 = this.Highlight.localPosition;
			float num6 = localPosition3.x = (float)num5;
			Vector3 vector3 = this.Highlight.localPosition = localPosition3;
		}
	}

	public virtual void GetCurrentTime()
	{
		this.Digits[1] = this.Clock.Hour;
		if (this.Clock.Minute < (float)9)
		{
			this.Digits[2] = (float)0;
			this.Digits[3] = this.Clock.Minute;
		}
		else
		{
			this.Digits[2] = this.Clock.Minute * 0.1f;
			this.Digits[2] = Mathf.Floor(this.Digits[2]);
			this.Digits[3] = this.Clock.Minute - this.Digits[2] * (float)10;
		}
		this.MinimumDigits[1] = this.Digits[1];
		this.MinimumDigits[2] = this.Digits[2];
		this.MinimumDigits[3] = this.Digits[3];
		this.UpdateTime(0);
	}

	public virtual void UpdateTime(int Increment)
	{
		this.Digits[this.Selected] = this.Digits[this.Selected] + (float)Increment;
		if (this.Selected == 1)
		{
			if (this.Digits[1] < this.MinimumDigits[1])
			{
				this.Digits[1] = this.MinimumDigits[1];
			}
			else if (this.Digits[1] > (float)17)
			{
				this.Digits[1] = (float)17;
			}
			if (this.Digits[1] == this.MinimumDigits[1])
			{
				if (this.Digits[2] < this.MinimumDigits[2])
				{
					this.Digits[2] = this.MinimumDigits[2];
				}
				if (this.Digits[2] == this.MinimumDigits[2] && this.Digits[3] < this.MinimumDigits[3])
				{
					this.Digits[3] = this.MinimumDigits[3];
				}
			}
		}
		else if (this.Selected == 2)
		{
			if (this.Digits[1] == this.MinimumDigits[1])
			{
				if (this.Digits[2] < this.MinimumDigits[2])
				{
					this.Digits[2] = this.MinimumDigits[2];
				}
				else if (this.Digits[2] > (float)5)
				{
					this.Digits[2] = this.MinimumDigits[2];
				}
				if (this.Digits[2] == this.MinimumDigits[2] && this.Digits[3] < this.MinimumDigits[3])
				{
					this.Digits[3] = this.MinimumDigits[3];
				}
			}
			else if (this.Digits[2] < (float)0)
			{
				this.Digits[2] = (float)5;
			}
			else if (this.Digits[2] > (float)5)
			{
				this.Digits[2] = (float)0;
			}
		}
		else if (this.Selected == 3)
		{
			if (this.Digits[1] == this.MinimumDigits[1] && this.Digits[2] == this.MinimumDigits[2])
			{
				if (this.Digits[3] < this.MinimumDigits[3])
				{
					this.Digits[3] = this.MinimumDigits[3];
				}
				else if (this.Digits[3] > (float)9)
				{
					this.Digits[3] = this.MinimumDigits[3];
				}
			}
			else if (this.Digits[3] < (float)0)
			{
				this.Digits[3] = (float)9;
			}
			else if (this.Digits[3] > (float)9)
			{
				this.Digits[3] = (float)0;
			}
		}
		if (this.Digits[1] < (float)12)
		{
			this.AMPM = " AM";
		}
		else
		{
			this.AMPM = " PM";
		}
		if (this.Digits[1] < (float)10)
		{
			this.TimeDisplay.text = "0" + this.Digits[1] + ":" + this.Digits[2] + this.Digits[3] + this.AMPM;
		}
		else if (this.Digits[1] < (float)13)
		{
			this.TimeDisplay.text = this.Digits[1] + ":" + this.Digits[2] + this.Digits[3] + this.AMPM;
		}
		else
		{
			this.TimeDisplay.text = "0" + (this.Digits[1] - (float)12) + ":" + this.Digits[2] + this.Digits[3] + this.AMPM;
		}
		this.TargetTime = (int)(this.Digits[1] * (float)60 + this.Digits[2] * (float)10 + this.Digits[3]);
	}

	public virtual void Main()
	{
	}
}
