using System;
using UnityEngine;

public class SplashGenerator : MonoBehaviour
{
	public Vector3 offset;

	private OceanAdvanced ocean;

	private Vector3 last_position;

	private float speed;

	private void Awake()
	{
		this.ocean = UnityEngine.Object.FindObjectOfType<OceanAdvanced>();
		this.speed = 0f;
		this.last_position = base.transform.position;
		base.InvokeRepeating("CheckSplash", 0.1f, 0.2f);
	}

	private void CheckSplash()
	{
		this.speed = (base.transform.position - this.last_position).magnitude / 0.5f;
		if (this.speed < 3f)
		{
			return;
		}
		Vector3 vector = base.transform.position + base.transform.rotation * this.offset;
		float waterHeight = OceanAdvanced.GetWaterHeight(vector);
		if (vector.y < waterHeight && this.last_position.y > waterHeight && this.speed > 2f)
		{
			this.ocean.RegisterInteraction(vector, Mathf.Clamp01(this.speed / 15f) * 0.5f);
		}
		this.last_position = base.transform.position;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(base.transform.position + base.transform.rotation * this.offset, 1f);
	}
}
