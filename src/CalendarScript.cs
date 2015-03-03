using System;
using UnityEngine;

[Serializable]
public class CalendarScript : MonoBehaviour
{
	public Transform Highlight;

	public Transform Continue;

	public UISprite Darkness;

	public bool Incremented;

	public bool FadeOut;

	public bool Reset;

	public float Timer;

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("Weekday") > 4)
		{
			PlayerPrefs.SetInt("Weekday", 0);
		}
		int num = -610;
		Vector3 localPosition = this.Continue.transform.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.Continue.transform.localPosition = localPosition;
		int num3 = 1;
		Color color = this.Darkness.color;
		float num4 = color.a = (float)num3;
		Color color2 = this.Darkness.color = color;
		Time.timeScale = (float)1;
	}

	public virtual void Update()
	{
		float x = Mathf.Lerp(this.Highlight.localPosition.x, (float)(-600 + 200 * PlayerPrefs.GetInt("Weekday")), Time.deltaTime * (float)10);
		Vector3 localPosition = this.Highlight.localPosition;
		float num = localPosition.x = x;
		Vector3 vector = this.Highlight.localPosition = localPosition;
		this.Timer += Time.deltaTime;
		if (this.Timer > (float)1)
		{
			if (!this.FadeOut)
			{
				float a = this.Darkness.color.a - Time.deltaTime;
				Color color = this.Darkness.color;
				float num2 = color.a = a;
				Color color2 = this.Darkness.color = color;
				if (this.Darkness.color.a < (float)0)
				{
					int num3 = 0;
					Color color3 = this.Darkness.color;
					float num4 = color3.a = (float)num3;
					Color color4 = this.Darkness.color = color3;
				}
			}
			else
			{
				if (this.Darkness.color.a == (float)0 && !this.Reset)
				{
					this.Darkness.color = new Color((float)1, (float)1, (float)1, (float)0);
				}
				float a2 = this.Darkness.color.a + Time.deltaTime;
				Color color5 = this.Darkness.color;
				float num5 = color5.a = a2;
				Color color6 = this.Darkness.color = color5;
				if (this.Darkness.color.a >= (float)1)
				{
					if (this.Reset)
					{
						PlayerPrefs.SetInt("Weekday", 0);
						Application.LoadLevel(Application.loadedLevel);
					}
					else
					{
						Application.LoadLevel("SchoolScene");
					}
				}
			}
			if (this.Timer > (float)2)
			{
				if (!this.Incremented)
				{
					PlayerPrefs.SetInt("Weekday", PlayerPrefs.GetInt("Weekday") + 1);
					this.Incremented = true;
				}
				if (this.Timer > (float)3)
				{
					float y = Mathf.Lerp(this.Continue.localPosition.y, (float)-545, Time.deltaTime * (float)10);
					Vector3 localPosition2 = this.Continue.localPosition;
					float num6 = localPosition2.y = y;
					Vector3 vector2 = this.Continue.localPosition = localPosition2;
					if (Input.GetButtonDown("A"))
					{
						this.FadeOut = true;
					}
					if (Input.GetButtonDown("B"))
					{
						this.FadeOut = true;
						this.Reset = true;
					}
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
