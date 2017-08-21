using System;
using UnityEngine;

public class BatheEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public ClockScript Clock;

	public StudentScript EventStudent;

	public UILabel EventSubtitle;

	public AudioClip[] EventClip;

	public string[] EventSpeech;

	public string[] EventAnim;

	public GameObject RivalPhone;

	public GameObject VoiceClip;

	public bool EventActive;

	public bool EventOver;

	public float EventTime = 15.1f;

	public int EventPhase = 1;

	public int EventDay = 4;

	public Vector3 OriginalPosition;

	public float CurrentClipLength;

	public float Timer;

	private void Start()
	{
		this.RivalPhone.SetActive(false);
		if (Globals.Weekday != this.EventDay)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (!this.Clock.StopTime && !this.EventActive && this.Clock.HourTime > this.EventTime)
		{
			this.EventStudent = this.StudentManager.Students[7];
			if (this.EventStudent != null && !this.EventStudent.Distracted && !this.EventStudent.Talking && !this.EventStudent.Meeting && this.EventStudent.Indoors)
			{
				if (!this.EventStudent.WitnessedMurder)
				{
					this.OriginalPosition = this.EventStudent.Cosmetic.FemaleAccessories[3].transform.localPosition;
					this.EventStudent.CurrentDestination = this.StudentManager.StripSpot;
					this.EventStudent.Pathfinding.target = this.StudentManager.StripSpot;
					this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventStudent.WalkAnim);
					this.EventStudent.Pathfinding.canSearch = true;
					this.EventStudent.Pathfinding.canMove = true;
					this.EventStudent.Pathfinding.speed = 1f;
					this.EventStudent.DistanceToDestination = 100f;
					this.EventStudent.Obstacle.checkTime = 99f;
					this.EventStudent.InEvent = true;
					this.EventStudent.Private = true;
					this.EventStudent.Prompt.Hide();
					this.EventStudent.Hearts.Stop();
					this.EventActive = true;
					if (this.EventStudent.Following)
					{
						this.EventStudent.Pathfinding.canMove = true;
						this.EventStudent.Pathfinding.speed = 1f;
						this.EventStudent.Following = false;
						this.EventStudent.Routine = true;
						this.Yandere.Followers--;
						this.EventStudent.Subtitle.UpdateLabel("Stop Follow Apology", 0, 3f);
						this.EventStudent.Prompt.Label[0].text = "     Talk";
					}
				}
				else
				{
					base.enabled = false;
				}
			}
		}
		if (this.EventActive)
		{
			if (this.Clock.HourTime > this.EventTime + 1f || this.EventStudent.WitnessedMurder || this.EventStudent.Splashed || this.EventStudent.Alarmed || this.EventStudent.Dying || !this.EventStudent.Alive)
			{
				this.EndEvent();
			}
			else
			{
				if (this.EventStudent.DistanceToDestination < 0.5f)
				{
					if (this.EventPhase == 1)
					{
						this.EventStudent.Routine = false;
						this.EventStudent.BathePhase = 1;
						this.EventStudent.Wet = true;
						this.EventPhase++;
					}
					else if (this.EventPhase == 2)
					{
						if (this.EventStudent.BathePhase == 4)
						{
							this.RivalPhone.SetActive(true);
							this.EventPhase++;
						}
					}
					else if (this.EventPhase == 3 && !this.EventStudent.Wet)
					{
						if (!this.RivalPhone.activeInHierarchy)
						{
							this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventAnim[0]);
							this.EventStudent.Pathfinding.canSearch = false;
							this.EventStudent.Pathfinding.canMove = false;
							this.EventStudent.Routine = false;
							this.StudentManager.CommunalLocker.Open = true;
							this.EventSubtitle.text = this.EventSpeech[0];
							AudioClipPlayer.Play(this.EventClip[0], this.EventStudent.transform.position + Vector3.up, 5f, 10f, out this.VoiceClip, out this.CurrentClipLength);
							this.EventPhase++;
						}
						else
						{
							this.EndEvent();
						}
					}
				}
				if (this.EventPhase == 4)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > this.CurrentClipLength + 1f)
					{
						this.EventStudent.Routine = true;
						this.EndEvent();
					}
				}
				float num = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
				if (num < 11f)
				{
					if (num < 10f)
					{
						float num2 = Mathf.Abs((num - 10f) * 0.2f);
						if (num2 < 0f)
						{
							num2 = 0f;
						}
						if (num2 > 1f)
						{
							num2 = 1f;
						}
						this.EventSubtitle.transform.localScale = new Vector3(num2, num2, num2);
					}
					else
					{
						this.EventSubtitle.transform.localScale = Vector3.zero;
					}
				}
			}
		}
	}

	private void EndEvent()
	{
		if (!this.EventOver)
		{
			if (this.VoiceClip != null)
			{
				UnityEngine.Object.Destroy(this.VoiceClip);
			}
			this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
			this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
			this.EventStudent.Obstacle.checkTime = 1f;
			if (!this.EventStudent.Dying)
			{
				this.EventStudent.Prompt.enabled = true;
				this.EventStudent.Pathfinding.canSearch = true;
				this.EventStudent.Pathfinding.canMove = true;
				this.EventStudent.Pathfinding.speed = 1f;
				this.EventStudent.TargetDistance = 1f;
				this.EventStudent.Private = false;
			}
			this.EventStudent.InEvent = false;
			this.EventSubtitle.text = string.Empty;
			this.StudentManager.UpdateStudents();
		}
		this.EventActive = false;
		base.enabled = false;
	}
}
