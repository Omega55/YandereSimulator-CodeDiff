using System;
using UnityEngine;

[Serializable]
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

	public bool FadeOut;

	public bool Auto;

	public float AutoLimit;

	public float AutoTimer;

	public float Timer;

	public int ID;

	public virtual void Start()
	{
		int num = -135;
		Vector3 localPosition = this.Buttons.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.Buttons.localPosition = localPosition;
		int num3 = 1;
		Color color = this.Darkness.color;
		float num4 = color.a = (float)num3;
		Color color2 = this.Darkness.color = color;
	}

	public virtual void Update()
	{
		if (!this.FadeOut)
		{
			if (this.Timer > (float)0)
			{
				float a = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime);
				Color color = this.Darkness.color;
				float num = color.a = a;
				Color color2 = this.Darkness.color = color;
				if (this.Darkness.color.a == (float)0)
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
				float y = Mathf.Lerp(this.Buttons.localPosition.y, (float)0, Time.deltaTime * (float)10);
				Vector3 localPosition = this.Buttons.localPosition;
				float num2 = localPosition.y = y;
				Vector3 vector = this.Buttons.localPosition = localPosition;
				this.AutoTimer += Time.deltaTime;
				if ((this.Auto && this.AutoTimer > this.AutoLimit) || Input.GetButtonDown("A"))
				{
					this.AutoTimer = (float)0;
					if (this.ID < this.Text.Length - 1)
					{
						this.ID++;
						this.SpawnMessage();
					}
					else
					{
						this.Darkness.color = new Color((float)0, (float)0, (float)0, (float)0);
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
			float y2 = Mathf.Lerp(this.Buttons.localPosition.y, (float)-135, Time.deltaTime * (float)10);
			Vector3 localPosition2 = this.Buttons.localPosition;
			float num3 = localPosition2.y = y2;
			Vector3 vector2 = this.Buttons.localPosition = localPosition2;
			float a2 = this.Darkness.color.a + Time.deltaTime;
			Color color3 = this.Darkness.color;
			float num4 = color3.a = a2;
			Color color4 = this.Darkness.color = color3;
			this.audio.volume = (float)1 - this.Darkness.color.a;
			this.Jukebox.volume = (float)1 - this.Darkness.color.a;
			if (this.Darkness.color.a >= (float)1)
			{
				Application.LoadLevel("CalendarScene");
			}
		}
		this.Timer += Time.deltaTime;
	}

	public virtual void SpawnMessage()
	{
		if (this.NewMessage != null)
		{
			this.NewMessage.transform.parent = this.OldMessages;
			float y = this.OldMessages.localPosition.y + (float)(72 + this.Height[this.ID] * 32);
			Vector3 localPosition = this.OldMessages.localPosition;
			float num = localPosition.y = y;
			Vector3 vector = this.OldMessages.localPosition = localPosition;
		}
		this.audio.clip = this.VoiceClips[this.ID];
		this.audio.Play();
		if (this.Speaker[this.ID] == 1)
		{
			this.NewMessage = (GameObject)UnityEngine.Object.Instantiate(this.LeftMessage[this.Height[this.ID]]);
			this.NewMessage.transform.parent = this.Panel;
			this.NewMessage.transform.localPosition = new Vector3((float)-225, (float)-375, (float)0);
			this.NewMessage.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		}
		else
		{
			this.NewMessage = (GameObject)UnityEngine.Object.Instantiate(this.RightMessage[this.Height[this.ID]]);
			this.NewMessage.transform.parent = this.Panel;
			this.NewMessage.transform.localPosition = new Vector3((float)225, (float)-375, (float)0);
			this.NewMessage.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		}
		this.AutoLimit = (float)(this.Height[this.ID] + 1);
		((TextMessageScript)this.NewMessage.GetComponent(typeof(TextMessageScript))).Label.text = this.Text[this.ID];
	}

	public virtual void Main()
	{
	}
}
