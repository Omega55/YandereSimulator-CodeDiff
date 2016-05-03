using System;
using CompilerGenerated;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class MusicTest : MonoBehaviour
{
	public float[] freqData;

	public AudioSource MainSong;

	public float[] band;

	public GameObject[] g;

	public Light LightObject;

	public float MaximumHeight;

	public bool PrepareToChangeColor;

	private __MusicTest$callable0$90_28__ sqrt;

	public MusicTest()
	{
		this.freqData = new float[8192];
		this.sqrt = new __MusicTest$callable0$90_28__(Mathf.Sqrt);
	}

	public virtual void Start()
	{
		int num = Extensions.get_length(this.freqData);
		int num2 = 0;
		for (int i = 0; i < Extensions.get_length(this.freqData); i++)
		{
			num /= 2;
			if (num == 0)
			{
				break;
			}
			num2++;
		}
		this.band = new float[num2 + 1];
		this.g = new GameObject[num2 + 1];
		for (int j = 0; j < Extensions.get_length(this.band); j++)
		{
			this.band[j] = (float)0;
			this.g[j] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			this.g[j].transform.position = new Vector3((float)j, (float)0, (float)0);
		}
		this.InvokeRepeating("check", (float)0, 0.0333333351f);
		this.MainSong.time = (float)7;
		this.audio.time = (float)7;
	}

	public virtual void check()
	{
		this.audio.GetSpectrumData(this.freqData, 0, FFTWindow.Rectangular);
		int num = 0;
		int num2 = 2;
		for (int i = 0; i < Extensions.get_length(this.freqData); i++)
		{
			float num3 = this.freqData[i];
			float num4 = this.band[num];
			this.band[num] = ((num3 <= num4) ? num4 : num3);
			if (i > num2 - 3)
			{
				num++;
				num2 *= 2;
				float y = this.band[num] * (float)32;
				Vector3 position = this.g[num].transform.position;
				float num5 = position.y = y;
				Vector3 vector = this.g[num].transform.position = position;
				this.band[num] = (float)0;
			}
		}
		if (this.g[3].transform.position.y > this.MaximumHeight)
		{
			this.MaximumHeight = this.g[3].transform.position.y;
		}
		if (this.g[3].transform.position.y < (float)4)
		{
			this.PrepareToChangeColor = true;
		}
		else if (this.PrepareToChangeColor)
		{
			if (this.LightObject.color.r == (float)1)
			{
				int num6 = 0;
				Color color = this.LightObject.color;
				float num7 = color.r = (float)num6;
				Color color2 = this.LightObject.color = color;
				int num8 = 1;
				Color color3 = this.LightObject.color;
				float num9 = color3.g = (float)num8;
				Color color4 = this.LightObject.color = color3;
			}
			else
			{
				int num10 = 1;
				Color color5 = this.LightObject.color;
				float num11 = color5.r = (float)num10;
				Color color6 = this.LightObject.color = color5;
				int num12 = 0;
				Color color7 = this.LightObject.color;
				float num13 = color7.g = (float)num12;
				Color color8 = this.LightObject.color = color7;
			}
			this.PrepareToChangeColor = false;
		}
	}

	public virtual void Main()
	{
	}
}
