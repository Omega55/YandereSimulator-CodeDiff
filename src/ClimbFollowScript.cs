﻿using System;
using UnityEngine;

public class ClimbFollowScript : MonoBehaviour
{
	public Transform Yandere;

	private void Update()
	{
		base.transform.position = new Vector3(base.transform.position.x, this.Yandere.position.y, base.transform.position.z);
	}
}
