using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class TalkingScript : MonoBehaviour
{
	public StudentScript S;

	public bool Fake;

	public virtual void Update()
	{
		if (this.S.Talking)
		{
			if (this.S.Interaction == 0)
			{
				this.S.Character.animation.CrossFade(this.S.IdleAnim);
				if (this.S.TalkTimer == (float)0)
				{
					this.S.DialogueWheel.Impatience.fillAmount = this.S.DialogueWheel.Impatience.fillAmount + Time.deltaTime * 0.1f;
					if (this.S.DialogueWheel.Impatience.fillAmount > 0.5f && this.S.Subtitle.Timer == (float)0)
					{
						this.S.Subtitle.UpdateLabel("Impatience", 1, (float)5);
					}
					if (this.S.DialogueWheel.Impatience.fillAmount >= (float)1)
					{
						this.S.Subtitle.UpdateLabel("Impatience", 2, (float)3);
						this.S.DialogueWheel.End();
						this.S.WaitTimer = (float)0;
					}
				}
			}
			else if (this.S.Interaction == 1)
			{
				if (this.S.TalkTimer == (float)3)
				{
					this.S.Character.animation.CrossFade(this.S.Nod2Anim);
					this.S.RepRecovery = 5;
					if (PlayerPrefs.GetInt("PantiesEquipped") == 6)
					{
						this.S.RepRecovery = (int)((float)this.S.RepRecovery + 2.5f);
					}
					if (PlayerPrefs.GetInt("SocialBonus") > 0)
					{
						this.S.RepRecovery = (int)((float)this.S.RepRecovery + 2.5f);
					}
					this.S.PendingRep = this.S.PendingRep + (float)this.S.RepRecovery;
					this.S.Reputation.PendingRep = this.S.Reputation.PendingRep + (float)this.S.RepRecovery;
					this.S.ID = 0;
					while (this.S.ID < Extensions.get_length(this.S.Outlines))
					{
						this.S.Outlines[this.S.ID].color = new Color((float)0, (float)1, (float)0, (float)1);
						this.S.ID = this.S.ID + 1;
					}
					this.S.Forgave = true;
					if (this.S.Witnessed == "Insanity" || this.S.Witnessed == "Weapon and Blood and Insanity" || this.S.Witnessed == "Weapon and Insanity" || this.S.Witnessed == "Blood and Insanity")
					{
						this.S.Subtitle.UpdateLabel("Forgiving Insanity", 0, (float)3);
					}
					else
					{
						this.S.Subtitle.UpdateLabel("Forgiving", 0, (float)3);
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = (float)0;
					}
					if (this.S.Character.animation[this.S.Nod2Anim].time >= this.S.Character.animation[this.S.Nod2Anim].length)
					{
						this.S.Character.animation.CrossFade(this.S.IdleAnim);
					}
					if (this.S.TalkTimer <= (float)0)
					{
						this.S.IgnoreTimer = (float)5;
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer = this.S.TalkTimer - Time.deltaTime;
			}
			else if (this.S.Interaction == 2)
			{
				if (this.S.TalkTimer == (float)3)
				{
					this.S.Subtitle.UpdateLabel("Student Compliment", 0, (float)3);
					this.S.RepBonus = 0;
					if (PlayerPrefs.GetInt("PantiesEquipped") == 3)
					{
						this.S.RepBonus = this.S.RepBonus + 1;
					}
					if ((this.S.Male && PlayerPrefs.GetInt("Seduction") > 0) || PlayerPrefs.GetInt("Seduction") == 5)
					{
						this.S.RepBonus = this.S.RepBonus + 1;
					}
					if (PlayerPrefs.GetInt("SocialBonus") > 0)
					{
						this.S.RepBonus = this.S.RepBonus + 1;
					}
					this.S.Reputation.PendingRep = this.S.Reputation.PendingRep + (float)(1 + this.S.RepBonus);
					this.S.PendingRep = this.S.PendingRep + (float)(1 + this.S.RepBonus);
					this.S.Complimented = true;
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.TalkTimer = (float)0;
				}
				this.S.Character.animation.CrossFade(this.S.LookDownAnim);
				this.S.TalkTimer = this.S.TalkTimer - Time.deltaTime;
				if (this.S.TalkTimer <= (float)0)
				{
					this.S.DialogueWheel.End();
				}
			}
			else if (this.S.Interaction == 3)
			{
				if (this.S.TalkTimer == (float)3)
				{
					this.S.Character.animation.CrossFade(this.S.GossipAnim);
					this.S.Subtitle.UpdateLabel("Student Gossip", 0, (float)3);
					this.S.GossipBonus = 0;
					if (this.S.Reputation.Reputation > 33.33333f)
					{
						this.S.GossipBonus = this.S.GossipBonus + 1;
					}
					if (PlayerPrefs.GetInt("PantiesEquipped") == 9)
					{
						this.S.GossipBonus = this.S.GossipBonus + 1;
					}
					if (PlayerPrefs.GetInt("DarkSecret") == 1)
					{
						this.S.GossipBonus = this.S.GossipBonus + 1;
					}
					if (PlayerPrefs.GetInt(this.S.StudentID + "_Friend") == 1)
					{
						this.S.GossipBonus = this.S.GossipBonus + 1;
					}
					if ((this.S.Male && PlayerPrefs.GetInt("Seduction") > 1) || PlayerPrefs.GetInt("Seduction") == 5)
					{
						this.S.GossipBonus = this.S.GossipBonus + 1;
					}
					if (PlayerPrefs.GetInt("SocialBonus") > 0)
					{
						this.S.GossipBonus = this.S.GossipBonus + 1;
					}
					PlayerPrefs.SetInt("Student_" + this.S.DialogueWheel.Victim + "_Reputation", PlayerPrefs.GetInt("Student_" + this.S.DialogueWheel.Victim + "_Reputation") - (1 + this.S.GossipBonus));
					this.S.Reputation.PendingRep = this.S.Reputation.PendingRep - (float)2;
					this.S.PendingRep = this.S.PendingRep - (float)2;
					this.S.Gossiped = true;
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = (float)0;
					}
					if (this.S.Character.animation[this.S.GossipAnim].time >= this.S.Character.animation[this.S.GossipAnim].length)
					{
						this.S.Character.animation.CrossFade(this.S.IdleAnim);
					}
					if (this.S.TalkTimer <= (float)0)
					{
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer = this.S.TalkTimer - Time.deltaTime;
			}
			else if (this.S.Interaction == 4)
			{
				if (this.S.TalkTimer == (float)2)
				{
					this.S.Subtitle.UpdateLabel("Student Farewell", 0, (float)2);
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.TalkTimer = (float)0;
				}
				this.S.Character.animation.CrossFade(this.S.IdleAnim);
				this.S.TalkTimer = this.S.TalkTimer - Time.deltaTime;
				if (this.S.TalkTimer <= (float)0)
				{
					this.S.DialogueWheel.End();
				}
			}
			else if (this.S.Interaction == 5)
			{
				if (this.S.TalkTimer == (float)100)
				{
					this.S.Subtitle.UpdateLabel("Task " + this.S.StudentID + " Line", this.S.TaskPhase, this.S.Subtitle.GetClipLength(this.S.StudentID, this.S.TaskPhase));
					this.S.Character.animation.CrossFade(this.S.TaskAnims[this.S.TaskPhase]);
					this.S.CurrentAnim = this.S.TaskAnims[this.S.TaskPhase];
					this.S.TalkTimer = this.S.Subtitle.GetClipLength(this.S.StudentID, this.S.TaskPhase);
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.Subtitle.Label.text = string.Empty;
					UnityEngine.Object.Destroy(this.S.Subtitle.CurrentClip);
					this.S.TalkTimer = (float)0;
				}
				if (this.S.Character.animation[this.S.CurrentAnim].time >= this.S.Character.animation[this.S.CurrentAnim].length)
				{
					this.S.Character.animation.CrossFade(this.S.IdleAnim);
				}
				this.S.TalkTimer = this.S.TalkTimer - Time.deltaTime;
				if (this.S.TalkTimer <= (float)0)
				{
					if (this.S.TaskPhase == 5)
					{
						this.S.DialogueWheel.TaskWindow.TaskComplete = true;
						PlayerPrefs.SetInt("Task_" + this.S.StudentID + "_Status", 3);
						PlayerPrefs.SetInt(this.S.StudentID + "_Friend", 1);
						this.S.Interaction = 0;
					}
					else if (this.S.TaskPhase == 4 || this.S.TaskPhase == 0)
					{
						this.S.StudentManager.TaskManager.UpdateTaskStatus();
						this.S.DialogueWheel.End();
					}
					else if (this.S.TaskPhase == 3)
					{
						this.S.DialogueWheel.TaskWindow.UpdateWindow(this.S.StudentID);
						this.S.Interaction = 0;
					}
					else
					{
						this.S.TaskPhase = this.S.TaskPhase + 1;
						this.S.Subtitle.UpdateLabel("Task " + this.S.StudentID + " Line", this.S.TaskPhase, this.S.Subtitle.GetClipLength(this.S.StudentID, this.S.TaskPhase));
						this.S.Character.animation.CrossFade(this.S.TaskAnims[this.S.TaskPhase]);
						this.S.CurrentAnim = this.S.TaskAnims[this.S.TaskPhase];
						this.S.TalkTimer = this.S.Subtitle.GetClipLength(this.S.StudentID, this.S.TaskPhase);
					}
				}
			}
			else if (this.S.Interaction == 6)
			{
				if (this.S.TalkTimer == (float)2)
				{
					if ((this.S.Clock.HourTime > (float)8 && this.S.Clock.HourTime < (float)13) || (this.S.Clock.HourTime > 13.375f && this.S.Clock.HourTime < 15.5f))
					{
						this.S.Character.animation.CrossFade(this.S.GossipAnim);
						this.S.Subtitle.UpdateLabel("Student Stay", 0, (float)5);
					}
					else
					{
						this.S.Character.animation.CrossFade(this.S.Nod1Anim);
						this.S.Subtitle.UpdateLabel("Student Follow", 0, (float)2);
						this.S.Following = true;
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = (float)0;
					}
					if (this.S.Character.animation[this.S.Nod1Anim].time >= this.S.Character.animation[this.S.Nod1Anim].length)
					{
						this.S.Character.animation.CrossFade(this.S.IdleAnim);
					}
					if (this.S.TalkTimer <= (float)0)
					{
						this.S.DialogueWheel.End();
						if (this.S.Following)
						{
							this.S.Pathfinding.target = this.S.Yandere.transform;
							this.S.Prompt.Label[0].text = "     " + "Stop";
							this.S.Yandere.Follower = this.S;
							this.S.Yandere.Followers = this.S.Yandere.Followers + 1;
						}
					}
				}
				this.S.TalkTimer = this.S.TalkTimer - Time.deltaTime;
			}
			else if (this.S.Interaction == 7)
			{
				if (this.S.TalkTimer == (float)3)
				{
					if ((this.S.Clock.HourTime > (float)8 && this.S.Clock.HourTime < (float)13) || (this.S.Clock.HourTime > 13.375f && this.S.Clock.HourTime < 15.5f))
					{
						this.S.Character.animation.CrossFade(this.S.GossipAnim);
						this.S.Subtitle.UpdateLabel("Student Stay", 0, (float)5);
					}
					else
					{
						this.S.Character.animation.CrossFade(this.S.Nod1Anim);
						this.S.Subtitle.UpdateLabel("Student Leave", 0, (float)3);
						this.S.GoAway = true;
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = (float)0;
					}
					if (this.S.Character.animation[this.S.Nod1Anim].time >= this.S.Character.animation[this.S.Nod1Anim].length)
					{
						this.S.Character.animation.CrossFade(this.S.IdleAnim);
					}
					if (this.S.TalkTimer <= (float)0)
					{
						this.S.DialogueWheel.End();
						if (this.S.GoAway)
						{
							this.S.CurrentDestination = this.S.StudentManager.GoAwaySpots.List[this.S.StudentID];
							this.S.Pathfinding.target = this.S.StudentManager.GoAwaySpots.List[this.S.StudentID];
						}
					}
				}
				this.S.TalkTimer = this.S.TalkTimer - Time.deltaTime;
			}
			else if (this.S.Interaction == 8)
			{
				if (this.S.TalkTimer == (float)3)
				{
					if ((this.S.Clock.HourTime > (float)8 && this.S.Clock.HourTime < (float)13) || (this.S.Clock.HourTime > 13.375f && this.S.Clock.HourTime < 15.5f))
					{
						this.S.Character.animation.CrossFade(this.S.GossipAnim);
						this.S.Subtitle.UpdateLabel("Student Stay", 0, (float)5);
					}
					else
					{
						this.S.Character.animation.CrossFade(this.S.Nod1Anim);
						if (!this.S.StudentManager.Students[this.S.DialogueWheel.Victim].InEvent && PlayerPrefs.GetInt("Student_" + this.S.DialogueWheel.Victim + "_Slave") == 0)
						{
							this.S.Subtitle.UpdateLabel("Student Distract", 0, (float)3);
							this.S.Distracting = true;
						}
						else
						{
							this.S.Subtitle.UpdateLabel("Student Distract Refuse", 0, (float)3);
						}
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = (float)0;
					}
					if (this.S.Character.animation[this.S.Nod1Anim].time >= this.S.Character.animation[this.S.Nod1Anim].length)
					{
						this.S.Character.animation.CrossFade(this.S.IdleAnim);
					}
					if (this.S.TalkTimer <= (float)0)
					{
						this.S.DialogueWheel.End();
						if (this.S.Clock.HourTime < (float)8 || (this.S.Clock.HourTime > (float)13 && this.S.Clock.HourTime < 13.375f) || this.S.Clock.HourTime > 15.5f)
						{
							Debug.Log("Do we get here though?");
							if (this.S.Distracting)
							{
								Debug.Log("Yep.");
								this.S.DistractionTarget = this.S.StudentManager.Students[this.S.DialogueWheel.Victim];
								this.S.CurrentDestination = this.S.DistractionTarget.transform;
								this.S.Pathfinding.target = this.S.DistractionTarget.transform;
								this.S.Pathfinding.speed = (float)4;
								this.S.TargetDistance = (float)1;
								this.S.DistractTimer = (float)10;
								this.S.Routine = false;
								this.S.InEvent = true;
							}
						}
					}
				}
				this.S.TalkTimer = this.S.TalkTimer - Time.deltaTime;
			}
			else if (this.S.Interaction == 9)
			{
				if (this.S.TalkTimer == (float)5)
				{
					if (this.S.Persona == 4)
					{
						this.S.Subtitle.UpdateLabel("Coward Grudge", 0, (float)5);
						this.S.Character.animation.CrossFade(this.S.CowardAnim);
						this.S.TalkTimer = (float)5;
					}
					else if (this.S.Persona == 5)
					{
						this.S.Subtitle.UpdateLabel("Evil Grudge", 0, (float)5);
						this.S.Character.animation.CrossFade(this.S.EvilAnim);
						this.S.TalkTimer = (float)5;
					}
					else
					{
						if (!this.S.Male)
						{
							this.S.Subtitle.UpdateLabel("Grudge Warning", 0, (float)99);
						}
						else
						{
							this.S.Subtitle.UpdateLabel("Grudge Warning", 1, (float)99);
						}
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.audio.clip.length;
						this.S.Character.animation.CrossFade(this.S.GrudgeAnim);
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = (float)0;
					}
					if (this.S.TalkTimer <= (float)0)
					{
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer = this.S.TalkTimer - Time.deltaTime;
			}
			else if (this.S.Interaction == 10)
			{
				if (this.S.TalkTimer == (float)100)
				{
					this.S.Subtitle.UpdateLabel("Club " + this.S.Club + " Info", this.S.ClubPhase, (float)99);
					this.S.TalkTimer = this.S.Subtitle.GetClubClipLength(this.S.Club, this.S.ClubPhase);
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.Subtitle.Label.text = string.Empty;
					UnityEngine.Object.Destroy(this.S.Subtitle.CurrentClip);
					this.S.TalkTimer = (float)0;
				}
				this.S.TalkTimer = this.S.TalkTimer - Time.deltaTime;
				if (this.S.TalkTimer <= (float)0)
				{
					if (this.S.ClubPhase == 3)
					{
						this.S.DialogueWheel.Show = true;
						this.S.Subtitle.Label.text = string.Empty;
						this.S.Interaction = 0;
						this.S.TalkTimer = (float)0;
					}
					else
					{
						this.S.ClubPhase = this.S.ClubPhase + 1;
						this.S.Subtitle.UpdateLabel("Club " + this.S.Club + " Info", this.S.ClubPhase, (float)99);
						this.S.TalkTimer = this.S.Subtitle.GetClubClipLength(this.S.Club, this.S.ClubPhase);
					}
				}
			}
			else if (this.S.Interaction == 11)
			{
				if (this.S.TalkTimer == (float)100)
				{
					if (this.S.ClubPhase == 1)
					{
						this.S.Subtitle.UpdateLabel("Club Join", this.S.Club, (float)99);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.audio.clip.length;
					}
					else if (this.S.ClubPhase == 2)
					{
						this.S.Subtitle.UpdateLabel("Club Accept", this.S.Club, (float)99);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.audio.clip.length;
					}
					else if (this.S.ClubPhase == 3)
					{
						this.S.Subtitle.UpdateLabel("Club Refuse", this.S.Club, (float)99);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.audio.clip.length;
					}
					else if (this.S.ClubPhase == 4)
					{
						this.S.Subtitle.UpdateLabel("Club Rejoin", this.S.Club, (float)99);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.audio.clip.length;
					}
					else if (this.S.ClubPhase == 5)
					{
						this.S.Subtitle.UpdateLabel("Club Exclusive", this.S.Club, (float)99);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.audio.clip.length;
					}
					else if (this.S.ClubPhase == 6)
					{
						this.S.Subtitle.UpdateLabel("Club Grudge", this.S.Club, (float)99);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.audio.clip.length;
					}
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.Subtitle.Label.text = string.Empty;
					UnityEngine.Object.Destroy(this.S.Subtitle.CurrentClip);
					this.S.TalkTimer = (float)0;
				}
				this.S.TalkTimer = this.S.TalkTimer - Time.deltaTime;
				if (this.S.TalkTimer <= (float)0)
				{
					if (this.S.ClubPhase == 1)
					{
						this.S.DialogueWheel.ClubWindow.Club = this.S.Club;
						this.S.DialogueWheel.ClubWindow.UpdateWindow();
						this.S.Interaction = 0;
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
			else if (this.S.Interaction == 12)
			{
				if (this.S.TalkTimer == (float)100)
				{
					if (this.S.ClubPhase == 1)
					{
						this.S.Subtitle.UpdateLabel("Club Quit", this.S.Club, (float)99);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.audio.clip.length;
					}
					else if (this.S.ClubPhase == 2)
					{
						this.S.Subtitle.UpdateLabel("Club Confirm", this.S.Club, (float)99);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.audio.clip.length;
					}
					else if (this.S.ClubPhase == 3)
					{
						this.S.Subtitle.UpdateLabel("Club Deny", this.S.Club, (float)99);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.audio.clip.length;
					}
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.Subtitle.Label.text = string.Empty;
					UnityEngine.Object.Destroy(this.S.Subtitle.CurrentClip);
					this.S.TalkTimer = (float)0;
				}
				this.S.TalkTimer = this.S.TalkTimer - Time.deltaTime;
				if (this.S.TalkTimer <= (float)0)
				{
					if (this.S.ClubPhase == 1)
					{
						this.S.DialogueWheel.ClubWindow.Club = this.S.Club;
						this.S.DialogueWheel.ClubWindow.Quitting = true;
						this.S.DialogueWheel.ClubWindow.UpdateWindow();
						this.S.Interaction = 0;
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
			else if (this.S.Interaction == 13)
			{
				if (this.S.TalkTimer == this.S.Subtitle.ClubFarewellClips[this.S.Club].length)
				{
					this.S.Subtitle.UpdateLabel("Club Farewell", this.S.Club, this.S.Subtitle.ClubFarewellClips[this.S.Club].length);
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.TalkTimer = (float)0;
				}
				this.S.TalkTimer = this.S.TalkTimer - Time.deltaTime;
				if (this.S.TalkTimer <= (float)0)
				{
					this.S.DialogueWheel.End();
				}
			}
			else if (this.S.Interaction == 14)
			{
				if (this.S.TalkTimer == (float)100)
				{
					if (this.S.ClubPhase == 1)
					{
						this.S.Subtitle.UpdateLabel("Club Activity", this.S.Club, (float)99);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.audio.clip.length;
					}
					else if (this.S.ClubPhase == 2)
					{
						this.S.Subtitle.UpdateLabel("Club Yes", this.S.Club, (float)99);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.audio.clip.length;
					}
					else if (this.S.ClubPhase == 3)
					{
						this.S.Subtitle.UpdateLabel("Club No", this.S.Club, (float)99);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.audio.clip.length;
					}
					else if (this.S.ClubPhase == 4)
					{
						this.S.Subtitle.UpdateLabel("Club Early", this.S.Club, (float)99);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.audio.clip.length;
					}
					else if (this.S.ClubPhase == 5)
					{
						this.S.Subtitle.UpdateLabel("Club Late", this.S.Club, (float)99);
						this.S.TalkTimer = this.S.Subtitle.CurrentClip.audio.clip.length;
					}
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.Subtitle.Label.text = string.Empty;
					UnityEngine.Object.Destroy(this.S.Subtitle.CurrentClip);
					this.S.TalkTimer = (float)0;
				}
				this.S.TalkTimer = this.S.TalkTimer - Time.deltaTime;
				if (this.S.TalkTimer <= (float)0)
				{
					if (this.S.ClubPhase == 1)
					{
						this.S.DialogueWheel.ClubWindow.Club = this.S.Club;
						this.S.DialogueWheel.ClubWindow.Activity = true;
						this.S.DialogueWheel.ClubWindow.UpdateWindow();
						this.S.Interaction = 0;
					}
					else if (this.S.ClubPhase == 2)
					{
						this.S.Police.ClubActivity = true;
						this.S.Police.FadeOut = true;
						this.S.Interaction = 0;
					}
					else
					{
						this.S.DialogueWheel.End();
					}
				}
			}
			else if (this.S.Interaction == 15)
			{
				if (this.S.TalkTimer == (float)5)
				{
					this.S.Subtitle.UpdateLabel("Club Unwelcome", this.S.Club, (float)99);
					this.S.TalkTimer = this.S.Subtitle.CurrentClip.audio.clip.length;
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = (float)0;
					}
					if (this.S.TalkTimer <= (float)0)
					{
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer = this.S.TalkTimer - Time.deltaTime;
			}
			else if (this.S.Interaction == 16)
			{
				if (this.S.TalkTimer == (float)5)
				{
					this.S.Subtitle.UpdateLabel("Club Kick", this.S.Club, (float)99);
					this.S.TalkTimer = this.S.Subtitle.CurrentClip.audio.clip.length;
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						this.S.TalkTimer = (float)0;
					}
					if (this.S.TalkTimer <= (float)0)
					{
						PlayerPrefs.SetInt("Club", 0);
						this.S.DialogueWheel.End();
					}
				}
				this.S.TalkTimer = this.S.TalkTimer - Time.deltaTime;
			}
			else if (this.S.Interaction == 20)
			{
				if (this.S.TalkTimer == (float)3)
				{
					if (!this.S.Fed)
					{
						this.S.Character.animation.CrossFade(this.S.Nod2Anim);
						this.S.Subtitle.UpdateLabel("Accept Food", 0, (float)3);
						this.S.RepBonus = 0;
						if (PlayerPrefs.GetInt("PantiesEquipped") == 3)
						{
							this.S.RepBonus = this.S.RepBonus + 1;
						}
						if ((this.S.Male && PlayerPrefs.GetInt("Seduction") > 0) || PlayerPrefs.GetInt("Seduction") == 5)
						{
							this.S.RepBonus = this.S.RepBonus + 1;
						}
						this.S.Reputation.PendingRep = this.S.Reputation.PendingRep + (float)(5 + this.S.RepBonus);
						this.S.PendingRep = this.S.PendingRep + (float)(5 + this.S.RepBonus);
					}
					else
					{
						this.S.Character.animation.CrossFade(this.S.GossipAnim);
						this.S.Subtitle.UpdateLabel("Reject Food", 0, (float)3);
					}
				}
				else if (Input.GetButtonDown("A"))
				{
					this.S.TalkTimer = (float)0;
				}
				if (this.S.Character.animation[this.S.Nod2Anim].time >= this.S.Character.animation[this.S.Nod2Anim].length)
				{
					this.S.Character.animation.CrossFade(this.S.IdleAnim);
				}
				if (this.S.Character.animation[this.S.GossipAnim].time >= this.S.Character.animation[this.S.GossipAnim].length)
				{
					this.S.Character.animation.CrossFade(this.S.IdleAnim);
				}
				this.S.TalkTimer = this.S.TalkTimer - Time.deltaTime;
				if (this.S.TalkTimer <= (float)0)
				{
					if (!this.S.Fed)
					{
						this.S.Yandere.PickUp.FoodPieces[this.S.Yandere.PickUp.Food].active = false;
						this.S.Yandere.PickUp.Food = this.S.Yandere.PickUp.Food - 1;
						this.S.Fed = true;
					}
					this.S.DialogueWheel.End();
					this.S.StudentManager.UpdateStudents();
				}
			}
			if (this.S.Waiting)
			{
				this.S.WaitTimer = this.S.WaitTimer - Time.deltaTime;
				if (this.S.WaitTimer <= (float)0)
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
							this.S.Hearts.enableEmission = false;
						}
					}
					this.S.StudentManager.EnablePrompts();
				}
			}
			else
			{
				this.S.targetRotation = Quaternion.LookRotation(this.S.Yandere.transform.position - this.transform.position);
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.S.targetRotation, (float)10 * Time.deltaTime);
			}
		}
	}

	public virtual void Main()
	{
	}
}
