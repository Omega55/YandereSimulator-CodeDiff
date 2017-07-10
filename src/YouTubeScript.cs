using System;
using UnityEngine;

public class YouTubeScript : MonoBehaviour
{
	public float Timer;

	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 1f)
		{
			base.GetComponent<AudioSource>().Play();
			UnityEngine.Object.Destroy(this);
		}
	}
}
