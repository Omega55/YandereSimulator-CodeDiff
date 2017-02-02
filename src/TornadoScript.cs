using System;
using UnityEngine;

[Serializable]
public class TornadoScript : MonoBehaviour
{
	public GameObject FemaleBloodyScream;

	public GameObject MaleBloodyScream;

	public GameObject Scream;

	public Collider MyCollider;

	public float Strength;

	public float Timer;

	public TornadoScript()
	{
		this.Strength = 10000f;
	}

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.5f)
		{
			float y = this.transform.position.y + Time.deltaTime;
			Vector3 position = this.transform.position;
			float num = position.y = y;
			Vector3 vector = this.transform.position = position;
			this.MyCollider.enabled = true;
		}
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript studentScript = (StudentScript)other.gameObject.GetComponent(typeof(StudentScript));
			if (studentScript != null && studentScript.StudentID > 1)
			{
				if (!studentScript.Male)
				{
					this.Scream = (GameObject)UnityEngine.Object.Instantiate(this.FemaleBloodyScream, studentScript.transform.position + Vector3.up, Quaternion.identity);
				}
				else
				{
					this.Scream = (GameObject)UnityEngine.Object.Instantiate(this.MaleBloodyScream, studentScript.transform.position + Vector3.up, Quaternion.identity);
				}
				this.Scream.transform.parent = studentScript.HipCollider.transform;
				this.Scream.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
				studentScript.Dead = true;
				studentScript.BecomeRagdoll();
				studentScript.Ragdoll.AllRigidbodies[0].isKinematic = false;
				studentScript.Ragdoll.AllRigidbodies[0].AddForce(Vector3.up * this.Strength);
			}
		}
	}

	public virtual void Main()
	{
	}
}
