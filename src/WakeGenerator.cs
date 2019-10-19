using System;
using UnityEngine;

public class WakeGenerator : MonoBehaviour
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
	}

	private void Update()
	{
		this.speed = (base.transform.position - this.last_position).magnitude / Time.deltaTime;
		this.last_position = base.transform.position;
		if (Time.time % 0.2f < 0.01f)
		{
			Vector3 vector = base.transform.position + base.transform.rotation * this.offset;
			if (OceanAdvanced.GetWaterHeight(vector) > vector.y)
			{
				this.ocean.RegisterInteraction(vector, Mathf.Clamp01(this.speed / 15f) * 0.5f);
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(base.transform.position + base.transform.rotation * this.offset, 0.5f);
	}
}
