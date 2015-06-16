using System;
using UnityEngine;

[Serializable]
public class ZoomScript : MonoBehaviour
{
	public RPG_Camera CameraScript;

	public YandereScript Yandere;

	public float TargetZoom;

	public float Zoom;

	public float ShakeStrength;

	public float Slender;

	public float Timer;

	public Vector3 Target;

	public virtual void Update()
	{
		if (this.Yandere.Crawling)
		{
			float y = Mathf.Lerp(this.transform.localPosition.y, 0.05f + this.Zoom + this.Slender, Time.deltaTime * (float)10);
			Vector3 localPosition = this.transform.localPosition;
			float num = localPosition.y = y;
			Vector3 vector = this.transform.localPosition = localPosition;
		}
		else if (this.Yandere.Crouching)
		{
			float y2 = Mathf.Lerp(this.transform.localPosition.y, 0.4f + this.Zoom + this.Slender, Time.deltaTime * (float)10);
			Vector3 localPosition2 = this.transform.localPosition;
			float num2 = localPosition2.y = y2;
			Vector3 vector2 = this.transform.localPosition = localPosition2;
		}
		else
		{
			float y3 = Mathf.Lerp(this.transform.localPosition.y, (float)1 + this.Zoom + this.Slender, Time.deltaTime * (float)10);
			Vector3 localPosition3 = this.transform.localPosition;
			float num3 = localPosition3.y = y3;
			Vector3 vector3 = this.transform.localPosition = localPosition3;
		}
		if (!this.Yandere.Aiming)
		{
			this.TargetZoom += Input.GetAxis("Mouse ScrollWheel");
		}
		if (this.Yandere.Slender || this.Yandere.Stand.active)
		{
			this.Slender = 0.5f;
		}
		if (this.TargetZoom < (float)0)
		{
			this.TargetZoom = (float)0;
		}
		if (this.Yandere.Crawling)
		{
			if (this.TargetZoom > 0.3f)
			{
				this.TargetZoom = 0.3f;
			}
		}
		else if (this.TargetZoom > 0.4f)
		{
			this.TargetZoom = 0.4f;
		}
		this.Zoom = Mathf.Lerp(this.Zoom, this.TargetZoom, Time.deltaTime);
		this.CameraScript.distance = (float)2 - this.Zoom * 3.33333f + this.Slender;
		this.CameraScript.distanceMax = (float)2 - this.Zoom * 3.33333f + this.Slender;
		this.CameraScript.distanceMin = (float)2 - this.Zoom * 3.33333f + this.Slender;
		if (!this.Yandere.TimeSkipping)
		{
			this.Timer += Time.deltaTime;
			this.ShakeStrength = Mathf.Lerp(this.ShakeStrength, (float)1 - this.Yandere.Sanity * 0.01f, Time.deltaTime);
			if (this.Timer > 0.1f + this.Yandere.Sanity * 0.01f)
			{
				this.Target.x = UnityEngine.Random.Range(-1f * this.ShakeStrength, 1f * this.ShakeStrength);
				this.Target.y = this.transform.localPosition.y;
				this.Target.z = UnityEngine.Random.Range(-1f * this.ShakeStrength, 1f * this.ShakeStrength);
				this.Timer = (float)0;
			}
		}
		else
		{
			this.Target = new Vector3((float)0, this.transform.localPosition.y, (float)0);
		}
		if (this.Yandere.RoofPush)
		{
			float x = Mathf.MoveTowards(this.transform.position.x, this.Yandere.Hips.position.x, Time.deltaTime * (float)10);
			Vector3 position = this.transform.position;
			float num4 = position.x = x;
			Vector3 vector4 = this.transform.position = position;
			float z = Mathf.MoveTowards(this.transform.position.z, this.Yandere.Hips.position.z, Time.deltaTime * (float)10);
			Vector3 position2 = this.transform.position;
			float num5 = position2.z = z;
			Vector3 vector5 = this.transform.position = position2;
		}
		else
		{
			this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, this.Target, Time.deltaTime * this.ShakeStrength * 0.1f);
		}
	}

	public virtual void Main()
	{
	}
}
