using System;
using UnityEngine;

[Serializable]
public class WeaponScript : MonoBehaviour
{
	public ColoredOutlineScript Outline;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Collider MyCollider;

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
	}

	public virtual void LateUpdate()
	{
		if (this.Prompt.Circle[3].fillAmount <= (float)0)
		{
			this.Outline.color = new Color((float)0, (float)0, (float)0, (float)1);
			this.transform.parent = this.Yandere.ItemParent;
			this.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
			this.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
			this.MyCollider.enabled = false;
			this.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			this.Yandere.Weapon = this;
			this.Yandere.Armed = true;
			this.Yandere.StudentManager.UpdateStudents();
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Yandere.NearestPrompt = null;
			this.Yandere.NotificationManager.DisplayNotification("Armed");
		}
		if (this.Yandere.Armed)
		{
			this.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
			this.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		}
	}

	public virtual void Drop()
	{
		this.Outline.color = new Color((float)0, (float)1, (float)1, (float)1);
		this.transform.parent = null;
		this.MyCollider.enabled = true;
		this.rigidbody.constraints = RigidbodyConstraints.None;
		this.Yandere.Weapon = null;
		this.Yandere.Armed = false;
		this.Yandere.StudentManager.UpdateStudents();
		this.Prompt.enabled = true;
	}

	public virtual void Main()
	{
	}
}
