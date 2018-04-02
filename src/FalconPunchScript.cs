using System;
using UnityEngine;

public class FalconPunchScript : MonoBehaviour
{
	public GameObject FalconExplosion;

	public Collider MyCollider;

	public float Strength = 100f;

	public bool IgnoreTime;

	public bool Falcon;

	public float TimeLimit = 0.5f;

	public float Timer;

	private void Update()
	{
		if (!this.IgnoreTime)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > this.TimeLimit)
			{
				this.MyCollider.enabled = false;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("A punch collided with something.");
		if (other.gameObject.layer == 9)
		{
			Debug.Log("A punch collided with something on the Characters layer.");
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				Debug.Log("A punch collided with a student.");
				if (component.StudentID > 1)
				{
					Debug.Log("A punch collided with a student and killed them.");
					UnityEngine.Object.Instantiate<GameObject>(this.FalconExplosion, component.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
					component.DeathType = DeathType.EasterEgg;
					component.BecomeRagdoll();
					Rigidbody rigidbody = component.Ragdoll.AllRigidbodies[0];
					rigidbody.isKinematic = false;
					if (this.Falcon)
					{
						rigidbody.AddForce((rigidbody.transform.position - base.transform.position) * this.Strength);
					}
					else
					{
						rigidbody.AddForce((rigidbody.transform.root.position - base.transform.root.position) * this.Strength);
						rigidbody.AddForce(Vector3.up * 10000f);
					}
				}
			}
		}
	}
}
