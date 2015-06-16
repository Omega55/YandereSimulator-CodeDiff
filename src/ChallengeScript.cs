using System;
using UnityEngine;

[Serializable]
public class ChallengeScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public CalendarScript Calendar;

	public GameObject ViewButton;

	public Transform Arrows;

	public Transform[] ChallengeList;

	public int[] Challenges;

	public UIPanel[] Panels;

	public UIPanel ChallengePanel;

	public UIPanel CalendarPanel;

	public UITexture LargeIcon;

	public UISprite Shadow;

	public bool Viewing;

	public bool Switch;

	public int Phase;

	public int List;

	public ChallengeScript()
	{
		this.Phase = 1;
	}

	public virtual void Update()
	{
		if (!this.Viewing)
		{
			if (!this.Switch)
			{
				if (this.InputManager.TappedUp || this.InputManager.TappedDown || Input.GetKeyDown("w") || Input.GetKeyDown("up") || Input.GetKeyDown("s") || Input.GetKeyDown("down"))
				{
					if (this.List == 0)
					{
						int num = -300;
						Vector3 localPosition = this.Arrows.localPosition;
						float num2 = localPosition.y = (float)num;
						Vector3 vector = this.Arrows.localPosition = localPosition;
						this.ViewButton.active = true;
						this.Panels[0].alpha = 0.5f;
						this.Panels[1].alpha = (float)1;
						this.List = 1;
					}
					else
					{
						int num3 = 200;
						Vector3 localPosition2 = this.Arrows.localPosition;
						float num4 = localPosition2.y = (float)num3;
						Vector3 vector2 = this.Arrows.localPosition = localPosition2;
						this.ViewButton.active = false;
						this.Panels[0].alpha = (float)1;
						this.Panels[1].alpha = 0.5f;
						this.List = 0;
					}
				}
				float x = this.ChallengeList[this.List].localPosition.x + Input.GetAxis("Horizontal") * (float)-10;
				Vector3 localPosition3 = this.ChallengeList[this.List].localPosition;
				float num5 = localPosition3.x = x;
				Vector3 vector3 = this.ChallengeList[this.List].localPosition = localPosition3;
				if (this.ChallengeList[this.List].localPosition.x > (float)500)
				{
					int num6 = 500;
					Vector3 localPosition4 = this.ChallengeList[this.List].localPosition;
					float num7 = localPosition4.x = (float)num6;
					Vector3 vector4 = this.ChallengeList[this.List].localPosition = localPosition4;
				}
				else if (this.ChallengeList[this.List].localPosition.x < (float)(-250 * (this.Challenges[this.List] - 3)))
				{
					int num8 = -250 * (this.Challenges[this.List] - 3);
					Vector3 localPosition5 = this.ChallengeList[this.List].localPosition;
					float num9 = localPosition5.x = (float)num8;
					Vector3 vector5 = this.ChallengeList[this.List].localPosition = localPosition5;
				}
				if (this.LargeIcon.color.a > (float)0)
				{
					float a = this.LargeIcon.color.a - Time.deltaTime * (float)10;
					Color color = this.LargeIcon.color;
					float num10 = color.a = a;
					Color color2 = this.LargeIcon.color = color;
					if (this.LargeIcon.color.a < (float)0)
					{
						int num11 = 0;
						Color color3 = this.LargeIcon.color;
						float num12 = color3.a = (float)num11;
						Color color4 = this.LargeIcon.color = color3;
					}
				}
			}
		}
		else if (this.LargeIcon.color.a < (float)1)
		{
			float a2 = this.LargeIcon.color.a + Time.deltaTime * (float)10;
			Color color5 = this.LargeIcon.color;
			float num13 = color5.a = a2;
			Color color6 = this.LargeIcon.color = color5;
			if (this.LargeIcon.color.a > (float)1)
			{
				int num14 = 1;
				Color color7 = this.LargeIcon.color;
				float num15 = color7.a = (float)num14;
				Color color8 = this.LargeIcon.color = color7;
			}
		}
		float a3 = this.LargeIcon.color.a * 0.75f;
		Color color9 = this.Shadow.color;
		float num16 = color9.a = a3;
		Color color10 = this.Shadow.color = color9;
		if (Input.GetButtonDown("A") && this.List == 1 && this.ChallengeList[this.List].localPosition.x > (float)-2125)
		{
			this.Viewing = true;
		}
		if (Input.GetButtonDown("B"))
		{
			if (this.Viewing)
			{
				this.Viewing = false;
			}
			else
			{
				this.Switch = true;
			}
		}
		if (this.Switch)
		{
			if (this.Phase == 1)
			{
				this.ChallengePanel.alpha = this.ChallengePanel.alpha - Time.deltaTime;
				if (this.ChallengePanel.alpha <= (float)0)
				{
					this.Phase++;
				}
			}
			else
			{
				this.CalendarPanel.alpha = this.CalendarPanel.alpha + Time.deltaTime;
				if (this.CalendarPanel.alpha >= (float)1)
				{
					this.Calendar.enabled = true;
					this.enabled = false;
					this.Switch = false;
					this.Phase = 1;
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
