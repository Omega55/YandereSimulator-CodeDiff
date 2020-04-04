using System;
using UnityEngine;

public class BodyHidingLockerScript : MonoBehaviour
{
	public RagdollScript Corpse;

	public PromptScript Prompt;

	public AudioClip LockerClose;

	public AudioClip LockerOpen;

	public float Rotation;

	public float Speed;

	public Transform Door;

	private void Update()
	{
		if (this.Rotation != 0f)
		{
			this.Speed += Time.deltaTime * 100f;
			this.Rotation = Mathf.MoveTowards(this.Rotation, 0f, this.Speed * Time.deltaTime);
			if (this.Rotation > -1f)
			{
				AudioSource.PlayClipAtPoint(this.LockerClose, this.Prompt.Yandere.MainCamera.transform.position);
				this.Corpse.gameObject.SetActive(false);
				base.enabled = false;
				this.Rotation = 0f;
				this.Speed = 0f;
			}
			this.Door.transform.localEulerAngles = new Vector3(0f, this.Rotation, 0f);
		}
		if (this.Prompt.Yandere.Carrying || this.Prompt.Yandere.Dragging)
		{
			this.Prompt.enabled = true;
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				AudioSource.PlayClipAtPoint(this.LockerOpen, this.Prompt.Yandere.MainCamera.transform.position);
				this.Corpse = this.Prompt.Yandere.CurrentRagdoll;
				this.Prompt.Yandere.EmptyHands();
				this.Corpse.Student.CharacterAnimation.Play("f02_lockerPose_00");
				this.Corpse.transform.parent = base.transform;
				this.Corpse.transform.position = base.transform.position + new Vector3(0f, 0.1f, 0f);
				this.Corpse.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
				this.Corpse.DisableRigidbodies();
				this.Corpse.enabled = false;
				this.Corpse.Hidden = true;
				this.Rotation = -180f;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}
}
