using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhoneScript : MonoBehaviour
{
	public GameObject[] RightMessage;

	public GameObject[] LeftMessage;

	public AudioClip[] VoiceClips;

	public GameObject NewMessage;

	public AudioSource Jukebox;

	public Transform OldMessages;

	public Transform Buttons;

	public Transform Panel;

	public Vignetting Vignette;

	public UISprite Darkness;

	public UISprite Sprite;

	public int[] Speaker;

	public string[] Text;

	public int[] Height;

	public AudioClip[] KidnapClip;

	public int[] KidnapSpeaker;

	public string[] KidnapText;

	public int[] KidnapHeight;

	public AudioClip[] BefriendClip;

	public int[] BefriendSpeaker;

	public string[] BefriendText;

	public int[] BefriendHeight;

	public bool FadeOut;

	public bool Auto;

	public float AutoLimit;

	public float AutoTimer;

	public float Timer;

	public int ID;

	private void Start()
	{
		this.Buttons.localPosition = new Vector3(this.Buttons.localPosition.x, -135f, this.Buttons.localPosition.z);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
		if (Globals.KidnapConversation)
		{
			this.VoiceClips = this.KidnapClip;
			this.Speaker = this.KidnapSpeaker;
			this.Text = this.KidnapText;
			this.Height = this.KidnapHeight;
			Globals.BefriendConversation = true;
			Globals.KidnapConversation = false;
		}
		else if (Globals.BefriendConversation)
		{
			this.VoiceClips = this.BefriendClip;
			this.Speaker = this.BefriendSpeaker;
			this.Text = this.BefriendText;
			this.Height = this.BefriendHeight;
			Globals.LivingRoom = true;
			Globals.BefriendConversation = false;
		}
	}

	private void Update()
	{
		if (!this.FadeOut)
		{
			if (this.Timer > 0f)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
				if (this.Darkness.color.a == 0f)
				{
					if (!this.Jukebox.isPlaying)
					{
						this.Jukebox.Play();
					}
					if (this.NewMessage == null)
					{
						this.SpawnMessage();
					}
				}
			}
			if (this.NewMessage != null)
			{
				this.Buttons.localPosition = new Vector3(this.Buttons.localPosition.x, Mathf.Lerp(this.Buttons.localPosition.y, 0f, Time.deltaTime * 10f), this.Buttons.localPosition.z);
				this.AutoTimer += Time.deltaTime;
				if ((this.Auto && this.AutoTimer > this.VoiceClips[this.ID].length + 1f) || Input.GetButtonDown("A"))
				{
					this.AutoTimer = 0f;
					if (this.ID < this.Text.Length - 1)
					{
						this.ID++;
						this.SpawnMessage();
					}
					else
					{
						this.Darkness.color = new Color(0f, 0f, 0f, 0f);
						this.FadeOut = true;
					}
				}
				if (Input.GetButtonDown("X"))
				{
					this.FadeOut = true;
				}
			}
		}
		else
		{
			this.Buttons.localPosition = new Vector3(this.Buttons.localPosition.x, Mathf.Lerp(this.Buttons.localPosition.y, -135f, Time.deltaTime * 10f), this.Buttons.localPosition.z);
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
			base.GetComponent<AudioSource>().volume = 1f - this.Darkness.color.a;
			this.Jukebox.volume = 1f - this.Darkness.color.a;
			if (this.Darkness.color.a >= 1f)
			{
				if (!Globals.BefriendConversation && !Globals.LivingRoom)
				{
					SceneManager.LoadScene("CalendarScene");
				}
				else if (Globals.LivingRoom)
				{
					SceneManager.LoadScene("LivingRoomScene");
				}
				else
				{
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				}
			}
		}
		this.Timer += Time.deltaTime;
	}

	private void SpawnMessage()
	{
		if (this.NewMessage != null)
		{
			this.NewMessage.transform.parent = this.OldMessages;
			this.OldMessages.localPosition = new Vector3(this.OldMessages.localPosition.x, this.OldMessages.localPosition.y + (72f + (float)this.Height[this.ID] * 32f), this.OldMessages.localPosition.z);
		}
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.VoiceClips[this.ID];
		component.Play();
		if (this.Speaker[this.ID] == 1)
		{
			this.NewMessage = UnityEngine.Object.Instantiate<GameObject>(this.LeftMessage[this.Height[this.ID]]);
			this.NewMessage.transform.parent = this.Panel;
			this.NewMessage.transform.localPosition = new Vector3(-225f, -375f, 0f);
			this.NewMessage.transform.localScale = Vector3.zero;
		}
		else
		{
			this.NewMessage = UnityEngine.Object.Instantiate<GameObject>(this.RightMessage[this.Height[this.ID]]);
			this.NewMessage.transform.parent = this.Panel;
			this.NewMessage.transform.localPosition = new Vector3(225f, -375f, 0f);
			this.NewMessage.transform.localScale = Vector3.zero;
			if (this.Speaker == this.KidnapSpeaker && this.Height[this.ID] == 8)
			{
				this.NewMessage.GetComponent<TextMessageScript>().Attachment = true;
			}
		}
		this.AutoLimit = (float)(this.Height[this.ID] + 1);
		this.NewMessage.GetComponent<TextMessageScript>().Label.text = this.Text[this.ID];
	}
}
