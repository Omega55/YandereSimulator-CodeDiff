using System;
using UnityEngine;

[Serializable]
public class LookAtSCP : MonoBehaviour
{
	public Transform SCP;

	public virtual void Start()
	{
		if (this.SCP == null)
		{
			this.SCP = GameObject.Find("SCPTarget").transform;
		}
		this.transform.LookAt(this.SCP);
	}

	public virtual void LateUpdate()
	{
		this.transform.LookAt(this.SCP);
	}

	public virtual void Main()
	{
	}
}
