using System;
using UnityEngine;

[Serializable]
public class JukeboxScript : MonoBehaviour
{
	public AudioSource Piano;

	public AudioSource HipHop;

	public int Track;

	public virtual void Update()
	{
		if (Input.GetKeyDown("m"))
		{
			if (this.Piano.volume == (float)0 && this.HipHop.volume == (float)0)
			{
				this.Piano.Play();
				this.HipHop.Play();
			}
			this.Track++;
			if (this.Track > 2)
			{
				this.Track = 1;
			}
		}
		if (this.Track == 1)
		{
			this.Piano.volume = this.Piano.volume + Time.deltaTime;
			this.HipHop.volume = this.HipHop.volume - Time.deltaTime;
		}
		else if (this.Track == 2)
		{
			this.Piano.volume = this.Piano.volume - Time.deltaTime;
			this.HipHop.volume = this.HipHop.volume + Time.deltaTime;
		}
	}

	public virtual void Main()
	{
	}
}
