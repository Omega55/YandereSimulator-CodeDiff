using System;
using UnityEngine;

public class OsanaClubEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public ClockScript Clock;

	public StudentScript[] EventStudent;

	public Transform[] EventLocation;

	public AudioClip[] EventClip;

	public string[] EventSpeech;

	public string[] EventAnim;

	public int[] EventSpeaker;

	public GameObject VoiceClip;

	public bool EventOn;

	public bool Spoken;

	public int EventPhase;

	public float Timer;

	public float Scale;

	public int[] StudentID;

	public DayOfWeek EventDay;

	private void Start()
	{
		if (DateGlobals.Weekday != this.EventDay)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (!this.EventOn)
		{
			for (int i = 1; i < 3; i++)
			{
				if (this.EventStudent[i] == null)
				{
					this.EventStudent[i] = this.StudentManager.Students[this.StudentID[i]];
				}
				else if (!this.EventStudent[i].Alive || this.EventStudent[i].Slave)
				{
					base.enabled = false;
				}
			}
			if (this.EventStudent[1] != null && this.EventStudent[2] != null && this.EventStudent[1].Pathfinding.canMove && this.EventStudent[2].Pathfinding.canMove)
			{
				this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].WalkAnim);
				this.EventStudent[1].CurrentDestination = this.EventLocation[1];
				this.EventStudent[1].Pathfinding.target = this.EventLocation[1];
				this.EventStudent[1].InEvent = true;
				this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].WalkAnim);
				this.EventStudent[2].CurrentDestination = this.EventLocation[2];
				this.EventStudent[2].Pathfinding.target = this.EventLocation[2];
				this.EventStudent[2].InEvent = true;
				this.EventOn = true;
			}
		}
		else
		{
			Vector3 b = (this.EventStudent[1].transform.position - this.EventStudent[2].transform.position) * 0.5f + this.EventStudent[2].transform.position;
			float num = Vector3.Distance(this.Yandere.transform.position, b);
			if (this.Clock.HourTime > 13.5f || this.EventStudent[1].WitnessedCorpse || this.EventStudent[2].WitnessedCorpse || this.EventStudent[1].Alarmed || this.EventStudent[2].Alarmed || this.EventStudent[1].Dying || this.EventStudent[2].Dying)
			{
				this.EndEvent();
			}
			else
			{
				for (int j = 1; j < 3; j++)
				{
					if (!this.EventStudent[j].Pathfinding.canMove && !this.EventStudent[j].Private)
					{
						this.EventStudent[j].Character.GetComponent<Animation>().CrossFade(this.EventStudent[j].IdleAnim);
						this.EventStudent[j].Private = true;
						this.StudentManager.UpdateStudents();
					}
				}
				if (!this.EventStudent[1].Pathfinding.canMove && !this.EventStudent[2].Pathfinding.canMove)
				{
					if (!this.Spoken)
					{
						this.EventStudent[this.EventSpeaker[1]].CharacterAnimation.CrossFade(this.EventStudent[1].IdleAnim);
						this.EventStudent[this.EventSpeaker[2]].CharacterAnimation.CrossFade(this.EventStudent[2].IdleAnim);
						this.EventStudent[this.EventSpeaker[this.EventPhase]].PickRandomAnim();
						this.EventStudent[this.EventSpeaker[this.EventPhase]].CharacterAnimation.CrossFade(this.EventStudent[this.EventSpeaker[this.EventPhase]].RandomAnim);
						AudioClipPlayer.Play(this.EventClip[this.EventPhase], this.EventStudent[this.EventSpeaker[this.EventPhase]].transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
						this.Spoken = true;
					}
					else
					{
						int num2 = this.EventSpeaker[this.EventPhase];
						if (this.EventStudent[num2].CharacterAnimation[this.EventStudent[num2].RandomAnim].time >= this.EventStudent[num2].CharacterAnimation[this.EventStudent[num2].RandomAnim].length)
						{
							this.EventStudent[num2].PickRandomAnim();
							this.EventStudent[num2].CharacterAnimation.CrossFade(this.EventStudent[num2].RandomAnim);
						}
						this.Timer += Time.deltaTime;
						if (this.Yandere.transform.position.y > this.EventStudent[1].transform.position.y - 1f && this.Yandere.transform.position.y < this.EventStudent[1].transform.position.y + 1f)
						{
							if (this.VoiceClip != null)
							{
								this.VoiceClip.GetComponent<AudioSource>().volume = 1f;
							}
							if (num < 10f)
							{
								if (this.Timer > this.EventClip[this.EventPhase].length)
								{
									this.EventSubtitle.text = string.Empty;
								}
								else
								{
									this.EventSubtitle.text = this.EventSpeech[this.EventPhase];
								}
								this.Scale = Mathf.Abs((num - 10f) * 0.2f);
								if (this.Scale < 0f)
								{
									this.Scale = 0f;
								}
								if (this.Scale > 1f)
								{
									this.Scale = 1f;
								}
								this.EventSubtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
							}
							else
							{
								this.EventSubtitle.transform.localScale = Vector3.zero;
								this.EventSubtitle.text = string.Empty;
							}
						}
						else if (this.VoiceClip != null)
						{
							this.VoiceClip.GetComponent<AudioSource>().volume = 0f;
						}
						if (this.Timer > this.EventClip[this.EventPhase].length + 0.5f)
						{
							this.Spoken = false;
							this.EventPhase++;
							this.Timer = 0f;
							if (this.EventPhase == this.EventSpeech.Length)
							{
								this.EndEvent();
							}
							else if (this.EventPhase > 6)
							{
								this.EventStudent[1].CurrentDestination = this.EventLocation[this.EventPhase];
								this.EventStudent[1].Pathfinding.target = this.EventLocation[this.EventPhase];
								this.EventStudent[2].CurrentDestination = this.EventStudent[1].transform;
								this.EventStudent[2].Pathfinding.target = this.EventStudent[1].transform;
							}
						}
					}
				}
				else
				{
					Debug.Log("One or both characters have not yet reached their destination.");
					if (!this.EventStudent[1].Pathfinding.canMove)
					{
						this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].IdleAnim);
					}
					else
					{
						this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].WalkAnim);
					}
					if (!this.EventStudent[2].Pathfinding.canMove)
					{
						this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].IdleAnim);
						if (this.EventPhase == 1)
						{
							this.SettleFriend();
						}
					}
					else
					{
						this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].WalkAnim);
					}
				}
			}
		}
	}

	private void SettleFriend()
	{
		this.EventStudent[2].MoveTowardsTarget(this.EventStudent[2].Pathfinding.target.position);
	}

	public void EndEvent()
	{
		Debug.Log("Ending Osana's club event.");
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		for (int i = 1; i < 3; i++)
		{
			this.EventStudent[i].CurrentDestination = this.EventStudent[i].Destinations[this.EventStudent[i].Phase];
			this.EventStudent[i].Pathfinding.target = this.EventStudent[i].Destinations[this.EventStudent[i].Phase];
			this.EventStudent[i].InEvent = false;
			this.EventStudent[i].Private = false;
		}
		if (!this.StudentManager.Stop)
		{
			this.StudentManager.UpdateStudents();
		}
		this.EventSubtitle.text = string.Empty;
		base.enabled = false;
	}
}
