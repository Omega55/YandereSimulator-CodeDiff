using System;
using UnityEngine;

[Serializable]
public class WitnessCameraScript : MonoBehaviour
{
	public Transform WitnessPOV;

	public float WitnessTimer;

	public Camera MyCamera;

	public bool Show;

	public virtual void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect((float)0, (float)0, (float)0, (float)0);
	}

	public virtual void Update()
	{
		if (this.Show)
		{
			float width = Mathf.Lerp(this.MyCamera.rect.width, 0.25f, Time.deltaTime * (float)10);
			Rect rect = this.MyCamera.rect;
			float num = rect.width = width;
			Rect rect2 = this.MyCamera.rect = rect;
			float height = Mathf.Lerp(this.MyCamera.rect.height, 0.4444444f, Time.deltaTime * (float)10);
			Rect rect3 = this.MyCamera.rect;
			float num2 = rect3.height = height;
			Rect rect4 = this.MyCamera.rect = rect3;
			float z = this.transform.localPosition.z + Time.deltaTime * 0.09f;
			Vector3 localPosition = this.transform.localPosition;
			float num3 = localPosition.z = z;
			Vector3 vector = this.transform.localPosition = localPosition;
			this.WitnessTimer += Time.deltaTime;
			if (this.WitnessTimer > (float)5)
			{
				this.WitnessTimer = (float)0;
				this.Show = false;
			}
		}
		else
		{
			float width2 = Mathf.Lerp(this.MyCamera.rect.width, (float)0, Time.deltaTime * (float)10);
			Rect rect5 = this.MyCamera.rect;
			float num4 = rect5.width = width2;
			Rect rect6 = this.MyCamera.rect = rect5;
			float height2 = Mathf.Lerp(this.MyCamera.rect.height, (float)0, Time.deltaTime * (float)10);
			Rect rect7 = this.MyCamera.rect;
			float num5 = rect7.height = height2;
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
