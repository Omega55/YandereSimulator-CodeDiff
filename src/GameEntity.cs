using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class GameEntity : MonoBehaviour
{
	protected Rigidbody rb;

	public Vector3 centerOfMassOffset = new Vector3(0f, 0f, 0f);

	private Vector3 S_centerOfMass;

	private Vector3 last_position;

	public Vector3 speed { get; private set; }

	public float absSpeed { get; private set; }

	public float sqrtSpeed { get; private set; }

	public float totalMass { get; private set; }

	protected virtual void Awake()
	{
		this.rb = base.GetComponent<Rigidbody>();
		this.S_centerOfMass = this.rb.centerOfMass;
		this.last_position = base.transform.position;
		this.totalMass = GameEntity.GetTotalMass(base.transform);
	}

	private static float GetTotalMass(Transform t)
	{
		float num = 0f;
		Rigidbody component = t.GetComponent<Rigidbody>();
		if (component != null)
		{
			num += component.mass;
		}
		for (int i = 0; i < t.childCount; i++)
		{
			num += GameEntity.GetTotalMass(t.GetChild(i));
		}
		return num;
	}

	protected virtual void FixedUpdate()
	{
		this.speed = (base.transform.position - this.last_position) / Time.deltaTime;
		this.last_position = base.transform.position;
		this.absSpeed = ((this.speed.x >= 0f) ? ((this.speed.x + this.speed.y >= 0f) ? ((this.speed.y + this.speed.z >= 0f) ? this.speed.z : (-this.speed.z)) : (-this.speed.y)) : (-this.speed.x));
		if (this.absSpeed < 0f)
		{
			this.absSpeed = -this.absSpeed;
		}
		this.sqrtSpeed = Mathf.Sqrt(this.absSpeed);
	}
}
