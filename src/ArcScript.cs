using System;
using UnityEngine;

public class ArcScript : MonoBehaviour
{
	private static readonly Vector3 NEW_ARC_RELATIVE_FORCE = Vector3.forward * 250f;

	public GameObject ArcTrail;

	public float Timer;

	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 1f)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.ArcTrail, base.transform.position, base.transform.rotation);
			gameObject.GetComponent<Rigidbody>().AddRelativeForce(ArcScript.NEW_ARC_RELATIVE_FORCE);
			this.Timer = 0f;
		}
	}
}
