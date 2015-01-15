using System;
using UnityEngine;

[Serializable]
public class YouTubeScript : MonoBehaviour
{
	public float Timer;

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > (float)1)
		{
			this.audio.Play();
			UnityEngine.Object.Destroy(this);
		}
	}

	public virtual void Main()
	{
	}
}
