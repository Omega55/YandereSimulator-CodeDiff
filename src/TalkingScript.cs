using System;
using UnityEngine;

public class TalkingScript : MonoBehaviour
{
	private const float LongestTime = 100f;

	private const float LongTime = 5f;

	private const float MediumTime = 3f;

	private const float ShortTime = 2f;

	public StudentScript S;

	public bool Follow;

	public bool Fake;

	private void Update()
	{
		if (this.S.Talking)
		{
			if (this.S.Interaction == StudentInteractionType.Idle)
			{
				if (!this.Fake)
				{
					this.S.Character.GetComponent<Animation>().CrossFade(this.S.IdleAnim);
				}
				if (this.S.TalkTimer == 0f)
				{
					if (!this.S.DialogueWheel.AppearanceWindow.Show)
					{
						this.S.DialogueWheel.Impatience.fillAmount += Time.deltaTime * 0.1f;
					}
					if (this.S.DialogueWheel.Impatience.fillAmount > 0.5f && this.S.Subtitle.Timer == 0f)
					{
						this.S.Subtitle.UpdateLabel("Impatience", 1, 5f);
					}
					if (this.S.DialogueWheel.Impatience.fillAmount >= 1f)
					{
						this.S.Subtitle.UpdateLabel("Impatience", 2, 3f);
						this.S.DialogueWheel.End();
						this.S.WaitTimer = 0f;
					}
				}
			}
			else if (this.S.Interaction == StudentInteractionType.Forgiving)
			{
				if (this.S.TalkTimer == 3f)
				{
					this.S.Character.GetComponent<Animation>().CrossFade(this.S.Nod2Anim);
					this.S.RepRecovery = 5f;
					if (PlayerPrefs.GetInt("PantiesEquipped") == 6)
					{
						this.S.RepRecovery += 2.5f;
					}
					if (PlayerPrefs.GetInt("SocialBonus") > 0)
					{
						this.S.RepRecovery += 2.5f;
					}
					this.S.PendingRep += this.S.RepRecovery;
					this.S.Reputation.PendingRep += this.S.RepRecovery;
					this.S.ID = 0;
					while (this.S.ID < this.S.Outlines.Length)
					{
						this.S.Outlines[this.S.ID].color = new Color(0f, 1f, 0f, 1f);
						this.S.ID++;
					}
					this.S.Forgave = true;
					if (this.S.Witnessed == "Insanity" || this.S.Witnessed == "Weapon and Blood and Insanity" || this.S.Witnessed == "Weapon and Insanity" || this.S.Witnessed == "Blood and Insanity")
					{
						this.S.Subtitle.UpdateLabel("Forgiving Insanity", 0, 3f);
					}
					else if (this.S.Witnessed == "Accident")
					{
						this.S.Subtitle.UpdateLabel("Forgiving Accident", 0, 5f);
					}
					else
					{
						this.S.Subtitle.UpdateLabel("Forgiving", 0, 3f);
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.Character.GetComponent<Animation>()[this.S.Nod2Anim].time >= this.S.Character.GetComponent<Animation>()[this.S.Nod2Anim].length)
					{
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.IdleAnim);
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.IgnoreTimer = 5f;
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.ReceivingCompliment)
			{
				if (this.S.TalkTimer == 3f)
				{
					this.S.Subtitle.UpdateLabel("Student Compliment", 0, 3f);
					this.S.RepBonus = 0;
					if (PlayerPrefs.GetInt("PantiesEquipped") == 3)
					{
						this.S.RepBonus++;
					}
					if ((this.S.Male && PlayerPrefs.GetInt("Seduction") > 0) || PlayerPrefs.GetInt("Seduction") == 5)
					{
						this.S.RepBonus++;
					}
					if (PlayerPrefs.GetInt("SocialBonus") > 0)
					{
						this.S.RepBonus++;
					}
					this.S.Reputation.PendingRep += 1f + (float)this.S.RepBonus;
					this.S.PendingRep += 1f + (float)this.S.RepBonus;
					this.S.Complimented = true;
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.TalkTimer = 0f;
				}
				this.S.Character.GetComponent<Animation>().CrossFade(this.S.LookDownAnim);
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.TalkTimer <= 0f)
				{
					this.S.DialogueWheel.End();
				}
			}
			else if (this.S.Interaction == StudentInteractionType.Gossiping)
			{
				if (this.S.TalkTimer == 3f)
				{
					this.S.Character.GetComponent<Animation>().CrossFade(this.S.GossipAnim);
					this.S.Subtitle.UpdateLabel("Student Gossip", 0, 3f);
					this.S.GossipBonus = 0;
					if (this.S.Reputation.Reputation > 33.33333f)
					{
						this.S.GossipBonus++;
					}
					if (PlayerPrefs.GetInt("PantiesEquipped") == 9)
					{
						this.S.GossipBonus++;
					}
					if (PlayerPrefs.GetInt("DarkSecret") == 1)
					{
						this.S.GossipBonus++;
					}
					if (PlayerPrefs.GetInt(this.S.StudentID.ToString() + "_Friend") == 1)
					{
						this.S.GossipBonus++;
					}
					if ((this.S.Male && PlayerPrefs.GetInt("Seduction") > 1) || PlayerPrefs.GetInt("Seduction") == 5)
					{
						this.S.GossipBonus++;
					}
					if (PlayerPrefs.GetInt("SocialBonus") > 0)
					{
						this.S.GossipBonus++;
					}
					PlayerPrefs.SetInt("Student_" + this.S.DialogueWheel.Victim.ToString() + "_Reputation", PlayerPrefs.GetInt("Student_" + this.S.DialogueWheel.Victim.ToString() + "_Reputation") - (1 + this.S.GossipBonus));
					this.S.Reputation.PendingRep -= 2f;
					this.S.PendingRep -= 2f;
					this.S.Gossiped = true;
					if (PlayerPrefs.GetInt("Topic_15_Discovered") == 0)
					{
						this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
						PlayerPrefs.SetInt("Topic_15_Discovered", 1);
					}
					if (PlayerPrefs.GetInt("Topic_15_Student_" + this.S.StudentID.ToString() + "_Learned") == 0)
					{
						this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
						PlayerPrefs.SetInt("Topic_15_Student_" + this.S.StudentID.ToString() + "_Learned", 1);
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.Character.GetComponent<Animation>()[this.S.GossipAnim].time >= this.S.Character.GetComponent<Animation>()[this.S.GossipAnim].length)
					{
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.IdleAnim);
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.Bye)
			{
				if (this.S.TalkTimer == 2f)
				{
					this.S.Subtitle.UpdateLabel("Student Farewell", 0, 2f);
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.TalkTimer = 0f;
				}
				this.S.Character.GetComponent<Animation>().CrossFade(this.S.IdleAnim);
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.TalkTimer <= 0f)
				{
					this.S.DialogueWheel.End();
				}
			}
			else if (this.S.Interaction == StudentInteractionType.GivingTask)
			{
				if (this.S.TalkTimer == 100f)
				{
					this.S.Subtitle.UpdateLabel("Task " + this.S.StudentID.ToString() + " Line", this.S.TaskPhase, this.S.Subtitle.GetClipLength(this.S.StudentID, this.S.TaskPhase));
					this.S.Character.GetComponent<Animation>().CrossFade(this.S.TaskAnims[this.S.TaskPhase]);
					this.S.CurrentAnim = this.S.TaskAnims[this.S.TaskPhase];
					this.S.TalkTimer = this.S.Subtitle.GetClipLength(this.S.StudentID, this.S.TaskPhase);
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.Subtitle.Label.text = string.Empty;
					UnityEngine.Object.Destroy(this.S.Subtitle.CurrentClip);
					this.S.TalkTimer = 0f;
				}
				if (this.S.Character.GetComponent<Animation>()[this.S.CurrentAnim].time >= this.S.Character.GetComponent<Animation>()[this.S.CurrentAnim].length)
				{
					this.S.Character.GetComponent<Animation>().CrossFade(this.S.IdleAnim);
				}
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.TalkTimer <= 0f)
				{
					if (this.S.TaskPhase == 5)
					{
						this.S.DialogueWheel.TaskWindow.TaskComplete = true;
						PlayerPrefs.SetInt("Task_" + this.S.StudentID.ToString() + "_Status", 3);
						PlayerPrefs.SetInt(this.S.StudentID.ToString() + "_Friend", 1);
						this.S.Interaction = StudentInteractionType.Idle;
					}
					else if (this.S.TaskPhase == 4 || this.S.TaskPhase == 0)
					{
						this.S.StudentManager.TaskManager.UpdateTaskStatus();
						this.S.DialogueWheel.End();
					}
					else if (this.S.TaskPhase == 3)
					{
						this.S.DialogueWheel.TaskWindow.UpdateWindow(this.S.StudentID);
						this.S.Interaction = StudentInteractionType.Idle;
					}
					else
					{
						this.S.TaskPhase++;
						this.S.Subtitle.UpdateLabel("Task " + this.S.StudentID.ToString() + " Line", this.S.TaskPhase, this.S.Subtitle.GetClipLength(this.S.StudentID, this.S.TaskPhase));
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.TaskAnims[this.S.TaskPhase]);
						this.S.CurrentAnim = this.S.TaskAnims[this.S.TaskPhase];
						this.S.TalkTimer = this.S.Subtitle.GetClipLength(this.S.StudentID, this.S.TaskPhase);
					}
				}
			}
			else if (this.S.Interaction == StudentInteractionType.FollowingPlayer)
			{
				if (this.S.TalkTimer == 2f)
				{
					if ((this.S.Clock.HourTime > 8f && this.S.Clock.HourTime < 13f) || (this.S.Clock.HourTime > 13.375f && this.S.Clock.HourTime < 15.5f))
					{
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.GossipAnim);
						this.S.Subtitle.UpdateLabel("Student Stay", 0, 5f);
					}
					else
					{
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.Nod1Anim);
						this.S.Subtitle.UpdateLabel("Student Follow", 0, 2f);
						this.Follow = true;
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.Character.GetComponent<Animation>()[this.S.Nod1Anim].time >= this.S.Character.GetComponent<Animation>()[this.S.Nod1Anim].length)
					{
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.IdleAnim);
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.DialogueWheel.End();
						if (this.Follow)
						{
							this.S.Pathfinding.target = this.S.Yandere.transform;
							this.S.Prompt.Label[0].text = "     Stop";
							if (this.S.StudentID == 7)
							{
								this.S.StudentManager.FollowerLookAtTarget.position = this.S.DefaultTarget.position;
								this.S.StudentManager.LoveManager.Follower = this.S;
							}
							this.S.Yandere.Follower = this.S;
							this.S.Yandere.Followers++;
							this.S.Following = true;
						}
						this.Follow = false;
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.GoingAway)
			{
				if (this.S.TalkTimer == 3f)
				{
					if ((this.S.Clock.HourTime > 8f && this.S.Clock.HourTime < 13f) || (this.S.Clock.HourTime > 13.375f && this.S.Clock.HourTime < 15.5f))
					{
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.GossipAnim);
						this.S.Subtitle.UpdateLabel("Student Stay", 0, 5f);
					}
					else
					{
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.Nod1Anim);
						this.S.Subtitle.UpdateLabel("Student Leave", 0, 3f);
						this.S.GoAway = true;
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.Character.GetComponent<Animation>()[this.S.Nod1Anim].time >= this.S.Character.GetComponent<Animation>()[this.S.Nod1Anim].length)
					{
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.IdleAnim);
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.DialogueWheel.End();
						if (this.S.GoAway)
						{
							this.S.CurrentDestination = this.S.StudentManager.GoAwaySpots.List[this.S.StudentID];
							this.S.Pathfinding.target = this.S.StudentManager.GoAwaySpots.List[this.S.StudentID];
						}
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.DistractingTarget)
			{
				if (this.S.TalkTimer == 3f)
				{
					if ((this.S.Clock.HourTime > 8f && this.S.Clock.HourTime < 13f) || (this.S.Clock.HourTime > 13.375f && this.S.Clock.HourTime < 15.5f))
					{
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.GossipAnim);
						this.S.Subtitle.UpdateLabel("Student Stay", 0, 5f);
					}
					else
					{
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.Nod1Anim);
						StudentScript studentScript = this.S.StudentManager.Students[this.S.DialogueWheel.Victim];
						if (studentScript.Routine && !studentScript.TargetedForDistraction)
						{
							this.S.Subtitle.UpdateLabel("Student Distract", 0, 3f);
						}
						else
						{
							this.S.Subtitle.UpdateLabel("Student Distract Refuse", 0, 3f);
						}
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.Character.GetComponent<Animation>()[this.S.Nod1Anim].time >= this.S.Character.GetComponent<Animation>()[this.S.Nod1Anim].length)
					{
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.IdleAnim);
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.DialogueWheel.End();
						if ((this.S.Clock.HourTime < 8f || (this.S.Clock.HourTime > 13f && this.S.Clock.HourTime < 13.375f) || this.S.Clock.HourTime > 15.5f) && !this.S.Distracting)
						{
							this.S.DistractionTarget = this.S.StudentManager.Students[this.S.DialogueWheel.Victim];
							this.S.DistractionTarget.TargetedForDistraction = true;
							this.S.CurrentDestination = this.S.DistractionTarget.transform;
							this.S.Pathfinding.target = this.S.DistractionTarget.transform;
							this.S.Pathfinding.speed = 4f;
							this.S.TargetDistance = 1f;
							this.S.DistractTimer = 10f;
							this.S.Distracting = true;
							this.S.Routine = false;
							this.S.CanTalk = false;
						}
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.PersonalGrudge)
			{
				if (this.S.TalkTimer == 5f)
				{
					if (this.S.Persona == PersonaType.Coward)
					{
						this.S.Subtitle.UpdateLabel("Coward Grudge", 0, 5f);
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.CowardAnim);
						this.S.TalkTimer = 5f;
					}
					else if (this.S.Persona == PersonaType.Evil)
					{
						this.S.Subtitle.UpdateLabel("Evil Grudge", 0, 5f);
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.EvilAnim);
						this.S.TalkTimer = 5f;
					}
					else
					{
						if (!this.S.Male)
						{
							this.S.Subtitle.UpdateLabel("Grudge Warning", 0, 99f);
						}
						else
						{
							this.S.Subtitle.UpdateLabel("Grudge Warning", 1, 99f);
						}
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.GrudgeAnim);
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.ClubInfo)
			{
				if (this.S.TalkTimer == 100f)
				{
					this.S.Subtitle.UpdateLabel("Club " + this.S.Club.ToString() + " Info", this.S.ClubPhase, 99f);
					this.S.TalkTimer = this.S.Subtitle.GetClubClipLength(this.S.Club, this.S.ClubPhase);
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.Subtitle.Label.text = string.Empty;
					UnityEngine.Object.Destroy(this.S.Subtitle.CurrentClip);
					this.S.TalkTimer = 0f;
				}
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.TalkTimer <= 0f)
				{
					if (this.S.ClubPhase == 3)
					{
						this.S.DialogueWheel.Panel.enabled = true;
						this.S.DialogueWheel.Show = true;
						this.S.Subtitle.Label.text = string.Empty;
						this.S.Interaction = StudentInteractionType.Idle;
						this.S.TalkTimer = 0f;
					}
					else
					{
						this.S.ClubPhase++;
						this.S.Subtitle.UpdateLabel("Club " + this.S.Club.ToString() + " Info", this.S.ClubPhase, 99f);
						this.S.TalkTimer = this.S.Subtitle.GetClubClipLength(this.S.Club, this.S.ClubPhase);
					}
				}
			}
			else if (this.S.Interaction == StudentInteractionType.ClubJoin)
			{
				if (this.S.TalkTimer == 100f)
				{
					if (this.S.ClubPhase == 1)
					{
						this.S.Subtitle.UpdateLabel("Club Join", this.S.Club, 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 2)
					{
						this.S.Subtitle.UpdateLabel("Club Accept", this.S.Club, 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 3)
					{
						this.S.Subtitle.UpdateLabel("Club Refuse", this.S.Club, 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 4)
					{
						this.S.Subtitle.UpdateLabel("Club Rejoin", this.S.Club, 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 5)
					{
						this.S.Subtitle.UpdateLabel("Club Exclusive", this.S.Club, 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 6)
					{
						this.S.Subtitle.UpdateLabel("Club Grudge", this.S.Club, 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.Subtitle.Label.text = string.Empty;
					UnityEngine.Object.Destroy(this.S.Subtitle.CurrentClip);
					this.S.TalkTimer = 0f;
				}
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.TalkTimer <= 0f)
				{
					if (this.S.ClubPhase == 1)
					{
						this.S.DialogueWheel.ClubWindow.Club = this.S.Club;
						this.S.DialogueWheel.ClubWindow.UpdateWindow();
						this.S.Subtitle.Label.text = string.Empty;
						this.S.Interaction = StudentInteractionType.Idle;
					}
					else
					{
						this.S.DialogueWheel.End();
						if (this.S.Club == 6)
						{
							this.S.ChangingBooth.CheckYandereClub();
						}
					}
				}
			}
			else if (this.S.Interaction == StudentInteractionType.ClubQuit)
			{
				if (this.S.TalkTimer == 100f)
				{
					if (this.S.ClubPhase == 1)
					{
						this.S.Subtitle.UpdateLabel("Club Quit", this.S.Club, 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 2)
					{
						this.S.Subtitle.UpdateLabel("Club Confirm", this.S.Club, 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 3)
					{
						this.S.Subtitle.UpdateLabel("Club Deny", this.S.Club, 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.Subtitle.Label.text = string.Empty;
					UnityEngine.Object.Destroy(this.S.Subtitle.CurrentClip);
					this.S.TalkTimer = 0f;
				}
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.TalkTimer <= 0f)
				{
					if (this.S.ClubPhase == 1)
					{
						this.S.DialogueWheel.ClubWindow.Club = this.S.Club;
						this.S.DialogueWheel.ClubWindow.Quitting = true;
						this.S.DialogueWheel.ClubWindow.UpdateWindow();
						this.S.Subtitle.Label.text = string.Empty;
						this.S.Interaction = StudentInteractionType.Idle;
					}
					else
					{
						this.S.DialogueWheel.End();
						if (this.S.Club == 6)
						{
							this.S.ChangingBooth.CheckYandereClub();
						}
					}
				}
			}
			else if (this.S.Interaction == StudentInteractionType.ClubBye)
			{
				if (this.S.TalkTimer == this.S.Subtitle.ClubFarewellClips[this.S.Club].length)
				{
					this.S.Subtitle.UpdateLabel("Club Farewell", this.S.Club, this.S.Subtitle.ClubFarewellClips[this.S.Club].length);
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.TalkTimer = 0f;
				}
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.TalkTimer <= 0f)
				{
					this.S.DialogueWheel.End();
				}
			}
			else if (this.S.Interaction == StudentInteractionType.ClubActivity)
			{
				if (this.S.TalkTimer == 100f)
				{
					if (this.S.ClubPhase == 1)
					{
						this.S.Subtitle.UpdateLabel("Club Activity", this.S.Club, 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 2)
					{
						this.S.Subtitle.UpdateLabel("Club Yes", this.S.Club, 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 3)
					{
						this.S.Subtitle.UpdateLabel("Club No", this.S.Club, 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 4)
					{
						this.S.Subtitle.UpdateLabel("Club Early", this.S.Club, 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
					else if (this.S.ClubPhase == 5)
					{
						this.S.Subtitle.UpdateLabel("Club Late", this.S.Club, 99f);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
					}
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.Subtitle.Label.text = string.Empty;
					UnityEngine.Object.Destroy(this.S.Subtitle.CurrentClip);
					this.S.TalkTimer = 0f;
				}
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.TalkTimer <= 0f)
				{
					if (this.S.ClubPhase == 1)
					{
						this.S.DialogueWheel.ClubWindow.Club = this.S.Club;
						this.S.DialogueWheel.ClubWindow.Activity = true;
						this.S.DialogueWheel.ClubWindow.UpdateWindow();
						this.S.Subtitle.Label.text = string.Empty;
						this.S.Interaction = StudentInteractionType.Idle;
					}
					else if (this.S.ClubPhase == 2)
					{
						this.S.Police.Darkness.enabled = true;
						this.S.Police.ClubActivity = true;
						this.S.Police.FadeOut = true;
						this.S.Subtitle.Label.text = string.Empty;
						this.S.Interaction = StudentInteractionType.Idle;
					}
					else
					{
						this.S.DialogueWheel.End();
					}
				}
			}
			else if (this.S.Interaction == StudentInteractionType.ClubUnwelcome)
			{
				if (this.S.TalkTimer == 5f)
				{
					this.S.Subtitle.UpdateLabel("Club Unwelcome", this.S.Club, 99f);
					this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.ClubKick)
			{
				if (this.S.TalkTimer == 5f)
				{
					this.S.Subtitle.UpdateLabel("Club Kick", this.S.Club, 99f);
					this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.TalkTimer <= 0f)
					{
						PlayerPrefs.SetInt("Club", 0);
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.NamingCrush)
			{
				if (this.S.TalkTimer == 3f)
				{
					if (this.S.DialogueWheel.Victim != this.S.Crush)
					{
						this.S.Subtitle.UpdateLabel("Suitor Love", 0, 3f);
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.GossipAnim);
						this.S.CurrentAnim = this.S.GossipAnim;
					}
					else
					{
						PlayerPrefs.SetInt("SuitorProgress", 1);
						this.S.Yandere.LoveManager.SuitorProgress++;
						this.S.Subtitle.UpdateLabel("Suitor Love", 1, 3f);
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.Nod1Anim);
						this.S.CurrentAnim = this.S.Nod1Anim;
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.Character.GetComponent<Animation>()[this.S.CurrentAnim].time >= this.S.Character.GetComponent<Animation>()[this.S.CurrentAnim].length)
					{
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.IdleAnim);
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.ChangingAppearance)
			{
				if (this.S.TalkTimer == 3f)
				{
					this.S.Subtitle.UpdateLabel("Suitor Love", 2, 3f);
					this.S.Character.GetComponent<Animation>().CrossFade(this.S.Nod1Anim);
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.Character.GetComponent<Animation>()[this.S.Nod1Anim].time >= this.S.Character.GetComponent<Animation>()[this.S.Nod1Anim].length)
					{
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.IdleAnim);
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.Court)
			{
				if (this.S.TalkTimer == 3f)
				{
					if (this.S.Male)
					{
						this.S.Subtitle.UpdateLabel("Suitor Love", 3, 5f);
					}
					else
					{
						this.S.Subtitle.UpdateLabel("Suitor Love", 4, 5f);
					}
					this.S.Character.GetComponent<Animation>().CrossFade(this.S.Nod1Anim);
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.Character.GetComponent<Animation>()[this.S.Nod1Anim].time >= this.S.Character.GetComponent<Animation>()[this.S.Nod1Anim].length)
					{
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.IdleAnim);
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.MeetTime = this.S.Clock.HourTime;
						if (this.S.Male)
						{
							this.S.MeetSpot = this.S.StudentManager.SuitorSpot;
						}
						else
						{
							this.S.MeetSpot = this.S.StudentManager.RomanceSpot;
							this.S.StudentManager.LoveManager.RivalWaiting = true;
						}
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.Gift)
			{
				if (this.S.TalkTimer == 5f)
				{
					this.S.Subtitle.UpdateLabel("Suitor Love", 5, 99f);
					this.S.Character.GetComponent<Animation>().CrossFade(this.S.Nod1Anim);
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = 0f;
					}
					if (this.S.Character.GetComponent<Animation>()[this.S.Nod1Anim].time >= this.S.Character.GetComponent<Animation>()[this.S.Nod1Anim].length)
					{
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.IdleAnim);
					}
					if (this.S.TalkTimer <= 0f)
					{
						this.S.Rose = true;
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer -= Time.deltaTime;
			}
			else if (this.S.Interaction == StudentInteractionType.Feeding)
			{
				if (this.S.TalkTimer == 3f)
				{
					if (!this.S.Fed)
					{
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.Nod2Anim);
						this.S.Subtitle.UpdateLabel("Accept Food", 0, 3f);
						this.S.RepBonus = 0;
						if (PlayerPrefs.GetInt("PantiesEquipped") == 3)
						{
							this.S.RepBonus++;
						}
						if ((this.S.Male && PlayerPrefs.GetInt("Seduction") > 0) || PlayerPrefs.GetInt("Seduction") == 5)
						{
							this.S.RepBonus++;
						}
						this.S.Reputation.PendingRep += 5f + (float)this.S.RepBonus;
						this.S.PendingRep += 5f + (float)this.S.RepBonus;
					}
					else
					{
						this.S.Character.GetComponent<Animation>().CrossFade(this.S.GossipAnim);
						this.S.Subtitle.UpdateLabel("Reject Food", 0, 3f);
					}
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.TalkTimer = 0f;
				}
				if (this.S.Character.GetComponent<Animation>()[this.S.Nod2Anim].time >= this.S.Character.GetComponent<Animation>()[this.S.Nod2Anim].length)
				{
					this.S.Character.GetComponent<Animation>().CrossFade(this.S.IdleAnim);
				}
				if (this.S.Character.GetComponent<Animation>()[this.S.GossipAnim].time >= this.S.Character.GetComponent<Animation>()[this.S.GossipAnim].length)
				{
					this.S.Character.GetComponent<Animation>().CrossFade(this.S.IdleAnim);
				}
				this.S.TalkTimer -= Time.deltaTime;
				if (this.S.TalkTimer <= 0f)
				{
					if (!this.S.Fed)
					{
						this.S.Yandere.PickUp.FoodPieces[this.S.Yandere.PickUp.Food].SetActive(false);
						this.S.Yandere.PickUp.Food--;
						this.S.Fed = true;
					}
					this.S.DialogueWheel.End();
					this.S.StudentManager.UpdateStudents();
				}
			}
			if (this.S.Waiting)
			{
				this.S.WaitTimer -= Time.deltaTime;
				if (this.S.WaitTimer <= 0f)
				{
					this.S.Talking = false;
					this.S.Waiting = false;
					if (!this.Fake)
					{
						this.S.Pathfinding.canSearch = true;
						this.S.Pathfinding.canMove = true;
						this.S.Obstacle.enabled = false;
						this.S.Alarmed = false;
						if (!this.S.Following && !this.S.Distracting && !this.S.Wet)
						{
							this.S.Routine = true;
						}
						if (!this.S.Following)
						{
							this.S.Hearts.emission.enabled = false;
						}
					}
					this.S.StudentManager.EnablePrompts();
				}
			}
			else
			{
				this.S.targetRotation = Quaternion.LookRotation(new Vector3(this.S.Yandere.transform.position.x, base.transform.position.y, this.S.Yandere.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.S.targetRotation, 10f * Time.deltaTime);
			}
		}
	}
}
