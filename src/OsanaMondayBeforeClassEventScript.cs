using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class OsanaMondayBeforeClassEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public ClockScript Clock;

	public StudentScript Rival;

	public Transform Destination;

	public AudioClip SpeechClip;

	public string[] SpeechText;

	public float[] SpeechTime;

	public GameObject AlarmDisc;

	public GameObject VoiceClip;

	public GameObject[] Bentos;

	public bool EventActive;

	public float Distance;

	public float Scale;

	public float Timer;

	public int SpeechPhase;

	public int Phase;

	public int Frame;

	public OsanaMondayBeforeClassEventScript()
	{
		this.SpeechPhase = 1;
	}

	public virtual void Start()
	{
		this.EventSubtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		this.Bentos[1].active = false;
		this.Bentos[2].active = false;
		if (PlayerPrefs.GetInt("Weekday") != 1)
		{
			this.enabled = false;
		}
	}

	public virtual void Update()
	{
		if (this.Phase == 0)
		{
			if (this.Frame > 0)
			{
				if (this.Clock.Period == 1)
				{
					if (this.StudentManager.Students[33] != null)
					{
						if (this.Rival == null)
						{
							this.Rival = this.StudentManager.Students[33];
						}
						else if (this.Rival.Indoors)
						{
							Debug.Log("Osana's before class event is beginning.");
							this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
							this.Rival.Pathfinding.target = this.Destination;
							this.Rival.CurrentDestination = this.Destination;
							this.Rival.Pathfinding.canSearch = true;
							this.Rival.Pathfinding.canMove = true;
							this.Rival.Routine = false;
							this.Rival.InEvent = true;
							this.Rival.Prompt.Hide();
							this.Rival.Prompt.enabled = false;
							this.Phase++;
						}
					}
					else
					{
						this.enabled = false;
					}
				}
				else
				{
					this.enabled = false;
				}
			}
			this.Frame++;
		}
		else if (this.Phase == 1)
		{
			if (this.Rival.DistanceToDestination < 0.5f)
			{
				this.PlayClip(this.SpeechClip, this.Rival.transform.position + Vector3.up * 1.5f);
				this.Rival.CharacterAnimation.CrossFade("f02_pondering_00");
				this.Rival.Pathfinding.canSearch = false;
				this.Rival.Pathfinding.canMove = false;
				this.Bentos[1].active = true;
				this.Bentos[2].active = true;
				this.Phase++;
			}
		}
		else
		{
			this.Rival.MoveTowardsTarget(this.Rival.CurrentDestination.position);
			this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Rival.CurrentDestination.rotation, (float)10 * Time.deltaTime);
			this.Timer += Time.deltaTime;
			if (this.VoiceClip != null)
			{
				this.VoiceClip.audio.pitch = Time.timeScale;
			}
			if (this.SpeechPhase < Extensions.get_length(this.SpeechTime))
			{
				if (this.Timer > this.SpeechTime[this.SpeechPhase])
				{
					this.EventSubtitle.text = this.SpeechText[this.SpeechPhase];
					this.SpeechPhase++;
				}
			}
			else if (this.Timer > this.Rival.CharacterAnimation["f02_pondering_00"].length)
			{
				this.EndEvent();
			}
			if (this.Rival.Alarmed)
			{
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.AlarmDisc, this.Yandere.transform.position + Vector3.up, Quaternion.identity);
				((AlarmDiscScript)gameObject.GetComponent(typeof(AlarmDiscScript))).NoScream = true;
				this.EndEvent();
			}
			this.Distance = Vector3.Distance(this.Yandere.transform.position, this.Rival.transform.position);
			if (this.enabled)
			{
				if (this.Distance - (float)4 < (float)15)
				{
					this.Scale = Mathf.Abs((float)1 - (this.Distance - (float)4) / (float)15);
					if (this.Scale < (float)0)
					{
						this.Scale = (float)0;
					}
					if (this.Scale > (float)1)
					{
						this.Scale = (float)1;
					}
					this.EventSubtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
					if (this.VoiceClip != null)
					{
						this.VoiceClip.audio.volume = this.Scale;
					}
				}
				else
				{
					this.EventSubtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
					if (this.VoiceClip != null)
					{
						this.VoiceClip.audio.volume = (float)0;
					}
				}
			}
		}
		if (this.Phase > 0 && this.Clock.Period > 1)
		{
			this.EndEvent();
		}
	}

	public virtual void PlayClip(AudioClip clip, Vector3 pos)
	{
		GameObject gameObject = new GameObject("TempAudio");
		gameObject.transform.position = pos;
		AudioSource audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = (float)5;
		audioSource.maxDistance = (float)10;
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

	public virtual void EndEvent()
	{
		Debug.Log("Osana's before class event ended.");
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		if (!this.Rival.Alarmed)
		{
			if (this.Rival.Phase == 1)
			{
				Debug.Log("Osana's phase was 1, so we're increasing her phase.");
				this.Rival.Phase = this.Rival.Phase + 1;
				this.Rival.CurrentDestination = this.Rival.Destinations[this.Rival.Phase];
				this.Rival.Pathfinding.target = this.Rival.Destinations[this.Rival.Phase];
			}
			this.Rival.Pathfinding.canSearch = true;
			this.Rival.Pathfinding.canMove = true;
			this.Rival.Routine = true;
		}
		this.Rival.Prompt.enabled = true;
		this.Rival.InEvent = false;
		this.Rival.Private = false;
		if (!this.StudentManager.Stop)
		{
			this.StudentManager.UpdateStudents();
		}
		this.EventSubtitle.text = string.Empty;
		this.enabled = false;
	}

	public virtual void Main()
	{
	}
}
