using System;
using UnityEngine;

public class ShadowScript : MonoBehaviour
{
	public Transform Foot;

	private void Update()
	{
		Vector3 position = base.transform.position;
		Vector3 position2 = this.Foot.position;
		position.x = position2.x;
		position.z = position2.z;
		base.transform.position = position;
	}
}
