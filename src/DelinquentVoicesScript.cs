using System;
using UnityEngine;

public class DelinquentVoicesScript : MonoBehaviour
{
	public YandereScript Yandere;

	public RadioScript Radio;

	public SubtitleScript Subtitle;

	public float Timer;

	public int RandomID;

	public int LastID;

	private void Start()
	{
		this.Timer = 5f;
	}

	private void Update()
	{
		if (this.Radio.MyAudio.isPlaying && this.Yandere.CanMove && Vector3.Distance(this.Yandere.transform.position, base.transform.position) < 5f)
		{
			this.Timer = Mathf.MoveTowards(this.Timer, 0f, Time.deltaTime);
			if (this.Timer == 0f && ClubGlobals.Club != ClubType.Delinquent)
			{
				if (this.Yandere.Container == null)
				{
					while (this.RandomID == this.LastID)
					{
						this.RandomID = Random.Range(0, this.Subtitle.DelinquentAnnoyClips.Length);
					}
					this.LastID = this.RandomID;
					this.Subtitle.UpdateLabel(SubtitleType.DelinquentAnnoy, this.RandomID, 3f);
				}
				else
				{
					while (this.RandomID == this.LastID)
					{
						this.RandomID = Random.Range(0, this.Subtitle.DelinquentCaseClips.Length);
					}
					this.LastID = this.RandomID;
					this.Subtitle.UpdateLabel(SubtitleType.DelinquentCase, this.RandomID, 3f);
				}
				this.Timer = 5f;
			}
		}
	}
}
