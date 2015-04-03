using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class AboutScript : MonoBehaviour
{
	public Transform[] Labels;

	public bool[] SlideOut;

	public bool[] SlideIn;

	public UILabel LinkLabel;

	public UITexture Yuno1;

	public UITexture Yuno2;

	public int SlideID;

	public int ID;

	public float Timer;

	public virtual void Start()
	{
		while (this.ID < Extensions.get_length(this.Labels))
		{
			int num = 2000;
			Vector3 localPosition = this.Labels[this.ID].localPosition;
			float num2 = localPosition.x = (float)num;
			Vector3 vector = this.Labels[this.ID].localPosition = localPosition;
			this.ID++;
		}
	}

	public virtual void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			if (this.SlideID < Extensions.get_length(this.Labels))
			{
				this.SlideIn[this.SlideID] = true;
			}
			this.SlideID++;
		}
		if (this.SlideID < Extensions.get_length(this.Labels) + 1)
		{
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.Labels))
			{
				if (this.SlideIn[this.ID])
				{
					float x = Mathf.Lerp(this.Labels[this.ID].localPosition.x, (float)0, Time.deltaTime);
					Vector3 localPosition = this.Labels[this.ID].localPosition;
					float num = localPosition.x = x;
					Vector3 vector = this.Labels[this.ID].localPosition = localPosition;
				}
				this.ID++;
			}
		}
		else
		{
			this.Timer += Time.deltaTime * (float)10;
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.Labels))
			{
				if (this.Timer > (float)this.ID)
				{
					this.SlideOut[this.ID] = true;
					if (this.Labels[this.ID].localPosition.x > (float)0)
					{
						float x2 = -0.1f;
						Vector3 localPosition2 = this.Labels[this.ID].localPosition;
						float num2 = localPosition2.x = x2;
						Vector3 vector2 = this.Labels[this.ID].localPosition = localPosition2;
					}
				}
				this.ID++;
			}
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.Labels))
			{
				if (this.SlideOut[this.ID])
				{
					float x3 = this.Labels[this.ID].localPosition.x + this.Labels[this.ID].localPosition.x * 0.01f;
					Vector3 localPosition3 = this.Labels[this.ID].localPosition;
					float num3 = localPosition3.x = x3;
					Vector3 vector3 = this.Labels[this.ID].localPosition = localPosition3;
				}
				this.ID++;
			}
			if (this.SlideID > Extensions.get_length(this.Labels) + 1)
			{
				float a = this.LinkLabel.color.a + Time.deltaTime;
				Color color = this.LinkLabel.color;
				float num4 = color.a = a;
				Color color2 = this.LinkLabel.color = color;
			}
			if (this.SlideID > Extensions.get_length(this.Labels) + 2)
			{
				float a2 = this.Yuno1.color.a + Time.deltaTime;
				Color color3 = this.Yuno1.color;
				float num5 = color3.a = a2;
				Color color4 = this.Yuno1.color = color3;
			}
			if (this.SlideID > Extensions.get_length(this.Labels) + 3)
			{
				float a3 = this.Yuno2.color.a + Time.deltaTime;
				Color color5 = this.Yuno2.color;
				float num6 = color5.a = a3;
				Color color6 = this.Yuno2.color = color5;
				float x4 = this.Yuno2.transform.localScale.x + Time.deltaTime * 0.1f;
				Vector3 localScale = this.Yuno2.transform.localScale;
				float num7 = localScale.x = x4;
				Vector3 vector4 = this.Yuno2.transform.localScale = localScale;
				float y = this.Yuno2.transform.localScale.y + Time.deltaTime * 0.1f;
				Vector3 localScale2 = this.Yuno2.transform.localScale;
				float num8 = localScale2.y = y;
				Vector3 vector5 = this.Yuno2.transform.localScale = localScale2;
			}
		}
	}

	public virtual void Main()
	{
	}
}
