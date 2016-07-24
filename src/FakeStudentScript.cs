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

	public float RotationTimer;

	public bool Rotate;

	public int Club;

	public virtual void Start()
	{
		this.targetRotation = this.transform.rotation;
		this.Student.Club = this.Club;
	}

	public virtual void Update()
	{
		if (!this.Student.Talking && this.Rotate)
		{
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
			this.RotationTimer += Time.deltaTime;
			if (this.RotationTimer > (float)1)
			{
				this.RotationTimer = (float)0;
				this.Rotate = false;
			}
		}
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Yandere.TargetStudent = this.Student;
			this.Subtitle.UpdateLabel("Club Greeting", this.Student.Club, (float)4);
			this.DialogueWheel.ClubLeader = true;
			this.StudentManager.DisablePrompts();
			this.DialogueWheel.HideShadows();
			this.DialogueWheel.Show = true;
			this.DialogueWheel.Panel.enabled = true;
			this.Student.Talking = true;
			this.Student.TalkTimer = (float)0;
			this.Yandere.ShoulderCamera.OverShoulder = true;
			this.Yandere.WeaponMenu.KeyboardShow = false;
			this.Yandere.Obscurance.enabled = false;
			this.Yandere.WeaponMenu.Show = false;
			this.Yandere.YandereVision = false;
			this.Yandere.CanMove = false;
			this.Yandere.Talking = true;
			this.Rotate = true;
		}
	}

	public virtual void Main()
	{
	}
}
