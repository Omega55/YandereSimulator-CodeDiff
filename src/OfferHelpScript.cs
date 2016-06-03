using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class OfferHelpScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public JukeboxScript Jukebox;

	public StudentScript Student;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public UILabel EventSubtitle;

	public AudioClip[] EventClip;

	public string[] EventSpeech;

	public string[] EventAnim;

	public int[] EventSpeaker;

	public bool Offering;

	public bool Spoken;

	public int EventPhase;

	public float Timer;

	public OfferHelpScript()
	{
		this.EventPhase = 1;
	}

	public virtual void Start()
	{
		this.Prompt.enabled = true;
	}

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Jukebox.Dip = 0.1f;
			this.Yandere.EmptyHands();
			this.Yandere.CanMove = false;
			this.Student = this.StudentManager.Students[7];
			this.Student.Prompt.Label[0].text = "     Talk";
			this.Student.Pushable = false;
			this.Student.Meeting = false;
			this.Student.Routine = false;
			this.Student.MeetTimer = (float)0;
			this.Offering = true;
		}
		if (this.Offering)
		{
			this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.transform.rotation, Time.deltaTime * (float)10);
			this.Yandere.MoveTowardsTarget(this.transform.position + Vector3.down);
			Quaternion to = Quaternion.LookRotation(this.Yandere.transform.position - this.Student.transform.position);
			this.Student.transform.rotation = Quaternion.Slerp(this.Student.transform.rotation, to, Time.deltaTime * (float)10);
			if (!this.Spoken)
			{
				if (this.EventSpeaker[this.EventPhase] == 1)
				{
					this.Yandere.Character.animation.CrossFade(this.EventAnim[this.EventPhase]);
					this.Student.Character.animation.CrossFade(this.Student.IdleAnim, (float)1);
				}
				else
				{
					this.Student.Character.animation.CrossFade(this.EventAnim[this.EventPhase]);
					this.Yandere.Character.animation.CrossFade(this.Yandere.IdleAnim, (float)1);
				}
				this.EventSubtitle.transform.localScale = new Vector3((float)1, (float)1, (float)1);
				this.EventSubtitle.text = this.EventSpeech[this.EventPhase];
				this.audio.clip = this.EventClip[this.EventPhase];
				this.audio.Play();
				this.Spoken = true;
			}
			else
			{
				if (Input.GetButtonDown("A"))
				{
					this.Timer += this.EventClip[this.EventPhase].length + (float)1;
				}
				if (this.EventSpeaker[this.EventPhase] == 1)
				{
					if (this.Yandere.Character.animation[this.EventAnim[this.EventPhase]].time >= this.Yandere.Character.animation[this.EventAnim[this.EventPhase]].length)
					{
						this.Yandere.Character.animation.CrossFade(this.Yandere.IdleAnim);
					}
				}
				else if (this.Student.Character.animation[this.EventAnim[this.EventPhase]].time >= this.Student.Character.animation[this.EventAnim[this.EventPhase]].length)
				{
					this.Student.Character.animation.CrossFade(this.Student.IdleAnim);
				}
				this.Timer += Time.deltaTime;
				if (this.Timer > this.EventClip[this.EventPhase].length)
				{
					this.EventSubtitle.text = string.Empty;
				}
				if (this.Timer > this.EventClip[this.EventPhase].length + (float)1)
				{
					this.Spoken = false;
					this.EventPhase++;
					this.Timer = (float)0;
					if (this.EventPhase == Extensions.get_length(this.EventSpeech))
					{
						PlayerPrefs.SetInt("Scheme_6_Stage", 5);
						this.Student.CurrentDestination = this.Student.Destinations[this.Student.Phase];
						this.Student.Pathfinding.target = this.Student.Destinations[this.Student.Phase];
						this.Student.Pathfinding.canSearch = true;
						this.Student.Pathfinding.canMove = true;
						this.Student.Routine = true;
						this.EventSubtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
						this.Yandere.CanMove = true;
						this.Jukebox.Dip = (float)1;
						UnityEngine.Object.Destroy(this.gameObject);
					}
				}
			}
		}
		if (!this.StudentManager.Students[7].Pushable)
		{
			this.active = false;
		}
	}

	public virtual void Main()
	{
	}
}
