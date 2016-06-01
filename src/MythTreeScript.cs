using System;
using UnityEngine;

[Serializable]
public class MythTreeScript : MonoBehaviour
{
	public UILabel EventSubtitle;

	public JukeboxScript Jukebox;

	public Transform Yandere;

	public bool Spoken;

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("Scheme_2_Stage") > 2)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	public virtual void Update()
	{
		if (!this.Spoken)
		{
			if (PlayerPrefs.GetInt("Scheme_2_Stage") == 2 && Vector3.Distance(this.Yandere.position, this.transform.position) < (float)5)
			{
				this.EventSubtitle.transform.localScale = new Vector3((float)1, (float)1, (float)1);
				this.EventSubtitle.text = "...that...ring...";
				this.Jukebox.Dip = 0.5f;
				this.Spoken = true;
				this.audio.Play();
			}
		}
		else if (!this.audio.isPlaying)
		{
			this.EventSubtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
			this.EventSubtitle.text = string.Empty;
			this.Jukebox.Dip = (float)1;
			UnityEngine.Object.Destroy(this);
		}
	}

	public virtual void Main()
	{
	}
}
