using System;
using UnityEngine;

[Serializable]
public class ArcScript : MonoBehaviour
{
	public GameObject ArcTrail;

	public float Timer;

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > (float)1)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.ArcTrail, this.transform.position, this.transform.rotation);
			gameObject.rigidbody.AddRelativeForce(Vector3.forward * (float)250);
			this.Timer = (float)0;
		}
	}

	public virtual void Main()
	{
	}
}
