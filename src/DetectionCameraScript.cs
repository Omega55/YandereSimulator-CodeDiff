using System;
using UnityEngine;

[Serializable]
public class DetectionCameraScript : MonoBehaviour
{
	public Transform YandereChan;

	public virtual void Update()
	{
		this.transform.position = this.YandereChan.transform.position + Vector3.up * (float)100;
		int num = 90;
		Vector3 eulerAngles = this.transform.eulerAngles;
		float num2 = eulerAngles.x = (float)num;
		Vector3 vector = this.transform.eulerAngles = eulerAngles;
	}

	public virtual void Main()
	{
	}
}
