using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ClubAmbienceScript : MonoBehaviour
{
	public JukeboxScript Jukebox;

	public Transform Yandere;

	public bool CreateAmbience;

	public bool EffectJukebox;

	public float ClubDip;

	public float MaxVolume;

	public virtual void Update()
	{
		if (this.Yandere.position.y > this.transform.position.y - 0.1f && this.Yandere.position.y < this.transform.position.y + 0.1f)
		{
			if (Vector3.Distance(this.transform.position, this.Yandere.position) < (float)4)
			{
				this.CreateAmbience = true;
				this.EffectJukebox = true;
			}
			else
			{
				this.CreateAmbience = false;
			}
		}
		if (this.EffectJukebox)
		{
			if (this.CreateAmbience)
			{
				this.audio.volume = Mathf.MoveTowards(this.audio.volume, this.MaxVolume, Time.deltaTime * 0.1f);
				this.Jukebox.ClubDip = Mathf.MoveTowards(this.Jukebox.ClubDip, this.ClubDip, Time.deltaTime * 0.1f);
			}
			else
			{
				this.audio.volume = Mathf.MoveTowards(this.audio.volume, (float)0, Time.deltaTime * 0.1f);
				this.Jukebox.ClubDip = Mathf.MoveTowards(this.Jukebox.ClubDip, (float)0, Time.deltaTime * 0.1f);
				if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(this.Jukebox, "ClipDip"), 0))
				{
					this.EffectJukebox = false;
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
