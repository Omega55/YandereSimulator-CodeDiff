using System;
using UnityEngine;

[Serializable]
public class TempScript : MonoBehaviour
{
	public int RotationSpeed;

	public float Rotation;

	public bool Rotate;

	public TempScript()
	{
		this.RotationSpeed = 36;
	}

	public virtual void LateUpdate()
	{
		if (Input.GetKeyDown("space"))
		{
			this.Rotate = true;
		}
		if (this.Rotate)
		{
			this.Rotation = Mathf.MoveTowards(this.Rotation, (float)135, Time.deltaTime * (float)this.RotationSpeed);
			float rotation = this.Rotation;
			Vector3 localEulerAngles = this.transform.localEulerAngles;
			float num = localEulerAngles.y = rotation;
			Vector3 vector = this.transform.localEulerAngles = localEulerAngles;
		}
	}

	public virtual void Main()
	{
	}
}
