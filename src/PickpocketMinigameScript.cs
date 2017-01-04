using System;
using UnityEngine;

[Serializable]
public class PickpocketMinigameScript : MonoBehaviour
{
	public Transform PickpocketSpot;

	public UISprite[] ButtonPrompts;

	public UISprite Circle;

	public UISprite BG;

	public YandereScript Yandere;

	public string CurrentButton;

	public bool Failure;

	public bool Success;

	public bool Show;

	public int ButtonID;

	public int Progress;

	public int ID;

	public float Timer;

	public PickpocketMinigameScript()
	{
		this.CurrentButton = string.Empty;
	}

	public virtual void Start()
	{
		this.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		this.ButtonPrompts[1].enabled = false;
		this.ButtonPrompts[2].enabled = false;
		this.ButtonPrompts[3].enabled = false;
		this.ButtonPrompts[4].enabled = false;
		this.Circle.enabled = false;
		this.BG.enabled = false;
	}

	public virtual void Update()
	{
		if (this.Show)
		{
			this.Yandere.MoveTowardsTarget(this.PickpocketSpot.position);
			this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.PickpocketSpot.rotation, Time.deltaTime * (float)10);
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)1)
			{
				if (this.ButtonID == 0)
				{
					this.ChooseButton();
					this.Timer = (float)0;
				}
				else
				{
					this.Failure = true;
					this.End();
				}
			}
			else if (this.ButtonID > 0)
			{
				this.Circle.fillAmount = (float)1 - this.Timer / 1f;
				if (Input.GetButtonDown("A") && this.CurrentButton != "A")
				{
					this.End();
					this.Failure = true;
				}
				else if (Input.GetButtonDown("B") && this.CurrentButton != "B")
				{
					this.End();
					this.Failure = true;
				}
				else if (Input.GetButtonDown("X") && this.CurrentButton != "X")
				{
					this.End();
					this.Failure = true;
				}
				else if (Input.GetButtonDown("Y") && this.CurrentButton != "Y")
				{
					this.End();
					this.Failure = true;
				}
				else if (Input.GetButtonDown(this.CurrentButton))
				{
					this.ButtonPrompts[this.ButtonID].enabled = false;
					this.Circle.enabled = false;
					this.BG.enabled = false;
					this.ButtonID = 0;
					this.Timer = (float)0;
					this.Progress++;
					if (this.Progress == 5)
					{
						this.Success = true;
						this.End();
					}
				}
			}
		}
		else if (this.transform.localScale.x > 0.1f)
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			if (this.transform.localScale.x < 0.1f)
			{
				this.transform.localScale = new Vector3((float)0, (float)0, (float)0);
			}
		}
	}

	public virtual void ChooseButton()
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

	public virtual void End()
	{
		this.ButtonPrompts[1].enabled = false;
		this.ButtonPrompts[2].enabled = false;
		this.ButtonPrompts[3].enabled = false;
		this.ButtonPrompts[4].enabled = false;
		this.Circle.enabled = false;
		this.BG.enabled = false;
		this.Yandere.Pickpocketing = false;
		this.Yandere.CanMove = true;
		this.Progress = 0;
		this.ButtonID = 0;
		this.Show = false;
		this.Timer = (float)0;
	}

	public virtual void Main()
	{
	}
}
