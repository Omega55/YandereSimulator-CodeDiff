using System;
using UnityEngine;

public class BrokenScript : MonoBehaviour
{
	public DynamicBone[] HairPhysics;

	public string[] MutterTexts;

	public AudioClip[] Mutters;

	public Vector3 PermanentAngleR;

	public Vector3 PermanentAngleL;

	public Transform TwintailR;

	public Transform TwintailL;

	public AudioClip KillKillKill;

	public AudioClip Stab;

	public AudioClip DoIt;

	public GameObject VoiceClip;

	public GameObject Yandere;

	public UILabel Subtitle;

	public bool Hunting;

	public bool Stabbed;

	public bool Began;

	public bool Done;

	public float SuicideTimer;

	public float Timer;

	public int ID = 1;

	private void Start()
	{
		this.HairPhysics[0].enabled = false;
		this.HairPhysics[1].enabled = false;
		this.PermanentAngleR = this.TwintailR.eulerAngles;
		this.PermanentAngleL = this.TwintailL.eulerAngles;
		this.Subtitle = GameObject.Find("EventSubtitle").GetComponent<UILabel>();
		this.Yandere = GameObject.Find("YandereChan");
	}

	private void Update()
	{
		if (!this.Done)
		{
			float num = Vector3.Distance(this.Yandere.transform.position, base.transform.root.position);
			if (num < 6f)
			{
				if (num < 5f)
				{
					if (!this.Hunting)
					{
						this.Timer += Time.deltaTime;
						if (this.VoiceClip == null)
						{
							this.Subtitle.text = string.Empty;
						}
						if (this.Timer > 5f)
						{
							this.Timer = 0f;
							this.Subtitle.text = this.MutterTexts[this.ID];
							AudioClipPlayer.PlayAttached(this.Mutters[this.ID], base.transform.position, base.transform, 1f, 5f, out this.VoiceClip, this.Yandere.transform.position.y);
							this.ID++;
							if (this.ID == this.Mutters.Length)
							{
								this.ID = 1;
							}
						}
					}
					else if (!this.Began)
					{
						if (this.VoiceClip != null)
						{
							UnityEngine.Object.Destroy(this.VoiceClip);
						}
						this.Subtitle.text = "Do it.";
						AudioClipPlayer.PlayAttached(this.DoIt, base.transform.position, base.transform, 1f, 5f, out this.VoiceClip, this.Yandere.transform.position.y);
						this.Began = true;
					}
					else if (this.VoiceClip == null)
					{
						this.Subtitle.text = "...kill...kill...kill...";
						AudioClipPlayer.PlayAttached(this.KillKillKill, base.transform.position, base.transform, 1f, 5f, out this.VoiceClip, this.Yandere.transform.position.y);
					}
					float num2 = Mathf.Abs((num - 5f) * 0.2f);
					num2 = ((num2 <= 1f) ? num2 : 1f);
					this.Subtitle.transform.localScale = new Vector3(num2, num2, num2);
				}
				else
				{
					this.Subtitle.transform.localScale = Vector3.zero;
				}
			}
		}
		Vector3 eulerAngles = this.TwintailR.eulerAngles;
		Vector3 eulerAngles2 = this.TwintailL.eulerAngles;
		eulerAngles.x = this.PermanentAngleR.x;
		eulerAngles.z = this.PermanentAngleR.z;
		eulerAngles2.x = this.PermanentAngleL.x;
		eulerAngles2.z = this.PermanentAngleL.z;
		this.TwintailR.eulerAngles = eulerAngles;
		this.TwintailL.eulerAngles = eulerAngles2;
	}
}
