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
			UnityEngine.Object.Instantiate<GameObject>(this.DestroyedCandlestick, base.transform.position, Quaternion.identity).transform.localScale = base.transform.localScale;
			this.Destroyed = true;
			AudioClipPlayer.Play2D(this.Break, base.transform.position);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
