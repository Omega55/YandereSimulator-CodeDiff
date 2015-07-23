using System;
using UnityEngine;

[Serializable]
public class HeartbrokenCursorScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public HeartbrokenScript Heartbroken;

	public UISprite Darkness;

	public UILabel Continue;

	public UILabel MyLabel;

	public bool FadeOut;

	public bool Nudge;

	public int Selected;

	public AudioClip SelectSound;

	public AudioClip MoveSound;

	public HeartbrokenCursorScript()
	{
		this.Selected = 1;
	}

	public virtual void Start()
	{
		int num = -989;
		Vector3 localPosition = this.Darkness.transform.localPosition;
		float num2 = localPosition.z = (float)num;
		Vector3 vector = this.Darkness.transform.localPosition = localPosition;
		int num3 = 0;
		Color color = this.Continue.color;
		float num4 = color.a = (float)num3;
		Color color2 = this.Continue.color = color;
	}

	public virtual void Update()
	{
		float y = Mathf.Lerp(this.transform.localPosition.y, (float)(255 - this.Selected * 50), Time.deltaTime * (float)10);
		Vector3 localPosition = this.transform.localPosition;
		float num = localPosition.y = y;
		Vector3 vector = this.transform.localPosition = localPosition;
		if (!this.FadeOut)
		{
			if (this.MyLabel.color.a >= (float)1)
			{
				if (this.InputManager.TappedDown)
				{
					this.Selected++;
					if (this.Selected > 4)
					{
						this.Selected = 1;
					}
					this.audio.clip = this.MoveSound;
					this.audio.Play();
				}
				if (this.InputManager.TappedUp)
				{
					this.Selected--;
					if (this.Selected < 1)
					{
						this.Selected = 4;
					}
					this.audio.clip = this.MoveSound;
					this.audio.Play();
				}
				if (this.Selected != 4)
				{
					int num2 = 1;
					Color color = this.Continue.color;
					float num3 = color.a = (float)num2;
					Color color2 = this.Continue.color = color;
				}
				else
				{
					int num4 = 0;
					Color color3 = this.Continue.color;
					float num5 = color3.a = (float)num4;
					Color color4 = this.Continue.color = color3;
				}
				if (Input.GetButtonDown("A"))
				{
					this.audio.clip = this.SelectSound;
					this.audio.Play();
					this.Nudge = true;
					if (this.Selected != 4)
					{
						this.FadeOut = true;
					}
				}
			}
		}
		else
		{
			this.Heartbroken.audio.volume = this.Heartbroken.audio.volume - Time.deltaTime;
			float a = this.Darkness.color.a + Time.deltaTime;
			Color color5 = this.Darkness.color;
			float num6 = color5.a = a;
			Color color6 = this.Darkness.color = color5;
			if (this.Darkness.color.a >= (float)1)
			{
				if (this.Selected == 1)
				{
					for (int i = 0; i < this.StudentManager.NPCsTotal; i++)
					{
						if (PlayerPrefs.GetInt("Student_" + i + "_Dying") == 1)
						{
							PlayerPrefs.SetInt("Student_" + i + "_Dying", 0);
						}
					}
					Application.LoadLevel(Application.loadedLevel);
				}
				else if (this.Selected == 2)
				{
					PlayerPrefs.DeleteAll();
					Application.LoadLevel("CalendarScene");
				}
				else if (this.Selected == 3)
				{
					Application.LoadLevel("TitleScene");
				}
			}
		}
		if (this.Nudge)
		{
			float x = this.transform.localPosition.x + Time.deltaTime * (float)250;
			Vector3 localPosition2 = this.transform.localPosition;
			float num7 = localPosition2.x = x;
			Vector3 vector2 = this.transform.localPosition = localPosition2;
			if (this.transform.localPosition.x > (float)-225)
			{
				int num8 = -225;
				Vector3 localPosition3 = this.transform.localPosition;
				float num9 = localPosition3.x = (float)num8;
				Vector3 vector3 = this.transform.localPosition = localPosition3;
				this.Nudge = false;
			}
		}
		else
		{
			float x2 = this.transform.localPosition.x - Time.deltaTime * (float)250;
			Vector3 localPosition4 = this.transform.localPosition;
			float num10 = localPosition4.x = x2;
			Vector3 vector4 = this.transform.localPosition = localPosition4;
			if (this.transform.localPosition.x < (float)-250)
			{
				int num11 = -250;
				Vector3 localPosition5 = this.transform.localPosition;
				float num12 = localPosition5.x = (float)num11;
				Vector3 vector5 = this.transform.localPosition = localPosition5;
			}
		}
	}

	public virtual void Main()
	{
	}
}
