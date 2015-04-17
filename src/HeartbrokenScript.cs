using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class HeartbrokenScript : MonoBehaviour
{
	public YandereScript Yandere;

	public AudioListener Listener;

	public AudioClip[] NoticedClips;

	public string[] NoticedLines;

	public UILabel[] Letters;

	public UILabel[] Options;

	public Vector3[] Origins;

	public UISprite Background;

	public UISprite Ground;

	public Camera MainCamera;

	public UILabel Subtitle;

	public AudioClip Slam;

	public bool Noticed;

	public float Timer;

	public int ShakeID;

	public int Phase;

	public int ID;

	public HeartbrokenScript()
	{
		this.Noticed = true;
		this.Phase = 1;
	}

	public virtual void Start()
	{
		while (this.ID < Extensions.get_length(this.Letters))
		{
			this.Letters[this.ID].transform.localScale = new Vector3((float)10, (float)10, (float)1);
			int num = 0;
			Color color = this.Letters[this.ID].color;
			float num2 = color.a = (float)num;
			Color color2 = this.Letters[this.ID].color = color;
			this.Origins[this.ID] = this.Letters[this.ID].transform.localPosition;
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Options))
		{
			int num3 = 0;
			Color color3 = this.Options[this.ID].color;
			float num4 = color3.a = (float)num3;
			Color color4 = this.Options[this.ID].color = color3;
			this.ID++;
		}
		this.ID = 0;
		int num5 = 0;
		Color color5 = this.Subtitle.color;
		float num6 = color5.a = (float)num5;
		Color color6 = this.Subtitle.color = color5;
		if (this.Noticed)
		{
			this.Listener.enabled = false;
			int num7 = 0;
			Color color7 = this.Background.color;
			float num8 = color7.a = (float)num7;
			Color color8 = this.Background.color = color7;
			int num9 = 0;
			Color color9 = this.Ground.color;
			float num10 = color9.a = (float)num9;
			Color color10 = this.Ground.color = color9;
		}
		else
		{
			int num11 = 100;
			Vector3 position = this.transform.parent.transform.position;
			float num12 = position.y = (float)num11;
			Vector3 vector = this.transform.parent.transform.position = position;
		}
	}

	public virtual void Update()
	{
		if (this.Noticed)
		{
			float y = this.Yandere.transform.position.y + 0.01f;
			Vector3 position = this.Ground.transform.position;
			float num = position.y = y;
			Vector3 vector = this.Ground.transform.position = position;
		}
		this.Timer += Time.deltaTime;
		if (this.Timer > (float)3)
		{
			if (this.Phase == 1)
			{
				if (this.Noticed)
				{
					this.UpdateSubtitle();
				}
				this.Phase++;
			}
			else if (this.Phase == 2 && !this.Subtitle.audio.isPlaying)
			{
				this.Phase++;
			}
		}
		if (this.Background.color.a < (float)1)
		{
			float a = this.Background.color.a + Time.deltaTime;
			Color color = this.Background.color;
			float num2 = color.a = a;
			Color color2 = this.Background.color = color;
			float a2 = this.Ground.color.a + Time.deltaTime;
			Color color3 = this.Ground.color;
			float num3 = color3.a = a2;
			Color color4 = this.Ground.color = color3;
			if (this.Background.color.a >= (float)1)
			{
				this.MainCamera.enabled = false;
			}
		}
		if (this.ID < Extensions.get_length(this.Letters))
		{
			this.Letters[this.ID].transform.localScale = Vector3.MoveTowards(this.Letters[this.ID].transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)100);
			float a3 = this.Letters[this.ID].color.a + Time.deltaTime * (float)10;
			Color color5 = this.Letters[this.ID].color;
			float num4 = color5.a = a3;
			Color color6 = this.Letters[this.ID].color = color5;
			if (this.Letters[this.ID].transform.localScale == new Vector3((float)1, (float)1, (float)1))
			{
				this.audio.PlayOneShot(this.Slam);
				this.ID++;
			}
		}
		else if (this.Phase == 3)
		{
			if (this.Options[0].color.a == (float)0)
			{
				int num5 = 0;
				Color color7 = this.Subtitle.color;
				float num6 = color7.a = (float)num5;
				Color color8 = this.Subtitle.color = color7;
				this.audio.Play();
			}
			if (this.ID - 11 < Extensions.get_length(this.Options) && this.ID - 11 < Extensions.get_length(this.Options))
			{
				float a4 = this.Options[this.ID - 11].color.a + Time.deltaTime * (float)2;
				Color color9 = this.Options[this.ID - 11].color;
				float num7 = color9.a = a4;
				Color color10 = this.Options[this.ID - 11].color = color9;
				if (this.Options[this.ID - 11].color.a >= (float)1)
				{
					this.ID++;
				}
			}
		}
		this.ShakeID = 0;
		while (this.ShakeID < Extensions.get_length(this.Letters))
		{
			float x = this.Origins[this.ShakeID].x + UnityEngine.Random.Range(-5f, 5f);
			Vector3 localPosition = this.Letters[this.ShakeID].transform.localPosition;
			float num8 = localPosition.x = x;
			Vector3 vector2 = this.Letters[this.ShakeID].transform.localPosition = localPosition;
			float y2 = this.Origins[this.ShakeID].y + UnityEngine.Random.Range(-5f, 5f);
			Vector3 localPosition2 = this.Letters[this.ShakeID].transform.localPosition;
			float num9 = localPosition2.y = y2;
			Vector3 vector3 = this.Letters[this.ShakeID].transform.localPosition = localPosition2;
			this.ShakeID++;
		}
	}

	public virtual void UpdateSubtitle()
	{
		int num = 0;
		int num2 = 1;
		Color color = this.Subtitle.color;
		float num3 = color.a = (float)num2;
		Color color2 = this.Subtitle.color = color;
		if (this.Yandere.Noticed)
		{
			string gameOverCause = ((StudentScript)this.Yandere.Senpai.GetComponent(typeof(StudentScript))).GameOverCause;
			if (gameOverCause == "Stalking")
			{
				num = 4;
			}
			else if (gameOverCause == "Insanity")
			{
				num = 3;
			}
			else if (gameOverCause == "Weapon")
			{
				num = 2;
			}
			else if (gameOverCause == "Murder")
			{
				num = 5;
			}
			else if (gameOverCause == "Blood")
			{
				num = 1;
			}
			this.Subtitle.text = this.NoticedLines[num];
			this.Subtitle.audio.clip = this.NoticedClips[num];
			this.Subtitle.audio.Play();
		}
	}

	public virtual void Main()
	{
	}
}
