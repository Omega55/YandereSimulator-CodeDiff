using System;
using UnityEngine;

[Serializable]
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

	public virtual void Start()
	{
		this.Panel.active = false;
	}

	public virtual void Update()
	{
		if (this.Prompt.Yandere.PickUp == null && !this.Prompt.Yandere.Dragging)
		{
			this.Prompt.HideButton[3] = false;
		}
		else
		{
			this.Prompt.HideButton[3] = true;
		}
		if (this.Prompt.Circle[3].fillAmount <= (float)0)
		{
			this.Prompt.Circle[3].fillAmount = (float)1;
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
			this.Prompt.Yandere.transform.rotation = Quaternion.Lerp(this.Prompt.Yandere.transform.rotation, this.GrabSpot.rotation, Time.deltaTime * (float)10);
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
				float x = this.transform.parent.transform.position.x - Time.deltaTime;
				Vector3 position = this.transform.parent.transform.position;
				float num = position.x = x;
				Vector3 vector = this.transform.parent.transform.position = position;
			}
			else if (Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("DpadX") < -0.5f)
			{
				float x2 = this.transform.parent.transform.position.x + Time.deltaTime;
				Vector3 position2 = this.transform.parent.transform.position;
				float num2 = position2.x = x2;
				Vector3 vector2 = this.transform.parent.transform.position = position2;
			}
			if (this.PullLimit < this.PushLimit)
			{
				if (this.transform.parent.transform.position.x < this.PullLimit)
				{
					float pullLimit = this.PullLimit;
					Vector3 position3 = this.transform.parent.transform.position;
					float num3 = position3.x = pullLimit;
					Vector3 vector3 = this.transform.parent.transform.position = position3;
				}
				else if (this.transform.parent.transform.position.x > this.PushLimit)
				{
					float pushLimit = this.PushLimit;
					Vector3 position4 = this.transform.parent.transform.position;
					float num4 = position4.x = pushLimit;
					Vector3 vector4 = this.transform.parent.transform.position = position4;
				}
			}
			else if (this.transform.parent.transform.position.x > this.PullLimit)
			{
				float pullLimit2 = this.PullLimit;
				Vector3 position5 = this.transform.parent.transform.position;
				float num5 = position5.x = pullLimit2;
				Vector3 vector5 = this.transform.parent.transform.position = position5;
			}
			else if (this.transform.parent.transform.position.x < this.PushLimit)
			{
				float pushLimit2 = this.PushLimit;
				Vector3 position6 = this.transform.parent.transform.position;
				float num6 = position6.x = pushLimit2;
				Vector3 vector6 = this.transform.parent.transform.position = position6;
			}
			if (this.DumpsterLid.transform.position.x > this.DumpsterLid.DisposalSpot - 0.05f && this.DumpsterLid.transform.position.x < this.DumpsterLid.DisposalSpot + 0.05f)
			{
				this.Panel.active = true;
			}
			else
			{
				this.Panel.active = false;
			}
			if (Input.GetButtonDown("B"))
			{
				this.Prompt.Yandere.DumpsterGrabbing = false;
				this.Prompt.Yandere.CanMove = true;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
				this.Panel.active = false;
				this.Grabbed = false;
			}
		}
	}

	public virtual void Main()
	{
	}
}
