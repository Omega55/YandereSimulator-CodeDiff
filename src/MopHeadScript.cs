using System;
using UnityEngine;

[Serializable]
public class MopHeadScript : MonoBehaviour
{
	public bool Mopping;

	public Renderer Blood;

	public float Bloodiness;

	public virtual void Start()
	{
		int num = 0;
		Color color = this.Blood.material.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Blood.material.color = color;
	}

	public virtual void OnTriggerStay(Collider other)
	{
		if (this.Mopping && this.Bloodiness < (float)9 && (other.name == "BloodPool(Clone)" || other.name == "BloodyShoeprint(Clone)"))
		{
			if (other.name == "BloodPool(Clone)")
			{
				((BloodPoolScript)other.GetComponent(typeof(BloodPoolScript))).Bleed = false;
			}
			this.Bloodiness += Time.deltaTime;
			float a = this.Bloodiness * 0.1f;
			Color color = this.Blood.material.color;
			float num = color.a = a;
			Color color2 = this.Blood.material.color = color;
			float x = other.transform.localScale.x - Time.deltaTime;
			Vector3 localScale = other.transform.localScale;
			float num2 = localScale.x = x;
			Vector3 vector = other.transform.localScale = localScale;
			float y = other.transform.localScale.y - Time.deltaTime;
			Vector3 localScale2 = other.transform.localScale;
			float num3 = localScale2.y = y;
			Vector3 vector2 = other.transform.localScale = localScale2;
			float z = other.transform.localScale.z - Time.deltaTime;
			Vector3 localScale3 = other.transform.localScale;
			float num4 = localScale3.z = z;
			Vector3 vector3 = other.transform.localScale = localScale3;
			if (other.transform.localScale.x < 0.1f)
			{
				UnityEngine.Object.Destroy(other.gameObject);
			}
		}
	}

	public virtual void Main()
	{
	}
}
