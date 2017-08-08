using System;
using UnityEngine;

public class TornadoScript : MonoBehaviour
{
	public GameObject FemaleBloodyScream;

	public GameObject MaleBloodyScream;

	public GameObject Scream;

	public Collider MyCollider;

	public float Strength = 10000f;

	public float Timer;

	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
			this.MyCollider.enabled = true;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null && component.StudentID > 1)
			{
				this.Scream = UnityEngine.Object.Instantiate<GameObject>((!component.Male) ? this.FemaleBloodyScream : this.MaleBloodyScream, component.transform.position + Vector3.up, Quaternion.identity);
				this.Scream.transform.parent = component.HipCollider.transform;
				this.Scream.transform.localPosition = Vector3.zero;
				component.DeathType = DeathType.EasterEgg;
				component.BecomeRagdoll();
				Rigidbody rigidbody = component.Ragdoll.AllRigidbodies[0];
				rigidbody.isKinematic = false;
				rigidbody.AddForce(Vector3.up * this.Strength);
			}
		}
	}
}
