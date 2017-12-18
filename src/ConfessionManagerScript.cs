using System;
using UnityEngine;

public class ConfessionManagerScript : MonoBehaviour
{
	public ShoulderCameraScript ShoulderCamera;

	public StudentManagerScript StudentManager;

	public HeartbrokenScript Heartbroken;

	public JukeboxScript OriginalJukebox;

	public CosmeticScript OsanaCosmetic;

	public AudioClip ConfessionAccepted;

	public AudioClip ConfessionRejected;

	public AudioClip ConfessionGiggle;

	public AudioClip[] ConfessionMusic;

	public GameObject OriginalBlossoms;

	public GameObject HeartBeatCamera;

	public GameObject MainCamera;

	public Transform ConfessionCamera;

	public Transform OriginalPOV;

	public Transform ReactionPOV;

	public Transform SenpaiNeck;

	public Transform SenpaiPOV;

	public string[] ConfessSubs;

	public string[] AcceptSubs;

	public string[] RejectSubs;

	public float[] ConfessTimes;

	public float[] AcceptTimes;

	public float[] RejectTimes;

	public UISprite TimelessDarkness;

	public UILabel SubtitleLabel;

	public UISprite Darkness;

	public UIPanel Panel;

	public AudioSource MyAudio;

	public AudioSource Jukebox;

	public Animation Yandere;

	public Animation Senpai;

	public Animation Osana;

	public Renderer Tears;

	public float RotateSpeed;

	public float TearSpeed;

	public float TearTimer;

	public float Timer;

	public bool ReverseTears;

	public bool FadeOut;

	public bool Reject;

	public int TearPhase;

	public int Phase;

	public int MusicID;

	public int SubID;

