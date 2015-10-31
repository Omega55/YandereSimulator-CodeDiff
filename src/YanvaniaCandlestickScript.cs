using System;
using UnityEngine;

[Serializable]
public class YanvaniaCandlestickScript : MonoBehaviour
{
	public GameObject DestroyedCandlestick;

	public bool Destroyed;

	public AudioClip Break;

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 19 && !this.Destroyed)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.DestroyedCandlestick, this.transform.position, Quaternion.identity);
			gameObject.transform.localScale = this.transform.localScale;
			this.Destroyed = true;
			this.PlayClip(this.Break, this.transform.position);
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
