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
						this.Prompt.Label[0].text = "     " + "Pour";
						this.Prompt.enabled = true;
					}
				}
				else if (this.Yandere.PickUp.Bucket.Dumbbells == 5)
				{
					if (!this.Prompt.enabled)
					{
						this.Prompt.Label[0].text = "     " + "Drop";
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
			this.Prompt.Circle[0].fillAmount = (float)1;
			if (this.Prompt.Label[0].text == "     " + "Pour")
			{
				this.Yandere.Stool = this.transform;
				this.Yandere.CanMove = false;
				this.Yandere.Pouring = true;
				this.Yandere.PourDistance = this.PourDistance;
				this.Yandere.PourHeight = this.PourHeight;
				this.Yandere.PourTime = this.PourTime;
			}
			else
			{
				this.Yandere.Character.animation.CrossFade("f02_bucketDrop_00");
				this.Yandere.MyController.radius = (float)0;
				this.Yandere.BucketDropping = true;
				this.Yandere.DropSpot = this.transform;
				this.Yandere.CanMove = false;
			}
		}
		if (this.Yandere.Pouring)
		{
			if (this.PourHeight == "Low" && Input.GetButtonDown("B"))
			{
				this.SplashCamera.Show = true;
				this.SplashCamera.MyCamera.enabled = true;
				this.SplashCamera.transform.position = new Vector3(2.875f, 0.8f, -35.625f);
				this.SplashCamera.transform.eulerAngles = new Vector3((float)0, (float)45, (float)0);
			}
		}
		else if (this.Yandere.BucketDropping && Input.GetButtonDown("B"))
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
