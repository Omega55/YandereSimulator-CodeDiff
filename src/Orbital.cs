using System;
using UnityEngine;

public class Orbital : MonoBehaviour
{
	public Transform target;

	private Vector3 lastPosition;

	private Vector3 direction;

	private float distance;

	private Vector3 movement;

	private Vector3 rotation;

	private void Awake()
	{
		this.direction = new Vector3(0f, 0f, (this.target.position - base.transform.position).magnitude);
		base.transform.SetParent(this.target);
		this.lastPosition = Input.mousePosition;
	}

	private void Update()
	{
		Vector3 vector = Input.mousePosition - this.lastPosition;
		if (Input.GetMouseButton(0))
		{
			this.movement += new Vector3(vector.x * 0.1f, vector.y * 0.05f, 0f);
		}
		this.movement.z = this.movement.z + Input.GetAxis("Mouse ScrollWheel") * -2.5f;
		this.rotation += this.movement;
		this.rotation.x = this.rotation.x % 360f;
		this.rotation.y = Mathf.Clamp(this.rotation.y, -80f, -10f);
		this.direction.z = Mathf.Clamp(this.movement.z + this.direction.z, 15f, 100f);
		base.transform.position = this.target.position + Quaternion.Euler(180f - this.rotation.y, this.rotation.x, 0f) * this.direction;
		base.transform.LookAt(this.target.position);
		this.lastPosition = Input.mousePosition;
		this.movement *= 0.9f;
	}
}
