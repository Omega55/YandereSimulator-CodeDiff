using System;
using UnityEngine;

[Serializable]
public class ClassMarkerScript : MonoBehaviour
{
	public ScheduleManagerScript ScheduleManager;

	public GameObject Yandere;

	public GameObject ButtonObject;

	public GameObject CircleObject;

	public GameObject LabelObject;

	public Transform ButtonPanel;

	public Camera UICamera;

	public UISprite Button;

	public UISprite Circle;

	public UILabel Label;

	public bool YHeldDown;

	public bool InView;

	public float Distance;

	public string LabelText;

	public ClassMarkerScript()
	{
		this.LabelText = string.Empty;
	}

	public virtual void Start()
	{
		this.Yandere = GameObject.Find("YandereChan");
		this.ButtonPanel = (Transform)GameObject.Find("ButtonPanel").GetComponent(typeof(Transform));
		this.UICamera = (Camera)GameObject.Find("UI Camera").GetComponent(typeof(Camera));
		this.Button = (UISprite)((GameObject)UnityEngine.Object.Instantiate(this.ButtonObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UISprite));
		this.Button.transform.parent = this.ButtonPanel;
		this.Button.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		this.Button.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		int num = 0;
		Color color = this.Button.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Button.color = color;
		this.Circle = (UISprite)((GameObject)UnityEngine.Object.Instantiate(this.CircleObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UISprite));
		this.Circle.transform.parent = this.ButtonPanel;
		this.Circle.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		this.Circle.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		int num3 = 0;
		Color color3 = this.Circle.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.Circle.color = color3;
		this.Label = (UILabel)((GameObject)UnityEngine.Object.Instantiate(this.LabelObject, this.transform.position, Quaternion.identity)).GetComponent(typeof(UILabel));
		this.Label.transform.parent = this.ButtonPanel;
		this.Label.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		this.Label.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		int num5 = 0;
		Color color5 = this.Label.color;
		float num6 = color5.a = (float)num5;
		Color color6 = this.Label.color = color5;
		this.Label.text = "     " + this.LabelText;
	}

	public virtual void Update()
	{
		if (this.InView)
		{
			this.Distance = Vector3.Distance(this.Yandere.transform.position, this.transform.position);
			if (this.Distance < (float)5)
			{
				Vector2 vector = this.UICamera.WorldToScreenPoint(this.transform.position + Vector3.up * (float)1);
				this.Button.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
				this.Circle.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
				Vector2 vector2 = this.UICamera.WorldToScreenPoint(this.transform.position + Vector3.up * (float)1);
				this.Label.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector2.x, vector2.y, 1f));
				this.Button.color = new Color(0.5f, 0.5f, 0.5f, (float)1);
				int num = 0;
				Color color = this.Circle.color;
				float num2 = color.a = (float)num;
				Color color2 = this.Circle.color = color;
				float a = 0.5f;
				Color color3 = this.Label.color;
				float num3 = color3.a = a;
				Color color4 = this.Label.color = color3;
				if (this.Distance < (float)1)
				{
					this.Button.color = new Color((float)1, (float)1, (float)1, (float)1);
					int num4 = 1;
					Color color5 = this.Label.color;
					float num5 = color5.a = (float)num4;
					Color color6 = this.Label.color = color5;
					this.Circle.color = new Color(0.5f, 0.5f, 0.5f, (float)1);
					if (!this.YHeldDown)
					{
						if (Input.GetButton("Y"))
						{
							this.Circle.color = new Color((float)1, (float)1, (float)1, (float)1);
							this.Circle.fillAmount = this.Circle.fillAmount - Time.deltaTime * (float)2;
							if (this.Circle.fillAmount <= (float)0)
							{
								this.ScheduleManager.ChangeTime();
							}
						}
						else
						{
							this.Circle.fillAmount = (float)1;
						}
					}
				}
			}
			else
			{
				int num6 = 0;
				Color color7 = this.Button.color;
				float num7 = color7.a = (float)num6;
				Color color8 = this.Button.color = color7;
				int num8 = 0;
				Color color9 = this.Circle.color;
				float num9 = color9.a = (float)num8;
				Color color10 = this.Circle.color = color9;
				int num10 = 0;
				Color color11 = this.Label.color;
				float num11 = color11.a = (float)num10;
				Color color12 = this.Label.color = color11;
			}
		}
		else
		{
			int num12 = 0;
			Color color13 = this.Button.color;
			float num13 = color13.a = (float)num12;
			Color color14 = this.Button.color = color13;
			int num14 = 0;
			Color color15 = this.Circle.color;
			float num15 = color15.a = (float)num14;
			Color color16 = this.Circle.color = color15;
			int num16 = 0;
			Color color17 = this.Label.color;
			float num17 = color17.a = (float)num16;
			Color color18 = this.Label.color = color17;
		}
	}

	public virtual void OnBecameVisible()
	{
		this.InView = true;
	}

	public virtual void OnBecameInvisible()
	{
		this.InView = false;
		int num = 0;
		Color color = this.Button.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Button.color = color;
		int num3 = 0;
		Color color3 = this.Circle.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.Circle.color = color3;
		int num5 = 0;
		Color color5 = this.Label.color;
		float num6 = color5.a = (float)num5;
		Color color6 = this.Label.color = color5;
	}

	public virtual void Main()
	{
	}
}
