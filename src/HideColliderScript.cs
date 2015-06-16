using System;
using UnityEngine;

[Serializable]
public class HideColliderScript : MonoBehaviour
{
	public RagdollScript Corpse;

	public Collider MyCollider;

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 11 && ((StudentScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript))).Dead)
		{
			this.Corpse = (RagdollScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(RagdollScript));
			if (!this.Corpse.Hidden)
			{
				this.Corpse.HideCollider = this.MyCollider;
				this.Corpse.Police.HiddenCorpses = this.Corpse.Police.HiddenCorpses + 1;
				this.Corpse.Hidden = true;
			}
		}
	}

	public virtual void Main()
	{
	}
}
