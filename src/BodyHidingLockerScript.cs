using System;
using UnityEngine;

public class BodyHidingLockerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public RagdollScript Corpse;

	public PromptScript Prompt;

	public AudioClip LockerClose;

	public AudioClip LockerOpen;

	public float Rotation;

	public float Speed;

	public Transform Door;

	public int StudentID;

	public bool ABC;

	private void Update()
	{
		if (this.Rotation != 0f)
		{
			this.Speed += Time.deltaTime * 100f;
			this.Rotation = Mathf.MoveTowards(this.Rotation, 0f, this.Speed * Time.deltaTime);
			if (this.Rotation > -1f)
			{
				AudioSource.PlayClipAtPoint(this.LockerClose, this.Prompt.Yandere.MainCamera.transform.position);
				if (this.Corpse != null)
				{
					this.Corpse.gameObject.SetActive(false);
				}
				this.Prompt.enabled = true;
				this.Rotation = 0f;
				this.Speed = 0f;
				if (this.ABC)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					base.enabled = false;
				}
			}
			this.Door.transform.localEulerAngles = new Vector3(0f, this.Rotation, 0f);
		}
		if (this.Corpse == null)
		{
			if (this.Prompt.Yandere.Carrying || this.Prompt.Yandere.Dragging)
			{
				this.Prompt.enabled = true;
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					this.Prompt.Circle[0].fillAmount = 1f;
					AudioSource.PlayClipAtPoint(this.LockerOpen, this.Prompt.Yandere.MainCamera.transform.position);
					if (this.Prompt.Yandere.Carrying)
					{
						this.Corpse = this.Prompt.Yandere.CurrentRagdoll;
					}
					else
					{
						this.Corpse = this.Prompt.Yandere.Ragdoll.GetComponent<RagdollScript>();
					}
					this.Prompt.Label[0].text = "     Remove Corpse";
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					this.Prompt.Yandere.EmptyHands();
					this.Prompt.Yandere.NearBodies = 0;
					this.Prompt.Yandere.NearestCorpseID = 0;
					this.Prompt.Yandere.CorpseWarning = false;
					this.Prompt.Yandere.StudentManager.UpdateStudents(0);
					this.Corpse.transform.parent = base.transform;
					this.Corpse.transform.position = base.transform.position + new Vector3(0f, 0.1f, 0f);
					this.Corpse.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
					this.Corpse.Police.HiddenCorpses++;
					this.Corpse.enabled = false;
					this.Corpse.Hidden = true;
					this.StudentID = this.Corpse.StudentID;
					if (this.ABC)
					{
						this.Corpse.DestroyRigidbodies();
					}
					else
					{
						this.Corpse.BloodSpawnerCollider.enabled = false;
						this.Corpse.Prompt.MyCollider.enabled = false;
						this.Corpse.BloodPoolSpawner.enabled = false;
						this.Corpse.DisableRigidbodies();
					}
					this.Corpse.Student.CharacterAnimation.enabled = true;
					this.Corpse.Student.CharacterAnimation.Play("f02_lockerPose_00");
					this.Rotation = -180f;
					return;
				}
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				return;
			}
		}
		else if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Prompt.Label[0].text = "     Hide Corpse";
			AudioSource.PlayClipAtPoint(this.LockerOpen, this.Prompt.Yandere.MainCamera.transform.position);
			this.Corpse.enabled = true;
			this.Corpse.gameObject.SetActive(true);
			this.Corpse.CharacterAnimation.enabled = false;
			this.Corpse.transform.localPosition = new Vector3(0f, 0f, 0.5f);
			this.Corpse.transform.localEulerAngles = new Vector3(0f, -90f, 0.5f);
			this.Corpse.transform.parent = null;
			this.Corpse.BloodSpawnerCollider.enabled = true;
			this.Corpse.Prompt.MyCollider.enabled = true;
			this.Corpse.BloodPoolSpawner.NearbyBlood = 0;
			this.Corpse.EnableRigidbodies();
			if (!this.Corpse.Cauterized)
			{
				this.Corpse.BloodPoolSpawner.enabled = true;
			}
			this.Corpse = null;
			this.Rotation = -180f;
		}
	}

	public void UpdateCorpse()
	{
		this.Corpse = this.StudentManager.Students[this.StudentID].Ragdoll;
		this.Corpse.transform.parent = base.transform;
		this.Prompt.Label[0].text = "     Remove Corpse";
		this.Prompt.enabled = true;
	}
}
