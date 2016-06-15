using System;
using UnityEngine;

[Serializable]
public class ArcTrailScript : MonoBehaviour
{
	public TrailRenderer Trail;

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			this.Trail.material.SetColor("_TintColor", new Color((float)1, (float)0, (float)0, (float)1));
		}
	}

	public virtual void Main()
	{
	}
}
