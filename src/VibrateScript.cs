using System;
using UnityEngine;

public class VibrateScript : MonoBehaviour
{
	public Vector3 Origin;

	private void Start()
	{
		this.Origin = base.transform.localPosition;
	}

	private void Update()
	{
		base.transform.localPosition = new Vector3(this.Origin.x + Random.Range(-5f, 5f), this.Origin.y + Random.Range(-5f, 5f), base.transform.localPosition.z);
	}
}
