using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenocideEndingScript : MonoBehaviour
{
	public AudioSource MyAudio;

	public UISprite Darkness;

	public UILabel Subtitle;

	public Animation Senpai;

	public Transform Neck;

	public AudioClip[] SpeechClip;

	public string[] SpeechText;

	public float[] SpeechDelay;

	public float[] SpeechTime;

	public int SpeechPhase;

	public float Alpha;

	public float Delay;

	public float Timer;

	private void Start()
	{
		this.Senpai["kidnapTorture_01"].speed = 0.9f;
		Time.timeScale = 1f;
	}

	private void Update()
	{
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += 1f;
			this.MyAudio.pitch = Time.timeScale;
		}
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale -= 1f;
			this.MyAudio.pitch = Time.timeScale;
		}
		if (this.SpeechPhase > 9)
		{
			base.transform.Translate(Vector3.forward * -0.1f * Time.deltaTime);
			if (this.MyAudio.isPlaying)
			{
				this.Senpai.Play();
				if (this.MyAudio.time < 7f)
				{
					this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.25f);
				}
				else
				{
					this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.25f);
				}
			}
			this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
		}
		if (!this.MyAudio.isPlaying || Input.GetButtonDown("A"))
		{
			if (Input.GetButtonDown("A"))
			{
				this.Timer = 1f;
			}
			this.Timer += Time.deltaTime;
			if (this.Timer > this.Delay)
			{
				this.SpeechPhase++;
				this.Timer = 0f;
				if (this.SpeechPhase < this.SpeechClip.Length)
				{
					this.Subtitle.text = this.SpeechText[this.SpeechPhase];
					this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
					this.Delay = this.SpeechDelay[this.SpeechPhase];
					this.MyAudio.Play();
					return;
				}
				SceneManager.LoadScene("CreditsScene");
			}
		}
	}

	private void LateUpdate()
	{
		this.Neck.transform.localEulerAngles = new Vector3(0f, this.Neck.transform.localEulerAngles.y, this.Neck.transform.localEulerAngles.z);
	}
}
