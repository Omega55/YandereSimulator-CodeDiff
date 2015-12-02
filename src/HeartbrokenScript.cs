using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class HeartbrokenScript : MonoBehaviour
{
	public HeartbrokenCursorScript Cursor;

	public YandereScript Yandere;

	public ClockScript Clock;

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

	public bool Arrested;

	public bool Noticed;

	public float AudioTimer;

	public float Timer;

	public int Phase;

	public int LetterID;

	public int ShakeID;

	public int GrowID;

	public int StopID;

	public int ID;

	public HeartbrokenScript()
	{
		this.Noticed = true;
		this.Phase = 1;
	}

	public virtual void Start()
	{
		if (((StudentScript)this.Yandere.Senpai.GetComponent(typeof(StudentScript))).Teacher)
		{
			this.Letters[0].text = string.Empty;
			this.Letters[1].text = "E";
			this.Letters[2].text = "X";
			this.Letters[3].text = "P";
			this.Letters[4].text = "E";
			this.Letters[5].text = "L";
			this.Letters[6].text = "L";
			this.Letters[7].text = "E";
			this.Letters[8].text = "D";
			this.Letters[9].text = string.Empty;
			this.Letters[10].text = string.Empty;
			while (this.ID < Extensions.get_length(this.Letters))
			{
				float x = this.Letters[this.ID].transform.localPosition.x + (float)100;
				Vector3 localPosition = this.Letters[this.ID].transform.localPosition;
				float num = localPosition.x = x;
				Vector3 vector = this.Letters[this.ID].transform.localPosition = localPosition;
				this.ID++;
			}
			this.LetterID = 1;
			this.StopID = 9;
		}
		else if (this.Arrested)
		{
			this.Letters[0].text = string.Empty;
			this.Letters[1].text = "A";
			this.Letters[2].text = "R";
			this.Letters[3].text = "R";
			this.Letters[4].text = "E";
			this.Letters[5].text = "S";
			this.Letters[6].text = "T";
			this.Letters[7].text = "E";
			this.Letters[8].text = "D";
			this.Letters[9].text = string.Empty;
			this.Letters[10].text = string.Empty;
			while (this.ID < Extensions.get_length(this.Letters))
			{
				float x2 = this.Letters[this.ID].transform.localPosition.x + (float)100;
				Vector3 localPosition2 = this.Letters[this.ID].transform.localPosition;
				float num2 = localPosition2.x = x2;
				Vector3 vector2 = this.Letters[this.ID].transform.localPosition = localPosition2;
				this.ID++;
			}
			this.LetterID = 1;
			this.StopID = 9;
		}
		else
		{
			this.LetterID = 0;
			this.StopID = 11;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Letters))
		{
			this.Letters[this.ID].transform.localScale = new Vector3((float)10, (float)10, (float)1);
			int num3 = 0;
			Color color = this.Letters[this.ID].color;
			float num4 = color.a = (float)num3;
			Color color2 = this.Letters[this.ID].color = color;
			this.Origins[this.ID] = this.Letters[this.ID].transform.localPosition;
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Options))
		{
			int num5 = 0;
			Color color3 = this.Options[this.ID].color;
			float num6 = color3.a = (float)num5;
			Color color4 = this.Options[this.ID].color = color3;
			this.ID++;
		}
		this.ID = 0;
		int num7 = 0;
		Color color5 = this.Subtitle.color;
		float num8 = color5.a = (float)num7;
		Color color6 = this.Subtitle.color = color5;
		if (this.Noticed)
		{
			int num9 = 0;
			Color color7 = this.Background.color;
			float num10 = color7.a = (float)num9;
			Color color8 = this.Background.color = color7;
			int num11 = 0;
			Color color9 = this.Ground.color;
			float num12 = color9.a = (float)num11;
			Color color10 = this.Ground.color = color9;
		}
		else
		{
			int num13 = 100;
			Vector3 position = this.transform.parent.transform.position;
			float num14 = position.y = (float)num13;
			Vector3 vector3 = this.transform.parent.transform.position = position;
		}
		this.Clock.StopTime = true;
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
				if (this.Subtitle.color.a > (float)0)
				{
					this.Phase++;
				}
				else
				{
					this.Phase += 2;
				}
			}
			else if (this.Phase == 2)
			{
				this.AudioTimer += Time.deltaTime;
				if (this.AudioTimer > this.Subtitle.audio.clip.length)
				{
					this.Phase++;
				}
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
		if (this.LetterID < this.StopID)
		{
			this.Letters[this.LetterID].transform.localScale = Vector3.MoveTowards(this.Letters[this.LetterID].transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)100);
			float a3 = this.Letters[this.LetterID].color.a + Time.deltaTime * (float)10;
			Color color5 = this.Letters[this.LetterID].color;
			float num4 = color5.a = a3;
			Color color6 = this.Letters[this.LetterID].color = color5;
			if (this.Letters[this.LetterID].transform.localScale == new Vector3((float)1, (float)1, (float)1))
			{
				this.audio.PlayOneShot(this.Slam);
				this.LetterID++;
				if (this.LetterID == this.StopID)
				{
					this.ID = 0;
				}
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
			if (this.ID < Extensions.get_length(this.Options) && this.ID < Extensions.get_length(this.Options))
			{
				float a4 = this.Options[this.ID].color.a + Time.deltaTime * (float)2;
				Color color9 = this.Options[this.ID].color;
				float num7 = color9.a = a4;
				Color color10 = this.Options[this.ID].color = color9;
				if (this.Options[this.ID].color.a >= (float)1)
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
		this.GrowID = 0;
		while (this.GrowID < 4)
		{
			if (this.Cursor.Selected - 1 != this.GrowID)
			{
				this.Options[this.GrowID].transform.localScale = Vector3.Lerp(this.Options[this.GrowID].transform.localScale, new Vector3(0.5f, 0.5f, 0.5f), Time.deltaTime * (float)10);
			}
			else
			{
				this.Options[this.GrowID].transform.localScale = Vector3.Lerp(this.Options[this.GrowID].transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			}
			this.GrowID++;
		}
	}

	public virtual void UpdateSubtitle()
	{
		StudentScript studentScript = (StudentScript)this.Yandere.Senpai.GetComponent(typeof(StudentScript));
		int num = 0;
		if (!studentScript.Teacher && this.Yandere.Noticed)
		{
			int num2 = 1;
			Color color = this.Subtitle.color;
			float num3 = color.a = (float)num2;
			Color color2 = this.Subtitle.color = color;
			string gameOverCause = studentScript.GameOverCause;
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
			else if (gameOverCause == "Lewd")
			{
				num = 6;
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
