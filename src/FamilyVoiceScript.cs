using System;
using UnityEngine;

public class FamilyVoiceScript : MonoBehaviour
{
	public StalkerYandereScript Yandere;

	public DetectionMarkerScript Marker;

	public AudioClip GameOverSound;

	public AudioClip GameOverLine;

	public AudioClip CrunchSound;

	public GameObject Heartbroken;

	public Transform YandereHead;

	public Transform Head;

	public AudioSource Jukebox;

	public AudioSource MyAudio;

	public Renderer Darkness;

	public UILabel Subtitle;

	public Transform[] Boundary;

	public string[] SpeechText;

	public float[] SpeechTime;

	public string GameOverText;

	public float NoticeSpeed;

	public float Alpha;

	public float Scale;

	public float Timer;

	public int GameOverPhase;

	public int SpeechPhase;

	public bool GameOver;

	public bool Started;

	private void Start()
	{
		this.Subtitle.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	private void Update()
	{
		if (!this.GameOver)
		{
			float num = Vector3.Distance(this.Yandere.transform.position, base.transform.position);
			if (num < 6f)
			{
				if (!this.Started)
				{
					this.MyAudio.Play();
					this.Started = true;
				}
				else
				{
					this.MyAudio.pitch = Time.timeScale;
					if (this.SpeechPhase < this.SpeechTime.Length && this.MyAudio.time > this.SpeechTime[this.SpeechPhase])
					{
						this.Subtitle.text = this.SpeechText[this.SpeechPhase];
						this.SpeechPhase++;
					}
					this.Scale = Mathf.Abs(1f - (num - 1f) / 5f);
					if (this.Scale < 0f)
					{
						this.Scale = 0f;
					}
					if (this.Scale > 1f)
					{
						this.Scale = 1f;
					}
					this.Jukebox.volume = 1f - 0.9f * this.Scale;
					this.Subtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
					this.MyAudio.volume = this.Scale;
				}
				for (int i = 0; i < this.Boundary.Length; i++)
				{
					Transform transform = this.Boundary[i];
					if (transform != null)
					{
						float num2 = Vector3.Distance(this.Yandere.transform.position, transform.position);
						Debug.Log(base.gameObject.name + "'s BoundaryDistance is: " + num2);
						if (num2 < 0.33333f)
						{
							Debug.Log("Got a ''proximity'' game over from " + base.gameObject.name);
							AudioSource.PlayClipAtPoint(this.CrunchSound, Camera.main.transform.position);
							this.TransitionToGameOver();
						}
					}
				}
				if (this.YandereIsInFOV())
				{
					if (this.YandereIsInLOS())
					{
						this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * this.NoticeSpeed);
					}
					else
					{
						this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * this.NoticeSpeed);
					}
				}
				else
				{
					this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * this.NoticeSpeed);
				}
				if (this.Alpha == 1f)
				{
					Debug.Log("Got a ''witnessed'' game over from " + base.gameObject.name);
					AudioSource.PlayClipAtPoint(this.GameOverSound, Camera.main.transform.position);
					this.TransitionToGameOver();
				}
			}
			else if (num < 7f)
			{
				this.Jukebox.volume = 1f;
				this.MyAudio.volume = 0f;
				this.Subtitle.transform.localScale = new Vector3(0f, 0f, 0f);
			}
			this.Marker.Tex.transform.localScale = new Vector3(1f, this.Alpha, 1f);
			this.Marker.Tex.color = new Color(1f, 0f, 0f, this.Alpha);
			return;
		}
		if (this.GameOverPhase == 0)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f && !this.MyAudio.isPlaying)
			{
				this.Subtitle.text = (this.GameOverText ?? "");
				this.MyAudio.clip = this.GameOverLine;
				this.MyAudio.Play();
				this.GameOverPhase++;
				return;
			}
		}
		else if (!this.MyAudio.isPlaying || Input.GetButton("A"))
		{
			this.Heartbroken.SetActive(true);
			this.Subtitle.text = "";
			base.enabled = false;
			this.MyAudio.Stop();
		}
	}

	private bool YandereIsInFOV()
	{
		Vector3 to = this.Yandere.transform.position - this.Head.position;
		float num = 90f;
		return Vector3.Angle(this.Head.forward, to) <= num;
	}

	private bool YandereIsInLOS()
	{
		Debug.DrawLine(this.Head.position, new Vector3(this.Yandere.transform.position.x, this.YandereHead.position.y, this.Yandere.transform.position.z), Color.red);
		RaycastHit raycastHit;
		if (Physics.Linecast(this.Head.position, new Vector3(this.Yandere.transform.position.x, this.YandereHead.position.y, this.Yandere.transform.position.z), out raycastHit))
		{
			Debug.Log(base.gameObject.name + " shot out a raycast that hit ''" + raycastHit.collider.gameObject.name + "''");
			if (raycastHit.collider.gameObject.layer == 13)
			{
				return true;
			}
		}
		return false;
	}

	private void TransitionToGameOver()
	{
		this.Marker.Tex.transform.localScale = new Vector3(1f, 0f, 1f);
		this.Marker.Tex.color = new Color(1f, 0f, 0f, 0f);
		this.Darkness.material.color = new Color(0f, 0f, 0f, 1f);
		this.Yandere.RPGCamera.enabled = false;
		this.Yandere.CanMove = false;
		this.Subtitle.text = "";
		this.GameOver = true;
		this.Jukebox.Stop();
		this.MyAudio.Stop();
		this.Alpha = 0f;
	}
}
