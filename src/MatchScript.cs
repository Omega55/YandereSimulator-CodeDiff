using System;
using UnityEngine;

[Serializable]
public class MatchScript : MonoBehaviour
{
	public float Timer;

	public Collider MyCollider;

	public virtual void Update()
	{
		if (this.rigidbody.useGravity)
		{
			this.transform.Rotate(Vector3.right * Time.deltaTime * (float)360);
			if (this.Timer > (float)0 && this.MyCollider.isTrigger)
			{
				this.MyCollider.isTrigger = false;
			}
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)5)
			{
				float z = this.transform.localScale.z - Time.deltaTime;
				Vector3 localScale = this.transform.localScale;
				float num = localScale.z = z;
				Vector3 vector = this.transform.localScale = localScale;
				if (this.transform.localScale.z < (float)0)
				{
					UnityEngine.Object.Destroy(this.gameObject);
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
