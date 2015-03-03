using System;
using UnityEngine;

[Serializable]
public class PhoneScript : MonoBehaviour
{
	public GameObject[] RightMessage;

	public GameObject[] LeftMessage;

	public GameObject NewMessage;

	public Transform OldMessages;

	public Transform Buttons;

	public Transform Panel;

	public Vignetting Vignette;

	public UISprite Darkness;

	public UISprite Sprite;

	public int[] Speaker;

	public string[] Text;

	public int[] Height;

	public bool FadeOut;

	public float Timer;

	public int ID;

	public virtual void Start()
	{
		int num = -65;
		Vector3 localPosition = this.Buttons.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.Buttons.localPosition = localPosition;
		int num3 = 1;
		Color color = this.Darkness.color;
		float num4 = color.a = (float)num3;
		Color color2 = this.Darkness.color = color;
	}

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (!this.FadeOut)
		{
			if (this.Timer > (float)1)
			{
				if (this.Vignette.intensity < (float)5)
				{
					this.Vignette.intensity = this.Vignette.intensity + Time.deltaTime * (float)5;
					if (this.Vignette.intensity > (float)5)
					{
						this.Vignette.intensity = (float)5;
					}
				}
				float a = this.Darkness.color.a - Time.deltaTime;
				Color color = this.Darkness.color;
				float num = color.a = a;
				Color color2 = this.Darkness.color = color;
				if (this.Darkness.color.a <= (float)0)
				{
					int num2 = 0;
					Color color3 = this.Darkness.color;
					float num3 = color3.a = (float)num2;
					Color color4 = this.Darkness.color = color3;
					if (this.NewMessage == null)
					{
						this.SpawnMessage();
					}
				}
			}
			if (this.NewMessage != null)
			{
				float y = Mathf.Lerp(this.Buttons.localPosition.y, (float)0, Time.deltaTime * (float)10);
				Vector3 localPosition = this.Buttons.localPosition;
				float num4 = localPosition.y = y;
				Vector3 vector = this.Buttons.localPosition = localPosition;
				if (Input.GetButtonDown("A"))
				{
					if (this.ID < this.Text.Length - 1)
					{
						this.ID++;
						this.SpawnMessage();
					}
					else
					{
						this.Darkness.color = new Color((float)0, (float)0, (float)0, (float)0);
						this.FadeOut = true;
					}
				}
			}
		}
		else
		{
			float a2 = this.Darkness.color.a + Time.deltaTime;
			Color color5 = this.Darkness.color;
			float num5 = color5.a = a2;
			Color color6 = this.Darkness.color = color5;
			if (this.Darkness.color.a >= (float)1)
			{
				Application.LoadLevel("CalendarScene");
			}
		}
	}

	public virtual void SpawnMessage()
	{
		if (this.NewMessage != null)
		{
			this.NewMessage.transform.parent = this.OldMessages;
			float y = this.OldMessages.localPosition.y + (float)(72 + this.Height[this.ID] * 32);
			Vector3 localPosition = this.OldMessages.localPosition;
			float num = localPosition.y = y;
			Vector3 vector = this.OldMessages.localPosition = localPosition;
		}
		if (this.Speaker[this.ID] == 1)
		{
			this.NewMessage = (GameObject)UnityEngine.Object.Instantiate(this.LeftMessage[this.Height[this.ID]]);
			this.NewMessage.transform.parent = this.Panel;
			this.NewMessage.transform.localPosition = new Vector3((float)-225, (float)-375, (float)0);
			this.NewMessage.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		}
		else
		{
			this.NewMessage = (GameObject)UnityEngine.Object.Instantiate(this.RightMessage[this.Height[this.ID]]);
			this.NewMessage.transform.parent = this.Panel;
			this.NewMessage.transform.localPosition = new Vector3((float)225, (float)-375, (float)0);
			this.NewMessage.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		}
		((TextMessageScript)this.NewMessage.GetComponent(typeof(TextMessageScript))).Label.text = this.Text[this.ID];
	}

	public virtual void Main()
	{
	}
}
