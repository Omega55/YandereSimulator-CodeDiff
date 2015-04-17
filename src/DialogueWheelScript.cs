using System;
using UnityEngine;

[Serializable]
public class DialogueWheelScript : MonoBehaviour
{
	public ReputationScript Reputation;

	public YandereScript Yandere;

	public Transform Interaction;

	public Transform Favors;

	public UISprite Impatience;

	public UILabel CenterLabel;

	public UISprite[] Segment;

	public UISprite[] Shadow;

	public string[] Text;

	public UISprite[] FavorSegment;

	public UISprite[] FavorShadow;

	public string[] FavorText;

	public int Selected;

	public bool AskingFavor;

	public bool Show;

	public Vector3 PreviousPosition;

	public Vector2 MouseDelta;

	public virtual void Start()
	{
		this.Interaction.localScale = new Vector3((float)1, (float)1, (float)1);
		this.Favors.localScale = new Vector3((float)0, (float)0, (float)0);
		this.transform.localScale = new Vector3((float)0, (float)0, (float)0);
	}

	public virtual void Update()
	{
		if (!this.Show)
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
		}
		else
		{
			if (!this.AskingFavor)
			{
				this.Interaction.localScale = Vector3.Lerp(this.Interaction.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				this.Favors.localScale = Vector3.Lerp(this.Favors.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			}
			else
			{
				this.Interaction.localScale = Vector3.Lerp(this.Interaction.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.Favors.localScale = Vector3.Lerp(this.Favors.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			}
			this.MouseDelta.x = this.MouseDelta.x + Input.GetAxis("Mouse X");
			this.MouseDelta.y = this.MouseDelta.y + Input.GetAxis("Mouse Y");
			if (this.MouseDelta.x > (float)11)
			{
				this.MouseDelta.x = (float)11;
			}
			else if (this.MouseDelta.x < (float)-11)
			{
				this.MouseDelta.x = (float)-11;
			}
			if (this.MouseDelta.y > (float)11)
			{
				this.MouseDelta.y = (float)11;
			}
			else if (this.MouseDelta.y < (float)-11)
			{
				this.MouseDelta.y = (float)-11;
			}
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			if (!this.AskingFavor)
			{
				if (Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f)
				{
					this.Selected = 0;
				}
				if ((Input.GetAxis("Vertical") > 0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (this.MouseDelta.y > (float)10 && this.MouseDelta.x < (float)10 && this.MouseDelta.x > (float)-10))
				{
					this.Selected = 1;
				}
				if ((Input.GetAxis("Vertical") > (float)0 && Input.GetAxis("Horizontal") > 0.5f) || (this.MouseDelta.y > (float)0 && this.MouseDelta.x > (float)10))
				{
					this.Selected = 2;
				}
				if ((Input.GetAxis("Vertical") < (float)0 && Input.GetAxis("Horizontal") > 0.5f) || (this.MouseDelta.y < (float)0 && this.MouseDelta.x > (float)10))
				{
					this.Selected = 3;
				}
				if ((Input.GetAxis("Vertical") < -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (this.MouseDelta.y < (float)-10 && this.MouseDelta.x < (float)10 && this.MouseDelta.x > (float)-10))
				{
					this.Selected = 4;
				}
				if ((Input.GetAxis("Vertical") < (float)0 && Input.GetAxis("Horizontal") < -0.5f) || (this.MouseDelta.y < (float)0 && this.MouseDelta.x < (float)-10))
				{
					this.Selected = 5;
				}
				if ((Input.GetAxis("Vertical") > (float)0 && Input.GetAxis("Horizontal") < -0.5f) || (this.MouseDelta.y > (float)0 && this.MouseDelta.x < (float)-10))
				{
					this.Selected = 6;
				}
				this.CenterLabel.text = this.Text[this.Selected];
			}
			else
			{
				if (Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f)
				{
					this.Selected = 0;
				}
				if ((Input.GetAxis("Vertical") > 0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (this.MouseDelta.y > (float)10 && this.MouseDelta.x < (float)10 && this.MouseDelta.x > (float)-10))
				{
					this.Selected = 1;
				}
				if ((Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") > 0.5f) || (this.MouseDelta.y < (float)10 && this.MouseDelta.y > (float)-10 && this.MouseDelta.x > (float)10))
				{
					this.Selected = 2;
				}
				if ((Input.GetAxis("Vertical") < -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (this.MouseDelta.y < (float)-10 && this.MouseDelta.x < (float)10 && this.MouseDelta.x > (float)-10))
				{
					this.Selected = 3;
				}
				if ((Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") < -0.5f) || (this.MouseDelta.y < (float)10 && this.MouseDelta.y > (float)-10 && this.MouseDelta.x < (float)-10))
				{
					this.Selected = 4;
				}
				if (this.Selected < this.FavorText.Length)
				{
					this.CenterLabel.text = this.FavorText[this.Selected];
				}
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
			for (int i = 1; i < 5; i++)
			{
				if (this.Selected == i)
				{
					this.FavorSegment[i].transform.localScale = Vector3.Lerp(this.FavorSegment[i].transform.localScale, new Vector3(1.3f, 1.3f, (float)1), Time.deltaTime * (float)10);
				}
				else
				{
					this.FavorSegment[i].transform.localScale = Vector3.Lerp(this.FavorSegment[i].transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				}
			}
			if (Input.GetButtonDown("A"))
			{
				if (!this.AskingFavor)
				{
					if (this.Selected == 1 && this.Shadow[this.Selected].color.a == (float)0)
					{
						this.Impatience.fillAmount = (float)0;
						this.Yandere.Interaction = 1;
						this.Yandere.TalkTimer = (float)3;
						this.Show = false;
					}
					if (this.Selected == 2 && this.Shadow[this.Selected].color.a == (float)0)
					{
						this.Impatience.fillAmount = (float)0;
						this.Yandere.Interaction = 2;
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
					if (this.Selected == 6 && this.Shadow[this.Selected].color.a == (float)0)
					{
						this.AskingFavor = true;
					}
				}
				else
				{
					if (this.Selected == 1 && this.FavorShadow[this.Selected].color.a == (float)0)
					{
						this.Impatience.fillAmount = (float)0;
						this.Yandere.Interaction = 9;
						this.Yandere.TalkTimer = (float)3;
						this.Show = false;
					}
					if (this.Selected == 3)
					{
						this.AskingFavor = false;
					}
				}
			}
		}
		this.PreviousPosition = Input.mousePosition;
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
		for (int i = 1; i < 5; i++)
		{
			int num3 = 0;
			Color color3 = this.FavorShadow[i].color;
			float num4 = color3.a = (float)num3;
			Color color4 = this.FavorShadow[i].color = color3;
		}
		float a = 0.75f;
		Color color5 = this.Shadow[3].color;
		float num5 = color5.a = a;
		Color color6 = this.Shadow[3].color = color5;
		float a2 = 0.75f;
		Color color7 = this.Shadow[5].color;
		float num6 = color7.a = a2;
		Color color8 = this.Shadow[5].color = color7;
		if (this.Reputation.Reputation < 33.33333f || this.Yandere.Bloodiness > (float)0 || this.Yandere.Sanity < 33.33333f)
		{
			float a3 = 0.75f;
			Color color9 = this.Shadow[6].color;
			float num7 = color9.a = a3;
			Color color10 = this.Shadow[6].color = color9;
		}
		float a4 = 0.75f;
		Color color11 = this.FavorShadow[2].color;
		float num8 = color11.a = a4;
		Color color12 = this.FavorShadow[2].color = color11;
		float a5 = 0.75f;
		Color color13 = this.FavorShadow[4].color;
		float num9 = color13.a = a5;
		Color color14 = this.FavorShadow[4].color = color13;
	}

	public virtual void End()
	{
		this.Yandere.TargetStudent.Interaction = 0;
		this.Yandere.TargetStudent.WaitTimer = (float)1;
		this.Yandere.TargetStudent.ShoulderCamera.OverShoulder = false;
		this.Yandere.TargetStudent.Waiting = true;
		this.Yandere.TargetStudent = null;
		this.AskingFavor = false;
		this.Show = false;
	}

	public virtual void Main()
	{
	}
}
