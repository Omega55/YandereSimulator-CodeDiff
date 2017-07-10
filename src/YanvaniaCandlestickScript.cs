using System;
using UnityEngine;

public class YanvaniaCandlestickScript : MonoBehaviour
{
	public GameObject DestroyedCandlestick;

	public bool Destroyed;

	public AudioClip Break;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 19 && !this.Destroyed)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.DestroyedCandlestick, base.transform.position, Quaternion.identity);
			gameObject.transform.localScale = base.transform.localScale;
			this.Destroyed = true;
			this.PlayClip(this.Break, base.transform.position);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void PlayClip(AudioClip clip, Vector3 pos)
	{
		GameObject gameObject = new GameObject("TempAudio");
		gameObject.transform.position = pos;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
	}
}
