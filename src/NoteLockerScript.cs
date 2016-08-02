using System;
using UnityEngine;

[Serializable]
public class NoteLockerScript : MonoBehaviour
{
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

	public bool CanLeaveNote;

	public bool NoteLeft;

	public bool Success;

	public float MeetTime;

	public float Timer;

	public int LockerOwner;

	public int MeetID;

	public int Phase;

	public NoteLockerScript()
	{
		this.CanLeaveNote = true;
		this.Phase = 1;
	}

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("Student_" + this.LockerOwner + "_Dead") == 1)
		{
			this.active = false;
		}
	}

	public virtual void Update()
	{
		if (this.Student != null)
		{
			if (this.Prompt.enabled)
			{
				if (Vector3.Distance(this.Student.transform.position, new Vector3(this.transform.position.x, this.Student.transform.position.y, this.transform.position.z)) < (float)1 || this.Yandere.Armed)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
			}
			else if (this.CanLeaveNote && Vector3.Distance(this.Student.transform.position, new Vector3(this.transform.position.x, this.Student.transform.position.y, this.transform.position.z)) > (float)1 && !this.Yandere.Armed)
			{
				this.Prompt.enabled = true;
			}
		}
		else
		{
			this.Student = this.StudentManager.Students[this.LockerOwner];
		}
		if (this.Prompt != null && this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			this.NoteWindow.NoteLocker = this;
			this.Yandere.Blur.enabled = true;
			this.Yandere.CanMove = false;
			this.NoteWindow.Show = true;
			this.Yandere.HUD.alpha = (float)0;
			this.PromptBar.Show = true;
			Time.timeScale = (float)0;
			this.PromptBar.Label[0].text = "Confirm";
			this.PromptBar.Label[1].text = "Cancel";
			this.PromptBar.Label[4].text = "Select";
			this.PromptBar.UpdateButtons();
		}
		if (this.NoteLeft)
		{
			if (this.Student != null && (this.Student.Phase == 2 || this.Student.Phase == 7) && this.Student.Routine && Vector3.Distance(this.transform.position, this.Student.transform.position) < (float)2 && !this.Student.InEvent)
			{
				this.Student.Character.animation.cullingType = AnimationCullingType.AlwaysAnimate;
				if (!this.Success)
				{
					this.Student.Character.animation.CrossFade("f02_tossNote_00");
					this.Locker.animation.CrossFade("lockerTossNote");
				}
				else
				{
					this.Student.Character.animation.CrossFade("f02_keepNote_00");
					this.Locker.animation.CrossFade("lockerKeepNote");
				}
				this.Student.Pathfinding.canSearch = false;
				this.Student.Pathfinding.canMove = false;
				this.Student.InEvent = true;
				this.Student.Routine = false;
				this.CheckingNote = true;
			}
			if (this.CheckingNote)
			{
				this.Timer += Time.deltaTime;
				this.Student.MoveTowardsTarget(this.Student.MyLocker.position);
				this.Student.transform.rotation = Quaternion.Slerp(this.Student.transform.rotation, this.Student.MyLocker.rotation, (float)10 * Time.deltaTime);
				if (this.Student != null)
				{
					if (this.Student.Character.animation["f02_tossNote_00"].time >= this.Student.Character.animation["f02_tossNote_00"].length)
					{
						this.Finish();
					}
					if (this.Student.Character.animation["f02_keepNote_00"].time >= this.Student.Character.animation["f02_keepNote_00"].length)
					{
						this.DetermineSchedule();
						this.Finish();
					}
				}
				if (this.Timer > 4.66666651f && this.NewNote == null)
				{
					this.NewNote = (GameObject)UnityEngine.Object.Instantiate(this.Note, this.transform.position, Quaternion.identity);
					this.NewNote.transform.parent = this.Student.LeftHand;
					this.NewNote.transform.localPosition = new Vector3(-0.06f, -0.01f, (float)0);
					this.NewNote.transform.localEulerAngles = new Vector3((float)-75, (float)-90, (float)180);
					this.NewNote.transform.localScale = new Vector3(0.1f, 0.2f, (float)1);
				}
				if (!this.Success)
				{
					if (this.Timer > 11.666667f)
					{
						if (this.NewNote.transform.localScale.x > 0.1f)
						{
							this.NewNote.transform.localScale = Vector3.Lerp(this.NewNote.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime);
						}
						else
						{
							this.NewNote.transform.localScale = new Vector3((float)0, (float)0, (float)0);
						}
					}
					if (this.Timer > 13.333333f && this.NewBall == null)
					{
						this.NewBall = (GameObject)UnityEngine.Object.Instantiate(this.Ball, this.Student.LeftHand.position, Quaternion.identity);
						this.NewBall.rigidbody.AddRelativeForce(Vector3.left * (float)100);
						this.NewBall.rigidbody.AddRelativeForce(Vector3.up * (float)100);
						this.Phase++;
					}
				}
				else if (this.Timer > 12.833333f)
				{
					this.NewNote.transform.localScale = Vector3.Lerp(this.NewNote.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime);
				}
				if (this.Phase == 1)
				{
					if (this.Timer > 2.33333325f)
					{
						this.Yandere.Subtitle.UpdateLabel("Note Reaction", 1, (float)3);
						this.Phase++;
					}
				}
				else if (this.Phase == 2)
				{
					if (!this.Success)
					{
						if (this.Timer > 9.666667f)
						{
							this.Yandere.Subtitle.UpdateLabel("Note Reaction", 2, (float)3);
							this.Phase++;
						}
					}
					else if (this.Timer > 10.166667f)
					{
						this.Yandere.Subtitle.UpdateLabel("Note Reaction", 3, (float)3);
						this.Phase++;
					}
				}
			}
		}
	}

	public virtual void Finish()
	{
		if (this.Student.Clock.HourTime > this.Student.MeetTime)
		{
			this.Student.CurrentDestination = this.Student.MeetSpot;
			this.Student.Pathfinding.target = this.Student.MeetSpot;
			this.Student.Pathfinding.canSearch = true;
			this.Student.Pathfinding.canMove = true;
			this.Student.Meeting = true;
			this.Student.MeetTime = (float)0;
		}
		this.Student.Character.animation.cullingType = AnimationCullingType.BasedOnRenderers;
		this.Student.Character.animation.CrossFade(this.Student.IdleAnim);
		this.Student.DistanceToDestination = (float)100;
		this.Student.InEvent = false;
		this.Student.Routine = true;
		this.CheckingNote = false;
		this.NoteLeft = false;
		this.Phase++;
	}

	public virtual void DetermineSchedule()
	{
		this.Student.MeetSpot = this.MeetSpots.List[this.MeetID];
		this.Student.MeetTime = this.MeetTime;
	}

	public virtual void Main()
	{
	}
}
