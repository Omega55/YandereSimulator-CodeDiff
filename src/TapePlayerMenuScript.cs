using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class TapePlayerMenuScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public TapePlayerScript TapePlayer;

	public PromptBarScript PromptBar;

	public GameObject Jukebox;

	public Transform TapePlayerCamera;

	public Transform Highlight;

	public Transform TimeBar;

	public Transform List;

	public AudioClip[] Recordings;

	public UILabel[] TapeLabels;

	public GameObject[] NewIcons;

	public AudioClip TapeStop;

	public string CurrentTime;

	public string ClipLength;

	public bool Listening;

	public bool Show;

	public UILabel Subtitle;

	public UILabel Label;

	public UISprite Bar;

	public int TotalTapes;

	public int Selected;

	public int Phase;

	public float RoundedTime;

	public float ResumeTime;

	public float Timer;

	public float[] Cues1;

	public float[] Cues2;

	public float[] Cues3;

	public float[] Cues4;

	public float[] Cues5;

	public float[] Cues6;

	public float[] Cues7;

	public float[] Cues8;

	public float[] Cues9;

	public float[] Cues10;

	public string[] Subs1;

	public string[] Subs2;

	public string[] Subs3;

	public string[] Subs4;

	public string[] Subs5;

	public string[] Subs6;

	public string[] Subs7;

	public string[] Subs8;

	public string[] Subs9;

	public string[] Subs10;

	public TapePlayerMenuScript()
	{
		this.TotalTapes = 10;
		this.Selected = 1;
		this.Phase = 1;
	}

	public virtual void Start()
	{
		int num = -955;
		Vector3 localPosition = this.List.transform.localPosition;
		float num2 = localPosition.x = (float)num;
		Vector3 vector = this.List.transform.localPosition = localPosition;
		int num3 = 100;
		Vector3 localPosition2 = this.TimeBar.localPosition;
		float num4 = localPosition2.y = (float)num3;
		Vector3 vector2 = this.TimeBar.localPosition = localPosition2;
		this.Subtitle.text = string.Empty;
		float x = 18.56667f;
		Vector3 position = this.TapePlayerCamera.position;
		float num5 = position.x = x;
		Vector3 vector3 = this.TapePlayerCamera.position = position;
		float z = 7.766667f;
		Vector3 position2 = this.TapePlayerCamera.position;
		float num6 = position2.z = z;
		Vector3 vector4 = this.TapePlayerCamera.position = position2;
	}

	public virtual void Update()
	{
		if (!this.Show)
		{
			float x = Mathf.Lerp(this.List.transform.localPosition.x, (float)-955, 0.166666672f);
			Vector3 localPosition = this.List.transform.localPosition;
			float num = localPosition.x = x;
			Vector3 vector = this.List.transform.localPosition = localPosition;
			float y = Mathf.Lerp(this.TimeBar.localPosition.y, (float)100, 0.166666672f);
			Vector3 localPosition2 = this.TimeBar.localPosition;
			float num2 = localPosition2.y = y;
			Vector3 vector2 = this.TimeBar.localPosition = localPosition2;
		}
		else if (this.Listening)
		{
			float x2 = Mathf.Lerp(this.List.transform.localPosition.x, (float)-955, 0.166666672f);
			Vector3 localPosition3 = this.List.transform.localPosition;
			float num3 = localPosition3.x = x2;
			Vector3 vector3 = this.List.transform.localPosition = localPosition3;
			float y2 = Mathf.Lerp(this.TimeBar.localPosition.y, (float)0, 0.166666672f);
			Vector3 localPosition4 = this.TimeBar.localPosition;
			float num4 = localPosition4.y = y2;
			Vector3 vector4 = this.TimeBar.localPosition = localPosition4;
			float x3 = Mathf.Lerp(this.TapePlayerCamera.position.x, 18.65f, 0.166666672f);
			Vector3 position = this.TapePlayerCamera.position;
			float num5 = position.x = x3;
			Vector3 vector5 = this.TapePlayerCamera.position = position;
			float z = Mathf.Lerp(this.TapePlayerCamera.position.z, 7.85f, 0.166666672f);
			Vector3 position2 = this.TapePlayerCamera.position;
			float num6 = position2.z = z;
			Vector3 vector6 = this.TapePlayerCamera.position = position2;
			if (this.Phase == 1)
			{
				this.TapePlayer.animation["InsertTape"].time = this.TapePlayer.animation["InsertTape"].time + 0.0555555f;
				if (this.TapePlayer.animation["InsertTape"].time >= this.TapePlayer.animation["InsertTape"].length)
				{
					this.TapePlayer.animation.Play("PressPlay");
					this.audio.Play();
					this.PromptBar.Label[0].text = "PAUSE";
					this.PromptBar.Label[1].text = "STOP";
					this.PromptBar.Label[5].text = "REWIND / FAST FORWARD";
					this.PromptBar.UpdateButtons();
					this.Phase++;
				}
			}
			else if (this.Phase == 2)
			{
				this.Timer += 0.0166666675f;
				if (this.audio.isPlaying)
				{
					if (this.Timer > 0.1f)
					{
						this.TapePlayer.animation["PressPlay"].time = this.TapePlayer.animation["PressPlay"].time + 0.0166666675f;
						if (this.TapePlayer.animation["PressPlay"].time > this.TapePlayer.animation["PressPlay"].length)
						{
							this.TapePlayer.animation["PressPlay"].time = this.TapePlayer.animation["PressPlay"].length;
						}
					}
				}
				else
				{
					this.TapePlayer.animation["PressPlay"].time = this.TapePlayer.animation["PressPlay"].time - 0.0166666675f;
					if (this.TapePlayer.animation["PressPlay"].time < (float)0)
					{
						this.TapePlayer.animation["PressPlay"].time = (float)0;
					}
					if (Input.GetButtonDown("A"))
					{
						this.PromptBar.Label[0].text = "PAUSE";
						this.TapePlayer.Spin = true;
						this.audio.time = this.ResumeTime;
						this.audio.Play();
					}
				}
				if (this.TapePlayer.animation["PressPlay"].time >= this.TapePlayer.animation["PressPlay"].length)
				{
					this.TapePlayer.Spin = true;
					if (this.audio.time >= this.audio.clip.length - (float)1)
					{
						this.TapePlayer.animation.Play("PressEject");
						this.TapePlayer.Spin = false;
						if (!this.audio.isPlaying)
						{
							this.audio.clip = this.TapeStop;
							this.audio.Play();
						}
						this.Subtitle.text = string.Empty;
						this.Phase++;
					}
					if (Input.GetButtonDown("A") && this.audio.isPlaying)
					{
						this.PromptBar.Label[0].text = "PLAY";
						this.TapePlayer.Spin = false;
						this.ResumeTime = this.audio.time;
						this.audio.Stop();
					}
				}
				if (Input.GetButtonDown("B"))
				{
					this.TapePlayer.animation.Play("PressEject");
					this.audio.clip = this.TapeStop;
					this.TapePlayer.Spin = false;
					this.audio.Play();
					this.PromptBar.Label[0].text = string.Empty;
					this.PromptBar.Label[1].text = string.Empty;
					this.PromptBar.Label[5].text = string.Empty;
					this.PromptBar.UpdateButtons();
					this.Subtitle.text = string.Empty;
					this.Phase++;
				}
			}
			else if (this.Phase == 3)
			{
				this.TapePlayer.animation["PressEject"].time = this.TapePlayer.animation["PressEject"].time + 0.0166666675f;
				if (this.TapePlayer.animation["PressEject"].time >= this.TapePlayer.animation["PressEject"].length)
				{
					this.TapePlayer.animation.Play("InsertTape");
					this.TapePlayer.animation["InsertTape"].time = this.TapePlayer.animation["InsertTape"].length;
					this.TapePlayer.FastForward = false;
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				this.TapePlayer.animation["InsertTape"].time = this.TapePlayer.animation["InsertTape"].time - 0.0555555f;
				if (this.TapePlayer.animation["InsertTape"].time <= (float)0)
				{
					this.TapePlayer.Tape.active = false;
					this.Jukebox.active = true;
					this.Listening = false;
					this.Timer = (float)0;
					this.PromptBar.Label[0].text = "PLAY";
					this.PromptBar.Label[1].text = "BACK";
					this.PromptBar.Label[4].text = "CHOOSE";
					this.PromptBar.UpdateButtons();
				}
			}
			if (this.Phase == 2)
			{
				if (this.InputManager.DPadRight || Input.GetKey("right"))
				{
					this.ResumeTime += 1.66666663f;
					this.audio.time = this.audio.time + 1.66666663f;
					this.TapePlayer.FastForward = true;
				}
				else
				{
					this.TapePlayer.FastForward = false;
				}
				if (this.InputManager.DPadLeft || Input.GetKey("left"))
				{
					this.ResumeTime -= 1.66666663f;
					this.audio.time = this.audio.time - 1.66666663f;
					this.TapePlayer.Rewind = true;
				}
				else
				{
					this.TapePlayer.Rewind = false;
				}
				int num7;
				int num8;
				if (this.audio.isPlaying)
				{
					num7 = Mathf.FloorToInt(this.audio.time / 60f);
					num8 = Mathf.FloorToInt(this.audio.time - (float)(num7 * 60));
					this.Bar.fillAmount = this.audio.time / this.audio.clip.length;
				}
				else
				{
					num7 = Mathf.FloorToInt(this.ResumeTime / 60f);
					num8 = Mathf.FloorToInt(this.ResumeTime - (float)(num7 * 60));
					this.Bar.fillAmount = this.ResumeTime / this.audio.clip.length;
				}
				this.CurrentTime = string.Format("{00:00}:{1:00}", num7, num8);
				this.Label.text = this.CurrentTime + " / " + this.ClipLength;
				if (this.Selected == 1)
				{
					for (int i = 0; i < Extensions.get_length(this.Cues1); i++)
					{
						if (this.audio.time > this.Cues1[i])
						{
							this.Subtitle.text = this.Subs1[i];
						}
					}
				}
				else if (this.Selected == 2)
				{
					for (int i = 0; i < Extensions.get_length(this.Cues2); i++)
					{
						if (this.audio.time > this.Cues2[i])
						{
							this.Subtitle.text = this.Subs2[i];
						}
					}
				}
				else if (this.Selected == 3)
				{
					for (int i = 0; i < Extensions.get_length(this.Cues3); i++)
					{
						if (this.audio.time > this.Cues3[i])
						{
							this.Subtitle.text = this.Subs3[i];
						}
					}
				}
				else if (this.Selected == 4)
				{
					for (int i = 0; i < Extensions.get_length(this.Cues4); i++)
					{
						if (this.audio.time > this.Cues4[i])
						{
							this.Subtitle.text = this.Subs4[i];
						}
					}
				}
				else if (this.Selected == 5)
				{
					for (int i = 0; i < Extensions.get_length(this.Cues5); i++)
					{
						if (this.audio.time > this.Cues5[i])
						{
							this.Subtitle.text = this.Subs5[i];
						}
					}
				}
				else if (this.Selected == 6)
				{
					for (int i = 0; i < Extensions.get_length(this.Cues6); i++)
					{
						if (this.audio.time > this.Cues6[i])
						{
							this.Subtitle.text = this.Subs6[i];
						}
					}
				}
				else if (this.Selected == 7)
				{
					for (int i = 0; i < Extensions.get_length(this.Cues7); i++)
					{
						if (this.audio.time > this.Cues7[i])
						{
							this.Subtitle.text = this.Subs7[i];
						}
					}
				}
				else if (this.Selected == 8)
				{
					for (int i = 0; i < Extensions.get_length(this.Cues8); i++)
					{
						if (this.audio.time > this.Cues8[i])
						{
							this.Subtitle.text = this.Subs8[i];
						}
					}
				}
				else if (this.Selected == 9)
				{
					for (int i = 0; i < Extensions.get_length(this.Cues9); i++)
					{
						if (this.audio.time > this.Cues9[i])
						{
							this.Subtitle.text = this.Subs9[i];
						}
					}
				}
				else if (this.Selected == 10)
				{
					for (int i = 0; i < Extensions.get_length(this.Cues10); i++)
					{
						if (this.audio.time > this.Cues10[i])
						{
							this.Subtitle.text = this.Subs10[i];
						}
					}
				}
			}
			else
			{
				this.Label.text = "00:00 / 00:00";
				this.Bar.fillAmount = (float)0;
			}
		}
		else
		{
			float x4 = Mathf.Lerp(this.TapePlayerCamera.position.x, 18.56667f, 0.166666672f);
			Vector3 position3 = this.TapePlayerCamera.position;
			float num9 = position3.x = x4;
			Vector3 vector7 = this.TapePlayerCamera.position = position3;
			float z2 = Mathf.Lerp(this.TapePlayerCamera.position.z, 7.766667f, 0.166666672f);
			Vector3 position4 = this.TapePlayerCamera.position;
			float num10 = position4.z = z2;
			Vector3 vector8 = this.TapePlayerCamera.position = position4;
			float x5 = Mathf.Lerp(this.List.transform.localPosition.x, (float)0, 0.166666672f);
			Vector3 localPosition5 = this.List.transform.localPosition;
			float num11 = localPosition5.x = x5;
			Vector3 vector9 = this.List.transform.localPosition = localPosition5;
			float y3 = Mathf.Lerp(this.TimeBar.localPosition.y, (float)100, 0.166666672f);
			Vector3 localPosition6 = this.TimeBar.localPosition;
			float num12 = localPosition6.y = y3;
			Vector3 vector10 = this.TimeBar.localPosition = localPosition6;
			if (Input.GetButtonDown("A") && PlayerPrefs.GetInt("Tape_" + this.Selected + "_Collected") == 1)
			{
				PlayerPrefs.SetInt("Tape_" + this.Selected + "_Listened", 1);
				this.NewIcons[this.Selected].active = false;
				this.Jukebox.active = false;
				this.Listening = true;
				this.Phase = 1;
				this.PromptBar.Label[0].text = string.Empty;
				this.PromptBar.Label[1].text = string.Empty;
				this.PromptBar.Label[4].text = string.Empty;
				this.PromptBar.UpdateButtons();
				this.TapePlayer.animation.Play("InsertTape");
				this.TapePlayer.Tape.active = true;
				this.audio.clip = this.Recordings[this.Selected];
				this.audio.time = (float)0;
				this.RoundedTime = (float)Mathf.CeilToInt(this.audio.clip.length);
				int num7 = (int)(this.RoundedTime / (float)60);
				int num8 = (int)(this.RoundedTime % (float)60);
				this.ClipLength = string.Format("{0:00}:{1:00}", num7, num8);
			}
			if (Input.GetButtonDown("B"))
			{
				this.TapePlayer.Yandere.HeartCamera.enabled = true;
				this.TapePlayer.TapePlayerCamera.enabled = false;
				this.TapePlayer.PromptBar.ClearButtons();
				this.TapePlayer.Yandere.CanMove = true;
				this.TapePlayer.PromptBar.Show = false;
				this.TapePlayer.Prompt.enabled = true;
				this.TapePlayer.Yandere.HUD.alpha = (float)1;
				Time.timeScale = (float)1;
				this.Show = false;
			}
			if (this.InputManager.TappedUp)
			{
				this.Selected--;
				if (this.Selected < 1)
				{
					this.Selected = 10;
				}
				int num13 = 440 - 80 * this.Selected;
				Vector3 localPosition7 = this.Highlight.localPosition;
				float num14 = localPosition7.y = (float)num13;
				Vector3 vector11 = this.Highlight.localPosition = localPosition7;
				this.CheckSelection();
			}
			if (this.InputManager.TappedDown)
			{
				this.Selected++;
				if (this.Selected > 10)
				{
					this.Selected = 1;
				}
				int num15 = 440 - 80 * this.Selected;
				Vector3 localPosition8 = this.Highlight.localPosition;
				float num16 = localPosition8.y = (float)num15;
				Vector3 vector12 = this.Highlight.localPosition = localPosition8;
				this.CheckSelection();
			}
		}
	}

	public virtual void UpdateLabels()
	{
		int i = 0;
		while (i < this.TotalTapes)
		{
			i++;
			if (PlayerPrefs.GetInt("Tape_" + i + "_Collected") == 1)
			{
				this.TapeLabels[i].text = "Mysterious Tape " + i;
				if (PlayerPrefs.GetInt("Tape_" + i + "_Listened") == 1)
				{
					this.NewIcons[i].active = false;
				}
				else
				{
					this.NewIcons[i].active = true;
				}
			}
			else
			{
				this.TapeLabels[i].text = "?????";
				this.NewIcons[i].active = false;
			}
		}
	}

	public virtual void CheckSelection()
	{
		if (PlayerPrefs.GetInt("Tape_" + this.Selected + "_Collected") == 1)
		{
			this.TapePlayer.PromptBar.Label[0].text = "PLAY";
			this.TapePlayer.PromptBar.UpdateButtons();
		}
		else
		{
			this.TapePlayer.PromptBar.Label[0].text = string.Empty;
			this.TapePlayer.PromptBar.UpdateButtons();
		}
	}

	public virtual void Main()
	{
	}
}
