using System;
using UnityEngine;

[Serializable]
public class YanvaniaJarScript : MonoBehaviour
{
	public GameObject Explosion;

	public bool Destroyed;

	public AudioClip Break;

	public GameObject Shard;

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 19 && !this.Destroyed)
		{
			UnityEngine.Object.Instantiate(this.Explosion, this.transform.position + Vector3.up * 0.5f, Quaternion.identity);
			this.Destroyed = true;
			this.PlayClip(this.Break, this.transform.position);
			for (int i = 1; i < 11; i++)
			{
				UnityEngine.Object.Instantiate(this.Shard, this.transform.position + Vector3.up * UnityEngine.Random.Range((float)0, 1f) + Vector3.right * UnityEngine.Random.Range(-0.5f, 0.5f), Quaternion.identity);
			}
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void PlayClip(AudioClip clip, Vector3 pos)
	{
		GameObject gameObject = new GameObject("TempAudio");
		gameObject.transform.position = pos;
		AudioSource audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
	}

	public virtual void Main()
	{
	}
}
