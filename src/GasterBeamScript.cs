using System;
using UnityEngine;

[Serializable]
public class GasterBeamScript : MonoBehaviour
{
	public float Strength;

	public GasterBeamScript()
	{
		this.Strength = 1000f;
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript studentScript = (StudentScript)other.gameObject.GetComponent(typeof(StudentScript));
			if (studentScript != null)
			{
				studentScript.Dead = true;
				studentScript.BecomeRagdoll();
				studentScript.Ragdoll.AllRigidbodies[0].isKinematic = false;
				studentScript.Ragdoll.AllRigidbodies[0].AddForce((studentScript.Ragdoll.AllRigidbodies[0].transform.root.position - this.transform.root.position) * this.Strength);
				studentScript.Ragdoll.AllRigidbodies[0].AddForce(Vector3.up * (float)1000);
			}
		}
	}

	public virtual void Main()
	{
	}
}
