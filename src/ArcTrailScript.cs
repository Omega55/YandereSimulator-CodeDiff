using System;
using UnityEngine;

public class ArcTrailScript : MonoBehaviour
{
	private static readonly Color TRAIL_TINT_COLOR = new Color(1f, 0f, 0f, 1f);

	public TrailRenderer Trail;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			this.Trail.material.SetColor("_TintColor", ArcTrailScript.TRAIL_TINT_COLOR);
		}
	}
}
