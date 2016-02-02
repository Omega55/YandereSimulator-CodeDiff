using System;
using UnityEngine;

[Serializable]
public class WelcomeScript : MonoBehaviour
{
	public GameObject WelcomePanel;

	public GameObject WarningPanel;

	public UILabel FlashingLabel;

	public UILabel BeginLabel;

	public UISprite Darkness;

	public AudioSource Music;

	public bool Continue;

	public bool FlashRed;

	public float VersionNumber;

	public float Timer;

	public virtual void Start()
	{
		int num = 0;
		Color color = this.BeginLabel.color;
		float num2 = color.a = (float)num;
		Color color2 = this.BeginLabel.color = color;
		int num3 = 2;
		Color color3 = this.Darkness.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.Darkness.color = color3;
		Screen.lockCursor = true;
		Screen.showCursor = false;
		if (PlayerPrefs.GetFloat("VersionNumber") < this.VersionNumber)
		{
			PlayerPrefs.DeleteAll();
			PlayerPrefs.SetFloat("VersionNumber", this.VersionNumber);
		}
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown("y"))
		{
			Application.LoadLevel("YanvaniaScene");
		}
		if (!this.Continue)
		{
			float a = this.Darkness.color.a - Time.deltaTime;
			Color color = this.Darkness.color;
			float num = color.a = a;
			Color color2 = this.Darkness.color = color;
			if (this.Darkness.color.a <= (float)0)
			{
				if (Input.GetKeyDown("w"))
				{
				}
				if (Input.anyKeyDown)
				{
					this.Timer = (float)5;
				}
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)5)
				{
					float a2 = this.BeginLabel.color.a + Time.deltaTime;
					Color color3 = this.BeginLabel.color;
					float num2 = color3.a = a2;
					Color color4 = this.BeginLabel.color = color3;
					if (this.BeginLabel.color.a >= (float)1)
					{
						if (this.WelcomePanel.active && Input.anyKeyDown)
						{
							this.Darkness.color = new Color((float)1, (float)1, (float)1, (float)0);
							this.Continue = true;
						}
						if (this.WarningPanel.active && !Input.GetKeyDown("w") && Input.anyKeyDown)
						{
							this.Darkness.color = new Color((float)1, (float)1, (float)1, (float)0);
							this.Continue = true;
						}
					}
				}
			}
		}
		else
		{
			this.Music.volume = this.Music.volume - Time.deltaTime;
			float a3 = this.Darkness.color.a + Time.deltaTime;
			Color color5 = this.Darkness.color;
			float num3 = color5.a = a3;
			Color color6 = this.Darkness.color = color5;
			if (this.Darkness.color.a >= (float)1)
			{
				Application.LoadLevel("WarningScene");
			}
		}
		if (!this.FlashRed)
		{
			float r = this.FlashingLabel.color.r + Time.deltaTime * (float)10;
			Color color7 = this.FlashingLabel.color;
			float num4 = color7.r = r;
			Color color8 = this.FlashingLabel.color = color7;
			if (this.FlashingLabel.color.r > (float)1)
			{
				this.FlashRed = true;
			}
		}
		else
		{
			float r2 = this.FlashingLabel.color.r - Time.deltaTime * (float)10;
			Color color9 = this.FlashingLabel.color;
			float num5 = color9.r = r2;
			Color color10 = this.FlashingLabel.color = color9;
			if (this.FlashingLabel.color.r < (float)0)
			{
				this.FlashRed = false;
			}
		}
	}

	public virtual void Main()
	{
	}
}
