﻿using System;
using UnityEngine;

public class NoteLockerScript : MonoBehaviour
{
	public FindStudentLockerScript FindStudentLocker;

	public StudentManagerScript StudentManager;

	public NoteWindowScript NoteWindow;

	public PromptBarScript PromptBar;

	public StudentScript Student;

	public YandereScript Yandere;

	public ListScript MeetSpots;

	public PromptScript Prompt;

	public GameObject NewBall;

	public GameObject NewNote;

	public GameObject Locker;

	public GameObject Ball;

	public GameObject Note;

	public AudioClip NoteSuccess;

	public AudioClip NoteFail;

	public AudioClip NoteFind;

	public bool CheckingNote;

	public bool CanLeaveNote = true;

	public bool SpawnedNote;

	public bool NoteLeft;

	public bool Success;

	public float MeetTime;

	public float Timer;

	public int LockerOwner;

	public int MeetID;

	public int Phase = 1;

	private void Start()
	{
		if (StudentGlobals.GetStudentDead(this.LockerOwner))
		{
			base.gameObject.SetActive(false);
		}
	}

	private void Update()
	{
		if (this.Student != null)
		{
			Vector3 b = new Vector3(base.transform.position.x, this.Student.transform.position.y, base.transform.position.z);
			if (this.Prompt.enabled)
			{
				if (Vector3.Distance(this.Student.transform.position, b) < 1f || this.Yandere.Armed)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
			}
			else if (this.CanLeaveNote && Vector3.Distance(this.Student.transform.position, b) > 1f && !this.Yandere.Armed)
			{
				this.Prompt.enabled = true;
			}
		}
		else
		{
			this.Student = this.StudentManager.Students[this.LockerOwner];
		}
		if (this.Prompt != null && this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.NoteWindow.NoteLocker = this;
			this.Yandere.Blur.enabled = true;
			this.NoteWindow.gameObject.SetActive(true);
			this.Yandere.CanMove = false;
			this.NoteWindow.Show = true;
			this.Yandere.HUD.alpha = 0f;
			this.PromptBar.Show = true;
			Time.timeScale = 0.0001f;
			this.PromptBar.Label[0].text = "Confirm";
			this.PromptBar.Label[1].text = "Cancel";
			this.PromptBar.Label[4].text = "Select";
			this.PromptBar.UpdateButtons();
		}
		if (this.NoteLeft)
		{
			if (this.Student != null && (this.Student.Phase == 2 || this.Student.Phase == 8) && this.Student.Routine && Vector3.Distance(base.transform.position, this.Student.transform.position) < 2f && !this.Student.InEvent)
			{
				this.Student.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				if (!this.Success)
				{
					this.Student.CharacterAnimation.CrossFade(this.Student.TossNoteAnim);
				}
				else
				{
					this.Student.CharacterAnimation.CrossFade(this.Student.KeepNoteAnim);
				}
				this.Student.Pathfinding.canSearch = false;
				this.Student.Pathfinding.canMove = false;
				this.Student.CheckingNote = true;
				this.Student.Routine = false;
				this.Student.InEvent = true;
				this.CheckingNote = true;
			}
			if (this.CheckingNote)
			{
				this.Timer += Time.deltaTime;
				this.Student.MoveTowardsTarget(this.Student.MyLocker.position);
				this.Student.transform.rotation = Quaternion.Slerp(this.Student.transform.rotation, this.Student.MyLocker.rotation, 10f * Time.deltaTime);
				if (this.Student != null)
				{
					if (this.Student.CharacterAnimation[this.Student.TossNoteAnim].time >= this.Student.CharacterAnimation[this.Student.TossNoteAnim].length)
					{
						this.Finish();
					}
					if (this.Student.CharacterAnimation[this.Student.KeepNoteAnim].time >= this.Student.CharacterAnimation[this.Student.KeepNoteAnim].length)
					{
						this.DetermineSchedule();
						this.Finish();
					}
				}
				if (this.Timer > 4.66666651f && !this.SpawnedNote)
				{
					this.NewNote = UnityEngine.Object.Instantiate<GameObject>(this.Note, base.transform.position, Quaternion.identity);
					this.NewNote.transform.parent = this.Student.LeftHand;
					this.NewNote.transform.localPosition = new Vector3(-0.06f, -0.01f, 0f);
					this.NewNote.transform.localEulerAngles = new Vector3(-75f, -90f, 180f);
					this.NewNote.transform.localScale = new Vector3(0.1f, 0.2f, 1f);
					this.SpawnedNote = true;
				}
				if (!this.Success)
				{
					if (this.Timer > 11.666667f && this.NewNote != null)
					{
						if (this.NewNote.transform.localScale.z > 0.1f)
						{
							this.NewNote.transform.localScale = Vector3.MoveTowards(this.NewNote.transform.localScale, Vector3.zero, Time.deltaTime);
						}
						else
						{
							UnityEngine.Object.Destroy(this.NewNote);
						}
					}
					if (this.Timer > 13.333333f && this.NewBall == null)
					{
						this.NewBall = UnityEngine.Object.Instantiate<GameObject>(this.Ball, this.Student.LeftHand.position, Quaternion.identity);
						Rigidbody component = this.NewBall.GetComponent<Rigidbody>();
						component.AddRelativeForce(Vector3.right * 100f);
						component.AddRelativeForce(Vector3.up * 100f);
						this.Phase++;
					}
				}
				else if (this.Timer > 12.833333f && this.NewNote != null)
				{
					if (this.NewNote.transform.localScale.z > 0.1f)
					{
						this.NewNote.transform.localScale = Vector3.MoveTowards(this.NewNote.transform.localScale, Vector3.zero, Time.deltaTime);
					}
					else
					{
						UnityEngine.Object.Destroy(this.NewNote);
					}
				}
				if (this.Phase == 1)
				{
					if (this.Timer > 2.33333325f)
					{
						this.Yandere.Subtitle.UpdateLabel(SubtitleType.NoteReaction, 1, 3f);
						this.Phase++;
					}
				}
				else if (this.Phase == 2)
				{
					if (!this.Success)
					{
						if (this.Timer > 9.666667f)
						{
							this.Yandere.Subtitle.UpdateLabel(SubtitleType.NoteReaction, 2, 3f);
							this.Phase++;
						}
					}
					else if (this.Timer > 10.166667f)
					{
						this.Yandere.Subtitle.UpdateLabel(SubtitleType.NoteReaction, 3, 3f);
						this.Phase++;
					}
				}
			}
		}
	}

	private void Finish()
	{
		if (this.Success && this.Student.Clock.HourTime > this.Student.MeetTime)
		{
			this.Student.CurrentDestination = this.Student.MeetSpot;
			this.Student.Pathfinding.target = this.Student.MeetSpot;
			this.Student.Pathfinding.canSearch = true;
			this.Student.Pathfinding.canMove = true;
			this.Student.Meeting = true;
			this.Student.MeetTime = 0f;
		}
		Animation component = this.Student.Character.GetComponent<Animation>();
		component.cullingType = AnimationCullingType.BasedOnRenderers;
		component.CrossFade(this.Student.IdleAnim);
		this.Student.DistanceToDestination = 100f;
		this.Student.CheckingNote = false;
		this.Student.InEvent = false;
		this.Student.Routine = true;
		this.CheckingNote = false;
		this.NoteLeft = false;
		this.Phase++;
	}

	private void DetermineSchedule()
	{
		this.Student.MeetSpot = this.MeetSpots.List[this.MeetID];
		this.Student.MeetTime = this.MeetTime;
	}
}
