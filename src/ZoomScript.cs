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

	public float Timer;

	public Vector3 Target;

	public virtual void Update()
	{
		float y = (float)1 + this.Zoom;
		Vector3 localPosition = this.transform.localPosition;
		float num = localPosition.y = y;
		Vector3 vector = this.transform.localPosition = localPosition;
		this.TargetZoom += Input.GetAxis("Mouse ScrollWheel");
		if (this.TargetZoom < (float)0)
		{
			this.TargetZoom = (float)0;
		}
		else if (this.TargetZoom > 0.4f)
		{
			this.TargetZoom = 0.4f;
		}
		this.Zoom = Mathf.Lerp(this.Zoom, this.TargetZoom, Time.deltaTime);
		this.CameraScript.distance = (float)2 - this.Zoom * 3.33333f;
		this.CameraScript.distanceMax = (float)2 - this.Zoom * 3.33333f;
		this.CameraScript.distanceMin = (float)2 - this.Zoom * 3.33333f;
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
		this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, this.Target, Time.deltaTime * this.ShakeStrength * 0.1f);
	}

	public virtual void Main()
	{
	}
}
