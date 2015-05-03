using System;
using UnityEngine;

[Serializable]
public class HeartbrokenCursorScript : MonoBehaviour
{
	public HeartbrokenScript Heartbroken;

	public InputManagerScript InputManager;

	public UISprite Darkness;

	public UILabel Continue;

	public UILabel MyLabel;

	public bool FadeOut;

	public int Selected;

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
				}
				if (this.InputManager.TappedUp)
				{
					this.Selected--;
					if (this.Selected < 1)
					{
						this.Selected = 4;
					}
				}
				if (this.Selected != 4)
				{
					int num2 = 1;
					Color color = this.Continue.color;
					float num3 = color.a = (float)num2;
					Color color2 = this.Continue.color = color;
					if (Input.GetButtonDown("A"))
					{
						this.FadeOut = true;
					}
				}
				else
				{
					int num4 = 0;
					Color color3 = this.Continue.color;
					float num5 = color3.a = (float)num4;
					Color color4 = this.Continue.color = color3;
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
				PlayerPrefs.DeleteAll();
				if (this.Selected == 1)
				{
					Application.LoadLevel(Application.loadedLevel);
				}
				else if (this.Selected == 2)
				{
					Application.LoadLevel("CalendarScene");
				}
				else if (this.Selected == 3)
				{
					Application.LoadLevel("TitleScene");
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
