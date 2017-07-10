﻿using System;
using UnityEngine;

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

	public AudioClip[] BasementRecordings;

	public UILabel[] TapeLabels;

	public GameObject[] NewIcons;

	public AudioClip TapeStop;

	public string CurrentTime;

	public string ClipLength;

	public bool Listening;

	public bool Show;

	public UILabel HeaderLabel;

	public UILabel Subtitle;

	public UILabel Label;

	public UISprite Bar;

	public int TotalTapes = 10;

	public int Category = 1;

	public int Selected = 1;

	public int Phase = 1;

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

	public float[] BasementCues1;

	public float[] BasementCues10;

	public string[] BasementSubs1;

	public string[] BasementSubs10;

	private void Start()
	{
		this.List.transform.localPosition = new Vector3(-955f, this.List.transform.localPosition.y, this.List.transform.localPosition.z);
		this.TimeBar.localPosition = new Vector3(this.TimeBar.localPosition.x, 100f, this.TimeBar.localPosition.z);
		this.Subtitle.text = string.Empty;
		this.TapePlayerCamera.position = new Vector3(-26.15f, this.TapePlayerCamera.position.y, 5.35f);
	}

	private void Update()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		if (!this.Show)
		{
			if (this.List.localPosition.x > -955f)
			{
				this.List.localPosition = new Vector3(Mathf.Lerp(this.List.localPosition.x, -956f, 0.166666672f), this.List.localPosition.y, this.List.localPosition.z);
				this.TimeBar.localPosition = new Vector3(this.TimeBar.localPosition.x, Mathf.Lerp(this.TimeBar.localPosition.y, 100f, 0.166666672f), this.TimeBar.localPosition.z);
			}
			else
			{
				this.TimeBar.gameObject.SetActive(false);
				this.List.gameObject.SetActive(false);
			}
		}
		else if (this.Listening)
		{
			this.List.localPosition = new Vector3(Mathf.Lerp(this.List.localPosition.x, -955f, 0.166666672f), this.List.localPosition.y, this.List.localPosition.z);
			this.TimeBar.localPosition = new Vector3(this.TimeBar.localPosition.x, Mathf.Lerp(this.TimeBar.localPosition.y, 0f, 0.166666672f), this.TimeBar.localPosition.z);
			this.TapePlayerCamera.position = new Vector3(Mathf.Lerp(this.TapePlayerCamera.position.x, -26.15f, 0.166666672f), this.TapePlayerCamera.position.y, Mathf.Lerp(this.TapePlayerCamera.position.z, 5.35f, 0.166666672f));
			if (this.Phase == 1)
			{
				this.TapePlayer.GetComponent<Animation>()["InsertTape"].time += 0.0555555f;
				if (this.TapePlayer.GetComponent<Animation>()["InsertTape"].time >= this.TapePlayer.GetComponent<Animation>()["InsertTape"].length)
				{
					this.TapePlayer.GetComponent<Animation>().Play("PressPlay");
					component.Play();
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
				if (component.isPlaying)
				{
					if ((double)this.Timer > 0.1)
					{
						this.TapePlayer.GetComponent<Animation>()["PressPlay"].time += 0.0166666675f;
						if (this.TapePlayer.GetComponent<Animation>()["PressPlay"].time > this.TapePlayer.GetComponent<Animation>()["PressPlay"].length)
						{
							this.TapePlayer.GetComponent<Animation>()["PressPlay"].time = this.TapePlayer.GetComponent<Animation>()["PressPlay"].length;
						}
					}
				}
				else
				{
					this.TapePlayer.GetComponent<Animation>()["PressPlay"].time -= 0.0166666675f;
					if (this.TapePlayer.GetComponent<Animation>()["PressPlay"].time < 0f)
					{
						this.TapePlayer.GetComponent<Animation>()["PressPlay"].time = 0f;
					}
					if (Input.GetButtonDown("A"))
					{
						this.PromptBar.Label[0].text = "PAUSE";
						this.TapePlayer.Spin = true;
						component.time = this.ResumeTime;
						component.Play();
					}
				}
				if (this.TapePlayer.GetComponent<Animation>()["PressPlay"].time >= this.TapePlayer.GetComponent<Animation>()["PressPlay"].length)
				{
					this.TapePlayer.Spin = true;
					if (component.time >= component.clip.length - 1f)
					{
						this.TapePlayer.GetComponent<Animation>().Play("PressEject");
						this.TapePlayer.Spin = false;
						if (!component.isPlaying)
						{
							component.clip = this.TapeStop;
							component.Play();
						}
						this.Subtitle.text = string.Empty;
						this.Phase++;
					}
					if (Input.GetButtonDown("A") && component.isPlaying)
					{
						this.PromptBar.Label[0].text = "PLAY";
						this.TapePlayer.Spin = false;
						this.ResumeTime = component.time;
						component.Stop();
					}
				}
				if (Input.GetButtonDown("B"))
				{
					this.TapePlayer.GetComponent<Animation>().Play("PressEject");
					component.clip = this.TapeStop;
					this.TapePlayer.Spin = false;
					component.Play();
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
				this.TapePlayer.GetComponent<Animation>()["PressEject"].time += 0.0166666675f;
				if (this.TapePlayer.GetComponent<Animation>()["PressEject"].time >= this.TapePlayer.GetComponent<Animation>()["PressEject"].length)
				{
					this.TapePlayer.GetComponent<Animation>().Play("InsertTape");
					this.TapePlayer.GetComponent<Animation>()["InsertTape"].time = this.TapePlayer.GetComponent<Animation>()["InsertTape"].length;
					this.TapePlayer.FastForward = false;
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				this.TapePlayer.GetComponent<Animation>()["InsertTape"].time -= 0.0555555f;
				if (this.TapePlayer.GetComponent<Animation>()["InsertTape"].time <= 0f)
				{
					this.TapePlayer.Tape.SetActive(false);
					this.Jukebox.SetActive(true);
					this.Listening = false;
					this.Timer = 0f;
					this.PromptBar.Label[0].text = "PLAY";
					this.PromptBar.Label[1].text = "BACK";
					this.PromptBar.Label[4].text = "CHOOSE";
					this.PromptBar.Label[5].text = "CATEGORY";
					this.PromptBar.UpdateButtons();
				}
			}
			if (this.Phase == 2)
			{
				if (this.InputManager.DPadRight || Input.GetKey("right"))
				{
					this.ResumeTime += 1.66666663f;
					component.time += 1.66666663f;
					this.TapePlayer.FastForward = true;
				}
				else
				{
					this.TapePlayer.FastForward = false;
				}
				if (this.InputManager.DPadLeft || Input.GetKey("left"))
				{
					this.ResumeTime -= 1.66666663f;
					component.time -= 1.66666663f;
					this.TapePlayer.Rewind = true;
				}
				else
				{
					this.TapePlayer.Rewind = false;
				}
				int num;
				int num2;
				if (component.isPlaying)
				{
					num = Mathf.FloorToInt(component.time / 60f);
					num2 = Mathf.FloorToInt(component.time - (float)num * 60f);
					this.Bar.fillAmount = component.time / component.clip.length;
				}
				else
				{
					num = Mathf.FloorToInt(this.ResumeTime / 60f);
					num2 = Mathf.FloorToInt(this.ResumeTime - (float)num * 60f);
					this.Bar.fillAmount = this.ResumeTime / component.clip.length;
				}
				this.CurrentTime = string.Format("{00:00}:{1:00}", num, num2);
				this.Label.text = this.CurrentTime + " / " + this.ClipLength;
				if (this.Category == 1)
				{
					if (this.Selected == 1)
					{
						for (int i = 0; i < this.Cues1.Length; i++)
						{
							if (component.time > this.Cues1[i])
							{
								this.Subtitle.text = this.Subs1[i];
							}
						}
					}
					else if (this.Selected == 2)
					{
						for (int j = 0; j < this.Cues2.Length; j++)
						{
							if (component.time > this.Cues2[j])
							{
								this.Subtitle.text = this.Subs2[j];
							}
						}
					}
					else if (this.Selected == 3)
					{
						for (int k = 0; k < this.Cues3.Length; k++)
						{
							if (component.time > this.Cues3[k])
							{
								this.Subtitle.text = this.Subs3[k];
							}
						}
					}
					else if (this.Selected == 4)
					{
						for (int l = 0; l < this.Cues4.Length; l++)
						{
							if (component.time > this.Cues4[l])
							{
								this.Subtitle.text = this.Subs4[l];
							}
						}
					}
					else if (this.Selected == 5)
					{
						for (int m = 0; m < this.Cues5.Length; m++)
						{
							if (component.time > this.Cues5[m])
							{
								this.Subtitle.text = this.Subs5[m];
							}
						}
					}
					else if (this.Selected == 6)
					{
						for (int n = 0; n < this.Cues6.Length; n++)
						{
							if (component.time > this.Cues6[n])
							{
								this.Subtitle.text = this.Subs6[n];
							}
						}
					}
					else if (this.Selected == 7)
					{
						for (int num3 = 0; num3 < this.Cues7.Length; num3++)
						{
							if (component.time > this.Cues7[num3])
							{
								this.Subtitle.text = this.Subs7[num3];
							}
						}
					}
					else if (this.Selected == 8)
					{
						for (int num4 = 0; num4 < this.Cues8.Length; num4++)
						{
							if (component.time > this.Cues8[num4])
							{
								this.Subtitle.text = this.Subs8[num4];
							}
						}
					}
					else if (this.Selected == 9)
					{
						for (int num5 = 0; num5 < this.Cues9.Length; num5++)
						{
							if (component.time > this.Cues9[num5])
							{
								this.Subtitle.text = this.Subs9[num5];
							}
						}
					}
					else if (this.Selected == 10)
					{
						for (int num6 = 0; num6 < this.Cues10.Length; num6++)
						{
							if (component.time > this.Cues10[num6])
							{
								this.Subtitle.text = this.Subs10[num6];
							}
						}
					}
				}
				else
				{
					if (this.Selected == 1)
					{
						for (int num7 = 0; num7 < this.BasementCues1.Length; num7++)
						{
							if (component.time > this.BasementCues1[num7])
							{
								this.Subtitle.text = this.BasementSubs1[num7];
							}
						}
					}
					if (this.Selected == 10)
					{
						for (int num8 = 0; num8 < this.BasementCues10.Length; num8++)
						{
							if (component.time > this.BasementCues10[num8])
							{
								this.Subtitle.text = this.BasementSubs10[num8];
							}
						}
					}
				}
			}
			else
			{
				this.Label.text = "00:00 / 00:00";
				this.Bar.fillAmount = 0f;
			}
		}
		else
		{
			this.TapePlayerCamera.position = new Vector3(Mathf.Lerp(this.TapePlayerCamera.position.x, -26.2125f, 0.166666672f), this.TapePlayerCamera.position.y, Mathf.Lerp(this.TapePlayerCamera.position.z, 5.4125f, 0.166666672f));
			this.List.transform.localPosition = new Vector3(Mathf.Lerp(this.List.transform.localPosition.x, 0f, 0.166666672f), this.List.transform.localPosition.y, this.List.transform.localPosition.z);
			this.TimeBar.localPosition = new Vector3(this.TimeBar.localPosition.x, Mathf.Lerp(this.TimeBar.localPosition.y, 100f, 0.166666672f), this.TimeBar.localPosition.z);
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				this.Category = ((this.Category != 1) ? 1 : 2);
				this.UpdateLabels();
			}
			if (this.InputManager.TappedUp)
			{
				this.Selected--;
				if (this.Selected < 1)
				{
					this.Selected = 10;
				}
				this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 440f - 80f * (float)this.Selected, this.Highlight.localPosition.z);
				this.CheckSelection();
			}
			else if (this.InputManager.TappedDown)
			{
				this.Selected++;
				if (this.Selected > 10)
				{
					this.Selected = 1;
				}
				this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 440f - 80f * (float)this.Selected, this.Highlight.localPosition.z);
				this.CheckSelection();
			}
			else if (Input.GetButtonDown("A"))
			{
				bool flag = false;
				if (this.Category == 1)
				{
					if (PlayerPrefs.GetInt("Tape_" + this.Selected.ToString() + "_Collected") == 1)
					{
						PlayerPrefs.SetInt("Tape_" + this.Selected.ToString() + "_Listened", 1);
						flag = true;
					}
				}
				else if (PlayerPrefs.GetInt("BasementTape_" + this.Selected.ToString() + "_Collected") == 1)
				{
					PlayerPrefs.SetInt("BasementTape_" + this.Selected.ToString() + "_Listened", 1);
					flag = true;
				}
				if (flag)
				{
					this.NewIcons[this.Selected].SetActive(false);
					this.Jukebox.SetActive(false);
					this.Listening = true;
					this.Phase = 1;
					this.PromptBar.Label[0].text = string.Empty;
					this.PromptBar.Label[1].text = string.Empty;
					this.PromptBar.Label[4].text = string.Empty;
					this.PromptBar.UpdateButtons();
					this.TapePlayer.GetComponent<Animation>().Play("InsertTape");
					this.TapePlayer.Tape.SetActive(true);
					if (this.Category == 1)
					{
						component.clip = this.Recordings[this.Selected];
					}
					else
					{
						component.clip = this.BasementRecordings[this.Selected];
					}
					component.time = 0f;
					this.RoundedTime = (float)Mathf.CeilToInt(component.clip.length);
					int num9 = (int)(this.RoundedTime / 60f);
					int num10 = (int)(this.RoundedTime % 60f);
					this.ClipLength = string.Format("{0:00}:{1:00}", num9, num10);
				}
			}
			else if (Input.GetButtonDown("B"))
			{
				this.TapePlayer.Yandere.HeartCamera.enabled = true;
				this.TapePlayer.Yandere.RPGCamera.enabled = true;
				this.TapePlayer.TapePlayerCamera.enabled = false;
				this.TapePlayer.NoteWindow.SetActive(true);
				this.TapePlayer.PromptBar.ClearButtons();
				this.TapePlayer.Yandere.CanMove = true;
				this.TapePlayer.PromptBar.Show = false;
				this.TapePlayer.Prompt.enabled = true;
				this.TapePlayer.Yandere.HUD.alpha = 1f;
				Time.timeScale = 1f;
				this.Show = false;
			}
		}
	}

	public void UpdateLabels()
	{
		int i = 0;
		while (i < this.TotalTapes)
		{
			i++;
			if (this.Category == 1)
			{
				this.HeaderLabel.text = "Mysterious Tapes";
				if (PlayerPrefs.GetInt("Tape_" + i.ToString() + "_Collected") == 1)
				{
					this.TapeLabels[i].text = "Mysterious Tape " + i.ToString();
					this.NewIcons[i].SetActive(PlayerPrefs.GetInt("Tape_" + i.ToString() + "_Listened") != 1);
				}
				else
				{
					this.TapeLabels[i].text = "?????";
					this.NewIcons[i].SetActive(false);
				}
			}
			else
			{
				this.HeaderLabel.text = "Basement Tapes";
				if (PlayerPrefs.GetInt("BasementTape_" + i.ToString() + "_Collected") == 1)
				{
					this.TapeLabels[i].text = "Basement Tape " + i.ToString();
					this.NewIcons[i].SetActive(PlayerPrefs.GetInt("BasementTape_" + i.ToString() + "_Listened") != 1);
				}
				else
				{
					this.TapeLabels[i].text = "?????";
					this.NewIcons[i].SetActive(false);
				}
			}
		}
	}

	public void CheckSelection()
	{
		if (this.Category == 1)
		{
			this.TapePlayer.PromptBar.Label[0].text = ((PlayerPrefs.GetInt("Tape_" + this.Selected.ToString() + "_Collected") != 1) ? string.Empty : "PLAY");
			this.TapePlayer.PromptBar.UpdateButtons();
		}
		else
		{
			this.TapePlayer.PromptBar.Label[0].text = ((PlayerPrefs.GetInt("BasementTape_" + this.Selected.ToString() + "_Collected") != 1) ? string.Empty : "PLAY");
			this.TapePlayer.PromptBar.UpdateButtons();
		}
	}
}
