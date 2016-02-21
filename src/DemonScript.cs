using System;
using UnityEngine;

[Serializable]
public class DemonScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public UILabel DemonSubtitle;

	public UISprite Darkness;

	public UISprite Button;

	public AudioClip[] Clips;

	public string[] Lines;

	public bool Communing;

	public float Intensity;

	public Color MyColor;

	public int DemonID;

	public int Phase;

	public int ID;

	public DemonScript()
	{
		this.Intensity = 1f;
		this.Phase = 1;
	}

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Yandere.CanMove = false;
			this.Communing = true;
		}
		if (this.Communing)
		{
			if (this.Phase == 1)
			{
				float a = Mathf.MoveTowards(this.Darkness.color.a, (float)1, Time.deltaTime);
				Color color = this.Darkness.color;
				float num = color.a = a;
				Color color2 = this.Darkness.color = color;
				if (this.Darkness.color.a == (float)1)
				{
					this.DemonSubtitle.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
					this.DemonSubtitle.text = this.Lines[this.ID];
					this.DemonSubtitle.color = this.MyColor;
					int num2 = 0;
					Color color3 = this.DemonSubtitle.color;
					float num3 = color3.a = (float)num2;
					Color color4 = this.DemonSubtitle.color = color3;
					this.Phase++;
					if (this.Clips[this.ID] != null)
					{
						this.audio.clip = this.Clips[this.ID];
						this.audio.Play();
					}
				}
			}
			else if (this.Phase == 2)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-1f * this.Intensity, this.Intensity), UnityEngine.Random.Range(-1f * this.Intensity, this.Intensity), UnityEngine.Random.Range(-1f * this.Intensity, this.Intensity));
				float a2 = Mathf.MoveTowards(this.DemonSubtitle.color.a, (float)1, Time.deltaTime);
				Color color5 = this.DemonSubtitle.color;
				float num4 = color5.a = a2;
				Color color6 = this.DemonSubtitle.color = color5;
				float a3 = Mathf.MoveTowards(this.Button.color.a, (float)1, Time.deltaTime);
				Color color7 = this.Button.color;
				float num5 = color7.a = a3;
				Color color8 = this.Button.color = color7;
				if (this.DemonSubtitle.color.a == (float)1 && Input.GetButtonDown("A"))
				{
					this.Phase++;
				}
			}
			else if (this.Phase == 3)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-1f * this.Intensity, this.Intensity), UnityEngine.Random.Range(-1f * this.Intensity, this.Intensity), UnityEngine.Random.Range(-1f * this.Intensity, this.Intensity));
				float a4 = Mathf.MoveTowards(this.DemonSubtitle.color.a, (float)0, Time.deltaTime);
				Color color9 = this.DemonSubtitle.color;
				float num6 = color9.a = a4;
				Color color10 = this.DemonSubtitle.color = color9;
				if (this.DemonSubtitle.color.a == (float)0)
				{
					this.ID++;
					if (this.ID < this.Lines.Length)
					{
						this.Phase--;
						this.DemonSubtitle.text = this.Lines[this.ID];
						if (this.Clips[this.ID] != null)
						{
							this.audio.clip = this.Clips[this.ID];
							this.audio.Play();
						}
					}
					else
					{
						this.Phase++;
					}
				}
			}
			else
			{
				float a5 = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime);
				Color color11 = this.Darkness.color;
				float num7 = color11.a = a5;
				Color color12 = this.Darkness.color = color11;
				float a6 = Mathf.MoveTowards(this.Button.color.a, (float)0, Time.deltaTime);
				Color color13 = this.Button.color;
				float num8 = color13.a = a6;
				Color color14 = this.Button.color = color13;
				if (this.Darkness.color.a == (float)0)
				{
					this.Yandere.CanMove = true;
					this.Communing = false;
					this.Phase = 1;
					this.ID = 0;
					PlayerPrefs.SetInt("Demon_" + this.DemonID + "_Active", 1);
					PlayerPrefs.SetInt("Paranormal", 1);
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
