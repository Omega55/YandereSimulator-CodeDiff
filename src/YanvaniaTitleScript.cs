using System;
using UnityEngine;

[Serializable]
public class YanvaniaTitleScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public GameObject ButtonEffect;

	public GameObject ErrorWindow;

	public GameObject SkipButton;

	public Transform Highlight;

	public Transform Prologue;

	public UIPanel Controls;

	public UIPanel Credits;

	public UIPanel Buttons;

	public UISprite Darkness;

	public UITexture Midori;

	public UITexture Logo;

	public AudioClip SelectSound;

	public AudioClip ExitSound;

	public AudioClip BGM;

	public Transform[] BackButtons;

	public Texture SadMidori;

	public bool FadeButtons;

	public bool ErrorLeave;

	public bool FadeOut;

	public float ScrollSpeed;

	public int Selected;

	public YanvaniaTitleScript()
	{
		this.Selected = 1;
	}

	public virtual void Start()
	{
		this.Midori.transform.localPosition = new Vector3((float)1540, (float)0, (float)0);
		this.Midori.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		this.Midori.gameObject.active = false;
		if (PlayerPrefs.GetInt("DraculaDefeated") == 1)
		{
			this.SkipButton.active = true;
			this.Logo.active = false;
		}
		else
		{
			this.SkipButton.active = false;
		}
		this.Prologue.gameObject.active = false;
		int num = -2665;
		Vector3 localPosition = this.Prologue.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.Prologue.localPosition = localPosition;
		int num3 = 1;
		Color color = this.Darkness.color;
		float num4 = color.a = (float)num3;
		Color color2 = this.Darkness.color = color;
		this.Buttons.alpha = (float)0;
		int num5 = 0;
		Color color3 = this.Logo.color;
		float num6 = color3.a = (float)num5;
		Color color4 = this.Logo.color = color3;
	}

	public virtual void Update()
	{
		if (!this.Logo.active && Input.GetKeyDown("m"))
		{
			PlayerPrefs.SetInt("DraculaDefeated", 1);
			PlayerPrefs.SetInt("MidoriEasterEgg", 1);
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown("end"))
		{
			PlayerPrefs.SetInt("DraculaDefeated", 1);
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown("`"))
		{
			PlayerPrefs.SetInt("DraculaDefeated", 0);
			Application.LoadLevel(Application.loadedLevel);
		}
		if (!this.FadeOut)
		{
			if (this.Darkness.color.a > (float)0)
			{
				if (Input.GetButtonDown("A"))
				{
					this.Skip();
				}
				if (!this.ErrorWindow.active)
				{
					float a = this.Darkness.color.a - Time.deltaTime;
					Color color = this.Darkness.color;
					float num = color.a = a;
					Color color2 = this.Darkness.color = color;
				}
			}
			else if (this.Darkness.color.a <= (float)0)
			{
				if (PlayerPrefs.GetInt("MidoriEasterEgg") == 0)
				{
					if (PlayerPrefs.GetInt("DraculaDefeated") == 1)
					{
						if (!this.Prologue.gameObject.active)
						{
							this.Prologue.active = true;
							this.audio.volume = 0.5f;
							this.audio.loop = true;
							this.audio.clip = this.BGM;
							this.audio.Play();
						}
						if (Input.GetButtonDown("B"))
						{
							int num2 = 2501;
							Vector3 localPosition = this.Prologue.localPosition;
							float num3 = localPosition.y = (float)num2;
							Vector3 vector = this.Prologue.localPosition = localPosition;
							this.Prologue.audio.Stop();
						}
						if (this.Prologue.localPosition.y > (float)2500)
						{
							if (this.audio.isPlaying)
							{
								this.Midori.mainTexture = this.SadMidori;
								Time.timeScale = (float)1;
								this.Midori.gameObject.audio.Stop();
								this.audio.Stop();
							}
							if (!this.ErrorLeave)
							{
								this.ErrorWindow.active = true;
								this.ErrorWindow.transform.localScale = Vector3.Lerp(this.ErrorWindow.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
								if (this.ErrorWindow.transform.localScale.x > 0.9f && Input.anyKeyDown)
								{
									this.ErrorWindow.audio.clip = this.ExitSound;
									this.ErrorWindow.audio.Play();
									this.ErrorLeave = true;
								}
							}
							else
							{
								this.FadeOut = true;
							}
						}
						else
						{
							float y = this.Prologue.localPosition.y + Time.deltaTime * this.ScrollSpeed;
							Vector3 localPosition2 = this.Prologue.localPosition;
							float num4 = localPosition2.y = y;
							Vector3 vector2 = this.Prologue.localPosition = localPosition2;
							if (Input.GetKeyDown("="))
							{
								Time.timeScale = (float)100;
							}
							if (Input.GetKeyDown("-"))
							{
								Time.timeScale = (float)1;
							}
						}
					}
					else if (!this.audio.isPlaying)
					{
						if (this.Logo.color.a == (float)0)
						{
							this.audio.Play();
						}
						else
						{
							this.audio.loop = true;
							this.audio.clip = this.BGM;
							this.audio.Play();
						}
					}
					else if (this.audio.clip != this.BGM)
					{
						float a2 = this.Logo.color.a + Time.deltaTime;
						Color color3 = this.Logo.color;
						float num5 = color3.a = a2;
						Color color4 = this.Logo.color = color3;
						if (Input.GetButtonDown("A"))
						{
							this.Skip();
						}
					}
					else if (!this.FadeButtons)
					{
						this.Controls.alpha = Mathf.MoveTowards(this.Controls.alpha, (float)0, Time.deltaTime);
						this.Credits.alpha = Mathf.MoveTowards(this.Credits.alpha, (float)0, Time.deltaTime);
						if (this.Controls.alpha == (float)0 && this.Credits.alpha == (float)0)
						{
							int num6 = -100 - 100 * this.Selected;
							Vector3 localPosition3 = this.Highlight.localPosition;
							float num7 = localPosition3.y = (float)num6;
							Vector3 vector3 = this.Highlight.localPosition = localPosition3;
							this.Buttons.alpha = this.Buttons.alpha + Time.deltaTime;
							if (this.Buttons.alpha >= (float)1)
							{
								if (Input.GetButtonDown("A"))
								{
									UnityEngine.Object.Instantiate(this.ButtonEffect, this.Highlight.position, Quaternion.identity);
									if (this.Selected == 1 || this.Selected == 4)
									{
										this.FadeOut = true;
									}
									if (this.Selected == 2 || this.Selected == 3)
									{
										this.FadeButtons = true;
									}
								}
								if (this.InputManager.TappedUp)
								{
									this.Highlight.gameObject.audio.Play();
									this.Selected--;
									if (this.Selected < 1)
									{
										this.Selected = 4;
									}
								}
								if (this.InputManager.TappedDown)
								{
									this.Highlight.gameObject.audio.Play();
									this.Selected++;
									if (this.Selected > 4)
									{
										this.Selected = 1;
									}
								}
							}
						}
					}
					else
					{
						this.Buttons.alpha = this.Buttons.alpha - Time.deltaTime;
						if (this.Buttons.alpha == (float)0)
						{
							if (this.Selected == 2)
							{
								this.Controls.alpha = Mathf.MoveTowards(this.Controls.alpha, (float)1, Time.deltaTime);
							}
							else
							{
								this.Credits.alpha = Mathf.MoveTowards(this.Credits.alpha, (float)1, Time.deltaTime);
							}
						}
						if ((this.Controls.alpha == (float)1 || this.Credits.alpha == (float)1) && Input.GetButtonDown("B"))
						{
							UnityEngine.Object.Instantiate(this.ButtonEffect, this.BackButtons[this.Selected].position, Quaternion.identity);
							this.FadeButtons = false;
						}
					}
				}
				else
				{
					this.Prologue.audio.enabled = false;
					this.Midori.gameObject.active = true;
					this.ScrollSpeed = (float)60;
					float x = Mathf.Lerp(this.Midori.transform.localPosition.x, (float)875, Time.deltaTime * (float)2);
					Vector3 localPosition4 = this.Midori.transform.localPosition;
					float num8 = localPosition4.x = x;
					Vector3 vector4 = this.Midori.transform.localPosition = localPosition4;
					float z = Mathf.Lerp(this.Midori.transform.localEulerAngles.z, (float)45, Time.deltaTime * (float)2);
					Vector3 localEulerAngles = this.Midori.transform.localEulerAngles;
					float num9 = localEulerAngles.z = z;
					Vector3 vector5 = this.Midori.transform.localEulerAngles = localEulerAngles;
					if (this.Midori.gameObject.audio.time > (float)3)
					{
						PlayerPrefs.SetInt("MidoriEasterEgg", 0);
					}
				}
			}
		}
		else
		{
			this.ErrorWindow.transform.localScale = Vector3.Lerp(this.ErrorWindow.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			float a3 = this.Darkness.color.a + Time.deltaTime;
			Color color5 = this.Darkness.color;
			float num10 = color5.a = a3;
			Color color6 = this.Darkness.color = color5;
			this.audio.volume = this.audio.volume - Time.deltaTime;
			if (this.Darkness.color.a >= (float)1)
			{
				if (PlayerPrefs.GetInt("DraculaDefeated") == 1)
				{
					Application.LoadLevel("HomeScene");
				}
				else if (this.Selected == 1)
				{
					Application.LoadLevel("YanvaniaScene");
				}
				else
				{
					Application.LoadLevel("HomeScene");
				}
			}
		}
	}

	public virtual void Skip()
	{
		int num = 0;
		Color color = this.Darkness.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Darkness.color = color;
		int num3 = 1;
		Color color3 = this.Logo.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.Logo.color = color3;
		this.audio.loop = true;
		this.audio.clip = this.BGM;
		this.audio.Play();
	}

	public virtual void Main()
	{
	}
}
