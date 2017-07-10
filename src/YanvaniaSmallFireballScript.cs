using System;
using UnityEngine;

public class YanvaniaSmallFireballScript : MonoBehaviour
{
	public GameObject Explosion;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name.Equals("Heart"))
		{
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
		if (other.gameObject.name.Equals("YanmontChan"))
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(10);
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
