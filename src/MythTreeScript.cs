using System;
using UnityEngine;

public class MythTreeScript : MonoBehaviour
{
	public UILabel EventSubtitle;

	public JukeboxScript Jukebox;

	public Transform Yandere;

	public bool Spoken;

	private void Start()
	{
		if (PlayerPrefs.GetInt("Scheme_2_Stage") > 2)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	private void Update()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		if (!this.Spoken)
		{
			if (PlayerPrefs.GetInt("Scheme_2_Stage") == 2 && Vector3.Distance(this.Yandere.position, base.transform.position) < 5f)
			{
				this.EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
				this.EventSubtitle.text = "...that...ring...";
				this.Jukebox.Dip = 0.5f;
				this.Spoken = true;
				component.Play();
			}
		}
		else if (!component.isPlaying)
		{
			this.EventSubtitle.transform.localScale = Vector3.zero;
			this.EventSubtitle.text = string.Empty;
			this.Jukebox.Dip = 1f;
			UnityEngine.Object.Destroy(this);
		}
	}
}
