using System;
using UnityEngine;

[Serializable]
public class VibrateScript : MonoBehaviour
{
	public Vector3 Origin;

	public virtual void Start()
	{
		this.Origin = this.transform.localPosition;
	}

	public virtual void Update()
	{
		float x = this.Origin.x + UnityEngine.Random.Range(-5f, 5f);
		Vector3 localPosition = this.transform.localPosition;
		float num = localPosition.x = x;
		Vector3 vector = this.transform.localPosition = localPosition;
		float y = this.Origin.y + UnityEngine.Random.Range(-5f, 5f);
		Vector3 localPosition2 = this.transform.localPosition;
		float num2 = localPosition2.y = y;
		Vector3 vector2 = this.transform.localPosition = localPosition2;
	}

	public virtual void Main()
	{
	}
}
