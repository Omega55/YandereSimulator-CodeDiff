using System;
using UnityEngine;

[Serializable]
public class YanvaniaCameraScript : MonoBehaviour
{
	public YanvaniaYanmontScript Yanmont;

	public GameObject Jukebox;

	public bool Cutscene;

	public bool StopMusic;

	public float TargetZoom;

	public float Zoom;

	public YanvaniaCameraScript()
	{
		this.StopMusic = true;
	}

	public virtual void Start()
	{
		this.transform.position = this.Yanmont.transform.position + new Vector3((float)0, 1.5f, -5.85f);
	}

	public virtual void FixedUpdate()
	{
		this.TargetZoom += Input.GetAxis("Mouse ScrollWheel");
		if (this.TargetZoom < (float)0)
		{
			this.TargetZoom = (float)0;
		}
		if (this.TargetZoom > 3.85f)
		{
			this.TargetZoom = 3.85f;
		}
		this.Zoom = Mathf.Lerp(this.Zoom, this.TargetZoom, Time.deltaTime);
		if (!this.Cutscene)
		{
			this.transform.position = this.Yanmont.transform.position + new Vector3((float)0, 1.5f, -5.85f + this.Zoom);
			if (this.transform.position.x > 47.9f)
			{
				float x = 47.9f;
				Vector3 position = this.transform.position;
				float num = position.x = x;
				Vector3 vector = this.transform.position = position;
			}
		}
		else
		{
			if (this.StopMusic)
			{
				if (this.Yanmont.Health > (float)0)
				{
					this.Jukebox.audio.volume = this.Jukebox.audio.volume - Time.deltaTime * 0.2f;
				}
				else
				{
					this.Jukebox.audio.volume = this.Jukebox.audio.volume - Time.deltaTime * 0.025f;
				}
				if (this.Jukebox.audio.volume <= (float)0)
				{
					this.StopMusic = false;
				}
			}
			float x2 = Mathf.MoveTowards(this.transform.position.x, -34.675f, Time.deltaTime * this.Yanmont.walkSpeed);
			Vector3 position2 = this.transform.position;
			float num2 = position2.x = x2;
			Vector3 vector2 = this.transform.position = position2;
			int num3 = 8;
			Vector3 position3 = this.transform.position;
			float num4 = position3.y = (float)num3;
			Vector3 vector3 = this.transform.position = position3;
			float z = -5.85f + this.Zoom;
			Vector3 position4 = this.transform.position;
			float num5 = position4.z = z;
			Vector3 vector4 = this.transform.position = position4;
		}
	}

	public virtual void Main()
	{
	}
}
