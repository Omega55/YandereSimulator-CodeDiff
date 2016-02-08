using System;
using UnityEngine;

[Serializable]
public class CreditsLabelScript : MonoBehaviour
{
	public float RotationSpeed;

	public float MovementSpeed;

	public float Rotation;

	public virtual void Start()
	{
		this.Rotation = (float)-90;
		float rotation = this.Rotation;
		Vector3 localEulerAngles = this.transform.localEulerAngles;
		float num = localEulerAngles.y = rotation;
		Vector3 vector = this.transform.localEulerAngles = localEulerAngles;
	}

	public virtual void Update()
	{
		this.Rotation += Time.deltaTime * this.RotationSpeed;
		float rotation = this.Rotation;
		Vector3 localEulerAngles = this.transform.localEulerAngles;
		float num = localEulerAngles.y = rotation;
		Vector3 vector = this.transform.localEulerAngles = localEulerAngles;
		float y = this.transform.localPosition.y + Time.deltaTime * this.MovementSpeed;
		Vector3 localPosition = this.transform.localPosition;
		float num2 = localPosition.y = y;
		Vector3 vector2 = this.transform.localPosition = localPosition;
		if (this.Rotation > (float)90)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
