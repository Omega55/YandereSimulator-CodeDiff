using System;
using UnityEngine;

public class MGPMProjectileScript : MonoBehaviour
{
	public Transform Sprite;

	public float Speed;

	private void Update()
	{
		if (base.gameObject.layer == 8)
		{
			base.transform.Translate(Vector3.up * Time.deltaTime * this.Speed);
		}
		else
		{
			base.transform.Translate(Vector3.forward * Time.deltaTime * this.Speed);
		}
		if (base.transform.localPosition.y > 300f || base.transform.localPosition.y < -300f || base.transform.localPosition.x > 134f || base.transform.localPosition.x < -134f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
