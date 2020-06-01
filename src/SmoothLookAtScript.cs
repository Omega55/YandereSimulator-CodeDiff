using System;
using UnityEngine;

public class SmoothLookAtScript : MonoBehaviour
{
	public Transform Target;

	public float Speed;

	private void LateUpdate()
	{
		Quaternion b = Quaternion.LookRotation(this.Target.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.Speed);
	}
}
