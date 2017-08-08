using System;
using UnityEngine;

public class OfferHelpScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public JukeboxScript Jukebox;

	public StudentScript Student;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public UILabel EventSubtitle;

	public Transform[] Locations;

	public AudioClip[] EventClip;

	public string[] EventSpeech;

	public string[] EventAnim;

	public int[] EventSpeaker;

	public bool Offering;

	public bool Spoken;

	public int EventPhase = 1;

	public float Timer;

	private void Start()
	{
		this.Prompt.enabled = true;
	}

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Jukebox.Dip = 0.1f;
			this.Yandere.EmptyHands();
			this.Yandere.CanMove = false;
			this.Student = this.StudentManager.Students[7];
			this.Student.Prompt.Label[0].text = "     Talk";
			this.Student.Pushable = false;
			this.Student.Meeting = false;
			this.Student.Routine = false;
			this.Student.MeetTimer = 0f;
			this.Offering = true;
		}
		if (this.Offering)
		{
			this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, base.transform.rotation, Time.deltaTime * 10f);
			this.Yandere.MoveTowardsTarget(base.transform.position + Vector3.down);
			Quaternion b = Quaternion.LookRotation(this.Yandere.transform.position - this.Student.transform.position);
			this.Student.transform.rotation = Quaternion.Slerp(this.Student.transform.rotation, b, Time.deltaTime * 10f);
			Animation component = this.Yandere.Character.GetComponent<Animation>();
			Animation component2 = this.Student.Character.GetComponent<Animation>();
			if (!this.Spoken)
			{
				if (this.EventSpeaker[this.EventPhase] == 1)
				{
					component.CrossFade(this.EventAnim[this.EventPhase]);
					component2.CrossFade(this.Student.IdleAnim, 1f);
				}
				else
				{
					component2.CrossFade(this.EventAnim[this.EventPhase]);
					component.CrossFade(this.Yandere.IdleAnim, 1f);
				}
				this.EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
				this.EventSubtitle.text = this.EventSpeech[this.EventPhase];
				AudioSource component3 = base.GetComponent<AudioSource>();
				component3.clip = this.EventClip[this.EventPhase];
				component3.Play();
				this.Spoken = true;
			}
			else
			{
				if (Input.GetButtonDown("A"))
				{
					this.Timer += this.EventClip[this.EventPhase].length + 1f;
				}
				if (this.EventSpeaker[this.EventPhase] == 1)
				{
					if (component[this.EventAnim[this.EventPhase]].time >= component[this.EventAnim[this.EventPhase]].length)
					{
						component.CrossFade(this.Yandere.IdleAnim);
					}
				}
				else if (component2[this.EventAnim[this.EventPhase]].time >= component2[this.EventAnim[this.EventPhase]].length)
				{
					component2.CrossFade(this.Student.IdleAnim);
				}
				this.Timer += Time.deltaTime;
				if (this.Timer > this.EventClip[this.EventPhase].length)
				{
					this.EventSubtitle.text = string.Empty;
				}
				if (this.Timer > this.EventClip[this.EventPhase].length + 1f)
				{
					this.Spoken = false;
					this.EventPhase++;
					this.Timer = 0f;
					if (this.EventPhase == 14)
					{
						if (PlayerPrefs.GetInt("Topic_23_Discovered") == 0)
						{
							this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
							PlayerPrefs.SetInt("Topic_23_Discovered", 1);
						}
						if (PlayerPrefs.GetInt("Topic_23_Student_7_Learned") == 0)
						{
							this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
							PlayerPrefs.SetInt("Topic_23_Student_7_Learned", 1);
						}
					}
					if (this.EventPhase == this.EventSpeech.Length)
					{
						PlayerPrefs.SetInt("Scheme_6_Stage", 5);
						this.Student.CurrentDestination = this.Student.Destinations[this.Student.Phase];
						this.Student.Pathfinding.target = this.Student.Destinations[this.Student.Phase];
						this.Student.Pathfinding.canSearch = true;
						this.Student.Pathfinding.canMove = true;
						this.Student.Routine = true;
						this.EventSubtitle.transform.localScale = Vector3.zero;
						this.Yandere.CanMove = true;
						this.Jukebox.Dip = 1f;
						UnityEngine.Object.Destroy(base.gameObject);
					}
				}
			}
		}
		else if (this.StudentManager.Students[7].Pushed || !this.StudentManager.Students[7].Alive)
		{
			base.gameObject.SetActive(false);
		}
	}

	public void UpdateLocation()
	{
		this.Student = this.StudentManager.Students[7];
		if (this.Student.CurrentDestination == this.StudentManager.MeetSpots.List[8])
		{
			base.transform.position = this.Locations[1].position;
			base.transform.eulerAngles = this.Locations[1].eulerAngles;
		}
		else if (this.Student.CurrentDestination == this.StudentManager.MeetSpots.List[9])
		{
			base.transform.position = this.Locations[2].position;
			base.transform.eulerAngles = this.Locations[2].eulerAngles;
		}
		else if (this.Student.CurrentDestination == this.StudentManager.MeetSpots.List[10])
		{
			base.transform.position = this.Locations[3].position;
			base.transform.eulerAngles = this.Locations[3].eulerAngles;
		}
	}
}
