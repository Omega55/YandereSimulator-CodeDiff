using System;
using UnityEngine;

[Serializable]
public class SplashCameraScript : MonoBehaviour
{
	public Camera MyCamera;

	public bool Show;

	public float Timer;

	public virtual void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect((float)0, 0.219f, (float)0, (float)0);
	}

	public virtual void Update()
	{
		if (this.Show)
		{
			float width = Mathf.Lerp(this.MyCamera.rect.width, 0.4f, Time.deltaTime * (float)10);
			Rect rect = this.MyCamera.rect;
			float num = rect.width = width;
			Rect rect2 = this.MyCamera.rect = rect;
			float height = Mathf.Lerp(this.MyCamera.rect.height, 0.71104f, Time.deltaTime * (float)10);
			Rect rect3 = this.MyCamera.rect;
			float num2 = rect3.height = height;
			Rect rect4 = this.MyCamera.rect = rect3;
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)10)
			{
				this.Show = false;
				this.Timer = (float)0;
			}
		}
		else
		{
			float width2 = Mathf.Lerp(this.MyCamera.rect.width, (float)0, Time.deltaTime * (float)10);
			Rect rect5 = this.MyCamera.rect;
			float num3 = rect5.width = width2;
			Rect rect6 = this.MyCamera.rect = rect5;
			float height2 = Mathf.Lerp(this.MyCamera.rect.height, (float)0, Time.deltaTime * (float)10);
			Rect rect7 = this.MyCamera.rect;
			float num4 = rect7.height = height2;
			Rect rect8 = this.MyCamera.rect = rect7;
			if (this.MyCamera.enabled && this.MyCamera.rect.width < 0.1f)
			{
				this.MyCamera.enabled = false;
			}
		}
	}

	public virtual void Main()
	{
	}
}
