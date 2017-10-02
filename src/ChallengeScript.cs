using System;
using UnityEngine;

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

	public int Phase = 1;

	public int List;

	private void Update()
	{
		if (!this.Viewing)
		{
			if (!this.Switch)
			{
				if (this.InputManager.TappedUp || this.InputManager.TappedDown)
				{
					if (this.List == 0)
					{
						this.Arrows.localPosition = new Vector3(this.Arrows.localPosition.x, -300f, this.Arrows.localPosition.z);
						this.ViewButton.SetActive(true);
						this.Panels[0].alpha = 0.5f;
						this.Panels[1].alpha = 1f;
						this.List = 1;
					}
					else
					{
						this.Arrows.localPosition = new Vector3(this.Arrows.localPosition.x, 200f, this.Arrows.localPosition.z);
						this.ViewButton.SetActive(false);
						this.Panels[0].alpha = 1f;
						this.Panels[1].alpha = 0.5f;
						this.List = 0;
					}
				}
				Transform transform = this.ChallengeList[this.List];
				if (this.InputManager.DPadRight || Input.GetKey(KeyCode.RightArrow))
				{
					transform.localPosition = new Vector3(transform.localPosition.x - Time.deltaTime * 1000f, transform.localPosition.y, transform.localPosition.z);
				}
				if (this.InputManager.DPadLeft || Input.GetKey(KeyCode.LeftArrow))
				{
					transform.localPosition = new Vector3(transform.localPosition.x + Time.deltaTime * 1000f, transform.localPosition.y, transform.localPosition.z);
				}
				transform.localPosition = new Vector3(transform.localPosition.x + Input.GetAxis("Horizontal") * -10f, transform.localPosition.y, transform.localPosition.z);
				if (transform.localPosition.x > 500f)
				{
					transform.localPosition = new Vector3(500f, transform.localPosition.y, transform.localPosition.z);
				}
				else if (transform.localPosition.x < -250f * ((float)this.Challenges[this.List] - 3f))
				{
					transform.localPosition = new Vector3(-250f * ((float)this.Challenges[this.List] - 3f), transform.localPosition.y, transform.localPosition.z);
				}
				if (this.LargeIcon.color.a > 0f)
				{
					this.LargeIcon.color = new Color(this.LargeIcon.color.r, this.LargeIcon.color.g, this.LargeIcon.color.b, this.LargeIcon.color.a - Time.deltaTime * 10f);
					if (this.LargeIcon.color.a < 0f)
					{
						this.LargeIcon.color = new Color(this.LargeIcon.color.r, this.LargeIcon.color.g, this.LargeIcon.color.b, 0f);
					}
				}
			}
		}
		else if (this.LargeIcon.color.a < 1f)
		{
			this.LargeIcon.color = new Color(this.LargeIcon.color.r, this.LargeIcon.color.g, this.LargeIcon.color.b, this.LargeIcon.color.a + Time.deltaTime * 10f);
			if (this.LargeIcon.color.a > 1f)
			{
				this.LargeIcon.color = new Color(this.LargeIcon.color.r, this.LargeIcon.color.g, this.LargeIcon.color.b, 1f);
			}
		}
		this.Shadow.color = new Color(this.Shadow.color.r, this.Shadow.color.g, this.Shadow.color.b, this.LargeIcon.color.a * 0.75f);
		if (!this.Switch && Input.GetButtonDown("A") && this.List == 1 && this.ChallengeList[this.List].localPosition.x > -2375f)
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
				this.ChallengePanel.alpha -= Time.deltaTime;
				if (this.ChallengePanel.alpha <= 0f)
				{
					this.Phase++;
				}
			}
			else
			{
				this.CalendarPanel.alpha += Time.deltaTime;
				if (this.CalendarPanel.alpha >= 1f)
				{
					this.Calendar.enabled = true;
					base.enabled = false;
					this.Switch = false;
					this.Phase = 1;
				}
			}
		}
	}
}
