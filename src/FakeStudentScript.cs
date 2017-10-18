using System;
using UnityEngine;

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

	public ClubType Club;

	private void Start()
	{
		this.targetRotation = base.transform.rotation;
		this.Student.Club = this.Club;
	}

	private void Update()
	{
		if (!this.Student.Talking && this.Rotate)
		{
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
			this.RotationTimer += Time.deltaTime;
			if (this.RotationTimer > 1f)
			{
				this.RotationTimer = 0f;
				this.Rotate = false;
			}
		}
		if (this.Prompt.Circle[0].fillAmount == 0f && !this.Yandere.Chased)
		{
			this.Yandere.TargetStudent = this.Student;
			this.Subtitle.UpdateLabel(ReactionType.ClubGreeting, (int)this.Student.Club, 4f);
			this.DialogueWheel.ClubLeader = true;
			this.StudentManager.DisablePrompts();
			this.DialogueWheel.HideShadows();
			this.DialogueWheel.Show = true;
			this.DialogueWheel.Panel.enabled = true;
			this.Student.Talking = true;
			this.Student.TalkTimer = 0f;
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
}
