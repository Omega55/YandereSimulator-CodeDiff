using System;
using UnityEngine;

[Serializable]
public class NotificationManagerScript : MonoBehaviour
{
	public YandereScript Yandere;

	public Transform NotificationSpawnPoint;

	public Transform NotificationParent;

	public GameObject Notification;

	public int NotificationsSpawned;

	public int Phase;

	public ClockScript Clock;

	public NotificationManagerScript()
	{
		this.Phase = 1;
	}

	public virtual void Update()
	{
		if (this.NotificationParent.localPosition.y > 0.001f + -0.049f * (float)this.NotificationsSpawned)
		{
			float y = Mathf.Lerp(this.NotificationParent.localPosition.y, -0.049f * (float)this.NotificationsSpawned, Time.deltaTime * (float)10);
			Vector3 localPosition = this.NotificationParent.localPosition;
			float num = localPosition.y = y;
			Vector3 vector = this.NotificationParent.localPosition = localPosition;
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

	public virtual void DisplayNotification(string Type)
	{
		if (!this.Yandere.Egg)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.Notification);
			NotificationScript notificationScript = (NotificationScript)gameObject.GetComponent(typeof(NotificationScript));
			gameObject.transform.parent = this.NotificationParent;
			gameObject.transform.localPosition = new Vector3((float)0, 0.60275f + 0.049f * (float)this.NotificationsSpawned, (float)0);
			gameObject.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
			notificationScript.NotificationManager = this;
			if (Type == "Bloody")
			{
				notificationScript.Label.text = "Visibly Bloody";
			}
			else if (Type == "Body")
			{
				notificationScript.Label.text = "Near Body";
			}
			else if (Type == "Insane")
			{
				notificationScript.Label.text = "Visibly Insane";
			}
			else if (Type == "Armed")
			{
				notificationScript.Label.text = "Visibly Armed";
			}
			else if (Type == "Lewd")
			{
				notificationScript.Label.text = "Visibly Lewd";
			}
			else if (Type == "Intrude")
			{
				notificationScript.Label.text = "Intruding";
			}
			else if (Type == "Late")
			{
				notificationScript.Label.text = "Late For Class";
			}
			else if (Type == "Info")
			{
				notificationScript.Label.text = "Learned New Info";
			}
			else if (Type == "Topic")
			{
				notificationScript.Label.text = "Learned New Topic";
			}
			else if (Type == "Opinion")
			{
				notificationScript.Label.text = "Learned Opinion";
			}
			else if (Type == "Complete")
			{
				notificationScript.Label.text = "Mission Complete";
			}
			else if (Type == "Exfiltrate")
			{
				notificationScript.Label.text = "Leave School";
			}
			else if (Type == "Class Soon")
			{
				notificationScript.Label.text = "Class Begins Soon";
			}
			else if (Type == "Class Now")
			{
				notificationScript.Label.text = "Class Begins Now";
			}
			this.NotificationsSpawned++;
			notificationScript.ID = this.NotificationsSpawned;
		}
	}

	public virtual void Main()
	{
	}
}
