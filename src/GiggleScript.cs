﻿using System;
using UnityEngine;

public class GiggleScript : MonoBehaviour
{
	public GameObject EmptyGameObject;

	public GameObject Giggle;

	public StudentScript Student;

	public bool StudentIsBusy;

	public bool Distracted;

	public int Frame;

	private void Start()
	{
		float num = 500f * (2f - SchoolGlobals.SchoolAtmosphere);
		base.transform.localScale = new Vector3(num, base.transform.localScale.y, num);
	}

	private void Update()
	{
		if (this.Frame > 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		this.Frame++;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9 && !this.Distracted)
		{
			this.Student = other.gameObject.GetComponent<StudentScript>();
			if (this.Student != null && this.Student.Giggle == null)
			{
				if (this.Student.StudentManager.LockerRoomArea.bounds.Contains(base.transform.position) || this.Student.StudentManager.WestBathroomArea.bounds.Contains(base.transform.position) || this.Student.StudentManager.EastBathroomArea.bounds.Contains(base.transform.position) || (this.Student.Club != ClubType.Delinquent && this.Student.StudentManager.IncineratorArea.bounds.Contains(base.transform.position)) || this.Student.StudentManager.HeadmasterArea.bounds.Contains(base.transform.position))
				{
					this.Student.Yandere.NotificationManager.CustomText = this.Student.Name + " ignored a giggle.";
					this.Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					return;
				}
				if (this.Student.Clock.Period == 3 && this.Student.BusyAtLunch)
				{
					this.StudentIsBusy = true;
				}
				if ((this.Student.StudentID == 47 || this.Student.StudentID == 49) && this.Student.StudentManager.ConvoManager.Confirmed)
				{
					this.StudentIsBusy = true;
				}
				if (this.Student.StudentID == this.Student.StudentManager.RivalID || this.Student.StudentID == 1)
				{
					StudentActionType currentAction = this.Student.CurrentAction;
				}
				if (!this.Student.YandereVisible && !this.Student.Alarmed && !this.Student.Distracted && !this.Student.Wet && !this.Student.Slave && !this.Student.WitnessedMurder && !this.Student.WitnessedCorpse && !this.Student.Investigating && !this.Student.InEvent && !this.Student.Following && !this.Student.Confessing && !this.Student.Meeting && !this.Student.TurnOffRadio && !this.Student.Fleeing && !this.Student.Distracting && !this.Student.GoAway && !this.Student.FocusOnYandere && !this.StudentIsBusy && this.Student.Actions[this.Student.Phase] != StudentActionType.Teaching && this.Student.Actions[this.Student.Phase] != StudentActionType.SitAndTakeNotes && this.Student.Actions[this.Student.Phase] != StudentActionType.Graffiti && this.Student.Actions[this.Student.Phase] != StudentActionType.Bully && this.Student.Routine && !this.Student.Headache && this.Student.Persona != PersonaType.Protective && !this.Student.MyBento.Tampered)
				{
					this.Student.CharacterAnimation.CrossFade(this.Student.IdleAnim);
					this.Giggle = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, new Vector3(base.transform.position.x, this.Student.transform.position.y, base.transform.position.z), Quaternion.identity);
					this.Student.Giggle = this.Giggle;
					if (this.Student.Pathfinding != null && !this.Student.Nemesis)
					{
						if (this.Student.Drownable)
						{
							this.Student.Drownable = false;
							this.Student.StudentManager.UpdateMe(this.Student.StudentID);
						}
						if (this.Student.ChalkDust.isPlaying)
						{
							this.Student.ChalkDust.Stop();
							this.Student.Pushable = false;
							this.Student.StudentManager.UpdateMe(this.Student.StudentID);
						}
						this.Student.Pathfinding.canSearch = false;
						this.Student.Pathfinding.canMove = false;
						this.Student.InvestigationPhase = 0;
						this.Student.InvestigationTimer = 0f;
						this.Student.Investigating = true;
						this.Student.EatingSnack = false;
						this.Student.SpeechLines.Stop();
						this.Student.ChalkDust.Stop();
						this.Student.DiscCheck = true;
						this.Student.Routine = false;
						this.Student.CleanTimer = 0f;
						this.Student.ReadPhase = 0;
						this.Student.StopPairing();
						if (this.Student.SunbathePhase > 2)
						{
							this.Student.SunbathePhase = 2;
						}
						if (this.Student.Persona != PersonaType.PhoneAddict && !this.Student.Sleuthing)
						{
							this.Student.SmartPhone.SetActive(false);
						}
						else if (!this.Student.Phoneless)
						{
							this.Student.SmartPhone.SetActive(true);
						}
						this.Student.OccultBook.SetActive(false);
						this.Student.Pen.SetActive(false);
						if (!this.Student.Male)
						{
							this.Student.Cigarette.SetActive(false);
							this.Student.Lighter.SetActive(false);
						}
						bool flag = false;
						if (this.Student.Bento.activeInHierarchy && this.Student.StudentID > 1)
						{
							flag = true;
						}
						this.Student.EmptyHands();
						if (flag)
						{
							GenericBentoScript component = this.Student.Bento.GetComponent<GenericBentoScript>();
							component.enabled = true;
							component.Prompt.enabled = true;
							this.Student.Bento.SetActive(true);
							this.Student.Bento.transform.parent = this.Student.transform;
							if (this.Student.Male)
							{
								this.Student.Bento.transform.localPosition = new Vector3(0f, 0.4266666f, -0.075f);
							}
							else
							{
								this.Student.Bento.transform.localPosition = new Vector3(0f, 0.461f, -0.075f);
							}
							this.Student.Bento.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
							this.Student.Bento.transform.parent = null;
						}
						this.Student.Yandere.NotificationManager.CustomText = this.Student.Name + " heard a giggle.";
						this.Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
					this.Distracted = true;
				}
			}
		}
	}
}
