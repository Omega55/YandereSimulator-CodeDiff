using System;
using UnityEngine;

public class YanvaniaJarShardScript : MonoBehaviour
{
	public float MyRotation;

	public float Rotation;

	private void Start()
	{
		this.Rotation = Random.Range(-360f, 360f);
		base.GetComponent<Rigidbody>().AddForce(Random.Range(-100f, 100f), Random.Range(0f, 100f), Random.Range(-100f, 100f));
	}

	private void Update()
	{
		this.MyRotation += this.Rotation;
		base.transform.eulerAngles = new Vector3(this.MyRotation, this.MyRotation, this.MyRotation);
		if (base.transform.position.y < 6.5f)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
