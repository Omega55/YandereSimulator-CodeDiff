using System;
using UnityEngine;

[Serializable]
public class IntroCircleScript : MonoBehaviour
{
	public UISprite Sprite;

	public UILabel Label;

	public float[] StartTime;

	public float[] Duration;

	public string[] Text;

	public float CurrentTime;

	public float LastTime;

	public float Timer;

	public int ID;

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.ID < this.StartTime.Length && this.Timer > this.StartTime[this.ID])
		{
			this.CurrentTime = this.Duration[this.ID];
			this.LastTime = this.Duration[this.ID];
			this.Label.text = this.Text[this.ID];
			this.ID++;
		}
		if (this.CurrentTime > (float)0)
		{
			this.CurrentTime -= Time.deltaTime;
		}
		if (this.Timer > (float)1)
		{
			this.Sprite.fillAmount = this.CurrentTime / this.LastTime;
			if (this.Sprite.fillAmount <= (float)0)
			{
				this.Label.text = string.Empty;
			}
		}
		if (Input.GetKeyDown("space"))
		{
			this.CurrentTime -= (float)5;
			this.Timer += (float)5;
		}
	}

	public virtual void Main()
	{
	}
}
