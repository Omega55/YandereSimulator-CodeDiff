using System;
using UnityEngine;

public class MGPMProjectileScript : MonoBehaviour
{
	public Transform Sprite;

	public int Angle;

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
		if (this.Angle == 1)
		{
			base.transform.Translate(Vector3.right * Time.deltaTime * this.Speed * 0.2f);
		}
		else if (this.Angle == -1)
		{
			base.transform.Translate(Vector3.right * Time.deltaTime * this.Speed * -0.2f);
		}
		if (base.transform.localPosition.y > 300f || base.transform.localPosition.y < -300f || base.transform.localPosition.x > 134f || base.transform.localPosition.x < -134f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
