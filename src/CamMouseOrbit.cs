using System;
using UnityEngine;

[Serializable]
public class CamMouseOrbit : MonoBehaviour
{
	public bool CanZoon;

	public Transform target;

	public float distance;

	public int xSpeed;

	public float ySpeed;

	public float distSpeed;

	public float yMinLimit;

	public float yMaxLimit;

	public float distMinLimit;

	public float distMaxLimit;

	public float orbitDamping;

	public float distDamping;

	private float x;

	private float y;

	private float dist;

	public CamMouseOrbit()
	{
		this.distance = 2.5f;
		this.xSpeed = 5;
		this.ySpeed = 2.5f;
		this.distSpeed = 10f;
		this.yMinLimit = -20f;
		this.yMaxLimit = 80f;
		this.distMinLimit = 0.5f;
		this.distMaxLimit = 50f;
		this.orbitDamping = 4f;
		this.distDamping = 4f;
		this.dist = this.distance;
	}

	public virtual void Start()
	{
		Vector3 eulerAngles = this.transform.eulerAngles;
		this.x = eulerAngles.y;
		this.y = eulerAngles.x;
		if (this.rigidbody)
		{
			this.rigidbody.freezeRotation = true;
		}
	}

	public virtual void LateUpdate()
	{
		if (this.target)
		{
			this.x += Input.GetAxis("Mouse X") * (float)this.xSpeed;
			this.y -= Input.GetAxis("Mouse Y") * this.ySpeed;
			if (this.CanZoon)
			{
				this.distance -= Input.GetAxis("Mouse ScrollWheel") * this.distSpeed;
			}
			this.y = this.ClampAngle(this.y, this.yMinLimit, this.yMaxLimit);
			this.distance = Mathf.Clamp(this.distance, this.distMinLimit, this.distMaxLimit);
			this.dist = Mathf.Lerp(this.dist, this.distance, this.distDamping * Time.deltaTime);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(this.y, this.x, (float)0), Time.deltaTime * this.orbitDamping);
			this.transform.position = this.transform.rotation * new Vector3((float)0, (float)0, -this.dist) + this.target.position;
			if (Input.GetKeyDown(KeyCode.O) && !this.CanZoon)
			{
				this.CanZoon = true;
			}
			else if (Input.GetKeyDown(KeyCode.O) && this.CanZoon)
			{
				this.CanZoon = false;
			}
		}
	}

	public virtual float ClampAngle(float a, float min, float max)
	{
		while (max < min)
		{
			max += 360f;
		}
		while (a > max)
		{
			a -= 360f;
		}
		while (a < min)
		{
			a += 360f;
		}
		return (a <= max) ? a : ((a - (max + min) * 0.5f >= 180f) ? min : max);
	}

	public virtual void Main()
	{
	}
}
