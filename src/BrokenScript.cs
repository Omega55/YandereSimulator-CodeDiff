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
						this.PlayClip(this.Mutters[this.ID], base.transform.position);
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
					this.PlayClip(this.DoIt, base.transform.position);
					this.Began = true;
				}
				else if (this.VoiceClip == null)
				{
					this.Subtitle.text = "...kill...kill...kill...";
					this.PlayClip(this.KillKillKill, base.transform.position);
				}
				float num2 = Mathf.Abs((num - 5f) * 0.2f);
				if (num2 < 0f)
				{
					num2 = 0f;
				}
				if (num2 > 1f)
				{
					num2 = 1f;
				}
				this.Subtitle.transform.localScale = new Vector3(num2, num2, num2);
			}
			else
			{
				this.Subtitle.transform.localScale = Vector3.zero;
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

	private void PlayClip(AudioClip clip, Vector3 pos)
	{
		GameObject gameObject = new GameObject("TempAudio");
		gameObject.transform.position = pos;
		gameObject.transform.parent = base.transform;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = 1f;
		audioSource.maxDistance = 5f;
		audioSource.spatialBlend = 1f;
		this.VoiceClip = gameObject;
		float y = this.Yandere.transform.position.y;
		float y2 = gameObject.transform.position.y;
		audioSource.volume = ((y >= y2 - 2f) ? 1f : 0f);
	}
}
