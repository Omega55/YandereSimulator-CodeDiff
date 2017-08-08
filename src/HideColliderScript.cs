using System;
using UnityEngine;

public class HideColliderScript : MonoBehaviour
{
	public RagdollScript Corpse;

	public Collider MyCollider;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 11)
		{
			GameObject gameObject = other.gameObject.transform.root.gameObject;
			if (!gameObject.GetComponent<StudentScript>().Alive)
			{
				this.Corpse = gameObject.GetComponent<RagdollScript>();
				if (!this.Corpse.Hidden)
				{
					this.Corpse.HideCollider = this.MyCollider;
					this.Corpse.Police.HiddenCorpses++;
					this.Corpse.Hidden = true;
				}
			}
		}
	}
}
