using System;
using UnityEngine;

public class DumpsterLidScript : MonoBehaviour
{
	public StudentScript Victim;

	public Transform SlideLocation;

	public Transform GarbageDebris;

	public Transform Hinge;

	public GameObject FallChecker;

	public GameObject Corpse;

	public PromptScript[] DragPrompts;

	public PromptScript Prompt;

	public float DisposalSpot;

	public float Rotation;

	public bool Slide;

	public bool Fill;

	public bool Open;

	public int StudentToGoMissing;

	private void Start()
	{
		this.FallChecker.SetActive(false);
		this.Prompt.HideButton[3] = true;
	}

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Open)
			{
				this.Prompt.Label[0].text = "     Close";
				this.Open = true;
			}
			else
			{
				this.Prompt.Label[0].text = "     Open";
				this.Open = false;
			}
		}
		if (!this.Open)
		{
			this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 10f);
			this.Prompt.HideButton[3] = true;
		}
		else
		{
			this.Rotation = Mathf.Lerp(this.Rotation, -115f, Time.deltaTime * 10f);
			if (this.Corpse != null)
			{
				if (this.Prompt.Yandere.PickUp != null)
				{
					this.Prompt.HideButton[3] = !this.Prompt.Yandere.PickUp.Garbage;
				}
				else
				{
					this.Prompt.HideButton[3] = true;
				}
			}
			else
			{
				this.Prompt.HideButton[3] = true;
			}
			if (this.Prompt.Circle[3].fillAmount == 0f)
			{
				Object.Destroy(this.Prompt.Yandere.PickUp.gameObject);
				this.Prompt.Circle[3].fillAmount = 1f;
				this.Prompt.HideButton[3] = false;
				this.Fill = true;
			}
			if (base.transform.position.z > this.DisposalSpot - 0.05f && base.transform.position.z < this.DisposalSpot + 0.05f)
			{
				this.FallChecker.SetActive(this.Prompt.Yandere.RoofPush);
			}
			else
			{
				this.FallChecker.SetActive(false);
			}
			if (this.Slide)
			{
				base.transform.eulerAngles = Vector3.Lerp(base.transform.eulerAngles, this.SlideLocation.eulerAngles, Time.deltaTime * 10f);
				base.transform.position = Vector3.Lerp(base.transform.position, this.SlideLocation.position, Time.deltaTime * 10f);
				this.Corpse.GetComponent<RagdollScript>().Student.Hips.position = base.transform.position + new Vector3(0f, 1f, 0f);
				if (Vector3.Distance(base.transform.position, this.SlideLocation.position) < 0.01f)
				{
					this.DragPrompts[0].enabled = false;
					this.DragPrompts[1].enabled = false;
					this.FallChecker.SetActive(false);
					this.Slide = false;
				}
			}
		}
		this.Hinge.localEulerAngles = new Vector3(this.Rotation, 0f, 0f);
		if (this.Fill)
		{
			this.GarbageDebris.localPosition = new Vector3(this.GarbageDebris.localPosition.x, Mathf.Lerp(this.GarbageDebris.localPosition.y, 1f, Time.deltaTime * 10f), this.GarbageDebris.localPosition.z);
			if (this.GarbageDebris.localPosition.y > 0.99f)
			{
				this.Prompt.Yandere.Police.SuicideScene = false;
				this.Prompt.Yandere.Police.Suicide = false;
				this.Prompt.Yandere.Police.HiddenCorpses--;
				this.Prompt.Yandere.Police.Corpses--;
				if (this.Corpse.GetComponent<RagdollScript>().AddingToCount)
				{
					this.Prompt.Yandere.NearBodies--;
				}
				this.GarbageDebris.localPosition = new Vector3(this.GarbageDebris.localPosition.x, 1f, this.GarbageDebris.localPosition.z);
				this.StudentToGoMissing = this.Corpse.GetComponent<StudentScript>().StudentID;
				Object.Destroy(this.Corpse);
				this.Fill = false;
				this.Prompt.Yandere.StudentManager.UpdateStudents(0);
			}
		}
	}

	public void SetVictimMissing()
	{
		StudentGlobals.SetStudentMissing(this.StudentToGoMissing, true);
	}
}
