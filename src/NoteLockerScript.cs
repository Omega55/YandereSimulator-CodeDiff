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

	public GameObject Ball;

	public GameObject Note;

	public AudioClip NoteSuccess;

	public AudioClip NoteFail;

	public AudioClip NoteFind;

	public Transform Hinge;

	public bool CanLeaveNote;

	public bool NoteLeft;

	public bool Success;

	public float MeetTime;

	public float Rotation;

	public float Timer;

	public int MeetID;

	public int Phase;

	public int ID;

	public NoteLockerScript()
	{
		this.CanLeaveNote = true;
		this.Phase = 1;
	}

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("Student_" + (this.ID + 1) + "_Dead") == 1)
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
			this.Student = this.StudentManager.Students[this.ID];
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
		if (this.NoteLeft && this.Student != null && (this.Student.Phase == 1 || this.Student.Phase == 6) && this.Student.Routine && Vector3.Distance(this.transform.position, this.Student.transform.position) < (float)2 && this.Student.DistanceToDestination < 0.1f)
		{
			if (!this.Student.InEvent)
			{
				this.Student.Character.animation.CrossFade("f02_findNote_00");
				this.Student.InEvent = true;
			}
			if (this.Student.Character.animation["f02_findNote_00"].time >= this.Student.Character.animation["f02_findNote_00"].length)
			{
				if (!this.Success)
				{
					this.Student.Character.animation.CrossFade("f02_tossNote_00");
				}
				else
				{
					this.Student.Character.animation.CrossFade("f02_keepNote_00");
				}
			}
			if (this.Student.Character.animation["f02_tossNote_00"].time >= this.Student.Character.animation["f02_tossNote_00"].length)
			{
				this.Student.Character.animation.CrossFade(this.Student.IdleAnim);
				this.Student.InEvent = false;
				this.NoteLeft = false;
				this.Phase++;
			}
			if (this.Student != null && this.Student.Character.animation["f02_keepNote_00"].time >= this.Student.Character.animation["f02_keepNote_00"].length)
			{
				this.DetermineSchedule();
				this.Student.Character.animation.CrossFade(this.Student.IdleAnim);
				this.Student.InEvent = false;
				this.NoteLeft = false;
				this.Phase++;
			}
			this.Timer += Time.deltaTime;
			if (this.Timer > 0.75f && this.Timer < 1.75f)
			{
				this.Rotation -= Time.deltaTime * (float)80;
			}
			if (this.Timer > 10.5f && this.Timer < 11.5f)
			{
				this.Rotation += Time.deltaTime * (float)80;
			}
			if (this.Timer > 3.5f && this.NewNote == null)
			{
				this.NewNote = (GameObject)UnityEngine.Object.Instantiate(this.Note, this.transform.position, Quaternion.identity);
				this.NewNote.transform.parent = this.Student.LeftHand;
				this.NewNote.transform.localPosition = new Vector3(-0.065f, -0.005f, 0.055f);
				this.NewNote.transform.localEulerAngles = new Vector3((float)-75, (float)-135, (float)-105);
				this.NewNote.transform.localScale = new Vector3(0.1f, 0.2f, (float)1);
			}
			if (this.Timer > (float)10)
			{
				this.NewNote.transform.localScale = Vector3.MoveTowards(this.NewNote.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime);
			}
			if (!this.Success && this.Timer > 10.5f && this.NewBall == null)
			{
				this.NewBall = (GameObject)UnityEngine.Object.Instantiate(this.Ball, this.Student.Phone.transform.parent.transform.position, Quaternion.identity);
				this.NewBall.rigidbody.AddRelativeForce(Vector3.left * (float)100);
				this.NewBall.rigidbody.AddRelativeForce(Vector3.up * (float)100);
				this.Phase++;
			}
			if (this.Phase == 1)
			{
				if (this.Timer > (float)2)
				{
					this.Yandere.Subtitle.UpdateLabel("Note Reaction", 1, (float)3);
					this.Phase++;
				}
			}
			else if (this.Phase == 2 && this.Timer > (float)9)
			{
				if (!this.Success)
				{
					this.Yandere.Subtitle.UpdateLabel("Note Reaction", 2, (float)3);
				}
				else
				{
					this.Yandere.Subtitle.UpdateLabel("Note Reaction", 3, (float)3);
				}
				this.Phase++;
			}
		}
		if (this.Phase == 4)
		{
			this.Rotation += Time.deltaTime * (float)135;
			if (this.Rotation > (float)0)
			{
				this.Student.InEvent = false;
				this.NoteLeft = false;
				this.Rotation = (float)0;
				this.Phase = 0;
				this.Timer = (float)0;
			}
		}
		float rotation = this.Rotation;
		Vector3 localEulerAngles = this.Hinge.localEulerAngles;
		float num = localEulerAngles.y = rotation;
		Vector3 vector = this.Hinge.localEulerAngles = localEulerAngles;
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
