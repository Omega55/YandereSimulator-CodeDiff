using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class HeartbrokenScript : MonoBehaviour
{
	public GameObject MainCamera;

	public UILabel[] Letters;

	public UILabel[] Options;

	public Vector3[] Origins;

	public AudioClip Slam;

	public float Timer;

	public int ShakeID;

	public int ID;

	public virtual void Start()
	{
		this.MainCamera.active = false;
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
	}

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > (float)1)
		{
			if (this.ID < Extensions.get_length(this.Letters))
			{
				this.Letters[this.ID].transform.localScale = Vector3.MoveTowards(this.Letters[this.ID].transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)100);
				float a = this.Letters[this.ID].color.a + Time.deltaTime * (float)10;
				Color color = this.Letters[this.ID].color;
				float num = color.a = a;
				Color color2 = this.Letters[this.ID].color = color;
				if (this.Letters[this.ID].transform.localScale == new Vector3((float)1, (float)1, (float)1))
				{
					this.audio.PlayOneShot(this.Slam);
					this.ID++;
				}
			}
			else if (this.Timer > (float)3)
			{
				if (this.Options[0].color.a == (float)0)
				{
					this.audio.Play();
				}
				if (this.ID - 11 < Extensions.get_length(this.Options))
				{
					float a2 = this.Options[this.ID - 11].color.a + Time.deltaTime;
					Color color3 = this.Options[this.ID - 11].color;
					float num2 = color3.a = a2;
					Color color4 = this.Options[this.ID - 11].color = color3;
					if (this.Options[this.ID - 11].color.a >= (float)1)
					{
						this.ID++;
					}
				}
			}
		}
		this.ShakeID = 0;
		while (this.ShakeID < Extensions.get_length(this.Letters))
		{
			float x = this.Origins[this.ShakeID].x + UnityEngine.Random.Range(-5f, 5f);
			Vector3 localPosition = this.Letters[this.ShakeID].transform.localPosition;
			float num3 = localPosition.x = x;
			Vector3 vector = this.Letters[this.ShakeID].transform.localPosition = localPosition;
			float y = this.Origins[this.ShakeID].y + UnityEngine.Random.Range(-5f, 5f);
			Vector3 localPosition2 = this.Letters[this.ShakeID].transform.localPosition;
			float num4 = localPosition2.y = y;
			Vector3 vector2 = this.Letters[this.ShakeID].transform.localPosition = localPosition2;
			this.ShakeID++;
		}
	}

	public virtual void Main()
	{
	}
}
