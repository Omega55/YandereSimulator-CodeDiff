using System;
using UnityEngine;

[Serializable]
public class YanvaniaCandlestickHeadScript : MonoBehaviour
{
	public GameObject Fire;

	public Vector3 Rotation;

	public float Value;

	public virtual void Start()
	{
		this.rigidbody.AddForce(this.transform.up * (float)100);
		this.rigidbody.AddForce(this.transform.right * (float)100);
		this.Value = UnityEngine.Random.Range(-1f, 1f);
	}

	public virtual void Update()
	{
		this.Rotation += new Vector3(this.Value, this.Value, this.Value);
		this.transform.localEulerAngles = this.Rotation;
		if (this.transform.localPosition.y < 0.23f)
		{
			UnityEngine.Object.Instantiate(this.Fire, this.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
