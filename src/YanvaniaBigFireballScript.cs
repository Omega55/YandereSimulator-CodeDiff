using System;
using UnityEngine;

[Serializable]
public class YanvaniaBigFireballScript : MonoBehaviour
{
	public GameObject Explosion;

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			((YanvaniaYanmontScript)other.gameObject.GetComponent(typeof(YanvaniaYanmontScript))).TakeDamage(15);
			UnityEngine.Object.Instantiate(this.Explosion, this.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
