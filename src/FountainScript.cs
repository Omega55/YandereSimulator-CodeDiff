using System;
using UnityEngine;

[Serializable]
public class FountainScript : MonoBehaviour
{
	public ParticleSystem Splashes;

	public UILabel EventSubtitle;

	public Collider[] Colliders;

	public bool Drowning;

	public AudioSource SpraySFX;

	public AudioSource DropsSFX;

	public float StartTimer;

	public float Timer;

	public virtual void Start()
	{
		this.SpraySFX.volume = 0.1f;
		this.DropsSFX.volume = 0.1f;
	}

	public virtual void Update()
	{
		if (this.StartTimer < (float)1)
		{
			this.StartTimer += Time.deltaTime;
			if (this.StartTimer > (float)1)
			{
				this.SpraySFX.gameObject.active = true;
				this.DropsSFX.gameObject.active = true;
			}
		}
		if (this.Drowning)
		{
			if (this.Timer == (float)0 && this.EventSubtitle.transform.localScale.x < (float)1)
			{
				this.EventSubtitle.transform.localScale = new Vector3((float)1, (float)1, (float)1);
				this.EventSubtitle.text = "Hey, what are you -";
				this.audio.Play();
			}
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)3 && this.EventSubtitle.transform.localScale.x > (float)0)
			{
				this.EventSubtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
				this.EventSubtitle.text = string.Empty;
				this.Splashes.Play();
			}
			if (this.Timer > (float)9)
			{
				this.Drowning = false;
				this.Splashes.Stop();
				this.Timer = (float)0;
			}
		}
	}

	public virtual void Main()
	{
	}
}
