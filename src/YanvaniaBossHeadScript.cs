using System;
using UnityEngine;

[Serializable]
public class YanvaniaBossHeadScript : MonoBehaviour
{
	public YanvaniaDraculaScript Dracula;

	public GameObject HitEffect;

	public float Timer;

	public virtual void Update()
	{
		this.Timer -= Time.deltaTime;
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (this.Timer <= (float)0 && this.Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate(this.HitEffect, this.transform.position, Quaternion.identity);
			this.Timer = (float)1;
			this.Dracula.TakeDamage();
		}
	}

	public virtual void Main()
	{
	}
}
