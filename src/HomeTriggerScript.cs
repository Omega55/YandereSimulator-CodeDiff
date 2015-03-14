using System;
using UnityEngine;

[Serializable]
public class HomeTriggerScript : MonoBehaviour
{
	public HomeCameraScript HomeCamera;

	public UILabel Label;

	public bool FadeIn;

	public int ID;

	public virtual void Start()
	{
		int num = 0;
		Color color = this.Label.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Label.color = color;
	}

	public virtual void OnTriggerEnter()
	{
		this.HomeCamera.ID = this.ID;
		this.FadeIn = true;
	}

	public virtual void OnTriggerExit()
	{
		this.HomeCamera.ID = 0;
		this.FadeIn = false;
	}

	public virtual void Update()
	{
		if (this.FadeIn)
		{
			float a = this.Label.color.a + Time.deltaTime;
			Color color = this.Label.color;
			float num = color.a = a;
			Color color2 = this.Label.color = color;
			if (this.Label.color.a > (float)1)
			{
				int num2 = 1;
				Color color3 = this.Label.color;
				float num3 = color3.a = (float)num2;
				Color color4 = this.Label.color = color3;
			}
		}
		else
		{
			float a2 = this.Label.color.a - Time.deltaTime;
			Color color5 = this.Label.color;
			float num4 = color5.a = a2;
			Color color6 = this.Label.color = color5;
			if (this.Label.color.a < (float)0)
			{
				int num5 = 0;
				Color color7 = this.Label.color;
				float num6 = color7.a = (float)num5;
				Color color8 = this.Label.color = color7;
			}
		}
	}

	public virtual void Main()
	{
	}
}
