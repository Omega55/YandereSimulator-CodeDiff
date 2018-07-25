using System;
using UnityEngine;

public class FollowYandereScript : MonoBehaviour
{
	public Transform Yandere;

	private void Update()
	{
		base.transform.position = new Vector3(this.Yandere.position.x, base.transform.position.y, this.Yandere.position.z);
	}
}
