using System;
using UnityEngine;

public class MusicTest : MonoBehaviour
{
	public float[] freqData;

	public AudioSource MainSong;

	public float[] band;

	public GameObject[] g;

	private void Start()
	{
		int num = this.freqData.Length;
		int num2 = 0;
		for (int i = 0; i < this.freqData.Length; i++)
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
		for (int j = 0; j < this.band.Length; j++)
		{
			this.band[j] = 0f;
			this.g[j] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			this.g[j].transform.position = new Vector3((float)j, 0f, 0f);
		}
		base.InvokeRepeating("check", 0f, 0.0333333351f);
	}

	private void check()
	{
		base.GetComponent<AudioSource>().GetSpectrumData(this.freqData, 0, FFTWindow.Rectangular);
		int num = 0;
		int num2 = 2;
		for (int i = 0; i < this.freqData.Length; i++)
		{
			float num3 = this.freqData[i];
			float num4 = this.band[num];
			this.band[num] = ((num3 <= num4) ? num4 : num3);
			if (i > num2 - 3)
			{
				num++;
				num2 *= 2;
				Transform transform = this.g[num].transform;
				transform.position = new Vector3(transform.position.x, this.band[num] * 32f, transform.position.z);
				this.band[num] = 0f;
			}
		}
	}
}
