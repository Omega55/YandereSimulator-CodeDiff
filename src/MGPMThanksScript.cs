using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MGPMThanksScript : MonoBehaviour
{
	public AudioClip ThanksMusic;

	public AudioSource Jukebox;

	public Renderer Black;

	public int Phase = 1;

	private void Start()
	{
		this.Black.material.color = new Color(0f, 0f, 0f, 1f);
	}

	private void Update()
	{
		if (this.Phase == 1)
		{
			this.Black.material.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Black.material.color.a, 0f, Time.deltaTime));
			if (this.Black.material.color.a == 0f)
			{
				this.Jukebox.Play();
				this.Phase++;
				return;
			}
		}
		else if (this.Phase == 2)
		{
			if (!this.Jukebox.isPlaying)
			{
				this.Jukebox.clip = this.ThanksMusic;
				this.Jukebox.loop = true;
				this.Jukebox.Play();
				this.Phase++;
				return;
			}
		}
		else if (this.Phase == 3)
		{
			if (Input.anyKeyDown)
			{
				this.Phase++;
				return;
			}
		}
		else
		{
			this.Black.material.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Black.material.color.a, 1f, Time.deltaTime));
			this.Jukebox.volume = 1f - this.Black.material.color.a;
			if (this.Black.material.color.a == 1f)
			{
				HomeGlobals.MiyukiDefeated = true;
				SceneManager.LoadScene("HomeScene");
			}
		}
	}
}
