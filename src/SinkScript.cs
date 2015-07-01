using System;
using UnityEngine;

[Serializable]
public class SinkScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
	}

	public virtual void Update()
	{
		if (this.Yandere.PickUp != null)
		{
			if (this.Yandere.PickUp.Bucket != null)
			{
				this.Prompt.enabled = true;
				if (!this.Yandere.PickUp.Bucket.Full)
				{
					this.Prompt.Label[0].text = "     " + "Fill Bucket";
				}
				else
				{
					this.Prompt.Label[0].text = "     " + "Empty Bucket";
				}
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			if (!this.Yandere.PickUp.Bucket.Full)
			{
				this.Yandere.PickUp.Bucket.Fill();
			}
			else
			{
				this.Yandere.PickUp.Bucket.Empty();
			}
			if (!this.Yandere.PickUp.Bucket.Full)
			{
				this.Prompt.Label[0].text = "     " + "Fill Bucket";
			}
			else
			{
				this.Prompt.Label[0].text = "     " + "Empty Bucket";
			}
			this.Prompt.Circle[0].fillAmount = (float)1;
		}
	}

	public virtual void Main()
	{
	}
}
