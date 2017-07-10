using System;
using UnityEngine;

public class DumpsterHandleScript : MonoBehaviour
{
	public DumpsterLidScript DumpsterLid;

	public PromptBarScript PromptBar;

	public PromptScript Prompt;

	public Transform GrabSpot;

	public GameObject Panel;

	public bool Grabbed;

	public float Direction;

	public float PullLimit;

	public float PushLimit;

	private void Start()
	{
		this.Panel.SetActive(false);
	}

	private void Update()
	{
		this.Prompt.HideButton[3] = (this.Prompt.Yandere.PickUp != null || this.Prompt.Yandere.Dragging || this.Prompt.Yandere.Carrying);
		if (this.Prompt.Circle[3].fillAmount <= 0f)
		{
			this.Prompt.Circle[3].fillAmount = 1f;
			this.Prompt.Yandere.DumpsterGrabbing = true;
			this.Prompt.Yandere.DumpsterHandle = this;
			this.Prompt.Yandere.CanMove = false;
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[1].text = "STOP";
			this.PromptBar.Label[5].text = "PUSH / PULL";
			this.PromptBar.UpdateButtons();
			this.PromptBar.Show = true;
			this.Grabbed = true;
		}
		if (this.Grabbed)
		{
			this.Prompt.Yandere.transform.rotation = Quaternion.Lerp(this.Prompt.Yandere.transform.rotation, this.GrabSpot.rotation, Time.deltaTime * 10f);
			if (Vector3.Distance(this.Prompt.Yandere.transform.position, this.GrabSpot.position) > 0.1f)
			{
				this.Prompt.Yandere.MoveTowardsTarget(this.GrabSpot.position);
			}
			else
			{
				this.Prompt.Yandere.transform.position = this.GrabSpot.position;
			}
			if (Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("DpadX") > 0.5f)
			{
				base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, base.transform.parent.transform.position.z - Time.deltaTime);
			}
			else if (Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("DpadX") < -0.5f)
			{
				base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, base.transform.parent.transform.position.z + Time.deltaTime);
			}
			if (this.PullLimit < this.PushLimit)
			{
				if (base.transform.parent.transform.position.z < this.PullLimit)
				{
					base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, this.PullLimit);
				}
				else if (base.transform.parent.transform.position.z > this.PushLimit)
				{
					base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, this.PushLimit);
				}
			}
			else if (base.transform.parent.transform.position.z > this.PullLimit)
			{
				base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, this.PullLimit);
			}
			else if (base.transform.parent.transform.position.z < this.PushLimit)
			{
				base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, this.PushLimit);
			}
			this.Panel.SetActive(this.DumpsterLid.transform.position.z > this.DumpsterLid.DisposalSpot - 0.05f && this.DumpsterLid.transform.position.z < this.DumpsterLid.DisposalSpot + 0.05f);
			if (Input.GetButtonDown("B"))
			{
				this.Prompt.Yandere.DumpsterGrabbing = false;
				this.Prompt.Yandere.CanMove = true;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
				this.Panel.SetActive(false);
				this.Grabbed = false;
			}
		}
	}
}
