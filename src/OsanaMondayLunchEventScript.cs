using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class OsanaMondayLunchEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public ClockScript Clock;

	public SpyScript Spy;

	public StudentScript Senpai;

	public StudentScript Rival;

	public BentoScript[] Bento;

	public string[] SabotagedSpeechText;

	public string[] SpeechText;

	public float[] SabotagedSpeechTime;

	public float[] SpeechTime;

	public AudioClip[] SpeechClip;

	public Transform[] Location;

	public Transform Epicenter;

	public GameObject AlarmDisc;

	public GameObject VoiceClip;

	public Vector3 OriginalPosition;

	public bool Sabotaged;

	public float Distance;

	public float Scale;

	public float Timer;

	public float RotationX;

	public float RotationY;

	public float RotationZ;

	public int SpeechPhase;

	public int Phase;

	public int Frame;

	public OsanaMondayLunchEventScript()
	{
		this.SpeechPhase = 1;
	}

	public virtual void Start()
	{
		this.OriginalPosition = this.Epicenter.position;
		this.EventSubtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		if (PlayerPrefs.GetInt("Weekday") != 1)
		{
			this.enabled = false;
		}
	}

	public virtual void Update()
	{
		if (this.Phase == 0)
		{
			if (this.Frame > 0 && this.StudentManager.Students[1].active && this.Clock.Period == 3)
			{
				Debug.Log("Osana's lunchtime event began.");
				this.Bento[1].Prompt.Hide();
				this.Bento[1].Prompt.enabled = false;
				this.Bento[2].Prompt.Hide();
				this.Bento[2].Prompt.enabled = false;
				this.Bento[1].gameObject.active = true;
				this.Bento[2].gameObject.active = true;
				this.Bento[1].enabled = false;
				this.Bento[2].enabled = false;
				this.Senpai = this.StudentManager.Students[1];
				this.Rival = this.StudentManager.Students[33];
				this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				this.Senpai.CharacterAnimation.Play(this.Senpai.WalkAnim);
				this.Senpai.Pathfinding.target = this.Location[1];
				this.Senpai.CurrentDestination = this.Location[1];
				this.Senpai.Pathfinding.canSearch = true;
				this.Senpai.Pathfinding.canMove = true;
				this.Senpai.Routine = false;
				this.Senpai.InEvent = true;
				this.Senpai.Prompt.Hide();
				this.Senpai.Prompt.enabled = false;
				this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				this.Rival.CharacterAnimation.Play(this.Rival.WalkAnim);
				this.Rival.Pathfinding.target = this.Location[0];
				this.Rival.CurrentDestination = this.Location[0];
				this.Rival.Pathfinding.canSearch = true;
				this.Rival.Pathfinding.canMove = true;
				this.Rival.Routine = false;
				this.Rival.InEvent = true;
				this.Rival.Prompt.Hide();
				this.Rival.Prompt.enabled = false;
				this.Spy.Prompt.enabled = true;
				this.Phase++;
			}
			this.Frame++;
		}
		else if (this.Phase == 1)
		{
			if (this.Rival.DistanceToDestination < 0.5f)
			{
				this.EventSubtitle.text = this.SpeechText[this.SpeechPhase];
				this.SpeechPhase++;
				this.PlayClip(this.SpeechClip[0], this.Rival.transform.position + Vector3.up * 1.5f);
				this.Rival.CharacterAnimation.CrossFade("f02_pondering_00");
				this.Epicenter.position = this.Rival.transform.position;
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			this.Rival.MoveTowardsTarget(this.Rival.CurrentDestination.position);
			this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Rival.CurrentDestination.rotation, (float)10 * Time.deltaTime);
			if (this.Rival.CharacterAnimation["f02_pondering_00"].time >= this.Rival.CharacterAnimation["f02_pondering_00"].length)
			{
				this.Epicenter.position = this.OriginalPosition;
				this.EventSubtitle.text = string.Empty;
				this.Rival.CharacterAnimation.Play(this.Rival.WalkAnim);
				this.Rival.Pathfinding.target = this.Location[2];
				this.Rival.CurrentDestination = this.Location[2];
				this.Rival.Pathfinding.canSearch = true;
				this.Rival.Pathfinding.canMove = true;
				this.Bento[1].gameObject.active = false;
				this.Bento[2].gameObject.active = false;
				this.Phase++;
			}
		}
		else if (this.Phase == 3)
		{
			if (this.Senpai.DistanceToDestination < 0.5f && this.Rival.DistanceToDestination < 0.5f)
			{
				this.PlayClip(this.SpeechClip[1], this.Epicenter.transform.position + Vector3.up * 1.5f);
				this.Senpai.CharacterAnimation.CrossFade("Monday_2A");
				this.Rival.CharacterAnimation.CrossFade("f02_Monday_2A");
				int num = 15;
				Vector3 localEulerAngles = this.Rival.Bento.transform.localEulerAngles;
				float num2 = localEulerAngles.x = (float)num;
				Vector3 vector = this.Rival.Bento.transform.localEulerAngles = localEulerAngles;
				float x = -0.02f;
				Vector3 localPosition = this.Rival.Bento.transform.localPosition;
				float num3 = localPosition.x = x;
				Vector3 vector2 = this.Rival.Bento.transform.localPosition = localPosition;
				this.Rival.Bento.active = true;
				this.Senpai.Pathfinding.canSearch = false;
				this.Senpai.Pathfinding.canMove = false;
				this.Rival.Pathfinding.canSearch = false;
				this.Rival.Pathfinding.canMove = false;
				this.Phase++;
			}
			else
			{
				if (this.Senpai.DistanceToDestination < 0.5f)
				{
					this.Senpai.CharacterAnimation.CrossFade("thinking_00");
					this.Senpai.MoveTowardsTarget(this.Senpai.CurrentDestination.position);
					this.Senpai.transform.rotation = Quaternion.Slerp(this.Senpai.transform.rotation, this.Senpai.CurrentDestination.rotation, (float)10 * Time.deltaTime);
					this.Senpai.Pathfinding.canSearch = false;
					this.Senpai.Pathfinding.canMove = false;
				}
				if (this.Rival.DistanceToDestination < 0.5f)
				{
					this.Rival.CharacterAnimation.CrossFade("f02_pondering_00");
					this.Rival.MoveTowardsTarget(this.Rival.CurrentDestination.position);
					this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Rival.CurrentDestination.rotation, (float)10 * Time.deltaTime);
					this.Rival.Pathfinding.canSearch = false;
					this.Rival.Pathfinding.canMove = false;
				}
			}
		}
		else if (this.Phase == 4)
		{
			this.Timer += Time.deltaTime;
			this.Senpai.MoveTowardsTarget(this.Senpai.CurrentDestination.position);
			this.Senpai.transform.rotation = Quaternion.Slerp(this.Senpai.transform.rotation, this.Senpai.CurrentDestination.rotation, (float)10 * Time.deltaTime);
			this.Rival.MoveTowardsTarget(this.Rival.CurrentDestination.position);
			this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Rival.CurrentDestination.rotation, (float)10 * Time.deltaTime);
			if (this.Timer > 21.5f)
			{
				this.Senpai.Bento.transform.localPosition = new Vector3(-0.01652f, -0.02516f, -0.08239f);
				this.Senpai.Bento.transform.localEulerAngles = new Vector3((float)-35, (float)116, (float)165);
				this.RotationX = (float)-35;
				this.RotationY = (float)115;
				this.RotationZ = (float)165;
				this.Senpai.Bento.active = true;
				this.Rival.Bento.active = false;
				this.Phase++;
			}
		}
		else if (this.Phase == 5)
		{
			this.Timer += Time.deltaTime;
			this.RotationX = Mathf.Lerp(this.RotationX, (float)6, Time.deltaTime);
			this.RotationY = Mathf.Lerp(this.RotationY, (float)153, Time.deltaTime);
			this.RotationZ = Mathf.Lerp(this.RotationZ, 102.5f, Time.deltaTime);
			this.Senpai.Bento.transform.localPosition = Vector3.Lerp(this.Senpai.Bento.transform.localPosition, new Vector3(-0.045f, -0.08f, -0.025f), Time.deltaTime);
			this.Senpai.Bento.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
			if (this.Timer > 29.833334f)
			{
				this.Senpai.Lid.transform.parent = this.Senpai.RightHand;
				this.Senpai.Lid.transform.localPosition = new Vector3(-0.025f, -0.025f, -0.015f);
				this.Senpai.Lid.transform.localEulerAngles = new Vector3(41.5f, (float)-60, (float)-180);
			}
			if (this.Timer > (float)30 && this.Bento[1].Poison > 0)
			{
				this.Senpai.CharacterAnimation.CrossFade("Monday_2B");
				this.Rival.CharacterAnimation.CrossFade("f02_Monday_2B");
				this.Sabotaged = true;
				this.SpeechPhase = 0;
			}
			if (this.Timer > 30.4333324f)
			{
				this.Senpai.Lid.transform.parent = null;
				this.Senpai.Lid.transform.position = new Vector3(-0.31f, 12.461f, -29.27f);
				this.Senpai.Lid.transform.eulerAngles = new Vector3(2.5f, (float)0, (float)0);
			}
			if (this.Timer > (float)31)
			{
				this.Senpai.Chopsticks[0].active = true;
				this.Senpai.Chopsticks[1].active = true;
				this.Phase++;
			}
		}
		else if (this.Phase == 6)
		{
			this.Timer += Time.deltaTime;
			if (!this.Sabotaged)
			{
				if (this.Timer > 37.15f)
				{
					this.PlayClip(this.SpeechClip[2], this.Epicenter.transform.position + Vector3.up * 1.5f);
					this.Phase++;
				}
			}
			else if (this.Timer > (float)41)
			{
				this.PlayClip(this.SpeechClip[3], this.Epicenter.transform.position + Vector3.up * 1.5f);
				this.Phase++;
			}
		}
		else if (this.Phase == 7)
		{
			this.Timer += Time.deltaTime;
			if (!this.Sabotaged)
			{
				if (this.Senpai.CharacterAnimation["Monday_2A"].time > this.Senpai.CharacterAnimation["Monday_2A"].length)
				{
					this.EndEvent();
				}
			}
			else
			{
				if (this.Timer > 44.5f && this.Senpai.Bento.transform.parent != null)
				{
					this.Senpai.Bento.transform.parent = null;
					this.Senpai.Bento.transform.position = new Vector3(-0.9813f, 12.461f, -29.2675f);
					this.Senpai.Bento.transform.eulerAngles = new Vector3((float)-2, (float)180, (float)0);
					this.Senpai.Chopsticks[0].active = false;
					this.Senpai.Chopsticks[1].active = false;
				}
				if (this.Senpai.InEvent && this.Senpai.CharacterAnimation["Monday_2B"].time > this.Senpai.CharacterAnimation["Monday_2B"].length)
				{
					this.Senpai.WalkAnim = "stomachPainWalk_00";
					this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
					this.Senpai.Pathfinding.target = this.StudentManager.MaleVomitSpot;
					this.Senpai.CurrentDestination = this.StudentManager.MaleVomitSpot;
					this.Senpai.CharacterAnimation.CrossFade(this.Senpai.WalkAnim);
					this.Senpai.Pathfinding.canSearch = true;
					this.Senpai.Pathfinding.canMove = true;
					this.Senpai.Pathfinding.speed = (float)2;
					this.Senpai.Distracted = true;
					this.Senpai.Vomiting = true;
					this.Senpai.InEvent = false;
					this.Senpai.Routine = false;
					this.Senpai.Private = true;
				}
				if (this.Rival.CharacterAnimation["f02_Monday_2B"].time > this.Rival.CharacterAnimation["f02_Monday_2B"].length)
				{
					this.EndEvent();
				}
			}
		}
		if (this.Phase > 3)
		{
			if (!this.Sabotaged)
			{
				if (this.SpeechPhase < Extensions.get_length(this.SpeechTime) && this.Timer > this.SpeechTime[this.SpeechPhase])
				{
					this.EventSubtitle.text = this.SpeechText[this.SpeechPhase];
					this.SpeechPhase++;
				}
			}
			else if (this.SpeechPhase < Extensions.get_length(this.SabotagedSpeechTime) && this.Timer > (float)41 + this.SabotagedSpeechTime[this.SpeechPhase])
			{
				this.EventSubtitle.text = this.SabotagedSpeechText[this.SpeechPhase];
				this.SpeechPhase++;
			}
		}
		if (this.Phase > 0)
		{
			if (this.Senpai.Alarmed || this.Rival.Alarmed)
			{
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.AlarmDisc, this.Yandere.transform.position + Vector3.up, Quaternion.identity);
				((AlarmDiscScript)gameObject.GetComponent(typeof(AlarmDiscScript))).NoScream = true;
				this.EndEvent();
			}
			if (this.VoiceClip != null)
			{
				this.VoiceClip.audio.pitch = Time.timeScale;
			}
			this.Distance = Vector3.Distance(this.Yandere.transform.position, this.Epicenter.position);
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
					if (this.Phase > 3)
					{
						if (this.Distance < (float)5)
						{
							this.Yandere.Eavesdropping = true;
						}
						else
						{
							this.Yandere.Eavesdropping = false;
						}
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
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		if (this.Senpai.InEvent)
		{
			if (!this.Senpai.Alarmed)
			{
				this.Senpai.Pathfinding.canSearch = true;
				this.Senpai.Pathfinding.canMove = true;
				this.Senpai.Routine = true;
			}
			this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			this.Senpai.InEvent = false;
			this.Senpai.Private = false;
		}
		if (!this.Rival.Alarmed)
		{
			this.Rival.Pathfinding.canSearch = true;
			this.Rival.Pathfinding.canMove = true;
			this.Rival.Routine = true;
		}
		this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		this.Rival.Prompt.enabled = true;
		this.Rival.InEvent = false;
		this.Rival.Private = false;
		if (!this.StudentManager.Stop)
		{
			this.StudentManager.UpdateStudents();
		}
		this.Spy.Prompt.Hide();
		this.Spy.Prompt.enabled = false;
		if (this.Spy.Phase > 0)
		{
			this.Spy.End();
		}
		this.Yandere.Eavesdropping = false;
		this.EventSubtitle.text = string.Empty;
		this.enabled = false;
	}

	public virtual void Main()
	{
	}
}
