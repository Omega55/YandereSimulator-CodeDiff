using System;
using UnityEngine;

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

	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.StartTime)
		{
			if (this.Button == null && this.New300 == null)
			{
				this.Button = UnityEngine.Object.Instantiate<GameObject>(this.OsuButton, base.transform.position, Quaternion.identity);
				this.Button.transform.parent = base.transform;
				this.Button.transform.localPosition = new Vector3(UnityEngine.Random.Range(-171f, 171f), UnityEngine.Random.Range(-68f, 68f), 0f);
				this.Button.transform.localEulerAngles = Vector3.zero;
				this.Button.transform.localScale = new Vector3(1f, 1f, 1f);
				UITexture component = this.Button.GetComponent<UITexture>();
				component.mainTexture = this.ButtonTexture;
				component.color = new Color(component.color.r, component.color.g, component.color.b, 0f);
				this.Circle = UnityEngine.Object.Instantiate<GameObject>(this.OsuCircle, base.transform.position, Quaternion.identity);
				this.Circle.transform.parent = base.transform;
				this.Circle.transform.localPosition = this.Button.transform.localPosition;
				this.Circle.transform.localEulerAngles = Vector3.zero;
				this.Circle.transform.localScale = new Vector3(2f, 2f, 2f);
				UITexture component2 = this.Circle.GetComponent<UITexture>();
				component2.mainTexture = this.CircleTexture;
				component2.color = new Color(component2.color.r, component2.color.g, component2.color.b, 0f);
			}
			else
			{
				if (this.Button != null)
				{
					UITexture component3 = this.Button.GetComponent<UITexture>();
					component3.color = new Color(component3.color.r, component3.color.g, component3.color.b, component3.color.a + Time.deltaTime);
					UITexture component4 = this.Circle.GetComponent<UITexture>();
					component4.color = new Color(component4.color.r, component4.color.g, component4.color.b, component4.color.a + Time.deltaTime);
					this.Circle.transform.localScale = new Vector3(this.Circle.transform.localScale.x - Time.deltaTime, this.Circle.transform.localScale.y - Time.deltaTime, this.Circle.transform.localScale.z);
					if (this.Circle.transform.localScale.x <= 0.5f)
					{
						this.New300 = UnityEngine.Object.Instantiate<GameObject>(this.Osu300, base.transform.position, Quaternion.identity);
						this.New300.transform.parent = base.transform;
						this.New300.transform.localPosition = this.Button.transform.localPosition;
						this.New300.transform.localEulerAngles = Vector3.zero;
						this.New300.transform.localScale = new Vector3(1f, 1f, 1f);
						UnityEngine.Object.Destroy(this.Button);
						UnityEngine.Object.Destroy(this.Circle);
					}
				}
				if (this.New300 != null)
				{
					UITexture component5 = this.New300.GetComponent<UITexture>();
					component5.color = new Color(component5.color.r, component5.color.g, component5.color.b, component5.color.a - Time.deltaTime);
					if (component5.color.a <= 0f)
					{
						UnityEngine.Object.Destroy(this.New300);
					}
				}
			}
		}
	}
}
