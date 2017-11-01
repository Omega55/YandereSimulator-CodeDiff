using System;
using UnityEngine;

public class PickpocketMinigameScript : MonoBehaviour
{
	public Transform PickpocketSpot;

	public UISprite[] ButtonPrompts;

	public UISprite Circle;

	public UISprite BG;

	public YandereScript Yandere;

	public string CurrentButton = string.Empty;

	public bool Failure;

	public bool Success;

	public bool Show;

	public int ButtonID;

	public int Progress;

	public int ID;

	public float Timer;

	private void Start()
	{
		base.transform.localScale = Vector3.zero;
		this.ButtonPrompts[1].enabled = false;
		this.ButtonPrompts[2].enabled = false;
		this.ButtonPrompts[3].enabled = false;
		this.ButtonPrompts[4].enabled = false;
		this.Circle.enabled = false;
		this.BG.enabled = false;
	}

	private void Update()
	{
		if (this.Show)
		{
			if (this.PickpocketSpot != null)
			{
				this.Yandere.MoveTowardsTarget(this.PickpocketSpot.position);
				this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.PickpocketSpot.rotation, Time.deltaTime * 10f);
			}
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				if (this.ButtonID == 0)
				{
					this.ChooseButton();
					this.Timer = 0f;
				}
				else
				{
					this.Failure = true;
					this.End();
				}
			}
			else if (this.ButtonID > 0)
			{
				this.Circle.fillAmount = 1f - this.Timer / 1f;
				if ((Input.GetButtonDown("A") && this.CurrentButton != "A") || (Input.GetButtonDown("B") && this.CurrentButton != "B") || (Input.GetButtonDown("X") && this.CurrentButton != "X") || (Input.GetButtonDown("Y") && this.CurrentButton != "Y"))
				{
					this.Failure = true;
					this.End();
				}
				else if (Input.GetButtonDown(this.CurrentButton))
				{
					this.ButtonPrompts[this.ButtonID].enabled = false;
					this.Circle.enabled = false;
					this.BG.enabled = false;
					this.ButtonID = 0;
					this.Timer = 0f;
					this.Progress++;
					if (this.Progress == 5)
					{
						this.Yandere.CanMove = true;
						this.Success = true;
						this.End();
					}
				}
			}
		}
		else if (base.transform.localScale.x > 0.1f)
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (base.transform.localScale.x < 0.1f)
			{
				base.transform.localScale = Vector3.zero;
			}
		}
	}

	private void ChooseButton()
	{
		this.ButtonPrompts[1].enabled = false;
		this.ButtonPrompts[2].enabled = false;
		this.ButtonPrompts[3].enabled = false;
		this.ButtonPrompts[4].enabled = false;
		int buttonID = this.ButtonID;
		while (this.ButtonID == buttonID)
		{
			this.ButtonID = UnityEngine.Random.Range(1, 5);
		}
		if (this.ButtonID == 1)
		{
			this.CurrentButton = "A";
		}
		else if (this.ButtonID == 2)
		{
			this.CurrentButton = "B";
		}
		else if (this.ButtonID == 3)
		{
			this.CurrentButton = "X";
		}
		else if (this.ButtonID == 4)
		{
			this.CurrentButton = "Y";
		}
		this.ButtonPrompts[this.ButtonID].enabled = true;
		this.Circle.enabled = true;
		this.BG.enabled = true;
	}

	public void End()
	{
		this.ButtonPrompts[1].enabled = false;
		this.ButtonPrompts[2].enabled = false;
		this.ButtonPrompts[3].enabled = false;
		this.ButtonPrompts[4].enabled = false;
		this.Circle.enabled = false;
		this.BG.enabled = false;
		if (this.Failure)
		{
			this.Yandere.CharacterAnimation.CrossFade("f02_readyToFight_00");
			this.Yandere.Caught = true;
		}
		else
		{
			this.Yandere.Pickpocketing = false;
		}
		this.Progress = 0;
		this.ButtonID = 0;
		this.Show = false;
		this.Timer = 0f;
	}
}
