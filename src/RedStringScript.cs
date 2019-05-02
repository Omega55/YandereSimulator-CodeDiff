using System;
using UnityEngine;

public class RedStringScript : MonoBehaviour
{
	public Transform Target;

	private void LateUpdate()
	{
		base.transform.LookAt(this.Target.position);
		base.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(base.transform.position, this.Target.position));
	}
}
