using System;
using UnityEngine;

public class FalconPunchScript : MonoBehaviour
{
	public GameObject FalconExplosion;

	public Rigidbody MyRigidbody;

	public Collider MyCollider;

	public float Strength = 100f;

	public float Speed = 100f;

	public bool Destructive;

	public bool IgnoreTime;

	public bool Shipgirl;

	public bool Bancho;

	public bool Falcon;

	public bool Mecha;

	public float TimeLimit = 0.5f;

	public float Timer;

	private void Start()
	{
		if (this.Mecha)
		{
			this.MyRigidbody.AddForce(base.transform.forward * this.Speed * 10f);
		}
	}

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
		if (this.Shipgirl)
		{
			this.MyRigidbody.AddForce(base.transform.forward * this.Speed);
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
					Vector3 a = rigidbody.transform.position - component.Yandere.transform.position;
					if (this.Falcon)
					{
						rigidbody.AddForce(a * this.Strength);
					}
					else if (this.Bancho)
					{
						rigidbody.AddForce(a.x * this.Strength, 5000f, a.z * this.Strength);
					}
					else
					{
						rigidbody.AddForce(a.x * this.Strength, 10000f, a.z * this.Strength);
					}
				}
			}
		}
		if (this.Destructive && other.gameObject.layer != 2 && other.gameObject.layer != 8 && other.gameObject.layer != 9 && other.gameObject.layer != 13 && other.gameObject.layer != 17)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.FalconExplosion, base.transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
			UnityEngine.Object.Destroy(other.gameObject);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
