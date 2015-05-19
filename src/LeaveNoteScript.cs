using System;
using UnityEngine;

[Serializable]
public class LeaveNoteScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public LetterWindowScript LetterWindow;

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

	public bool NoteLeft;

	public bool Success;

	public float MeetTime;

	public float Rotation;

	public float Timer;

	public int MeetID;

	public int Phase;

	public int ID;

	public LeaveNoteScript()
	{
		this.Phase = 1;
	}

	public virtual void Update()
	{
		if (this.Student == null)
		{
			this.Student = this.StudentManager.Students[this.ID];
		}
		else
		{
			if (this.Prompt.enabled)
			{
				if (Vector3.Distance(this.Student.transform.position, new Vector3(this.transform.position.x, this.Student.transform.position.y, this.transform.position.z)) < (float)1)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
			}
			else if (Vector3.Distance(this.Student.transform.position, new Vector3(this.transform.position.x, this.Student.transform.position.y, this.transform.position.z)) > (float)1)
			{
				this.Prompt.enabled = true;
			}
			if (this.Prompt.Circle[0].fillAmount <= (float)0)
			{
				this.Prompt.Circle[0].fillAmount = (float)1;
				this.Yandere.Blur.enabled = true;
				this.LetterWindow.Origin = this;
				this.LetterWindow.Show = true;
				this.Yandere.CanMove = false;
				this.Yandere.HUD.alpha = (float)0;
				this.PromptBar.Show = true;
				Time.timeScale = (float)0;
				this.PromptBar.Label[0].text = "Confirm";
				this.PromptBar.Label[1].text = "Cancel";
				this.PromptBar.Label[4].text = "Select";
				this.PromptBar.UpdateButtons();
			}
			if (this.NoteLeft && (this.Student.Phase == 1 || this.Student.Phase == 6) && this.Student.Routine && this.Student.DistanceToDestination < 0.1f)
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
					this.Student = null;
					this.NoteLeft = false;
					this.Phase++;
				}
				if (this.Student != null && this.Student.Character.animation["f02_keepNote_00"].time >= this.Student.Character.animation["f02_keepNote_00"].length)
				{
					this.DetermineSchedule();
					this.Student.Character.animation.CrossFade(this.Student.IdleAnim);
					this.Student.InEvent = false;
					this.Student = null;
					this.NoteLeft = false;
					this.Phase++;
				}
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)1 && this.Timer < (float)2)
				{
					this.Rotation -= Time.deltaTime * (float)90;
				}
				if (this.Timer > (float)4 && this.Timer < (float)5)
				{
					this.Rotation -= Time.deltaTime * (float)45;
				}
				if (this.Timer > (float)5 && this.NewNote == null)
				{
					this.NewNote = (GameObject)UnityEngine.Object.Instantiate(this.Note, this.transform.position, Quaternion.identity);
					this.NewNote.transform.parent = this.Student.LeftHand;
					this.NewNote.transform.localPosition = new Vector3(-0.03f, -0.05f, 0.075f);
					this.NewNote.transform.localEulerAngles = new Vector3((float)-30, (float)-90, (float)-90);
					this.NewNote.transform.localScale = new Vector3(0.1f, 0.2f, (float)1);
				}
				if (this.Timer > (float)10)
				{
					this.NewNote.transform.localScale = Vector3.MoveTowards(this.NewNote.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime);
				}
				if (!this.Success && this.Timer > (float)12 && this.NewBall == null)
				{
					this.NewBall = (GameObject)UnityEngine.Object.Instantiate(this.Ball, this.Student.Phone.transform.parent.transform.position, Quaternion.identity);
					this.NewBall.rigidbody.AddRelativeForce(Vector3.left * (float)100);
					this.NewBall.rigidbody.AddRelativeForce(Vector3.up * (float)100);
				}
				if (this.Phase == 1)
				{
					if (this.Timer > (float)2)
					{
						this.Yandere.Subtitle.UpdateLabel("Note Reaction", 1, (float)3);
						this.Phase++;
					}
				}
				else if (this.Phase == 2 && this.Timer > (float)11)
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
		}
		if (this.Phase == 4)
		{
			this.Rotation += Time.deltaTime * (float)135;
			if (this.Rotation > (float)0)
			{
				this.NoteLeft = false;
				this.Rotation = (float)0;
				this.Phase = 0;
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
