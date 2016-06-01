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

	private __MusicTest$callable0$51_28__ sqrt;

	public MusicTest()
	{
		this.sqrt = new __MusicTest$callable0$51_28__(Mathf.Sqrt);
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
	}

	public virtual void Main()
	{
	}
}
