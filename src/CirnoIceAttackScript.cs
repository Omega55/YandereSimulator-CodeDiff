﻿using System;
using UnityEngine;

public class CirnoIceAttackScript : MonoBehaviour
{
	public GameObject IceExplosion;

	private void Start()
	{
		Physics.IgnoreLayerCollision(18, 13, true);
		Physics.IgnoreLayerCollision(18, 18, true);
	}

	private void OnCollisionEnter(Collision collision)
	{
		UnityEngine.Object.Instantiate<GameObject>(this.IceExplosion, base.transform.position, Quaternion.identity);
		if (collision.gameObject.layer == 9)
		{
			StudentScript component = collision.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				component.SpawnAlarmDisc();
				component.BecomeRagdoll();
			}
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