	private void Start()
	{
		this.ConfessionCamera.gameObject.SetActive(false);
		this.TimelessDarkness.color = new Color(0f, 0f, 0f, 0f);
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
		this.SubtitleLabel.text = string.Empty;
	}

	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Phase == -1)
		{
			this.TimelessDarkness.color = new Color(this.TimelessDarkness.color.r, this.TimelessDarkness.color.g, this.TimelessDarkness.color.b, Mathf.MoveTowards(this.TimelessDarkness.color.a, 1f, Time.deltaTime));
			this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 0f, Time.deltaTime);
			this.OriginalJukebox.Volume = Mathf.MoveTowards(this.OriginalJukebox.Volume, 0f, Time.deltaTime);
			if (this.TimelessDarkness.color.a == 1f && this.Timer > 2f)
			{
				this.TimelessDarkness.color = new Color(0f, 0f, 0f, 0f);
				this.Darkness.color = new Color(0f, 0f, 0f, 1f);
				this.ConfessionCamera.gameObject.SetActive(true);
				this.MainCamera.SetActive(false);
				this.OsanaCosmetic = this.StudentManager.Students[this.StudentManager.RivalID].Cosmetic;
				this.Osana = this.StudentManager.Students[this.StudentManager.RivalID].CharacterAnimation;
				this.Tears = this.StudentManager.Students[this.StudentManager.RivalID].Tears;
				this.Senpai = this.StudentManager.Students[1].CharacterAnimation;
				this.SenpaiNeck = this.StudentManager.Students[1].Neck;
				this.Osana[this.OsanaCosmetic.Student.ShyAnim].weight = 0f;
				this.Senpai["SenpaiConfession"].speed = 0.9f;
				this.OriginalBlossoms.SetActive(false);
				this.Tears.gameObject.SetActive(true);
				this.Osana.transform.position = new Vector3(0f, 6f, 98.5f);
				this.Senpai.transform.position = new Vector3(0f, 6f, 98.5f);
				this.Osana.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				this.Senpai.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				this.OsanaCosmetic.MyRenderer.materials[this.OsanaCosmetic.FaceID].SetFloat("_BlendAmount", 1f);
				this.Senpai.Play("SenpaiConfession");
				this.Osana.Play("OsanaConfession");
				this.OriginalBlossoms.SetActive(false);
				this.HeartBeatCamera.SetActive(false);
				base.GetComponent<AudioSource>().Play();
				this.Jukebox.Play();
				this.Timer = 0f;
				this.Phase++;
				this.Yandere.transform.parent.position = new Vector3(5f, 5.73f, 98f);
				this.Yandere.transform.parent.eulerAngles = new Vector3(0f, -90f, 0f);
			}
		}
		else if (this.Phase == 0)
		{
			if (this.Timer > 11f)
			{
				this.FadeOut = true;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 1)
		{
			if (this.Timer > 2f)
			{
				this.ConfessionCamera.eulerAngles = this.SenpaiPOV.eulerAngles;
				this.ConfessionCamera.position = this.SenpaiPOV.position;
				this.Senpai.gameObject.SetActive(false);
				this.Osana["OsanaConfession"].time = 11f;
				this.MyAudio.volume = 1f;
				this.MyAudio.time = 8f;
				this.FadeOut = false;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			if (this.SubID < this.ConfessTimes.Length && this.Osana["OsanaConfession"].time > this.ConfessTimes[this.SubID] + 3f)
			{
				this.SubtitleLabel.text = string.Empty + this.ConfessSubs[this.SubID];
				this.SubID++;
			}
			this.RotateSpeed += Time.deltaTime * 0.2f;
			this.ConfessionCamera.eulerAngles = Vector3.Lerp(this.ConfessionCamera.eulerAngles, new Vector3(0f, 0f, 0f), Time.deltaTime * this.RotateSpeed);
			this.ConfessionCamera.position = Vector3.Lerp(this.ConfessionCamera.position, new Vector3(0f, 7.25f, 97f), Time.deltaTime * this.RotateSpeed);
			if (this.Osana["OsanaConfession"].time >= this.Osana["OsanaConfession"].length)
			{
				if (DatingGlobals.RivalSabotaged > 4)
				{
					this.Reject = true;
				}
				if (!this.Reject)
				{
					this.Osana.CrossFade("OsanaConfessionAccepted");
					this.MyAudio.clip = this.ConfessionAccepted;
				}
				else
				{
					this.Osana.CrossFade("OsanaConfessionRejected");
					this.MyAudio.clip = this.ConfessionRejected;
				}
				this.MyAudio.time = 0f;
				this.MyAudio.Play();
				this.Jukebox.Stop();
				this.SubtitleLabel.text = string.Empty;
				this.RotateSpeed = 0f;
				this.SubID = 0;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 3)
		{
			if (!this.Reject)
			{
				if (this.SubID < this.AcceptTimes.Length && this.Osana["OsanaConfessionAccepted"].time > this.AcceptTimes[this.SubID])
				{
					this.SubtitleLabel.text = string.Empty + this.AcceptSubs[this.SubID];
					this.SubID++;
				}
				if (this.TearPhase == 0)
				{
					if (this.Timer > 26f)
					{
						this.ReverseTears = true;
						this.TearSpeed = 5f;
						this.TearPhase++;
					}
				}
				else if (this.TearPhase == 1)
				{
					if ((double)this.Timer > 33.33333)
					{
						this.ReverseTears = true;
						this.TearSpeed = 5f;
						this.TearPhase++;
					}
				}
				else if (this.TearPhase == 2)
				{
					if (this.Timer > 39f)
					{
						this.ReverseTears = true;
						this.TearSpeed = 5f;
						this.TearPhase++;
					}
				}
				else if (this.TearPhase == 3 && this.Timer > 40f)
				{
					this.TearPhase++;
				}
				if (this.Timer > 10f)
				{
					if (!this.Jukebox.isPlaying)
					{
						this.Jukebox.clip = this.ConfessionMusic[4];
						this.Jukebox.loop = true;
						this.Jukebox.volume = 0f;
						this.Jukebox.Play();
					}
					this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0.05f, Time.deltaTime * 0.01f);
					if (!this.ReverseTears)
					{
						this.TearTimer = Mathf.MoveTowards(this.TearTimer, 1f, Time.deltaTime * this.TearSpeed);
					}
					else
					{
						this.TearTimer = Mathf.MoveTowards(this.TearTimer, 0f, Time.deltaTime * this.TearSpeed);
						if (this.TearTimer == 0f)
						{
							this.ReverseTears = false;
							this.TearSpeed = 0.2f;
						}
					}
					if (this.TearPhase < 4)
					{
						this.Tears.materials[0].SetFloat("_TearReveal", this.TearTimer);
					}
					this.Tears.materials[1].SetFloat("_TearReveal", this.TearTimer);
				}
				if (Input.GetKeyDown("space"))
				{
					this.Jukebox.clip = this.ConfessionMusic[4];
					this.Jukebox.loop = true;
					this.Jukebox.volume = 0.05f;
					this.Jukebox.Play();
					this.Osana["OsanaConfessionAccepted"].time = 43f;
					this.MyAudio.Stop();
					this.Timer = 43f;
				}
				if (this.Timer > 43f)
				{
					this.TearSpeed = 0.1f;
					this.FadeOut = true;
					this.Timer = 0f;
					this.Phase++;
				}
			}
			else
			{
				if (this.SubID < this.RejectTimes.Length && this.Osana["OsanaConfessionRejected"].time > this.RejectTimes[this.SubID])
				{
					this.SubtitleLabel.text = string.Empty + this.RejectSubs[this.SubID];
					this.SubID++;
				}
				if (Input.GetKeyDown("space"))
				{
					this.Osana["OsanaConfessionRejected"].time = 41f;
					this.MyAudio.time = 41f;
					this.Timer = 41f;
				}
				if (this.Timer > 41f)
				{
					this.TearTimer = Mathf.MoveTowards(this.TearTimer, 1f, Time.deltaTime * this.TearSpeed);
					this.Tears.materials[0].SetFloat("_TearReveal", this.TearTimer);
					this.Tears.materials[1].SetFloat("_TearReveal", this.TearTimer);
				}
				if (this.Timer > 47f)
				{
					this.RotateSpeed += Time.deltaTime * 0.01f;
					this.ConfessionCamera.eulerAngles = new Vector3(this.ConfessionCamera.eulerAngles.x, this.ConfessionCamera.eulerAngles.y - this.RotateSpeed * 2f, this.ConfessionCamera.eulerAngles.z);
					this.ConfessionCamera.position = new Vector3(this.ConfessionCamera.position.x, this.ConfessionCamera.position.y, this.ConfessionCamera.position.z - this.RotateSpeed * 0.05f);
				}
				if (this.Timer > 51f)
				{
					this.FadeOut = true;
					this.Timer = 0f;
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 4)
		{
			if (this.Reject)
			{
				this.RotateSpeed += Time.deltaTime * 0.01f;
				this.ConfessionCamera.eulerAngles = new Vector3(this.ConfessionCamera.eulerAngles.x, this.ConfessionCamera.eulerAngles.y - this.RotateSpeed * 2f, this.ConfessionCamera.eulerAngles.z);
				this.ConfessionCamera.position = new Vector3(this.ConfessionCamera.position.x, this.ConfessionCamera.position.y, this.ConfessionCamera.position.z - this.RotateSpeed * 0.05f);
			}
			if (this.Timer > 2f)
			{
				this.ConfessionCamera.eulerAngles = this.OriginalPOV.eulerAngles;
				this.ConfessionCamera.position = this.OriginalPOV.position;
				this.Senpai.gameObject.SetActive(true);
				if (!this.Reject)
				{
					this.Senpai.Play("SenpaiConfessionAccepted");
					this.Senpai["SenpaiConfessionAccepted"].time = this.Osana["OsanaConfessionAccepted"].time;
					this.Senpai.Play("SenpaiConfessionAccepted");
					this.Yandere.Play("YandereConfessionAccepted");
				}
				else
				{
					this.Senpai.Play("SenpaiConfessionRejected");
					this.Senpai["SenpaiConfessionRejected"].time += 2f;
				}
				this.SubtitleLabel.text = string.Empty;
				this.FadeOut = false;
				this.RotateSpeed = 0f;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 5)
		{
			if (this.Timer > 5f)
			{
				if (this.Reject)
				{
					this.Yandere.Play("YandereConfessionRejected");
				}
				this.Jukebox.pitch = Mathf.MoveTowards(this.Jukebox.pitch, 0f, Time.deltaTime * 0.1f);
				this.RotateSpeed += Time.deltaTime * 0.5f;
				this.ConfessionCamera.position = Vector3.Lerp(this.ConfessionCamera.position, new Vector3(7f, 7f, 97.5f), Time.deltaTime * this.RotateSpeed);
				if (this.Timer > 10f)
				{
					if (this.Reject)
					{
						AudioSource.PlayClipAtPoint(this.ConfessionGiggle, this.Yandere.transform.position);
					}
					this.ConfessionCamera.eulerAngles = this.ReactionPOV.eulerAngles;
					this.ConfessionCamera.position = this.ReactionPOV.position;
					this.RotateSpeed = 0f;
					this.Timer = 0f;
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 6)
		{
			this.Jukebox.pitch = Mathf.MoveTowards(this.Jukebox.pitch, 0f, Time.deltaTime * 0.1f);
			if (!this.Reject)
			{
				if (!this.Heartbroken.Confessed)
				{
					this.MainCamera.transform.eulerAngles = this.ConfessionCamera.eulerAngles;
					this.MainCamera.transform.position = this.ConfessionCamera.position;
					this.Heartbroken.Confessed = true;
					this.MainCamera.SetActive(true);
					Camera.main.enabled = false;
					this.ShoulderCamera.enabled = true;
					this.ShoulderCamera.Noticed = true;
					this.ShoulderCamera.Skip = true;
				}
				this.ConfessionCamera.position = this.MainCamera.transform.position;
			}
			else
			{
				this.RotateSpeed += Time.deltaTime * 0.5f;
				this.ConfessionCamera.position = Vector3.Lerp(this.ConfessionCamera.position, new Vector3(4f, 7f, 98f), Time.deltaTime * this.RotateSpeed);
				if (this.Timer > 5f)
				{
					this.FadeOut = true;
				}
			}
		}
		if (this.FadeOut)
		{
			this.Darkness.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime * 0.5f));
		}
		else
		{
			this.Darkness.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime * 0.5f));
		}
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale -= 1f;
			this.MyAudio.pitch -= 1f;
			this.Jukebox.pitch -= 1f;
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += 1f;
			this.MyAudio.pitch += 1f;
			this.Jukebox.pitch += 1f;
		}
	}

	private void LateUpdate()
	{
		if (this.Phase > 4 && this.Reject)
		{
			this.SenpaiNeck.eulerAngles = new Vector3(this.SenpaiNeck.eulerAngles.x + 15f, this.SenpaiNeck.eulerAngles.y, this.SenpaiNeck.eulerAngles.z);
		}
	}
}
