using System;
using UnityEngine;

public class MatchScript : MonoBehaviour
{
	public float Timer;

	public Collider MyCollider;

	private void Update()
	{
		if (base.GetComponent<Rigidbody>().useGravity)
		{
			base.transform.Rotate(Vector3.right * (Time.deltaTime * 360f));
			if (this.Timer > 0f && this.MyCollider.isTrigger)
			{
				this.MyCollider.isTrigger = false;
			}
			this.Timer += Time.deltaTime;
			if (this.Timer > 5f)
			{
				base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.y, base.transform.localScale.z - Time.deltaTime);
				if (base.transform.localScale.z < 0f)
				{
					Object.Destroy(base.gameObject);
				}
			}
		}
	}
}
