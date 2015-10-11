using System;
using UnityEngine;

[Serializable]
public class CirnoIceAttackScript : MonoBehaviour
{
	public GameObject IceExplosion;

	public virtual void Start()
	{
		Physics.IgnoreLayerCollision(18, 13, true);
		Physics.IgnoreLayerCollision(18, 18, true);
	}

	public virtual void OnCollisionEnter(Collision collision)
	{
		UnityEngine.Object.Instantiate(this.IceExplosion, this.transform.position, Quaternion.identity);
		if (collision.gameObject.layer == 9)
		{
			StudentScript studentScript = (StudentScript)collision.gameObject.GetComponent(typeof(StudentScript));
			if (studentScript != null)
			{
				studentScript.SpawnAlarmDisc();
				studentScript.BecomeRagdoll();
			}
		}
		UnityEngine.Object.Destroy(this.gameObject);
	}

	public virtual void Main()
	{
	}
}
