using System;
using UnityEngine;

[Serializable]
public class BoundaryScript : MonoBehaviour
{
	public Transform Yandere;

	public UITexture Static;

	public UILabel Label;

	public float Intensity;

	public virtual void Update()
	{
		if (this.Yandere.position.z < (float)-94)
		{
			this.Intensity = -95f + Mathf.Abs(this.Yandere.position.z);
			float a = this.Intensity / 5f;
			Color color = this.Static.color;
			float num = color.a = a;
			Color color2 = this.Static.color = color;
			float a2 = this.Intensity / 5f;
			Color color3 = this.Label.color;
			float num2 = color3.a = a2;
			Color color4 = this.Label.color = color3;
			this.audio.volume = this.Intensity / 5f * 0.1f;
			float x = UnityEngine.Random.Range(-10f, 10f);
			Vector3 localPosition = this.Label.transform.localPosition;
			float num3 = localPosition.x = x;
			Vector3 vector = this.Label.transform.localPosition = localPosition;
			float y = UnityEngine.Random.Range(-10f, 10f);
			Vector3 localPosition2 = this.Label.transform.localPosition;
			float num4 = localPosition2.y = y;
			Vector3 vector2 = this.Label.transform.localPosition = localPosition2;
		}
	}

	public virtual void Main()
	{
	}
}
