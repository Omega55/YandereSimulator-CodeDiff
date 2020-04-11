using System;
using UnityEngine;

public class YanvaniaCandlestickHeadScript : MonoBehaviour
{
	public GameObject Fire;

	public Vector3 Rotation;

	public float Value;

	private void Start()
	{
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.AddForce(base.transform.up * 100f);
		component.AddForce(base.transform.right * 100f);
		this.Value = Random.Range(-1f, 1f);
	}

	private void Update()
	{
		this.Rotation += new Vector3(this.Value, this.Value, this.Value);
		base.transform.localEulerAngles = this.Rotation;
		if (base.transform.localPosition.y < 0.23f)
		{
			Object.Instantiate<GameObject>(this.Fire, base.transform.position, Quaternion.identity);
			Object.Destroy(base.gameObject);
		}
	}
}
