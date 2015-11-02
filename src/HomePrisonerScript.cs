using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class HomePrisonerScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public HomeWindowScript HomeWindow;

	public HomeDarknessScript Darkness;

	public PortraitChanScript Prisoner;

	public UILabel[] OptionLabels;

	public string[] Descriptions;

	public Transform TortureDestination;

	public Transform TortureTarget;

	public GameObject NowLoading;

	public Transform Highlight;

	public AudioSource Jukebox;

	public UILabel SanityLabel;

	public UILabel DescLabel;

	public UILabel Subtitle;

	public bool PlayedAudio;

	public bool ZoomIn;

	public float Sanity;

	public float Timer;

	public int ID;

	public AudioClip FirstTorture;

	public AudioClip Under50Torture;

	public AudioClip Over50Torture;

	public AudioClip TortureHit;

	public string[] FullSanityBanterText;

	public string[] HighSanityBanterText;

	public string[] LowSanityBanterText;

	public string[] NoSanityBanterText;

	public string[] BanterText;

	public AudioClip[] FullSanityBanter;

	public AudioClip[] HighSanityBanter;

	public AudioClip[] LowSanityBanter;

	public AudioClip[] NoSanityBanter;

	public AudioClip[] Banter;

	public float BanterTimer;

	public bool Bantering;

	public int BanterID;

	public HomePrisonerScript()
	{
		this.Sanity = 100f;
		this.ID = 1;
	}

	public virtual void Start()
	{
		this.Sanity = PlayerPrefs.GetFloat("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Sanity");
		this.SanityLabel.text = "Sanity: " + this.Sanity + "%";
		this.Prisoner.Sanity = this.Sanity;
		this.Subtitle.text = string.Empty;
		if (this.Sanity == (float)100)
		{
			this.BanterText = this.FullSanityBanterText;
			this.Banter = this.FullSanityBanter;
		}
		else if (this.Sanity >= (float)50)
		{
			this.BanterText = this.HighSanityBanterText;
			this.Banter = this.HighSanityBanter;
		}
		else if (this.Sanity == (float)0)
		{
			this.BanterText = this.NoSanityBanterText;
			this.Banter = this.NoSanityBanter;
		}
		else
		{
			this.BanterText = this.LowSanityBanterText;
			this.Banter = this.LowSanityBanter;
		}
		if (PlayerPrefs.GetInt("Night") == 0)
		{
			float a = 0.5f;
			Color color = this.OptionLabels[2].color;
			float num = color.a = a;
			Color color2 = this.OptionLabels[2].color = color;
		}
		else
		{
			float a2 = 0.5f;
			Color color3 = this.OptionLabels[1].color;
			float num2 = color3.a = a2;
			Color color4 = this.OptionLabels[1].color = color3;
			float a3 = 0.5f;
			Color color5 = this.OptionLabels[3].color;
			float num3 = color5.a = a3;
			Color color6 = this.OptionLabels[3].color = color5;
			float a4 = 0.5f;
			Color color7 = this.OptionLabels[4].color;
			float num4 = color7.a = a4;
			Color color8 = this.OptionLabels[4].color = color7;
		}
		if (this.Sanity > (float)0)
		{
			this.OptionLabels[5].text = "?????";
			float a5 = 0.5f;
			Color color9 = this.OptionLabels[5].color;
			float num5 = color9.a = a5;
			Color color10 = this.OptionLabels[5].color = color9;
		}
		else
		{
			this.OptionLabels[5].text = "Bring to School";
			float a6 = 0.5f;
			Color color11 = this.OptionLabels[1].color;
			float num6 = color11.a = a6;
			Color color12 = this.OptionLabels[1].color = color11;
			float a7 = 0.5f;
			Color color13 = this.OptionLabels[2].color;
			float num7 = color13.a = a7;
			Color color14 = this.OptionLabels[2].color = color13;
			float a8 = 0.5f;
			Color color15 = this.OptionLabels[3].color;
			float num8 = color15.a = a8;
			Color color16 = this.OptionLabels[3].color = color15;
			float a9 = 0.5f;
			Color color17 = this.OptionLabels[4].color;
			float num9 = color17.a = a9;
			Color color18 = this.OptionLabels[4].color = color17;
			int num10 = 1;
			Color color19 = this.OptionLabels[5].color;
			float num11 = color19.a = (float)num10;
			Color color20 = this.OptionLabels[5].color = color19;
			if (PlayerPrefs.GetInt("Night") == 1)
			{
				float a10 = 0.5f;
				Color color21 = this.OptionLabels[5].color;
				float num12 = color21.a = a10;
				Color color22 = this.OptionLabels[5].color = color21;
			}
		}
		this.UpdateDesc();
		if (PlayerPrefs.GetInt("Kidnapped") == 0)
		{
			this.enabled = false;
		}
	}

	public virtual void Update()
	{
		if (Vector3.Distance(this.HomeYandere.transform.position, this.Prisoner.transform.position) < (float)2 && this.HomeYandere.CanMove)
		{
			this.BanterTimer += Time.deltaTime;
			if (this.BanterTimer > (float)5 && !this.Bantering)
			{
				this.Bantering = true;
				if (this.BanterID < Extensions.get_length(this.Banter) - 1)
				{
					this.BanterID++;
					this.Subtitle.text = this.BanterText[this.BanterID];
					this.audio.clip = this.Banter[this.BanterID];
					this.audio.Play();
				}
			}
		}
		if (this.Bantering && !this.audio.isPlaying)
		{
			this.Subtitle.text = string.Empty;
			this.Bantering = false;
			this.BanterTimer = (float)0;
		}
		if (!this.HomeYandere.CanMove && (this.HomeCamera.Destination == this.HomeCamera.Destinations[10] || this.HomeCamera.Destination == this.TortureDestination))
		{
			if (this.InputManager.TappedDown)
			{
				this.ID++;
				if (this.ID > 5)
				{
					this.ID = 1;
				}
				int num = 465 - this.ID * 40;
				Vector3 localPosition = this.Highlight.localPosition;
				float num2 = localPosition.y = (float)num;
				Vector3 vector = this.Highlight.localPosition = localPosition;
				this.UpdateDesc();
			}
			if (this.InputManager.TappedUp)
			{
				this.ID--;
				if (this.ID < 1)
				{
					this.ID = 5;
				}
				int num3 = 465 - this.ID * 40;
				Vector3 localPosition2 = this.Highlight.localPosition;
				float num4 = localPosition2.y = (float)num3;
				Vector3 vector2 = this.Highlight.localPosition = localPosition2;
				this.UpdateDesc();
			}
			if (Input.GetKeyDown("x"))
			{
				this.Sanity -= (float)10;
				if (this.Sanity < (float)0)
				{
					this.Sanity = (float)100;
				}
				PlayerPrefs.SetFloat("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Sanity", this.Sanity);
				this.SanityLabel.text = "Sanity: " + this.Sanity + "%";
				this.Prisoner.UpdateSanity();
			}
			if (!this.ZoomIn)
			{
				if (Input.GetButtonDown("A") && this.OptionLabels[this.ID].color.a == (float)1)
				{
					if (this.Sanity > (float)0)
					{
						if (this.Sanity >= (float)50)
						{
							this.Prisoner.Character.animation.CrossFade("f02_kidnapTorture_00");
						}
						else
						{
							this.Prisoner.Character.animation.CrossFade("f02_kidnapSurrender_00");
							int num5 = 1;
							Vector3 localPosition3 = this.TortureDestination.localPosition;
							float num6 = localPosition3.z = (float)num5;
							Vector3 vector3 = this.TortureDestination.localPosition = localPosition3;
							int num7 = 0;
							Vector3 localPosition4 = this.TortureDestination.localPosition;
							float num8 = localPosition4.y = (float)num7;
							Vector3 vector4 = this.TortureDestination.localPosition = localPosition4;
							float y = 1.1f;
							Vector3 localPosition5 = this.TortureTarget.localPosition;
							float num9 = localPosition5.y = y;
							Vector3 vector5 = this.TortureTarget.localPosition = localPosition5;
						}
						this.HomeCamera.Destination = this.TortureDestination;
						this.HomeCamera.Target = this.TortureTarget;
						this.HomeCamera.Torturing = true;
						this.Prisoner.Tortured = true;
						this.Prisoner.RightEyeRotOrigin.x = (float)-6;
						this.Prisoner.LeftEyeRotOrigin.x = (float)6;
						this.ZoomIn = true;
					}
					else
					{
						this.Darkness.FadeOut = true;
					}
					this.HomeWindow.Show = false;
					this.HomeCamera.PromptBar.ClearButtons();
					this.HomeCamera.PromptBar.Show = false;
				}
				if (Input.GetButtonDown("B"))
				{
					this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
					this.HomeCamera.Target = this.HomeCamera.Targets[0];
					this.HomeCamera.PromptBar.ClearButtons();
					this.HomeCamera.PromptBar.Show = false;
					this.HomeYandere.CanMove = true;
					this.HomeYandere.active = true;
					this.HomeWindow.Show = false;
				}
			}
			else
			{
				this.TortureDestination.LookAt(this.TortureTarget);
				float z = this.TortureDestination.localPosition.z - Time.deltaTime * 0.02f;
				Vector3 localPosition6 = this.TortureDestination.localPosition;
				float num10 = localPosition6.z = z;
				Vector3 vector6 = this.TortureDestination.localPosition = localPosition6;
				this.Jukebox.volume = this.Jukebox.volume - Time.deltaTime * 0.1f;
				this.Timer += Time.deltaTime;
				if (this.Sanity >= (float)50)
				{
					float y2 = this.TortureDestination.localPosition.y - Time.deltaTime * 0.02f;
					Vector3 localPosition7 = this.TortureDestination.localPosition;
					float num11 = localPosition7.y = y2;
					Vector3 vector7 = this.TortureDestination.localPosition = localPosition7;
					if (this.Sanity == (float)100)
					{
						if (this.Timer > 2.5f && !this.PlayedAudio)
						{
							this.audio.clip = this.FirstTorture;
							this.PlayedAudio = true;
							this.audio.Play();
						}
					}
					else if (this.Timer > 1.5f && !this.PlayedAudio)
					{
						this.audio.clip = this.Over50Torture;
						this.PlayedAudio = true;
						this.audio.Play();
					}
				}
				else if (this.Timer > (float)5 && !this.PlayedAudio)
				{
					this.audio.clip = this.Under50Torture;
					this.PlayedAudio = true;
					this.audio.Play();
				}
				if (this.Timer > (float)10 && this.Darkness.Sprite.color.a != (float)1)
				{
					this.Darkness.enabled = false;
					int num12 = 1;
					Color color = this.Darkness.Sprite.color;
					float num13 = color.a = (float)num12;
					Color color2 = this.Darkness.Sprite.color = color;
					this.audio.clip = this.TortureHit;
					this.audio.Play();
				}
				if (this.Timer > (float)15)
				{
					if (this.ID == 1)
					{
						Time.timeScale = (float)1;
						this.NowLoading.active = true;
						PlayerPrefs.SetInt("Late", 1);
						Application.LoadLevel("SchoolScene");
						PlayerPrefs.SetFloat("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Sanity", this.Sanity - 2.5f);
					}
					else if (this.ID == 2)
					{
						Application.LoadLevel("CalendarScene");
						PlayerPrefs.SetFloat("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Sanity", this.Sanity - (float)10);
						PlayerPrefs.SetFloat("Reputation", PlayerPrefs.GetFloat("Reputation") - (float)20);
					}
					else if (this.ID == 3)
					{
						PlayerPrefs.SetInt("Night", 1);
						Application.LoadLevel("HomeScene");
						PlayerPrefs.SetFloat("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Sanity", this.Sanity - (float)30);
						PlayerPrefs.SetFloat("Reputation", PlayerPrefs.GetFloat("Reputation") - (float)20);
					}
					else if (this.ID == 4)
					{
						Application.LoadLevel("CalendarScene");
						PlayerPrefs.SetFloat("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Sanity", this.Sanity - (float)45);
						PlayerPrefs.SetFloat("Reputation", PlayerPrefs.GetFloat("Reputation") - (float)20);
					}
					if (PlayerPrefs.GetFloat("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Sanity") < (float)0)
					{
						PlayerPrefs.SetFloat("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Sanity", (float)0);
					}
				}
			}
		}
	}

	public virtual void UpdateDesc()
	{
		this.HomeCamera.PromptBar.Label[0].text = "Accept";
		this.DescLabel.text = string.Empty + this.Descriptions[this.ID];
		if (PlayerPrefs.GetInt("Night") == 0)
		{
			if (this.ID == 2)
			{
				this.DescLabel.text = "This option is unavailable in the daytime.";
				this.HomeCamera.PromptBar.Label[0].text = string.Empty;
			}
		}
		else if (this.ID != 2)
		{
			this.DescLabel.text = "This option is unavailable at nighttime.";
			this.HomeCamera.PromptBar.Label[0].text = string.Empty;
		}
		if (this.ID == 5)
		{
			if (this.Sanity > (float)0)
			{
				this.DescLabel.text = "This option is unavailable until your prisoner's Sanity has reached zero.";
			}
			if (PlayerPrefs.GetInt("Night") == 1)
			{
				this.DescLabel.text = "This option is unavailable at nighttime.";
				this.HomeCamera.PromptBar.Label[0].text = string.Empty;
			}
		}
		this.HomeCamera.PromptBar.UpdateButtons();
	}

	public virtual void Main()
	{
	}
}
