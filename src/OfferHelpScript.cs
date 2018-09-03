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

	public bool Unable;

	public int EventStudentID;

	public int EventPhase = 1;

	public float Timer;

	private void Start()
	{
		this.Prompt.enabled = true;
	}

	private void Update()
	{
		if (!this.Unable)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
				{
					this.Jukebox.Dip = 0.1f;
					this.Yandere.EmptyHands();
					this.Yandere.CanMove = false;
					this.Student = this.StudentManager.Students[this.EventStudentID];
					this.Student.Prompt.Label[0].text = "     Talk";
					this.Student.Pushable = false;
					this.Student.Meeting = false;
					this.Student.Routine = false;
					this.Student.MeetTimer = 0f;
					this.Offering = true;
				}
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
					if (!this.Yandere.PauseScreen.Show && Input.GetButtonDown("A"))
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
						Debug.Log("Emptying string.");
						this.EventSubtitle.text = string.Empty;
					}
					if (this.Timer > this.EventClip[this.EventPhase].length + 1f)
					{
						if (this.EventStudentID == 5 && this.EventPhase == 2)
						{
							this.Yandere.PauseScreen.StudentInfoMenu.Targeting = true;
							base.StartCoroutine(this.Yandere.PauseScreen.PhotoGallery.GetPhotos());
							this.Yandere.PauseScreen.PhotoGallery.gameObject.SetActive(true);
							this.Yandere.PauseScreen.PhotoGallery.NamingBully = true;
							this.Yandere.PauseScreen.MainMenu.SetActive(false);
							this.Yandere.PauseScreen.Panel.enabled = true;
							this.Yandere.PauseScreen.Sideways = true;
							this.Yandere.PauseScreen.Show = true;
							Time.timeScale = 0.0001f;
							this.Yandere.PauseScreen.PhotoGallery.UpdateButtonPrompts();
							this.Offering = false;
						}
						else
						{
							this.Continue();
						}
					}
				}
			}
			else if (this.StudentManager.Students[this.EventStudentID].Pushed || !this.StudentManager.Students[this.EventStudentID].Alive)
			{
				base.gameObject.SetActive(false);
			}
		}
		else
		{
			this.Prompt.Circle[0].fillAmount = 1f;
		}
	}

	public void UpdateLocation()
	{
		this.Student = this.StudentManager.Students[this.EventStudentID];
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
		if (this.EventStudentID == 30 && !PlayerGlobals.GetStudentFriend(30))
		{
			this.Prompt.Label[0].text = "     Must Befriend Student First";
			this.Unable = true;
		}
	}

	public void Continue()
	{
		Debug.Log("Proceeding to next line.");
		this.Offering = true;
		this.Spoken = false;
		this.EventPhase++;
		this.Timer = 0f;
		if (this.EventStudentID == 30 && this.EventPhase == 14)
		{
			if (!ConversationGlobals.GetTopicDiscovered(23))
			{
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				ConversationGlobals.SetTopicDiscovered(23, true);
			}
			if (!ConversationGlobals.GetTopicLearnedByStudent(23, this.EventStudentID))
			{
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(23, this.EventStudentID, true);
			}
		}
		if (this.EventPhase == this.EventSpeech.Length)
		{
			if (this.EventStudentID == 30)
			{
				SchemeGlobals.SetSchemeStage(6, 5);
			}
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
