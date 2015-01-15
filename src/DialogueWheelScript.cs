using System;
using UnityEngine;

[Serializable]
public class DialogueWheelScript : MonoBehaviour
{
	public YandereScript Yandere;

	public UISprite Impatience;

	public UILabel CenterLabel;

	public UISprite[] Segment;

	public UISprite[] Shadow;

	public string[] Text;

	public int Selected;

	public bool Show;

	public virtual void Start()
	{
		this.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		this.HideShadows();
	}

	public virtual void Update()
	{
		if (!this.Show)
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
		}
		else
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			if (Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f)
			{
				this.Selected = 0;
			}
			if (Input.GetAxis("Vertical") > 0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f)
			{
				this.Selected = 1;
			}
			if (Input.GetAxis("Vertical") > (float)0 && Input.GetAxis("Horizontal") > 0.5f)
			{
				this.Selected = 2;
			}
			if (Input.GetAxis("Vertical") < (float)0 && Input.GetAxis("Horizontal") > 0.5f)
			{
				this.Selected = 3;
			}
			if (Input.GetAxis("Vertical") < -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f)
			{
				this.Selected = 4;
			}
			if (Input.GetAxis("Vertical") < (float)0 && Input.GetAxis("Horizontal") < -0.5f)
			{
				this.Selected = 5;
			}
			if (Input.GetAxis("Vertical") > (float)0 && Input.GetAxis("Horizontal") < -0.5f)
			{
				this.Selected = 6;
			}
			for (int i = 1; i < 7; i++)
			{
				if (this.Selected == i)
				{
					this.Segment[i].transform.localScale = Vector3.Lerp(this.Segment[i].transform.localScale, new Vector3(1.3f, 1.3f, (float)1), Time.deltaTime * (float)10);
				}
				else
				{
					this.Segment[i].transform.localScale = Vector3.Lerp(this.Segment[i].transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				}
			}
			this.CenterLabel.text = this.Text[this.Selected];
			if (Input.GetButtonDown("A"))
			{
				if (this.Selected == 1 && this.Shadow[this.Selected].color.a == (float)0)
				{
					this.Impatience.fillAmount = (float)0;
					this.Yandere.Interaction = 1;
					this.Yandere.TalkTimer = (float)3;
					this.Show = false;
				}
				if (this.Selected == 4)
				{
					this.Impatience.fillAmount = (float)0;
					this.Yandere.Interaction = 4;
					this.Yandere.TalkTimer = (float)2;
					this.Show = false;
				}
			}
		}
	}

	public virtual void HideShadows()
	{
		this.Impatience.fillAmount = (float)0;
		for (int i = 1; i < 7; i++)
		{
			int num = 0;
			Color color = this.Shadow[i].color;
			float num2 = color.a = (float)num;
			Color color2 = this.Shadow[i].color = color;
		}
	}

	public virtual void End()
	{
		this.Yandere.TargetStudent.Interaction = 0;
		this.Yandere.TargetStudent.WaitTimer = (float)1;
		this.Yandere.TargetStudent.ShoulderCamera.OverShoulder = false;
		this.Yandere.TargetStudent.Waiting = true;
		this.Yandere.TargetStudent = null;
		this.Yandere.Talking = false;
		this.Show = false;
	}

	public virtual void Main()
	{
	}
}
