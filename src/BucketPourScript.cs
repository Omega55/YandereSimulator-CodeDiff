using System;
using UnityEngine;

[Serializable]
public class BucketPourScript : MonoBehaviour
{
	public SplashCameraScript SplashCamera;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public string PourHeight;

	public float PourDistance;

	public float PourTime;

	public BucketPourScript()
	{
		this.PourHeight = string.Empty;
	}

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.enabled = false;
	}

	public virtual void Update()
	{
		if (this.Yandere.PickUp != null)
		{
			if (this.Yandere.PickUp.Bucket != null)
			{
				if (this.Yandere.PickUp.Bucket.Full)
				{
					if (!this.Prompt.enabled)
					{
						this.Prompt.enabled = true;
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
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Prompt.Circle[0] != null && this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Yandere.Stool = this.transform;
			this.Yandere.CanMove = false;
			this.Yandere.Pouring = true;
			this.Yandere.PourDistance = this.PourDistance;
			this.Yandere.PourHeight = this.PourHeight;
			this.Yandere.PourTime = this.PourTime;
		}
		if (this.Yandere.Pouring && this.PourHeight == "Low" && Input.GetButtonDown("B"))
		{
			this.SplashCamera.Show = true;
			this.SplashCamera.MyCamera.enabled = true;
			this.SplashCamera.transform.position = new Vector3(2.875f, 0.8f, -35.625f);
			this.SplashCamera.transform.eulerAngles = new Vector3((float)0, (float)45, (float)0);
		}
	}

	public virtual void Main()
	{
	}
}
