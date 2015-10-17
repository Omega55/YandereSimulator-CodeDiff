using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class BrokenScript : MonoBehaviour
{
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

	public int ID;

	public BrokenScript()
	{
		this.ID = 1;
	}

	public virtual void Start()
	{
		this.PermanentAngleR = this.TwintailR.eulerAngles;
		this.PermanentAngleL = this.TwintailL.eulerAngles;
		this.Subtitle = (UILabel)GameObject.Find("EventSubtitle").GetComponent(typeof(UILabel));
		this.Yandere = GameObject.Find("YandereChan");
	}

	public virtual void Update()
	{
		if (!this.Done)
		{
			if (!this.Hunting)
			{
				this.Timer += Time.deltaTime;
				if (this.VoiceClip == null)
				{
					this.Subtitle.text = string.Empty;
				}
				if (this.Timer > (float)5)
				{
					this.Timer = (float)0;
					this.Subtitle.text = this.MutterTexts[this.ID];
					this.PlayClip(this.Mutters[this.ID], this.transform.position);
					this.ID++;
					if (this.ID == Extensions.get_length(this.Mutters))
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
				this.PlayClip(this.DoIt, this.transform.position);
				this.Began = true;
			}
			else if (this.VoiceClip == null)
			{
				this.Subtitle.text = "...kill...kill...kill...";
				this.PlayClip(this.KillKillKill, this.transform.position);
			}
		}
		float num = Vector3.Distance(this.Yandere.transform.position, this.transform.root.position);
		if (num < (float)5)
		{
			float num2 = Mathf.Abs((num - (float)5) * 0.2f);
			if (num2 < (float)0)
			{
				num2 = (float)0;
			}
			if (num2 > (float)1)
			{
				num2 = (float)1;
			}
			this.Subtitle.transform.localScale = new Vector3(num2, num2, num2);
		}
		else
		{
			this.Subtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		}
		float x = this.PermanentAngleR.x;
		Vector3 eulerAngles = this.TwintailR.eulerAngles;
		float num3 = eulerAngles.x = x;
		Vector3 vector = this.TwintailR.eulerAngles = eulerAngles;
		float x2 = this.PermanentAngleL.x;
		Vector3 eulerAngles2 = this.TwintailL.eulerAngles;
		float num4 = eulerAngles2.x = x2;
		Vector3 vector2 = this.TwintailL.eulerAngles = eulerAngles2;
		float z = this.PermanentAngleR.z;
		Vector3 eulerAngles3 = this.TwintailR.eulerAngles;
		float num5 = eulerAngles3.z = z;
		Vector3 vector3 = this.TwintailR.eulerAngles = eulerAngles3;
		float z2 = this.PermanentAngleL.z;
		Vector3 eulerAngles4 = this.TwintailL.eulerAngles;
		float num6 = eulerAngles4.z = z2;
		Vector3 vector4 = this.TwintailL.eulerAngles = eulerAngles4;
	}

	public virtual void PlayClip(AudioClip clip, Vector3 pos)
	{
		GameObject gameObject = new GameObject("TempAudio");
		gameObject.transform.position = pos;
		gameObject.transform.parent = this.transform;
		AudioSource audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = (float)1;
		audioSource.maxDistance = (float)5;
		this.VoiceClip = gameObject;
		if (this.Yandere.transform.position.y < gameObject.transform.position.y - (float)2)
		{
			audioSource.volume = (float)0;
		}
		else
		{
			audioSource.volume = (float)1;
		}
	}

	public virtual void Main()
	{
	}
}
