using System;
using UnityEngine;

[Serializable]
public class FalconPunchScript : MonoBehaviour
{
	public GameObject FalconExplosion;

	public Collider MyCollider;

	public float Strength;

	public bool Falcon;

	public float TimeLimit;

	public float Timer;

	public FalconPunchScript()
	{
		this.Strength = 100f;
		this.TimeLimit = 0.5f;
	}

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			this.MyCollider.enabled = false;
		}
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript studentScript = (StudentScript)other.gameObject.GetComponent(typeof(StudentScript));
			if (studentScript != null && studentScript.StudentID > 1)
			{
				UnityEngine.Object.Instantiate(this.FalconExplosion, this.transform.position, Quaternion.identity);
				studentScript.Dead = true;
				studentScript.BecomeRagdoll();
				studentScript.Ragdoll.AllRigidbodies[0].isKinematic = false;
				if (this.Falcon)
				{
					studentScript.Ragdoll.AllRigidbodies[0].AddForce((studentScript.Ragdoll.AllRigidbodies[0].transform.position - this.transform.position) * this.Strength);
				}
				else
				{
					studentScript.Ragdoll.AllRigidbodies[0].AddForce((studentScript.Ragdoll.AllRigidbodies[0].transform.root.position - this.transform.root.position) * this.Strength);
					studentScript.Ragdoll.AllRigidbodies[0].AddForce(Vector3.up * (float)10000);
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
