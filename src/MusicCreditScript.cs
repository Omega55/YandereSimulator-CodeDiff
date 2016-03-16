using System;
using UnityEngine;

[Serializable]
public class MusicCreditScript : MonoBehaviour
{
	public UILabel SongLabel;

	public UILabel BandLabel;

	public bool Slide;

	public float Timer;

	public virtual void Start()
	{
		int num = 400;
		Vector3 localPosition = this.transform.localPosition;
		float num2 = localPosition.x = (float)num;
		Vector3 vector = this.transform.localPosition = localPosition;
	}

	public virtual void Update()
	{
		if (this.Slide)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer < (float)5)
			{
				float x = Mathf.Lerp(this.transform.localPosition.x, (float)0, Time.deltaTime * (float)10);
				Vector3 localPosition = this.transform.localPosition;
				float num = localPosition.x = x;
				Vector3 vector = this.transform.localPosition = localPosition;
			}
			else
			{
				float x2 = this.transform.localPosition.x + Time.deltaTime;
				Vector3 localPosition2 = this.transform.localPosition;
				float num2 = localPosition2.x = x2;
				Vector3 vector2 = this.transform.localPosition = localPosition2;
				float x3 = this.transform.localPosition.x + Mathf.Abs(this.transform.localPosition.x * 0.01f) * Time.deltaTime * (float)1000;
				Vector3 localPosition3 = this.transform.localPosition;
				float num3 = localPosition3.x = x3;
				Vector3 vector3 = this.transform.localPosition = localPosition3;
				if (this.transform.localPosition.x > (float)400)
				{
					int num4 = 400;
					Vector3 localPosition4 = this.transform.localPosition;
					float num5 = localPosition4.x = (float)num4;
					Vector3 vector4 = this.transform.localPosition = localPosition4;
					this.Slide = false;
					this.Timer = (float)0;
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
