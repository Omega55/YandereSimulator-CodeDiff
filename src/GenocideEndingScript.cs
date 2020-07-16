using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenocideEndingScript : MonoBehaviour
{
	public AudioSource MyAudio;

	public UISprite SecondDarkness;

	public UISprite Darkness;

	public UILabel Subtitle;

	public Animation Senpai;

	public Transform Neck;

	public AudioClip[] SpeechClip;

	public AudioClip OsanaClip;

	public AudioClip Slam;

	public string[] SpeechText;

	public float[] SpeechDelay;

	public float[] SpeechTime;

	public GameObject RIVAL;

	public GameObject ELIMINATED;

	public GameObject SenpaiRopes;

	public GameObject OsanaRopes;

	public GameObject Osana;

	public int SpeechPhase;

	public float SecondAlpha;

	public float TimeLimit;

	public float Alpha;

	public float Delay;

	public float Timer;

	private void Start()
	{
		Time.timeScale = 1f;
		if (EventGlobals.OsanaConversation)
		{
			this.Osana.GetComponent<StudentScript>().CharacterAnimation["f02_kidnapTorture_01"].speed = 0.8f;
			this.Osana.GetComponent<CosmeticScript>().SetFemaleUniform();
			this.SenpaiRopes.SetActive(false);
			this.OsanaRopes.SetActive(true);
			this.Senpai.transform.parent.gameObject.SetActive(false);
			this.Osana.SetActive(true);
			this.SpeechText[10] = "...huh? ...what is this? ...why am I tied to a...chair?! Why are you doing this?! This isn't funny! Lemme go! Lemme go right now!";
			this.Subtitle.text = this.SpeechText[10];
			this.MyAudio.clip = this.OsanaClip;
			this.MyAudio.Play();
			this.SpeechPhase = 10;
			this.TimeLimit = 9f;
			this.Delay = 10f;
			return;
		}
		Debug.Log("We're here for the Genocide Ending.");
		this.Senpai["kidnapTorture_01"].speed = 0.9f;
		this.SenpaiRopes.SetActive(true);
		this.OsanaRopes.SetActive(false);
		this.Senpai.transform.parent.gameObject.SetActive(true);
		this.Osana.SetActive(false);
		GameGlobals.DarkEnding = true;
	}

	private void Update()
	{
		if (this.SpeechPhase > 9)
		{
			base.transform.Translate(Vector3.forward * -0.1f * Time.deltaTime);
			if (this.MyAudio.isPlaying)
			{
				this.Senpai.Play();
				if (this.MyAudio.time < this.TimeLimit)
				{
					this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.25f);
				}
				else
				{
					this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.25f);
				}
			}
			this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
			if (this.Darkness.color.a == 1f)
			{
				this.Subtitle.text = "";
			}
		}
		if (!this.MyAudio.isPlaying || Input.GetButtonDown("A"))
		{
			if (Input.GetButtonDown("A"))
			{
				this.Timer = 1f;
			}
			this.Timer += Time.deltaTime;
			if (this.Delay == 10f && this.Timer > 1f)
			{
				if (this.Timer < 3f)
				{
					this.RIVAL.SetActive(true);
					this.ELIMINATED.SetActive(true);
				}
				else if (this.Timer < 5f)
				{
					if (this.ELIMINATED.activeInHierarchy)
					{
						this.ELIMINATED.SetActive(false);
						AudioSource.PlayClipAtPoint(this.Slam, base.transform.position);
					}
				}
				else
				{
					this.SecondAlpha = Mathf.MoveTowards(this.SecondAlpha, 1f, Time.deltaTime * 0.25f);
					this.SecondDarkness.color = new Color(0f, 0f, 0f, this.SecondAlpha);
				}
			}
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
				if (!EventGlobals.OsanaConversation)
				{
					SceneManager.LoadScene("CreditsScene");
					return;
				}
				SceneManager.LoadScene("CalendarScene");
				EventGlobals.OsanaConversation = false;
			}
		}
	}

	private void LateUpdate()
	{
		this.Neck.transform.localEulerAngles = new Vector3(0f, this.Neck.transform.localEulerAngles.y, this.Neck.transform.localEulerAngles.z);
	}
}
