using System;
using UnityEngine;

public class UpthrustScript : MonoBehaviour
{
	[SerializeField]
	private float amplitude = 0.1f;

	[SerializeField]
	private float frequency = 0.6f;

	[SerializeField]
	private Vector3 rotationAmplitude = new Vector3(4.45f, 4.45f, 4.45f);

	private Vector3 startPosition;

	private void Start()
	{
		this.startPosition = base.transform.localPosition;
	}

	private void Update()
	{
		float d = this.amplitude * Mathf.Sin(6.28318548f * this.frequency * Time.time);
		base.transform.localPosition = this.startPosition + this.evaluatePosition(Time.time);
		base.transform.Rotate(this.rotationAmplitude * d);
	}

	private Vector3 evaluatePosition(float time)
	{
		float y = this.amplitude * Mathf.Sin(6.28318548f * this.frequency * time);
		return new Vector3(0f, y, 0f);
	}
}
