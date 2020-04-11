using System;
using UnityEngine;

public class YanvaniaJarScript : MonoBehaviour
{
	public GameObject Explosion;

	public bool Destroyed;

	public AudioClip Break;

	public GameObject Shard;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 19 && !this.Destroyed)
		{
			Object.Instantiate<GameObject>(this.Explosion, base.transform.position + Vector3.up * 0.5f, Quaternion.identity);
			this.Destroyed = true;
			AudioClipPlayer.Play2D(this.Break, base.transform.position);
			for (int i = 1; i < 11; i++)
			{
				Object.Instantiate<GameObject>(this.Shard, base.transform.position + Vector3.up * Random.Range(0f, 1f) + Vector3.right * Random.Range(-0.5f, 0.5f), Quaternion.identity);
			}
			Object.Destroy(base.gameObject);
		}
	}
}
