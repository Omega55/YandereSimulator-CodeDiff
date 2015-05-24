using System;
using UnityEngine;

[Serializable]
public class OsuScript : MonoBehaviour
{
	public GameObject Button;

	public GameObject Circle;

	public GameObject New300;

	public GameObject OsuButton;

	public GameObject OsuCircle;

	public GameObject Osu300;

	public Texture ButtonTexture;

	public Texture CircleTexture;

	public float StartTime;

	public float Timer;

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.StartTime)
		{
			if (this.Button == null && this.New300 == null)
			{
				this.Button = (GameObject)UnityEngine.Object.Instantiate(this.OsuButton, this.transform.position, Quaternion.identity);
				this.Button.transform.parent = this.transform;
				float x = UnityEngine.Random.Range(-171f, 171f);
				Vector3 localPosition = this.Button.transform.localPosition;
				float num = localPosition.x = x;
				Vector3 vector = this.Button.transform.localPosition = localPosition;
				float y = UnityEngine.Random.Range(-68f, 68f);
				Vector3 localPosition2 = this.Button.transform.localPosition;
				float num2 = localPosition2.y = y;
				Vector3 vector2 = this.Button.transform.localPosition = localPosition2;
				int num3 = 0;
				Vector3 localPosition3 = this.Button.transform.localPosition;
				float num4 = localPosition3.z = (float)num3;
				Vector3 vector3 = this.Button.transform.localPosition = localPosition3;
				this.Button.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
				this.Button.transform.localScale = new Vector3((float)1, (float)1, (float)1);
				((UITexture)this.Button.GetComponent(typeof(UITexture))).mainTexture = this.ButtonTexture;
				int num5 = 0;
				Color color = ((UITexture)this.Button.GetComponent(typeof(UITexture))).color;
				float num6 = color.a = (float)num5;
				Color color2 = ((UITexture)this.Button.GetComponent(typeof(UITexture))).color = color;
				this.Circle = (GameObject)UnityEngine.Object.Instantiate(this.OsuCircle, this.transform.position, Quaternion.identity);
				this.Circle.transform.parent = this.transform;
				this.Circle.transform.localPosition = this.Button.transform.localPosition;
				this.Circle.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
				this.Circle.transform.localScale = new Vector3((float)2, (float)2, (float)2);
				((UITexture)this.Circle.GetComponent(typeof(UITexture))).mainTexture = this.CircleTexture;
				int num7 = 0;
				Color color3 = ((UITexture)this.Circle.GetComponent(typeof(UITexture))).color;
				float num8 = color3.a = (float)num7;
				Color color4 = ((UITexture)this.Circle.GetComponent(typeof(UITexture))).color = color3;
			}
			else
			{
				if (this.Button != null)
				{
					float a = ((UITexture)this.Button.GetComponent(typeof(UITexture))).color.a + Time.deltaTime;
					Color color5 = ((UITexture)this.Button.GetComponent(typeof(UITexture))).color;
					float num9 = color5.a = a;
					Color color6 = ((UITexture)this.Button.GetComponent(typeof(UITexture))).color = color5;
					float a2 = ((UITexture)this.Circle.GetComponent(typeof(UITexture))).color.a + Time.deltaTime;
					Color color7 = ((UITexture)this.Circle.GetComponent(typeof(UITexture))).color;
					float num10 = color7.a = a2;
					Color color8 = ((UITexture)this.Circle.GetComponent(typeof(UITexture))).color = color7;
					float x2 = this.Circle.transform.localScale.x - Time.deltaTime;
					Vector3 localScale = this.Circle.transform.localScale;
					float num11 = localScale.x = x2;
					Vector3 vector4 = this.Circle.transform.localScale = localScale;
					float y2 = this.Circle.transform.localScale.y - Time.deltaTime;
					Vector3 localScale2 = this.Circle.transform.localScale;
					float num12 = localScale2.y = y2;
					Vector3 vector5 = this.Circle.transform.localScale = localScale2;
					if (this.Circle.transform.localScale.x <= 0.5f)
					{
						this.New300 = (GameObject)UnityEngine.Object.Instantiate(this.Osu300, this.transform.position, Quaternion.identity);
						this.New300.transform.parent = this.transform;
						this.New300.transform.localPosition = this.Button.transform.localPosition;
						this.New300.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
						this.New300.transform.localScale = new Vector3((float)1, (float)1, (float)1);
						UnityEngine.Object.Destroy(this.Button);
						UnityEngine.Object.Destroy(this.Circle);
					}
				}
				if (this.New300 != null)
				{
					float a3 = ((UITexture)this.New300.GetComponent(typeof(UITexture))).color.a - Time.deltaTime;
					Color color9 = ((UITexture)this.New300.GetComponent(typeof(UITexture))).color;
					float num13 = color9.a = a3;
					Color color10 = ((UITexture)this.New300.GetComponent(typeof(UITexture))).color = color9;
					if (((UITexture)this.New300.GetComponent(typeof(UITexture))).color.a <= (float)0)
					{
						UnityEngine.Object.Destroy(this.New300);
					}
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
