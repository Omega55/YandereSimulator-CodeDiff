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

	public bool OverShoulder;

	public virtual void Update()
	{
		if (this.Yandere.FollowHips)
		{
			float x = Mathf.MoveTowards(this.transform.position.x, this.Yandere.Hips.position.x, Time.deltaTime);
			Vector3 position = this.transform.position;
			float num = position.x = x;
			Vector3 vector = this.transform.position = position;
			float z = Mathf.MoveTowards(this.transform.position.z, this.Yandere.Hips.position.z, Time.deltaTime);
			Vector3 position2 = this.transform.position;
			float num2 = position2.z = z;
			Vector3 vector2 = this.transform.position = position2;
		}
		if (this.Yandere.Crawling)
		{
			float y = Mathf.Lerp(this.transform.localPosition.y, 0.05f + this.Zoom + this.Slender, Time.deltaTime * (float)10);
			Vector3 localPosition = this.transform.localPosition;
			float num3 = localPosition.y = y;
			Vector3 vector3 = this.transform.localPosition = localPosition;
		}
		else if (this.Yandere.Crouching)
		{
			float y2 = Mathf.Lerp(this.transform.localPosition.y, 0.4f + this.Zoom + this.Slender, Time.deltaTime * (float)10);
			Vector3 localPosition2 = this.transform.localPosition;
			float num4 = localPosition2.y = y2;
			Vector3 vector4 = this.transform.localPosition = localPosition2;
		}
		else if (!this.Yandere.FollowHips)
		{
			if (this.Yandere.Slender)
			{
				float y3 = Mathf.Lerp(this.transform.localPosition.y, (float)1 + this.Zoom + this.Slender, Time.deltaTime * (float)10);
				Vector3 localPosition3 = this.transform.localPosition;
				float num5 = localPosition3.y = y3;
				Vector3 vector5 = this.transform.localPosition = localPosition3;
			}
			else if (this.Yandere.Stand.active)
			{
				float y4 = Mathf.Lerp(this.transform.localPosition.y, (float)1 - this.Zoom * 0.5f + this.Slender * 0.5f, Time.deltaTime * (float)10);
				Vector3 localPosition4 = this.transform.localPosition;
				float num6 = localPosition4.y = y4;
				Vector3 vector6 = this.transform.localPosition = localPosition4;
			}
			else
			{
				float y5 = Mathf.Lerp(this.transform.localPosition.y, (float)1 + this.Zoom, Time.deltaTime * (float)10);
				Vector3 localPosition5 = this.transform.localPosition;
				float num7 = localPosition5.y = y5;
				Vector3 vector7 = this.transform.localPosition = localPosition5;
			}
		}
		else
		{
			float y6 = Mathf.MoveTowards(this.transform.position.y, this.Yandere.Hips.position.y + this.Zoom, Time.deltaTime * (float)10);
			Vector3 position3 = this.transform.position;
			float num8 = position3.y = y6;
			Vector3 vector8 = this.transform.position = position3;
		}
		if (!this.Yandere.Aiming)
		{
			this.TargetZoom += Input.GetAxis("Mouse ScrollWheel");
		}
		if (this.Yandere.Slender || this.Yandere.Stand.active || this.Yandere.Blasting || this.Yandere.PK)
		{
			this.Slender = Mathf.Lerp(this.Slender, 0.5f, Time.deltaTime);
		}
		else
		{
			this.Slender = Mathf.Lerp(this.Slender, (float)0, Time.deltaTime);
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
		if (!this.Yandere.Possessed)
		{
			this.CameraScript.distance = (float)2 - this.Zoom * 3.33333f + this.Slender;
			this.CameraScript.distanceMax = (float)2 - this.Zoom * 3.33333f + this.Slender;
			this.CameraScript.distanceMin = (float)2 - this.Zoom * 3.33333f + this.Slender;
		}
		else
		{
			this.CameraScript.distance = (float)5;
			this.CameraScript.distanceMax = (float)5;
		}
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
			float x2 = Mathf.MoveTowards(this.transform.position.x, this.Yandere.Hips.position.x, Time.deltaTime * (float)10);
			Vector3 position4 = this.transform.position;
			float num9 = position4.x = x2;
			Vector3 vector9 = this.transform.position = position4;
			float z2 = Mathf.MoveTowards(this.transform.position.z, this.Yandere.Hips.position.z, Time.deltaTime * (float)10);
			Vector3 position5 = this.transform.position;
			float num10 = position5.z = z2;
			Vector3 vector10 = this.transform.position = position5;
		}
		else
		{
			this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, this.Target, Time.deltaTime * this.ShakeStrength * 0.1f);
		}
		if (this.OverShoulder)
		{
			float x3 = 0.25f;
			Vector3 localPosition6 = this.transform.localPosition;
			float num11 = localPosition6.x = x3;
			Vector3 vector11 = this.transform.localPosition = localPosition6;
		}
		else
		{
			int num12 = 0;
			Vector3 localPosition7 = this.transform.localPosition;
			float num13 = localPosition7.x = (float)num12;
			Vector3 vector12 = this.transform.localPosition = localPosition7;
		}
	}

	public virtual void Main()
	{
	}
}
