using System;
using UnityEngine;

public class TranqCaseScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public DoorScript Door;

	public Transform Hinge;

	public bool Occupied;

	public bool Open;

	public int VictimID;

	private void Start()
	{
		this.Prompt.enabled = false;
	}

	private void Update()
	{
		if (this.Yandere.transform.position.x > base.transform.position.x && Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 1f)
		{
			if (this.Yandere.Dragging)
			{
				if (this.Yandere.Ragdoll.GetComponent<RagdollScript>().Tranquil)
				{
					if (!this.Prompt.enabled)
					{
						this.Prompt.enabled = true;
					}
				}
				else if (this.Prompt.enabled)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Prompt.enabled && this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.TranquilHiding = true;
			this.Yandere.CanMove = false;
			this.Prompt.enabled = false;
			this.Prompt.Hide();
			this.Yandere.Ragdoll.GetComponent<RagdollScript>().TranqCase = this;
			this.VictimID = this.Yandere.Ragdoll.GetComponent<RagdollScript>().StudentID;
			this.Door.Prompt.enabled = true;
			this.Door.enabled = true;
			this.Occupied = true;
			this.Open = true;
		}
		this.Hinge.localEulerAngles = new Vector3(this.Hinge.localEulerAngles.x, this.Hinge.localEulerAngles.y, Mathf.Lerp(this.Hinge.localEulerAngles.z, (!this.Open) ? 0f : 135f, Time.deltaTime * 10f));
	}
}
