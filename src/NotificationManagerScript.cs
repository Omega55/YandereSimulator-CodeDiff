using System;
using UnityEngine;

public class NotificationManagerScript : MonoBehaviour
{
	public YandereScript Yandere;

	public Transform NotificationSpawnPoint;

	public Transform NotificationParent;

	public GameObject Notification;

	public int NotificationsSpawned;

	public int Phase = 1;

	public ClockScript Clock;

	private void Update()
	{
		if (this.NotificationParent.localPosition.y > 0.001f + -0.049f * (float)this.NotificationsSpawned)
		{
			this.NotificationParent.localPosition = new Vector3(this.NotificationParent.localPosition.x, Mathf.Lerp(this.NotificationParent.localPosition.y, -0.049f * (float)this.NotificationsSpawned, Time.deltaTime * 10f), this.NotificationParent.localPosition.z);
		}
		if (this.Phase == 1)
		{
			if (this.Clock.HourTime > 8.4f)
			{
				this.DisplayNotification("Class Soon");
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			if (this.Clock.HourTime > 8.5f)
			{
				this.DisplayNotification("Class Now");
				this.Phase++;
			}
		}
		else if (this.Phase == 3)
		{
			if (this.Clock.HourTime > 13.4f)
			{
				this.DisplayNotification("Class Soon");
				this.Phase++;
			}
		}
		else if (this.Phase == 4 && this.Clock.HourTime > 13.5f)
		{
			this.DisplayNotification("Class Now");
			this.Phase++;
		}
	}

	public void DisplayNotification(string Type)
	{
		if (!this.Yandere.Egg)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Notification);
			NotificationScript component = gameObject.GetComponent<NotificationScript>();
			gameObject.transform.parent = this.NotificationParent;
			gameObject.transform.localPosition = new Vector3(0f, 0.60275f + 0.049f * (float)this.NotificationsSpawned, 0f);
			gameObject.transform.localEulerAngles = Vector3.zero;
			component.NotificationManager = this;
			if (Type == "Bloody")
			{
				component.Label.text = "Visibly Bloody";
			}
			else if (Type == "Body")
			{
				component.Label.text = "Near Body";
			}
			else if (Type == "Insane")
			{
				component.Label.text = "Visibly Insane";
			}
			else if (Type == "Armed")
			{
				component.Label.text = "Visibly Armed";
			}
			else if (Type == "Lewd")
			{
				component.Label.text = "Visibly Lewd";
			}
			else if (Type == "Intrude")
			{
				component.Label.text = "Intruding";
			}
			else if (Type == "Late")
			{
				component.Label.text = "Late For Class";
			}
			else if (Type == "Info")
			{
				component.Label.text = "Learned New Info";
			}
			else if (Type == "Topic")
			{
				component.Label.text = "Learned New Topic";
			}
			else if (Type == "Opinion")
			{
				component.Label.text = "Learned Opinion";
			}
			else if (Type == "Complete")
			{
				component.Label.text = "Mission Complete";
			}
			else if (Type == "Exfiltrate")
			{
				component.Label.text = "Leave School";
			}
			else if (Type == "Class Soon")
			{
				component.Label.text = "Class Begins Soon";
			}
			else if (Type == "Class Now")
			{
				component.Label.text = "Class Begins Now";
			}
			this.NotificationsSpawned++;
			component.ID = this.NotificationsSpawned;
		}
	}
}
