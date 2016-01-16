using System;
using UnityEngine;

[Serializable]
public class BoneScript : MonoBehaviour
{
	public float Height;

	public float Origin;

	public bool Drop;

	public virtual void Start()
	{
		float y = UnityEngine.Random.Range((float)0, 360f);
		Vector3 eulerAngles = this.transform.eulerAngles;
		float num = eulerAngles.y = y;
		Vector3 vector = this.transform.eulerAngles = eulerAngles;
		this.Origin = this.transform.position.y;
		this.audio.pitch = (float)NGUITools.RandomRange((int)0.9f, (int)1.1f);
	}

	public virtual void Update()
	{
		if (!this.Drop)
		{
			if (this.transform.position.y < this.Origin + (float)2 - 0.0001f)
			{
				float y = Mathf.Lerp(this.transform.position.y, this.Origin + (float)2, Time.deltaTime * (float)10);
				Vector3 position = this.transform.position;
				float num = position.y = y;
				Vector3 vector = this.transform.position = position;
			}
			else
			{
				this.Drop = true;
			}
		}
		else
		{
			this.Height -= Time.deltaTime;
			float y2 = this.transform.position.y + this.Height;
			Vector3 position2 = this.transform.position;
			float num2 = position2.y = y2;
			Vector3 vector2 = this.transform.position = position2;
			if (this.transform.position.y < this.Origin - 2.155f)
			{
				UnityEngine.Object.Destroy(this.gameObject);
			}
		}
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
				studentScript.Ragdoll.AllRigidbodies[0].AddForce(this.transform.up);
			}
		}
	}

	public virtual void Main()
	{
	}
}
