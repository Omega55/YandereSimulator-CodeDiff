using System;
using UnityEngine;

public class YanvaniaBossHeadScript : MonoBehaviour
{
	public YanvaniaDraculaScript Dracula;

	public GameObject HitEffect;

	public float Timer;

	private void Update()
	{
		this.Timer -= Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (this.Timer <= 0f && this.Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart")
		{
			Object.Instantiate<GameObject>(this.HitEffect, base.transform.position, Quaternion.identity);
			this.Timer = 1f;
			this.Dracula.TakeDamage();
		}
	}
}
