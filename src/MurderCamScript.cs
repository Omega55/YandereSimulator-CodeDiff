using System;
using UnityEngine;

[Serializable]
public class MurderCamScript : MonoBehaviour
{
	public Vector3 WitnessViewpoint;

	public Transform Yandere;

	public UISprite Exclamation;

	public Camera MurderCam;

	public bool ZoomIn;

	public float Timer;

	public virtual void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").transform;
		int num = 1;
		Rect rect = this.MurderCam.rect;
		float num2 = rect.x = (float)num;
		Rect rect2 = this.MurderCam.rect = rect;
		this.MurderCam.enabled = false;
		int num3 = 0;
		Color color = this.Exclamation.color;
		float num4 = color.a = (float)num3;
		Color color2 = this.Exclamation.color = color;
	}

	public virtual void Update()
	{
		if (this.ZoomIn)
		{
			this.transform.position = Vector3.Lerp(this.transform.position, this.WitnessViewpoint, Time.deltaTime);
			this.transform.LookAt(this.WitnessViewpoint);
			this.Timer += Time.deltaTime;
			if (this.Timer < (float)2)
			{
				if (this.MurderCam.rect.x > 0.75f)
				{
					float x = this.MurderCam.rect.x - Time.deltaTime;
					Rect rect = this.MurderCam.rect;
					float num = rect.x = x;
					Rect rect2 = this.MurderCam.rect = rect;
					if (this.MurderCam.rect.x < 0.75f)
					{
						float x2 = 0.75f;
						Rect rect3 = this.MurderCam.rect;
						float num2 = rect3.x = x2;
						Rect rect4 = this.MurderCam.rect = rect3;
					}
				}
				if (this.Timer < (float)1)
				{
					if (this.Exclamation.color.a < (float)1)
					{
						float a = this.Exclamation.color.a + Time.deltaTime * (float)5;
						Color color = this.Exclamation.color;
						float num3 = color.a = a;
						Color color2 = this.Exclamation.color = color;
						if (this.Exclamation.color.a > (float)1)
						{
							int num4 = 1;
							Color color3 = this.Exclamation.color;
							float num5 = color3.a = (float)num4;
							Color color4 = this.Exclamation.color = color3;
						}
					}
					float x3 = this.Exclamation.transform.localScale.x - Time.deltaTime * (float)5;
					Vector3 localScale = this.Exclamation.transform.localScale;
					float num6 = localScale.x = x3;
					Vector3 vector = this.Exclamation.transform.localScale = localScale;
					float y = this.Exclamation.transform.localScale.y - Time.deltaTime * (float)5;
					Vector3 localScale2 = this.Exclamation.transform.localScale;
					float num7 = localScale2.y = y;
					Vector3 vector2 = this.Exclamation.transform.localScale = localScale2;
					if (this.Exclamation.transform.localScale.x < (float)1)
					{
						int num8 = 1;
						Vector3 localScale3 = this.Exclamation.transform.localScale;
						float num9 = localScale3.x = (float)num8;
						Vector3 vector3 = this.Exclamation.transform.localScale = localScale3;
						int num10 = 1;
						Vector3 localScale4 = this.Exclamation.transform.localScale;
						float num11 = localScale4.y = (float)num10;
						Vector3 vector4 = this.Exclamation.transform.localScale = localScale4;
						float z = Mathf.Lerp(this.Exclamation.transform.localEulerAngles.z, (float)0, Time.deltaTime * (float)10);
						Vector3 localEulerAngles = this.Exclamation.transform.localEulerAngles;
						float num12 = localEulerAngles.z = z;
						Vector3 vector5 = this.Exclamation.transform.localEulerAngles = localEulerAngles;
					}
				}
				else
				{
					float a2 = this.Exclamation.color.a - Time.deltaTime;
					Color color5 = this.Exclamation.color;
					float num13 = color5.a = a2;
					Color color6 = this.Exclamation.color = color5;
				}
			}
			else
			{
				float a3 = this.Exclamation.color.a - Time.deltaTime;
				Color color7 = this.Exclamation.color;
				float num14 = color7.a = a3;
				Color color8 = this.Exclamation.color = color7;
				float x4 = this.MurderCam.rect.x + Time.deltaTime;
				Rect rect5 = this.MurderCam.rect;
				float num15 = rect5.x = x4;
				Rect rect6 = this.MurderCam.rect = rect5;
				if (this.MurderCam.rect.x > (float)1)
				{
					this.MurderCam.enabled = false;
					int num16 = 1;
					Rect rect7 = this.MurderCam.rect;
					float num17 = rect7.x = (float)num16;
					Rect rect8 = this.MurderCam.rect = rect7;
					int num18 = 0;
					Color color9 = this.Exclamation.color;
					float num19 = color9.a = (float)num18;
					Color color10 = this.Exclamation.color = color9;
					this.ZoomIn = false;
					this.Timer = (float)0;
				}
			}
		}
	}

	public virtual void MurderWitnessed()
	{
		this.transform.position = this.Yandere.position + Vector3.up * 1.462788f;
		int num = 0;
		Color color = this.Exclamation.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Exclamation.color = color;
		int num3 = 30;
		Vector3 localEulerAngles = this.Exclamation.transform.localEulerAngles;
		float num4 = localEulerAngles.z = (float)num3;
		Vector3 vector = this.Exclamation.transform.localEulerAngles = localEulerAngles;
		this.Exclamation.transform.localScale = new Vector3((float)2, (float)2, (float)1);
		this.MurderCam.enabled = true;
		this.ZoomIn = true;
	}

	public virtual void Main()
	{
	}
}
