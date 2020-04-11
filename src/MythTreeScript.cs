using System;
using UnityEngine;

public class MythTreeScript : MonoBehaviour
{
	public UILabel EventSubtitle;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public bool Spoken;

	public AudioSource MyAudio;

	private void Start()
	{
		if (SchemeGlobals.GetSchemeStage(2) > 2)
		{
			Object.Destroy(this);
		}
	}

	private void Update()
	{
		if (!this.Spoken)
		{
			if (this.Yandere.Inventory.Ring && Vector3.Distance(this.Yandere.transform.position, base.transform.position) < 5f)
			{
				this.EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
				this.EventSubtitle.text = "...that...ring...";
				this.Jukebox.Dip = 0.5f;
				this.Spoken = true;
				this.MyAudio.Play();
				return;
			}
		}
		else if (!this.MyAudio.isPlaying)
		{
			this.EventSubtitle.transform.localScale = Vector3.zero;
			this.EventSubtitle.text = string.Empty;
			this.Jukebox.Dip = 1f;
			Object.Destroy(this);
		}
	}
}
