using System;
using UnityEngine;

[Serializable]
public class YanvaniaIntroScript : MonoBehaviour
{
	public YanvaniaZombieSpawnerScript ZombieSpawner;

	public YanvaniaYanmontScript Yanmont;

	public GameObject Jukebox;

	public Transform BlackRight;

	public Transform BlackLeft;

	public UILabel FinalStage;

	public UILabel Heartbreak;

	public UITexture Triangle;

	public float LeaveTime;

	public float Position;

	public float Timer;

	public virtual void Start()
	{
		this.BlackRight.gameObject.active = true;
		this.BlackLeft.gameObject.active = true;
		this.FinalStage.gameObject.active = true;
		this.Heartbreak.gameObject.active = true;
		this.Triangle.gameObject.active = true;
		this.Triangle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		int num = 1300;
		Vector3 localPosition = this.Heartbreak.transform.localPosition;
		float num2 = localPosition.x = (float)num;
		Vector3 vector = this.Heartbreak.transform.localPosition = localPosition;
		int num3 = -1300;
		Vector3 localPosition2 = this.FinalStage.transform.localPosition;
		float num4 = localPosition2.x = (float)num3;
		Vector3 vector2 = this.FinalStage.transform.localPosition = localPosition2;
	}

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > (float)1 && this.Timer < (float)3)
		{
			if (!this.Jukebox.active)
			{
				this.Jukebox.active = true;
			}
			this.Triangle.transform.localScale = Vector3.Lerp(this.Triangle.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			float x = Mathf.Lerp(this.Heartbreak.transform.localPosition.x, (float)0, Time.deltaTime * (float)10);
			Vector3 localPosition = this.Heartbreak.transform.localPosition;
			float num = localPosition.x = x;
			Vector3 vector = this.Heartbreak.transform.localPosition = localPosition;
			float x2 = Mathf.Lerp(this.FinalStage.transform.localPosition.x, (float)0, Time.deltaTime * (float)10);
			Vector3 localPosition2 = this.FinalStage.transform.localPosition;
			float num2 = localPosition2.x = x2;
			Vector3 vector2 = this.FinalStage.transform.localPosition = localPosition2;
		}
		else if (this.Timer > (float)3)
		{
			if (!this.Jukebox.active)
			{
				this.Jukebox.active = true;
			}
			float z = this.Triangle.transform.localEulerAngles.z + (float)36 * Time.deltaTime;
			Vector3 localEulerAngles = this.Triangle.transform.localEulerAngles;
			float num3 = localEulerAngles.z = z;
			Vector3 vector3 = this.Triangle.transform.localEulerAngles = localEulerAngles;
			float a = this.Triangle.color.a - Time.deltaTime;
			Color color = this.Triangle.color;
			float num4 = color.a = a;
			Color color2 = this.Triangle.color = color;
			float a2 = this.Heartbreak.color.a - Time.deltaTime;
			Color color3 = this.Heartbreak.color;
			float num5 = color3.a = a2;
			Color color4 = this.Heartbreak.color = color3;
			float a3 = this.FinalStage.color.a - Time.deltaTime;
			Color color5 = this.FinalStage.color;
			float num6 = color5.a = a3;
			Color color6 = this.FinalStage.color = color5;
		}
		if (this.Timer > (float)4)
		{
			this.Finish();
		}
		if (this.Timer > this.LeaveTime)
		{
			if (this.Position == (float)0)
			{
				this.Position += Time.deltaTime;
			}
			else
			{
				this.Position += this.Position * 0.1f;
			}
			if (this.BlackLeft.localPosition.x > (float)-2100)
			{
				float x3 = this.BlackRight.localPosition.x + this.Position;
				Vector3 localPosition3 = this.BlackRight.localPosition;
				float num7 = localPosition3.x = x3;
				Vector3 vector4 = this.BlackRight.localPosition = localPosition3;
				float x4 = this.BlackLeft.localPosition.x - this.Position;
				Vector3 localPosition4 = this.BlackLeft.localPosition;
				float num8 = localPosition4.x = x4;
				Vector3 vector5 = this.BlackLeft.localPosition = localPosition4;
			}
		}
		if (Input.GetKeyDown("1"))
		{
			this.Finish();
		}
	}

	public virtual void Finish()
	{
		if (!this.Jukebox.active)
		{
			this.Jukebox.active = true;
		}
		this.ZombieSpawner.enabled = true;
		this.Yanmont.CanMove = true;
		UnityEngine.Object.Destroy(this.gameObject);
	}

	public virtual void Main()
	{
	}
}
