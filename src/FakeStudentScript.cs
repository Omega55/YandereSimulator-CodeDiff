using System;
using UnityEngine;

[Serializable]
public class FakeStudentScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public DialogueWheelScript DialogueWheel;

	public SubtitleScript Subtitle;

	public YandereScript Yandere;

	public StudentScript Student;

	public PromptScript Prompt;

	public Quaternion targetRotation;

	public int Club;

	public virtual void Start()
	{
		this.targetRotation = this.transform.rotation;
		this.Student.Club = this.Club;
	}

	public virtual void Update()
	{
		if (!this.Student.Talking)
		{
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
		}
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Yandere.TargetStudent = this.Student;
			this.Subtitle.UpdateLabel("Club Greeting", this.Student.Club, (float)4);
			this.DialogueWheel.ClubLeader = true;
			this.StudentManager.DisablePrompts();
			this.DialogueWheel.HideShadows();
			this.DialogueWheel.Show = true;
			this.Student.Talking = true;
			this.Student.TalkTimer = (float)0;
			this.Yandere.ShoulderCamera.OverShoulder = true;
			this.Yandere.WeaponMenu.KeyboardShow = false;
			this.Yandere.Obscurance.enabled = false;
			this.Yandere.WeaponMenu.Show = false;
			this.Yandere.YandereVision = false;
			this.Yandere.CanMove = false;
			this.Yandere.Talking = true;
		}
	}

	public virtual void Main()
	{
	}
}
