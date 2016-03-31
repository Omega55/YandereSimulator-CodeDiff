using System;
using UnityEngine;

[Serializable]
public class AntiCheatScript : MonoBehaviour
{
	public GameObject Jukebox;

	public bool Check;

	public virtual void Update()
	{
		if (this.Check && !this.audio.isPlaying)
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YandereChan")
		{
			this.Jukebox.active = false;
			this.Check = true;
			this.audio.Play();
		}
	}

	public virtual void Main()
	{
	}
}
