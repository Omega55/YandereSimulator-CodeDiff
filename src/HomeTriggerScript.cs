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
			float a = Mathf.MoveTowards(this.Label.color.a, (float)1, Time.deltaTime * (float)10);
			Color color = this.Label.color;
			float num = color.a = a;
			Color color2 = this.Label.color = color;
		}
		else
		{
			float a2 = Mathf.MoveTowards(this.Label.color.a, (float)0, Time.deltaTime * (float)10);
			Color color3 = this.Label.color;
			float num2 = color3.a = a2;
			Color color4 = this.Label.color = color3;
		}
	}

	public virtual void Disable()
	{
		int num = 0;
		Color color = this.Label.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Label.color = color;
		this.active = false;
	}

	public virtual void Main()
	{
	}
}
